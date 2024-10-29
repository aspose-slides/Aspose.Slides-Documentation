---
title: إدارة صندوق النص
type: docs
weight: 20
url: /ar/androidjava/manage-textbox/
description: إنشاء صندوق نص في شرائح باور بوينت باستخدام جافا. إضافة عمود في صندوق النص أو إطار النص في شرائح باور بوينت باستخدام جافا. إضافة صندوق نص مع ارتباط تشعبي في شرائح باور بوينت باستخدام جافا.
---


توجد النصوص على الشرائح عادةً في صناديق نصية أو أشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. توفر Aspose.Slides لنظام Android عبر جافا واجهة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}

توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال المضافة من خلال واجهة `IShape` يمكنها احتواء نص. ولكن الأشكال المضافة من خلال واجهة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) يمكن أن تحتوي على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكيد على أنه تم تحويله من خلال واجهة `IAutoShape`. فقط حينها ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)، وهو خاصية تحت `IAutoShape`. راجع قسم [تحديث النص](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء صندوق نص على الشريحة**

لإنشاء صندوق نص على شريحة، اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) مع تعيين [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` الذي تم إضافته مؤخرًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، قم بكتابة ملف PPTX عبر كائن `Presentation`. 

هذا الرمز بلغة جافا - تنفيذ للخطوات أعلاه - يوضح لك كيفية إضافة نص إلى شريحة:

```java
// ينشئ Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع إلى Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى Rectangle
    ashp.addTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);

    // يحدد النص
    portion.setText("Aspose TextBox");

    // يحفظ العرض التقديمي إلى القرص
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **التحقق من شكل صندوق النص**

توفر Aspose.Slides خاصية [isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--) (من فئة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)) لتتيح لك استكشاف الأشكال والعثور على صناديق النص.

![صندوق النص والشكل](istextbox.png)

يوضح لك هذا الرمز بلغة جافا كيفية التحقق من ما إذا كان الشكل قد تم إنشاؤه كصندوق نص: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "الشكل هو صندوق نص" : "الشكل ليس صندوق نص");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة عمود في صندوق النص**

توفر Aspose.Slides خاصيتي [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) التي تتيح لك إضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص وتعيين مقدار المسافة بالنقاط بين الأعمدة.

هذا الرمز بلغة جافا يوضح العملية الموصوفة: 

```java
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع إلى Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضيف TextFrame إلى Rectangle
    aShape.addTextFrame("جميع هذه الأعمدة محدودة لتكون ضمن حاوية نص واحدة -- " +
            "يمكنك إضافة أو حذف نص، ويتكيف النص الجديد أو المتبقي تلقائيًا " +
            "لتدفق داخل الحاوية. لا يمكنك أن يكون لديك تدفق نص من حاوية واحدة " +
            "إلى أخرى، لكنها -- لقد أخبرناك أن خيارات الأعمدة في باور بوينت محدودة!");

    // يحصل على تنسيق نص إطار النص
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // يحدد عدد الأعمدة في TextFrame
    format.setColumnCount(3);

    // يحدد المسافة بين الأعمدة
    format.setColumnSpacing(10);

    // يحفظ العرض التقديمي
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة عمود في إطار النص**
توفر Aspose.Slides لنظام Android عبر جافا خاصية [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يوضح لك هذا الرمز بلغة جافا كيفية إضافة عمود داخل إطار النص:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("جميع هذه الأعمدة مُجبَرة على البقاء ضمن حاوية نص واحدة -- " +
            "يمكنك إضافة أو حذف نص - ويتكيف النص الجديد أو المتبقي تلقائيًا " +
            "ليبقى ضمن الحاوية. لا يمكنك أن يتساقط النص من حاوية واحدة " +
            "إلى أخرى، على الرغم من أن خيارات الأعمدة للنص في باور بوينت محدودة!");
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

تتيح لك Aspose.Slides تغيير أو تحديث النص المحتوي في صندوق النص أو جميع النصوص المحتواة في عرض تقديمي.

يوضح هذا الرمز بلغة جافا عملية حيث يتم تحديث أو تغيير جميع النصوص في عرض تقديمي:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // يتحقق مما إذا كان الشكل يدعم إطار نص (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // يتكرر عبر الفقرات في إطار النص
                {
                    for (IPortion portion : paragraph.getPortions()) // يتكرر عبر كل جزء في الفقرة
                    {
                        portion.setText(portion.getText().replace("years", "months")); // يغير النص
                        portion.getPortionFormat().setFontBold(NullableBool.True); // يغير التنسيق
                    }
                }
            }
        }
    }

    // يحفظ العرض التقديمي المعدَّل
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة صندوق نص مع ارتباط تشعبي** 

يمكنك إدراج رابط داخل صندوق نص. عند النقر على صندوق النص، يتم توجيه المستخدمين لفتح الرابط. 

لإضافة صندوق نص يحتوي على رابط، اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة `Presentation`. 
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع تعيين `ShapeType` كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape الذي تم إضافته مؤخرًا.
4. أضف `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي له. 
5. قم بإنشاء مثيل لفئة `IHyperlinkManager`. 
6. قم بتعيين كائن `IHyperlinkManager` لخاصية [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالنص المفضل لديك في `TextFrame`.
7. أخيرًا، قم بكتابة ملف PPTX عبر كائن `Presentation`. 

يوضح هذا الرمز بلغة جافا - تنفيذ للخطوات أعلاه - كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:

```java
// ينشئ فئة Presentation تمثل PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape مع تعيين النوع إلى Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يقوم بتحويل الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يحدد الرابط النصي للجزء النصي
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ العرض التقديمي PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```