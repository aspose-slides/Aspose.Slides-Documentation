---
title: تحويل عروض PowerPoint إلى XML في .NET
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى ملفات XML لعروض PowerPoint أو إلى تدفقات باستخدام C# مع Aspose.Slides لـ .NET."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET تحويل عروض PowerPoint إلى تنسيق عرض PowerPoint XML. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض، استكشاف المشكلات في المستندات المولدة، مقارنة النتائج في الاختبارات الآلية، أو التكامل مع سير عمل يستهلك XML بدلاً من حزمة عرض.

استخدم طريقة [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) مع القيمة `Xml` من تعداد [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). يمكنك كتابة النتيجة مباشرة إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` ينشئ عرض PowerPoint XML. لا يستخرج الأجزاء الفردية لـ Office Open XML المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض إلى ملف XML**

حمّل عرضًا مصدرًا باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم مرّر مسار الإخراج و`SaveFormat.Xml` إلى [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). يمكن أن يكون المصدر بأي تنسيق عرض يدعم التحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **كتابة إخراج XML إلى تدفق**

استخدم overload الخاص بالتدفق من [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) عندما يجب أن يبقى XML في الذاكرة أو يُمرر إلى مكوّن آخر، مثل خدمة ويب، موفر تخزين، أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) ويعيد وضعه للقراءة اللاحقة:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// مرر xmlStream إلى المكوّن التالي في سير العمل.
```

## **مقارنة XML مع صيغ العرض والتصدير**

اختر صيغة الإخراج وفقًا لكيفية استخدام النتيجة:

| الصيغة | الإخراج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض PowerPoint XML | فحص البنية، استكشاف الأخطاء، مقارنة الإخراج المُولد، وتكامل قائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint القديم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض |
| PDF أو TIFF | صفحات ذات تخطيط ثابت أو صور TIFF | العرض والطباعة والأرشفة |
| PNG أو JPEG أو SVG | تمثيل مرسوم لشريحة فردية | صُغَر، معاينات، وأصول الصور |
| HTML أو HTML5 | إخراج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT وPPTX، يُقصد بإخراج XML أساسًا للفحص وعمليات سير العمل القائمة على البيانات. وعلى عكس PDF وTIFF وHTML وصيغ صور الشرائح، يمثل بيانات العرض بدلاً من رسم الشرائح كصفحات أو أصول بصرية. جدول [قائمة صيغ الملفات المدعومة](/slides/ar/net/supported-file-formats/) يوضح كل صيغة يمكن لـ Aspose.Slides تحميلها أو استيرادها أو حفظها أو عرضها.

## **الأسئلة المتكررة**

**هل `SaveFormat.Xml` هو نفس حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على عدة أجزاء من Office Open XML، بينما `SaveFormat.Xml` ينشئ ملف عرض PowerPoint XML.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). على سبيل المثال، استخدم [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدّر مرة أخرى؟**

نعم. مرّر ملف XML أو تدفق إلى مُنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). ثم تُرجع الخاصية [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) القيمة `SourceFormat.Xml`. تُبلغ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) عن `LoadFormat.Unknown` لهذا التنسيق، لذا لا تستخدمه لتحديد ما إذا كان يمكن فتح ملف XML.

**هل تحويل XML يرسم كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض مُهيكلة. استخدم PDF أو TIFF للإخراج الموجه للصفحات، أو PNG أو JPEG أو SVG للصور الفردية للشرائح.