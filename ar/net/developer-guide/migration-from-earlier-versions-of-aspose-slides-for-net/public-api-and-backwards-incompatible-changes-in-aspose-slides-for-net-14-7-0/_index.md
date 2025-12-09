---
title: التغييرات العامة في API والتغييرات غير المتوافقة عكسيًا في Aspose.Slides لـ .NET 14.7.0
linktitle: Aspose.Slides لـ .NET 14.7.0
type: docs
weight: 90
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- ترحيل
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
description: "مراجعة تحديثات API العامة والتغييرات المتشققة في Aspose.Slides لـ .NET لتحديث حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تمت [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **المنشئات والعناصر التي تمت إزالتها**
#### **إزالة بعض مُنشئات الأنواع الفرعية لـ TransitionValueBase و TransitionValueFactory**
تم حذف مُنشئات بعض الأنواع الفرعية لـ TransitionValueBase (CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لأنها غير مفيدة في API العامة. 

تم حذف الفئة المرتبطة TransitionValueFactory وواجهتها ITransitionValueFactory لنفس السبب.
#### **إزالة العنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان عنصر SoundAction غير صحيح ولم يُستخدم. تُحدد إعدادات الصوت عبر الخصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.
### **إضافة فئات وواجهات**
#### **إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة Aspose.Slides.SlideShow.FlyThroughTransition (وواجهتها Aspose.Slides.SlideShow.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough المدعوم بدءاً من هذا الإصدار.
#### **إضافة الفئة GlitterTransition، الواجهة IGlitterTransition وتعداد TransitionPattern**
الفئة Aspose.Slides.SlideShow.GlitterTransition (وواجهتها Aspose.Slides.SlideShow.IGlitterTransition) تتعلق بنوع الانتقال Glitter المدعوم بدءاً من هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يملأ مساحة أكبر.
#### **إضافة الفئة LeftRightDirectionTransition، الواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الفئة Aspose.Slides.SlideShow.LeftRightDirectionTransition (وواجهتها Aspose.Slides.SlideShow.ILeftRightDirectionTransition) تتعلق بأنواع الانتقالات Conveyor، Ferris، Flip، Gallery و Switch. جميعها مدعومة بدءاً من هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على القيم left و right.
#### **إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة.

- عناصر جديدة تتعلق بانتقالات PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window.
- عناصر جديدة تتعلق بانتقالات PowerPoint 2013 الجديدة: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind.
#### **إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة Aspose.Slides.SlideShow.RevealTransition (وواجهتها Aspose.Slides.SlideShow.IRevealTransition) تتعلق بنوع الانتقال Reveal المدعوم بدءاً من هذا الإصدار.
#### **إضافة الفئة RippleTransition، الواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
الفئة Aspose.Slides.SlideShow.RippleTransition (وواجهتها Aspose.Slides.SlideShow.IRippleTransition) تتعلق بنوع الانتقال Ripple المدعوم بدءاً من هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على الزوايا والوسط.