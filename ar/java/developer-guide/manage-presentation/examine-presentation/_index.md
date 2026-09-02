---
title: استرجاع وتحديث معلومات العرض التقديمي في Java
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/java/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint و OpenDocument باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

توضح هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. وتشرح كيفية تحديد تنسيق العرض الحالي دون تحميل الملف بالكامل، وقراءة خصائص المستند الخاصة به، وتحديث تلك الخصائص عند الحاجة.

تعتمد الأمثلة على واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/documentproperties/) وتُظهر عمليات نمطية للعمل مع بيانات تعريف العرض التقديمي.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود بلغة Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **الحصول على خصائص العرض التقديمي**

يعرض هذا الكود بلغة Java كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يعرض مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

تُظهر النتائج الناتجة عن تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد الروابط التالية مفيدة:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/java/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/java/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأي منها؟**

ابحث عن [معلومات الخطوط المضمّنة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsmanager/#getFonts--) لتحديد الخطوط الضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وكم عددها؟**

قم بالتكرار عبر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/) وتفحص علامة [الظهور](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#getHidden--) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه مخصصين للشرائح، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlideSize--) الحالي والاتجاه مع الإعدادات المسبقة القياسية؛ فهذا يساعد على توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. تجول عبر جميع [المخططات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/)، وتحقق من [مصدر البيانات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getDataSourceType--) الخاص بها، ولاحظ ما إذا كانت البيانات داخلية أم مستندة إلى روابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، رسومات متحركة، ووسائط متعددة؛ ثم أعطِ درجة تعقيد تقريبية لتحديد نقاط الضعف المحتملة في الأداء.