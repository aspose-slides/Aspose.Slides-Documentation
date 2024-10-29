---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 14.7.0
type: docs
weight: 90
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades y otros cambios [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) que se introdujeron con la API de Aspose.Slides para .NET 14.7.0.

{{% /alert %}} 
## **Cambios en el API Público**
### **Constructores y Elementos Eliminados**
#### **Eliminados Algunos Constructores de Subtipos de TransitionValueBase y TransitionValueFactory**
Los constructores de algunos subtipos de TransitionValueBase (específicamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) son inútiles en el API público y, por lo tanto, han sido eliminados.

La clase relacionada TransitionValueFactory y su interfaz ITransitionValueFactory han sido eliminadas por la misma razón.
#### **Eliminado el Elemento SoundAction de la Enumeración Aspose.Slides.SlideShow.TransitionType**
El elemento SoundAction era incorrecto y no se utilizaba. La configuración de sonido se define mediante las propiedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Clases e Interfaces Agregadas**
#### **Agregada la Clase FlyThroughTransition y la Interfaz IFlyThroughTransition**
La clase Aspose.Slides.SlideShow.FlyThroughTransition (y su interfaz Aspose.Slides.SlideShow.IFlyThroughTransition) se relaciona con el tipo de transición Flythrough soportado desde esta versión.
#### **Agregada la Clase GlitterTransition, la Interfaz IGlitterTransition y la Enumeración TransitionPattern**
La clase Aspose.Slides.SlideShow.GlitterTransition (y su interfaz Aspose.Slides.SlideShow.IGlitterTransition) se relaciona con el tipo de transición Glitter soportado desde esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionPattern se utiliza en esta clase y especifica un patrón geométrico que se utiliza para rellenar un área más grande.
#### **Agregada la Clase LeftRightDirectionTransition, la Interfaz ILeftRightDirectionTransition y la Enumeración TransitionLeftRightDirectionType**
La clase Aspose.Slides.SlideShow.LeftRightDirectionTransition (y su interfaz Aspose.Slides.SlideShow.ILeftRightDirectionTransition) se relaciona con los tipos de transición Conveyor, Ferris, Flip, Gallery y Switch. Todos están soportados desde esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionLeftRightDirectionType se utiliza en esta clase y especifica una dirección, restringida a los valores izquierdo y derecho.
#### **Nuevos Elementos Agregados a la Enumeración Aspose.Slides.SlideShow.TransitionType**
La enumeración Aspose.Slides.SlideShow.TransitionType ha sido extendida con nuevos elementos.

- Nuevos elementos relacionados con transiciones de PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nuevos elementos relacionados con nuevas transiciones de PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Agregada la Clase RevealTransition y la Interfaz IRevealTransition**
La clase Aspose.Slides.SlideShow.RevealTransition (y su interfaz Aspose.Slides.SlideShow.IRevealTransition) se relaciona con el tipo de transición Reveal soportado desde esta versión.
#### **Agregada la Clase RippleTransition, la Interfaz IRippleTransition y la Enumeración TransitionCornerAndCenterDirectionType**
La clase Aspose.Slides.SlideShow.RippleTransition (y su interfaz Aspose.Slides.SlideShow.IRippleTransition) se relaciona con el tipo de transición Ripple soportado desde esta versión.

La enumeración Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType se utiliza en esta clase y especifica una dirección, restringida a los rincones y al centro.