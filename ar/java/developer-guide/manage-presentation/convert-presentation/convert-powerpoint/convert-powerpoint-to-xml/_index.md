---
title: تحويل عروض PowerPoint إلى XML في Java
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات PowerPoint XML في Java باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java تحويل عروض PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض التقديمي، واستكشاف مستندات تم إنشاؤها، ومقارنة الناتج في الاختبارات الآلية، أو التكامل مع سير عمل يستهلك XML بدلاً من حزمة العرض التقديمي.

استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) مع القيمة `Xml` من فئة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/). يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` ينشئ PowerPoint XML Presentation. لا يقوم باستخراج أجزاء Office Open XML الفردية المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا مصدرًا باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، ثم مرّر مسار الإخراج و `SaveFormat.Xml` إلى [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

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

## **كتابة إخراج XML إلى تدفق**

استخدم نسخة التدفق من [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) عندما يجب أن يبقى XML في الذاكرة أو يُمرَّر إلى مكوّن آخر، مثل خدمة ويب، موفر تخزين، أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) ويحصل على XML الناتج كمصفوفة بايت:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // مرر xmlData إلى المكوّن التالي في سير العمل.
} finally {
    presentation.dispose();
}
```

## **مقارنة XML مع تنسيقات العرض وتنسيقات التصدير**

اختر تنسيق الإخراج وفقًا للطريقة التي سيُستخدم بها النتيجة:

| التنسيق | المخرجات | الاستخدام الشائع |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض PowerPoint XML | فحص الهيكل، استكشاف الأخطاء، مقارنة الناتج المُولَّد، والتكامل المبني على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint الأقدم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على أجزاء متعددة | تحرير PowerPoint المعتاد وتبادل العروض التقديمية |
| PDF أو TIFF | صفحات ذات تخطيط ثابت أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG، JPEG، أو SVG | تمثيل مرسوم لشريحة فردية | مصغرات، معاينات، وأصول صور |
| HTML أو HTML5 | إخراج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT و PPTX، يُقصد من إخراج XML أساسًا للفحص وسير العمل الموجه للبيانات. وعلى عكس PDF و TIFF و HTML وتنسيقات صور الشرائح، فهو يمثل بيانات العرض بدلاً من رسم الشرائح كصفحات أو أصول بصرية. تُظهر جدول [قائمة تنسيقات الملفات المدعومة](/slides/ar/java/supported-file-formats/) أن PowerPoint XML Presentation هو تنسيق حفظ فقط، لذا لا تُستخدم عندما يتطلب سير العمل تحميل الملف المُصدَّر مرة أخرى إلى Aspose.Slides للتحرير المستمر.

## **الأسئلة المتكررة**

**هل `SaveFormat.Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هو حزمة تحتوي على عدة أجزاء من Office Open XML، بينما `SaveFormat.Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). على سبيل المثال، استخدم [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدَّر مرة أخرى؟**

لا. PowerPoint XML Presentation مدعوم حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو أي تنسيق عرض مدعوم آخر عندما تكون الحاجة إلى تحرير ذهابًا وإيابًا.

**هل يقوم تحويل XML برسم كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض منظمة. استخدم PDF أو TIFF لإخراج موجه للصفحات، أو PNG و JPEG و SVG لصور الشرائح الفردية.