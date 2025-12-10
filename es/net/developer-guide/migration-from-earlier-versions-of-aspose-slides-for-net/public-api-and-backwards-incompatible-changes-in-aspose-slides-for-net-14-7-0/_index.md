---
title: API pública y cambios incompatibles retrospectivos en Aspose.Slides para .NET 14.7.0
linktitle: Aspose.Slides para .NET 14.7.0
type: docs
weight: 90
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) y otros cambios introducidos con la API de Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Constructores y elementos eliminados**
#### **Eliminados algunos constructores de subtipos de TransitionValueBase y TransitionValueFactory**
Los constructores de algunos subtipos de TransitionValueBase (específicamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) son inútiles en la API pública y, por lo tanto, se han eliminado. 

La clase relacionada TransitionValueFactory y su interfaz ITransitionValueFactory se han eliminado por la misma razón.
#### **Eliminado el elemento SoundAction de la enumeración Aspose.Slides.SlideShow.TransitionType**
El elemento SoundAction era incorrecto y no se utilizaba. La configuración de sonido se define mediante las propiedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Clases e interfaces agregadas**
#### **Agregada la clase FlyThroughTransition y la interfaz IFlyThroughTransition**
La clase Aspose.Slides.SlideShow.FlyThroughTransition (y su interfaz Aspose.Slides.SlideShow.IFlyThroughTransition) está relacionada con el tipo de transición Flythrough compatible a partir de esta versión.
#### **Agregada la clase GlitterTransition, la interfaz IGlitterTransition y la enumeración TransitionPattern**
La clase Aspose.Slides.SlideShow.GlitterTransition (y su interfaz Aspose.Slides.SlideShow.IGlitterTransition) está relacionada con el tipo de transición Glitter compatible a partir de esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionPattern se utiliza en esta clase y especifica un patrón geométrico que se repite para llenar un área mayor.
#### **Agregada la clase LeftRightDirectionTransition, la interfaz ILeftRightDirectionTransition y la enumeración TransitionLeftRightDirectionType**
La clase Aspose.Slides.SlideShow.LeftRightDirectionTransition (y su interfaz Aspose.Slides.SlideShow.ILeftRightDirectionTransition) está relacionada con los tipos de transición Conveyor, Ferris, Flip, Gallery y Switch. Todos son compatibles a partir de esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionLeftRightDirectionType se utiliza en esta clase y especifica una dirección, restringida a los valores left y right.
#### **Agregados nuevos elementos a la enumeración Aspose.Slides.SlideShow.TransitionType**
La enumeración Aspose.Slides.SlideShow.TransitionType se ha ampliado con nuevos elementos.

- Nuevos elementos relacionados con transiciones de PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nuevos elementos relacionados con transiciones nuevas de PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Agregada la clase RevealTransition y la interfaz IRevealTransition**
La clase Aspose.Slides.SlideShow.RevealTransition (y su interfaz Aspose.Slides.SlideShow.IRevealTransition) está relacionada con el tipo de transición Reveal compatible a partir de esta versión.
#### **Agregada la clase RippleTransition, la interfaz IRippleTransition y la enumeración TransitionCornerAndCenterDirectionType**
La clase Aspose.Slides.SlideShow.RippleTransition (y su interfaz Aspose.Slides.SlideShow.IRippleTransition) está relacionada con el tipo de transición Ripple compatible a partir de esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType se utiliza en esta clase y especifica una dirección, restringida a las esquinas y al centro.