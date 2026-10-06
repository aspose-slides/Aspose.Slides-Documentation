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
description: "تحويل عروض PowerPoint وعروض OpenDocument إلى ملفات XML لعروض PowerPoint أو تدفقات في Java باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java تحويل عروض PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض التقديمي، أو استكشاف المشكلات في المستندات التي تم إنشاؤها، أو مقارنة النتائج في الاختبارات الآلية، أو دمجها مع تدفق عمل يستهلك XML بدلاً من حزمة عرض تقديمي.

استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) مع القيمة `Xml` من فئة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/). يمكنك كتابة النتيجة مباشرة إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` ينشئ PowerPoint XML Presentation. لا يستخرج أجزاء Office Open XML الفردية المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص الحزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا أصليًا باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ، ثم مرّر مسار الإخراج و`SaveFormat.Xml` إلى [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

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

استخدم نسخة الدفق من [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) عندما يجب أن يبقى XML في الذاكرة أو يُمرّر إلى مكوّن آخر، مثل خدمة ويب أو موفر تخزين أو خط معالجة XML. المثال التالي يكتب النتيجة إلى [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) ويحصل على XML الناتج كمصفوفة بايت:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // تمرير xmlData إلى المكوّن التالي في سير العمل.
} finally {
    presentation.dispose();
}
```

## **مقارنة XML مع صيغ العرض وصيغ التصدير**

اختر صيغة الإخراج بحسب كيفية استخدام النتيجة:

| الصيغة | الإخراج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | فحص البنية، استكشاف المشكلات، مقارنة النتائج التي تم إنشاؤها، وتكامل قائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | توافق مع تدفقات عمل PowerPoint القديمة |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض |
| PDF أو TIFF | صفحات ذات تخطيط ثابت أو صورة متعددة الصفحات | عرض، طباعة، وأرشفة |
| PNG أو JPEG أو SVG | تمثيل مرسوم لشريحة فردية | صور مصغرة، معاينات، وموارد صور |
| HTML أو HTML5 | إخراج عرض موجه للويب | عرض في المتصفح ونشر الويب |

على عكس PPT و PPTX، يُقصد بإخراج XML في المقام الأول للفحص وتدفقات العمل القائمة على البيانات. وعلى عكس PDF و TIFF و HTML وصيغ صور الشرائح، فهو يمثل بيانات العرض بدلاً من تصيير الشرائح كصفحات أو أصول بصرية. جدول [supported file formats](/slides/ar/java/supported-file-formats/) يدرج كل صيغة يمكن لـ Aspose.Slides تحميلها أو استيرادها أو حفظها أو تصييرها.

## **الأسئلة الشائعة**

**هل `SaveFormat.Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على عدة أجزاء Office Open XML، بينما `SaveFormat.Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). على سبيل المثال، استخدم [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدّر مرة أخرى؟**

نعم. مرّر ملف XML أو تدفق إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). ثم تُعيد [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--) القيمة `SourceFormat.Xml`. تُظهر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) `LoadFormat.Unknown` لهذه الصيغة، لذا لا تُستخدم لتحديد ما إذا كان يمكن فتح ملف XML.

**هل يقوم تحويل XML بتصيير كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض مُنظمة. استخدم PDF أو TIFF لإخراج موجه للصفحات، أو PNG أو JPEG أو SVG للحصول على صور شرائح فردية.