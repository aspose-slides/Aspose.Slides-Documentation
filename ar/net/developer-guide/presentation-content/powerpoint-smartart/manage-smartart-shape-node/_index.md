---
title: إدارة عقد شكل SmartArt في العروض التقديمية باستخدام .NET
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/net/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعد
- تنسيق تعبئة
- عقدة العرض
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides لـ .NET. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
قدمت Aspose.Slides for .NET أبسط واجهة برمجة تطبيقات لإدارة الأشكال SmartArt بأبسط طريقة. سيساعدك الكود التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

- إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArt إذا كان كذلك.
- إضافة عقدة جديدة إلى مجموعة العقد NodeCollection في شكل SmartArt وتعيين النص في TextFrame.
- الآن، إضافة عقدة فرعية إلى العقدة SmartArt التي تم إضافتها حديثًا وتعيين النص في TextFrame.
- حفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddNodes.pptx");

// التجول عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // التحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // إضافة عقدة SmartArt جديدة
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // إضافة نص
        TemNode.TextFrame.Text = "Test";

        // إضافة عقدة فرعية جديدة في العقدة الأصلية. سيتم إضافتها في نهاية المجموعة
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // إضافة نص
        newNode.TextFrame.Text = "New Node Added";

    }
}

// حفظ العرض التقديمي
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **إضافة عقدة SmartArt في موضع محدد**
في الكود التالي نشرح كيفية إضافة العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt في موضع معين.

- إنشاء مثال من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- إضافة شكل SmartArt من نوع StackedList إلى الشريحة التي تم الوصول إليها.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، إضافة العقدة الفرعية للعقدة المحددة في الموضع 2 وتعيين نصها.
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

// إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأب
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// إضافة نص
chNode.TextFrame.Text = "Sample Text Added";

// حفظ العرض التقديمي
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الوصول إلى عقدة SmartArt**
سيساعدك الكود التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة الشكل.

- إنشاء مثال من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArt إذا كان كذلك.
- استعراض جميع العقد داخل شكل SmartArt.
- الوصول إلى معلومات مثل موضع عقدة SmartArt، المستوى والنص.
  ```c#
  // تحميل العرض التقديمي المطلوب
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // التجول عبر كل شكل داخل الشريحة الأولى
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // التحقق مما إذا كان الشكل من نوع SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // تحويل الشكل إلى SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // التجول عبر جميع العقد داخل SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // الوصول إلى عقدة SmartArt في الفهرس i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // طباعة معلمات عقدة SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **الوصول إلى العقدة الفرعية في SmartArt**
سيساعدك الكود التالي على الوصول إلى العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt.

- إنشاء مثال من فئة PresentationEx وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArtEx إذا كان كذلك.
- استعراض جميع العقد داخل شكل SmartArt.
- بالنسبة لكل عقدة SmartArt مختارة، استعراض جميع العقد الفرعية داخل العقدة المحددة.
- الوصول إلى معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

// التجول عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // التحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // التجول عبر جميع العقد داخل SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // الوصول إلى عقدة SmartArt في الفهرس i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // التجول عبر العقد الفرعية في عقدة SmartArt في الفهرس i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // الوصول إلى العقدة الفرعية في عقدة SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // طباعة معلمات العقدة الفرعية في SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```


## **الوصول إلى العقدة الفرعية في SmartArt في موضع محدد**
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تخص العقد المقابلة في شكل SmartArt.

- إنشاء مثال من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- إضافة شكل SmartArt من نوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة في الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، الوصول إلى العقدة الفرعية في الموضع 1 للعقدة SmartArt باستخدام الطريقة GetNodeByPosition().
- الوصول إلى معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```c#
 // إنشاء نسخة من العرض التقديمي
 Presentation pres = new Presentation();

 // الوصول إلى الشريحة الأولى
 ISlide slide = pres.Slides[0];

 // إضافة شكل SmartArt في الشريحة الأولى
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // الوصول إلى عقدة SmartArt في الفهرس 0
 ISmartArtNode node = smart.AllNodes[0];

 // الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأم
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // طباعة معلمات العقدة الفرعية في SmartArt
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```


