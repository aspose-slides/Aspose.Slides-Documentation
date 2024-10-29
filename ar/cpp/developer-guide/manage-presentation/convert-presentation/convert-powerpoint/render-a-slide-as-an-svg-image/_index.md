---
title: عرض شريحة كصورة SVG
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
---

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو صيغة رسومية معيارية تُستخدم لعرض الصور ثنائية الأبعاد. تخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

تعتبر SVG واحدة من الصيغ القليلة للصور التي تلبي معايير عالية جداً في هذه الجوانب: القابلية للتوسع، والتفاعل، والأداء، وإمكانية الوصول، والبرمجة، وغيرها. ولهذه الأسباب، تُستخدم بشكل شائع في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي في *صيغة كبيرة جداً*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك إعادة تحجيم صور SVG عدة مرات كما تشاء دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة**.* يمكن لمعظم القُرّاء تفسير ملفات SVG.
- **استخدام *أصغر أحجام ممكنة من الصور***. عادةً ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في صيغ أخرى، خاصة تلك الصيغ المعتمدة على البيتبس (JPEG أو PNG).

يسمح لك Aspose.Slides for C++ بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. أنشئ مثيلاً من فئة Presentation.
2. قم بالتكرار خلال جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة إلى ملف SVG خاص بها من خلال FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني الخاص بنا](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides for C++.

{{% /alert %}} 

يوضح لك هذا الرمز المصدري في C++ كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

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