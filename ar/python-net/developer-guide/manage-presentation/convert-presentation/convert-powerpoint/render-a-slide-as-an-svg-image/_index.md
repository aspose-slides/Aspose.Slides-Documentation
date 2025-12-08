---
title: تحويل شرائح العروض التقديمية إلى صور SVG باستخدام Python
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
- عرض شريحة
- تحويل شريحة
- تصدير شريحة
- صورة متجهة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint وOpenDocument إلى صور SVG باستخدام Aspose.Slides للـ Python عبر .NET. صور عالية الجودة مع أمثلة شيفرة بسيطة."
---

## **تحويل الشرائح إلى SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لعرض الصور الثنائية الأبعاد. يقوم SVG بتخزين الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعل، الأداء، إمكانية الوصول، القابلية للبرمجة، وغيرها. لهذه الأسباب يُستخدم بشكل شائع في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى
- **طباعة عرضك التقديمي في *تنسيق كبير جدًا*.** يمكن للصور بصيغة SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG مرات متعددة حسب الحاجة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من الشرائح في *وسائط أو منصات مختلفة**.* معظم القارئات يمكنها تفسير ملفات SVG. 
- **استخدام *أصغر حجم ممكن للصور***. عادةً ما تكون ملفات SVG أصغر حجمًا من نظيراتها عالية الدقة في تنسيقات أخرى، خاصةً تلك التي تعتمد على البت ماب (JPEG أو PNG).

يتيح Aspose.Slides for Python عبر .NET تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:
1. إنشاء مثيل من الفئة Presentation.  
2. التكرار عبر جميع الشرائح في العرض التقديمي.  
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.  

{{% alert color="primary" %}} 
قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides for Python عبر .NET.
{{% /alert %}} 

يعرض هذا المثال البرمجي بلغة Python كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```


## **الأسئلة المتكررة**

**لماذا قد يبدو الـ SVG الناتج مختلفًا عبر المتصفحات؟**  
يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة حسب محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) في تسوية عدم التوافق.

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**  
نعم. يمكن حفظ أي [shape can be saved as a separate SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)، وهو ما يكون مناسبًا للأيقونات، والرسوم التوضيحية، وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في ملف SVG واحد (شريط/وثيقة)؟**  
السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة ما بعد المعالجة تُجرى على مستوى التطبيق.