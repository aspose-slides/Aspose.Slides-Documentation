---
title: إدارة صناديق النص في العروض التقديمية باستخدام .NET
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords:
- صندوق النص
- إطار النص
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
description: "يُسهل Aspose.Slides for .NET إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint و OpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة صندوق نص أولاً ثم وضع بعض النص داخل صندوق النص. 

للسماح لك بإضافة شكل يمكنه احتواء النص، توفر Aspose.Slides for .NET واجهة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape) لتتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليست جميع الأشكال المضافة عبر واجهة `IShape` قادرة على احتواء النص. عادةً ما تحتوي الأشكال المضافة عبر واجهة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape) على نص. 

لذلك، عند التعامل مع شكل موجود ترغب في إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندئذٍ ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/properties/textframe)، وهي خاصية تابعة لـ `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/ar/net/manage-textbox/#update-text) في هذه الصفحة. 

{{% /alert %}}

## **إنشاء صندوق نص على شريحة**

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation). 
2. احصل على مرجع الشريحة الأولى من خلال فهرسها. 
3. أضف كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape) مع ضبط [ShapeType](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/properties/shapetype) على `Rectangle` في موضع محدد على الشريحة واحصل على المرجع للكائن `IAutoShape` المضاف حديثًا. 
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

هذا الكود C#—تنفيذ للخطوات أعلاه—يظهر لك كيفية إضافة نص إلى شريحة:

```c#
using Aspose.Slides;

// ينشئ كائن PresentationEx
using (Presentation pres = new Presentation())
{

    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.Slides[0];

    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى الـ Rectangle
    ashp.AddTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.TextFrame;

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.Paragraphs[0];

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.Portions[0];

    // يضبط النص
    portion.Text = "Aspose TextBox";

    // يحفظ العرض التقديمي على القرص
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **التحقق من شكل صندوق النص**

توفر Aspose.Slides الخاصية [IsTextBox](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/istextbox/) من واجهة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) لتسمح لك بفحص الأشكال وتحديد صناديق النص.

![صندوق نص وشكل](istextbox.png)

هذا الكود C# يوضح لك كيفية التحقق ما إذا تم إنشاء الشكل كصندوق نص: 

```c#
using Aspose.Slides;

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

لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `AddAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/)، ستُعيد خاصية `IsTextBox` للقالب التلقائي القيمة `false`. ومع ذلك، بعد إضافة نص إلى القالب التلقائي باستخدام طريقة `AddTextFrame` أو خاصية `Text`، ستُعيد خاصية `IsTextBox` القيمة `true`.

```cs
using Aspose.Slides;

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

## **العثور على الشكل الذي يمتلك إطار نص**

في كود معالجة النصوص العامة، قد تستلم كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) دون معرفة الشكل الذي يحتويه مسبقًا. استخدم خاصية [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/) للعودة إلى [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) المالكة. 

بالنسبة لإطار نص ينتمي إلى [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) أو أي شكل آخر يحتوي على نص، تُحدد خاصية [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/) وتكون خاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) ذات قيمة `null`. كلا الخصيصين هما خصائص تنقل للقراءة فقط، لذا فإن قراءتهما لا يغيّر الملكية. تحقق دائمًا من أن القيمة المرتجعة ليست `null` قبل الوصول إلى الشكل. 

لمثال كامل يحدد مالكي الشكل وخلايا الجداول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، انظر إلى [Search and Replace Text](/slides/ar/net/search-and-replace-text/). 

## **إضافة أعمدة إلى صندوق النص**

توفر Aspose.Slides الخصائص [ColumnCount](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/columncount) و[ColumnSpacing](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/properties/columnspacing) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat)) لتسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص ثم تحديد التباعد بين الأعمدة بالنقاط. 

هذا الكود C# يوضح العملية الموصوفة: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// يحصل على الشريحة الأولى في العرض التقديمي
	ISlide slide = presentation.Slides[0];

	// يضيف AutoShape مع تعيين النوع كـ Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// يضيف TextFrame إلى الـ Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// يحصل على تنسيق النص لإطار النص
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// يحدد عدد الأعمدة في إطار النص
	format.ColumnCount = 3;

	// يحدد التباعد بين الأعمدة
	format.ColumnSpacing = 10;

	// يحفظ العرض التقديمي
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides for .NET خاصية [ColumnCount](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/columncount) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل في إطار النص. 

هذا الكود C# يوضح لك كيفية إضافة عمود داخل إطار نص:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق نص أو جميع النصوص الموجودة في عرض تقديمي. 

هذا الكود C# يُظهر عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //يتحقق ما إذا كان الشكل يدعم إطار النص (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //يتنقل عبر الفقرات في إطار النص
               {
                   foreach (IPortion portion in paragraph.Portions) //يتنقل عبر كل قطعة في الفقرة
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //يُغيّر النص
                       portion.PortionFormat.FontBold = NullableBool.True; //يُغيّر التنسيق
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

يمكنك إدراج ارتباط داخل صندوق نص. عند النقر على صندوق النص، يتم توجيه المستخدمين لفتح الارتباط. 

1. أنشئ مثيلًا من الفئة `Presentation`. 
2. احصل على مرجع الشريحة الأولى من خلال فهرسها.  
3. أضف كائن `AutoShape` مع ضبط `ShapeType` على `Rectangle` في موضع محدد على الشريحة واحصل على مرجع كائن AutoShape المضاف حديثًا. 
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. أنشئ كائنًا من الفئة `IHyperlinkManager`. 
6. عيّن كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/properties/hyperlinkclick) المرتبطة بالجزء المفضل من `TextFrame`. 
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

هذا الكود C#—تنفيذ للخطوات أعلاه—يظهر لك كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:

```c#
using Aspose.Slides;

// ينشئ كائنًا من فئة Presentation تمثل ملف PPTX
Presentation pptxPresentation = new Presentation();

// يحصل على الشريحة الأولى في العرض التقديمي
ISlide slide = pptxPresentation.Slides[0];

// يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// يحول الشكل إلى AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// يضيف نصًا إلى الإطار
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// يحدد الارتباط التشعبي لنص الجزء
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// يحفظ عرض PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**ما الفرق بين صندوق النص وعلامة العنصر النائب للنص عند العمل مع الشرائح الرئيسية؟**

العنصر النائب [placeholder](/slides/ar/net/manage-placeholder/) يرث النمط/الموقع من [master](https://reference.aspose.com/slides/ar/net/aspose.slides/masterslide/) ويمكن تجاوزها في [layouts](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نص جماعي عبر العرض التقديمي دون المساس بالنص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نص وتستثني الكائنات المضمنة ([charts](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/ar/net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartart/)) عن طريق استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.