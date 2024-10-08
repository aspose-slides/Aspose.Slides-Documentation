---
title: إدارة فقرة PowerPoint في C#
type: docs
weight: 40
url: /ar/net/manage-paragraph/
keywords: 
- إضافة فقرة
- إدارة الفقرات
- مسافة الفقرة
- خصائص الفقرة
- نص HTML
- تصدير نص الفقرة
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "إنشاء وإدارة فقرة ونص ومسافة وخصائص في عروض PowerPoint في C# أو .NET"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint وفقرات وأجزاء في C#.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFame` على فقرة واحدة أو أكثر (كل فقرة يتم إنشاؤها من خلال إرجاع خط).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو أكثر (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل نصوص وخصائص تنسيقها.

يمكن أن يتعامل كائن `IParagraph` مع نصوص ذات خصائص تنسيق مختلفة من خلال كائناته الفرعية `IPortion`.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تظهر لك هذه الخطوات كيفية إضافة إطار نصي يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. احصل على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` من [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) لكل `IParagraph` جديدة (كائنان Portion لفقرة افتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion لكل `IParagraph`.
7. تعيين نص لبعض الأجزاء.
8. تطبيق ميزات التنسيق المفضلة لديك على كل جزء باستخدام خصائص التنسيق المعروضة بواسطة كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الشيفرة C# هي تطبيق للخطوات لإضافة فقرات تحتوي على أجزاء:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // إضافة شكل مستطيل IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // الوصول إلى إطار نص الآوتوشيب
    ITextFrame tf = ashp.TextFrame;

    // إنشاء فقرات وأجزاء بتنسيقات نص مختلفة
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
    // حفظ العرض المعدل
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **إدارة نقاط الفقرة**
تساعد قوائم النقاط على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات المرقمة دائما أسهل في القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) للشكل الآوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. تعيين نوع الفقرة `Type` ليكون `Symbol` وتعيين رمز الفقرة.
8. تعيين نص الفقرة `Text`.
9. تعيين `Indent` الفقرة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية الموضحة في الخطوات من 7 إلى 13.
14. حفظ العرض.

هذا الشيفرة C# تظهر لك كيفية إضافة نقطة فقرة:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];


    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار نص الآوتوشيب
    ITextFrame txtFrm = aShp.TextFrame;

    // إزالة الفقرة الافتراضية
    txtFrm.Paragraphs.RemoveAt(0);

    // إنشاء فقرة
    Paragraph para = new Paragraph();

    // تعيين نمط الفقرة ورمزها
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // تعيين نص الفقرة
    para.Text = "مرحبًا بك في Aspose.Slides";

    // تعيين مسافة النقطة
    para.ParagraphFormat.Indent = 25;

    // تعيين لون النقطة
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para.ParagraphFormat.Bullet.Height = 100;

    // إضافة الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para);

    // إنشاء الفقرة الثانية
    Paragraph para2 = new Paragraph();

    // تعيين نوع ونمط الفقرة
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // إضافة نص الفقرة
    para2.Text = "هذه نقطة مرقمة";

    // تعيين مسافة النقطة
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص

    // تعيين ارتفاع النقطة
    para2.ParagraphFormat.Bullet.Height = 100;

    // إضافة الفقرة إلى إطار النص
    txtFrm.Paragraphs.Add(para2);


    // حفظ العرض المعدل
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **إدارة نقاط الصورة**
تساعد قوائم النقاط على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات المصورة سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) للشكل الآوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة `Text`.
10. تعيين `Indent` الفقرة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

هذا الشيفرة C# تظهر لك كيفية إضافة وإدارة نقاط الصورة:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// يقوم بإنشاء الصورة للنقاط
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// إضافة والوصول إلى Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// الوصول إلى إطار النص الآوتوشيب
ITextFrame textFrame = autoShape.TextFrame;

// إزالة الفقرة الافتراضية
textFrame.Paragraphs.RemoveAt(0);

// إنشاء فقرة جديدة
Paragraph paragraph = new Paragraph();
paragraph.Text = "مرحبًا بك في Aspose.Slides";

// تعيين نمط الفقرة ورمز الصورة
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// تعيين ارتفاع النقطة
paragraph.ParagraphFormat.Bullet.Height = 100;

// إضافة الفقرة إلى إطار النص
textFrame.Paragraphs.Add(paragraph);

// كتابة العرض كملف PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// كتابة العرض كملف PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **إدارة النقاط متعددة المستويات**
تساعد قوائم النقاط على تنظيم وتقديم المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) للشكل الآوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية من خلال فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة من خلال فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة من خلال فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

هذا الشيفرة C# تظهر لك كيفية إضافة وإدارة النقاط متعددة المستويات:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];
    
    // إضافة والوصول إلى Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // الوصول إلى إطار النص للشكل الآوتوشيب الذي تم إنشاؤه
    ITextFrame text = aShp.AddTextFrame("");
    
    // مسح الفقرة الافتراضية
    text.Paragraphs.Clear();

    // إضافة الفقرة الأولى
    IParagraph para1 = new Paragraph();
    para1.Text = "المحتوى";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // تعيين مستوى النقطة
    para1.ParagraphFormat.Depth = 0;

    // إضافة الفقرة الثانية
    IParagraph para2 = new Paragraph();
    para2.Text = "المستوى الثاني";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // تعيين مستوى النقطة
    para2.ParagraphFormat.Depth = 1;

    // إضافة الفقرة الثالثة
    IParagraph para3 = new Paragraph();
    para3.Text = "المستوى الثالث";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // تعيين مستوى النقطة
    para3.ParagraphFormat.Depth = 2;

    // إضافة الفقرة الرابعة
    IParagraph para4 = new Paragraph();
    para4.Text = "المستوى الرابع";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // تعيين مستوى النقطة
    para4.ParagraphFormat.Depth = 3;

    // إضافة الفقرات إلى المجموعة
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // كتابة العرض كملف PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إدارة الفقرة مع قائمة مرقمة مخصصة**
توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) خاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) وغيرها التي تتيح لك إدارة الفقرات مع ترقيم أو تنسيق مخصص.

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) للشكل الآوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء المثيل الأول للفقرة من خلال فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) إلى 2.
7. إنشاء المثيل الثاني للفقرة من خلال فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء المثيل الثالث للفقرة من خلال فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

هذا الشيفرة C# تظهر لك كيفية إضافة وإدارة الفقرات مع ترقيم أو تنسيق مخصص:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// الوصول إلى إطار النص للشكل الآوتوشيب الذي تم إنشاؤه
	ITextFrame textFrame = shape.TextFrame;

	// إزالة الفقرة الافتراضية الموجودة
	textFrame.Paragraphs.RemoveAt(0);

	// القائمة الأولى
	var paragraph1 = new Paragraph { Text = "نقطة 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "نقطة 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "نقطة 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **تعيين مسافة الفقرة**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) مع ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين المسافة لكل [فقرة](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) من خلال خاصية BulletOffset.
1. كتابة العرض المعدل كملف PPT.

هذا الشيفرة C# تظهر لك كيفية تعيين مسافة الفقرة:

```c#
// يقوم بإنشاء مثيل لفئة Presentation
Presentation pres = new Presentation();

