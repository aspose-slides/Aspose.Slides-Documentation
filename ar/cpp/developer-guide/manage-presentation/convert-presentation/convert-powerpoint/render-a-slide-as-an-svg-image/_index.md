---
title: "تصدير شرائح العرض التقديمي كصور SVG في C++"
linktitle: "الشريحة إلى SVG"
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
keywords:
  - "PowerPoint إلى SVG"
  - "العرض التقديمي إلى SVG"
  - "الشريحة إلى SVG"
  - "PPT إلى SVG"
  - "PPTX إلى SVG"
  - "حفظ PPT كـ SVG"
  - "حفظ PPTX كـ SVG"
  - "تصدير PPT إلى SVG"
  - "تصدير PPTX إلى SVG"
  - "عرض الشريحة"
  - "تحويل الشريحة"
  - "تصدير الشريحة"
  - "صورة متجهة"
  - "PowerPoint"
  - "العرض التقديمي"
  - "C++"
  - "Aspose.Slides"
description: "تعلم كيفية عرض شرائح PowerPoint كصور SVG باستخدام Aspose.Slides لـ C++. صور عالية الجودة مع أمثلة شفرة بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لعرض صور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.  

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، الوصولية، القابلية للبرمجة، وغيرها. لهذه الأسباب، يُستخدم بشكل شائع في تطوير الويب.  

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى  

- **طباعة عرضك التقديمي بصيغة *كبيرة جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.  
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** أغلب القراء يمكنهم تفسير ملفات SVG.  
- **استخدام *أصغر الأحجام الممكنة للصور*.** عادةً ما تكون ملفات SVG أصغر من مكافئاتها عالية الدقة في تنسيقات أخرى، خاصةً تلك التي تعتمد على البت ماب (JPEG أو PNG).  

## **تصدير شريحة كصورة SVG**

Aspose.Slides for C++ يسمح لك بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:  

1. إنشاء مثال من الفئة Presentation.  
2. التكرار عبر جميع الشرائح في العرض التقديمي.  
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.  

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيقنا الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفّذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides for C++.  

{{% /alert %}} 

هذا المثال البرمجي بلغة C++ يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:  
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

**لماذا قد يظهر SVG الناتج مختلفًا عبر المتصفحات؟**  
يتم تنفيذ دعم ميزات SVG المحددة بشكل مختلف من قبل محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) في تقليل عدم التوافق.  

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**  
نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)، وهو مناسب للأيقونات، والرموز التصويرية، وإعادة استخدام الرسومات.  

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**  
السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.