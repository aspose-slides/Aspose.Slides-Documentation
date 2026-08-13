---
title: التغييرات العامة للواجهة غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.7.0
linktitle: Aspose.Slides لـ .NET 14.7.0
type: docs
weight: 90
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- الهجرة
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
description: "مراجعة تحديثات الواجهة العامة والتغييرات المكسّرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP الخاصة بك بسلاسة."
---
{{% alert color="info" %}} 

هذه الصفحة تُظهر جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [مُزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **التغييرات العامة للواجهة**
### **المنشئات والعناصر التي تم إزالتها**
#### **إزالة بعض منشئات الأنواع الفرعية لـ TransitionValueBase و TransitionValueFactory**
تم إلغاء منشآت بعض الأنواع الفرعية لـ TransitionValueBase (المحددة هي CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لأنها غير مفيدة في الواجهة العامة.

تم إلغاء الفئة المرتبطة TransitionValueFactory والواجهة ITransitionValueFactory لنفس السبب.
#### **إزالة عنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان عنصر SoundAction غير صحيح ولا يُستَخدم. يتم تعريف إعدادات الصوت عبر الخصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.
### **إضافة فئات وواجهات**
#### **إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة Aspose.Slides.SlideShow.FlyThroughTransition (وواجهتها Aspose.Slides.SlideShow.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough المدعوم منذ هذا الإصدار.
#### **إضافة الفئة GlitterTransition، والواجهة IGlitterTransition، وتعداد TransitionPattern**
الفئة Aspose.Slides.SlideShow.GlitterTransition (وواجهتها Aspose.Slides.SlideShow.IGlitterTransition) تتعلق بنوع الانتقال Glitter المدعوم منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يُرصّ لتغطية مساحة أكبر.
#### **إضافة الفئة LeftRightDirectionTransition، والواجهة ILeftRightDirectionTransition، وتعداد TransitionLeftRightDirectionType**
الفئة Aspose.Slides.SlideShow.LeftRightDirectionTransition (وواجهتها Aspose.Slides.SlideShow.ILeftRightDirectionTransition) تتعلق بأنواع الانتقال Conveyor، Ferris، Flip، Gallery و Switch. جميعها مدعومة منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بالقيم left و right.
#### **إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة.

- عناصر جديدة متعلقة بانتقالات PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window.
- عناصر جديدة متعلقة بانتقالات PowerPoint 2013 الجديدة: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind.
#### **إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة Aspose.Slides.SlideShow.RevealTransition (وواجهتها Aspose.Slides.SlideShow.IRevealTransition) تتعلق بنوع الانتقال Reveal المدعوم منذ هذا الإصدار.
#### **إضافة الفئة RippleTransition، والواجهة IRippleTransition، وتعداد TransitionCornerAndCenterDirectionType**
الفئة Aspose.Slides.SlideShow.RippleTransition (وواجهتها Aspose.Slides.SlideShow.IRippleTransition) تتعلق بنوع الانتقال Ripple المدعوم منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا مقيدًا بالأركان والمركز.