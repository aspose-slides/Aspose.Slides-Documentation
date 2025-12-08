---
title: إدارة فقرات PowerPoint في C#
type: docs
weight: 40
url: /ar/net/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرات
- إدارة النص
- إدارة الفقرات
- مسافة البادئة للفقرة
- نقطة الفقرة
- قائمة مرقمة
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرات إلى صور
- تصدير الفقرات
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "إنشاء فقرات وإدارة خصائص الفقرة في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في C#.

* توفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (كل فقرة تُنشأ عبر عودة سطر).
* توفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات iPortions).
* توفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها. 

كائن `IParagraph` قادر على معالجة نصوص ذات خصائص تنسيق مختلفة من خلال كائنات `IPortion` التحتية الخاصة به.

## **Add Multiple Paragraph Containing Multiple Portions**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنين Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي توفرها كائنات `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود C# هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:
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
    // يحفظ العرض التقديمي المعدل
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **Manage Paragraph Bullets**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وفعالية. الفقرات النقطية دائمًا ما تكون أسهل في القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى `TextFrame` الخاص بالـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/). 
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. ضبط `Type` للرصاصة للفقرة إلى `Symbol` وتعيين حرف الرصاصة.
9. ضبط نص الفقرة.
10. ضبط `Indent` للرصاصة.
11. تعيين لون للرصاصة.
12. تعيين ارتفاع للرصاصة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات من 7 إلى 13.
15. حفظ العرض التقديمي.

هذا الكود C# يوضح كيفية إضافة رصاصة للفقرة:
```c#
    // ينشئ فئة Presentation التي تمثل ملف PPTX
    using (Presentation pres = new Presentation())
    {
    
        // يصل إلى الشريحة الأولى
        ISlide slide = pres.Slides[0];
    
    
        // يضيف الشكل التلقائي ويصل إليه
        IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
        // يصل إلى إطار النص للـ AutoShape
        ITextFrame txtFrm = aShp.TextFrame;
    
        // يزيل الفقرة الافتراضية
        txtFrm.Paragraphs.RemoveAt(0);
    
        // ينشئ فقرة
        Paragraph para = new Paragraph();
    
        // يضبط نمط نقطة الفقرة والرمز
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
    
        // يضبط نوع ونمط نقطة الفقرة
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
    
    
        // يحفظ العرض التقديمي المعدل
        pres.Save("Bullet_out.pptx", SaveFormat.Pptx);
    
    }
```


## **Manage Picture Bullets**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وفعالية. فقرات الصور سهلة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` الخاص بالـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. تحميل الصورة عبر [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. ضبط نوع الرصاصة إلى [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) وتعيين الصورة.
9. ضبط نص الفقرة.
10. ضبط `Indent` للرصاصة.
11. تعيين لون للرصاصة.
12. ضبط ارتفاع للرصاصة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة رصاصات الصور:
```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// يصل إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// ينشئ الصورة للنقاط
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// يضيف الشكل التلقائي ويصل إليه
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// يصل إلى إطار النص للـ autoshape
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

// يكتب العرض التقديمي كملف PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// يكتب العرض التقديمي كملف PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Manage Multilevel Bullets**

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وفعالية. الرصاصات المتدرجة سهولة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى `TextFrame` الخاص بالـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط العمق إلى 0.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط العمق إلى 1.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط العمق إلى 2.
9. إنشاء المثال الرابع للفقرة عبر فئة `Paragraph` وضبط العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة الرصاصات المتدرجة:
```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
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
    // يحدد مستوى الرصاصة
    para1.ParagraphFormat.Depth = 0;

    // يضيف الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى الرصاصة
    para2.ParagraphFormat.Depth = 1;

    // يضيف الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى الرصاصة
    para3.ParagraphFormat.Depth = 2;

    // يضيف الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // يحدد مستوى الرصاصة
    para4.ParagraphFormat.Depth = 3;

    // يضيف الفقرات إلى المجموعة
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // يكتب العرض التقديمي كملف PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Manage Paragraph with Custom Numbered List**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) وغيرها التي تتيح لك إدارة الفقرات القابلة للترقيم المخصص أو التنسيق.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى `TextFrame` للـ autoshape عبر [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) إلى 2.
7. إنشاء المثال الثاني للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 3.
8. إنشاء المثال الثالث للفقرة عبر فئة `Paragraph` وضبط `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح كيفية إضافة وإدارة فقرات ذات ترقيم مخصص أو تنسيق:
```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// يصل إلى إطار النص للشكل التلقائي المُنشأ
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


