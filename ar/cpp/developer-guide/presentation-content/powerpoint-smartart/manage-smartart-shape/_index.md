---
title: إدارة رسومات SmartArt في العروض التقديمية باستخدام C++
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/cpp/manage-smartart-shape/
keywords:
- كائن SmartArt
- رسم SmartArt
- نمط SmartArt
- لون SmartArt
- إنشاء SmartArt
- إضافة SmartArt
- تحرير SmartArt
- تغيير SmartArt
- الوصول إلى SmartArt
- نوع تخطيط SmartArt
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام C++ وAspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
Aspose.Slides لـ C++ يتيح الآن إضافة أشكال SmartArt مخصصة إلى الشرائح من الصفر. لقد وفرت Aspose.Slides لـ C++ أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بأبسط طريقة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType له.
- حفظ العرض المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **الوصول إلى شكل SmartArt على شريحة**
سيتم استخدام الشفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض. في الشفرة النموذجية سنستعرض كل شكل داخل الشريحة ونتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى كائن SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **الوصول إلى شكل SmartArt بنوع Layout محدد**
ستساعد الشفرة النموذجية التالية في الوصول إلى شكل SmartArt بنوع Layout محدد. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- التحقق من شكل SmartArt بنوع Layout محدد والقيام بما يلزم بعد ذلك.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **تغيير نمط شكل SmartArt**
ستساعد الشفرة النموذجية التالية في الوصول إلى شكل SmartArt بنوع Layout محدد.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- العثور على شكل SmartArt بنمط معين.
- تعيين النمط الجديد لشكل SmartArt.
- حفظ العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. ستقوم الشفرة النموذجية التالية بالوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط اللون الجديد لشكل SmartArt.
- حفظ العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **الأسئلة المتكررة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/cpp/powerpoint-animation/) عبر واجهة برمجة تطبيقات الرسوم المتحركة (الدخول، الخروج، التشديد، مسارات الحركة) تمامًا كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt معين في شريحة إذا لم أكن أعرف معرّفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) والبحث عن الشكل باستخدام تلك القيمة — هذه طريقة موصى بها لتحديد موقع الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/cpp/group/).

**كيف أحصل على صورة لSmartArt معين (مثلًا للمعاينة أو التقرير)؟**

تصدير صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [رسم الأشكال الفردية](/slides/ar/cpp/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل العرض الكامل إلى PDF؟**

نعم. محرك العرض يهدف إلى دقة عالية عند [تصدير PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.