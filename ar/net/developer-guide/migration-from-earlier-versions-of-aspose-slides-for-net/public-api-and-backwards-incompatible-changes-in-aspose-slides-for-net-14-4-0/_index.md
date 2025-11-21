---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides لـ .NET 14.4.0
linktitle: Aspose.Slides لـ .NET 14.4.0
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسَّرة في Aspose.Slides لـ .NET لترحيل حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف**
### **الواجهات والفئات والأساليب والخصائص المضافة**
#### **تمت إضافة خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides**
ترجع خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة النموذجية. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlide.Remove()**
تتيح طريقة Aspose.Slides.ILayoutSlide.Remove() إزالة نموذج من عرض تقديمي بأقل كمية من الشيفرة. على سبيل المثال:

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
#### **طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
تتيح طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused() إزالة نماذج الشرائح غير المستخدمة (النماذج التي تكون خاصية HasDependingSlides فيها false). أمثلة الشيفرة:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

أو

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **خاصية Aspose.Slides.IMasterSlide.HasDependingSlides**
ترجع خاصية Aspose.Slides.IMasterSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة الرئيسية. على سبيل المثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **طريقة Aspose.Slides.ISlide.Remove()**
تتيح طريقة Aspose.Slides.ISlide.Remove() إزالة شريحة من عرض تقديمي بأقل كمية من الشيفرة. على سبيل المثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
ترجع خاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat كائن IFillFormat لنقطة SmartArt إذا كان النموذج يوفر نقاطًا. يمكن استخدامها لتعيين صورة النقطة.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level**
ترجع خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level المستوى المتداخل لنقاط SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position**
ترجع خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position موضع النقطة بين الأخوة لها.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **تمت إضافة طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
تتيح طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove() إزالة نقطة من مخطط.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection**
تم إضافة واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection إلى مساحة الاسم Aspose.Slides.

تقوم فئة GlobalLayoutSlideCollection بتنفيذ واجهة IGlobalLayoutSlideCollection.

