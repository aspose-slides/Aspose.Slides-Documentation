---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 14.7.0
type: docs
weight: 60
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وتغييرات أخرى تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.7.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إزالة المُنشئات من بعض الأنواع الفرعية لـ TransitionValueBase وتمت إزالة TransitionValueFactory**
تمت إزالة المُنشئات من بعض الأنواع الفرعية لـ TransitionValueBase (وبشكل خاص CornerDirectionTransition و EightDirectionTransition و EmptyTransition و InOutTransition و OptionalBlackTransition و OrientationTransition و SideDirectionTransition و SplitTransition و WheelTransition) لأنها غير مفيدة في واجهة برمجة التطبيقات العامة. وتمت إزالة الفئة المتعلقة TransitionValueFactory وواجهة ITransitionValueFactory لنفس السبب.
### **تمت إزالة عنصر SoundAction من تعداد com.aspose.slides.TransitionType**
كان عنصر SoundAction غير صحيح ولم يتم استخدامه. يتم تعريف إعدادات الصوت بواسطة الخصائص SlideShowTransition.SoundMode و .Sound و .SoundLoop و .SoundIsBuiltIn و .SoundName.
### **تمت إضافة فئة FlyThroughTransition وواجهة IFlyThroughTransition**
تتعلق فئة com.aspose.slides.FlyThroughTransition (وواجهتها com.aspose.slides.IFlyThroughTransition) بنوع الانتقال Flythrough الذي تم دعمه في هذا الإصدار.
### **تمت إضافة فئة GlitterTransition وواجهة IGlitterTransition وتعداد TransitionPattern**
تتعلق فئة com.aspose.slides.GlitterTransition (وواجهتها com.aspose.slides.IGlitterTransition) بنوع الانتقال Glitter الذي تم دعمه في هذا الإصدار. 
يتم استخدام تعداد com.aspose.slides.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يملأ معًا منطقة أكبر.
### **تمت إضافة فئة LeftRightDirectionTransition وواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
تتعلق فئة com.aspose.slides.LeftRightDirectionTransition (وواجهتها com.aspose.slides.ILeftRightDirectionTransition) بأنواع الانتقال Switch و Flip و Ferris و Gallery و Conveyor التي تم دعمها في هذا الإصدار. 
يتم استخدام تعداد com.aspose.slides.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بالقيم اليسار واليمين.
### **تمت إضافة عناصر جديدة إلى تعداد com.aspose.slides.TransitionType**
تم توسيع تعداد com.aspose.slides.TransitionType بعناصر جديدة. 
العناصر الجديدة تتعلق بالانتقالات الجديدة في PowerPoint 2010: Vortex و Switch و Flip و Ripple و Honeycomb و Cube و Box و Rotate و Orbit و Doors و Window و Ferris و Gallery و Conveyor و Pan و Glitter و Warp و Flythrough و Flash و Shred و Reveal و WheelReverse.
العناصر الجديدة تتعلق بالانتقالات الجديدة في PowerPoint 2013: FallOver و Drape و Curtains و Wind و Prestige و Fracture و Crush و PeelOff و PageCurlDouble و PageCurlSingle و Airplane و Origami.
### **تمت إضافة فئة RevealTransition وواجهة IRevealTransition**
تتعلق فئة com.aspose.slides.RevealTransition (وواجهتها com.aspose.slides.IRevealTransition) بنوع الانتقال Reveal الذي تم دعمه في هذا الإصدار. 
تمت إضافة فئة RippleTransition وواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType
تتعلق فئة com.aspose.slides.RippleTransition (وواجهتها com.aspose.slides.IRippleTransition) بنوع الانتقال Ripple الذي تم دعمه في هذا الإصدار. 
يتم استخدام تعداد com.aspose.slides.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بالزوايا والمركز.
### **تمت إضافة فئة ShredTransition وواجهة IShredTransition وتعداد TransitionShredPattern**
تتعلق فئة com.aspose.slides.ShredTransition (وواجهتها com.aspose.slides.IShredTransition) بنوع الانتقال Shred الذي تم دعمه في هذا الإصدار. 
يتم استخدام تعداد com.aspose.slides.TransitionShredPattern في هذه الفئة ويحدد شكلًا هندسيًا يملأ معًا منطقة أكبر.