// يحصل على الشريحة الأولى
ISlide sld = pres.Slides[0];

// يضيف شكل مستطيل
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// يضيف إطار نص إلى الشكل المستطيل
ITextFrame tf = rect.AddTextFrame("هذه هي السطر الأول \rهذه هي السطر الثاني \rهذه هي السطر الثالث");

// يضبط النص ليتناسب مع الشكل
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// يخفي خطوط الشكل المستطيل
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// يحصل على الفقرة الأولى في إطار النص ويعين مسافتها
IParagraph para1 = tf.Paragraphs[0];

// تعيين نمط الفقرة ورمزها
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// يحصل على الفقرة الثانية في إطار النص ويعين مسافتها
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// يحصل على الفقرة الثالثة في إطار النص ويعين مسافتها
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// يكتب العرض إلى القرص
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **تعيين المسافة المعلقة للفقرة**

هذا الشيفرة C# تظهر لك كيفية تعيين المسافة المعلقة لفقرة:  

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "مثال"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "تعيين المسافة المعلقة للفقرة"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "هذه الشيفرة C# تظهر لك كيفية تعيين المسافة المعلقة للفقرة: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **إدارة خصائص انتهاء الفقرة لكل فقرة**

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. احصل على مرجع للشريحة التي تحتوي على الفقرة من خلال موقعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) مع فقرتين إلى الشكل المستطيل.
1. تعيين `FontHeight` ونوع الخط إلى الفقرات.
1. تعيين خصائص النهاية للفقرات.
1. كتابة العرض المعدل كملف PPTX.

هذا الشيفرة C# تظهر لك كيفية تعيين خصائص النهاية للفقرات في PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("نص تجريبي"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("نص تجريبي 2"));
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

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء المثيل الأول للفقرة من خلال فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) class.
8. إضافة محتوى ملف HTML المقروء في TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) في TextFrame.
9. حفظ العرض المعدل.

هذا الشيفرة C# هي تطبيق للخطوات لاستيراد نصوص HTML في الفقرات:

```c#
// يقوم بإنشاء مثيل عرض فارغ
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى الافتراضية للعرض
    ISlide slide = pres.Slides[0];

    // إضافة شكل أوتوشيب لإيواء محتوى HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // إضافة إطار نص إلى الشكل
    ashape.AddTextFrame("");

    // مسح جميع الفقرات في إطار النص المضاف
    ashape.TextFrame.Paragraphs.Clear();

    // تحميل ملف HTML باستخدام قارئ تيار
    TextReader tr = new StreamReader("file.html");

    // إضافة النص من قراءة التيار HTML إلى إطار النص
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // حفظ العرض
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تصدير نص الفقرات إلى HTML**
توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (المحتوى في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class وتحميل العرض المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) للشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الشيفرة C# تظهر لك كيفية تصدير نص فقرة PowerPoint إلى HTML:

```c#
// يقوم بتحميل ملف العرض
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // الوصول إلى الشريحة الأولى الافتراضية للعرض
    ISlide slide = pres.Slides[0];

    // الوصول إلى الفهرس المطلوب
    int index = 0;

    // الوصول إلى الشكل المضاف
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // كتابة بيانات الفقرات إلى HTML بتحديد فهرس البداية للفقرة وعدد الفقرات التي ستتم نسخها
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```