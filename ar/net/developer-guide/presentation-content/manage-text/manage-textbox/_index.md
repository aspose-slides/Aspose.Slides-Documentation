---
title: إدارة صناديق النص في العروض التقديمية باستخدام .NET
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET يجعل من السهل إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك أولاً إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. 

لتمكينك من إضافة شكل يمكنه احتواء نص، يقدم Aspose.Slides لـ .NET الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

يوفر Aspose.Slides أيضًا الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) لتمكينك من إضافة أشكال إلى الشرائح. ومع ذلك، لا يمكن لجميع الأشكال المضافة عبر الواجهة `IShape` احتواء نص. عادةً ما تحتوي الأشكال المضافة عبر الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) على نص. 

لذلك، عند التعامل مع شكل موجود تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر الواجهة `IAutoShape`. عندها فقط ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)، وهي خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) في هذه الصفحة. 
{{% /alert %}}

## **إنشاء صندوق نص على الشريحة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. الحصول على إشارة الشريحة الأولى من خلال فهرستها. 
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) مع خاصية [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) محددة كـ `Rectangle` في موضع محدد على الشريحة والحصول على الإشارة للكائن `IAutoShape` المضاف حديثًا. 
4. إضافة خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يظهر لك هذا الكود C#—تنفيذ الخطوات السابقة—كيفية إضافة نص إلى شريحة:
```c#
// ينشئ كائن PresentationEx
using (Presentation pres = new Presentation())
{

    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.Slides[0];

    // يضيف AutoShape بنوع مستطيل
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.AddTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.TextFrame;

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.Paragraphs[0];

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.Portions[0];

    // يحدد النص
    portion.Text = "Aspose TextBox";

    // يحفظ العرض التقديمي إلى القرص
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **التحقق من شكل صندوق النص**

يوفر Aspose.Slides الخاصية [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) من الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)، مما يتيح لك فحص الأشكال وتحديد صناديق النص.

![Text box and shape](istextbox.png)

يظهر لك هذا الكود C# كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص:
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


لاحظ أنه إذا قمت بإضافة شكل تلقائي ببساطة باستخدام طريقة `AddAutoShape` من الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/)، فإن خاصية `IsTextBox` لهذا الشكل ستُعيد `false`. ومع ذلك، بعد إضافة نص إلى الشكل باستخدام طريقة `AddTextFrame` أو خاصية `Text`, ستُعيد خاصية `IsTextBox` القيمة `true`.
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


## **إضافة عمود في صندوق النص**

يوفر Aspose.Slides الخاصيتين [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) و[ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) لتمكينك من إضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص ثم تحديد التباعد بالنقاط بين الأعمدة.

يظهر هذا الكود C# العملية الموصوفة:
```c#
using (Presentation presentation = new Presentation())
{
	// يحصل على الشريحة الأولى في العرض التقديمي
	ISlide slide = presentation.Slides[0];

	// يضيف AutoShape بنوع مستطيل
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// يضيف TextFrame إلى المستطيل
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// يحصل على تنسيق النص لـ TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// يحدد عدد الأعمدة في TextFrame
	format.ColumnCount = 3;

	// يحدد التباعد بين الأعمدة
	format.ColumnSpacing = 10;

	// يحفظ العرض التقديمي
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **إضافة عمود في إطار النص**

يوفر Aspose.Slides لـ .NET الخاصية [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يظهر لك هذا الكود C# كيفية إضافة عمود داخل إطار النص:
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

يتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق النص أو جميع النصوص الموجودة في العرض التقديمي.

يظهر هذا الكود C# عملية يتم فيها تحديث أو تغيير جميع النصوص في عرض تقديمي:
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
                       portion.Text = portion.Text.Replace("years", "months"); //يغير النص
                       portion.PortionFormat.FontBold = NullableBool.True; //يغير التنسيق
                   }
               }
           }
       }
   }
  
   //يحفظ العرض التقديمي المعدل
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **إضافة صندوق نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل صندوق النص. عندما يتم النقر على صندوق النص، يتم توجيه المستخدمين لفتح الارتباط. 

1. إنشاء نسخة من الفئة `Presentation`. 
2. الحصول على إشارة الشريحة الأولى من خلال فهرستها.  
3. إضافة كائن `AutoShape` مع `ShapeType` محدد كـ `Rectangle` في موضع محدد على الشريحة والحصول على إشارة للكائن AutoShape المضاف حديثًا. 
4. إضافة `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من الفئة `IHyperlinkManager`. 
6. تعيين كائن `IHyperlinkManager` إلى الخاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) المرتبطة بالجزء المفضل لديك من `TextFrame`. 
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يظهر لك هذا الكود C#—تنفيذ الخطوات السابقة—كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:
```c#
// يُنشئ كائنًا من الفئة Presentation التي تمثل ملف PPTX
Presentation pptxPresentation = new Presentation();

// يحصل على الشريحة الأولى في العرض التقديمي
ISlide slide = pptxPresentation.Slides[0];

// يضيف كائن AutoShape بنوع Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// يحول الشكل إلى AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// يصل إلى الخاصية ITextFrame المرتبطة بـ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// يضيف نصًا إلى الإطار
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// يضبط الارتباط التشعبي لنص الجزء
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// يحفظ عرض PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**ما الفرق بين صندوق النص وعنصر النص النائب عند العمل مع الشرائح الرئيسية؟**

يُعتمد [placeholder](/slides/ar/net/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) ويمكن تجاوزه في [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني تنفيذ استبدال نص جماعي عبر العرض التقديمي دون تعديل النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستثناء الكائنات المدمجة ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) من خلال استعراض مجموعاتها بشكل منفصل أو تخطي أنواع تلك الكائنات.