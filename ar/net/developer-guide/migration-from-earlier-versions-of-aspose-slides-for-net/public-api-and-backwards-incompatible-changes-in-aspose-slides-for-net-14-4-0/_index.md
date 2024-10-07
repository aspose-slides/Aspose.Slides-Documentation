---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.4.0
type: docs
weight: 60
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
### **تمت إضافة الواجهات والفصول والطرق والخصائص**
#### **تمت إضافة خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides**
تعود خاصية Aspose.Slides.ILayoutSlide.HasDependingSlides بقيمة true إذا كان هناك على الأقل شريحة واحدة تعتمد على شريحة التخطيط هذه. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlide.Remove()**
تسمح لك طريقة Aspose.Slides.ILayoutSlide.Remove() بإزالة تخطيط من عرض تقديمي بأقل قدر من التعليمات البرمجية. على سبيل المثال:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
تسمح لك طريقة Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) بإزالة تخطيط من المجموعة. أمثلة التعليمات البرمجية:

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
تسمح لك طريقة Aspose.Slides.ILayoutSlideCollection.RemoveUnused() بإزالة شرائح التخطيط غير المستخدمة (شرائح التخطيط التي تكون HasDependingSlides لها false). أمثلة التعليمات البرمجية:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

أو

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **خاصية Aspose.Slides.IMasterSlide.HasDependingSlides**
تعود خاصية Aspose.Slides.IMasterSlide.HasDependingSlides بقيمة true إذا كان هناك على الأقل شريحة واحدة تعتمد على شريحة الماستر هذه. على سبيل المثال:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **طريقة Aspose.Slides.ISlide.Remove()**
تسمح لك طريقة Aspose.Slides.ISlide.Remove() بإزالة شريحة من عرض تقديمي بأقل قدر من التعليمات البرمجية. على سبيل المثال:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
تعود خاصية Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat بـ IFillFormat لرمز SmartArt إذا كان التخطيط يوفر رموز. يمكن استخدامها لتعيين صورة الرمز.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level**
تعود خاصية Aspose.Slides.SmartArt.ISmartArtNode.Level بالمستوى المتداخل لعقد SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "المستوى الأول";

``` 
#### **خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position**
تعود خاصية Aspose.Slides.SmartArt.ISmartArtNode.Position بموقع عقدة ما بين أشقائها.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **تمت إضافة طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
تسمح لك طريقة Aspose.Slides.SmartArt.ISmartArtNode.Remove() بإزالة عقدة من رسم تخطيطي.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **واجهة IGlobalLayoutSlideCollection وفصل GlobalLayoutSlideCollection**
تمت إضافة واجهة IGlobalLayoutSlideCollection وفصل GlobalLayoutSlideCollection إلى مساحة أسماء Aspose.Slides.

إن فصل GlobalLayoutSlideCollection ينفذ واجهة IGlobalLayoutSlideCollection.

تمثل واجهة IGlobalLayoutSlideCollection مجموعة من جميع شرائح التخطيط في عرض تقديمي. خاصية IPresentation.LayoutSlides من نوع IGlobalLayoutSlideCollection. تمتد IGlobalLayoutSlideCollection واجهة ILayoutSlideCollection بطرق لإضافة ونسخ شرائح التخطيط في سياق توحيد المجموعات الفردية لشرائح تخطيطات الماستر:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – يمكن استخدامها لإضافة نسخة من شريحة تخطيط محددة إلى العرض التقديمي. تحتفظ هذه الطريقة بتنسيق المصدر (عند نسخ تخطيط بين عروض تقديمية مختلفة، يمكن نسخ الماستر الخاص بالتخطيط أيضًا. يتم استخدام السجل الداخلي لتعقب الماسترات المنسوخة تلقائيًا لمنع إنشاء نسخ متعددة من نفس شريحة الماستر.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – تستخدم لإضافة نسخة من شريحة تخطيط محددة إلى عرض تقديمي. سيكون التخطيط الجديد مرتبطًا بالماستر المحدد في العرض التقديمي الوجهة. هذه الخيار مشابه لنسخ أو لصق مع خيار **استخدام تنسيق الوجهة** في Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – تستخدم لإضافة شريحة تخطيط جديدة إلى عرض تقديمي. أنواع التخطيط المدعومة: العنوان، العنوان فقط، فارغ، عنوان وكائن، نص عمودي، عنوان ونص عمودي، جسمان، عنوان القسم، نصان وجسمان، كائن عنوان وتسمية، صورة وتسمية، مخصص. يمكن توليد اسم التخطيط تلقائيًا. تحتوي شريحة التخطيط من النوع SlideLayoutType.Custom على خانات فارغة ولا أشكال. النسخة المماثلة لهذه الطريقة هي IMasterLayoutSlideCollection.Add(SlideLayoutType, string) التي يمكن الوصول إليها من خاصية IMasterSlide.LayoutSlides.
#### **واجهة IMasterLayoutSlideCollection وفصل MasterLayoutSlideCollection**
تمت إضافة واجهة IMasterLayoutSlideCollection وفصل MasterLayoutSlideCollection إلى مساحة أسماء Aspose.Slides. إن فصل MasterLayoutSlideCollection ينفذ واجهة IMasterLayoutSlideCollection.

تمثل واجهة IMasterLayoutSlideCollection مجموعات من جميع شرائح التخطيط لشريحة الماستر المحددة. إنها تمتد واجهة ILayoutSlideCollection بطرق لإضافة، إدراج، إزالة أو نسخ شرائح التخطيط في سياق المجموعات الفردية لشرائح تخطيط الماستر:

``` csharp

 // توقيع الطريقة:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// مثال التعليمات البرمجية الذي يربط نسخة من sourceLayout بـ destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

