---
title: تغيير حجم صفحة الملاحظات واتجاهها على Android
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لـ Android عبر Java، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF وصور."
---
## **نظرة عامة**

استخدم [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getNotesSize--) للوصول إلى إعدادات صفحة ملاحظات العرض التقديمي. تُعيد كائنًا من نوع [INotesSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotessize/) حيث تُحدد الطريقة [setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) أبعاد الصفحة. على الرغم من أنه لا يمكن استبدال كائن الإعدادات نفسه، يمكنك تعيين أبعاد جديدة عبر هذه الطريقة.

العرض والارتفاع محددان بـ **النقاط**، حيث يوجد 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي ككل، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getNotesSize--) | يتحكم في أبعاد صفحة الملاحظات والأبعاد المستخدمة لتصدير المذكرات. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlideSize--) | يتحكم في أبعاد الشرائح العادية للعرض التقديمي عبر [ISlideSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/). |

تغيير أي من الإعدادين لا يغيّر تلقائيًا الآخر. تغيير توجّه صفحة الملاحظات لا يدور الشرائح العادية. راجع [Slide Size](/slides/ar/androidjava/slide-size/) لتغيير حجم الشرائح العادية.

الأمثلة أدناه تستخدم ملف `sample.pptx` موجود. بالنسبة لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل بها ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم صفحة الملاحظات وتوجّهها**

اقرأ العرض والارتفاع وقارنهما لتحديد التوجّه: الصفحة الأوسع هي أفقية، والصفحة الأطول هي عمودية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **التبديل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير التوجّه فقط، عكس العرض والارتفاع الحاليين. يحافظ هذا على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى عمودية ويترك الصفحة المربعة دون تغيير.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للوضع العمودي، استخدم نفس التعيين عندما يكون `size.getWidth() > size.getHeight()`. لا تستبدل أبعاد A4 أو Letter ما لم تكن ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم مخصص لصفحة الملاحظات**

قم بتعيين البعدين معًا، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة العرض التقديمي. يحدد هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، يحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المحفوظة. يسمح المقارنة بتحمل فرق 0.01 نقطة للقيم ذات الفاصلة العائمة؛ ولا يضمن الدقة الكاملة لكل تنسيق ملف.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

النتيجة المتوقعة هي `900.0 x 600.0 points` و `Size preserved: true`. يتحقق التحقق من عرض تقديمي مُفتح حديثًا من صحة الملف المحفوظ، وليس فقط من الإعدادات في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة لتصميمات الملاحظات أو النشرات. لا تمكّن هذه الأبعاد تلك التصاميم بحد ذاتها: يجب أيضًا تكوين خيارات التصدير. يستمر تصدير الشرائح العادية في استخدام أبعاد الشرائح.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) إلى [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) لتضمين الملاحظات في ملف PDF. يُظهر هذا المثال أيضًا معالجة الشريحة الأولى التي تحتوي على ملاحظات إلى PNG باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) و[RenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/renderingoptions/).

وضع [BottomTruncated](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notespositions/) يبقي الملاحظات في صفحة واحدة؛ يمكن قطع الملاحظات التي لا تتسع. يستخدم PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المذكور أدناه، يكون حجم PNG 900 × 600 بكسل. النقاط تصف هندسة الصفحة؛ البكسل يصف الناتج الرقمي، والذي يعتمد أيضًا على مقياس التقديم.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

للتصدير إلى PDF مع ملاحظات طويلة، يتيح وضع [BottomFull](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notespositions/) إضافة صفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء صورة شريحة واحدة المذكور أعلاه، لأنه لا يدعمه. بعد تغيير الحجم، تحقق من المخرجات للعثور على ملاحظات مقطوعة وموقع كائنات notes‑master الموجودة؛ لا ينبغي اعتبار تغيير أبعاد الصفحة ضمانًا لتناسب جميع المحتويات. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/androidjava/convert-powerpoint-to-pdf-with-notes/) للمزيد حول تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handoutlayoutingoptions/) لإنشاء عدة صور مصغرة للشرائح على صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handouttype/) لترتيب ما يصل إلى أربع شرائح لكل صفحة. يحدد الإعداد الأفقي ترتيب الشرائح؛ يأتي توجّه الصفحة من عرضها وارتفاعها.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرة دون تغيير أبعاد الشرائح المصدرية. بالنسبة لصور النشرة، استخدم [Presentation.getImages](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) مع تخطيط النشرة، بدلاً من طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم تقديم النشرة على مستوى العرض أبعاد صفحة الملاحظات، بينما لا ينتج استدعاء صورة شريحة فردية صفحة النشرة. راجع [Handout Mode](/slides/ar/androidjava/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في العارضات، التصدير، والطباعة**

احتفظ بتمييز حجم العرض المخزن، حجم الصفحة المُصدّر، وحجم الورق المطبوع:

- **عارضات العروض:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد تخطيطه الخاصة. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد يقوم تحويل تنسيق ذلك التطبيق بتوحيدها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المكوّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس تقديم، لذا قد تُقرب القيم الكسرية للنقطة في مخرجات الصور. لا يطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **برامج تشغيل الطابعات:** يمكن لاختيار الورق، والتدوير التلقائي، وإعدادات الملاءمة إلى الصفحة أن تغير المخرجات الفعلية دون تغيير الأبعاد المخزَّنة في العرض أو PDF. للحصول على حجم ورق محدد، طابق إعدادات الطابعة وتحقق من معاينة الطباعة.

## **الأسئلة المتكررة**

**هل يمكنني تعيين حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن للشرائح الفردية أن تحتوي على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يغيّر تغيير توجّه الملاحظات شرائحي؟**

لصفحات الملاحظات والشرائح العادية أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

أعد فتح العرض التقديمي المحفوظ وقارن أبعاد ملاحظاته. إذا تغيرت، تحقق مما إذا كان حفظ أو تحويل الملف في تطبيق آخر قد غير إعدادات الصفحة. إذا لم يحدث ذلك، افحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.