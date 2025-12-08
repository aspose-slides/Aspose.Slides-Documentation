---
title: إدارة مربع نص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث النص
- مربع نص مع رابط تشعبي
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "إدارة مربع نص أو إطار نص في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك أولاً إضافة مربع نص ثم وضع بعض النص داخل مربع النص. 

للسماح لك بإضافة شكل يمكنه احتواء النص، توفر Aspose.Slides for .NET الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) .

{{% alert title="Note" color="warning" %}} 

كما توفر Aspose.Slides الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للسماح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر واجهة `IShape` يمكنها احتواء النص. عادةً ما تحتوي الأشكال التي تُضاف عبر الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) على نص. 

لذلك، عند التعامل مع شكل موجود تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندها سيمكنك العمل مع [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)، وهي خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) في هذه الصفحة. 

{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. احصل على مرجع الشريحة الأولى عبر فهرستها. 
3. أضف كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) مع خاصية [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) مضبوطة على `Rectangle` في موضع محدد على الشريحة واحصل على المرجع للكائن `IAutoShape` المضاف حديثًا. 
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

هذا الكود C#—تنفيذ للخطوات أعلاه—يوضح لك كيفية إضافة نص إلى شريحة:
```c#
// إنشاء كائن PresentationEx
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape مع تعيين النوع على مستطيل
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // إضافة TextFrame إلى المستطيل
    ashp.AddTextFrame(" ");

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.TextFrame;

    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.Paragraphs[0];

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.Portions[0];

    // تعيين النص
    portion.Text = "Aspose TextBox";

    // حفظ العرض التقديمي إلى القرص
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **التحقق من شكل مربع النص**

توفر Aspose.Slides الخاصية [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) من الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ، مما يتيح لك فحص الأشكال وتحديد مربعات النص. 

![مربع النص والشكل](istextbox.png)

هذا الكود C# يوضح لك كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```


لاحظ أنه إذا قمت فقط بإضافة شكل تلقائي باستخدام طريقة `AddAutoShape` من الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) ، فإن خاصية `IsTextBox` لهذا الشكل ستُرجع `false`. ومع ذلك، بعد إضافة نص إلى الشكل باستخدام طريقة `AddTextFrame` أو خاصية `Text`، ستُرجع خاصية `IsTextBox` القيمة `true`. 
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox غير صحيح
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox صحيح

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox غير صحيح
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox صحيح

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox غير صحيح
    shape3.AddTextFrame("");
    // shape3.IsTextBox غير صحيح

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox غير صحيح
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox غير صحيح
}
```


## **إضافة عمود في مربع النص**

توفر Aspose.Slides الخصائص [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) و[ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) للسماح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص ثم تحديد التباعد بالنقاط بين الأعمدة. 

هذا الكود في C# يوضح العملية الموضحة: 
```c#
using (Presentation presentation = new Presentation())
{
	// يحصل على الشريحة الأولى في العرض التقديمي
	ISlide slide = presentation.Slides[0];

	// إضافة AutoShape مع تعيين النوع إلى Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// إضافة TextFrame إلى Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// الحصول على تنسيق النص في TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// تحديد عدد الأعمدة في TextFrame
	format.ColumnCount = 3;

	// تحديد التباعد بين الأعمدة
	format.ColumnSpacing = 10;

	// حفظ العرض التقديمي
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **إضافة عمود في إطار النص**

توفر Aspose.Slides for .NET الخاصية [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل في إطار النص. 

هذا الكود C# يوضح لك كيفية إضافة عمود داخل إطار النص:
```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```


## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي. 

هذا الكود C# يوضح عملية يتم فيها تحديث أو تغيير جميع النصوص في عرض تقديمي:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //يتنقل عبر الفقرات في إطار النص
               {
                   foreach (IPortion portion in paragraph.Portions) //يتنقل عبر كل جزء في الفقرة
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //يغيّر النص
                       portion.PortionFormat.FontBold = NullableBool.True; //يغيّر التنسيق
                   }
               }
           }
       }
   }
  
   //يحفظ العرض التقديمي المعدل
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **إضافة مربع نص مع رابط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يُوجه المستخدمون لفتح الرابط. 

1. إنشاء نسخة من الفئة `Presentation`. 
2. احصل على مرجع الشريحة الأولى عبر فهرستها.  
3. أضف كائن `AutoShape` مع `ShapeType` مضبوطة على `Rectangle` في موضع محدد على الشريحة واحصل على مرجع الكائن AutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من الفئة `IHyperlinkManager`. 
6. عيّن كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) المرتبطة بالجزء المفضل من `TextFrame`. 
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

هذا الكود C#—تنفيذ للخطوات أعلاه—يوضح لك كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:
```c#
// يُنشئ كائن من فئة Presentation تمثل ملف PPTX
Presentation pptxPresentation = new Presentation();

// يحصل على الشريحة الأولى في العرض التقديمي
ISlide slide = pptxPresentation.Slides[0];

// يضيف كائن AutoShape مع تعيين النوع إلى Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// يقوم بتحويل الشكل إلى AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// يصل إلى الخاصية ITextFrame المرتبطة بـ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// يضيف بعض النص إلى الإطار
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// يضبط الارتباط التشعبي لنص الجزء
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// يحفظ عرض PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**ما الفرق بين مربع النص وعلامة النص النائبة عند العمل مع الشرائح الرئيسية؟**

يُورث [placeholder](/slides/ar/net/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) ويمكن تجاوزه في الـ [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/)، بينما يُعد مربع النص العادي كائنًا مستقلاً على شريحة محددة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني تنفيذ استبدال نص جماعي عبر العرض التقديمي دون التأثر بالنص داخل المخططات والجداول وSmartArt؟**

قصر تكرارك على الأشكال التلقائية التي تحتوي على إطارات نص واستبعاد الكائنات المضمنة ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) عبر استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.