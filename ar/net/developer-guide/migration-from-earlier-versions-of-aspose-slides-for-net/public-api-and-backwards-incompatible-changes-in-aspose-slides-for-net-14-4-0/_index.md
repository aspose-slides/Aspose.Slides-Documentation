---
title: الواجهة العامة للتطبيقات (API) والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.4.0
linktitle: Aspose.Slides لـ .NET 14.4.0
type: docs
weight: 60
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- الهجرة
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض تحديثات الواجهة العامة للتطبيقات (API) والتغييرات المكسورة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

## **الواجهة العامة للتطبيقات (API) والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **إضافة واجهات، فئات، طرق وخصائص**
#### **تمت إضافة الخاصية Aspose.Slides.ILayoutSlide.HasDependingSlides**
تُعيد الخاصية Aspose.Slides.ILayoutSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة النموذجية. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlide.Remove()**
تتيح طريقة Aspose.Slides.ILayoutSlide.Remove() إزالة نموذج من عرض تقديمي بأقل قدر من الشيفرة. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
تتيح طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) إزالة نموذج من المجموعة. أمثلة الشيفرة:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

أو

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
تتيح طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused() إزالة نماذج الشرائح غير المستخدمة (النماذج التي تكون الخاصية HasDependingSlides لها false). أمثلة الشيفرة:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

أو

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **خاصية Aspose.Slides.IMasterSlide.HasDependingSlides**
تُعيد الخاصية Aspose.Slides.IMasterSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة الأساسية. على سبيل المثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **طريقة Aspose.Slides.ISlide.Remove()**
تتيح طريقة Aspose.Slides.ISlide.Remove() إزالة شريحة من عرض تقديمي بأقل قدر من الشيفرة. على سبيل المثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat كائن IFillFormat لتعداد SmartArt إذا كان النموذج يوفر تعدادًا. يمكن استخدامها لتعيين صورة التعداد.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.Level المستوى المتداخل لعقد SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.Position موضع العقدة بين الأشقاء.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **تمت إضافة طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
تسمح طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove() بإزالة عقدة من مخطط.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection**
تم إضافة واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection إلى مساحة الاسم Aspose.Slides.

تُنفّذ فئة GlobalLayoutSlideCollection واجهة IGlobalLayoutSlideCollection.

