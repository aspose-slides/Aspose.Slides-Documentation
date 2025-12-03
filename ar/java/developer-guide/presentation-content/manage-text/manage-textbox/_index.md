---
title: إدارة صناديق النص في العروض التقديمية باستخدام جافا
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "يتيح Aspose.Slides for Java إنشاء وتحرير واستنساخ صناديق النص بسهولة في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Java واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) التي تسمح لك بإضافة شكل يحتوي على بعض النص.

{{% alert title="Info" color="info" %}}
توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الشكل المضاف عبر واجهة `IShape` يمكنه احتواء نص. أما الأشكال المضافة عبر واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) فقد تحتوي على نص. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
لذا، عند التعامل مع شكل تريد إضافة نص إليه، قد تحتاج إلى التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، وهي خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/java/manage-textbox/#update-text) في هذه الصفحة. 
{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيء من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. احصل على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) مع ضبط [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) كـ `Rectangle` في موقع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` المضاف حديثًا. 
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` لتحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود Java—تنفيذ للخطوات أعلاه—كيفية إضافة نص إلى شريحة:
```java
// ينشئ كائن Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape بنوع يتم تعيينه كـ Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");

    // يحصل على إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();

    // ينشئ كائن الفقرة لإطار النص
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


## **التحقق من شكل مربع النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) من واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ، مما يتيح لك فحص الأشكال وتحديد صناديق النص.

![Text box and shape](istextbox.png)

يعرض لك هذا الكود Java كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص: 
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


لاحظ أنه إذا قمت بإضافة شكل تلقائي فقط باستخدام طريقة `addAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/)، فستعيد طريقة `isTextBox` لل shape قيمة `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، ستعيد خاصية `isTextBox` القيمة `true`.
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() ترجع false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() ترجع true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() ترجع false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() ترجع true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() ترجع false
shape3.addTextFrame("");
// shape3.isTextBox() ترجع false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() ترجع false
shape4.getTextFrame().setText("");
// shape4.isTextBox() ترجع false
```


## **إضافة عمود في مربع النص**

توفر Aspose.Slides الخاصيتين [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) التي تسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين المسافة بين الأعمدة بالنقاط. 

يعرض هذا الكود في Java العملية الموصوفة: 
```java
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape بنوع محدد كـ Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضيف TextFrame إلى المستطيل
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // يحصل على تنسيق النص في TextFrame
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

توفر Aspose.Slides for Java الخاصية [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص. 

يعرض لك هذا الكود Java كيفية إضافة عمود داخل إطار النص:
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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع النص أو جميع النصوص الموجودة في العرض التقديمي. 

يعرض هذا الكود Java عملية يتم فيها تحديث أو تغيير جميع النصوص في العرض التقديمي:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // يتنقل عبر الفقرات في إطار النص
                {
                    for (IPortion portion : paragraph.getPortions()) // يتنقل عبر كل جزء في الفقرة
                    {
                        portion.setText(portion.getText().replace("years", "months")); // يغيّر النص
                        portion.getPortionFormat().setFontBold(NullableBool.True); // يغيّر التنسيق
                    }
                }
            }
        }
    }

    // يحفظ العرض التقديمي المعدل
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الارتباط. 

لإضافة مربع نص يحتوي على ارتباط، اتبع الخطوات التالية:

1. إنشاء مثيء من فئة `Presentation`. 
2. احصل على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع ضبط `ShapeType` كـ `Rectangle` في موقع محدد على الشريحة واحصل على مرجع للكائن AutoShape المضاف حديثًا. 
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء مثيء من فئة `IHyperlinkManager`. 
6. عيّن كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضل لديك من `TextFrame`. 
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود Java—تنفيذ للخطوات أعلاه—كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:
```java
// ينشئ كائن من فئة Presentation يمثل PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape بنوع مستطيل
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يحوّل الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يضبط الارتباط التشعبي لنص الجزء
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ العرض التقديمي PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعلامة النص النائبة عند العمل مع الشرائح الرئيسية؟**

تُورِث [placeholder](/slides/ar/java/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/) ويمكن تجاوزها في [layouts](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/)، بينما يُعد مربع النص العادي كائنًا مستقلاً على شريحة معينة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال جماعي للنص عبر العرض التقديمي دون تعديل النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/java/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)) من خلال استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.