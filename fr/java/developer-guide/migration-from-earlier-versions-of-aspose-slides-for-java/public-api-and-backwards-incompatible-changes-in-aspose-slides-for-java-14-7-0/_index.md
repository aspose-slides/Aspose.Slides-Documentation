---
title: API publique et modifications incompatibles avec les versions antérieures dans Aspose.Slides pour Java 14.7.0
linktitle: Aspose.Slides pour Java 14.7.0
type: docs
weight: 60
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) classes, méthodes, propriétés, etc., ainsi que les nouvelles restrictions et autres modifications introduites avec l'API Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Constructeurs de certains sous‑types de TransitionValueBase ont été supprimés et TransitionValueFactory a été supprimé**
Les constructeurs de certains sous‑types de TransitionValueBase (et notamment CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sont inutiles dans l'API publique et ont donc été supprimés. La classe associée TransitionValueFactory et son interface ITransitionValueFactory ont été retirés pour la même raison.
### **L'élément SoundAction a été supprimé de l'énumération com.aspose.slides.TransitionType**
L'élément SoundAction était incorrect et n'était pas utilisé. Les paramètres sonores sont définis par les propriétés SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **La classe FlyThroughTransition et l'interface IFlyThroughTransition ont été ajoutées**
La classe com.aspose.slides.FlyThroughTransition (et son interface com.aspose.slides.IFlyThroughTransition) correspond au type de transition Flythrough qui est pris en charge dans cette version.
### **Les classes GlitterTransition, IGlitterTransition et l'énumération TransitionPattern ont été ajoutées**
La classe com.aspose.slides.GlitterTransition (et son interface com.aspose.slides.IGlitterTransition) correspond au type de transition Glitter qui est pris en charge dans cette version. L'énumération com.aspose.slides.TransitionPattern est utilisée dans cette classe et spécifie un motif géométrique qui se répète pour couvrir une plus grande surface.
### **La classe LeftRightDirectionTransition, l'interface ILeftRightDirectionTransition et l'énumération TransitionLeftRightDirectionType ont été ajoutées**
La classe com.aspose.slides.LeftRightDirectionTransition (et son interface com.aspose.slides.ILeftRightDirectionTransition) correspond aux types de transition Switch, Flip, Ferris, Gallery, Conveyor qui sont pris en charge dans cette version. L'énumération com.aspose.slides.TransitionLeftRightDirectionType est utilisée dans cette classe et spécifie une direction limitée aux valeurs left et right.
### **De nouveaux éléments ont été ajoutés à l'énumération com.aspose.slides.TransitionType**
L'énumération com.aspose.slides.TransitionType a été étendue avec de nouveaux éléments. Nouveaux éléments liés aux transitions PowerPoint 2010 : Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nouveaux éléments liés aux transitions PowerPoint 2013 : FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **La classe RevealTransition et l'interface IRevealTransition ont été ajoutées**
La classe com.aspose.slides.RevealTransition (et son interface com.aspose.slides.IRevealTransition) correspond au type de transition Reveal qui est pris en charge dans cette version. La classe RippleTransition, l'interface IRippleTransition et l'énumération TransitionCornerAndCenterDirectionType ont été ajoutées.
La classe com.aspose.slides.RippleTransition (et son interface com.aspose.slides.IRippleTransition) correspond au type de transition Ripple qui est pris en charge dans cette version. L'énumération com.aspose.slides.TransitionCornerAndCenterDirectionType est utilisée dans cette classe et spécifie une direction limitée aux coins et au centre.
### **La classe ShredTransition, l'interface IShredTransition et l'énumération TransitionShredPattern ont été ajoutées**
La classe com.aspose.slides.ShredTransition (et son interface com.aspose.slides.IShredTransition) correspond au type de transition Shred qui est pris en charge dans cette version. L'énumération com.aspose.slides.TransitionShredPattern est utilisée dans cette classe et spécifie une forme géométrique qui se répète pour couvrir une plus grande surface.