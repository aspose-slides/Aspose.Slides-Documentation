---
title: استرجاع وتحديث معلومات العرض التقديمي على Android
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. توضح كيفية تحديد تنسيق العرض التقديمي الحالي دون تحميل الملف بالكامل، قراءة خصائص المستند الخاصة به، وتحديث تلك الخصائص عند الحاجة.

تعتمد الأمثلة على واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/documentproperties/) وتعرض عمليات نموذجية للعمل مع البيانات الوصفية للعرض التقديمي.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT، PPTX، ODP، وغيرها) الذي يُوجد به العرض التقديمي في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود Java:

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

يُظهر لك هذا الكود Java كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

قد ترغب في رؤية [properties under the DocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) الفئة.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![Original document properties of the PowerPoint presentation](input_properties.png)

يُظهر لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:

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

تظهر نتائج تغيير خصائص المستند أدناه.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/androidjava/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأيها؟**

ابحث عن معلومات [embedded-font information](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [fonts actually used across content](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/#getFonts--) لتحديد الخطوط الحاسمة للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

استعرض مجموعة [slide collection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidecollection/) وتفقد علامة [visibility flag](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#getHidden--) لكل شريحة.

**هل يمكنني اكتشاف ما إذا كان حجم الشريحة المخصص والاتجاه مستخدمين، وما إذا كانا مختلفين عن الافتراضيات؟**

نعم. قارن [slide size](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlideSize--) والاتجاه الحاليين مع الإعدادات القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [charts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chart/)، وتحقق من [data source](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) الخاص بها، وحدد ما إذا كانت البيانات داخلية أو مرتبطة بروابط، مع ملاحظة أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح «الثقيلة» التي قد تبطئ العرض أو تصدير PDF؟**

لكل شريحة، احصر عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، رسوم متحركة، ووسائط متعددة؛ ثمّ ضع تقييمًا تقريبيًا للتعقيد لتحديد نقاط الضغط المحتملة في الأداء.