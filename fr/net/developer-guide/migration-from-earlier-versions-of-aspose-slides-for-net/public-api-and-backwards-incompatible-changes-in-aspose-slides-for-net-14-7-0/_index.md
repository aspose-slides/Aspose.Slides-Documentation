---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 14.7.0
linktitle: Aspose.Slides pour .NET 14.7.0
type: docs
weight: 90
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie tous les [ajoutés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ou les [supprimés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) classes, méthodes, propriétés, etc., ainsi que les autres changements introduits avec l’API Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Constructeurs et éléments supprimés**
#### **Suppression de certains constructeurs de sous-types TransitionValueBase et de TransitionValueFactory**
Les constructeurs de certains sous-types de TransitionValueBase (specifiquement CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sont inutiles dans l’API publique et ont donc été supprimés. 

La classe associée TransitionValueFactory et son interface ITransitionValueFactory ont été supprimées pour la même raison.
#### **Suppression de l’élément SoundAction de l’énumération Aspose.Slides.SlideShow.TransitionType**
L’élément SoundAction était incorrect et non utilisé. Les paramètres sonores sont définis par les propriétés SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classes et interfaces ajoutées**
#### **Ajout de la classe FlyThroughTransition et de l’interface IFlyThroughTransition**
La classe Aspose.Slides.SlideShow.FlyThroughTransition (et son interface Aspose.Slides.SlideShow.IFlyThroughTransition) correspond au type de transition Flythrough pris en charge à partir de cette version.
#### **Ajout de la classe GlitterTransition, de l’interface IGlitterTransition et de l’énumération TransitionPattern**
La classe Aspose.Slides.SlideShow.GlitterTransition (et son interface Aspose.Slides.SlideShow.IGlitterTransition) correspond au type de transition Glitter pris en charge à partir de cette version.

L’énumération Aspose.Slides.SlideShow.TransitionPattern est utilisée dans cette classe et spécifie un motif géométrique qui se répète pour couvrir une zone plus large.
#### **Ajout de la classe LeftRightDirectionTransition, de l’interface ILeftRightDirectionTransition et de l’énumération TransitionLeftRightDirectionType**
La classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (et son interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) correspond aux types de transition Conveyor, Ferris, Flip, Gallery et Switch. Tous sont pris en charge à partir de cette version.

L’énumération Aspose.Slides.SlideShow.TransitionLeftRightDirectionType est utilisée dans cette classe et spécifie une direction, limitée aux valeurs left et right.
#### **Ajout de nouveaux éléments à l’énumération Aspose.Slides.SlideShow.TransitionType**
L’énumération Aspose.Slides.SlideShow.TransitionType a été étendue avec de nouveaux éléments.

- Nouveaux éléments liés aux transitions PowerPoint 2010 : Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nouveaux éléments liés aux transitions PowerPoint 2013 : Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Ajout de la classe RevealTransition et de l’interface IRevealTransition**
La classe Aspose.Slides.SlideShow.RevealTransition (et son interface Aspose.Slides.SlideShow.IRevealTransition) correspond au type de transition Reveal pris en charge à partir de cette version.
#### **Ajout de la classe RippleTransition, de l’interface IRippleTransition et de l’énumération TransitionCornerAndCenterDirectionType**
La classe Aspose.Slides.SlideShow.RippleTransition (et son interface Aspose.Slides.SlideShow.IRippleTransition) correspond au type de transition Ripple pris en charge à partir de cette version.

L’énumération Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType est utilisée dans cette classe et spécifie une direction, limitée aux coins et au centre.