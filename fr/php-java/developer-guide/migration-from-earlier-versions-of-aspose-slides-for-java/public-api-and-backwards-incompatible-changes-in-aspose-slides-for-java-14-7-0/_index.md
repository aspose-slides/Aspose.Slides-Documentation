---
title: API public et modifications incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 14.7.0
type: docs
weight: 60
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) de classes, méthodes, propriétés, etc., ainsi que toutes les nouvelles restrictions et autres modifications introduites avec l'API Aspose.Slides pour PHP via Java 14.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Les constructeurs de certains sous-types de TransitionValueBase ont été supprimés et TransitionValueFactory a été supprimé**
Les constructeurs de certains sous-types de TransitionValueBase (et spécifiquement CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sont inutiles dans l'API publique et ont donc été supprimés. La classe associée TransitionValueFactory et son interface ITransitionValueFactory ont été supprimées pour la même raison.
### **L'élément SoundAction a été supprimé de l'énumération com.aspose.slides.TransitionType**
L'élément SoundAction était incorrect et non utilisé. Les paramètres audio sont définis par les propriétés SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **La classe FlyThroughTransition et l'interface IFlyThroughTransition ont été ajoutées**
La classe com.aspose.slides.FlyThroughTransition (et son interface com.aspose.slides.IFlyThroughTransition) est liée au type de transition Flythrough qui a été supporté dans cette version.
### **La classe GlitterTransition, l'interface IGlitterTransition et l'énumération TransitionPattern ont été ajoutées**
La classe com.aspose.slides.GlitterTransition (et son interface com.aspose.slides.IGlitterTransition) est liée au type de transition Glitter qui a été supporté dans cette version. L'énumération com.aspose.slides.TransitionPattern est utilisée dans cette classe et spécifie un motif géométrique qui s'assemble pour remplir une zone plus grande.
### **La classe LeftRightDirectionTransition, l'interface ILeftRightDirectionTransition et l'énumération TransitionLeftRightDirectionType ont été ajoutées**
La classe com.aspose.slides.LeftRightDirectionTransition (et son interface com.aspose.slides.ILeftRightDirectionTransition) est liée aux types de transition Switch, Flip, Ferris, Gallery, Conveyor qui ont été supportés dans cette version. L'énumération com.aspose.slides.TransitionLeftRightDirectionType est utilisée dans cette classe et spécifie une direction limitée aux valeurs gauche et droite.
### **De nouveaux éléments ont été ajoutés dans l'énumération com.aspose.slides.TransitionType**
L'énumération com.aspose.slides.TransitionType a été étendue avec de nouveaux éléments. 
De nouveaux éléments liés aux nouvelles transitions PowerPoint 2010 : Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
De nouveaux éléments liés aux nouvelles transitions PowerPoint 2013 : FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **La classe RevealTransition et l'interface IRevealTransition ont été ajoutées**
La classe com.aspose.slides.RevealTransition (et son interface com.aspose.slides.IRevealTransition) est liée au type de transition Reveal qui a été supporté dans cette version.
### **La classe RippleTransition, l'interface IRippleTransition et l'énumération TransitionCornerAndCenterDirectionType ont été ajoutées**
La classe com.aspose.slides.RippleTransition (et son interface com.aspose.slides.IRippleTransition) est liée au type de transition Ripple qui a été supporté dans cette version. L'énumération com.aspose.slides.TransitionCornerAndCenterDirectionType est utilisée dans cette classe et spécifie une direction limitée aux coins et au centre.
### **La classe ShredTransition, l'interface IShredTransition et l'énumération TransitionShredPattern ont été ajoutées**
La classe com.aspose.slides.ShredTransition (et son interface com.aspose.slides.IShredTransition) est liée au type de transition Shred qui a été supporté dans cette version. L'énumération com.aspose.slides.TransitionShredPattern est utilisée dans cette classe et spécifie une forme géométrique qui s'assemble pour remplir une zone plus grande.