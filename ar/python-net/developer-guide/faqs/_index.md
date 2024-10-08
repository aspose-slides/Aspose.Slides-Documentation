---
title: الأسئلة المتداولة
type: docs
weight: 340
url: /ar/python-net/faqs/
keywords:
- الأسئلة المتداولة
- PowerPoint
- تنسيق العرض
- خطأ نفاد الذاكرة
- حجم الشريحة
- استخراج النص
- استرداد النص
- حجم الفقرة
- تنسيق الجداول
- خط
- بايثون
- Aspose.Slides لـ Python عبر .NET
---

## **تنسيقات الملفات المدعومة**

**س: ما هي تنسيقات الملفات التي يدعمها Aspose.Slides لـ Python عبر .NET؟**

**ج**: يدعم Aspose.Slides لـ Python عبر .NET تنسيقات الملفات التي تم وصفها في [التنسيقات المدعومة](/slides/ar/python-net/supported-file-formats/).

## **الاستثناءات**

**س: أحصل على استثناء نفاد الذاكرة أثناء تحميل ملف PPT كبير يحتوي على صور. هل توجد قيود في Aspose.Slides بخصوص حجم الملف؟**

**ج**: لا توجد صيغة محددة لحساب حجم العرض المدعوم من Aspose.Slides. يجب أن يكون هناك مساحة كافية لاستيعاب هيكل العرض بالكامل والصور في الذاكرة. عادةً ما تشغل الصور في الذاكرة مساحة أكبر من القرص الصلب، خاصةً عندما تحتوي الصور على تأثيرات إضافية.

بشكل عام، يمكن لـ Aspose.Slides لـ Python عبر .NET التعامل بسهولة مع ملفات العرض التي تبلغ حوالي 300 ميجابايت على خادم بذاكرة وصول عشوائي (RAM) سعتها 4 جيجابايت.

## **العمل مع الشرائح**

**س: هل يمكنني تغيير حجم الشرائح في عرض تقديمي؟**

**ج**: يمكنك استخدام خاصية `slide_size` التي تكشف عنها فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتعريف حجم الشرائح في عرض تقديمي.

**س: هل توجد طريقة لتعريف شرائح بأحجام مختلفة في عرض تقديمي؟**

**ج**: نظرًا لأن حجم الشرائح يتم تحديده على مستوى العرض في مستندات Microsoft PowerPoint، فلا توجد طريقة للقيام بذلك.

**س: هل يدعم Aspose.Slides لـ Python عبر .NET معاينة الشريحة قبل الحفظ؟**

**ج**: يمكنك عرض شرائح العرض على شكل صور ويمكنك استخدام هذه الصور لمعاينة الشرائح.

## **العمل مع النصوص**

**س: هل من الممكن استرداد كل النص من عرض تقديمي؟**

**ج**: يوفر Aspose.Slides لـ Python عبر .NET فئة [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) ضمن مساحة الأسماء `aspose.slides.util` التي تقدم طرقًا متنوعة لاسترداد النص بالكامل من العروض التقديمية.

**س: لماذا تختلف أحجام الفقرات على أنظمة التشغيل Windows وLinux؟**

**ج**: تعتمد حسابات أحجام الفقرات على حساب حجم النص الذي يمثل الفقرة المعطاة. يعتمد حساب حجم النص على قياسات الخط المحدد في العرض التقديمي لـ PowerPoint. إذا كان الخط المحدد مفقودًا، يتم استبداله بأقرب خط مشابه، لكن هذه الخطوط لديها قياسات تختلف عن القياسات الأصلية. ونتيجة لذلك، ستؤدي حسابات أحجام الفقرات في أنظمة مختلفة إلى نتائج مختلفة اعتمادًا على مجموعة الخطوط المثبتة. لتحقيق نفس النتيجة على أنظمة تشغيل مختلفة، تحتاج إلى تثبيت نفس الخطوط على الأنظمة أو تحميلها في وقت التشغيل كـ [خطوط خارجية](/slides/ar/python-net/custom-font/).

## **التنسيق والصور**

**س: كيف يمكنني تعيين لون حدود الجدول؟**

**ج**: يمكنك تغيير لون جميع حدود الجدول أو فقط الحدود المحيطة بالجدول بالكامل. لتغيير جميع الحدود، يمكنك استخدام خاصية `cell_format` من فئة [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). أما بالنسبة لحدود الجدول بالكامل، يجب عليك تكرار الخلايا وتغيير لون الحدود الخارجية.

**س: ما المقياس الذي يستخدمه Aspose.Slides لـ Python عبر .NET لوضع الصور؟**

**ج**: يتم قياس إحداثيات وأحجام جميع الأشكال على الشرائح بالنقاط (72 نقطة لكل إنش).

## **العمل مع الخطوط**

**س: عند تحويل PPT إلى PDF أو صور، لماذا تختلف الخطوط في الوثائق الناتجة؟**

**ج**: قد تشير هذه المشكلة إلى أن الخطوط المستخدمة في العرض مفقودة من نظام التشغيل الذي تم تنفيذ الشيفرة عليه. يجب عليك تثبيت الخطوط على نظام التشغيل أو تحميلها كخطوط خارجية باستخدام فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) كما هو موضح أدناه:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```