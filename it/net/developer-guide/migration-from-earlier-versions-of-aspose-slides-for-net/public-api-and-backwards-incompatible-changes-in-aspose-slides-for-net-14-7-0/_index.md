---
title: API Pubblica e Modifiche Incompatibili all'indietro in Aspose.Slides per .NET 14.7.0
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/), nonché le altre modifiche introdotte con l'API Aspose.Slides per .NET 14.7.0.

{{% /alert %}} 
## **Modifiche all'API Pubblica**
### **Costruttori ed Elementi Rimossi**
#### **Rimossi Alcuni Costruttori di Sotto‑tipo TransitionValueBase e TransitionValueFactory**
I costruttori di alcuni sotto‑tipi di TransitionValueBase (in particolare CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sono inutili nell'API pubblica e sono stati rimossi. 

La classe correlata TransitionValueFactory e la sua interfaccia ITransitionValueFactory sono state rimosse per lo stesso motivo.
#### **Rimosso l'Elemento SoundAction dall'Enumerazione Aspose.Slides.SlideShow.TransitionType**
L'elemento SoundAction era errato e non utilizzato. Le impostazioni audio sono definite dalle proprietà SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classi e Interfacce Aggiunte**
#### **Aggiunta la Classe FlyThroughTransition e l'Interfaccia IFlyThroughTransition**
La classe Aspose.Slides.SlideShow.FlyThroughTransition (e la sua interfaccia Aspose.Slides.SlideShow.IFlyThroughTransition) riguarda il tipo di transizione Flythrough supportato a partire da questa release.
#### **Aggiunta la Classe GlitterTransition, l'Interfaccia IGlitterTransition e l'Enumerazione TransitionPattern**
La classe Aspose.Slides.SlideShow.GlitterTransition (e la sua interfaccia Aspose.Slides.SlideShow.IGlitterTransition) riguarda il tipo di transizione Glitter supportato a partire da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionPattern è usata in questa classe e specifica un motivo geometrico che si ripete per riempire un'area più grande.
#### **Aggiunta la Classe LeftRightDirectionTransition, l'Interfaccia ILeftRightDirectionTransition e l'Enumerazione TransitionLeftRightDirectionType**
La classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (e la sua interfaccia Aspose.Slides.SlideShow.ILeftRightDirectionTransition) riguarda i tipi di transizione Conveyor, Ferris, Flip, Gallery e Switch. Tutti sono supportati a partire da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionLeftRightDirectionType è usata in questa classe e specifica una direzione, limitata ai valori left e right.
#### **Aggiunti Nuovi Elementi all'Enumerazione Aspose.Slides.SlideShow.TransitionType**
L'enumerazione Aspose.Slides.SlideShow.TransitionType è stata estesa con nuovi elementi.

- Nuovi elementi relativi alle transizioni di PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nuovi elementi relativi alle transizioni di PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Aggiunta la Classe RevealTransition e l'Interfaccia IRevealTransition**
La classe Aspose.Slides.SlideShow.RevealTransition (e la sua interfaccia Aspose.Slides.SlideShow.IRevealTransition) riguarda il tipo di transizione Reveal supportato a partire da questa release.
#### **Aggiunta la Classe RippleTransition, l'Interfaccia IRippleTransition e l'Enumerazione TransitionCornerAndCenterDirectionType**
La classe Aspose.Slides.SlideShow.RippleTransition (e la sua interfaccia Aspose.Slides.SlideShow.IRippleTransition) riguarda il tipo di transizione Ripple supportato a partire da questa release.

L'enumerazione Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType è usata in questa classe e specifica una direzione, limitata agli angoli e al centro.