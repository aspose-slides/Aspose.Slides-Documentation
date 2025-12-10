---
title: إدارة فقرات نص PowerPoint في .NET
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/net/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة نص
- إدارة فقرة
- إدارة تعداد نقطي
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides ل .NET - تحسين المحاذاة والمسافات والأسلوب في عروض PPT و PPTX و ODP باستخدام C#."
---

يوفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في C#.

* يوفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر إرجاع السطر).
* يوفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعدد (مجموعة من كائنات iPortions).
* يوفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها. 

يمكن لكائن `IParagraph` التعامل مع نصوص ذات خصائص تنسيق مختلفة عبر كائنات `IPortion` الأساسيّة الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تُظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. إنشاء كائنين من النوع [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. إنشاء ثلاثة كائنات من النوع [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) لكل `IParagraph` جديد (اثنان من الكائنات للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. ضبط نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة لكل جزء باستخدام خصائص التنسيق التي تُوفرها كائن `IPortion`.
9. حفظ العرض المعدّل.

هذا كود C# يُنفّذ الخطوات لإضافة فقرات تحتوي على أجزاء:
```c#
 // ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يضيف IAutoShape شكل مستطيل
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // يصل إلى TextFrame للـ AutoShape
    ITextFrame tf = ashp.TextFrame;

    // ينشئ فقرات وأجزاء بتنسيقات نص مختلفة
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


## **إدارة تعداد الفقرات النقطية**
تُسهل القوائم النقطية تنظيم وعرض المعلومات بسرعة وفعالية. الفقرات النقطية أسهل دائمًا في القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. ضبط الخاصية `Type` للعدد النقطي للفقرة إلى `Symbol` وتحديد رمز العدد.
9. ضبط نص الفقرة.
10. ضبط `Indent` للفقرة بالنسبة للعدد النقطي.
11. تحديد لون للعدد النقطي.
12. تحديد ارتفاع للعدد النقطي.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات من 7 إلى 13.
15. حفظ العرض.

هذا كود C# يوضح كيفية إضافة تعداد فقرة نقطية:
```c#
 // ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];


    // يضيف الشكل التلقائي ويصل إليه
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار نص الشكل التلقائي
    ITextFrame txtFrm = aShp.TextFrame;

    // يزيل الفقرة الافتراضية
    txtFrm.Paragraphs.RemoveAt(0);

    // ينشئ فقرة
    Paragraph para = new Paragraph();

    // يضبط نمط نقط الفقرة والرمز
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // يضبط نص الفقرة
    para.Text = "Welcome to Aspose.Slides";

    // يضبط إزاحة النقطة
    para.ParagraphFormat.Indent = 25;

    // يضبط لون النقطة
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // يضبط ارتفاع النقطة
    para.ParagraphFormat.Bullet.Height = 100;

    // يضيف الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para);

    // ينشئ الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // يضبط نوع النقطة للفقرة والنمط
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // يضيف نص الفقرة
    para2.Text = "This is numbered bullet";

    // يضبط إزاحة النقطة
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // يضبط ارتفاع النقطة
    para2.ParagraphFormat.Bullet.Height = 100;

    // يضيف الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para2);


    // يحفظ العرض المعدل
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **إدارة تعداد الصور النقطية**
تُسهل القوائم النقطية تنظيم وعرض المعلومات بسرعة وفعالية. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. ضبط نوع العدد إلى [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) وتحديد الصورة.
9. ضبط نص الفقرة.
10. ضبط `Indent` للفقرة بالنسبة للعدد.
11. تحديد لون للعدد.
12. ضبط ارتفاع للعدد.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدّل.

هذا كود C# يوضح كيفية إضافة وإدارة عدد نقطي بصورة:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// يصل إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// ينشئ الصورة المستخدمة للنقاط
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// يضيف الشكل التلقائي ويصل إليه
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// يصل إلى إطار النص للشكل التلقائي
ITextFrame textFrame = autoShape.TextFrame;

// يزيل الفقرة الافتراضية
textFrame.Paragraphs.RemoveAt(0);

// ينشئ فقرة جديدة
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// يضبط نمط نقطة الفقرة والصورة
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// يضبط ارتفاع النقطة
paragraph.ParagraphFormat.Bullet.Height = 100;

// يضيف الفقرة إلى إطار النص
textFrame.Paragraphs.Add(paragraph);

// يحفظ العرض كملف PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// يحفظ العرض كملف PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **إدارة تعداد متعدد المستويات**
تُسهل القوائم النقطية تنظيم وعرض المعلومات بسرعة وفعالية. العدادات متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط العمق إلى 0.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط العمق إلى 1.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط العمق إلى 2.
9. إنشاء المثال الرابع للفقرة عبر فئة `Paragraph` وضبط العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدّل.

هذا كود C# يوضح كيفية إضافة وإدارة عدد نقطي متعدد المستويات:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // يصل إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];
    
    // يضيف الشكل التلقائي ويصل إليه
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // يصل إلى إطار النص للشكل التلقائي المُنشأ
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
    // يضبط مستوى النقطة
    para1.ParagraphFormat.Depth = 0;

    // يضيف الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يضبط مستوى النقطة
    para2.ParagraphFormat.Depth = 1;

    // يضيف الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يضبط مستوى النقطة
    para3.ParagraphFormat.Depth = 2;

    // يضيف الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يضبط مستوى النقطة
    para4.ParagraphFormat.Depth = 3;

    // يضيف الفقرات إلى المجموعة
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // يكتب العرض كملف PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **إدارة فقرة بقائمة مرقّمة مخصصة**
توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) وغيرها التي تسمح بإدارة الفقرات ذات العدّ المتخصّص أو التنسيق المخصّص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) إلى 2.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 3.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدّل.

