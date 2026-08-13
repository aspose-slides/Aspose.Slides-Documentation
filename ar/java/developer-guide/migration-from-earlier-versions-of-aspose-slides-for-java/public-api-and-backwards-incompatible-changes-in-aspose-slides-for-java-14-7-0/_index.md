---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides for Java لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT, PPTX و ODP."
---
{{% alert color="info" %}} 

هذه الصفحة تُدرج جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) وأي قيود جديدة وتغييرات أخرى تم تقديمها مع Aspose.Slides for Java 14.7.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إزالة منشئي بعض الأنواع الفرعية لـ TransitionValueBase وتم إزالة TransitionValueFactory**
تم إلغاء منشئي بعض الأنواع الفرعية لـ TransitionValueBase (وبشكل خاص CornerDirectionTransition و EightDirectionTransition و EmptyTransition و InOutTransition و OptionalBlackTransition و OrientationTransition و SideDirectionTransition و SplitTransition و WheelTransition) لأنها غير مفيدة في واجهة البرمجة العامة لذلك تم إزالتها. تم إلغاء الفئة المرتبطة TransitionValueFactory وواجهتها ITransitionValueFactory لنفس السبب.
### **تم إزالة العنصر SoundAction من تعداد com.aspose.slides.TransitionType**
كان العنصر SoundAction غير صحيح وغير مستخدم. يتم تعريف إعدادات الصوت بواسطة خصائص SlideShowTransition.SoundMode و .Sound و .SoundLoop و .SoundIsBuiltIn و .SoundName.
### **تمت إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة com.aspose.slides.FlyThroughTransition (وواجهتها com.aspose.slides.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough الذي تم دعمه في هذا الإصدار.
### **تمت إضافة الفئة GlitterTransition وواجهة IGlitterTransition وتعداد TransitionPattern**
الفئة com.aspose.slides.GlitterTransition (وواجهتها com.aspose.slides.IGlitterTransition) تتعلق بنوع الانتقال Glitter الذي تم دعمه في هذا الإصدار. يتم استخدام تعداد com.aspose.slides.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يتكرر لتغطية مساحة أكبر.
### **تمت إضافة الفئة LeftRightDirectionTransition وواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الفئة com.aspose.slides.LeftRightDirectionTransition (وواجهتها com.aspose.slides.ILeftRightDirectionTransition) تتعلق بأنواع الانتقال Switch و Flip و Ferris و Gallery و Conveyor التي تم دعمها في هذا الإصدار. يتم استخدام تعداد com.aspose.slides.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على القيم left و right.
### **تمت إضافة عناصر جديدة إلى تعداد com.aspose.slides.TransitionType**
تم توسيع تعداد com.aspose.slides.TransitionType بإضافة عناصر جديدة. عناصر جديدة متعلقة بالانتقالات الجديدة في PowerPoint 2010: Vortex و Switch و Flip و Ripple و Honeycomb و Cube و Box و Rotate و Orbit و Doors و Window و Ferris و Gallery و Conveyor و Pan و Glitter و Warp و Flythrough و Flash و Shred و Reveal و WheelReverse. عناصر جديدة متعلقة بالانتقالات الجديدة في PowerPoint 2013: FallOver و Drape و Curtains و Wind و Prestige و Fracture و Crush و PeelOff و PageCurlDouble و PageCurlSingle و Airplane و Origami.
### **تمت إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة com.aspose.slides.RevealTransition (وواجهتها com.aspose.slides.IRevealTransition) تتعلق بنوع الانتقال Reveal الذي تم دعمه في هذا الإصدار.
تمت إضافة الفئة RippleTransition وواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType.
الفئة com.aspose.slides.RippleTransition (وواجهتها com.aspose.slides.IRippleTransition) تتعلق بنوع الانتقال Ripple الذي تم دعمه في هذا الإصدار. يتم استخدام تعداد com.aspose.slides.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على الزوايا والوسط.
### **تمت إضافة الفئة ShredTransition والواجهة IShredTransition وتعداد TransitionShredPattern**
الفئة com.aspose.slides.ShredTransition (وواجهتها com.aspose.slides.IShredTransition) تتعلق بنوع الانتقال Shred الذي تم دعمه في هذا الإصدار. يتم استخدام تعداد com.aspose.slides.TransitionShredPattern في هذه الفئة ويحدد شكلًا هندسيًا يتكرر لتغطية مساحة أكبر.