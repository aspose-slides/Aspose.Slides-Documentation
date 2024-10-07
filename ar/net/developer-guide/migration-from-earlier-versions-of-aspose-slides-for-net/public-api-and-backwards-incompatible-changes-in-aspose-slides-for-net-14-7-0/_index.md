---
title: واجهة البرمجة العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.7.0
type: docs
weight: 90
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المكونات المضافة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) أو [المكونات المحذوفة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) من الأصناف، الأساليب، الخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.7.0.

{{% /alert %}} 
## **تغييرات واجهة البرمجة العامة**
### **البناءات والعناصر المحذوفة**
#### **تمت إزالة بعض البناءات الفرعية لـ TransitionValueBase وTransitionValueFactory**
البناءات لبعض الأنواع الفرعية لـ TransitionValueBase (على وجه التحديد CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) غير مفيدة في واجهة البرمجة العامة وبالتالي تم إزالتها.

تمت إزالة الصفحة ذات الصلة TransitionValueFactory وواجهة ITransitionValueFactory لنفس السبب.
#### **تمت إزالة عنصر SoundAction من تعداد Aspose.Slides.SlideShow.TransitionType**
كان عنصر SoundAction غير صحيح ولم يُستخدم. يتم تعريف إعدادات الصوت من خلال الخصائص SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName.
### **تم إضافة الأصناف والواجهات**
#### **تمت إضافة صنف FlyThroughTransition وواجهة IFlyThroughTransition**
الصنف Aspose.Slides.SlideShow.FlyThroughTransition (وواجهة Aspose.Slides.SlideShow.IFlyThroughTransition) يتعلق بنوع الانتقال Flythrough المدعوم من هذا الإصدار.
#### **تمت إضافة صنف GlitterTransition وواجهة IGlitterTransition وتعداد TransitionPattern**
الصنف Aspose.Slides.SlideShow.GlitterTransition (وواجهة Aspose.Slides.SlideShow.IGlitterTransition) يتعلق بنوع الانتقال Glitter المدعوم من هذا الإصدار.

يتم استخدام تعداد Aspose.Slides.SlideShow.TransitionPattern في هذا الصنف ويحدد نمطًا هندسيًا يتم تجميعه معًا لملء منطقة أكبر.
#### **تمت إضافة صنف LeftRightDirectionTransition وواجهة ILeftRightDirectionTransition وتعداد TransitionLeftRightDirectionType**
الصنف Aspose.Slides.SlideShow.LeftRightDirectionTransition (وواجهة Aspose.Slides.SlideShow.ILeftRightDirectionTransition) يتعلق بأنواع الانتقال Conveyor وFerris وFlip وGallery وSwitch. جميعها مدعومة من هذا الإصدار.

يتم استخدام تعداد Aspose.Slides.SlideShow.TransitionLeftRightDirectionType في هذا الصنف ويحدد اتجاهًا، مقيدًا بالقيم اليسار واليمين.
#### **تمت إضافة عناصر جديدة إلى تعداد Aspose.Slides.SlideShow.TransitionType**
تم توسيع تعداد Aspose.Slides.SlideShow.TransitionType بعناصر جديدة.

- عناصر جديدة تتعلق بانتقالات PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window.
- عناصر جديدة تتعلق بانتقالات PowerPoint 2013 الجديدة: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind.
#### **تمت إضافة صنف RevealTransition وواجهة IRevealTransition**
الصنف Aspose.Slides.SlideShow.RevealTransition (وواجهة Aspose.Slides.SlideShow.IRevealTransition) يتعلق بنوع الانتقال Reveal المدعوم من هذا الإصدار.
#### **تمت إضافة صنف RippleTransition وواجهة IRippleTransition وتعداد TransitionCornerAndCenterDirectionType**
الصنف Aspose.Slides.SlideShow.RippleTransition (وواجهة Aspose.Slides.SlideShow.IRippleTransition) يتعلق بنوع الانتقال Ripple المدعوم من هذا الإصدار.

يتم استخدام تعداد Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType في هذا الصنف ويحدد اتجاهًا، مقيدًا بالأركان والوسط.