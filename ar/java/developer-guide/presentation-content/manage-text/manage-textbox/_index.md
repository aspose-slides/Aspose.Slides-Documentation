---
title: إدارة صناديق النص في العروض التقديمية باستخدام Java
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "Aspose.Slides for Java يجعل من السهل إنشاء وتعديل واستنساخ صناديق النص في ملفات PowerPoint و OpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة صندوق نص ثم وضع بعض النص داخل الصندوق. توفر Aspose.Slides للـ Java الواجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) التي تسمح لك بإضافة شكل يحتوي على بعض النص.

{{% alert title="Info" color="info" %}}
توفر Aspose.Slides أيضًا الواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليست كل الأشكال المضافة عبر واجهة `IShape` يمكنها احتواء نص. لكن الأشكال المضافة عبر واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) قد تحتوي على نص. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندئذٍ ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، وهي خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/java/manage-textbox/#update-text) في هذه الصفحة. 
{{% /alert %}}

## **إنشاء صندوق نص على شريحة**

لإنشاء صندوق نص على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. الحصول على مرجع للشرحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) مع [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) مضبوطًا كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع لكائن `IAutoShape` المضاف حديثًا. 
4. إضافة خاصية `TextFrame` إلى كائن `IAutoShape` التي ستحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

هذا الكود Java — تنفيذ للخطوات أعلاه — يوضح لك كيفية إضافة نص إلى شريحة:
```java
// يُنشئ كائن Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع النوع مضبوط كـ Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");

    // يصل إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();

    // ينشئ كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // ينشئ كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);

    // يعيّن النص
    portion.setText("Aspose TextBox");

    // يحفظ العرض التقديمي على القرص
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **التحقق من شكل صندوق النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) من واجهة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) التي تسمح لك بفحص الأشكال وتحديد صناديق النص.

![صندوق النص والشكل](istextbox.png)

هذا الكود Java يوضح لك كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص: 
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


لاحظ أنه إذا قمت فقط بإضافة شكل تلقائي باستخدام طريقة `addAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/)، فستُعيد طريقة `isTextBox` لهذا الشكل `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، تُعيد خاصية `isTextBox` القيمة `true`. 
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() يرجع false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() يرجع true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() يرجع false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() يرجع true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() يرجع false
shape3.addTextFrame("");
// shape3.isTextBox() يرجع false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() يرجع false
shape4.getTextFrame().setText("");
// shape4.isTextBox() يرجع false
```


## **إضافة أعمدة إلى صندوق النص**

توفر Aspose.Slides الخصائص [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) التي تسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص وتعيين مقدار التباعد بالنقاط بين الأعمدة. 

هذا الكود Java يُظهر العملية الموصوفة: 
```java
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع النوع مضبوط كـ Rectangle
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

    // يحدد المسافة بين الأعمدة
    format.setColumnSpacing(10);

    // يحفظ العرض التقديمي
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides للـ Java الخاصية [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. عبر هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضلة في إطار النص. 

هذا الكود Java يوضح لك كيفية إضافة عمود داخل إطار النص:
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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق نص أو جميع النصوص الموجودة في عرض تقديمي. 

هذا الكود Java يُظهر عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:
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
                        portion.setText(portion.getText().replace("years", "months")); //يغيّر النص
                        portion.getPortionFormat().setFontBold(NullableBool.True); //يغيّر التنسيق
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


## **إضافة صندوق نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل صندوق نص. عند النقر على صندوق النص، يُوجه المستخدمون لفتح الارتباط. 

لإضافة صندوق نص يحتوي على ارتباط، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة `Presentation`. 
2. الحصول على مرجع للشرحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن `AutoShape` مع `ShapeType` مضبوطًا كـ `Rectangle` في موقع محدد على الشريحة والحصول على مرجع لكائن AutoShape المضاف حديثًا. 
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء كائن من الفئة `IHyperlinkManager`. 
6. إسناد كائن `IHyperlinkManager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضل لديك من `TextFrame`. 
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

هذا الكود Java — تنفيذ للخطوات أعلاه — يوضح لك كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:
```java
// يُنشئ كائنًا من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يحوّل الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يحدد الارتباط التشعبي لنص الجزء
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ العرض التقديمي بصيغة PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**ما الفرق بين صندوق النص وعلامة النص النائبة عند العمل مع الشرائح الرئيسية؟**

[placeholder](/slides/ar/java/manage-placeholder/) يرث النمط/الموضع من الـ [master](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/) ويمكن تجاوزه على الـ [layouts](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال جماعي للنص عبر العرض التقديمي دون تعديل النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نص واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)) عن طريق اجتياز مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.