هذا كود C# يوضح كيفية إضافة وإدارة فقرات ذات تعداد مخصّص أو تنسيق:
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


## **ضبط مسافة الفقرة البادئة**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. ضبط البادئة لكل [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) عبر خاصية `BulletOffset`.
1. كتابة العرض المعدّل كملف PPT.

هذا كود C# يوضح كيفية ضبط مسافة بادئة للفقرة:
```c#
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();

// يحصل على الشريحة الأولى
ISlide sld = pres.Slides[0];

// يضيف شكل مستطيل
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// يضيف TextFrame إلى المستطيل
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// يضبط النص ليتناسب مع الشكل
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// يخفي خطوط المستطيل
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// يحصل على الفقرة الأولى في TextFrame ويضبط إزاحتها
IParagraph para1 = tf.Paragraphs[0];

// يضبط نمط نقط الفقرة والرمز
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// يحصل على الفقرة الثانية في TextFrame ويضبط إزاحتها
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// يحصل على الفقرة الثالثة في TextFrame ويضبط إزاحتها
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// يحفظ العرض إلى القرص
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **ضبط مسافة بادئة معلقة لفقرة**

هذا كود C# يوضح كيفية ضبط المسافة البادئة المعلقة لفقرة:  
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


## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة التي تحتوي الفقرة عبر موضعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
1. كتابة العرض المعدّل كملف PPTX.

هذا كود C# يوضح كيفية ضبط خصائص End للفقرات في PowerPoint:
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


## **استيراد نص HTML إلى فقرات**
يوفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في كائن TextReader.
7. إنشاء أول مثال للفقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض المعدّل.

هذا كود C# يُنفّذ الخطوات لاستيراد نصوص HTML إلى فقرات:
```c#
// ينشئ مثالًا فارغًا من العرض التقديمي
using (Presentation pres = new Presentation())
{
    // يصل إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.Slides[0];

    // يضيف الشكل التلقائي لاستضافة محتوى HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // يضيف إطار نص إلى الشكل
    ashape.AddTextFrame("");

    // يمسح جميع الفقرات في إطار النص المضاف
    ashape.TextFrame.Paragraphs.Clear();

    // يحمل ملف HTML باستخدام قارئ التدفق
    TextReader tr = new StreamReader("file.html");

    // يضيف النص من قارئ تدفق HTML إلى إطار النص
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // يحفظ العرض التقديمي
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **تصدير نص الفقرة إلى HTML**
يوفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا كود C# يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
```c#
// يحمل ملف العرض التقديمي
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // يصل إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.Slides[0];

    // يحصل على الفهرس المطلوب
    int index = 0;

    // يحصل على الشكل المضاف
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // يكتب بيانات الفقرات إلى HTML عن طريق تحديد فهرس بدء الفقرة وعدد الفقرات التي سيتم نسخها
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بالواجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام أساليب `GetImage` من الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة بتنسيق bitmap. تسمح هذه الأساليب باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، وهو ما قد يكون مفيدًا لاستخدامات متعددة.

لنفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول صندوق نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بتنسيق PNG. تُعد هذه الطريقة مفيدة خاصةً عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.
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

في هذا المثال، نُوسّع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يُستخرج الشكل من العرض ويحفظ كصورة بمعامل مقياس `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. تُحسب حدود الفقرة مع اعتبار المقياس. يمكن أن يكون التحجيم مفيدًا عندما نحتاج إلى صورة أكثر تفصيلاً، مثلاً للاستخدام في مواد مطبوعة عالية الجودة.
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// احفظ الشكل في الذاكرة كصورة نقطية مع التحجيم.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// أنشئ صورة نقطية للشكل من الذاكرة.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// احسب حدود الفقرة الثانية.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// احسب حجم الصورة الناتجة (الحد الأدنى - 1x1 بكسل).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// حضّر صورة نقطية للفقرة.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// أعد رسم الفقرة من صورة الشكل إلى صورة الفقرة.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **أسئلة شائعة**

**هل يمكنني تعطيل التفاف السطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد التفاف الإطار النصي ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) لإيقاف التفاف السطور حتى لا تنكسر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرداد المستطيل الحدودي للفقرة (وأيضًا لجزء واحد) لمعرفة موضعها وحجمها الدقيق على الشريحة.

**أين تُتحكم محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

خاصية [Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) هي إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); تُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء من الفقرة فقط (مثلاً كلمة واحدة)؟**

نعم. تُحدَّد اللغة على مستوى الجزء ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/))، لذا يمكن أن تت co-exist عدة لغات داخل الفقرة نفسها.