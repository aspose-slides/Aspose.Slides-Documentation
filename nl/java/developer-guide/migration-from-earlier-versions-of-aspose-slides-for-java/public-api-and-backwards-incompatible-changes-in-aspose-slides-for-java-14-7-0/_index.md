---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 14.7.0
linktitle: Aspose.Slides voor Java 14.7.0
type: docs
weight: 60
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP-presentatie-oplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle toegevoegde klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for Java 14.7.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **Constructors van enkele TransitionValueBase-subtypen zijn verwijderd en TransitionValueFactory is verwijderd**
Constructors van enkele TransitionValueBase-subtypen (en specifiek CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) zijn overbodig in de openbare API en zijn daarom verwijderd. De gerelateerde klasse TransitionValueFactory en de bijbehorende interface ITransitionValueFactory zijn om dezelfde reden weggehaald.
### **Element SoundAction is verwijderd uit de enumeratie com.aspose.slides.TransitionType**
Element SoundAction was onjuist en werd niet gebruikt. Geluidsinstellingen worden gedefinieerd door de eigenschappen SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **FlyThroughTransition‑klasse en IFlyThroughTransition‑interface zijn toegevoegd**
De klasse com.aspose.slides.FlyThroughTransition (en de bijbehorende interface com.aspose.slides.IFlyThroughTransition) heeft betrekking op het overgangstype Flythrough dat in deze versie wordt ondersteund.
### **GlitterTransition‑klasse, IGlitterTransition‑interface en TransitionPattern‑enumeratie zijn toegevoegd**
De klasse com.aspose.slides.GlitterTransition (en de bijbehorende interface com.aspose.slides.IGlitterTransition) heeft betrekking op het overgangstype Glitter dat in deze versie wordt ondersteund. De enumeratie com.aspose.slides.TransitionPattern wordt in deze klasse gebruikt en geeft een geometrisch patroon aan dat herhaald wordt om een groter gebied te vullen.
### **LeftRightDirectionTransition‑klasse, ILeftRightDirectionTransition‑interface en TransitionLeftRightDirectionType‑enumeratie zijn toegevoegd**
De klasse com.aspose.slides.LeftRightDirectionTransition (en de bijbehorende interface com.aspose.slides.ILeftRightDirectionTransition) heeft betrekking op de overgangstypen Switch, Flip, Ferris, Gallery, Conveyor die in deze versie worden ondersteund. De enumeratie com.aspose.slides.TransitionLeftRightDirectionType wordt in deze klasse gebruikt en geeft een richting aan die beperkt is tot de waarden links en rechts.
### **Nieuwe elementen zijn toegevoegd aan de enumeratie com.aspose.slides.TransitionType**
De enumeratie com.aspose.slides.TransitionType is uitgebreid met nieuwe elementen. Nieuwe elementen gerelateerd aan de PowerPoint 2010‑overgangen: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nieuwe elementen gerelateerd aan de PowerPoint 2013‑overgangen: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition‑klasse en IRevealTransition‑interface zijn toegevoegd**
De klasse com.aspose.slides.RevealTransition (en de bijbehorende interface com.aspose.slides.IRevealTransition) heeft betrekking op het overgangstype Reveal dat in deze versie wordt ondersteund. De klasse RippleTransition, de interface IRippleTransition en de enumeratie TransitionCornerAndCenterDirectionType zijn toegevoegd. De klasse com.aspose.slides.RippleTransition (en de bijbehorende interface com.aspose.slides.IRippleTransition) heeft betrekking op het overgangstype Ripple dat in deze versie wordt ondersteund. De enumeratie com.aspose.slides.TransitionCornerAndCenterDirectionType wordt in deze klasse gebruikt en geeft een richting aan die beperkt is tot de hoeken en het centrum.
### **ShredTransition‑klasse, IShredTransition‑interface en TransitionShredPattern‑enumeratie zijn toegevoegd**
De klasse com.aspose.slides.ShredTransition (en de bijbehorende interface com.aspose.slides.IShredTransition) heeft betrekking op het overgangstype Shred dat in deze versie wordt ondersteund. De enumeratie com.aspose.slides.TransitionShredPattern wordt in deze klasse gebruikt en geeft een geometrische vorm aan die herhaald wordt om een groter gebied te vullen.