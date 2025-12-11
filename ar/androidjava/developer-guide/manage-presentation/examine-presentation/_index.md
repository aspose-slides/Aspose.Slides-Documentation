---
title: استرداد وتحديث معلومات العرض التقديمي على Android
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument التقديمية باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---

Aspose.Slides for Android via Java يسمح لك بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="Info" color="info" %}} 

تحتوي فئتا PresentationInfo و DocumentProperties على الخصائص والطرق المستخدمة في العمليات هنا.

{{% /alert %}} 

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT أو PPTX أو ODP أو غيرها) الذي يكون فيه العرض التقديمي في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. شاهد هذا الكود Java:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **الحصول على خصائص العرض التقديمي**

يعرض لك هذا الكود Java كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```


قد ترغب في رؤية الخصائص ضمن فئة DocumentProperties.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة PresentationInfo.updateDocumentProperties التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند المعروضة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يعرض لك مثال الشفرة هذا كيفية تعديل بعض خصائص العرض التقديمي:
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


تظهر النتائج التي تم الحصول عليها من تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض مشفرًا](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض محميًا من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض محمياً بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأية خطوط هي؟**

ابحث عن [معلومات الخطوط المضمّنة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) لتحديد الخطوط الحيوية للعرض.

**كيف يمكنني معرفة بسرعة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تصفح [مجموعة الشرائح](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) وتفقد [علامة الرؤية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه شريحة مخصص، وما إذا كان يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) الحالي و[الاتجاه](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) مع الإعدادات القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) الخاص بها، وحدد ما إذا كانت البيانات داخلية أو معتمدة على روابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، الشفافية، الظلال، الرسوم المتحركة والوسائط المتعددة؛ ثم أعطِ درجة تعقيد تقريبية لتحديد النقاط الساخنة المحتملة للأداء.