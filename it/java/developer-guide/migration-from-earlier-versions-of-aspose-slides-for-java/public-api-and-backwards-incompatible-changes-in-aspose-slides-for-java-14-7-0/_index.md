---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 14.7.0
linktitle: Aspose.Slides per Java 14.7.0
type: docs
weight: 60
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}}
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) e tutte le nuove restrizioni e altre modifiche introdotte con l'API Aspose.Slides for Java 14.7.0.
{{% /alert %}}
## **Modifiche all'API pubblica**
### **I costruttori di alcuni sottotipi di TransitionValueBase sono stati rimossi e TransitionValueFactory è stato rimosso**
I costruttori di alcuni sottotipi di TransitionValueBase (in particolare CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sono inutili nell'API pubblica e sono quindi stati rimossi. La classe correlata TransitionValueFactory e la sua interfaccia ITransitionValueFactory sono state rimosse per lo stesso motivo.
### **L'elemento SoundAction è stato rimosso dall'enumerazione com.aspose.slides.TransitionType**
L'elemento SoundAction era errato e non veniva utilizzato. Le impostazioni audio sono definite dalle proprietà SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **La classe FlyThroughTransition e l'interfaccia IFlyThroughTransition sono state aggiunte**
La classe com.aspose.slides.FlyThroughTransition (e la sua interfaccia com.aspose.slides.IFlyThroughTransition) si riferisce al tipo di transizione Flythrough che è stato supportato in questa versione.
### **Le classi GlitterTransition, l'interfaccia IGlitterTransition e l'enumerazione TransitionPattern sono state aggiunte**
La classe com.aspose.slides.GlitterTransition (e la sua interfaccia com.aspose.slides.IGlitterTransition) si riferisce al tipo di transizione Glitter che è stato supportato in questa versione. L'enumerazione com.aspose.slides.TransitionPattern è utilizzata in questa classe e specifica un motivo geometrico che si ripete per coprire un'area più ampia.
### **Le classi LeftRightDirectionTransition, l'interfaccia ILeftRightDirectionTransition e l'enumerazione TransitionLeftRightDirectionType sono state aggiunte**
La classe com.aspose.slides.LeftRightDirectionTransition (e la sua interfaccia com.aspose.slides.ILeftRightDirectionTransition) si riferisce ai tipi di transizione Switch, Flip, Ferris, Gallery, Conveyor che sono stati supportati in questa versione. L'enumerazione com.aspose.slides.TransitionLeftRightDirectionType è utilizzata in questa classe e specifica una direzione limitata ai valori sinistra e destra.
### **Sono stati aggiunti nuovi elementi all'enumerazione com.aspose.slides.TransitionType**
L'enumerazione com.aspose.slides.TransitionType è stata estesa con nuovi elementi. Nuovi elementi relativi alle transizioni di PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nuovi elementi relativi alle transizioni di PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Le classi RevealTransition e l'interfaccia IRevealTransition sono state aggiunte**
La classe com.aspose.slides.RevealTransition (e la sua interfaccia com.aspose.slides.IRevealTransition) si riferisce al tipo di transizione Reveal che è stato supportato in questa versione.
La classe RippleTransition, l'interfaccia IRippleTransition e l'enumerazione TransitionCornerAndCenterDirectionType sono state aggiunte.
La classe com.aspose.slides.RippleTransition (e la sua interfaccia com.aspose.slides.IRippleTransition) si riferisce al tipo di transizione Ripple che è stato supportato in questa versione.
L'enumerazione com.aspose.slides.TransitionCornerAndCenterDirectionType è utilizzata in questa classe e specifica una direzione limitata agli angoli e al centro.
### **Le classi ShredTransition, l'interfaccia IShredTransition e l'enumerazione TransitionShredPattern sono state aggiunte**
La classe com.aspose.slides.ShredTransition (e la sua interfaccia com.aspose.slides.IShredTransition) si riferisce al tipo di transizione Shred che è stato supportato in questa versione. L'enumerazione com.aspose.slides.TransitionShredPattern è utilizzata in questa classe e specifica una forma geometrica che si ripete per coprire un'area più ampia.