يمكن استخدام الطريقة لإضافة نسخة من شريحة تخطيط محددة إلى نهاية المجموعة. سيكون التخطيط الجديد مرتبطًا بشريحة الماستر الأم لمجموعة شرائح التخطيط هذه. لذا، هذه مماثلة للنسخ أو اللصق مع خيار **استخدام تنسيق الوجهة** في PowerPoint. النسخة المماثلة لهذه الطريقة هي IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) التي يمكن الوصول إليها من خاصية IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – تستخدم لإدخال نسخة من شريحة تخطيط محددة إلى موضع محدد من المجموعة. سيكون التخطيط الجديد مرتبطًا بشريحة الماستر الأم لمجموعة شرائح التخطيط هذه. لذا، هذه مماثلة للنسخ واللصق مع خيار **استخدام تنسيق الوجهة** في PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – تستخدم لإضافة أو إدراج شريحة تخطيط جديدة. أنواع التخطيط المدعومة: العنوان، العنوان فقط، فارغ، عنوان وكائن، نص عمودي، عنوان ونص عمودي، جسمان، عنوان القسم، نصان وجسمان، كائن عنوان وتسمية، صورة وتسمية، مخصص. يمكن توليد اسم التخطيط تلقائيًا. تحتوي شريحة التخطيط من النوع SlideLayoutType.Custom على خانات فارغة ولا أشكال. النسخة المماثلة لهذه الطريقة هي IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) التي يمكن الوصول إليها من خاصية IPresentation.LayoutSlides.
- void RemoveAt(int index); – تستخدم لإزالة التخطيط عند الفهرس المحدد من المجموعة.
- void Reorder(int index, ILayoutSlide layoutSlide); – تستخدم لتحريك شريحة التخطيط من المجموعة إلى الموضع المحدد.
### **تمت تغيير الطرق والخصائص**
#### **توقيع طريقة Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
توقيع طريقة ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

أصبحت غير صالحة الآن وتم استبدالها بالتوقيع

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

يحدد معلمة allowCloneMissingLayout ما يجب القيام به إذا لم يكن هناك تخطيط مناسب في destMaster للشريحة الجديدة (المنسوخة). التخطيط المناسب هو التخطيط بنفس النوع أو الاسم كالتخطيط الخاص بشريحة المصدر. إذا لم يكن هناك تخطيط مناسب في الماستر المحدد، فسيتم نسخ تخطيط شريحة المصدر (إذا كانت allowCloneMissingLayout تساوي true) أو سيتم رمي PptxEditException (إذا كانت allowCloneMissingLayout تساوي false).

استدعاء الطريقة غير الصالحة مثل

AddClone(sourceSlide, destMaster);

يفترض أن allowCloneMissingLayout تساوي false (أي سيتم رمي PptxEditException إذا لم يكن هناك تخطيط مناسب). يبدو الاستدعاء المماثل من الناحية الوظيفية الذي يستخدم التوقيع الجديد كالتالي:
AddClone(sourceSlide, destMaster, false);

إذا كنت تريد أن يتم نسخ التخطيطات المفقودة تلقائيًا بدلاً من رمي PptxEditException، فإنقل معلمة allowCloneMissingLayout كـ true.

ينطبق الشيء نفسه على طريقة ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

أيضًا أصبحت غير صالحة الآن وتم استبدالها بالتوقيع

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides**
تغير نوع خاصية Aspose.Slides.IMasterSlide.LayoutSlides من ILayoutSlideCollection إلى واجهة IMasterLayoutSlideCollection الجديدة. واجهة IMasterLayoutSlideCollection هي فرع من ILayoutSlideCollection لذلك لا يحتاج الرمز الموجود إلى أي تعديلات.
#### **تغير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides**
تغير نوع خاصية Aspose.Slides.IPresentation.LayoutSlides من ILayoutSlideCollection إلى واجهة IGlobalLayoutSlideCollection الجديدة. واجهة IGlobalLayoutSlideCollection هي فرع من ILayoutSlideCollection لذلك لا يحتاج الرمز الموجود إلى أي تعديلات.