---
title: إدارة مربع النص
type: docs
weight: 20
url: /java/manage-textbox/
description: إنشاء مربع نص على شرائح PowerPoint باستخدام Java. إضافة عمود في مربع نص أو إطار نص في شرائح PowerPoint باستخدام Java. إضافة مربع نص به رابط في شرائح PowerPoint باستخدام Java.
---


تعتمد النصوص في الشرائح عادةً على مربعات نص أو أشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة مربع نص ثم وضع بعض النصوص داخل مربع النص. يوفر Aspose.Slides لـ Java واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}

يقدم Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليست جميع الأشكال المضافة من خلال واجهة `IShape` يمكن أن تحتوي على نص. ولكن الأشكال المضافة من خلال واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

لذلك، عند التعامل مع شكل ترغب في إضافة نص إليه، قد ترغب في التحقق والتأكيد بأنه تم تحويله من خلال واجهة `IAutoShape`. فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، وهو خاصية تحت `IAutoShape`. انظر قسم [تحديث النص](https://docs.aspose.com/slides/java/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص على الشريحة، اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. أضف كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) مع إعداد [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` الذي تم إضافته مؤخرًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، اكتب ملف PPTX من خلال كائن `Presentation`.

يوضح هذا الكود بلغة Java - تنفيذ الخطوات السابقة - كيفية إضافة نص إلى شريحة:

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

    // يحدد النص
    portion.setText("Aspose TextBox");

    // يحفظ العرض التقديمي على القرص
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **التحقق من شكل مربع النص**

يوفر Aspose.Slides خاصية [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) (من فئة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)) التي تتيح لك فحص الأشكال والعثور على مربعات النص.

![مربع النص والشكل](istextbox.png)

يوضح هذا الكود بلغة Java كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "النموذج هو مربع نص" : "النموذج ليس مربع نص");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة عمود في مربع النص**

يوفر Aspose.Slides خاصيتي [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) التي تتيح لك إضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع نص وتحديد مقدار التباعد بالنقاط بين الأعمدة.

يوضح هذا الكود بلغة Java العملية الموصوفة:

```java
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضيف TextFrame إلى المستطيل
    aShape.addTextFrame("جميع هذه الأعمدة مقيدة لتكون ضمن حاوية نص واحدة -- " +
            "يمكنك إضافة أو حذف نص والنص الجديد أو المتبقي يتكيف تلقائيًا " +
            "ليتدفق داخل الحاوية. لا يمكنك أن يتدفق النص من حاوية واحدة " +
            "إلى أخرى، رغم ذلك -- لقد أخبرناك أن خيارات الأعمدة في PowerPoint للنص محدودة!");

    // يحصل على تنسيق النص لإطار النص
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // يحدد عدد الأعمدة في إطار النص
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
يوفر Aspose.Slides لـ Java خاصية [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يوضح هذا الكود بلغة Java كيفية إضافة عمود داخل إطار النص:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("جميع هذه الأعمدة مجبرة على البقاء ضمن حاوية نص واحدة -- " +
            "يمكنك إضافة أو حذف نص - والنص الجديد أو المتبقي يتكيف تلقائيًا " +
            "ليبقى داخل الحاوية. لا يمكنك أن يتدفق النص من حاوية واحدة " +
            "إلى أخرى، رغم ذلك -- لأن خيارات الأعمدة في PowerPoint للنص محدودة!");
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

يسمح لك Aspose.Slides بتغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

يوضح هذا الكود بلغة Java عملية يتم فيها تحديث أو تغيير جميع النصوص في عرض تقديمي:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //يتحقق مما إذا كانت الشكل يدعم إطار النص (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //يتكرر خلال الفقرات في إطار النص
                {
                    for (IPortion portion : paragraph.getPortions()) //يتكرر عبر كل جزء في الفقرة
                    {
                        portion.setText(portion.getText().replace("years", "months")); //يغير النص
                        portion.getPortionFormat().setFontBold(NullableBool.True); //يغير التنسيق
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

## **إضافة مربع نص برابط** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة مربع نص يحتوي على رابط، اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة `Presentation`.
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. أضف كائن `AutoShape` مع تعيين `ShapeType` كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape الذي تم إضافته مؤخراً.
4. أضف `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي له.
5. أنشئ مثيلًا من فئة `IHyperlinkManager`.
6. عيّن كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بجزء النص المفضل لديك في `TextFrame`.
7. أخيرًا، اكتب ملف PPTX من خلال كائن `Presentation`.

يوضح هذا الكود بلغة Java - تنفيذ الخطوات المذكورة أعلاه - كيفية إضافة مربع نص مع رابط إلى شريحة:

```java
// ينشئ مثيل لفئة Presentation التي تمثل PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يحول الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النصوص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يعين الرابط للنص الجزء
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ العرض التقديمي PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```