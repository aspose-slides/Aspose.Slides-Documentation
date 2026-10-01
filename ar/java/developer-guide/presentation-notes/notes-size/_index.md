---
title: تغيير حجم صفحة الملاحظات والاتجاه في Java
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/java/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات عمودية
- حجم النشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- Java
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لـ Java، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF وصور."
---
## **نظرة عامة**

استخدم [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getNotesSize--) للوصول إلى إعدادات صفحة ملاحظات العرض التقديمي. تُعيد كائن [INotesSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotessize/) الذي تحتوي طريقة [setSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) على تعيين أبعاد الصفحة. رغم أنه لا يمكن استبدال كائن الإعدادات ذاته، يمكنك تعيين أبعاد جديدة عبر هذه الطريقة.

يتم تحديد العرض والارتفاع بوحدتي **نقطة**، مع 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي بأكمله، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getNotesSize--) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرات. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlideSize--) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [ISlideSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidesize/). |

تغيير أي من الإعدادين لا يغير الآخر تلقائيًا. كما أن تغيير اتجاه صفحة الملاحظات لا يدور الشرائح العادية. راجع [حجم الشريحة](/slides/ar/java/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملف `sample.pptx` موجود مسبقًا. بالنسبة لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل بها ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم صفحة الملاحظات والاتجاه**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأعرض هي أفقية، والصفحة الأطول هي عمودية، والمتساوية الأبعاد تصف صفحة مربعة. تُظهر هذه العينة الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **التحويل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض الحالي مع الارتفاع. يحافظ ذلك على أطوال الجانبين، بما في ذلك حجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى عمودية ويترك الصفحة المربعة دون تغيير.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للوضع العمودي، استخدم نفس العملية عندما `size.getWidth() > size.getHeight()`. لا تستبدل أبعاد A4 أو Letter ما لم ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

عيّن البعدين معًا، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة العرض التقديمي. تُحدد هذه العينة صفحة أفقية بحجم 900 × 600 نقطة، تُحفظ كملف PPTX، ثم تُفتح مرة أخرى للتحقق من القيم المحفوظة. يسمح المقارنة بفجوة 0.01 نقطة للقيم العشرية؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

النتيجة المتوقعة هي `900.0 x 600.0 points` و `Size preserved: true`. التحقق من عرض تقديمي مفتوح حديثًا يثبت صحة الملف المحفوظ، وليس مجرد الإعدادات في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة لتصاميم الملاحظات أو النشرات. هذه الأبعاد لا تُفعِّل تلك التصاميم بحد ذاتها: يجب أيضًا تكوين خيارات التصدير. يظل تصدير الشرائح العادية يستخدم أبعاد الشرائح.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) إلى [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) لتضمين الملاحظات في ملف PDF. تُظهر هذه العينة أيضًا الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) و [RenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/renderingoptions/).

وضع [BottomTruncated](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notespositions/) يبقي الملاحظات على صفحة واحدة؛ يمكن قص الملاحظات التي لا تتناسب. يستخدم PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون PNG بحجم 900 × 600 بكسل. تصف النقاط هندسة الصفحة؛ وتصف البكسلات المخرجات النقطية، التي تعتمد أبعادها أيضًا على مقياس التقديم.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

لتصدير PDF مع ملاحظات طويلة، يسمح وضع [BottomFull](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notespositions/) بصفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء صورة شريحة واحدة أعلاه، لأنه لا يدعمه. بعد تغيير الحجم، افحص المخرجات للتحقق من عدم قص الملاحظات وموقع كائنات notes‑master الحالية؛ تعديل أبعاد الصفحة وحده لا يضمن أن كل المحتوى سيتناسب. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/java/convert-powerpoint-to-pdf-with-notes/) للمزيد حول تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handoutlayoutingoptions/) لعرض صور مصغرة متعددة للشرائح على صفحة واحدة. تُحدد العينة التالية صفحة بحجم 900 × 600 نقطة وتستخدم [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handouttype/) لترتيب حتى أربع شرائح لكل صفحة. يحدد الإعداد الأفقي ترتيب الشرائح؛ يأتي اتجاه الصفحة من عرضه وارتفاعه.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرات دون تغيير أبعاد الشرائح المصدرية. للصور النشرية، استخدم [Presentation.getImages](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) مع تخطيط النشرة، وليس طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم التقديم النشري على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما لا ينتج استدعاء صورة الشريحة الفردية صفحة النشرة. راجع [Handout Mode](/slides/ar/java/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في العارضات، التصدير والطباعة**

احتفظ بتمييز حجم العرض التقديمي المخزن، حجم الصفحة المُصدَّر، وحجم الورق المطبوع:

- **عارضات العرض التقديمي:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد تخطيطه الخاصة. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تُعيد عملية تحويل تنسيقه تطبيعها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المحددة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس تقديم، لذا قد تُقرب القيم العشرية للنقاط في مخرجات الصورة. لا يُطبق تصدير الشرائح العادية على حجم صفحة الملاحظات.
- **برامج تشغيل الطابعات:** يمكن لاختيار الورق، والدوران التلقائي، وإعدادات الملاءمة للصفحة أن تُغيِّر المخرجات الفعلية دون تغيير الأبعاد المخزنة في العرض التقديمي أو PDF. بالنسبة لحجم ورق محدد، طابق إعدادات الطابعة وتحقق من معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني ضبط حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن للشرائح الفردية أن تحتوي على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يُغيّر تغيير اتجاه الملاحظات شرائحي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادي عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون الناتج المحفوظ أو المطبوع بحجم مختلف؟**

أولاً أعد فتح العرض التقديمي المحفوظ وقارن أبعاد ملاحظاته. إذا تغيّرت، تحقّق مما إذا كان حفظ أو تحويل الملف في تطبيق آخر غير إعدادات الصفحة. إذا لم يحدث ذلك، افحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.