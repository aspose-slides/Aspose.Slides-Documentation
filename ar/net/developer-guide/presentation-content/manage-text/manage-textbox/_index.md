---
title: إدارة مربعات النص في العروض التقديمية في .NET
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET يجعل من السهل إنشاء وتحرير واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك أولاً إضافة مربع نص ثم وضع النص داخل مربع النص. 

للسماح لك بإضافة شكل يمكنه احتواء نص، توفر Aspose.Slides for .NET الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 

{{% alert title="ملاحظة" color="warning" %}} 

كما توفر Aspose.Slides الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للسماح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليست كل الأشكال المضافة عبر واجهة `IShape` يمكنها احتواء نص. الأشكال المضافة عبر الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) عادةً ما تحتوي على نص. 

لذلك، عند التعامل مع شكل موجود وتريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)، وهو خاصية تحت `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) في هذه الصفحة. 

{{% /alert %}}

## **إنشاء مربع نص على شريحة**

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة الأولى من خلال فهرستها.  
3. أضف كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) مع تعيين [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) إلى `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` المضاف حديثًا.  
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*  
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`.  

يعرض هذا الكود C#—تنفيذ الخطوات أعلاه—كيفية إضافة نص إلى شريحة:
```c#
 // ينشئ كائن Presentation
 using (Presentation pres = new Presentation())
 {
 
     // يحصل على الشريحة الأولى في العرض التقديمي
     ISlide sld = pres.Slides[0];
 
     // يضيف AutoShape مع تعيين النوع كـ Rectangle
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);
 
     // يضيف TextFrame إلى المستطيل
     ashp.AddTextFrame(" ");
 
     // يصل إلى إطار النص
     ITextFrame txtFrame = ashp.TextFrame;
 
     // ينشئ كائن Paragraph لإطار النص
     IParagraph para = txtFrame.Paragraphs[0];
 
     // ينشئ كائن Portion للفقرة
     IPortion portion = para.Portions[0];
 
     // يعيّن النص
     portion.Text = "Aspose TextBox";
 
     // يحفظ العرض التقديمي على القرص
     pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **التحقق من وجود شكل مربع نص**

توفر Aspose.Slides الخاصية [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) من الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) لتسمح لك بفحص الأشكال وتحديد مربعات النص.

![Text box and shape](istextbox.png)

يعرض هذا الكود C# كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص:
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


لاحظ أنه إذا قمت فقط بإضافة شكل تلقائي باستخدام طريقة `AddAutoShape` من الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/)، فستعيد خاصية `IsTextBox` للقالب القابل للإضافة القيمة `false`. ومع ذلك، بعد إضافة النص إلى الشكل القابل للإضافة باستخدام طريقة `AddTextFrame` أو خاصية `Text`، تعيد خاصية `IsTextBox` القيمة `true`.
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


## **إضافة أعمدة إلى مربع النص**

توفر Aspose.Slides الخاصيتين [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) و[ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) للسماح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص ثم تحديد المسافة بالنقاط بين الأعمدة. 

يعرض هذا الكود C# العملية الموصوفة:
```c#
using (Presentation presentation = new Presentation())
{
	// يحصل على الشريحة الأولى في العرض التقديمي
	ISlide slide = presentation.Slides[0];

	// يضيف AutoShape مع تعيين النوع كـ Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// يضيف TextFrame إلى المستطيل
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// يحصل على تنسيق النص لإطار النص
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// يحدد عدد الأعمدة في TextFrame
	format.ColumnCount = 3;

	// يحدد التباعد بين الأعمدة
	format.ColumnSpacing = 10;

	// يحفظ العرض التقديمي
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **إضافة أعمدة إلى إطار نص**

توفر Aspose.Slides for .NET الخاصية [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) التي تسمح لك بإضافة أعمدة في أطر النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل في إطار النص. 

يعرض هذا الكود C# كيفية إضافة عمود داخل إطار نص:
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

تسمح لك Aspose.Slides بتغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي. 

يعرض هذا الكود C# عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:
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


## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الارتباط. 

1. أنشئ مثيلًا من الفئة `Presentation`.  
2. احصل على مرجع الشريحة الأولى من خلال فهرستها.  
3. أضف كائنًا `AutoShape` مع تعيين `ShapeType` إلى `Rectangle` في موضع محدد على الشريحة واحصل على مرجع كائن AutoShape المضاف حديثًا.  
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي.  
5. أنشئ كائنًا من الفئة `IHyperlinkManager`.  
6. عيّن كائن `IHyperlinkManager` إلى الخاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) المرتبطة بالجزء المفضل من `TextFrame`.  
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض هذا الكود C#—تنفيذ الخطوات أعلاه—كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pptxPresentation = new Presentation();

// يحصل على الشريحة الأولى في العرض التقديمي
ISlide slide = pptxPresentation.Slides[0];

// يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// يحوّل الشكل إلى AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// الوصول إلى الخاصية ITextFrame المرتبطة بـ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// يضيف بعض النص إلى الإطار
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// يضبط الارتباط التشعبي لنص الجزء
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// يحفظ العرض التقديمي بصيغة PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**ما الفرق بين مربع النص وعناصر النائب النصي عند العمل مع الشرائح الرئيسية؟**

يُورث [placeholder](/slides/ar/net/manage-placeholder/) النمط/الموقع من الـ[master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) ويمكن تجاوزه في الـ[layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/)، بينما يُعد مربع النص العادي كائنًا مستقلاً على شريحة معينة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على أطر نص واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) من خلال استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.