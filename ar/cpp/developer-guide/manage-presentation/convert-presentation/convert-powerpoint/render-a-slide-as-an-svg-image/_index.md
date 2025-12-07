---
title: تحويل شرائح العرض التقديمي إلى صور SVG في C++
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- تحويل شريحة
- تحويل شريحة
- تصدير شريحة
- صورة متجهة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides للغة C++. رسومات عالية الجودة مع أمثلة شفرة بسيطة."
---

## **صيغة SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو صيغة رسومات قياسية تُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

SVG هو أحد القليل من صيغ الصور التي تفي بمعايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، الوصولية، القابلية للبرمجة، وغيرها. لهذا السبب يُستخدم عادةً في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بصيغة *كبيرة جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- **استخدام الرسوم البيانية والمخططات من شرائحك في *وسائط أو منصات مختلفة*.** يمكن لمعظم القارئات تفسير ملفات SVG.
- **استخدام *أصغر الأحجام الممكنة للصور*.** ملفات SVG عادةً أصغر من نظيراتها عالية الدقة في صيغ أخرى، خاصةً الصيغ القائمة على البيت ماب (JPEG أو PNG).

## **تحويل شريحة إلى صورة SVG**

يوفر Aspose.Slides for C++ إمكانية تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:

1. إنشاء مثيل من الفئة Presentation.
2. التنقل عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="primary" %}} 
قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides for C++.
{{% /alert %}} 

يعرض لك هذا النموذج البرمجي في C++ كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```


## **الأسئلة المتكررة**

**لماذا قد يبدو الـ SVG الناتج مختلفًا بين المتصفحات؟**

يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة من قبل محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) في تسوية عدم التوافق.

**هل يمكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)، وهو أمر ملائم للأيقونات والرسوم التخطيطية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحدة. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.