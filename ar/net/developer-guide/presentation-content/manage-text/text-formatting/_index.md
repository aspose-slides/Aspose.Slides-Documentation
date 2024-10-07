---
title: تنسيق النص
linktitle: تنسيق النص
type: docs
weight: 50
url: /net/text-formatting/
keywords:
- تمييز النص
- تعبير منتظم
- محاذاة فقرات النص
- شفافية النص
- خصائص خط الفقرة
- عائلة الخط
- دوران النص
- دوران الزاوية المخصصة
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- النمط الافتراضي للنص
- C#
- Aspose.Slides لـ .NET
description: "إدارة وتعديل النص وخصائص إطار النص في C#"
---

## نظرة عامة

تصف هذه المقالة كيفية **العمل مع تنسيق نص عرض PowerPoint باستخدام C#** مثل تمييز النص، تطبيق تعبير منتظم، محاذاة فقرات النص، ضبط شفافية النص، تغيير خصائص خط الفقرة، استخدام عائلات الخطوط، ضبط دوران النص، تخصيص دوران الزاوية، إدارة إطار النص، ضبط تباعد الأسطر، استخدام خاصية الملاءمة التلقائية، ضبط مرساة إطار النص، تغيير تبويب النص. تغطي المقالة هذه المواضيع.

## **تمييز النص**
تم إضافة طريقة HighlightText جديدة إلى واجهة ITextFrame وclass TextFrame.

يسمح بتمييز جزء من النص بلون الخلفية باستخدام عينة نص، مشابهًا لأداة لون تمييز النص في PowerPoint 2019.

1. قم بإنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) مع ملف الإدخال.
   - يمكن أن يكون ملف الإدخال PPT، PPTX، ODP، إلخ.
