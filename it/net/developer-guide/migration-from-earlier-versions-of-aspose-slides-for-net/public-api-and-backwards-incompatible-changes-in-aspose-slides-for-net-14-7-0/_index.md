---
title: API pubbliche e cambiamenti incompatibili con versioni precedenti in Aspose.Slides per .NET 14.7.0
linktitle: Aspose.Slides per .NET 14.7.0
type: docs
weight: 90
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutti i [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) o i [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) classi, metodi, proprietà e così via, e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 14.7.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Costruttori ed Elementi Rimossi**
#### **Rimossi alcuni costruttori di sottotipi TransitionValueBase e TransitionValueFactory**
I costruttori di alcuni sottotipi di TransitionValueBase (in particolare CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sono inutili nell'API pubblica e sono stati rimossi. 

La classe correlata TransitionValueFactory e la sua interfaccia ITransitionValueFactory sono state rimosse per lo stesso motivo.
#### **Rimosso l'elemento SoundAction dall'enumerazione Aspose.Slides.SlideShow.TransitionType**
L'elemento SoundAction era errato e non utilizzato. Le impostazioni audio sono definite dalle proprietà SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classi e Interfacce Aggiunte**
#### **Aggiunta la classe FlyThroughTransition e l'interfaccia IFlyThroughTransition**
La classe Aspose.Slides.SlideShow.FlyThroughTransition (e la sua interfaccia Aspose.Slides.SlideShow.IFlyThroughTransition) è relativa al tipo di transizione Flythrough supportato da questa release.
#### **Aggiunta la classe GlitterTransition, l'interfaccia IGlitterTransition e l'enumerazione TransitionPattern**
La classe Aspose.Slides.SlideShow.GlitterTransition (e la sua interfaccia Aspose.Slides.SlideShow.IGlitterTransition) è relativa al tipo di transizione Glitter supportato da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionPattern è utilizzata in questa classe e specifica un motivo geometrico che si ripete per riempire un'area più ampia.
#### **Aggiunta la classe LeftRightDirectionTransition, l'interfaccia ILeftRightDirectionTransition e l'enumerazione TransitionLeftRightDirectionType**
La classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (e la sua interfaccia Aspose.Slides.SlideShow.ILeftRightDirectionTransition) è relativa ai tipi di transizione Conveyor, Ferris, Flip, Gallery e Switch. Tutti sono supportati da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionLeftRightDirectionType è utilizzata in questa classe e specifica una direzione, limitata ai valori left e right.
#### **Aggiunti nuovi elementi all'enumerazione Aspose.Slides.SlideShow.TransitionType**
L'enumerazione Aspose.Slides.SlideShow.TransitionType è stata estesa con nuovi elementi.

- Nuovi elementi relativi alle transizioni di PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nuovi elementi relativi alle nuove transizioni di PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Aggiunta la classe RevealTransition e l'interfaccia IRevealTransition**
La classe Aspose.Slides.SlideShow.RevealTransition (e la sua interfaccia Aspose.Slides.SlideShow.IRevealTransition) è relativa al tipo di transizione Reveal supportato da questa release.
#### **Aggiunta la classe RippleTransition, l'interfaccia IRippleTransition e l'enumerazione TransitionCornerAndCenterDirectionType**
La classe Aspose.Slides.SlideShow.RippleTransition (e la sua interfaccia Aspose.Slides.SlideShow.IRippleTransition) è relativa al tipo di transizione Ripple supportato da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType è utilizzata in questa classe e specifica una direzione, limitata agli angoli e al centro.