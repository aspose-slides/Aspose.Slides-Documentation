---
title: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords:
- SmartArt
- عقدة SmartArt
- عقدة الطفل SmartArt
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "إدارة عقد SmartArt وعقد الطفل في عروض PowerPoint باستخدام C# أو .NET"
---


## **إضافة عقدة SmartArt**
لقد قدمت Aspose.Slides لـ .NET أبسط واجهة برمجة التطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيمكّنك نموذج الكود التالي من إضافة عقدة وعقدة طفل داخل شكل SmartArt.

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArt.
- إضافة عقدة جديدة في مجموعة عقد SmartArt وتعيين النص في TextFrame.
- الآن، أضف عقدة طفل في عقدة SmartArt الجديدة واضبط النص في TextFrame.
- حفظ العرض التقديمي.

```c#
// تحميل العرض التقديمي المرغوب
Presentation pres = new Presentation("AddNodes.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // تحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // إضافة عقدة SmartArt جديدة
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // إضافة نص
        TemNode.TextFrame.Text = "اختبار";

        // إضافة عقدة طفل جديدة في العقدة الأصلية. ستتم إضافتها في نهاية المجموعة
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // إضافة نص
        newNode.TextFrame.Text = "عقدة جديدة مضافة";

    }
}

// حفظ العرض التقديمي
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **إضافة عقدة SmartArt في موضع معين**
في نموذج الكود التالي، شرحنا كيفية إضافة عقد الأطفال المنتمية إلى العقد الخاصة بأشكال SmartArt في موضع معين.

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من نوع StackedList في الشريحة المُعتمَدة.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، أضف عقدة الطفل للعقدة المحددة في الموضع 2 واضبط نصها.
- حفظ العرض التقديمي.

```c#
// إنشاء مثيل للعرض التقديمي
Presentation pres = new Presentation();

// الوصول إلى شريحة العرض التقديمي
ISlide slide = pres.Slides[0];

// إضافة Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// الوصول إلى عقدة SmartArt في الفهرس 0
ISmartArtNode node = smart.AllNodes[0];

// إضافة عقدة طفل جديدة في الموضع 2 في العقدة الأصلية
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// إضافة نص
chNode.TextFrame.Text = "نص عينة مضافة";

// حفظ العرض التقديمي
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **الوصول إلى عقدة SmartArt**
سيساعدك نموذج الكود التالي في الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.

- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.

- التنقل عبر كل شكل داخل الشريحة الأولى.

- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArt.

- التنقل عبر جميع العقد داخل شكل SmartArt.

- الوصول إلى معلومات العرض مثل موضع عقدة SmartArt ومستواها ونصها.

```c#
// تحميل العرض التقديمي المرغوب
Presentation pres = new Presentation("AccessSmartArt.pptx");
  
// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // تحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
  
        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
        // التنقل عبر جميع العقد داخل SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // الوصول إلى عقدة SmartArt في الفهرس i
            Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
            // طباعة معلمات عقدة SmartArt
            string outString = string.Format("i = {0}, النص = {1},  المستوى = {2}, الموضع = {3}", i, node.TextFrame.Text, node.Level, node.Position);
            Console.WriteLine(outString);
        }
    }
}
```

  


## **الوصول إلى عقدة الطفل في SmartArt**
سيساعدك نموذج الكود التالي في الوصول إلى عقد الأطفال المنتمية إلى العقد الخاصة بأشكال SmartArt.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArtEx.
- التنقل عبر جميع العقد داخل شكل SmartArt.
- لكل عقدة من عقد SmartArt المحددة، التنقل عبر جميع عقد الأطفال داخل العقدة المعينة.
- الوصول إلى معلومات العرض مثل موضع عقدة الطفل ومستواها ونصها. 

```c#
// تحميل العرض التقديمي المرغوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // تحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // التنقل عبر جميع العقد داخل SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // الوصول إلى عقدة SmartArt في الفهرس i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // التنقل عبر عقد الأطفال في عقدة SmartArt في الفهرس i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // الوصول إلى عقدة الطفل في عقدة SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // طباعة معلمات عقدة الطفل في SmartArt
                string outString = string.Format("j = {0}, النص = {1},  المستوى = {2}, الموضع = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **الوصول إلى عقدة الطفل في موضع معين**
في هذا المثال، سنتعلم كيفية الوصول إلى عقد الأطفال في موضع معين المنتمية إلى العقد الخاصة بأشكال SmartArt.

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من نوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة في الفهرس 0 لشكل SmartArt المعتمد.
- الآن، الوصول إلى عقدة الطفل في الموضع 1 لعقدة SmartArt المعتمدة باستخدام طريقة GetNodeByPosition().
- الوصول إلى معلومات العرض مثل موضع عقدة الطفل ومستواها ونصها.

```c#
// إنشاء مثيل للعرض التقديمي
Presentation pres = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide slide = pres.Slides[0];

