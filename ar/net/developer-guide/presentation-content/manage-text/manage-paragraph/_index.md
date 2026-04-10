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
- إدارة نقط التعداد
- إزاحة الفقرة
- إزاحة معلقة
- نقط الفقرة
- قائمة مرقمة
- قائمة نقط
- خصائص الفقرة
- استيراد HTML
- تحويل النص إلى HTML
- تحويل الفقرة إلى HTML
- تحويل الفقرة إلى صورة
- تحويل النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إتقان تنسيق الفقرات مع Aspose.Slides لـ .NET — تحسين المحاذاة والمسافات والأنماط في عروض PPT و PPTX و ODP باستخدام C#."
---
توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأقسام في C#.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر عودة سطر).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أقسامًا. يمكن لكائن `IParagraph` أن يحتوي على قسم واحد أو متعدد (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص تنسيقها.

يمكن لكائن `IParagraph` معالجة النصوص ذات الخصائص التنسيقية المختلفة من خلال كائنات `IPortion` التابعة له.

## **إضافة فقرات متعددة تحتوي على أقسام متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أقسام:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) على شكل مستطيل إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان من Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل قسم.
8. تطبيق خصائص التنسيق المفضلة على كل قسم باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الكود C# هو تنفيذ للخطوات لإضافة فقرات تحتوي على أقسام:

```c#
// يقوم بإنشاء فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // إضافة IAutoShape على شكل مستطيل
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى TextFrame الخاص بـ AutoShape
    ITextFrame tf = ashp.TextFrame;

    // إنشاء فقرات وأقسام بتنسيقات نصية مختلفة
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
                tf.Paragraphs[i].Portions[j].FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].FontHeight = 18;
            }
        }
    // حفظ العرض التقديمي المعدل
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **إدارة نقط الفقرات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط تكون دائمًا أسهل في القراءة والفهم.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثيل للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/).
8. تعيين `Type` للنقطة في الفقرة إلى `Symbol` وتحديد حرف النقطة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة بالنسبة للنقطة.
11. تحديد لون للنقطة.
12. تحديد ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات من 7 إلى 13.
15. حفظ العرض التقديمي.

```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];


    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص الخاص بـ autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // إزالة الفقرة الافتراضية
    txtFrm.Paragraphs.RemoveAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // ضبط نمط نقطة الفقرة والرمز
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // تعيين نص الفقرة
    para.Text = "Welcome to Aspose.Slides";

    // ضبط إزاحة النقطة
    para.ParagraphFormat.Indent = 25;

    // ضبط لون النقطة
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص

    // ضبط ارتفاع النقطة
    para.ParagraphFormat.Bullet.Height = 100;

    // إضافة الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para);

    // إنشاء فقرة ثانية
    Paragraph para2 = new Paragraph();

    // ضبط نوع نمط نقطة الفقرة
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // إضافة نص الفقرة
    para2.Text = "This is numbered bullet";

    // ضبط إزاحة النقطة
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون نقطة مخصص

    // ضبط ارتفاع النقطة
    para2.ParagraphFormat.Bullet.Height = 100;

    // إضافة الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para2);


    // حفظ العرض التقديمي المعدل
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **إدارة نقاط الصور**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثيل للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) وتحديد الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة بالنسبة للنقطة.
11. تحديد لون للنقطة.
12. تحديد ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// ينشئ الصورة الخاصة بالنقاط
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// إضافة والوصول إلى Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// الوصول إلى إطار النص الخاص بالـ autoshape
ITextFrame textFrame = autoShape.TextFrame;

// إزالة الفقرة الافتراضية
textFrame.Paragraphs.RemoveAt(0);

// إنشاء فقرة جديدة
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// ضبط نمط نقطة الفقرة والصورة
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// ضبط ارتفاع النقطة
paragraph.ParagraphFormat.Bullet.Height = 100;

// إضافة الفقرة إلى إطار النص
textFrame.Paragraphs.Add(paragraph);

// حفظ العرض التقديمي كملف PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// حفظ العرض التقديمي كملف PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **إدارة النقاط متعددة المستويات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات تكون سهلة القراءة والفهم.

1. إنشاء مثيل لفئة [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/).
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثيل للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للـ autoshape المُنشأ
    ITextFrame text = aShp.AddTextFrame("");
    
    // مسح الفقرة الافتراضية
    text.Paragraphs.Clear();

    // إضافة الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ضبط مستوى النقطة
    para1.ParagraphFormat.Depth = 0;

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ضبط مستوى النقطة
    para2.ParagraphFormat.Depth = 1;

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ضبط مستوى النقطة
    para3.ParagraphFormat.Depth = 2;

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ضبط مستوى النقطة
    para4.ParagraphFormat.Depth = 3;

    // إضافة الفقرات إلى المجموعة
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // حفظ العرض التقديمي كملف PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith) وغيرها التي تسمح لك بإدارة الفقرات مع تعداد أو تنسيق مخصص.