## **Set Paragraph Indent**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. ضبط المسافة البادئة لكل [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) عبر خاصية BulletOffset الخاصة بها.
1. كتابة العرض التقديمي المعدل كملف PPT.

هذا الكود C# يوضح كيفية ضبط مسافة بادئة للفقرة:
```c#
// إنشاء فئة Presentation
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

// الحصول على الفقرة الأولى في TextFrame وتعيين إزاحة البادئة لها
IParagraph para1 = tf.Paragraphs[0];

// ضبط نمط نقطة الفقرة والرمز
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// الحصول على الفقرة الثانية في TextFrame وتعيين إزاحة البادئة لها
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// الحصول على الفقرة الثالثة في TextFrame وتعيين إزاحة البادئة لها
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// حفظ العرض التقديمي إلى القرص
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **Set Hanging Indent for Paragraph**

هذا الكود C# يوضح كيفية ضبط المسافة البادئة المتدلية للفقرة:  
{{301b7441-c12f-4011-a0a9-e08c4ced703}}

## **Manage End Paragraph Run Properties for Paragraph**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

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


## **Import HTML Text into Paragraphs**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نصوص HTML إلى الفقرات.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` عبر [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في كائن TextReader.
7. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء إلى مجموعة [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) الخاصة بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

هذا الكود C# هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML إلى الفقرات:
```c#
// ينشئ مثيلًا فارغًا من العرض التقديمي
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

    // يقوم بتحميل ملف HTML باستخدام قارئ تدفق
    TextReader tr = new StreamReader("file.html");

    // يضيف النص من قارئ تدفق HTML إلى إطار النص
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // يحفظ العرض التقديمي
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Export Paragraphs Text to HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدَّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء نسخة من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود C# يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
```c#
// يحمل ملف العرض التقديمي
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // يصل إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.Slides[0];

    // يصل إلى الفهرس المطلوب
    int index = 0;

    // يصل إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // يكتب بيانات الفقرات إلى HTML بتحديد فهرس بداية الفقرة وعدد الفقرات التي سيتم نسخها
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **Save a Paragraph as an Image**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح هذه الأساليب باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا لاستخدامها لاحقًا في سيناريوهات متعددة.

افترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد وتنسيق النص بدقة.
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

**Example 2**

في هذا المثال، نوسّع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بمعامل مقياس `2`. يتيح ذلك مخرجات بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما تحتاج إلى صورة أكثر تفصيلًا، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// احفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// إنشاء صورة bitmap للشكل من الذاكرة.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// حساب حدود الفقرة الثانية.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// حساب حجم الصورة الناتجة (الحد الأدنى - بكسل واحد 1x1).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// تحضير صورة bitmap للفقرة.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// إعادة رسم الفقرة من صورة bitmap الخاصة بالشكل إلى صورة bitmap الخاصة بالفقرة.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **FAQ**

**Can I completely disable line wrapping inside a text frame?**

نعم. استخدم إعداد التفاف إطار النص ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حواف الإطار.

**How can I get the exact on-slide bounds of a specific paragraph?**

يمكنك استرجاع المستطيل الحدودي للفقرة (وحتى للجزء الفردي) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**Where is paragraph alignment (left/right/center/justify) controlled?**

يتم التحكم في المحاذاة عبر خاصية [Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); وتطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**Can I set a spell-check language for just part of a paragraph (e.g., one word)?**

نعم. يتم تعيين اللغة على مستوى الجزء عبر [PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)، لذا يمكن أن يت coexist عدة لغات داخل فقرة واحدة.