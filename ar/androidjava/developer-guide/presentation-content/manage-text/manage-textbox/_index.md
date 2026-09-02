---
title: إدارة صناديق النص في العروض التقديمية على Android
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/androidjava/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة رابط تشعبي
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android عبر Java يجعل من السهل إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint و OpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

النصوص في الشرائح عادةً ما تكون داخل صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، تحتاج إلى إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. يوفّر Aspose.Slides for Android عبر Java الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}
Aspose.Slides يوفّر أيضاً الواجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر واجهة `IShape` يمكنها حمل نص. ولكن الأشكال التي تُضاف عبر الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape) قد تحتوي على نص.
{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 
لذلك، عند التعامل مع شكل ترغب في إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. فقط بعدها سيمكنك العمل مع [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/TextFrame)، التي هي خاصية تحت `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/ar/androidjava/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء صندوق نص في شريحة**

لإنشاء صندوق نص في شريحة، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. احصل على إشارة إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من النوع [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape) مع [ShapeType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) مُعينًا إلى `Rectangle` في موضع محدد على الشريحة واحصل على الإشارة إلى كائن `IAutoShape` المضاف حديثًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك كود Java التالي—تنفيذ للخطوات أعلاه—كيفية إضافة نص إلى شريحة:

```java
import com.aspose.slides.*;

// إنشاء نسخة من Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");

    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();

    // إنشاء كائن الفقرة لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);

    // تعيين النص
    portion.setText("Aspose TextBox");

    // حفظ العرض التقديمي إلى القرص
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **التحقق من شكل صندوق النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#isTextBox--) من الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) ، مما يتيح لك فحص الأشكال وتحديد صناديق النص.

![صندوق النص والشكل](istextbox.png)

يعرض لك كود Java التالي كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص: 

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

لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام طريقة `addAutoShape` من الواجهة [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/) ، فإن طريقة `isTextBox` للشكل التلقائي ستعيد `false`. ومع ذلك، بعد أن تضيف نصًا إلى الشكل التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، ستعيد خاصية `isTextBox` القيمة `true`.

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

في كود معالجة النصوص العام، قد تستقبل كائنًا من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) دون معرفة مسبقة أي عنصر عرض تقديمي يحتويه. استخدم طريقة [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--) للعودة إلى الـ[IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) المالك.

بالنسبة لإطار نص ينتمي إلى [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) أو شكل آخر يحتوي على نص، تُعيد طريقة [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--) المالك وتُعيد طريقة [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentCell--) القيمة `null`. كلا الطريقتين توفران تنقلًا للقراءة فقط، لذا فإن استدعائهما لا يغيّر الملكية. تأكد دائمًا من فحص القيمة المرجعة للتأكد من أنها ليست `null` قبل الوصول إلى الشكل.

للحصول على مثال كامل يحدد مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعُقَد SmartArt، راجع [Search and Replace Text](/slides/ar/androidjava/search-and-replace-text/).

## **إضافة أعمدة إلى صندوق النص**

توفر Aspose.Slides الخصائص [ColumnCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrameFormat) والفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/TextFrameFormat)) التي تتيح لك إضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص وتعيين المسافة بين الأعمدة بالنقاط.

يعرض لك الكود التالي بلغة Java العملية الموصوفة:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape مع تعيين النوع كـ Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // إضافة TextFrame إلى المستطيل
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // يحصل على تنسيق النص لإطار النص
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // تحديد عدد الأعمدة في إطار النص
    format.setColumnCount(3);

    // تحديد المسافة بين الأعمدة
    format.setColumnSpacing(10);

    // حفظ العرض التقديمي
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides for Android عبر Java الخاصية [ColumnCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (من الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضّل في إطار النص.

يعرض لك كود Java التالي كيفية إضافة عمود داخل إطار نص:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق النص أو جميع النصوص الموجودة في عرض تقديمي.

يعرض لك كود Java التالي عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:

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

## **إضافة صندوق نص مع رابط تشعبي** 

يمكنك إدراج رابط داخل صندوق نص. عندما يتم النقر على صندوق النص، سيتم توجيه المستخدمين لفتح الرابط. 

لإضافة صندوق نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة `Presentation`. 
2. احصل على إشارة إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من النوع `AutoShape` مع `ShapeType` مُعينًا إلى `Rectangle` في موضع محدد على الشريحة واحصل على إشارة إلى كائن الـAutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` وقم بتعيين نص الجزء الأول منه. في المثال أدناه، استخدمنا هذا النص: *Aspose.Slides*
5. احصل على كائن [IHyperlinkManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/) من `PortionFormat` للجزء المفضّل لديك في `TextFrame`.
6. استدعِ طريقة [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) على ذلك الكائن لتعيين الرابط الذي يفتح عند النقر على النص.
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يعرض لك كود Java التالي—تنفيذ للخطوات أعلاه—كيفية إضافة صندوق نص مع رابط تشعبي إلى شريحة:

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // يحوّل الشكل إلى AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // يعيّن الارتباط التشعبي لنص الجزء
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

**ما الفرق بين صندوق النص وعنصر نائبة النص عند العمل مع الشرائح الرئيسية؟**

يُورث [placeholder](/slides/ar/androidjava/manage-placeholder/) النمط/الموضع من الـ[master](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterslide/) ويمكن تجاوزه في الـ[layouts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغيّر عند تبديل التخطيطات.

**كيف يمكنني تنفيذ استبدال نص جماعي عبر العرض التقديمي دون تعديل النص داخل المخططات أو الجداول أو SmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نص واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/smartart/)) عن طريق استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.