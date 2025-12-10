---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.4.0
linktitle: Aspose.Slides لـ .NET 14.4.0
type: docs
weight: 60
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides لـ .NET لتحديث حلول عروض PowerPoint (PPT, PPTX) و ODP بسلاسة."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **الواجهات والفئات والطرق والخصائص المضافة**
#### **تمت إضافة خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides**
تُعيد خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة التخطيطية. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlide.Remove()**
تسمح طريقة Aspose.Slides.ILayoutSlide.Remove() بإزالة تخطيط من عرض تقديمي بأقل كمية من الشيفرة. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
تسمح طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) بإزالة تخطيط من المجموعة. أمثلة على الشيفرة:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
تسمح طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused() بإزالة شرائح التخطيط غير المستخدمة (شرائح التخطيط التي تكون خاصية HasDependingSlides فيها false). أمثلة على الشيفرة:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **خاصية Aspose.Slides.IMasterSlide.HasDependingSlides**
تُعيد خاصية Aspose.Slides.IMasterSlide.HasDependingSlides القيمة true إذا كان هناك شريحة واحدة على الأقل تعتمد على هذه الشريحة الرئيسية. على سبيل المثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **طريقة Aspose.Slides.ISlide.Remove()**
تسمح طريقة Aspose.Slides.ISlide.Remove() بإزالة شريحة من عرض تقديمي بأقل كمية من الشيفرة. على سبيل المثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
تُعيد خاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat كائن IFillFormat لنقطة SmartArt إذا كان التخطيط يوفر نقاطًا. يمكن استخدامها لتعيين صورة النقطة.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level**
تُعيد خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level المستوى المتداخل لعقد SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position**
تُعيد خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position موضع العقدة بين عقدها الشقيقة.

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
تمت إضافة واجهة IGlobalLayoutSlideCollection وفئة GlobalLayoutSlideCollection إلى مساحة الاسم Aspose.Slides.
تقوم فئة GlobalLayoutSlideCollection بتنفيذ واجهة IGlobalLayoutSlideCollection.
تمثل واجهة IGlobalLayoutSlideCollection مجموعة جميع شرائح التخطيط في عرض تقديمي. خاصية IPresentation.LayoutSlides من نوع IGlobalLayoutSlideCollection. تقوم IGlobalLayoutSlideCollection بتمديد واجهة ILayoutSlideCollection بإضافة طرق لإضافة وتكرار شرائح التخطيط في سياق دمج المجموعات الفردية لشرائح تخطيط الماستر:
- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – يمكن استخدامها لإضافة نسخة من شريحة تخطيط محددة إلى العرض التقديمي. تُحافظ هذه الطريقة على تنسيق المصدر (عند تكرار تخطيط بين عروض تقديمية مختلفة، يمكن أيضًا تكرار ماستر التخطيط. يُستخدم السجل الداخلي لتتبع الماسترات المكررة تلقائيًا لمنع إنشاء نسخ متعددة من نفس شريحة الماستر.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – تُستخدم لإضافة نسخة من شريحة تخطيط محددة إلى عرض تقديمي. سيتربط التخطيط الجديد بالماستر المحدد في العرض الهدف. هذا الخيار مشابه للنسخ أو اللصق مع خيار **Use Destination Theme** في Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة شريحة تخطيط جديدة إلى عرض تقديمي. الأنواع المدعومة للتخطيط: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن إنشاء اسم التخطيط تلقائيًا. التخطيط المضاف من النوع SlideLayoutType.Custom لا يحتوي على أي نائبات ولا أشكال. نظير هذه الطريقة هو الطريقة IMasterLayoutSlideCollection.Add(SlideLayoutType, string) التي تُستدعى عبر خاصية IMasterSlide.LayoutSlides.
#### **الواجهة IMasterLayoutSlideCollection والفئة MasterLayoutSlideCollection**
تمت إضافة الواجهة IMasterLayoutSlideCollection والفئة MasterLayoutSlideCollection إلى مساحة الاسم Aspose.Slides. تقوم فئة MasterLayoutSlideCollection بتنفيذ واجهة IMasterLayoutSlideCollection.
تمثل الواجهة IMasterLayoutSlideCollection مجموعة جميع شرائح التخطيط لشريحة ماستر محددة. إنها تمد واجهة ILayoutSlideCollection بطرق لإضافة، إدراج، إزالة أو تكرار شرائح التخطيط في سياق المجموعات الفردية لشرائح تخطيط الماستر:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

يمكن استخدام الطريقة لإضافة نسخة من شريحة تخطيط محددة إلى نهاية المجموعة. سيتربط التخطيط الجديد بشريحة الماستر الأصلية لهذا التجميع. هذا مشابه للنسخ أو اللصق مع خيار **Use Destination Theme** في PowerPoint. نظير هذه الطريقة هو الطريقة IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) التي تُستدعى عبر خاصية IPresentation.LayoutSlides.
- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – تُستخدم لإدراج نسخة من شريحة تخطيط محددة في موضع محدد داخل المجموعة. سيتربط التخطيط الجديد بشريحة الماستر الأصلية لهذا التجميع. هذا مشابه للنسخ واللصق مع خيار **Use Destination Theme** في PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – تُستخدم لإضافة أو إدراج شريحة تخطيط جديدة. الأنواع المدعومة هي: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. يمكن إنشاء اسم التخطيط تلقائيًا. التخطيط المadded من النوع SlideLayoutType.Custom لا يحتوي على نائبة ولا أشكال. نظير هذه الطريقة هو الطريقة IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) التي تُستدعى عبر خاصية IPresentation.LayoutSlides.
- void RemoveAt(int index); – تُستخدم لإزالة التخطيط عند الفهرس المحدد في المجموعة.
- void Reorder(int index, ILayoutSlide layoutSlide); – تُستخدم لنقل شريحة التخطيط داخل المجموعة إلى الموضع المحدد.
### **الطرق والخصائص التي تم تغييرها**
#### **Signature of the Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Method**
The signature of the ISlideCollection method:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

is obsolete now and is replaced with signature

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

The allowCloneMissingLayout parameter specifies what to do if there is no appropriate layout in the destMaster for the new (cloned) slide. The appropriate layout is the layout with the same type or name as the layout of the source slide. If there is no appropriate layout in the specified master then the layout of the source slide will be cloned (if allowCloneMissingLayout is true) or a PptxEditException will be thrown (if allowCloneMissingLayout is false).

Call of the obsolete method like

AddClone(sourceSlide, destMaster);

assumes allowCloneMissingLayout is equal to false (that is, PptxEditException will be thrown if there is no appropriate layout). Functionally identical call that uses new signature looks like this:
AddClone(sourceSlide, destMaster, false);

If you want missing layouts to be automatically cloned instead PptxEditException throwing then pass the allowCloneMissingLayout parameter as true.

The same refers to the ISlideCollection method:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

is also obsolete now and is replaced with signature

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type of the Aspose.Slides.IMasterSlide.LayoutSlides Property**
The type of the Aspose.Slides.IMasterSlide.LayoutSlides property has been changed from ILayoutSlideCollection to the new IMasterLayoutSlideCollection interface. The IMasterLayoutSlideCollection interface is a descendant of the ILayoutSlideCollection so existing code needs no adaptations.
#### **Type of the Aspose.Slides.IPresentation.LayoutSlides Property Has Been Changed**
The type of the Aspose.Slides.IPresentation.LayoutSlides property has been changed from ILayoutSlideCollection to the new IGlobalLayoutSlideCollection interface. The IGlobalLayoutSlideCollection interface is a descendant of the ILayoutSlideCollection so existing code needs no adaptations.