تمثل واجهة IGlobalLayoutSlideCollection مجموعة جميع نماذج الشرائح في عرض تقديمي. الخاصية IPresentation.LayoutSlides هي من نوع IGlobalLayoutSlideCollection. تمتد IGlobalLayoutSlideCollection من واجهة ILayoutSlideCollection مع أساليب لإضافة ونسخ نماذج الشرائح في سياق توحيد المجموعات الفردية لنماذج الشرائح الخاصة بملف الماستر:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – يمكن استخدامها لإضافة نسخة من نموذج محدد إلى العرض التقديمي. هذه الطريقة تحتفظ بتنسيق المصدر (عند نسخ نموذج بين عروض تقديمية مختلفة، يمكن أيضًا نسخ الماستر الخاص بالنموذج. يُستخدم السجل الداخلي لتتبع النسخ الماسترات التي تم نسخها تلقائيًا لتجنب إنشاء نسخ متعددة من نفس شريحة الماستر.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – تُستخدم لإضافة نسخة من نموذج محدد إلى عرض تقديمي. سيتم ربط النموذج الجديد بالماستر المحدد في العرض الهدف. هذا الخيار مماثل للنسخ أو اللصق مع خيار **Use Destination Theme** في Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة نموذج شريحة جديد إلى عرض تقديمي. أنواع النماذج المدعومة: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن إنشاء اسم النموذج تلقائيًا. النموذج المضاف من النوع SlideLayoutType.Custom لا يحتوي على نُسخ احتياطية ولا أشكال. ما يعادل هذه الطريقة هو طريقة IMasterLayoutSlideCollection.Add(SlideLayoutType, string) التي تُستدعى عبر الخاصية IMasterSlide.LayoutSlides.
#### **الواجهة IMasterLayoutSlideCollection والفئة MasterLayoutSlideCollection**
تمت إضافة واجهة IMasterLayoutSlideCollection وفئة MasterLayoutSlideCollection إلى مساحة الاسم Aspose.Slides. تقوم فئة MasterLayoutSlideCollection بتنفيذ واجهة IMasterLayoutSlideCollection.

تمثل واجهة IMasterLayoutSlideCollection مجموعة جميع نماذج الشرائح لملف ماستر محدد. تمتد من ILayoutSlideCollection مع أساليب لإضافة، إدراج، إزالة أو نسخ نماذج الشرائح في سياق المجموعات الفردية لنماذج ماستر:

``` csharp

 // توقيع الطريقة:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// مثال شيفرة يربط نسخة من sourceLayout بـ destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

يمكن استخدام الطريقة لإضافة نسخة من نموذج محدد إلى نهاية المجموعة. سيُربط النموذج الجديد بملف الماستر الأب لهذه المجموعة. لذا فإنها تعادل النسخ أو اللصق مع خيار **Use Destination Theme** في PowerPoint. ما يعادل هذه الطريقة هو طريقة IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) التي تُستدعى عبر الخاصية IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – تُستخدم لإدراج نسخة من نموذج محدد في موقع محدد داخل المجموعة. سيُربط النموذج الجديد بملف الماستر الأب لهذه المجموعة. لذا فإنها تعادل النسخ واللصق مع خيار **Use Destination Theme** في PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة أو إدراج نموذج شريحة جديد. الأنواع المدعومة هي نفسها المذكورة أعلاه. يمكن إنشاء اسم النموذج تلقائيًا. النموذج المضاف من النوع SlideLayoutType.Custom لا يحتوي على نُسخ احتياطية ولا أشكال. ما يعادل هذه الطريقة هو طريقة IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) التي تُستدعى عبر الخاصية IPresentation.LayoutSlides.
- void RemoveAt(int index); – تُستخدم لإزالة النموذج في الموضع المحدد داخل المجموعة.
- void Reorder(int index, ILayoutSlide layoutSlide); – تُستخدم لنقل نموذج شريحة داخل المجموعة إلى الموضع المحدد.
### **الأساليب والخصائص التي تم تغييرها**
#### **توقيع طريقة Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
توقيع طريقة ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

أصبح الآن قديمًا وتم استبداله بالتوقيع

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

المعلمة allowCloneMissingLayout تحدد ماذا يحدث إذا لم يتوفر نموذج مناسب في destMaster للشرائح (المستنسخة) الجديدة. النموذج المناسب هو النموذج الذي له نفس النوع أو الاسم كنموذج الشريحة المصدر. إذا لم يتوفر نموذج مناسب في الماستر المحدد، سيتم نسخ نموذج المصدر (إذا كان allowCloneMissingLayout true) أو سيتم إلقاء استثناء PptxEditException (إذا كان allowCloneMissingLayout false).

استدعاء الطريقة القديمة مثل

AddClone(sourceSlide, destMaster);

يفترض أن allowCloneMissingLayout يساوي false (أي سيتم إلقاء PptxEditException إذا لم يتوفر نموذج مناسب). الاستدعاء المكافئ باستخدام التوقيع الجديد يكون هكذا:
AddClone(sourceSlide, destMaster, false);

إذا رغبت في نسخ النماذج المفقودة تلقائيًا بدلاً من إلقاء PptxEditException، مرّر المعلمة allowCloneMissingLayout كـ true.

ينطبق نفس الأمر على طريقة ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

أصبحت أيضًا قديمة وتم استبدالها بالتوقيع

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides**
تم تغيير نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides من ILayoutSlideCollection إلى الواجهة الجديدة IMasterLayoutSlideCollection. بما أن IMasterLayoutSlideCollection هي فرع من ILayoutSlideCollection، لا تحتاج الشيفرة الحالية إلى تعديل.
#### **نوع خاصية Aspose.Slides.IPresentation.LayoutSlides تم تغييره**
تم تغيير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides من ILayoutSlideCollection إلى الواجهة الجديدة IGlobalLayoutSlideCollection. بما أن IGlobalLayoutSlideCollection هي فرع من ILayoutSlideCollection، لا تحتاج الشيفرة الحالية إلى تعديل.