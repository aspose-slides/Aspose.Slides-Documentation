---
title: إدارة مربع النص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords: "مربع نص, إطار نص, إضافة مربع نص, مربع نص مع ارتباط تشعبي, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة مربع نص أو إطار نص إلى عروض PowerPoint التقديمية في C# أو .NET"
---

النصوص على الشرائح عادةً ما توجد في مربعات نص أو أشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص أولاً ثم وضع بعض النصوص داخل مربع النص.

للسماح لك بإضافة شكل يمكنه الاحتفاظ بالنص، توفر Aspose.Slides for .NET واجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).

{{% alert title="ملحوظة" color="warning" %}}

توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للسماح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليست جميع الأشكال المضافة من خلال واجهة `IShape` يمكنها الاحتفاظ بالنص. الأشكل المضافة من خلال واجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) عادةً ما تحتوي على نص.

لذلك، عند التعامل مع شكل موجود تريد إضافة نص له، قد ترغب في التحقق والتأكيد أنه تم تحويله من خلال واجهة `IAutoShape`. فقط حينها ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) ، وهي خاصية تحت `IAutoShape`. راجع قسم [تحديث النص](https://docs.aspose.com/slides/net/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة الأولى من خلال فهرسها.
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) مع [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) تم تعيينه كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع لكائن `IAutoShape` المضاف حديثًا.
4. إضافة خاصية `TextFrame` إلى الكائن `IAutoShape` التي ستحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، كتابة ملف PPTX من خلال كائن `Presentation`.

توضح هذه الشيفرة بلغة C#—تنفيذ الخطوات المذكورة أعلاه—كيفية إضافة نص إلى شريحة:

```c#
// يهيئ PresentationEx
using (Presentation pres = new Presentation())
{

    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.Slides[0];

    // يضيف AutoShape بنوع تم تعيينه كـ Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى Rectangle
    ashp.AddTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.TextFrame;

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.Paragraphs[0];

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.Portions[0];

    // يحدد النص
    portion.Text = "Aspose TextBox";

    // يحفظ العرض التقديمي على القرص
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **التحقق من شكل مربع النص**

توفر Aspose.Slides خاصية [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (من فئة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)) للسماح لك بفحص الأشكال والعثور على مربعات النص.

![مربع النص والشكل](istextbox.png)

توضح هذه الشيفرة بلغة C# كيفية التحقق مما إذا تم إنشاء شكل كمربع نص:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "الشكل هو مربع نص" : "الشكل ليس مربع نص");
        }
    });
}
```

## **إضافة عمود في مربع النص**

توفر Aspose.Slides خاصيات [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) و [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) للسماح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص ثم تحديد المسافة بالنقاط بين الأعمدة.

توضح هذه الشيفرة بلغة C# العملية الموضحة:

```c#
using (Presentation presentation = new Presentation())
{
	// يحصل على الشريحة الأولى في العرض التقديمي
	ISlide slide = presentation.Slides[0];

	// يضيف AutoShape بنوع تم تعيينه كـ Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// يضيف TextFrame إلى Rectangle
	aShape.AddTextFrame("جميع هذه الأعمدة مقيدة لتكون داخل حاوية نص واحدة -- " +
	"يمكنك إضافة أو حذف نص وسيتم تعديل النص الجديد أو المتبقي " +
	"لتدفق داخل الحاوية. لا يمكنك الحصول على تدفق النص من حاوية واحدة إلى أخرى -- " +
	"كما أخبرناك، خيارات الأعمدة للنص في PowerPoint محدودة!");

	// يحصل على تنسيق النص لإطار النص
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// يحدد عدد الأعمدة في TextFrame
	format.ColumnCount = 3;

	// يحدد المسافة بين الأعمدة
	format.ColumnSpacing = 10;

	// يحفظ العرض التقديمي
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **إضافة عمود في إطار النص**
توفر Aspose.Slides for .NET خاصية [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

توضح هذه الشيفرة بلغة C# كيفية إضافة عمود داخل إطار النص:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "جميع هذه الأعمدة مُجبرة على البقاء داخل حاوية نص واحدة -- " +
                                "يمكنك إضافة أو حذف نص - وسيتم تعديل النص الجديد أو المتبقي تلقائيًا " +
                                "للبقاء داخل الحاوية. لا يمكنك الحصول على تدفق النص من حاوية واحدة " +
                                "إلى أخرى، رغم ذلك -- لأن خيارات الأعمدة للنص في PowerPoint محدودة!";
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

تسمح Aspose.Slides لك بتغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

توضح هذه الشيفرة بلغة C# عملية يقوم فيها بتحديث أو تغيير جميع النصوص في عرض تقديمي:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // يتكرر عبر الفقرات في إطار النص
               {
                   foreach (IPortion portion in paragraph.Portions) // يتكرر عبر كل جزء في الفقرة
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // يغير النص
                       portion.PortionFormat.FontBold = NullableBool.True; // يغير التنسيق
                   }
               }
           }
       }
   }

   // يحفظ العرض التقديمي المعدل
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **إضافة مربع نص مع ارتباط تشعبي**

يمكنك إدراج ارتباط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الارتباط.

1. إنشاء مثيل من فئة `Presentation`.
2. الحصول على مرجع الشريحة الأولى من خلال فهرسها.
3. إضافة كائن `AutoShape` مع `ShapeType` تم تعيينه كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع للكائن AutoShape المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء مثيل من فئة `IHyperlinkManager`.
6. تعيين كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) المرتبطة بجزء النص المفضل لديك من `TextFrame`.
7. أخيرًا، كتابة ملف PPTX من خلال كائن `Presentation`.

توضح هذه الشيفرة بلغة C#—تنفيذ الخطوات المذكورة أعلاه—كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:

```c#
// يهيئ فئة Presentation تمثل PPTX
Presentation pptxPresentation = new Presentation();

// يحصل على الشريحة الأولى في العرض التقديمي
ISlide slide = pptxPresentation.Slides[0];

// يضيف كائن AutoShape بنوع تم تعيينه كـ Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// يحول الشكل إلى AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// يضيف بعض النصوص إلى إطار
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// يحدد الارتباط للجزء النصي
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// يحفظ عرض PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```