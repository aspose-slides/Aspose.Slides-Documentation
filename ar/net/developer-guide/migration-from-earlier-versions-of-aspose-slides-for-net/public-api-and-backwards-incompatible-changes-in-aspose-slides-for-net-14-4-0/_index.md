---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.4.0"
linktitle: "Aspose.Slides لـ .NET 14.4.0"
type: docs
weight: 60
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET لتترحيل حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الواجهات والفئات والطرق والخصائص المضافة**
#### **تم إضافة الخاصية Aspose.Slides.ILayoutSlide.HasDependingSlides**
تعيد الخاصية Aspose.Slides.ILayoutSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة التخطيطية. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlide.Remove()**
تتيح طريقة Aspose.Slides.ILayoutSlide.Remove() حذف تخطيط من عرض تقديمي بأقل قدر من الشيفرة. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
تتيح طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) حذف تخطيط من المجموعة. أمثلة على الشيفرة:

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
تتيح طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused() حذف شرائح التخطيط غير المستخدمة (الشرائح التي تكون HasDependingSlides فيها false). أمثلة على الشيفرة:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

أو

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **خاصية Aspose.Slides.IMasterSlide.HasDependingSlides**
تُرجع الخاصية Aspose.Slides.IMasterSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة الرئيسية. على سبيل المثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **طريقة Aspose.Slides.ISlide.Remove()**
تتيح طريقة Aspose.Slides.ISlide.Remove() حذف شريحة من عرض تقديمي بأقل قدر من الشيفرة. على سبيل المثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat كائن IFillFormat لفقرة SmartArt إذا كان التخطيط يوفر نقطًا. يمكن استخدامها لتعيين صورة الفقرة.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.Level المستوى المتداخل لعقد SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.Position موضع العقدة بين أشقائها.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **تم إضافة طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
تتيح طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove() حذف عقدة من مخطط.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection**
تم إضافة واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection إلى مساحة الاسم Aspose.Slides.

تُنفذ فئة GlobalLayoutSlideCollection واجهة IGlobalLayoutSlideCollection.

