---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 14.7.0
type: docs
weight: 60
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las [clases añadidas](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/), métodos, propiedades, etc., las nuevas restricciones y otros cambios introducidos con el API de Aspose.Slides para Java 14.7.0.

{{% /alert %}} 
## **Cambios en el API Público**
### **Se han eliminado los constructores de algunos subtipos de TransitionValueBase y se ha eliminado TransitionValueFactory**
Los constructores de algunos subtipos de TransitionValueBase (y específicamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) son inútiles en el API público y, por lo tanto, han sido eliminados. La clase relacionada TransitionValueFactory y su interfaz ITransitionValueFactory han sido eliminadas por la misma razón.
### **El elemento SoundAction ha sido eliminado de la enumeración com.aspose.slides.TransitionType**
El elemento SoundAction era incorrecto y no se utilizaba. Las configuraciones de sonido están definidas por las propiedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Se ha añadido la clase FlyThroughTransition y la interfaz IFlyThroughTransition**
La clase com.aspose.slides.FlyThroughTransition (y su interfaz com.aspose.slides.IFlyThroughTransition) se relaciona con el tipo de transición Flythrough que se ha soportado en esta versión.
### **Se ha añadido la clase GlitterTransition, la interfaz IGlitterTransition y la enumeración TransitionPattern**
La clase com.aspose.slides.GlitterTransition (y su interfaz com.aspose.slides.IGlitterTransition) se relaciona con el tipo de transición Glitter que se ha soportado en esta versión. 
La enumeración com.aspose.slides.TransitionPattern se utiliza en esta clase y especifica un patrón geométrico que se azuleja para llenar un área más grande.
### **Se ha añadido la clase LeftRightDirectionTransition, la interfaz ILeftRightDirectionTransition y la enumeración TransitionLeftRightDirectionType**
La clase com.aspose.slides.LeftRightDirectionTransition (y su interfaz com.aspose.slides.ILeftRightDirectionTransition) se relaciona con los tipos de transición Switch, Flip, Ferris, Gallery, Conveyor que se han soportado en esta versión. 
La enumeración com.aspose.slides.TransitionLeftRightDirectionType se utiliza en esta clase y especifica una dirección restringida a los valores de izquierda y derecha.
### **Se han añadido nuevos elementos en la enumeración com.aspose.slides.TransitionType**
La enumeración com.aspose.slides.TransitionType se ha ampliado con nuevos elementos. 
Nuevos elementos relacionados con las nuevas transiciones de PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. 
Nuevos elementos relacionados con las nuevas transiciones de PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Se ha añadido la clase RevealTransition y la interfaz IRevealTransition**
La clase com.aspose.slides.RevealTransition (y su interfaz com.aspose.slides.IRevealTransition) se relaciona con el tipo de transición Reveal que se ha soportado en esta versión. 
Se han añadido la clase RippleTransition, la interfaz IRippleTransition y la enumeración TransitionCornerAndCenterDirectionType.
La clase com.aspose.slides.RippleTransition (y su interfaz com.aspose.slides.IRippleTransition) se relaciona con el tipo de transición Ripple que se ha soportado en esta versión. 
La enumeración com.aspose.slides.TransitionCornerAndCenterDirectionType se utiliza en esta clase y especifica una dirección restringida a las esquinas y al centro.
### **Se ha añadido la clase ShredTransition, la interfaz IShredTransition y la enumeración TransitionShredPattern**
La clase com.aspose.slides.ShredTransition (y su interfaz com.aspose.slides.IShredTransition) se relaciona con el tipo de transición Shred que se ha soportado en esta versión. 
La enumeración com.aspose.slides.TransitionShredPattern se utiliza en esta clase y especifica una forma geométrica que se azuleja para llenar un área más grande.