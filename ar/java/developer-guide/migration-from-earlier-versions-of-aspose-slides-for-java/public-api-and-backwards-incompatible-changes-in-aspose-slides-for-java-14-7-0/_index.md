---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لجافا 14.7.0
type: docs
weight: 60
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [الإضافات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، وأي قيود جديدة وتغييرات أخرى تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لجافا 14.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إزالة البناة لبعض الأنماط الفرعية من TransitionValueBase وتمت إزالة TransitionValueFactory**
تمت إزالة البناة لبعض الأنماط الفرعية من TransitionValueBase (وبشكل محدد CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لأنها غير مجدية في واجهة برمجة التطبيقات العامة. تمت إزالة الفئة المرتبطة TransitionValueFactory وواجهة ITransitionValueFactory لنفس السبب.
### **تمت إزالة عنصر SoundAction من تعداد TransitionType في com.aspose.slides**
كان عنصر SoundAction غير صحيح وغير مستخدم. يتم تعريف إعدادات الصوت بواسطة خصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.
### **تمت إضافة فئة FlyThroughTransition وواجهة IFlyThroughTransition**
تتعلق فئة com.aspose.slides.FlyThroughTransition (وفرعها com.aspose.slides.IFlyThroughTransition) بنوع الانتقال Flythrough الذي تم دعمه في هذا الإصدار.
### **تمت إضافة فئة GlitterTransition وواجهة IGlitterTransition وتعداد TransitionPattern**
تتعلق فئة com.aspose.slides.GlitterTransition (وفرعها com.aspose.slides.IGlitterTransition) بنوع الانتقال Glitter الذي تم دعمه في هذا الإصدار. يستخدم تعداد com.aspose.slides.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يتناسب معًا لملء منطقة أكبر.
### **تمت إضافة فئة LeftRightDirectionTransition وواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
تتعلق فئة com.aspose.slides.LeftRightDirectionTransition (وفرعها com.aspose.slides.ILeftRightDirectionTransition) بأنواع الانتقال Switch، Flip، Ferris، Gallery، Conveyor التي تم دعمها في هذا الإصدار. يستخدم تعداد com.aspose.slides.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بقيم اليسار واليمين.
### **تمت إضافة عناصر جديدة إلى تعداد com.aspose.slides.TransitionType**
تم توسيع تعداد com.aspose.slides.TransitionType بعناصر جديدة. 
العناصر الجديدة المتعلقة بالانتقالات الجديدة في PowerPoint 2010: Vortex، Switch، Flip، Ripple، Honeycomb، Cube، Box، Rotate، Orbit، Doors، Window، Ferris، Gallery، Conveyor، Pan، Glitter، Warp، Flythrough، Flash، Shred، Reveal، WheelReverse.
العناصر الجديدة المتعلقة بالانتقالات الجديدة في PowerPoint 2013: FallOver، Drape، Curtains، Wind، Prestige، Fracture، Crush، PeelOff، PageCurlDouble، PageCurlSingle، Airplane، Origami.
### **تمت إضافة فئة RevealTransition وواجهة IRevealTransition**
تتعلق فئة com.aspose.slides.RevealTransition (وفرعها com.aspose.slides.IRevealTransition) بنوع الانتقال Reveal الذي تم دعمه في هذا الإصدار.
### **تمت إضافة فئة RippleTransition وواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
تتعلق فئة com.aspose.slides.RippleTransition (وفرعها com.aspose.slides.IRippleTransition) بنوع الانتقال Ripple الذي تم دعمه في هذا الإصدار. يستخدم تعداد com.aspose.slides.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بالزوايا والمركز.
### **تمت إضافة فئة ShredTransition وواجهة IShredTransition وتعداد TransitionShredPattern**
تتعلق فئة com.aspose.slides.ShredTransition (وفرعها com.aspose.slides.IShredTransition) بنوع الانتقال Shred الذي تم دعمه في هذا الإصدار. يستخدم تعداد com.aspose.slides.TransitionShredPattern في هذه الفئة ويحدد شكلًا هندسيًا يتناسب معًا لملء منطقة أكبر.