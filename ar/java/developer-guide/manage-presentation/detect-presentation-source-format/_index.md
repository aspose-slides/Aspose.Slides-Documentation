---
title: تحديد تنسيق العرض التقديمي الأصلي في Java
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/java/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- اكتشاف تنسيق العرض التقديمي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- Java
- Aspose.Slides
description: "قراءة التنسيق الأصلي لعرض تم تحميله في Java باستخدام Aspose.Slides for Java، ومقارنة واجهات كشف التنسيق، ومعالجة الملفات، التدفقات، والتنسيقات القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--) لتحديد تنسيقه الأصلي. الطريقة متاحة أيضًا عبر [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSourceFormat--). استخدمها عندما يعتمد المعالجة اللاحقة على التنسيق الذي تم تحميل المثيل الحالي منه.

تنسيق المصدر يختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) المختار لملف الإخراج. حفظ الملف بتنسيق آخر لا يغيّر تنسيق المصدر للمثيل الحالي.

## **قراءة تنسيق المصدر لملف**

يتطلب هذا المثال وجود ملف `sample.pptx` موجود. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--) بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة تنسيقات أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **التعرف على القيم المدعومة**

الفئة [SourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sourceformat/) تُعرّف ثوابت عددية تميز تنسيقات العرض التقديمي التالية. الامتدادات أدناه هي امتدادات شائعة، وليس إعادة بناء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | الصيغة |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML يدعم الماكرو |
| `Pps` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شرائح Office Open XML |
| `Ppsm` | `.ppsm` | عرض شرائح Office Open XML يدعم الماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML يدعم الماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب OpenDocument |
| `Fodp` | `.fodp` | عرض OpenDocument XML مسطّح |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة تنسيق المصدر لتدفق بيانات**

يتطلب هذا المثال وجود ملف `sample.pps` موجود. قراءة بايتاته إلى تدفق ذاكرة تُحاكي الإدخال المستلم بدون اسم ملف، مثل قيمة في قاعدة بيانات أو مصفوفة بايتات تم رفعها. يتلقى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) التدفق فقط.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT وPPS وPOT تستخدم نفس التنسيق الثنائي الأساسي. عند التحميل عبر مسار الملف، يمكن للامتداد أن يساعد في تمييز عرض شرائح أو قالب. بدون اسم ملف، قد يُبلّغ محتوى PPS أو POT القديم كـ `SourceFormat.Ppt`؛ مثال PPS أعلاه يطبع القيمة العددية لـ `SourceFormat.Ppt`.

إذا كان تطبيقك بحاجة للحفاظ على هذا التمييز، احتفظ باسم الملف الأصلي أو بيانات التعريف الفرعية منفصلة. الامتداد يُعد تلميحًا مفيدًا لهذه الأنواع القديمة، لكنه لا ينبغي أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض التقديمي بالكامل. استخدم [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--) عندما يكون المثيل موجودًا بالفعل.

يتطلب هذا المثال `sample.pptx` ويطبع القيم العددية لـ `LoadFormat.Pptx` و`SourceFormat.Pptx` على التوالي. في الإنتاج، اختر الـ API المناسب لمرحلة المعالجة؛ العرض المحمَّل مسبقًا لا يحتاج فحصًا ثانيًا فقط للحصول على تنسيق المصدر.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

النتائج تستخدم ثوابت من فئات مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadformat/) و[SourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sourceformat/). لا تقارن القيم العددية بينها ولا تفترض أن كل تنسيق يملك نتائج كشف متماثلة. يمكن الإبلاغ عن PowerPoint XML كـ `LoadFormat.Unknown` قبل التحميل و`SourceFormat.Xml` بعد التحميل.

## **الحفاظ على تنسيقات المصدر والإخراج منفصلة**

يتطلب هذا المثال `sample.pptx` ويكتب `converted.odp`. يطبع القيمة العددية لـ `SourceFormat.Pptx` قبل وبعد حفظ المثيل الأصلي. فقط المثيل الجديد المحمل من إخراج ODP يُبلغ عن `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

العرض الذي يُنشئ من الصفر باستخدام `new Presentation()` يُبلغ عن `SourceFormat.Pptx`. لا يوجد ملف إدخال: هذه هي القيمة الافتراضية لمثيل تم إنشاؤه حديثًا، ولا دليل على أن ملف PPTX تم تحميله. تتبع ما إذا كان تطبيقك قد أنشأ أو حمَّل المثيل بشكل منفصل إذا كان هذا التمييز مهمًا.

## **تحويل تنسيق المصدر إلى امتداد**

يتطلب المثال التالي `sample.pptx`. يُحوِّل كل قيمة [SourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sourceformat/) مدعومة حاليًا إلى امتداد شائع، دون تحليل اسم الملف الإدخالي. الفallback يتجنب إسناد امتداد بصمت لقيمة غير معروفة.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

هذا التحويل لا يُحوّل الملف ولا يستعيد نوع PPS/POT القديم الذي فقد أثناء تحميل التدفق. للحفظ الفعلي، حدد [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/java/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من التنسيقات عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلًا الملفات ذات الأسماء نفسها. يعيد فتح كل إخراج عبر المسار ومن خلال تدفق ذاكرة. بالنسبة لـ PPTX وODP، كلا المسارين يُبلغان عن التنسيق المحفوظ. بالنسبة لـ PPS، التحميل عبر المسار يُبلغ عن `Pps`، بينما تحميل نفس البايتات بدون اسم ملف يُبلغ عن `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

الجدول التالي يلخّص تعريف تنسيق المصدر للعرض التقديمي مع امتدادات مطابقة. الأسماء تُشير إلى الثوابت؛ أمثلة Java تطبع القيم العددية لها:

| تنسيق الحفظ | SourceFormat من مسار ملف | SourceFormat من تدفق بلا اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | نفس ما هو في مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | نفس ما هو في مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | نفس ما هو في مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | نفس ما هو في مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوى PPS/POT يُعرف كـ `Ppt` في التدفقات بلا اسم. يصف الجدول طريقة تعريف التنسيق، لا حفظ جميع ميزات العرض أثناء التحويل.

## **الأسئلة المتكررة**

**هل حفظ الملف إلى ODP يغيّر تنسيق المصدر للعرض المحمَّل من PPTX؟**

لا. المثيل الحالي لا يزال يُبلغ عن `Pptx`. المثيل المحمَّل من ملف ODP المحفوظ يُبلغ عن `Odp`.

**هل يستطيع التدفق دائمًا تمييز عرض تقديمي قديم، عرض شرائح، أو قالب؟**

لا. PPT وPPS وPOT تشترك في نفس التنسيق الثنائي. احتفظ باسم الملف أو بيانات التعريف الفرعية منفصلة عندما يكون هذا التمييز مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض قد تم تحميله بالفعل؟**

اقرأ [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--). استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) للفحص قبل التحميل.