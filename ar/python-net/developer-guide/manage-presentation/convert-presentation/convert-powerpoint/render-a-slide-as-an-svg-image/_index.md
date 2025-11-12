---
title: عرض شرائح العرض التقديمي كصور SVG في Python
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/python-net/render-a-slide-as-an-svg-image/
keywords:
- شريحة إلى SVG
- عرض تقديمي إلى SVG
- PowerPoint إلى SVG
- OpenDocument إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- ODP إلى SVG
- تحويل الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية عرض شرائح PowerPoint وOpenDocument كصور SVG باستخدام Aspose.Slides لـ Python عبر .NET. صور عالية الجودة مع أمثلة شفرة بسيطة."
---

## **تحويل الشرائح إلى SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تُحدد سلوكها أو مظهرها.

SVG هو أحد القليل من التنسيقات للصور التي تفي بمعايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، القابلية للبرمجة، وغيرها. لهذه الأسباب، يُستخدم عادةً في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بصيغة *كبيرة جدًا*.** يمكن للصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** معظم القرّاء يمكنهم تفسير ملفات SVG.
- **استخدام *أصغر حجم ممكن للصور*.** عادةً ما تكون ملفات SVG أصغر من نظيراتها ذات الدقة العالية في تنسيقات أخرى، خاصةً تلك القائمة على البت ماب (JPEG أو PNG).

Aspose.Slides لـ Python عبر .NET يتيح لك تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. إنشاء كائن من فئة Presentation.
2. التكرار عبر جميع الشرائح في العرض.
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق ويب مجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) حيث قمنا بتنفيذ وظيفة تحويل PPT إلى SVG باستخدام Aspose.Slides لـ Python عبر .NET.

{{% /alert %}} 

هذا الكود النموذجي في Python يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **الأسئلة الشائعة**

**لماذا قد يبدو SVG الناتج مختلفًا عبر المتصفحات؟**

يتم تنفيذ الدعم لميزات SVG المحددة بطرق مختلفة من قِبل محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) في تسوية الاختلافات.

**هل من الممكن تصدير ليس فقط الشرائح ولكن أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)، وهو ما يكون مناسبًا للأيقونات والرسومات البيانية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.