تمثل واجهة IGlobalLayoutSlideCollection مجموعة جميع شرائح التخطيط في عرض تقديمي. خاصية IPresentation.LayoutSlides هي من النوع IGlobalLayoutSlideCollection. تُوسّع IGlobalLayoutSlideCollection واجهة ILayoutSlideCollection بطرق لإضافة واستنساخ شرائح التخطيط في سياق توحيد مجموعات شرائح التخطيط الخاصة بكل رئيس.

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – يمكن استخدامها لإضافة نسخة من شريحة تخطيط محددة إلى العرض. تحتفظ هذه الطريقة بتنسيق المصدر (عند استنساخ تخطيط بين عروض تقديمية مختلفة، يمكن أيضًا استنساخ رئيس التخطيط. يُستخدم السجل الداخلي لتتبع المراسم المستنسخة تلقائيًا لتجنّب إنشاء نسخ متعددة من نفس الشريحة الرئيسة.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – تُستخدم لإضافة نسخة من شريحة تخطيط محددة إلى عرض تقديمي. سيتم ربط التخطيط الجديد بالرئيس المحدد في العرض الوجهة. هذا الخيار مماثل للنسخ أو اللصق مع خيار **Use Destination Theme** في Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة شريحة تخطيط جديدة إلى عرض تقديمي. أنواع التخطيطات المدعومة: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن إنشاء اسم التخطيط تلقائيًا. التخطيط من النوع SlideLayoutType.Custom لا يحتوي على نِسَخ مؤقتة ولا أشكال. نظير هذه الطريقة هو طريقة IMasterLayoutSlideCollection.Add(SlideLayoutType, string) المتاحة عبر خاصية IMasterSlide.LayoutSlides.
#### **واجهة IMasterLayoutSlideCollection وفئة MasterLayoutSlideCollection**
تم إضافة واجهة IMasterLayoutSlideCollection وفئة MasterLayoutSlideCollection إلى مساحة الاسم Aspose.Slides. تُنفذ فئة MasterLayoutSlideCollection واجهة IMasterLayoutSlideCollection.

تمثل واجهة IMasterLayoutSlideCollection مجموعة جميع شرائح التخطيط الخاصة برئيس محدد. تُوسّع ILayoutSlideCollection بطرق لإضافة أو إدراج أو حذف أو استنساخ شرائح التخطيط في سياق مجموعات شرائح التخطيط الخاصة بكل رئيس:

``` csharp

 // توقيع الطريقة:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// مثال شيفرة يربط نسخة من sourceLayout بـ destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

يمكن استخدام الطريقة لإضافة نسخة من شريحة تخطيط محددة إلى نهاية المجموعة. سيتم ربط التخطيط الجديد بالرئيس الأصلي لهذه المجموعة. وبالتالي هي مكافئ للنسخ أو اللصق مع خيار **Use Destination Theme** في PowerPoint. نظير هذه الطريقة هو IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) المتاح عبر خاصية IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – تُستخدم لإدراج نسخة من شريحة تخطيط محددة في موضع محدد داخل المجموعة. سيُربط التخطيط الجديد بالرئيس الأصلي للمجموعة. هذا مكافئ للنسخ واللصق مع خيار **Use Destination Theme** في PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة أو إدراج شريحة تخطيط جديدة. الأنواع المدعومة هي نفسها المذكورة أعلاه. يمكن إنشاء اسم التخطيط تلقائيًا. التخطيط من النوع SlideLayoutType.Custom لا يحتوي على نِسَخ مؤقتة ولا أشكال. نظير هذه الطريقة هو IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) المتاح عبر خاصية IPresentation.LayoutSlides.
- void RemoveAt(int index); – تُستخدم لإزالة التخطيط في الفهرس المحدد من المجموعة.
- void Reorder(int index, ILayoutSlide layoutSlide); – تُستخدم لنقل شريحة التخطيط داخل المجموعة إلى الموضع المحدد.
### **الطرق والخصائص المتغيّرة**
#### **توقيع طريقة Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
توقيع الطريقة في ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

أصبح الآن قديمًا وتم استبداله بالتوقيع

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

المعامل allowCloneMissingLayout يحدد ما يجب فعله إذا لم يتوفر تخطيط مناسب في destMaster للشريحة (المستنسخة) الجديدة. التخطيط المناسب هو التخطيط الذي يحمل نفس النوع أو الاسم كما في شريحة المصدر. إذا لم يوجد تخطيط مناسب في الرئيس المحدد فسيتم استنساخ تخطيط شريحة المصدر (إذا كان allowCloneMissingLayout true) أو سيتم إلقاء استثناء PptxEditException (إذا كان allowCloneMissingLayout false).

استدعاء الطريقة القديمة مثل

AddClone(sourceSlide, destMaster);

يفترض أن allowCloneMissingLayout يساوي false (أي سيتم إلقاء PptxEditException إذا لم يتوفر تخطيط مناسب). الاستدعاء المكافئ باستخدام التوقيع الجديد هو:

AddClone(sourceSlide, destMaster, false);

إذا رغبت في استنساخ التخطيطات المفقودة تلقائيًا بدلاً من إلقاء استثناء PptxEditException فمرّر المعامل allowCloneMissingLayout كقيمة true.

ينطبق نفس الأمر على طريقة ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

أصبحت أيضًا قديمة وتم استبدالها بالتوقيع

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides**
تم تغيير نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides من ILayoutSlideCollection إلى واجهة IMasterLayoutSlideCollection الجديدة. بما أن IMasterLayoutSlideCollection هي فرعية من ILayoutSlideCollection، لا يحتاج الكود الموجود إلى تعديل.
#### **نوع خاصية Aspose.Slides.IPresentation.LayoutSlides تم تغييره**
تم تغيير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides من ILayoutSlideCollection إلى واجهة IGlobalLayoutSlideCollection الجديدة. بما أن IGlobalLayoutSlideCollection هي فرعية من ILayoutSlideCollection، لا يحتاج الكود الموجود إلى تعديل.