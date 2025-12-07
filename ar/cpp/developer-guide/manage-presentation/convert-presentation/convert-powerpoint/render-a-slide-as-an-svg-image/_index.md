---
title: تحويل شرائح العرض التقديمي إلى صور SVG في C++
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- عرض الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides لـ C++. رسومات عالية الجودة مع أمثلة شفرة بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تفي بمعايير عالية جداً في هذه الجوانب: القابلية للتوسع، التفاعل، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذه الأسباب، يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بتنسيق *كبير جداً*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عدد مرات الحاجة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** معظم القراء يمكنهم تفسير ملفات SVG. 
- **استخدام *أصغر أحجام ممكنة للصور***. ملفات SVG أصغر عادةً من ما يعادلها ذات الدقة العالية في تنسيقات أخرى، خصوصاً تلك القائمة على البت ماب (JPEG أو PNG).

## **تحويل شريحة إلى صورة SVG**

Aspose.Slides for C++ يسمح لك بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. أنشئ مثيلاً من فئة Presentation.
2. قم بالتكرار عبر جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيقنا الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides for C++.

{{% /alert %}} 

يعرض لك هذا الكود النموذجي بلغة C++ كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
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

**لماذا قد يظهر SVG الناتج بشكل مختلف عبر المتصفحات؟**

يتم تنفيذ الدعم لميزات SVG المحددة بشكل مختلف من قبل محركات المتصفح. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) في تقليل عدم التوافق.

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)، وهو أمر ملائم للأيقونات والرسوم التخطيطية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/وثيقة)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحدة. دمج عدة شرائح في قماش SVG واحد هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.