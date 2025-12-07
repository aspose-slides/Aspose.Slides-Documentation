---
title: تحويل شرائح العروض التقديمية إلى صور SVG في C++
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
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides للـ C++. مرئيات عالية الجودة مع أمثلة كود بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لتقديم الصور ثنائية الأبعاد. يقوم SVG بتخزين الصور كمتجهات في XML مع تفاصيل تُحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذه الأسباب يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي في *تنسيق كبير جدًا*.** يمكن لأشكال SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** معظم القارئات يمكنها تفسير ملفات SVG. 
- **استخدام *أصغر حجم ممكن للصور*.** عادةً ما تكون ملفات SVG أصغر من نظيراتها ذات الدقة العالية في صيغ أخرى، خصوصًا الصيغ القائمة على البت‌ماب (JPEG أو PNG).

## **تحويل شريحة إلى صورة SVG**

تسمح لك Aspose.Slides للـ C++ بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:

1. إنشاء مثال من فئة Presentation.  
2. التنقل عبر جميع الشرائح في العرض التقديمي.  
3. كتابة كل شريحة إلى ملف SVG خاص بها باستخدام FileStream.  

{{% alert color="primary" %}} 
قد ترغب في تجربة تطبيقنا الويب المجاني الذي نفذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides للـ C++. 
[free web application](https://products.aspose.app/slides/conversion/ppt-to-svg)
{{% /alert %}} 

يعرض لك هذا المثال البرمجي بلغة C++ كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
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


## **الأسئلة الشائعة**

**لماذا قد يظهر SVG الناتج بشكل مختلف عبر المتصفحات؟**  
يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة من قبل محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) في التخفيف من عدم التوافق.  

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**  
نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)، وهو ما يُعد ملائمًا للأيقونات، والرسوم البيانية، وإعادة استخدام الرسومات.  

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**  
السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة ما بعد المعالجة تُنفّذ على مستوى التطبيق.