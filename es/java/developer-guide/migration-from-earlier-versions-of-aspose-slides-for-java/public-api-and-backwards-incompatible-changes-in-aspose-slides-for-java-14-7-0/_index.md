---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para Java 14.7.0
linktitle: Aspose.Slides para Java 14.7.0
type: docs
weight: 60
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles con versiones anteriores en Aspose.Slides for Java para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás elementos [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) , cualquier nueva restricción y otros cambios introducidos con la API de Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Se han eliminado los constructores de algunos subtipos de TransitionValueBase y se ha eliminado TransitionValueFactory**
Los constructores de algunos subtipos de TransitionValueBase (y concretamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) son innecesarios en la API pública y, por tanto, se han eliminado. La clase relacionada TransitionValueFactory y su interfaz ITransitionValueFactory se han eliminado por la misma razón.
### **Se ha eliminado el elemento SoundAction de la enumeración com.aspose.slides.TransitionType**
El elemento SoundAction era incorrecto y no se utilizaba. Los ajustes de sonido se definen mediante las propiedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn y .SoundName.
### **Se han añadido la clase FlyThroughTransition y la interfaz IFlyThroughTransition**
La clase com.aspose.slides.FlyThroughTransition (y su interfaz com.aspose.slides.IFlyThroughTransition) se refiere al tipo de transición Flythrough que se ha soportado en esta versión.
### **Se han añadido la clase GlitterTransition, la interfaz IGlitterTransition y la enumeración TransitionPattern**
La clase com.aspose.slides.GlitterTransition (y su interfaz com.aspose.slides.IGlitterTransition) se refiere al tipo de transición Glitter que se ha soportado en esta versión.  
La enumeración com.aspose.slides.TransitionPattern se utiliza en esta clase y especifica un patrón geométrico que se repite para cubrir un área mayor.
### **Se han añadido la clase LeftRightDirectionTransition, la interfaz ILeftRightDirectionTransition y la enumeración TransitionLeftRightDirectionType**
La clase com.aspose.slides.LeftRightDirectionTransition (y su interfaz com.aspose.slides.ILeftRightDirectionTransition) se refiere a los tipos de transición Switch, Flip, Ferris, Gallery y Conveyor que se han soportado en esta versión.  
La enumeración com.aspose.slides.TransitionLeftRightDirectionType se utiliza en esta clase y especifica una dirección restringida a los valores left y right.
### **Se han añadido nuevos elementos a la enumeración com.aspose.slides.TransitionType**
La enumeración com.aspose.slides.TransitionType se ha ampliado con nuevos elementos.  
Nuevos elementos relacionados con transiciones de PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.  
Nuevos elementos relacionados con transiciones de PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Se han añadido la clase RevealTransition y la interfaz IRevealTransition**
La clase com.aspose.slides.RevealTransition (y su interfaz com.aspose.slides.IRevealTransition) se refiere al tipo de transición Reveal que se ha soportado en esta versión.  
Se han añadido la clase RippleTransition, la interfaz IRippleTransition y la enumeración TransitionCornerAndCenterDirectionType.  
La clase com.aspose.slides.RippleTransition (y su interfaz com.aspose.slides.IRippleTransition) se refiere al tipo de transición Ripple que se ha soportado en esta versión.  
La enumeración com.aspose.slides.TransitionCornerAndCenterDirectionType se utiliza en esta clase y especifica una dirección restringida a las esquinas y al centro.
### **Se han añadido la clase ShredTransition, la interfaz IShredTransition y la enumeración TransitionShredPattern**
La clase com.aspose.slides.ShredTransition (y su interfaz com.aspose.slides.IShredTransition) se refiere al tipo de transición Shred que se ha soportado en esta versión.  
La enumeración com.aspose.slides.TransitionShredPattern se utiliza en esta clase y especifica una forma geométrica que se repite para cubrir un área mayor.