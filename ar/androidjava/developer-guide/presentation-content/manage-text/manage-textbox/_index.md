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
- تحديث نص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة رابط تشعبي
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء، تحديد، تنسيق، وتحديث مربعات النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **المقدمة**

في Aspose.Slides لنظام Android عبر Java، يُخزن نص الشريحة في إطارات نصية تنتمي إلى الأشكال. تمثل الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) الشكل الأكثر شيوعًا الذي يحمل نصًا وتُظهر نصه من خلال الطريقة [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}
كل شكل تلقائي يطبق [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)، لكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نص. عند معالجة عرض تقديمي موجود، تحقق من أن الشكل يطبق [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) قبل الوصول إلى نصه.
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص، أضف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطار نصه، واحفظ العرض التقديمي. المثال التالي ينشئ مربع نص مستطيل:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقاييس والأبعاد التي تُمرَّر إلى الطريقة [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) تُقاس بالنقاط. تقوم الطريقة [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) بتهيئة إطار النص بالنص المزوَّد.

## **التحقق من وجود شكل مربع نص**

استخدم الطريقة [IAutoShape.isTextBox](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#isTextBox--) لتحديد ما إذا كان الشكل التلقائي يُعامل كمربع نص. هذا مفيد عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![مربع نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في العرض التقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

الشكل التلقائي المضاف حديثًا لا يُعتبر مربع نص إلا إذا احتوى على نص غير فارغ. يمكنك توفير ذلك النص عبر [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) أو [ITextFrame.setText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). إضافة أو تعيين سلسلة فارغة يجعل [IAutoShape.isTextBox](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#isTextBox--) تُعيد `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

المكالمتان الأوليان يطبعان `true`؛ الأخيرتان يطبعان `false`.

## **إيجاد الشكل الذي يملك إطار نص**

قد يتلقى كود معالجة النص العامة كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم الطريقة القارئة فقط [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--) للعودة إلى [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) المالك.

لإطار نص يملكه شكل تلقائي أو شكل آخر يحمل نصًا، تُعيد [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--) المالك وتُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentCell--) القيمة `null`. تحقق من القيمة المرجعة قبل الوصول إليها. لتحديد كل من مالكي الشكل وخلية الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع القسم [Search and Replace Text](/slides/ar/androidjava/search-and-replace-text/) .

## **إضافة أعمدة إلى مربع نص**

تقسّم الطريقة [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) إطار النص إلى أعمدة، بينما تُحدد الطريقة [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) الفجوة بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى [ITextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/) ويمكن تغييره عبر إطار نص مربع نص موجود. يعيد النص التدفق بين الأعمدة داخل نفس الشكل؛ ولا يستمر في شكل آخر.

المثال التالي يُنشئ مربع نص بثلاثة أعمدة مع 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ثم يقرأ الإعدادات المخزنة من ملف الإخراج:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **استخراج النص من الأعمدة الفردية**

استخدم الطريقة [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) لاسترجاع النص المخصص لكل عمود بصري في إطار نص موجود. تُعيد الطريقة سلسلة واحدة لكل عمود وفق ترتيب القراءة القائم على الأعمدة. يُنتج إطار نص بعمود واحد مصفوفة ذات عنصر واحد، ويمثل العمود الفارغ سلسلة فارغة. تحتوي السلاسل على نص عادي فقط؛ ولا يُحفظ التنسيق على مستوى الجزء.

هذا مفيد عندما تحتاج إلى:

- استخراج النص مع الحفاظ على ترتيب القراءة القائم على الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل أو حقل قاعدة بيانات أو مقصد آخر.
- فحص كيفية إعادة توزيع النص بعد تغيير عدد الأعمدة باستخدام [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-)، أو الفجوة باستخدام [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)، أو الخط، أو حجم إطار النص.

تُبلغ الطريقة عن النص الموزَّع داخل [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الحالي؛ ولا تُجري تلقائيًا تدفق النص بين أشكال أو مربعات نص منفصلة. قد يعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرأ عدد الأعمدة المكوَّن، ويكتب النص من كل عمود إلى ملف منفصل. تُهمل الأشكال التي لا توفر إطار نص.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تحديث النص**

لتحديث النص عبر العرض التقديمي، كرر عبر الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرّر أجزاء نصها. يتيح العمل على مستوى الجزء تغيير كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لكلمة `years` بـ `months` في نص الأشكال التلقائية ويجعل كل جزء متأثر غامقًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا التجوال يُحدّث النص فقط في الأشكال التلقائية. يتطلب النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة تجوالًا في مجموعات تلك الكائنات نفسها.

## **إضافة مربع نص به رابط تشعبي**

يمكن ربط رابط تشعبي بجزء نص محدد، بحيث يكون ذلك الجزء فقط هو القابل للنقر. استخدم الطريقة [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) لربط الجزء بعنوان URL خارجي.

المثال التالي يُنشئ نصًا مرتبطًا ويحفظه في عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعنصر النائب النصي في الشريحة الرئيسية أو تخطيط الشريحة؟**

يمكن لـ [placeholder](/slides/ar/androidjava/manage-placeholder/) أن يرث موقعه وتنسيقه من [master slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterslide/) أو [layout slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslide/). مربع النص العادي هو شكل مستقل على الشريحة التي تم إنشاؤه عليها ولا يكتسب سلوك العنصر النائب عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تعديل النص في المخططات أو الجداول أو SmartArt؟**

قصر التجوال على الأشكال التي تطبق [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) كما هو موضح في مثال تحديث النص. تخزن المخططات والجداول وSmartArt النص في نماذج كائناتها الخاصة، لذا لا تُعدَّل بهذه الحلقة.