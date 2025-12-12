---
title: إدارة مربعات النص في العروض التقديمية على Android
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/androidjava/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تُتيح Aspose.Slides للأندرويد عبر Java إنشاء وتعديل واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument بسهولة، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---


عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Android via Java واجهة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}

كما توفر Aspose.Slides واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر واجهة `IShape` يمكنها احتواء نص. لكن الأشكال التي تُضاف عبر واجهة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندئذٍ ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)، وهو خاصية تحت `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) مع تعيين `ShapeType` إلى `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` المضاف حديثًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

هذا الكود Java—تنفيذ للخطوات أعلاه—يوضح لك كيفية إضافة نص إلى شريحة:
```java
// ينشئ كائن Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);

    // يضبط النص
    portion.setText("Aspose TextBox");

    // يحفظ العرض التقديمي إلى القرص
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **التحقق من شكل مربع النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) من واجهة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) التي تسمح لك بفحص الأشكال وتحديد مربعات النص.

![Text box and shape](istextbox.png)

يعرض هذا الكود Java كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص: 
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `addAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/)، فإن طريقة `isTextBox` للشكل التلقائي ستعيد `false`. ومع ذلك، بعد أن تضيف نصًا إلى الشكل التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، ستعيد خاصية `isTextBox` القيمة `true`.
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() يعيد false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() يعيد true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() يعيد false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() يعيد true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() يعيد false
shape3.addTextFrame("");
// shape3.isTextBox() يعيد false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() يعيد false
shape4.getTextFrame().setText("");
// shape4.isTextBox() يعيد false
```


## **إضافة أعمدة إلى مربع النص**

توفر Aspose.Slides خاصيتي [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) وصنف [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) التي تسمح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وضبط المسافة بين الأعمدة بالنقاط.

يُظهر هذا الكود في Java العملية الموصوفة: 
```java
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضيف TextFrame إلى المستطيل
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // يحصل على تنسيق النص لإطار النص
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // يحدد عدد الأعمدة في إطار النص
    format.setColumnCount(3);

    // يحدد التباعد بين الأعمدة
    format.setColumnSpacing(10);

    // يحفظ العرض التقديمي
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides for Android via Java الخاصية [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يعرض هذا الكود Java كيفية إضافة عمود داخل إطار النص:
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

يعرض هذا الكود Java عملية يتم فيها تحديث جميع النصوص في العرض التقديمي:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //يتنقل عبر الفقرات في إطار النص
                {
                    for (IPortion portion : paragraph.getPortions()) //يتنقل عبر كل جزء في الفقرة
                    {
                        portion.setText(portion.getText().replace("years", "months")); //يُغيّر النص
                        portion.getPortionFormat().setFontBold(NullableBool.True); //يُغيّر التنسيق
                    }
                }
            }
        }
    }

    //يحفظ العرض التقديمي المعدل
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة مربع نص مع رابط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. أنشئ كائنًا من فئة `Presentation`. 
2. احصل على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من نوع `AutoShape` مع تعيين `ShapeType` إلى `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. أنشئ كائنًا من فئة `IHyperlinkManager`. 
6. عين كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضل لديك من `TextFrame`.
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض هذا الكود Java—تنفيذ للخطوات أعلاه—كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:
```java
// يُنشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape مع تعيين النوع كمستطيل
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يحول الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // يصل إلى الخاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يحدد الارتباط التشعبي لنص الجزء
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ عرض PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**ما الفرق بين مربع النص وعنصر نائب للنص عند العمل مع الشرائح الرئيسة؟**

يُورث العنصر النائب ([placeholder](/slides/ar/androidjava/manage-placeholder/)) النمط/الموقع من الـ[master](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) ويمكن تجاوزه في الـ[layouts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/)، بينما يُعد مربع النص العادي كائنًا مستقلاً على شريحة معينة ولا يتغيّر عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال جماعي للنصوص في العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المضمنة ([charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) عبر استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.