## **إزالة عقدة SmartArt**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء مثال من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArt إذا كان كذلك.
- التحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
- اختيار عقدة SmartArt التي سيتم حذفها.
- الآن، إزالة العقدة المحددة باستخدام طريقة RemoveNode()* حفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // الانتقال عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // التحقق مما إذا كان الشكل من نوع SmartArt
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


## **إزالة عقدة SmartArt في موضع محدد**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

- إنشاء مثال من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArt إذا كان كذلك.
- اختيار عقدة شكل SmartArt في الفهرس 0.
- الآن، التحقق مما إذا كانت العقدة SmartArt المختارة تحتوي على أكثر من عقدتين فرعيتين.
- الآن، إزالة العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- حفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// استعراض كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // التحقق مما إذا كان الشكل من نوع SmartArt
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
                // إزالة العقدة الفرعية في الموضع 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// حفظ العرض التقديمي
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **تعيين موضع مخصص للعقدة الفرعية في SmartArt**
الآن تدعم Aspose.Slides for .NET تعيين خصائص X و Y لشكل SmartArt. يوضح المقتطف التالي كيفية تعيين موضع وحجم ودوران مخصص لشكل SmartArt، يرجى ملاحظة أن إضافة عقد جديدة يتسبب في إعادة حساب مواضع وأحجام جميع العقد.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// نقل شكل SmartArt إلى موقع جديد
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// تغيير عرض شكل SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// تغيير ارتفاع شكل SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// تغيير دوران شكل SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```


## **التحقق من عقدة المساعد**
في الكود التالي سنستكشف كيفية تحديد عقد المساعد في مجموعة عقد SmartArt وتغييرها.

- إنشاء مثال من فئة PresentationEx وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الثانية باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المختار إلى SmartArtEx إذا كان كذلك.
- استعراض جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقد مساعد.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- حفظ العرض التقديمي.
```c#
// إنشاء نسخة من العرض التقديمي
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // التجول عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // التجول عبر جميع العقد في شكل SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // التحقق مما إذا كانت العقدة مساعدة
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
تمكّن Aspose.Slides for .NET من إضافة أشكال SmartArt مخصصة وتعيين تنسيقات التعبئة لها. يشرح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة باستخدام Aspose.Slides for .NET.

يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة `Presentation`.
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة شكل SmartArt بتحديد LayoutType الخاص به.
- تعيين FillFormat لعقد شكل SmartArt.
- كتابة العرض المعدل كملف PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة
    ISlide slide = presentation.Slides[0];

    // إضافة شكل SmartArt والعقد
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

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


## **إنشاء صورة مصغرة للعقدة الفرعية في SmartArt**
يمكن للمطورين إنشاء صورة مصغرة للعقدة الفرعية في SmartArt باتباع الخطوات التالية:

1. إنشاء مثال من فئة `Presentation` يمثل ملف PPTX.
2. إضافة SmartArt.
3. الحصول على مرجع عقدة باستخدام فهرسها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه يُظهر إنشاء صورة مصغرة لعقدة فرعية في SmartArt
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


## **الأسئلة الشائعة**

**هل يتم دعم الرسوم المتحركة في SmartArt؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/net/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني العثور بشكل موثوق على SmartArt محدد في الشريحة إذا كان معرّفه الداخلي غير معروف؟**

استخدم وابحث عبر [النص البديل](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). تعيين AltText مميز على SmartArt يتيح لك العثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض إلى PDF؟**

نعم. تقوم Aspose.Slides بتصrender SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكنني استخراج صورة لكامل SmartArt (للعروض أو التقارير)؟**

نعم. يمكنك تصrender شكل SmartArt إلى [تنسيقات نقطية](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو إلى [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) لإخراج متجه قابل للتوسيع، مما يجعله مناسبًا للصور المصغرة، التقارير أو الاستخدام على الويب.