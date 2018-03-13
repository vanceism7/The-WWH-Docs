# WHW -- Angular

## The Beginning

### 1. What does it do?
[Angular](https://angular.io) is a framework for building client applications in HTML and either JavaScript or a language like TypeScript that compiles to JavaScript.

The framework consists of several libraries, some of them core and some optional.

### 2. How does it do it?
You write Angular applications by composing [HTML templates](https://angular.io/guide/architecture#templates) with Angularized markup, writing [component](https://angular.io/guide/architecture#components) classes to manage those templates, adding application logic in services, and boxing components and services in [modules](https://angular.io/guide/architecture#modules).

Then you launch the app by [bootstrapping](https://angular.io/guide/bootstrapping) the root module. Angular takes over, presenting your application content in a browser and responding to user interactions according to the instructions you've provided.

### 3. Why do we use it?
It allows us to write rich web applications (RIA) as well as cross-platform desktop applications, essentially solving the issue of cross-platform application compatibility from the front end. Any language can be used as a back-end, there is no ecosystem dependability or lock-in

---
## [NgModule](https://angular.io/guide/ngmodules)

### 0. Pre-Requisites
- [Bootstrapping](https://angular.io/guide/bootstrapping)
- [JavaScript Modules vs. NgModules.](https://angular.io/guide/ngmodule-vs-jsmodule)

### 1. What does it do?
An NgModule is a class marked by the `@NgModule` decorator. NgModules box all of the components and services they have/use into a convenient package, and provides the ability to make their own internals public to external modules using the exports array. 
NgModules consolidate [components](https://angular.io/api/core/Component), [directives](https://angular.io/api/core/Directive), and [pipes](https://angular.io/guide/pipes) into cohesive blocks of functionality. 

### 2. How does it do it?
NgModules identify their different dependencies in the `@NgModule` metadata.

Some Common NgModule properties are: 
`declarations`: List of directives/pipes that belong to this module.
`exports`: List of directives/pipes/modules that can be used within the template of any component that is part of an Angular module that imports this Angular module.
`imports`: List of modules whose exported directives/pipes should be available to templates in this module.
`providers`: Defines the set of inject-able objects that are available in the injector of this module.
```
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
class ExampleModule {
}
```

The complete listing of ngmodule options can be found [here](https://angular.io/api/core/NgModule#metadata-overview)

### 3. Why does it do it?
NgModule wires together components, html templates, services, providers, etc, enabling them to work together cohesively without needing to manage the boilerplate code on your own.

---

## [Components](https://angular.io/api/core/Component)

### 1. What does it do?
Angular components are classes marked with the `@Component` decorator. They define the functionality and data used by the view. It is essentially the "code-behind" or "controller" code in [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)/[MVVM](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) style applications.
Angular components are a subset of [directives](https://angular.io/api/core/Directive).

*Links*
[`@Component`](https://angular.io/api/core/Component#metadata-overview) 

### 2. How does it do it?
You write functions on the component, just the way you would any other back-end controller class, and angular wires up your component to the view using the `@Component` [metadata](https://angular.io/guide/architecture#metadata) 

A component must belong to an [NgModule](https://angular.io/api/core/NgModule) in order for it to be usable by another component or application. To specify that a component is a member of an NgModule, you should list it in the [`declarations`](https://angular.io/api/core/NgModule#example) field of that NgModule. 


### 3. Why does it do it?
Separation of responsibilities: Its provides a good way to keep the view logic separate from the view itself. Also, because html is not very sophisticated and would not be capable of such real-time interaction by itself.

---
## [Views/Templates](https://angular.io/guide/template-syntax)

### 1. What does it do?
It displays a GUI to the user, allowing them a smooth interactive experience with your app. The views are written in html spruced up with Angular syntax provided by components and directives in the form of custom html tags and attributes

### 2. How does it do it?
Angularized html extends html with the following new syntax types:
- [Interpolation](https://angular.io/guide/template-syntax#interpolation----)
- [Binding](https://angular.io/guide/template-syntax#binding-syntax-an-overview)

The html extensions listed above are powered by [Template Expressions](https://angular.io/guide/template-syntax#template-expressions), and [Template Statements](https://angular.io/guide/template-syntax#template-statements).

### 3. Why does it do it?
Angular Templates allow a fluid interactive web experience, much closer to desktop applications than the original html static web pages

---
## [Interpolation](https://angular.io/guide/template-syntax#interpolation----)

### 1. What does it do?
Interpolation adds the ability to read in data dynamically from the views corresponding component class properties and methods. Data specified inside interpolation is called a [template expression](https://angular.io/guide/template-syntax#template-expressions) and is converted into a [property binding](https://angular.io/guide/template-syntax#property-binding)

### 2. How does it do it?
The Basic Syntax is: `{{ComponentProperty}}` `{{ComponentFunction()}}`  `{{1 + 1}}`

For example, if you had the following component class:
```
class Person {
	name: string 
}
class MyComponent {
	title: string
	heroImageUrl: string
	user: Person
	GetSomeText(): string {
		return "Some Text"
	}
}
```
The view can take advantage of these properties using them in this way
```
<p>Currently logged in as {{User.name}}</p>`
<h3>
	{{title}} -- {{GetSomeText()}}
	<img src="{{heroImageUrl}}" style="height:30px">
</h3>
```

### 3. Why does it do it.
It is one of the ways in which a view can pull dynamic data from its components

---
## [Data Binding](https://angular.io/guide/template-syntax#binding-syntax-an-overview)
### 1. What does it do?
It allows the view logic to change based on the components state

### 2. How does it do it?
Binding attaches data in the component to the various properties of the views html tags. The different types of data bindings are:
- [Property Binding](https://angular.io/guide/template-syntax#property-binding--property-)
- [Attribute, Class, and Style Binding](https://angular.io/guide/template-syntax#attribute-class-and-style-bindings)
- [Event Binding](https://angular.io/guide/template-syntax#event-binding---event-)
- [Two-Way Binding](https://angular.io/guide/template-syntax#two-way-binding---)

### 3. Why does it do it?
These are the various ways in which the angular views can interact with the user, and how its functionality can change based on it's components state

---
## [Template Statements](https://angular.io/guide/template-syntax#template-statements)

### 1. What does it do?
### 2. How does it do it?
### 3. Why does it do it?

---
## [Title](Link)
### 1. What does it do?
### 2. How does it do it?
### 3. Why does it do it?