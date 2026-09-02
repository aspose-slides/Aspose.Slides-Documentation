---
title: تحويل عروض PowerPoint إلى XML في .NET
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى ملفات XML أو تدفقات XML في C# باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET يمكنه تحويل عروض PowerPoint إلى تنسيق عرض PowerPoint XML. يعتبر إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص هيكل العرض، أو استكشاف الأخطاء في المستندات المُنشأة، أو مقارنة الإخراج في اختبارات آلية، أو الاندماج مع سير عمل يستهلك XML بدلاً من حزمة عرض.

استخدم طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) مع القيمة `Xml` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/). يمكنك كتابة النتيجة مباشرة إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` ينشئ عرض PowerPoint XML. لا يستخرج الأجزاء الفردية لـ Office Open XML المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء الحزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص الحزمة نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا مصدرًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، ثم مرّر مسار الإخراج و`SaveFormat.Xml` إلى [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **كتابة مخرجات XML إلى تدفق**

استخدم تحميل الدفق لـ [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) عندما يجب أن يبقى XML في الذاكرة أو يتم تمريره إلى مكون آخر، مثل خدمة ويب، أو موفر تخزين، أو خط معالجة XML. المثال التالي يكتب النتيجة إلى [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) ويعيد تموضعه للقراءة اللاحقة:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// مرّر xmlStream إلى المكوّن التالي في سير العمل.
```

## **مقارنة XML مع صيغ العرض والتصدير**

اختر صيغة الإخراج بناءً على كيفية استخدام النتيجة:

| الصيغة | المخرجات | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض PowerPoint XML | فحص الهيكل، استكشاف الأخطاء، مقارنة الإخراج المُنشأ، وتكامل قائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint الأقدم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض التقديمية |
| PDF أو TIFF | صفحات ثابتة التخطيط أو صورة متعددة الصفحات | العرض، الطباعة، والحفظ الأرشيفي |
| PNG أو JPEG أو SVG | تمثيل مُرسم لشريحة فردية | الصور المصغرة، المعاينات، وأصول الصورة |
| HTML أو HTML5 | مخرجات عرض موجهة للويب | العرض في المتصفح والنشر على الويب |

على عكس PPT و PPTX، يُقصد بإخراج XML أساسًا للفحص وسير العمل القائم على البيانات. وعلى عكس PDF و TIFF و HTML وصيغ صور الشرائح، فهو يمثل بيانات العرض بدلاً من رسم الشرائح كصفحات أو أصول بصرية. جدول [supported file formats](/slides/ar/net/supported-file-formats/) يدرج PowerPoint XML Presentation كصيغة حفظ فقط، لذا لا تستخدمه عندما يتوجب على سير العمل تحميل الملف المُصدَّر مرة أخرى إلى Aspose.Slides للتحرير المستمر.

## **الأسئلة المتكررة**

**هل `SaveFormat.Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هو حزمة تحتوي على عدة أجزاء Office Open XML، بينما `SaveFormat.Xml` ينشئ ملف عرض PowerPoint XML.

**هل يمكنني حفظ مخرجات XML دون إنشاء ملف على القرص؟**

نعم. مرّر دفقًا قابلًا للكتابة إلى [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). على سبيل المثال، استخدم [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) للمعالجة في الذاكرة.

**هل يستطيع Aspose.Slides تحميل ملف XML المُصدّر مرة أخرى؟**

لا. عرض PowerPoint XML مدعوم حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو أي صيغة عرض مدعومة أخرى عندما تكون الحاجة إلى تحرير ذهابًا وإيابًا.

**هل تحويل XML يرسم كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض منظمة. استخدم PDF أو TIFF للمخرجات الموجهة للصفحات، أو PNG أو JPEG أو SVG لصور الشرائح الفردية.