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
- تصيير الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides لـ C++. رسوم عالية الجودة مع أمثلة شفرة بسيطة."
---

## **SVG Format**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لتصوير الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تُحدِّد سلوكها أو مظهرها. 

SVG هو أحد القلة القليلة من صيغ الصور التي تفي بمعايير عالية جدًا فيما يتعلق بـ: القابلية للتوسع، التفاعلية، الأداء، الوصولية، القابلية للبرمجة، وغير ذلك. لهذه الأسباب، يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بصيغة *كبيرة جدًا*.** يمكن للصور SVG أن تُقَاس إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عددًا لا نهائيًا من المرات دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة***. يمكن لمعظم القارئات تفسير ملفات SVG. 
- **استخدام *أصغر الأحجام الممكنة للصور***. عادةً ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في الصيغ الأخرى، خاصةً الصيغ القائمة على البتّامب (JPEG أو PNG).

## **Render a Slide as an SVG Image**

Aspose.Slides for C++ تتيح لك تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لتوليد صور SVG:

1. إنشاء مثال من فئة Presentation.  
2. التكرار عبر جميع الشرائح في العرض.  
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.  

{{% alert color="primary" %}} 

قد ترغب في تجربة تطبيقنا الويب [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفّذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides for C++. 

{{% /alert %}} 

هذا المثال البرمجي في C++ يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
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


## **FAQ**

**لماذا قد يبدو الـ SVG الناتج مختلفًا بين المتصفحات؟**  

يتم تنفيذ الدعم لميزات SVG المحددة بطرق مختلفة بواسطة محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) في تلافي التوافقية.  

**هل يمكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**  

نعم. يمكن حفظ أي [shape can be saved as a separate SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)، وهو أمر مفيد للأيقونات والرسوم التوضيحية وإعادة استخدام الرسومات.  

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**  

السيناريو المعتاد هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة ما بعد المعالجة تُجرى على مستوى التطبيق.