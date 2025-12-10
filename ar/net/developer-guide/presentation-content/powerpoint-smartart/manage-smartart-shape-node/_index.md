---
title: إدارة عقد شكل SmartArt في العروض التقديمية في .NET
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
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides for .NET. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
قدمت Aspose.Slides for .NET أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك رمز العينة التالي في إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

- إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- إضافة عقدة جديدة إلى مجموعة العقد NodeCollection في شكل SmartArt وتعيين النص في TextFrame.
- الآن، إضافة عقدة فرعية إلى عقدة SmartArt التي تم إضافتها حديثًا وتعيين النص في TextFrame.
- حفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AddNodes.pptx");

// التنقل عبر كل شكل داخل الشريحة الأولى
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
في رمز العينة التالي شرحنا كيفية إضافة العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt في موضع معين.

- إنشاء مثيل من الفئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- إضافة شكل SmartArt من نوع StackedList إلى الشريحة التي تم الوصول إليها.
- الوصول إلى العقدة الأولى في الشكل SmartArt المضاف.
- الآن، إضافة العقدة الفرعية للعقدة المحددة في الموضع 2 وتعيين نصها.
- حفظ العرض التقديمي.
```c#
// إنشاء نسخة عرض تقديمي
Presentation pres = new Presentation();

// الوصول إلى شريحة العرض التقديمي
ISlide slide = pres.Slides[0];

// إضافة شكل Smart Art
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// الوصول إلى عقدة SmartArt ذات الفهرس 0
ISmartArtNode node = smart.AllNodes[0];

// إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// إضافة نص
chNode.TextFrame.Text = "Sample Text Added";

// حفظ العرض التقديمي
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **الوصول إلى عقدة SmartArt**
سيساعدك رمز العينة التالي في الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة الشكل SmartArt.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التجول عبر جميع العقد داخل شكل SmartArt.
- الوصول إلى معلومات مثل موضع عقدة SmartArt، المستوى والنص وعرضها.
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
              // الوصول إلى عقدة SmartArt عند الفهرس i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // طباعة معلمات عقدة SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```



## **الوصول إلى عقدة فرعية في SmartArt**
سيساعدك رمز العينة التالي في الوصول إلى العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt.

- إنشاء مثيل من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التجول عبر جميع العقد داخل شكل SmartArt.
- لكل عقدة SmartArt مختارة، التجول عبر جميع العقد الفرعية داخل العقدة المحددة.
- الوصول إلى معلومات مثل موضع العقدة الفرعية، المستوى والنص وعرضها.
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

                // طباعة معلمات العقدة الفرعية في SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **الوصول إلى عقدة فرعية في SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تابعة للعقد المقابلة في شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation`.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- إضافة شكل SmartArt من نوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة ذات الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، الوصول إلى العقدة الفرعية في الموضع 1 للعقدة SmartArt باستخدام طريقة `GetNodeByPosition()`.
- عرض معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```c#
 // إنشاء نسخة من العرض التقديمي
 Presentation pres = new Presentation();

 // الوصول إلى الشريحة الأولى
 ISlide slide = pres.Slides[0];

 // إضافة شكل SmartArt في الشريحة الأولى
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // الوصول إلى عقدة SmartArt ذات الفهرس 0
 ISmartArtNode node = smart.AllNodes[0];

 // الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // طباعة معلمات العقدة الفرعية في SmartArt
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```



## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
- اختيار عقدة SmartArt التي سيتم حذفها.
- الآن، إزالة العقدة المحددة باستخدام طريقة `RemoveNode()` وحفظ العرض التقديمي.
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

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- اختيار عقدة الشكل SmartArt ذات الفهرس 0.
- الآن، التحقق مما إذا كان للعقدة المحددة أكثر من عقدتين فرعيتين.
- الآن، إزالة العقدة في الموضع 1 باستخدام طريقة `RemoveNodeByPosition()`.
- حفظ العرض التقديمي.
```c#
// تحميل العرض التقديمي المطلوب             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// التجول عبر كل شكل داخل الشريحة الأولى
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



## **تعيين موضع مخصص لعقدة فرعية في كائن SmartArt**
الآن تدعم Aspose.Slides for .NET إعداد خصائص X و Y الخاصة بـ SmartArtShape. يوضح مقتطف الشيفرة أدناه كيفية تعيين موضع SmartArtShape مخصص وحجمه ودورانه. يرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب المواقع والأحجام لجميع العقد.
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
في رمز العينة التالي سنستكشف كيفية تحديد العقد المساعدة في مجموعة عقد SmartArt وتغييرها.

- إنشاء مثيل من الفئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الثانية باستخدام فهرستها.
- التجول عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التجول عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقد مساعدة.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- حفظ العرض التقديمي.
```c#
 // إنشاء نسخة عرض تقديمي
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
             // التنقل عبر جميع العقد في شكل SmartArt

             foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
             {
                 String tc = node.TextFrame.Text;
                 // التحقق مما إذا كانت العقدة مساعدة
                 if (node.IsAssistant)
                 {
                     // ضبط العقدة المساعدة إلى false وجعلها عقدة عادية
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
تمكّن Aspose.Slides for .NET من إضافة أشكال SmartArt مخصصة وتعيين تنسيقات تعبئتها. توضح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة باستخدام Aspose.Slides for .NET.

يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة `Presentation`.
- الحصول على مرجع شريحة باستخدام فهرستها.
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



## **إنشاء صورة مصغرة لعقدة فرعية في SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية في SmartArt باتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة `Presentation` التي تمثل ملف PPTX.
2. إضافة SmartArt.
3. الحصول على مرجع لعقدة باستخدام فهرستها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه يولد صورة مصغرة لعقدة فرعية في SmartArt
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


## **الأسئلة المتكررة**

**هل يتم دعم الرسوم المتحركة لـ SmartArt؟**

نعم. يتم التعامل مع SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/net/shape-animation/) (دخول، خروج، تأكيد، مسارات حركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على شريحة إذا كان معرّفه الداخلي غير معروف؟**

عيّن وابحث باستخدام [النص البديل]https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). إعداد AltText مميز على SmartArt يتيح لك العثور عليه برمجةً دون الاعتماد على المعرفات الداخلية.

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. تقوم Aspose.Slides بتصحيح SmartArt بدقة عالية أثناء [تصدير PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط، الألوان، والتأثيرات.

**هل يمكنني استخراج صورة لكامل SmartArt (للعروض أو التقارير)؟**

نعم. يمكنك تصيير شكل SmartArt إلى [تنسيقات نقطية]https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/ أو إلى [SVG]https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/ لإنتاج مخرجات متجهية قابلة للتوسع، ما يجعلها مناسبة للصور المصغرة، التقارير، أو الاستخدام عبر الويب.