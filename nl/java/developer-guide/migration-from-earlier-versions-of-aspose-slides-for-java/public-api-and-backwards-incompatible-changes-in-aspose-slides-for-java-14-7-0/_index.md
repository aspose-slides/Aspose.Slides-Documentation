---
title: Openbare API en incompatibele wijzigingen in Aspose.Slides voor Java 14.7.0
linktitle: Aspose.Slides voor Java 14.7.0
type: docs
weight: 60
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatie-oplossingen soepel te migreren."
---
{{% alert color="primary" %}}
Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for Java 14.7.0 API.
{{% /alert %}}
## **Openbare API-wijzigingen**
### **Constructors van een aantal TransitionValueBase‑subtypen zijn verwijderd en TransitionValueFactory is verwijderd**
Constructors van een aantal TransitionValueBase‑subtypen (en specifiek CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) zijn overbodig in de openbare API en daarom verwijderd. Gerelateerde klasse TransitionValueFactory en de interface ITransitionValueFactory zijn om dezelfde reden verwijderd.
### **Element SoundAction is verwijderd uit de enumeratie com.aspose.slides.TransitionType**
Element SoundAction was onjuist en werd niet gebruikt. Geluidsinstellingen worden gedefinieerd door de eigenschappen SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Klasse FlyThroughTransition en interface IFlyThroughTransition zijn toegevoegd**
De klasse com.aspose.slides.FlyThroughTransition (en haar interface com.aspose.slides.IFlyThroughTransition) heeft betrekking op het overgangstype Flythrough dat in deze release wordt ondersteund.
### **Klasse GlitterTransition, interface IGlitterTransition en enumeratie TransitionPattern zijn toegevoegd**
De klasse com.aspose.slides.GlitterTransition (en haar interface com.aspose.slides.IGlitterTransition) heeft betrekking op het overgangstype Glitter dat in deze release wordt ondersteund. De enumeratie com.aspose.slides.TransitionPattern wordt in deze klasse gebruikt en specificeert een geometrisch patroon dat zich herhaalt om een groter gebied te vullen.
### **Klasse LeftRightDirectionTransition, interface ILeftRightDirectionTransition en enumeratie TransitionLeftRightDirectionType zijn toegevoegd**
De klasse com.aspose.slides.LeftRightDirectionTransition (en haar interface com.aspose.slides.ILeftRightDirectionTransition) heeft betrekking op de overgangstypen Switch, Flip, Ferris, Gallery, Conveyor die in deze release worden ondersteund. De enumeratie com.aspose.slides.TransitionLeftRightDirectionType wordt in deze klasse gebruikt en specificeert een richting die beperkt is tot de waarden links en rechts.
### **Nieuwe elementen zijn toegevoegd aan de enumeratie com.aspose.slides.TransitionType**
De enumeratie com.aspose.slides.TransitionType is uitgebreid met nieuwe elementen. Nieuwe elementen gerelateerd aan de nieuwe PowerPoint 2010‑overgangen: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nieuwe elementen gerelateerd aan de nieuwe PowerPoint 2013‑overgangen: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Klasse RevealTransition en interface IRevealTransition zijn toegevoegd**
De klasse com.aspose.slides.RevealTransition (en haar interface com.aspose.slides.IRevealTransition) heeft betrekking op het overgangstype Reveal dat in deze release wordt ondersteund.
Klasse RippleTransition, interface IRippleTransition en enumeratie TransitionCornerAndCenterDirectionType zijn toegevoegd. De klasse com.aspose.slides.RippleTransition (en haar interface com.aspose.slides.IRippleTransition) heeft betrekking op het overgangstype Ripple dat in deze release wordt ondersteund. De enumeratie com.aspose.slides.TransitionCornerAndCenterDirectionType wordt in deze klasse gebruikt en specificeert een richting die beperkt is tot de hoeken en het midden.
### **Klasse ShredTransition, interface IShredTransition en enumeratie TransitionShredPattern zijn toegevoegd**
De klasse com.aspose.slides.ShredTransition (en haar interface com.aspose.slides.IShredTransition) heeft betrekking op het overgangstype Shred dat in deze release wordt ondersteund. De enumeratie com.aspose.slides.TransitionShredPattern wordt in deze klasse gebruikt en specificeert een geometrische vorm die zich herhaalt om een groter gebied te vullen.