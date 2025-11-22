---
title: إدارة عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/net/manage-smartart-shape-node/
keywords:
- SmartArt
- عقدة SmartArt
- عقدة فرعية SmartArt
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "إدارة عقد SmartArt والعقد الفرعية في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **إضافة عقدة SmartArt**
Aspose.Slides for .NET قدَّمت أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك الشيفرة المثال التالية على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- أضف عقدة جديدة إلى مجموعة العقد NodeCollection في شكل SmartArt وقم بتعيين النص في TextFrame.
- الآن، أضف عقدة فرعية إلى العقدة SmartArt المضافة حديثًا وقم بتعيين النص في TextFrame.
- احفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddNodes.pptx");

// التنقل عبر جميع الأشكال داخل الشريحة الأولى
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
في الشيفرة المثال التالية شرحنا كيفية إضافة العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt في موضع معين.

- إنشاء نسخة من الفئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من النوع StackedList إلى الشريحة التي تم الوصول إليها.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، أضف العقدة الفرعية للعقدة المحددة في الموضع 2 وقم بتعيين نصها.
- احفظ العرض التقديمي.
```c#
// إنشاء مثيل عرض تقديمي
Presentation pres = new Presentation();

// الوصول إلى شريحة العرض التقديمي
ISlide slide = pres.Slides[0];

// إضافة Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// الوصول إلى عقدة SmartArt في الفهرس 0
ISmartArtNode node = smart.AllNodes[0];

// إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// إضافة نص
chNode.TextFrame.Text = "Sample Text Added";

// حفظ العرض التقديمي
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الوصول إلى عقدة SmartArt**
ستساعدك الشيفرة المثال التالية على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType للـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عندما يتم إضافة شكل SmartArt.

- إنشاء نسخة من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التنقل عبر جميع العقود داخل شكل SmartArt.
- الوصول إلى وعرض معلومات مثل موضع عقدة SmartArt ومستوى العقدة والنص.
  ```c#
  // تحميل العرض التقديمي المطلوب
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // التنقل عبر جميع الأشكال داخل الشريحة الأولى
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // التحقق مما إذا كان الشكل من نوع SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // تحويل الشكل إلى SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // التنقل عبر جميع العقد داخل SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // الوصول إلى عقدة SmartArt عند الفهرس i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // طباعة معلمات عقدة SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **الوصول إلى العقدة الفرعية SmartArt**
ستساعدك الشيفرة المثال التالية على الوصول إلى العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt.

- إنشاء نسخة من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التنقل عبر جميع العقود داخل شكل SmartArt.
- لكل عقدة SmartArt مختارة، التنقل عبر جميع العقد الفرعية داخل تلك العقدة المحددة.
- الوصول إلى وعرض معلومات مثل موضع العقدة الفرعية ومستوى العقدة والنص.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // التحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // التنقل عبر جميع العقد داخل SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // الوصول إلى عقدة SmartArt عند الفهرس i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // التنقل عبر العقد الفرعية في عقدة SmartArt عند الفهرس i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // الوصول إلى العقدة الفرعية في عقدة SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // طباعة معلمات العقدة الفرعية لـ SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```


## **الوصول إلى العقدة الفرعية SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تتبع للعقد المقابلة في شكل SmartArt.

- إنشاء نسخة من الفئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من النوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة عند الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، وصول إلى العقدة الفرعية في الموضع 1 لعقدة SmartArt التي تم الوصول إليها باستخدام طريقة GetNodeByPosition().
- الوصول إلى وعرض معلومات مثل موضع العقدة الفرعية ومستوى العقدة والنص.
```c#
 // إنشاء نسخة من العرض التقديمي
 Presentation pres = new Presentation();

 // الوصول إلى الشريحة الأولى
 ISlide slide = pres.Slides[0];

 // إضافة شكل SmartArt في الشريحة الأولى
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // الوصول إلى عقدة SmartArt في الفهرس 0
 ISmartArtNode node = smart.AllNodes[0];

 // الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // طباعة معلمات العقدة الفرعية لـ SmartArt
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```


## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء نسخة من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- تحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
- اختر عقدة SmartArt التي سيتم حذفها.
- الآن، احذف العقدة المحددة باستخدام طريقة RemoveNode()* احفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // الوصول إلى عقدة SmartArt عند الفهرس 0
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
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

- إنشاء نسخة من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- اختر عقدة شكل SmartArt عند الفهرس 0.
- الآن، تحقق مما إذا كانت عقدة SmartArt المحددة تحتوي على أكثر من عقدتين فرعيتين.
- الآن، احذف العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- احفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // التحقق مما إذا كان الشكل من نوع SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // تحويل الشكل إلى SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // الوصول إلى عقدة SmartArt عند الفهرس 0
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
الآن تدعم Aspose.Slides for .NET تعيين خصائص X و Y لشكل SmartArtShape. يوضح المقتطف البرمجي أدناه كيفية تعيين موضع مخصص وحجم ودوران SmartArtShape، يرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب مواضع وأحجام جميع العقد.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// تحريك شكل SmartArt إلى موضع جديد
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
في الشيفرة المثال التالية سنستكشف كيفية التعرف على عقد المساعد في مجموعة عقد SmartArt وتعديلها.

- إنشاء نسخة من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- تحقق مما إذا كان الشكل من نوع SmartArt وحوِّل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقدًا مساعدة.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- احفظ العرض التقديمي.
```c#
// إنشاء مثيل للعرض التقديمي
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // التنقل عبر جميع العقد داخل شكل SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // التحقق مما إذا كانت العقدة عقدة مساعدة
                if (node.IsAssistant)
                {
                    // تعيين عقدة المساعد إلى false وجعلها عقدة عادية
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
تمكّن Aspose.Slides for .NET من إضافة أشكال SmartArt مخصصة وتعيين تنسيقات تعبئتها. يوضح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة الخاص بها باستخدام Aspose.Slides for .NET.

يرجى اتباع الخطوات التالية:
- إنشاء نسخة من الفئة `Presentation`.
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt عن طريق ضبط خاصية LayoutType.
- تعيين FillFormat لعقد شكل SmartArt.
- حفظ العرض التقديمي المعدل كملف PPTX.
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


## **إنشاء صورة مصغرة للعقدة الفرعية SmartArt**
يمكن للمطورين إنشاء صورة مصغرة للعقدة الفرعية في SmartArt باتباع الخطوات التالية:
1. إنشاء نسخة من الفئة `Presentation` التي تمثل ملف PPTX.
1. إضافة SmartArt.
1. الحصول على مرجع العقدة باستخدام الفهرس الخاص بها
1. الحصول على صورة المصغرة.
1. حفظ صورة المصغرة بأي صيغة صورة مرغوبة.
المثال أدناه يولد صورة مصغرة لعقدة SmartArt الفرعية
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


## **FAQ**

**هل تدعم الرسوم المتحركة لـ SmartArt؟**

نعم. يتم التعامل مع SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/net/shape-animation/) (دخول، خروج، تأكيد، مسارات حركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt محدد على شريحة بثقة إذا كان معرفه الداخلي غير معروف؟**

قم بالتعيين والبحث باستخدام [النص البديل](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). يسمح تعيين AltText مميز على SmartArt بالعثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. تقوم Aspose.Slides بعرض SmartArt بجودة بصرية عالية أثناء [تصدير PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكنني استخراج صورة للـ SmartArt بالكامل (للمعاينات أو التقارير)؟**

نعم. يمكنك تحويل شكل SmartArt إلى [صيغ نقطية](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو إلى [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) لإنتاج متجه قابل للتكبير، مما يجعله مناسبًا للصور المصغرة، التقارير، أو الاستخدام على الويب.