// إضافة شكل SmartArt في الشريحة الأولى
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// الوصول إلى عقدة SmartArt في الفهرس 0
ISmartArtNode node = smart.AllNodes[0];

// الوصول إلى عقدة الطفل في الموضع 1 في العقدة الأصلية
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// طباعة معلمات عقدة الطفل في SmartArt
string outString = string.Format("j = {0}, النص = {1},  المستوى = {2}, الموضع = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArt.
- تحقق مما إذا كانت SmartArt تحتوي على أكثر من 0 عقد.
- تحديد عقدة SmartArt المراد حذفها.
- الآن، إزالة العقدة المحددة باستخدام طريقة RemoveNode() * حفظ العرض التقديمي.

```c#
// تحميل العرض التقديمي المرغوب
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // الوصول إلى عقدة SmartArt في الفهرس 0
                ISmartArtNode node = smart.AllNodes[0];

                // إزالة العقدة المحددة
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // حفظ العرض التقديمي
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **إزالة عقدة SmartArt في موضع معين**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArt.
- تحديد عقدة الشكل SmartArt في الفهرس 0.
- الآن، تحقق مما إذا كانت العقدة SmartArt المحددة تحتوي على أكثر من 2 عقدة أطفال.
- الآن، إزالة العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- حفظ العرض التقديمي.

```c#
// تحميل العرض التقديمي المرغوب             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // تحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // الوصول إلى عقدة SmartArt في الفهرس 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // إزالة عقدة الطفل في الموضع 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// حفظ العرض التقديمي
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **تعيين موضع مخصص لعقدة الطفل في SmartArt**
الآن تدعم Aspose.Slides لـ .NET تعيين خصائص X و Y لشكل SmartArt. يظهر نموذج الكود أدناه كيفية تعيين موضع SmartArtShape مخصص، والحجم، والدوران، ويرجى ملاحظة أن إضافة عقد جديدة تؤدي إلى إعادة حساب المواضع والأحجام لجميع العقد.

```c#
// تحميل العرض التقديمي المرغوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// نقل شكل SmartArt إلى موضع جديد
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// تغيير عرض أشكال SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// تغيير ارتفاع أشكال SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// تغيير دوران أشكال SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **تحقق من عقدة المساعد**
في نموذج الكود التالي، سنحقق كيفية تحديد عقد مساعد في مجموعة عقد SmartArt وتغييرها.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وإذا كان SmartArt، قم بتحويل الشكل المحدد إلى SmartArtEx.
- التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقد مساعد.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- حفظ العرض التقديمي.

```c#
// إنشاء مثيل للعرض التقديمي
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // التنقل عبر جميع العقد الخاصة بشكل SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // تحقق مما إذا كانت العقدة هي عقدة مساعد
                if (node.IsAssistant)
                {
                    // تعيين العقدة المساعدة إلى false وجعلها عقدة عادية
                    node.IsAssistant = false;
                }
            }
        }
    }
    // حفظ العرض التقديمي
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **تعيين تنسيق تعبئة العقدة**
تتيح Aspose.Slides لـ .NET إضافة أشكال SmartArt مخصصة وتعيين تنسيقات تعبئتها. يشرح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة باستخدام Aspose.Slides لـ .NET.

يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع لشريحة باستخدام فهرسها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType الخاص به.
- تعيين FillFormat لعقد شكل SmartArt.
- كتابة العرض التقديمي المعدل كملف PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة
    ISlide slide = presentation.Slides[0];

    // إضافة شكل SmartArt والعقد
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "بعض النص";

    // تعيين لون تعبئة العقدة
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // حفظ العرض التقديمي
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **توليد الصورة المصغرة لعقدة الطفل في SmartArt**
يمكن للمطورين توليد صورة مصغرة لعقدة طفل في SmartArt من خلال اتباع الخطوات أدناه:

1. إنشاء فئة `Presentation` التي تمثل ملف PPTX.
2. إضافة SmartArt.
3. الحصول على مرجع لعقدة باستخدام فهرسها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

ويمثل المثال أدناه توليد صورة مصغرة لعقدة الطفل في SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```