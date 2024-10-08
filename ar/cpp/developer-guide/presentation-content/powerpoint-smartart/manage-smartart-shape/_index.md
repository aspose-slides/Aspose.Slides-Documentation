---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /ar/cpp/manage-smartart-shape/
---


## **إنشاء شكل SmartArt**
تتيح Aspose.Slides لـ C++ الآن إضافة أشكال SmartArt مخصصة في الشرائح من الصفر. تقدم Aspose.Slides لـ C++ أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بطريقة سهلة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType الخاص به.
- كتابة العرض التقديمي المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في عينة الكود، سنتنقل عبر كل شكل داخل الشريحة ونتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt، فسنقوم بتحويله إلى مثيل SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
ستساعد عينة الكود التالية في الوصول إلى شكل SmartArt بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان من نوع SmartArt.
- التحقق من شكل SmartArt بنوع LayoutType معين وتنفيذ ما هو مطلوب بعد ذلك.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **تغيير نمط شكل SmartArt**
ستساعد عينة الكود التالية في الوصول إلى شكل SmartArt بنوع LayoutType معين.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان من نوع SmartArt.
- العثور على شكل SmartArt بنمط معين.
- تعيين النمط الجديد لشكل SmartArt.
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في عينة الكود التالية، سنقوم بالوصول إلى شكل SmartArt بنمط لون معين وسنقوم بتغيير نمطه.

- إنشاء مثيل من `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان من نوع SmartArt.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط اللون الجديد لشكل SmartArt.
- حفظ العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}