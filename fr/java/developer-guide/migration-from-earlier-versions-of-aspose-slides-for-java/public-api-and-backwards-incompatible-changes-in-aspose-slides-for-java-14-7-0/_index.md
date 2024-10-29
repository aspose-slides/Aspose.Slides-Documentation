---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour Java 14.7.0
type: docs
weight: 60
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) de classes, méthodes, propriétés, etc., toute nouvelle restriction et autres changements introduits avec l'API Aspose.Slides pour Java 14.7.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **Dessinateurs de certains sous-types TransitionValueBase ont été supprimés et TransitionValueFactory a été supprimé**
Les dessinateurs de certains sous-types TransitionValueBase (et spécifiquement CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sont inutiles dans l'API publique et ont donc été supprimés. La classe associée TransitionValueFactory et son interface ITransitionValueFactory ont été supprimées pour la même raison.
### **L'élément SoundAction a été retiré de l'énumération com.aspose.slides.TransitionType**
L'élément SoundAction était incorrect et non utilisé. Les paramètres sonores sont définis par les propriétés SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **La classe FlyThroughTransition et l'interface IFlyThroughTransition ont été ajoutées**
La classe com.aspose.slides.FlyThroughTransition (et son interface com.aspose.slides.IFlyThroughTransition) concerne le type de transition Flythrough qui a été supporté dans cette version.
### **La classe GlitterTransition, l'interface IGlitterTransition et l'énumération TransitionPattern ont été ajoutées**
La classe com.aspose.slides.GlitterTransition (et son interface com.aspose.slides.IGlitterTransition) concerne le type de transition Glitter qui a été supporté dans cette version.
L'énumération com.aspose.slides.TransitionPattern est utilisée dans cette classe et spécifie un motif géométrique qui se tile ensemble pour remplir une surface plus grande.
### **La classe LeftRightDirectionTransition, l'interface ILeftRightDirectionTransition et l'énumération TransitionLeftRightDirectionType ont été ajoutées**
La classe com.aspose.slides.LeftRightDirectionTransition (et son interface com.aspose.slides.ILeftRightDirectionTransition) concerne les types de transition Switch, Flip, Ferris, Gallery, Conveyor qui ont été supportés dans cette version.
L'énumération com.aspose.slides.TransitionLeftRightDirectionType est utilisée dans cette classe et spécifie une direction restreinte aux valeurs gauche et droite.
### **De nouveaux éléments ont été ajoutés dans l'énumération com.aspose.slides.TransitionType**
L'énumération com.aspose.slides.TransitionType a été étendue avec de nouveaux éléments.
De nouveaux éléments liés aux nouvelles transitions PowerPoint 2010 : Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
De nouveaux éléments liés aux nouvelles transitions PowerPoint 2013 : FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **La classe RevealTransition et l'interface IRevealTransition ont été ajoutées**
La classe com.aspose.slides.RevealTransition (et son interface com.aspose.slides.IRevealTransition) concerne le type de transition Reveal qui a été supporté dans cette version.
La classe RippleTransition, l'interface IRippleTransition et l'énumération TransitionCornerAndCenterDirectionType ont été ajoutées.
La classe com.aspose.slides.RippleTransition (et son interface com.aspose.slides.IRippleTransition) concerne le type de transition Ripple qui a été supporté dans cette version.
L'énumération com.aspose.slides.TransitionCornerAndCenterDirectionType est utilisée dans cette classe et spécifie une direction restreinte aux coins et au centre.
### **La classe ShredTransition, l'interface IShredTransition et l'énumération TransitionShredPattern ont été ajoutées**
La classe com.aspose.slides.ShredTransition (et son interface com.aspose.slides.IShredTransition) concerne le type de transition Shred qui a été supporté dans cette version.
L'énumération com.aspose.slides.TransitionShredPattern est utilisée dans cette classe et spécifie une forme géométrique qui se tile ensemble pour remplir une surface plus grande.