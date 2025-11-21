---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.7.0
linktitle: Aspose.Slides para .NET 14.7.0
type: docs
weight: 90
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás elementos [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/), y los demás cambios introducidos con la API de Aspose.Slides for .NET 14.7.0. 

{{% /alert %}} 
## **Cambios de API Pública**
### **Constructores y Elementos Eliminados**
#### **Eliminados algunos constructores de subtipos de TransitionValueBase y TransitionValueFactory**
Los constructores de algunos subtipos de TransitionValueBase (específicamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) son inútiles en la API pública y por eso se han eliminado. 

La clase relacionada TransitionValueFactory y su interfaz ITransitionValueFactory se han eliminado por la misma razón. 
#### **Eliminado el elemento SoundAction de la enumeración Aspose.Slides.SlideShow.TransitionType**
El elemento SoundAction era incorrecto y no se utilizaba. Los ajustes de sonido se definen mediante las propiedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName. 
### **Clases e Interfaces Añadidas**
#### **Añadida la clase FlyThroughTransition y la interfaz IFlyThroughTransition**
La clase Aspose.Slides.SlideShow.FlyThroughTransition (y su interfaz Aspose.Slides.SlideShow.IFlyThroughTransition) se refiere al tipo de transición Flythrough admitido a partir de esta versión. 
#### **Añadida la clase GlitterTransition, la interfaz IGlitterTransition y la enumeración TransitionPattern**
La clase Aspose.Slides.SlideShow.GlitterTransition (y su interfaz Aspose.Slides.SlideShow.IGlitterTransition) se refiere al tipo de transición Glitter admitido a partir de esta versión. 

La enumeración Aspose.Slides.SlideShow.TransitionPattern se utiliza en esta clase y especifica un patrón geométrico que se repite para rellenar un área mayor. 
#### **Añadida la clase LeftRightDirectionTransition, la interfaz ILeftRightDirectionTransition y la enumeración TransitionLeftRightDirectionType**
La clase Aspose.Slides.SlideShow.LeftRightDirectionTransition (y su interfaz Aspose.Slides.SlideShow.ILeftRightDirectionTransition) se refiere a los tipos de transición Conveyor, Ferris, Flip, Gallery y Switch. Todos están admitidos a partir de esta versión. 

La enumeración Aspose.Slides.SlideShow.TransitionLeftRightDirectionType se utiliza en esta clase y especifica una dirección, restringida a los valores left y right. 
#### **Añadidos nuevos elementos a la enumeración Aspose.Slides.SlideShow.TransitionType**
La enumeración Aspose.Slides.SlideShow.TransitionType se ha ampliado con nuevos elementos. 

- Nuevos elementos relacionados con transiciones de PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- Nuevos elementos relacionados con transiciones de PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind. 
#### **Añadida la clase RevealTransition y la interfaz IRevealTransition**
La clase Aspose.Slides.SlideShow.RevealTransition (y su interfaz Aspose.Slides.SlideShow.IRevealTransition) se refiere al tipo de transición Reveal admitido a partir de esta versión. 
#### **Añadida la clase RippleTransition, la interfaz IRippleTransition y la enumeración TransitionCornerAndCenterDirectionType**
La clase Aspose.Slides.SlideShow.RippleTransition (y su interfaz Aspose.Slides.SlideShow.IRippleTransition) se refiere al tipo de transición Ripple admitido a partir de esta versión. 

La enumeración Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType se utiliza en esta clase y especifica una dirección, restringida a las esquinas y al centro.