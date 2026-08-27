---
title: إدارة مربعات النص في العروض التقديمية باستخدام Java
linktitle: إدارة مربع نص
type: docs
weight: 20
url: /ar/java/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء مربع نص
- التحقق من مربع نص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تجعل Aspose.Slides for Java من السهل إنشاء وتحرير واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Java واجهة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}
توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، لا يمكن لجميع الأشكال التي تُضاف عبر واجهة `IShape` احتواء نص. لكن الأشكال التي تُضاف عبر واجهة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) قد تحتوي على نص. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
لذلك، عند التعامل مع شكل ترغب في إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط عندئذٍ ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/TextFrame)، وهو خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/ar/java/manage-textbox/#update-text) في هذه الصفحة. 
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation). 
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) مع [ShapeType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IGeometryShape#setShapeType-int-) مضبوطًا كـ `Rectangle` في موضع محدد على الشريحة والحصول على مرجع لكائن `IAutoShape` الذي تمت إضافته حديثًا. 
4. إضافة خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox* 
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

هذا الكود Java—تنفيذ للخطوات أعلاه—يوضح لك كيفية إضافة نص إلى شريحة:

```java
import com.aspose.slides.*;

// ينشئ كائن Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع إلى Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");

    // يصل إلى إطار النص
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

## **التحقق من وجود شكل مربع نص**

توفر Aspose.Slides طريقة [isTextBox](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/#isTextBox--) من واجهة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) تسمح لك بفحص الأشكال وتحديد مربعات النص.

![مربع النص والشكل](istextbox.png)

هذا الكود Java يوضح لك كيفية التحقق مما إذا تم إنشاء الشكل كمربع نص:

```java
import com.aspose.slides.*;

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

لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `addAutoShape` من واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/)، فسترجع طريقة `isTextBox` للقالب التلقائي القيمة `false`. ومع ذلك، بعد إضافة نص إلى القالب التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، سترجع خاصية `isTextBox` القيمة `true`.

```java
import com.aspose.slides.*;

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

## **العثور على الشكل المالك لإطار النص**

في كود معالجة النص العامة، قد تتلقى كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) دون معرفة مسبقة أي كائن عرض تقديمي يحتويه. استخدم طريقة [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentShape--) للعودة إلى [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) المالك.

بالنسبة لإطار نص ينتمي إلى [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) أو شكل آخر يحتوي على نص، تُعيد طريقة [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentShape--) المالك وتُعيد طريقة [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) القيمة `null`. كلا الطريقتين توفران تنقلاً للقراءة فقط، لذا فإن استدعائهما لا يغيّر الملكية. تحقق دائمًا من أن القيمة المرجعة ليست `null` قبل الوصول إلى الشكل.

لمثال كامل يحدد مالكي الأشكال وخلايا الجداول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [البحث واستبدال النص](/slides/ar/java/search-and-replace-text/).

## **إضافة أعمدة إلى مربع نص**

توفر Aspose.Slides خصائص [ColumnCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/TextFrameFormat)) التي تسمح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وضبط مقدار التباعد بالنقاط بين الأعمدة.

هذا الكود Java يُظهر العملية الموصوفة:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع إلى Rectangle
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

توفر Aspose.Slides for Java خاصية [ColumnCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضلة في إطار النص.

هذا الكود Java يوضح لك كيفية إضافة عمود داخل إطار النص:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

هذا الكود Java يُظهر عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //يتكرر عبر الفقرات في إطار النص
                {
                    for (IPortion portion : paragraph.getPortions()) //يتكرر عبر كل جزء في الفقرة
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

## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة `Presentation`. 
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن `AutoShape` مع `ShapeType` مضبوطًا كـ `Rectangle` في موضع محدد على الشريحة والحصول على مرجع لكائن AutoShape الذي تمت إضافته حديثًا. 
4. إضافة `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء كائن من الفئة `IHyperlinkManager`. 
6. ربط كائن `IHyperlinkManager` بخاصية [HyperlinkClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضل داخل `TextFrame`. 
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

هذا الكود Java—تنفيذ للخطوات أعلاه—يوضح لك كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
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

    // يضبط الارتباط التشعبي لنص الجزء
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // يحفظ عرض PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعنصر نائب للنص عند العمل مع الشرائح الأصلية؟**

[عنصر نائب](/slides/ar/java/manage-placeholder/) يرث النمط/الموقع من الـ[الماستر](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterslide/) ويمكن تجاوزه في الـ[التخطيطات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslide/)، في حين أن مربع النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال نصي شامل عبر العرض التقديمي دون التأثير على النص داخل الرسوم البيانية، الجداول، وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المدمجة ([الرسوم البيانية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/), [الجداول](https://reference.aspose.com/slides/ar/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/smartart/)) عن طريق المرور على مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.