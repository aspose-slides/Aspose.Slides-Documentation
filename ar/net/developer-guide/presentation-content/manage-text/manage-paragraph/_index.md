---
title: إدارة فقرات نص PowerPoint في .NET
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/net/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الرصاصة
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- النص إلى HTML
- الفقرة إلى HTML
- الفقرة إلى صورة
- النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اتقن تنسيق الفقرات باستخدام Aspose.Slides لـ .NET — قم بتحسين المحاذاة والمسافات والنمط في عروض PPT و PPTX و ODP باستخدام C#."
---

Aspose.Slides يوفر جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في C#.

* Aspose.Slides يوفر واجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر عودة السطر).
* Aspose.Slides يوفر واجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعددة (مجموعة من كائنات iPortions).
* Aspose.Slides يوفر واجهة [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص تنسيقها. 

يمكن لكائن `IParagraph` معالجة نصوص بخصائص تنسيق مختلفة عبر كائنات `IPortion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) على شكل مستطيل إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنين Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي توفرها كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الكود C# هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:
```c#
// ينشئ كائن Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يضيف IAutoShape من نوع مستطيل
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // يصل إلى TextFrame الخاص بـ AutoShape
    ITextFrame tf = ashp.TextFrame;

    // ينشئ فقرات وأجزاء بصيغ نصية مختلفة
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // يحفظ العرض المعدل
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **إدارة تعداد الفقرات**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط دائمًا أسهل في القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر الرابط [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/). 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثال الأول للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. ضبط الخاصية `Type` للرصاص إلى `Symbol` وتعيين حرف الرصاص.
9. تعيين نص الفقرة.
10. تعيين `Indent` للرصاص للفقرة.
11. تعيين لون للرصاص.
12. تعيين ارتفاع للرصاص.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
15. حفظ العرض.

هذا الكود C# يوضح كيفية إضافة رصاص فقرة:
```c#
// ينشئ كائن Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];


    // يضيف ويصل إلى AutoShape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // يزيل الفقرة الافتراضية
    txtFrm.Paragraphs.RemoveAt(0);

    // ينشئ فقرة
    Paragraph para = new Paragraph();

    // يحدد نمط نقطة الفقرة والرمز
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // يحدد نص الفقرة
    para.Text = "Welcome to Aspose.Slides";

    // يحدد إزاحة النقطة
    para.ParagraphFormat.Indent = 25;

    // يحدد لون النقطة
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // اضبط IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // يحدد ارتفاع النقطة
    para.ParagraphFormat.Bullet.Height = 100;

    // يضيف الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para);

    // ينشئ الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // يحدد نوع نمط نقطة الفقرة
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // يضيف نص الفقرة
    para2.Text = "This is numbered bullet";

    // يحدد إزاحة النقطة
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // اضبط IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // يحدد ارتفاع النقطة
    para2.ParagraphFormat.Bullet.Height = 100;

    // يضيف الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para2);


    // يحفظ العرض المعدل
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **إدارة رصاصات الصور**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر الرابط [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثال الأول للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. ضبط نوع الرصاص إلى [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` للرصاص للفقرة.
11. تعيين لون للرصاص.
12. تعيين ارتفاع للرصاص.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة رصاصات الصور:
```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// يصل إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// ينشئ الصورة المستخدمة للنقاط
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// يضيف ويصل إلى AutoShape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// يصل إلى إطار النص للـ AutoShape
ITextFrame textFrame = autoShape.TextFrame;

// يزيل الفقرة الافتراضية
textFrame.Paragraphs.RemoveAt(0);

// ينشئ فقرة جديدة
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// يحدد نمط نقطة الفقرة والصورة
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// يحدد ارتفاع النقطة
paragraph.ParagraphFormat.Bullet.Height = 100;

// يضيف الفقرة إلى إطار النص
textFrame.Paragraphs.Add(paragraph);

// يحفظ العرض كملف PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// يحفظ العرض كملف PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **إدارة رصاصات متعددة المستويات**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة. رصاصات متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر الرابط [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثال الأول للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط العمق إلى 0.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط العمق إلى 1.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط العمق إلى 2.
9. إنشاء المثال الرابع للفقرة عبر فئة `Paragraph` وضبط العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة رصاصات متعددة المستويات:
```c#
 // ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];
    
    // يضيف ويصل إلى AutoShape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للـ AutoShape المُنشأ
    ITextFrame text = aShp.AddTextFrame("");
    
    // يمسح الفقرة الافتراضية
    text.Paragraphs.Clear();

    // يضيف الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى النقطة
    para1.ParagraphFormat.Depth = 0;

    // يضيف الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى النقطة
    para2.ParagraphFormat.Depth = 1;

    // يضيف الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى النقطة
    para3.ParagraphFormat.Depth = 2;

    // يضيف الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى النقطة
    para4.ParagraphFormat.Depth = 3;

    // يضيف الفقرات إلى المجموعة
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // يحفظ العرض كملف PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **إدارة فقرة بقائمة مرقمة مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بـ autoshape عبر الرابط [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثال الأول للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) إلى 2.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 3.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة فقرات ذات ترقيم مخصص أو تنسيق:
```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// يصل إلى إطار النص للـ AutoShape المُنشأ
	ITextFrame textFrame = shape.TextFrame;

	// يزيل الفقرة الافتراضية الموجودة
	textFrame.Paragraphs.RemoveAt(0);

	// القائمة الأولى
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **ضبط مسافة الفقرة (Indent)**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. ضبط المسافة (Indent) لكل [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) عبر خاصية BulletOffset الخاصة به.
1. كتابة العرض المعدل كملف PPT.

هذا الكود C# يوضح كيفية ضبط مسافة الفقرة:
```c#
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل مستطيل
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// إضافة TextFrame إلى المستطيل
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// ضبط النص ليتناسب مع الشكل
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// إخفاء خطوط المستطيل
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// الحصول على الفقرة الأولى في TextFrame وتعيين إزاحتها
IParagraph para1 = tf.Paragraphs[0];

// تحديد نمط نقطة الفقرة والرمز
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// الحصول على الفقرة الثانية في TextFrame وتعيين إزاحتها
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// الحصول على الفقرة الثالثة في TextFrame وتعيين إزاحتها
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// حفظ العرض على القرص
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **ضبط مسافة التعليق (Hanging Indent) للفقرة**

هذا الكود C# يوضح كيفية ضبط مسافة التعليق للفقرة:  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إدارة خصائص End للفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية ضبط خصائص End للفقرات في PowerPoint:
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام TextReader.
7. إنشاء المثال الأول للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض المعدل.

هذا الكود C# هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات:
```c#
 // ينشئ مثيل عرض تقديمي فارغ
 using (Presentation pres = new Presentation())
 {
     // يصل إلى الشريحة الأولى الافتراضية في العرض
     ISlide slide = pres.Slides[0];

     // يضيف AutoShape لاستيعاب محتوى HTML
     IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

     ashape.FillFormat.FillType = FillType.NoFill;

     // يضيف إطار نص إلى الشكل
     ashape.AddTextFrame("");

     // يمسح جميع الفقرات في إطار النص المضاف
     ashape.TextFrame.Paragraphs.Clear();

     // يحمل ملف HTML باستخدام قارئ تدفق
     TextReader tr = new StreamReader("file.html");

     // يضيف النص من قارئ تدفق HTML إلى إطار النص
     ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

     // يحفظ العرض التقديمي
     pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **تصدير نص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بدء إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود C# يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
```c#
// يحمل ملف العرض التقديمي
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // يصل إلى الشريحة الأولى الافتراضية في العرض
    ISlide slide = pres.Slides[0];

    // يحصل على الفهرس المطلوب
    int index = 0;

    // يحصل على الشكل المضاف
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // يكتب بيانات الفقرات إلى HTML بتحديد فهرس بدء الفقرة وعدد الفقرات المراد نسخها
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **حفظ فقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح هذه الأساليب استخراج أجزاء معينة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا للاستخدام في سيناريوهات متعددة.

لنفترض أن لدينا ملف عرض يسمى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. ثم يتم رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة بشكل خاص عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.
```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


النتيجة:

![The paragraph image](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نمد النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يُستخرج الشكل من العرض ويحفظ كصورة مع عامل تكبير `2`. يتيح ذلك الحصول على إخراج بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة التكبير. يمكن أن يكون التكبير مفيدًا عندما تكون الصورة التفصيلية مطلوبة، مثل الاستخدام في مواد مطبوعة عالية الجودة.
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **FAQ**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد الالتفاف الخاص بإطار النص ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) لإيقاف الالتفاف حتى لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة المحددة على الشريحة؟**

يمكنك استرجاع مستطيل الحد (bounding rectangle) للفقرة (وحتى للجزء الواحد) لتعرف موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يمين/يسار/وسط/مساواة)؟**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) هي إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); يتم تطبيقه على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. اللغة تُحدد على مستوى الجزء ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)), لذا يمكن أن تت coexist عدة لغات داخل فقرة واحدة.