1. إنشاء مثيل لفئة [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثيل للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith) إلى 2.
7. إنشاء مثيل الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثيل الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// الوصول إلى إطار النص للـ autoshape المُنشأ
	ITextFrame textFrame = shape.TextFrame;

	// إزالة الفقرة الافتراضية الموجودة
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

## **تعيين إزاحة السطر الأول لفقرة**

استخدم خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. تنقل هذه الخاصية السطر الأول فقط نسبة إلى الهامش الأيسر للفقرة. القيمة الإيجابية تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية لنص الفقرة.

استخدم خاصية [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) عندما تحتاج لنقل الفقرة بأكملها. واستخدم خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) عندما تحتاج لنقل السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لخاصية `Indent` لتوضيح كيفية تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لخاصية [Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![إزاحة السطر الأول للفقرات](first_line_indent.png)

## **تعيين إزاحة معلقة لفقرة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ السطر الأول إلى اليسار مقارنةً بالأسطر المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/). اضبط `Indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار نسبة إلى نص الفقرة.

عمليًا، تحدد خاصية [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) الموضع الأيسر لنص الفقرة، وتحدد خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) موضع السطر الأول نسبة إلى ذلك الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `MarginLeft` إيجابية وقيمة `Indent` سالبة.

هذا التنسيق مفيد للملاحق، المراجع، المدخلات القاموسية، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية لنص الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة إيجابية لخاصية [MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) لكل فقرة.
6. ضبط قيمة سالبة لخاصية [Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الإزاحة المعلقة للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء مثيل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) class.
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض المعدل كملف PPTX.

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

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام كائن TextReader.
7. إنشاء أول مثيل للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphcollection/) في إطار النص.
9. حفظ العرض المعدل.

```c#
// ينشئ مثيلًا فارغًا للعرض التقديمي
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى الافتراضية في العرض
    ISlide slide = pres.Slides[0];

    // يضيف AutoShape ليحتوي على محتوى HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // يضيف إطار نص إلى الشكل
    ashape.AddTextFrame("");

    // يمسح جميع الفقرات في إطار النص المُضاف
    ashape.TextFrame.Paragraphs.Clear();

    // يحمل ملف HTML باستخدام StreamReader
    TextReader tr = new StreamReader("file.html");

    // يضيف النص من StreamReader الخاص بـ HTML إلى إطار النص
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // يحفظ العرض التقديمي
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر الفهرس الخاص بها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل لـ `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

```c#
// يحمل ملف العرض التقديمي
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    ISlide slide = pres.Slides[0];

    // الوصول إلى الفهرس المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // يكتب بيانات الفقرات إلى HTML بتحديد فهرس بدء الفقرة وعدد الفقرات المراد نسخها
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة شكل يحتوي على الفقرة باستخدام طُرُق `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح لك هذه الطرق باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، وهو ما قد يكون مفيدًا لاستخدامات متعددة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص يحتوي على ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج لحفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.

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

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسّع النهج السابق بإضافة عوامل تحجيم لصورة الفقرة. يُستخرج الشكل من العرض ويُحفظ كصورة بمعامل تحجيم `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة التحجيم. يمكن أن يكون التحجيم مفيدًا خاصةً عندما تحتاج إلى صورة أكثر تفصيلاً، مثل استخدامها في مواد مطبوعة عالية الجودة.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// حفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
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

// حساب حجم الصورة الناتجة (الحد الأدنى - 1×1 بكسل).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// إعداد bitmap للفقرة.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// إعادة رسم الفقرة من bitmap الشكل إلى bitmap الفقرة.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. استخدم إعداد التفاف إطار النص ([WrapText](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/wraptext/)) لإيقاف التفاف السطور بحيث لا تنكسر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة بدقة على الشريحة؟**

يمكنك استرجاع المستطيل الحدودي للفقرة (وحتى للجزء الواحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يمين/يسار/وسط/مساواة)؟**

يتم التحكم في ذلك على مستوى الفقرة عبر [Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphformat/alignment/) في [ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphformat/)، وتطبق على كامل الفقرة بغض النظر عن تنسيق الأقسام الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. يتم تعيين اللغة على مستوى الجزء عبر [PortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/languageid/)، لذا يمكن أن تتواجد لغات متعددة ضمن نفس الفقرة.