3. الوصول إلى الشريحة باستخدام مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)
4. الوصول إلى الشكل باستخدام مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) كـ [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. تمييز النص باستخدام طريقة [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext).
6. احفظ العرض بالتنسيق المطلوب، أي PPT، PPTX أو ODP، إلخ.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // تمييز جميع كلمات 'مهم'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // تمييز جميع وقوعات 'the' المنفصلة
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

تقدم Aspose خدمة [تحرير PowerPoint مجانية على الإنترنت](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **تمييز النص باستخدام تعبير منتظم**
تمت إضافة طريقة HighlightRegex جديدة إلى واجهة ITextFrame وclass TextFrame.

يسمح بتمييز جزء من النص بلون الخلفية باستخدام regex، مشابهًا لأداة لون تمييز النص في PowerPoint 2019.


توضح المقتطفات البرمجية أدناه كيفية استخدام هذه الميزة:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // تمييز جميع الكلمات التي تحتوي على 10 رموز أو أكثر
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **تعيين لون خلفية النص**

تتيح Aspose.Slides لك تحديد اللون المفضل لديك لخلفية النص.

يوضح هذا الكود C# كيفية تعيين لون الخلفية لنص كامل: 

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("أسود");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" أحمر ");
    
    var portion3 = new Portion("أسود");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

هذا الكود C# يوضح لك كيفية تعيين لون الخلفية لجزء فقط من النص:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("أسود");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" أحمر ");
    
    var portion3 = new Portion("أسود");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("أحمر"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **محاذاة فقرات النص**

يعتبر تنسيق النص أحد العناصر الرئيسية أثناء إنشاء أي نوع من الوثائق أو العروض التقديمية. نعلم أن Aspose.Slides لـ .NET تدعم إضافة نص إلى الشرائح ولكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في شريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ .NET :

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى أشكال العناصر النائبة الموجودة في الشريحة وتحويلها إلى AutoShape.
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من TextFrame المعرض بواسطة AutoShape.
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو المنتصف أو تبريرها.
6. كتابة العرض المعدل كملف PPTX.

تم تنفيذ الخطوات أعلاه أدناه.

```c#
// إنشاء كائن Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // تغيير النص في كلا العنصرين 
    tf1.Text = "محاذاة مركزية بواسطة Aspose";
    tf2.Text = "محاذاة مركزية بواسطة Aspose";

    // الحصول على الفقرة الأولى من العنصرين النائبين
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // محاذاة فقرة النص إلى المنتصف
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // كتابة العرض كملف PPTX
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **تعيين الشفافية للنص**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ .NET. من أجل تعيين الشفافية على النص. يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع لشريحة.
3. تعيين لون الظل
4. كتابة العرض كملف PPTX.

تم تنفيذ الخطوات أعلاه أدناه.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - الشفافية هي: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // تعيين الشفافية إلى صفر بالمئة
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **تعيين تباعد الأحرف للنص**

تتيح Aspose.Slides لك تعيين المسافة بين الحروف في مربع نص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لخط أو كتلة نصية عن طريق توسيع أو تقليل المسافة بين الأحرف.

يوضح هذا الكود C# كيف يمكنك توسيع المسافة لخط واحد من النص وتقليل المسافة لخط آخر:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // توسيع
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // تقليل

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **إدارة خصائص خط الفقرة**

تحتوي العروض التقديمية عادةً على كل من النصوص والصور. يمكن تنسيق النص بطرق متنوعة، إما لتسليط الضوء على أقسام وكلمات محددة، أو للامتثال للأساليب المؤسسية. يساعد تنسيق النص المستخدمين على تغيير الشكل والمظهر لمحتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ .NET لتكوين خصائص خط الفقرات النص على الشرائح. لإدارة خصائص خط فقرة باستخدام Aspose.Slides لـ .NET :

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. الوصول إلى أشكال العنصر النائب في الشريحة وتحويلها إلى AutoShape.
4. الحصول على الفقرة من TextFrame المعرض بواسطة AutoShape.
5. تبرير الفقرة.
6. الوصول إلى جزء نص فقرة.
7. تعريف الخط باستخدام FontData وتعيين الخط لجزء النص وفقًا لذلك.
   1. تعيين الخط كعريض.
   1. تعيين الخط كإيطالي.
8. تعيين لون الخط باستخدام FillFormat المعروض بواسطة كائن Portion.
9. كتابة العرض المعدل كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

تم تنفيذ الخطوات أعلاه أدناه. يأخذ عرضًا غير مزخرف ويدرج تنسيقات الخطوط على واحدة من الشرائح.

```c#
// إنشاء كائن Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // الوصول إلى الشريحة باستخدام موضعها
    ISlide slide = pres.Slides[0];

    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلها إلى AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // الوصول إلى الفقرة الأولى
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // الوصول إلى الجزء الأول
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // تعريف خطوط جديدة
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // تعيين الخطوط الجديدة للجزء
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // تعيين الخط كعريض
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // تعيين الخط كإيطالي
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // تعيين لون الخط
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // كتابة PPTX إلى القرص
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **إدارة عائلة الخط للنص**
يستخدم الجزء للاحتفاظ بالنص الذي له نمط تنسيق مشابه في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ .NET لإنشاء مربع نص ببعض النص ثم تعريف خط معين، وخصائص أخرى مختلفة من فئة عائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص بداخله:

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. إضافة AutoShape من نوع مستطيل إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ AutoShape.
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ TextFrame.
8. تحديد الخط الذي سيتم استخدامه للجزء.
9. تحديد خصائص خط أخرى مثل العريض، الإيطالي، والتسطير، اللون والارتفاع باستخدام الخصائص المناسبة كما هو معروض بواسطة كائن Portion.
10. كتابة العرض المعدل كملف PPTX.

تم تنفيذ الخطوات أعلاه أدناه.

```c#
// إنشاء Presentation
using (Presentation presentation = new Presentation())
{
   
    // الحصول على الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.FillFormat.FillType = FillType.NoFill;

    // الوصول إلى TextFrame المرتبط بـ AutoShape
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "مربع نص Aspose";

    // الوصول إلى الجزء المرتبط بـ TextFrame
    IPortion port = tf.Paragraphs[0].Portions[0];

    // تعيين الخط للجزء
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // تعيين خاصية العريض للخط
    port.PortionFormat.FontBold = NullableBool.True;

    // تعيين خاصية الإيطالي للخط
    port.PortionFormat.FontItalic = NullableBool.True;

    // تعيين خاصية التسطير للخط
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // تعيين ارتفاع الخط
    port.PortionFormat.FontHeight = 25;

    // تعيين لون الخط
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // كتابة العرض إلى القرص 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين حجم الخط للنص**

تتيح Aspose.Slides لك اختيار حجم الخط المفضل لديك للنص الموجود في فقرة والنصوص الأخرى التي قد تضاف إلى الفقرة لاحقًا.

يوضح هذا C# كيفية تعيين حجم الخط للنص الموجود في فقرة:

```c#
var presentation = new Presentation("example.pptx");

// يحصل على الشكل الأول، على سبيل المثال.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // يحصل على الفقرة الأولى، على سبيل المثال.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين الحجم الافتراضي للخط إلى 20 pt لجميع أجزاء النص في الفقرة. 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // تعيين حجم الخط إلى 20 pt للجزء الحالي من النص في الفقرة. 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **تعيين دوران النص**

تتيح Aspose.Slides لـ .NET للمطورين تدوير النص. يمكن تعيين النص ليظهر كأفقي، عمودي، عمودي 270، عمودي WordArt، عمودي EastAsian، عمودي Mongolian أو عمودي WordArt من اليمين إلى اليسار. لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تدوير النص.
6. حفظ الملف على القرص.

```c#
// إنشاء كائن من Presentation class
Presentation presentation = new Presentation();

// الحصول على الشريحة الأولى 
ISlide slide = presentation.Slides[0];

// إضافة AutoShape من نوع مستطيل
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// إضافة TextFrame إلى المستطيل
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// الوصول إلى إطار النص
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// إنشاء كائن Paragraph لإطار النص
IParagraph para = txtFrame.Paragraphs[0];

// إنشاء كائن Portion للفقرة
IPortion portion = para.Portions[0];
portion.Text = "ثور بني سريع يقفز فوق الكلب الكسول. ثور بني سريع يقفز فوق الكلب الكسول.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// حفظ العرض
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **تعيين زاوية دوران مخصصة لـ TextFrame**
تدعم Aspose.Slides لـ .NET الآن، تعيين زاوية دوران مخصصة لـ textframe. في هذا الموضوع، سنرى مع المثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تم إضافة خاصية RotationAngle جديدة إلى الواجهات IChartTextBlockFormat وITextFrameFormat، مما يسمح بتعيين زاوية الدوران المخصصة لـ textframe. من أجل تعيين خاصية RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. إضافة مخطط على الشريحة.
3. تعيين خاصية RotationAngle.
4. كتابة العرض كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.

```c#
// إنشاء كائن من Presentation class
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("عنوان مخصص").TextFrameFormat.RotationAngle = -30;

// حفظ العرض
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **تباعد الأسطر للفقرات**
توفر Aspose.Slides خصائص ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter)، [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore)، و[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) تحت فئة [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) التي تسمح لك بإدارة تباعد الأسطر لفقرات محددة. يتم استخدام الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد الأسطر لفقرة معينة كنسبة مئوية، استخدم قيمة إيجابية. 
* لتحديد تباعد الأسطر لفقرة معينة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد خط بحجم 16 نقطة على فقرة من خلال تعيين خاصية `SpaceBefore` إلى -16.

هذا هو كيف تحدد تباعد الأسطر لفقرة محددة:

1. تحميل عرض يحتوي على AutoShape وبعض النص فيه.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض.

يوضح هذا الكود C# كيفية تحديد تباعد الأسطر لفقرة:

```c#
// إنشاء كائن من Presentation class
Presentation presentation = new Presentation("Fonts.pptx");

// الحصول على مرجع الشريحة من خلال فهرسها
ISlide sld = presentation.Slides[0];

// الوصول إلى TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// الوصول إلى الفقرة
IParagraph para1 = tf1.Paragraphs[0];

// تعيين خصائص الفقرة
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// حفظ العرض
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع، سوف نستكشف الخصائص المختلفة لتنسيق إطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، ومرساة النص، وتدوير النص في العرض التقديمي. تتيح Aspose.Slides لـ .NET للمطورين تعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى عادي أو شكل. إذا تم تعيينه إلى عادي، فسيبقى الشكل كما هو بينما سيتم ضبط النص دون تسبب الشكل في تغيير نفسه بينما إذا تم تعيين AutofitType إلى الشكل، فستتم تعديل الشكل بحيث يحتوى فقط على النص المطلوب فيه. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين AutofitType لـ TextFrame.
6. حفظ الملف على القرص.

```c#
// إنشاء كائن من Presentation class
Presentation presentation = new Presentation();

// الوصول إلى الشريحة الأولى 
ISlide slide = presentation.Slides[0];

// إضافة AutoShape من نوع مستطيل
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// إضافة TextFrame إلى المستطيل
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// الوصول إلى إطار النص
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// إنشاء كائن Paragraph لإطار النص
IParagraph para = txtFrame.Paragraphs[0];

// إنشاء كائن Portion للفقرة
IPortion portion = para.Portions[0];
portion.Text = "ثور بني سريع يقفز فوق الكلب الكسول. ثور بني سريع يقفز فوق الكلب الكسول.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// حفظ العرض
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **تعيين مرساة إطار النص**
تتيح Aspose.Slides لـ .NET للمطورين تعيين مرساة لأي TextFrame. يحدد TextAnchorType مكان وضع هذا النص في الشكل. يمكن تعيين TextAnchorType إلى أعلى أو وسط أو أسفل أو مبرر أو موزع. لتعيين مرساة لأي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين TextAnchorType لإطار النص.
6. حفظ الملف على القرص.

```c#
// إنشاء كائن من Presentation class
Presentation presentation = new Presentation();

// الحصول على الشريحة الأولى 
ISlide slide = presentation.Slides[0];

// إضافة AutoShape من نوع مستطيل
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// إضافة TextFrame إلى المستطيل
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// الوصول إلى إطار النص
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// إنشاء كائن Paragraph لإطار النص
IParagraph para = txtFrame.Paragraphs[0];

// إنشاء كائن Portion للفقرة
IPortion portion = para.Portions[0];
portion.Text = "ثور بني سريع يقفز فوق الكلب الكسول. ثور بني سريع يقفز فوق الكلب الكسول.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// حفظ العرض
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **تعيين تبويب النص**
- EffectiveTabs.ExplicitTabCount (2 في حالتنا هذه) تعادل Tabs.Count.
- تتضمن مجموعة EffectiveTabs جميع علامات التبويب (من مجموعة Tabs وعلامات التبويب الافتراضية)
- EffectiveTabs.ExplicitTabCount (2 في حالتنا هذه) تعادل Tabs.Count.
- تظهر خاصية EffectiveTabs.DefaultTabSize (294) المسافة بين علامات التبويب الافتراضية (3 و 4 في مثالنا).
- ستعيد EffectiveTabs.GetTabByIndex(index) برقم الفهرس = 0 علامة التبويب الصريحة الأولى (الموقع = 731)، الفهرس = 1 - العلامة الثانية (الموقع = 1241). إذا حاولت الحصول على علامة التبويب التالية برقم الفهرس = 2، فسيعيد الانتقال إلى علامة التبويب الافتراضية الأولى (الموقع = 1470) وهكذا.
- مستخدمًا EffectiveTabs.GetTabAfterPosition(pos) للحصول على التبويب التالي بعد نص معين. على سبيل المثال، لديك نص: "Helloworld!". لرسم هذا النص، يجب أن تعرف أين تبدأ "world!". في البداية، يجب عليك حساب طول "Hello" بالبكسل واستدعاء GetTabAfterPosition مع هذه القيمة. ستحصل على الموقع التالي لعرض "world!".

## **تعيين لغة التدقيق**

تتيح Aspose.Slides خاصية [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (المعرضة من فئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) لتعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم من خلالها التحقق من الإملاء والقواعد في PowerPoint.

يوضح هذا الكود C# كيفية تعيين لغة التدقيق لـ PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // تعيين معرف لغة التدقيق
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **تعيين اللغة الافتراضية**

يوضح هذا الكود C# كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل:

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // إضافة شكل مستطيل جديد مع نص
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "نص جديد";
    
    // يتحقق من لغة العنصر الأول
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **تعيين نمط النص الافتراضي**

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر نص العرض التقديمي مرة واحدة، فيمكنك استخدام خاصية `DefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) وتعيين التنسيق المفضل لديك. يوضح مثال الكود أدناه كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص على جميع الشرائح في عرض تقديمي جديد.

```c#
using (Presentation presentation = new Presentation())
{
    // الحصول على تنسيق الفقرة الرئيسي.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```