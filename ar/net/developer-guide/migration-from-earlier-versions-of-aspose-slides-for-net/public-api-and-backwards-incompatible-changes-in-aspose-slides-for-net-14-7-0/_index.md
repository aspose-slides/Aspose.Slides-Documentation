---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides لـ .NET 14.7.0"
linktitle: "Aspose.Slides لـ .NET 14.7.0"
type: docs
weight: 90
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتجانبة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ، وتغييرات أخرى تم تقديمها مع Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **التغييرات العامة في واجهة برمجة التطبيقات**
### **المنشئات والعناصر التي تم إزالتها**
#### **إزالة بعض منشئات الأنواع الفرعية لـ TransitionValueBase و TransitionValueFactory**
إن منشآت بعض الأنواع الفرعية لـ TransitionValueBase (وبشكل محدد CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لا فائدة لها في واجهة برمجة التطبيقات العامة وبالتالي تم إزالتها. 

تمت إزالة الفئة المرتبطة TransitionValueFactory والواجهة ITransitionValueFactory لنفس السبب.
#### **إزالة العنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان العنصر SoundAction غير صحيح ولم يُستخدم. يتم تعريف إعدادات الصوت بواسطة الخصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.
### **الفئات والواجهات التي تم إضافتها**
#### **إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة Aspose.Slides.SlideShow.FlyThroughTransition (والواجهة Aspose.Slides.SlideShow.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough المدعوم منذ هذا الإصدار.
#### **إضافة الفئة GlitterTransition، الواجهة IGlitterTransition وتعداد TransitionPattern**
الفئة Aspose.Slides.SlideShow.GlitterTransition (والواجهة Aspose.Slides.SlideShow.IGlitterTransition) تتعلق بنوع الانتقال Glitter المدعوم منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يُرصّ معًا لملء مساحة أكبر.
#### **إضافة الفئة LeftRightDirectionTransition، الواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الفئة Aspose.Slides.SlideShow.LeftRightDirectionTransition (والواجهة Aspose.Slides.SlideShow.ILeftRightDirectionTransition) تتعلق بأنواع الانتقال Conveyor، Ferris، Flip، Gallery و Switch. جميعها مدعومة منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا، مقيدًا بالقيم left و right.
#### **إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة.

- عناصر جديدة تتعلق بالانتقالات في PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window.
- عناصر جديدة تتعلق بالانتقالات في PowerPoint 2013: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind.
#### **إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة Aspose.Slides.SlideShow.RevealTransition (والواجهة Aspose.Slides.SlideShow.IRevealTransition) تتعلق بنوع الانتقال Reveal المدعوم منذ هذا الإصدار.
#### **إضافة الفئة RippleTransition، الواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
الفئة Aspose.Slides.SlideShow.RippleTransition (والواجهة Aspose.Slides.SlideShow.IRippleTransition) تتعلق بنوع الانتقال Ripple المدعوم منذ هذا الإصدار.

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا، مقيدًا بالزوايا والوسط.