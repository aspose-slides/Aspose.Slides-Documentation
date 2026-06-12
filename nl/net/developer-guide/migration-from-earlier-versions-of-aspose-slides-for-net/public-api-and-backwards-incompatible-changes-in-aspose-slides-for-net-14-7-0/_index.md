---
title: Openbare API en terugwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.7.0
linktitle: Aspose.Slides voor .NET 14.7.0
type: docs
weight: 90
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en kritieke wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 
Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 14.7.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
### **Verwijderde constructeurs en elementen**
#### **Verwijderde enkele TransitionValueBase subtype-constructeurs en TransitionValueFactory**
De constructeurs van enkele TransitionValueBase subtypes (specifiek CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) zijn zinloos in de openbare API en zijn daarom verwijderd. 

De gerelateerde klasse TransitionValueFactory en de interface ITransitionValueFactory zijn om dezelfde reden verwijderd.
#### **Verwijderd het SoundAction-element uit de enumeratie Aspose.Slides.SlideShow.TransitionType**
Het SoundAction-element was onjuist en werd niet gebruikt. Geluidsinstellingen worden gedefinieerd door de eigenschappen SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Toegevoegde klassen en interfaces**
#### **Toegevoegd de FlyThroughTransition-klasse en IFlyThroughTransition-interface**
De klasse Aspose.Slides.SlideShow.FlyThroughTransition (en de interface Aspose.Slides.SlideShow.IFlyThroughTransition) heeft betrekking op het Flythrough‑overgangstype dat vanaf deze release wordt ondersteund.
#### **Toegevoegd de GlitterTransition-klasse, IGlitterTransition-interface en TransitionPattern-enumeratie**
De klasse Aspose.Slides.SlideShow.GlitterTransition (en de interface Aspose.Slides.SlideShow.IGlitterTransition) heeft betrekking op het Glitter‑overgangstype dat vanaf deze release wordt ondersteund.

De enumeratie Aspose.Slides.SlideShow.TransitionPattern wordt in deze klasse gebruikt en specificeert een geometrisch patroon dat wordt herhaald om een groter gebied te vullen.
#### **Toegevoegd de LeftRightDirectionTransition-klasse, ILeftRightDirectionTransition-interface en TransitionLeftRightDirectionType-enumeratie**
De klasse Aspose.Slides.SlideShow.LeftRightDirectionTransition (en de interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) heeft betrekking op de overgangstypen Conveyor, Ferris, Flip, Gallery en Switch. Alle worden vanaf deze release ondersteund.

De enumeratie Aspose.Slides.SlideShow.TransitionLeftRightDirectionType wordt in deze klasse gebruikt en specificeert een richting, beperkt tot de waarden left en right.
#### **Nieuwe elementen toegevoegd aan de enumeratie Aspose.Slides.SlideShow.TransitionType**
De enumeratie Aspose.Slides.SlideShow.TransitionType is uitgebreid met nieuwe elementen.

- Nieuwe elementen gerelateerd aan PowerPoint 2010‑overgangen: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nieuwe elementen gerelateerd aan de nieuwe PowerPoint 2013‑overgangen: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Toegevoegd de RevealTransition-klasse en IRevealTransition-interface**
De klasse Aspose.Slides.SlideShow.RevealTransition (en de interface Aspose.Slides.SlideShow.IRevealTransition) heeft betrekking op het Reveal‑overgangstype dat vanaf deze release wordt ondersteund.
#### **Toegevoegd de RippleTransition-klasse, IRippleTransition-interface en TransitionCornerAndCenterDirectionType-enumeratie**
De klasse Aspose.Slides.SlideShow.RippleTransition (en de interface Aspose.Slides.SlideShow.IRippleTransition) heeft betrekking op het Ripple‑overgangstype dat vanaf deze release wordt ondersteund.

De enumeratie Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType wordt in deze klasse gebruikt en specificeert een richting, beperkt tot de hoeken en het midden.