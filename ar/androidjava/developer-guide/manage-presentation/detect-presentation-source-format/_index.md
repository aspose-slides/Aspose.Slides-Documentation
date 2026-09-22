---
title: تحديد تنسيق العرض التقديمي الأصلي على Android
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/androidjava/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- اكتشاف تنسيق العرض التقديمي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "قراءة تنسيق العرض التقديمي الأصلي المحمل على Android باستخدام Aspose.Slides للأندرويد عبر Java، ومقارنة واجهات برمجة الكشف، ومعالجة الملفات، والتيارات، والصيغ القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSourceFormat--) لتحديد تنسيقه الأصلي. الطريقة متوفرة أيضاً عبر [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). استخدمها عندما يعتمد المعالجة اللاحقة على التنسيق الذي تم تحميل المثيل الحالي منه.

تنسيق المصدر مختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) المحدد لملف الإخراج. حفظ الملف بتنسيق آخر لا يغيّر تنسيق المصدر للمثيل الحالي.

الأمثلة تستخدم جافا ومسارات ملفات. على Android، استبدل مسارات العينة بمسارات في التخزين المتاح للتطبيق، مثل دليل الملفات الداخلية لتطبيقك.

## **قراءة تنسيق المصدر للملف**

يتطلب هذا المثال وجود ملف `sample.pptx` موجود. يقوم بتحميل الملف ويختار سياسة معالجة تطبيقية باستخدام [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSourceFormat--) بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة صيغ أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

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

تعرّف الفئة [SourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sourceformat/) الثوابت الرقمية التي تميز صيغ العروض التقديمية التالية. الامتدادات أدناه هي امتدادات تقليدية، ليست إعادة إنشاء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | التنسيق |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML مع تمكين الماكرو |
| `Pps` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شرائح Office Open XML |
| `Ppsm` | `.ppsm` | عرض شرائح Office Open XML مع تمكين الماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML مع تمكين الماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب عرض OpenDocument |
| `Fodp` | `.fodp` | عرض OpenDocument بنظام XML مسطح |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة تنسيق المصدر من تدفق**

يتطلب هذا المثال وجود ملف `sample.pps` موجود. قراءة بايته في تدفق ذاكرة يحاكي إدخالًا يُستلم دون اسم ملف، مثل قيمة في قاعدة بيانات أو مصفوفة بايت تم رفعها. يتلقى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) التدفق فقط.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

تستخدم PPT و PPS و POT نفس تنسيق البايت الثنائي الأساسي. عند التحميل عبر مسار ملف، يمكن للامتداد أن يساعد في تمييز عرض شرائح أو قالب. بدون اسم ملف، قد يُبلّغ المحتوى القديم لـ PPS و POT كـ `SourceFormat.Ppt`؛ المثال السابق للـ PPS يطبع القيمة الرقمية لـ `SourceFormat.Ppt`.

إذا كان تطبيقك بحاجة إلى الحفاظ على هذا التمييز، احتفظ باسم الملف الأصلي أو ببيانات تعريف فرعية منفصلة. الامتداد يُعد تلميحًا مفيدًا لهذه الأنواع القديمة، لكنه لا ينبغي أن يكون الأساس الوحيد لتحديد محتوى العرض التقديمي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض التقديمي بالكامل. استخدم [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSourceFormat--) عندما يكون المثيل موجودًا بالفعل.

يتطلب هذا المثال وجود `sample.pptx` ويطبع القيم الرقمية لـ `LoadFormat.Pptx` و `SourceFormat.Pptx` على التوالي. في الإنتاج، اختر الـ API المناسب لمرحلة المعالجة الخاصة بك؛ لا يحتاج العرض المُحمَّل بالفعل إلى فحص ثانٍ فقط للحصول على تنسيق المصدر.

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

النتائج تستخدم الثوابت من فئات مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sourceformat/). لا تقارن قيمها الرقمية ولا تفترض أن لكل تنسيق نتائج كشف متطابقة. قد يُبلّغ PowerPoint XML كـ `LoadFormat.Unknown` قبل التحميل و`SourceFormat.Xml` بعد التحميل.

## **حافظ على تنسيقات المصدر والإخراج منفصلة**

يتطلب هذا المثال وجود `sample.pptx` ويكتب `converted.odp`. يطبع القيمة الرقمية لـ `SourceFormat.Pptx` قبل وبعد حفظ المثيل الأصلي. فقط المثيل الجديد المحمَّل من مخرجات ODP يُبلّغ `Odp`.

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

العرض الذي يُنشأ من الصفر باستخدام `new Presentation()` يُبلّغ `SourceFormat.Pptx`. لا يمتلك ملفًا إدخاليًا: هذه هي القيمة الافتراضية لمثيل تم إنشاؤه حديثًا، وليست دليلًا على أنه تم تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ المثيل أو حمّله منفصلًا إذا كان هذا التمييز مهمًا.

## **تحويل تنسيق المصدر إلى امتداد**

يتطلب المثال التالي وجود `sample.pptx`. يربط كل قيمة مدعومة حاليًا في [SourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sourceformat/) بامتداد تقليدي، دون تحليل اسم الملف الإدخالي. يضمن fallback عدم تعيين امتداد بصمت لقيمة غير معروفة.

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

هذا الربط لا يُحوّل ملفًا ولا يستعيد نوع فرعي قديم PPS/POT فقد أثناء تحميل التدفق. للحفظ الفعلي، حدد [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من الصيغ عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلًا الملفات ذات الأسماء نفسها. يعيد فتح كل مخرجات إما عبر المسار أو عبر تدفق ذاكرة. بالنسبة لـ PPTX و ODP، كلا الطريقين يُبلغان عن التنسيق المحفوظ. بالنسبة لـ PPS، يُبلغ التحميل عبر المسار عن `Pps`، بينما التحميل من نفس البايتات دون اسم ملف يُبلّغ عن `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

يلخص الجدول التالي تحديد تنسيق المصدر للعروض التقديمية ذات الامتدادات المتطابقة. الأسماء تمثل ثوابت؛ الأمثلة بجافا تطبع قيمها الرقمية:

| تنسيق الحفظ | SourceFormat من مسار ملف | SourceFormat من تدفق بدون اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | نفس قيمة مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | نفس قيمة مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | نفس قيمة مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | نفس قيمة مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوى PPS/POT يُعرّف كـ `Ppt` للتدفقات المنزوعة الأسماء. يصف الجدول تحديد الصيغ، لا الحفاظ على كل ميزة للعرض أثناء التحويل.

## **الأسئلة الشائعة**

**هل حفظ الملف بصيغة ODP يغيّر تنسيق المصدر لعرض تم تحميله من PPTX؟**

لا. المثيل الحالي لا يزال يُبلّغ `Pptx`. المثيل المحمَّل من ملف ODP المحفوظ يُبلّغ `Odp`.

**هل يمكن للتدفق دائمًا تمييز عرض قديم عن عرض شرائح أو قالب؟**

لا. تشترك PPT و PPS و POT في نفس تنسيق البايت الثنائي. احتفظ باسم الملف أو بيانات تعريف فرعية منفصلة عندما يكون هذا التمييز مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض مُحمَّلاً بالفعل؟**

اقرأ [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSourceFormat--). استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) للفحص قبل التحميل.