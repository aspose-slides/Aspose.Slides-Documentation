---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.7.0
linktitle: Aspose.Slides voor .NET 14.7.0
type: docs
weight: 90
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migratie
- legacy code
- moderne code
- legacy benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 14.7.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **Verwijderde constructors en elementen**
#### **Verwijderde constructors van sommige TransitionValueBase‑subtypen en TransitionValueFactory**
De constructors van sommige TransitionValueBase‑subtypen (specifiek CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) zijn nutteloos in de openbare API en zijn daarom verwijderd. 

De gerelateerde klasse TransitionValueFactory en de interface ITransitionValueFactory zijn om dezelfde reden verwijderd.
#### **Verwijderd het SoundAction‑element uit de enumeratie Aspose.Slides.SlideShow.TransitionType**
Het SoundAction‑element was onjuist en werd niet gebruikt. Geluidsinstellingen worden gedefinieerd door de eigenschappen SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Toegevoegde klassen en interfaces**
#### **Toegevoegde klasse FlyThroughTransition en interface IFlyThroughTransition**
De klasse Aspose.Slides.SlideShow.FlyThroughTransition (en de interface Aspose.Slides.SlideShow.IFlyThroughTransition) heeft betrekking op het Flythrough‑overgangstype dat vanaf deze release wordt ondersteund.
#### **Toegevoegde klasse GlitterTransition, interface IGlitterTransition en enumeratie TransitionPattern**
De klasse Aspose.Slides.SlideShow.GlitterTransition (en de interface Aspose.Slides.SlideShow.IGlitterTransition) heeft betrekking op het Glitter‑overgangstype dat vanaf deze release wordt ondersteund.

De enumeratie Aspose.Slides.SlideShow.TransitionPattern wordt in deze klasse gebruikt en specificeert een geometrisch patroon dat naast elkaar wordt geplaatst om een groter gebied te vullen.
#### **Toegevoegde klasse LeftRightDirectionTransition, interface ILeftRightDirectionTransition en enumeratie TransitionLeftRightDirectionType**
De klasse Aspose.Slides.SlideShow.LeftRightDirectionTransition (en de interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) heeft betrekking op de overgangstypen Conveyor, Ferris, Flip, Gallery en Switch. Allemaal ondersteund vanaf deze release.

De enumeratie Aspose.Slides.SlideShow.TransitionLeftRightDirectionType wordt in deze klasse gebruikt en specificeert een richting, beperkt tot de waarden left en right.
#### **Nieuwe elementen toegevoegd aan de enumeratie Aspose.Slides.SlideShow.TransitionType**
De enumeratie Aspose.Slides.SlideShow.TransitionType is uitgebreid met nieuwe elementen.

- Nieuwe elementen gerelateerd aan PowerPoint 2010‑overgangen: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nieuwe elementen gerelateerd aan PowerPoint 2013‑overgangen: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Toegevoegde klasse RevealTransition en interface IRevealTransition**
De klasse Aspose.Slides.SlideShow.RevealTransition (en de interface Aspose.Slides.SlideShow.IRevealTransition) heeft betrekking op het Reveal‑overgangstype dat vanaf deze release wordt ondersteund.
#### **Toegevoegde klasse RippleTransition, interface IRippleTransition en enumeratie TransitionCornerAndCenterDirectionType**
De klasse Aspose.Slides.SlideShow.RippleTransition (en de interface Aspose.Slides.SlideShow.IRippleTransition) heeft betrekking op het Ripple‑overgangstype dat vanaf deze release wordt ondersteund.

De enumeratie Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType wordt in deze klasse gebruikt en specificeert een richting, beperkt tot de hoeken en het centrum.