تمثل واجهة IGlobalLayoutSlideCollection مجموعة جميع نماذج الشرائح في عرض تقديمي. خاصية IPresentation.LayoutSlides هي من النوع IGlobalLayoutSlideCollection. تُوسّع IGlobalLayoutSlideCollection واجهة ILayoutSlideCollection بطرق لإضافة واستنساخ نماذج الشرائح في سياق توحيد مجموعات نماذج الشرائح للماسترات الفردية:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – يمكن استخدامها لإضافة نسخة من نموذج شريحة محدد إلى العرض التقديمي. تحتفظ هذه الطريقة بتنسيق المصدر (عند استنساخ نموذج بين عروض تقديمية مختلفة، يمكن أيضًا استنساخ ماستر النموذج. يُستخدم السجل الداخلي لتتبع الماسترات المستنسخة تلقائيًا لمنع إنشاء نسخ متعددة من نفس الشريحة الأساسية.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – تُستخدم لإضافة نسخة من نموذج شريحة محدد إلى عرض تقديمي. سيتم ربط النموذج الجديد بالماستر المحدد في العرض الهدف. هذا الخيار مماثل للنسخ أو اللصق مع خيار **Use Destination Theme** في Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة نموذج شريحة جديد إلى عرض تقديمي. الأنواع المدعومة: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن توليد اسم النموذج تلقائيًا. النموذج المضاف من النوع SlideLayoutType.Custom لا يحتوي على نائبات (placeholders) ولا أشكال. طريقة مشابهة لهذه الطريقة هي IMasterLayoutSlideCollection.Add(SlideLayoutType, string) التي تُستدعى عبر خاصية IMasterSlide.LayoutSlides.
#### **الواجهة IMasterLayoutSlideCollection والفئة MasterLayoutSlideCollection**
تمت إضافة واجهة IMasterLayoutSlideCollection وفئة MasterLayoutSlideCollection إلى مساحة الاسم Aspose.Slides. تُنفّذ فئة MasterLayoutSlideCollection واجهة IMasterLayoutSlideCollection.

تمثل واجهة IMasterLayoutSlideCollection مجموعة جميع نماذج الشرائح لماستر محدد. تُوسّع هذه الواجهة ILayoutSlideCollection بطرق لإضافة، إدراج، إزالة أو استنساخ نماذج الشرائح في سياق مجموعات نماذج الشرائح الفردية للماستر:

``` csharp

 // توقيع الطريقة:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// مثال شيفرة يرفق نسخة من sourceLayout إلى destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

يمكن استخدام الطريقة لإضافة نسخة من نموذج شريحة محدد إلى نهاية المجموعة. سيتم ربط النموذج الجديد بالماستر الأب لهذا التجميع. وبالتالي فهي مماثلة للنسخ أو اللصق مع خيار **Use Destination Theme** في PowerPoint. طريقة مماثلة هي IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) التي تُستدعى عبر خاصية IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – تُستخدم لإدراج نسخة من نموذج شريحة محدد في موضع معين داخل المجموعة. سيتم ربط النموذج الجديد بالماستر الأب لهذا التجميع. وهذا مماثل للنسخ واللصق مع خيار **Use Destination Theme** في PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة أو إدراج نموذج شريحة جديد. الأنواع المدعومة: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن توليد اسم النموذج تلقائيًا. النموذج المضاف من النوع SlideLayoutType.Custom لا يحتوي على نائبات ولا أشكال. طريقة مشابهة لهذه الطريقة هي IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) التي تُستدعى عبر خاصية IPresentation.LayoutSlides.
- void RemoveAt(int index); – تُستخدم لإزالة النموذج في الفهرس المحدد من المجموعة.
- void Reorder(int index, ILayoutSlide layoutSlide); – تُستخدم لنقل نموذج شريحة داخل المجموعة إلى الموضع المحدد.
### **الطرق والخصائص التي تم تعديلها**
#### **توقيع طريقة Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
توقيع طريقة ISlideCollection السابق:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
أصبح الآن مهملًا وتم استبداله بالتوقيع:

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

المعامل allowCloneMissingLayout يحدد ما يجب القيام به إذا لم يكن هناك نموذج مناسب في destMaster للشفرة (الشريحة) المستنسخة الجديدة. النموذج المناسب هو النموذج الذي يملك النوع نفسه أو الاسم نفسه لنموذج الشريحة المصدر. إذا لم يكن هناك نموذج مناسب في الماستر المحدد، سيتم استنساخ نموذج الشريحة المصدر (إذا كان allowCloneMissingLayout صحيحًا) أو سيتم إلقاء استثناء PptxEditException (إذا كان allowCloneMissingLayout خاطئًا).

استدعاء الطريقة المهملة مثل:

AddClone(sourceSlide, destMaster);

يفترض أن allowCloneMissingLayout يساوي false (أي سيتم إلقاء PptxEditException إذا لم يكن هناك نموذج مناسب). الاستدعاء المكافئ باستخدام التوقيع الجديد يكون هكذا:
AddClone(sourceSlide, destMaster, false);

إذا رغبت في استنساخ النماذج المفقودة تلقائيًا بدلًا من إلقاء استثناء PptxEditException، مرّر المعامل allowCloneMissingLayout كقيمة true.

ينطبق نفس الأمر على طريقة ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

التي أصبحت مهملة أيضًا وتم استبدالها بالتوقيع:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides**
تم تغيير نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides من ILayoutSlideCollection إلى الواجهة الجديدة IMasterLayoutSlideCollection. لأن IMasterLayoutSlideCollection هي فرع من ILayoutSlideCollection، لا تحتاج الشيفرة الموجودة إلى تعديل.
#### **تم تغيير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides**
تم تغيير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides من ILayoutSlideCollection إلى الواجهة الجديدة IGlobalLayoutSlideCollection. لأن IGlobalLayoutSlideCollection هي فرع من ILayoutSlideCollection، لا تحتاج الشيفرة الموجودة إلى تعديل.