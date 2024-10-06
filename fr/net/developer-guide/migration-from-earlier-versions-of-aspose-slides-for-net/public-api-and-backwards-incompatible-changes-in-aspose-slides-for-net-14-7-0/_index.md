---
title: API public et modifications incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 14.7.0
type: docs
weight: 90
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ou [supprimées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/), ainsi que d'autres modifications introduites avec l'API Aspose.Slides pour .NET 14.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Constructeurs et éléments supprimés**
#### **Constructeurs et TransitionValueFactory de certains sous-types de TransitionValueBase supprimés**
Les constructeurs de certains sous-types de TransitionValueBase (à savoir CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sont inutiles dans l'API publique et ont donc été supprimés.

La classe associée TransitionValueFactory et son interface ITransitionValueFactory ont été supprimées pour la même raison.
#### **Éléments SoundAction supprimés de l'énumération Aspose.Slides.SlideShow.TransitionType**
L'élément SoundAction était incorrect et non utilisé. Les paramètres sonores sont définis par les propriétés SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classes et interfaces ajoutées**
#### **Ajout de la classe FlyThroughTransition et de l'interface IFlyThroughTransition**
La classe Aspose.Slides.SlideShow.FlyThroughTransition (et son interface Aspose.Slides.SlideShow.IFlyThroughTransition) se rapporte au type de transition Flythrough pris en charge depuis cette version.
#### **Ajout de la classe GlitterTransition, de l'interface IGlitterTransition et de l'énumération TransitionPattern**
La classe Aspose.Slides.SlideShow.GlitterTransition (et son interface Aspose.Slides.SlideShow.IGlitterTransition) se rapporte au type de transition Glitter pris en charge depuis cette version.

L'énumération Aspose.Slides.SlideShow.TransitionPattern est utilisée dans cette classe et spécifie un motif géométrique qui s'assemble pour remplir une zone plus grande.
#### **Ajout de la classe LeftRightDirectionTransition, de l'interface ILeftRightDirectionTransition et de l'énumération TransitionLeftRightDirectionType**
La classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (et son interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) se rapporte aux types de transition Conveyor, Ferris, Flip, Gallery et Switch. Tous sont pris en charge depuis cette version.

L'énumération Aspose.Slides.SlideShow.TransitionLeftRightDirectionType est utilisée dans cette classe et spécifie une direction, limitée aux valeurs gauche et droite.
#### **Ajout de nouveaux éléments à l'énumération Aspose.Slides.SlideShow.TransitionType**
L'énumération Aspose.Slides.SlideShow.TransitionType a été étendue avec de nouveaux éléments.

- Nouveaux éléments liés aux transitions PowerPoint 2010 : Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nouveaux éléments liés aux nouvelles transitions PowerPoint 2013 : Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Ajout de la classe RevealTransition et de l'interface IRevealTransition**
La classe Aspose.Slides.SlideShow.RevealTransition (et son interface Aspose.Slides.SlideShow.IRevealTransition) se rapporte au type de transition Reveal pris en charge depuis cette version.
#### **Ajout de la classe RippleTransition, de l'interface IRippleTransition et de l'énumération TransitionCornerAndCenterDirectionType**
La classe Aspose.Slides.SlideShow.RippleTransition (et son interface Aspose.Slides.SlideShow.IRippleTransition) se rapporte au type de transition Ripple pris en charge depuis cette version.

L'énumération Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType est utilisée dans cette classe et spécifie une direction, limitée aux coins et au centre.