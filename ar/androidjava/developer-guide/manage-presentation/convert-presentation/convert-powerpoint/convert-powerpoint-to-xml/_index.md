---
title: تحويل عروض PowerPoint إلى XML على Android
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/androidjava/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض التقديمي إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- عرض PowerPoint XML
- SaveFormat.Xml
- حفظ العرض التقديمي كـ XML
- تصدير العرض التقديمي إلى XML
- تدفق XML
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint وعروض OpenDocument إلى ملفات أو تدفقات PowerPoint XML على Android باستخدام Aspose.Slides."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android عبر Java تحويل عروض PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص هيكل العرض، واستكشاف المشكلات في المستندات التي تم إنشاؤها، ومقارنة الإخراج في الاختبارات الآلية، أو التكامل مع سير عمل يستهلك XML بدلاً من حزمة العرض.

استخدم الطريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) مع [SaveFormat.Xml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Xml). يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى دفق.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` ينشئ PowerPoint XML Presentation. لا يقوم باستخراج أجزاء Office Open XML الفردية المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.

{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

قم بتحميل عرض تقديمي المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ، ثممرر مسار الإخراج و[SaveFormat.Xml](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Xml) إلى [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **كتابة إخراج XML إلى دفق**

استخدم نسخة الدفق من [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) عندما يجب أن يبقى XML في الذاكرة أو يتم تمريره إلى مكون آخر، مثل خدمة ويب أو مزود تخزين أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) ويحصل على XML المُولد كمصفوفة بايت:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // تمرير xmlData إلى المكوّن التالي في سير العمل.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **مقارنة XML مع تنسيقات العرض والتصدير**

اختر تنسيق الإخراج وفقًا لكيفية استخدام النتيجة:

| الصيغة | الإخراج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض PowerPoint XML | فحص الهيكل، استكشاف المشكلات، مقارنة الإخراج المُولد، والتكامل القائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint القديم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض |
| PDF or TIFF | صفحات ثابتة التخطيط أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG, JPEG, or SVG | تمثيل مصور لشريحة فردية | صور مصغرة، معاينات، وأصول الصور |
| HTML or HTML5 | إخراج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT وPPTX، يُقصد من إخراج XML أساسًا للفحص وسير العمل القائم على البيانات. وعلى عكس PDF وTIFF وHTML وتنسيقات صور الشرائح، فهو يمثل بيانات العرض بدلاً من إنشاء صور للشرائح كصفحات أو أصول بصرية. تُظهر جدول [supported file formats](/slides/ar/androidjava/supported-file-formats/) أن PowerPoint XML Presentation هو تنسيق حفظ فقط، لذا لا تستخدمه عندما يحتاج سير العمل إلى تحميل الملف المصدَّر مرةً أخرى إلى Aspose.Slides للتحرير المتواصل.

## **الأسئلة الشائعة**

**هل `SaveFormat.Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على عدة أجزاء Office Open XML، بينما `SaveFormat.Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). على سبيل المثال، استخدم [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المصدَّر مرةً أخرى؟**

لا. يُدعم PowerPoint XML Presentation حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو تنسيق عرض مدعوم آخر عندما يكون تحريرًا ذهابًا وإيابًا مطلوبًا.

**هل تقوم تحويل XML بتصوير كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض مُنظمة. استخدم PDF أو TIFF لإخراج موجه للصفحات، أو PNG أو JPEG أو SVG لصور الشرائح الفردية.