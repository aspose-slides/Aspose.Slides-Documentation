---
title: تحويل عروض PowerPoint إلى XML في JavaScript
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/nodejs-java/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- عرض PowerPoint XML
- SaveFormat.Xml
- حفظ العرض كـ XML
- تصدير العرض إلى XML
- تدفق XML
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى ملفات أو تدفقات PowerPoint XML في JavaScript باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمكنه تحويل عروض PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض، حل المشكلات في المستندات المولدة، مقارنة الإخراج في الاختبارات الآلية، أو الاندماج مع سير عمل يستهلك XML بدلاً من حزمة عرض تقديمي.

استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) مع القيمة `Xml` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` ينشئ PowerPoint XML Presentation. لا يستخرج الأجزاء الفردية من Office Open XML المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

قم بتحميل عرض تقديمي مصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، ثم مرّر مسار الإخراج و`SaveFormat.Xml` إلى [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save). يمكن أن يكون المصدر بأي تنسيق عرض تقديمي مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض تقديمي PPTX إلى ملف XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **كتابة إخراج XML إلى تدفق**

استخدم نسخة التدفق من [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) عندما يحتاج XML إلى البقاء في الذاكرة أو تمريره إلى مكوّن آخر، مثل خدمة ويب، موفر تخزين، أو أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى `ByteArrayOutputStream` في Java وينسخ البيانات المولدة إلى `Buffer` في Node.js:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // تمرير xmlBuffer إلى المكوّن التالي في سير العمل.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **مقارنة XML مع تنسيقات العرض وتصديرها**

اختر تنسيق الإخراج وفقًا لكيفية استخدام النتيجة:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | فحص البنية، حل المشكلات، مقارنة الإخراج المولد، والاندماج القائم على XML |
| PPT (`.ppt`) | ملف عرض تقديمي ثنائي قديم | التوافق مع سير عمل PowerPoint الأقدم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على أجزاء متعددة | تحرير PowerPoint العادي وتبادل العروض |
| PDF أو TIFF | صفحات ثابتة أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG أو JPEG أو SVG | تمثيل مرسوم لشفرة شريحة واحدة | صور مصغرة، معاينات، وأصول صور |
| HTML أو HTML5 | إخراج عرض تقديمي موجه للويب | عرض في المتصفح والنشر على الويب |

على عكس PPT وPPTX، يُقصد من إخرج XML أساسًا للفحص وسير العمل القائم على البيانات. وعلى عكس PDF وTIFF وHTML وتنسيقات صور الشرائح، فهو يمثل بيانات العرض بدلاً من تصيير الشرائح كصفحات أو أصول بصرية. جدول [supported file formats](/slides/ar/nodejs-java/supported-file-formats/) يدرج PowerPoint XML Presentation كتنسيق حفظ فقط، لذا لا تستخدمه عندما يتطلب سير العمل تحميل الملف المُصدّر مرة أخرى إلى Aspose.Slides للتحرير المتواصل.

## **الأسئلة المتكررة**

**هل `SaveFormat.Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على أجزاء Office Open XML متعددة، بينما `SaveFormat.Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلاً للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save). على سبيل المثال، استخدم `ByteArrayOutputStream` في Java وانسخ بياناته إلى `Buffer` في Node.js للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدّر مرة أخرى؟**

لا. PowerPoint XML Presentation مدعوم حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو تنسيق عرض تقديمي مدعوم آخر عندما يتطلب تحريرًا ذهابًا وإيابًا.

**هل تحول XML كل شريحة إلى صفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض منظمة. استخدم PDF أو TIFF للإخراج الموجه للصفحات، أو PNG أو JPEG وSVG لصور الشرائح الفردية.