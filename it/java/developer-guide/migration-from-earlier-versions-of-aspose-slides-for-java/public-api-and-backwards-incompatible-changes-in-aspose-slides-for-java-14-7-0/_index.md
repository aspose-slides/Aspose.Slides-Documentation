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
description: "Esamina gli aggiornamenti dell'API pubblica e i cambiamenti incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) , eventuali nuove restrizioni e altre modifiche introdotte con l'API Aspose.Slides for Java 14.7.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
### **I costruttori di alcuni sottotipi di TransitionValueBase sono stati rimossi e TransitionValueFactory è stato rimosso**
I costruttori di alcuni sottotipi di TransitionValueBase (in particolare CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sono inutili nell'API pubblica e quindi sono stati rimossi. La classe correlata TransitionValueFactory e la sua interfaccia ITransitionValueFactory sono state rimosse per lo stesso motivo.
### **L'elemento SoundAction è stato rimosso dall'enumerazione com.aspose.slides.TransitionType**
L'elemento SoundAction era errato e non veniva utilizzato. Le impostazioni audio sono definite dalle proprietà SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **La classe FlyThroughTransition e l'interfaccia IFlyThroughTransition sono state aggiunte**
La classe com.aspose.slides.FlyThroughTransition (e la sua interfaccia com.aspose.slides.IFlyThroughTransition) si riferisce al tipo di transizione Flythrough, supportato in questa versione.
### **La classe GlitterTransition, l'interfaccia IGlitterTransition e l'enumerazione TransitionPattern sono state aggiunte**
La classe com.aspose.slides.GlitterTransition (e la sua interfaccia com.aspose.slides.IGlitterTransition) si riferisce al tipo di transizione Glitter, supportato in questa versione. L'enumerazione com.aspose.slides.TransitionPattern è utilizzata in questa classe e specifica un motivo geometrico che si ripete per riempire un'area più ampia.
### **La classe LeftRightDirectionTransition, l'interfaccia ILeftRightDirectionTransition e l'enumerazione TransitionLeftRightDirectionType sono state aggiunte**
La classe com.aspose.slides.LeftRightDirectionTransition (e la sua interfaccia com.aspose.slides.ILeftRightDirectionTransition) si riferisce ai tipi di transizione Switch, Flip, Ferris, Gallery, Conveyor, supportati in questa versione. L'enumerazione com.aspose.slides.TransitionLeftRightDirectionType è utilizzata in questa classe e specifica una direzione limitata ai valori sinistra e destra.
### **Sono stati aggiunti nuovi elementi all'enumerazione com.aspose.slides.TransitionType**
L'enumerazione com.aspose.slides.TransitionType è stata estesa con nuovi elementi.
Nuovi elementi relativi alle transizioni PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Nuovi elementi relativi alle transizioni PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **La classe RevealTransition e l'interfaccia IRevealTransition sono state aggiunte**
La classe com.aspose.slides.RevealTransition (e la sua interfaccia com.aspose.slides.IRevealTransition) si riferisce al tipo di transizione Reveal, supportato in questa versione.
La classe RippleTransition, l'interfaccia IRippleTransition e l'enumerazione TransitionCornerAndCenterDirectionType sono state aggiunte
La classe com.aspose.slides.RippleTransition (e la sua interfaccia com.aspose.slides.IRippleTransition) si riferisce al tipo di transizione Ripple, supportato in questa versione. L'enumerazione com.aspose.slides.TransitionCornerAndCenterDirectionType è utilizzata in questa classe e specifica una direzione limitata agli angoli e al centro.
### **La classe ShredTransition, l'interfaccia IShredTransition e l'enumerazione TransitionShredPattern sono state aggiunte**
La classe com.aspose.slides.ShredTransition (e la sua interfaccia com.aspose.slides.IShredTransition) si riferisce al tipo di transizione Shred, supportato in questa versione. L'enumerazione com.aspose.slides.TransitionShredPattern è utilizzata in questa classe e specifica una forma geometrica che si ripete per riempire un'area più ampia.