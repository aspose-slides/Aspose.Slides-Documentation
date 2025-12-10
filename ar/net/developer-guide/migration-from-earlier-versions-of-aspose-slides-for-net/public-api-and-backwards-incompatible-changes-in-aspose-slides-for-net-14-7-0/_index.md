---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides لـ .NET 14.7.0
linktitle: Aspose.Slides لـ .NET 14.7.0
type: docs
weight: 90
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- ترحيل
- رمز قديم
- رمز حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسورة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) الفئات، الطرق، الخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم إدخالها مع Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **تم إزالة البُنى والعناصر**
#### **تم إزالة بعض بُنيات فرعية لـ TransitionValueBase وبُنية TransitionValueFactory**
تم حذف بُنيات بعض الأنواع الفرعية لـ TransitionValueBase (CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) لأنها غير مفيدة في API العامة.  

تم حذف الفئة المرتبطة TransitionValueFactory وواجهتها ITransitionValueFactory لنفس السبب.  
#### **تم إزالة العنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان عنصر SoundAction غير صحيح ولم يُستخدم. تُحدد إعدادات الصوت عبر خصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.  
### **إضافة فئات وواجهات**
#### **تم إضافة الفئة FlyThroughTransition والواجهة IFlyThroughTransition**
الفئة Aspose.Slides.SlideShow.FlyThroughTransition (واواجهتها Aspose.Slides.SlideShow.IFlyThroughTransition) تتعلق بنوع الانتقال Flythrough المدعوم من هذا الإصدار.  
#### **تم إضافة الفئة GlitterTransition والواجهة IGlitterTransition وتعداد TransitionPattern**
الفئة Aspose.Slides.SlideShow.GlitterTransition (واواجهتها Aspose.Slides.SlideShow.IGlitterTransition) تتعلق بنوع الانتقال Glitter المدعوم من هذا الإصدار.  

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionPattern في هذه الفئة ويحدد نمطًا هندسيًا يكرر نفسه لملء مساحة أكبر.  
#### **تم إضافة الفئة LeftRightDirectionTransition والواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الفئة Aspose.Slides.SlideShow.LeftRightDirectionTransition (واواجهتها Aspose.Slides.SlideShow.ILeftRightDirectionTransition) تتعلق بأنواع الانتقال Conveyor، Ferris، Flip، Gallery وSwitch. جميعها مدعومة من هذا الإصدار.  

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على القيم left وright.  
#### **تم إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة.  

- عناصر جديدة مرتبطة بانتقالات PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- عناصر جديدة مرتبطة بانتقالات PowerPoint 2013 الجديدة: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **تم إضافة الفئة RevealTransition والواجهة IRevealTransition**
الفئة Aspose.Slides.SlideShow.RevealTransition (واواجهتها Aspose.Slides.SlideShow.IRevealTransition) تتعلق بنوع الانتقال Reveal المدعوم من هذا الإصدار.  
#### **تم إضافة الفئة RippleTransition والواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
الفئة Aspose.Slides.SlideShow.RippleTransition (واواجهتها Aspose.Slides.SlideShow.IRippleTransition) تتعلق بنوع الانتقال Ripple المدعوم من هذا الإصدار.  

يُستخدم تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType في هذه الفئة ويحدد اتجاهًا يقتصر على الزوايا والمركز.