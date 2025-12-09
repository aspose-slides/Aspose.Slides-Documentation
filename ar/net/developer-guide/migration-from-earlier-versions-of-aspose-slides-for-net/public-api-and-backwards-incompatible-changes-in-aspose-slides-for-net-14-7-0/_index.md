---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.7.0
linktitle: Aspose.Slides لـ .NET 14.7.0
type: docs
weight: 90
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- الترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP بسلاسة."
---

{{% alert color="primary" %}} 
تُدرج هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 14.7.0 API.
{{% /alert %}} 
## **تغييرات API العامة**
### **المنشئات والعناصر التي تمت إزالتها**
#### **تمت إزالة بعض منشئات الأنواع الفرعية لـ TransitionValueBase و TransitionValueFactory**
منشئات بعض الأنواع الفرعية لـ TransitionValueBase (وتحديداً CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لا فائدة لها في API العامة لذا تم إزالتها. 
تمت إزالة الفئة المرتبطة TransitionValueFactory والواجهة ITransitionValueFactory لنفس السبب. 
#### **تمت إزالة عنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان عنصر SoundAction غير صحيح ولم يُستخدم. يتم تعريف إعدادات الصوت عبر خصائص SlideShowTransition.SoundMode و .Sound و .SoundLoop و .SoundIsBuiltIn و .SoundName. 
### **الفئات والواجهات المضافة**
#### **تمت إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة Aspose.Slides.SlideShow.FlyThroughTransition (وواجهتها Aspose.Slides.SlideShow.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough المدعوم منذ هذا الإصدار. 
#### **تمت إضافة الفئة GlitterTransition والواجهة IGlitterTransition وتعداد TransitionPattern**
الفئة Aspose.Slides.SlideShow.GlitterTransition (وواجهتها Aspose.Slides.SlideShow.IGlitterTransition) تتعلق بنوع الانتقال Glitter المدعوم منذ هذا الإصدار. 
تعداد Aspose.Slides.SlideShow.TransitionPattern يُستَخدم في هذه الفئة ويحدد نمطًا هندسيًا يُوزع لتغطية مساحة أكبر. 
#### **تمت إضافة الفئة LeftRightDirectionTransition والواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الفئة Aspose.Slides.SlideShow.LeftRightDirectionTransition (وواجهتها Aspose.Slides.SlideShow.ILeftRightDirectionTransition) تتعلق بأنواع الانتقال Conveyor و Ferris و Flip و Gallery و Switch. جميعها مدعومة منذ هذا الإصدار. 
تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType يُستَخدم في هذه الفئة ويحدد اتجاهًا، مقصراً على القيم left و right. 
#### **تمت إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة. 
- عناصر جديدة متعلقة بانتقالات PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window. 
- عناصر جديدة متعلقة بانتقالات PowerPoint 2013 الجديدة: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind. 
#### **تمت إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة Aspose.Slides.SlideShow.RevealTransition (وواجهة Aspose.Slides.SlideShow.IRevealTransition) تتعلق بنوع الانتقال Reveal المدعوم منذ هذا الإصدار. 
#### **تمت إضافة الفئة RippleTransition والواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
الفئة Aspose.Slides.SlideShow.RippleTransition (وواجهتها Aspose.Slides.SlideShow.IRippleTransition) تتعلق بنوع الانتقال Ripple المدعوم منذ هذا الإصدار. 
تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType يُستَخدم في هذه الفئة ويحدد اتجاهًا، مقصراً على الزوايا والوسط.