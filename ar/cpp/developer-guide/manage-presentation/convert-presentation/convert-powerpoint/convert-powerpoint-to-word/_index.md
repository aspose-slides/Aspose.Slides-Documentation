---
title: تحويل عروض PowerPoint إلى مستندات Word في C++
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/cpp/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى Word
- العرض التقديمي إلى Word
- الشريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- PowerPoint إلى DOCX
- العرض التقديمي إلى DOCX
- الشريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- PowerPoint إلى DOC
- العرض التقديمي إلى DOC
- الشريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- حفظ PPT كـ DOCX
- حفظ PPTX كـ DOCX
- تصدير PPT إلى DOCX
- تصدير PPTX إلى DOCX
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint PPT و PPTX إلى مستندات Word قابلة للتحرير في C++ باستخدام Aspose.Slides مع الحفاظ على التخطيط الدقيق والصور والتنسيق."
---

إذا كنت تخطط لاستخدام المحتوى النصي أو المعلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى Word (DOC أو DOCX). 

* مقارنةً بـ Microsoft PowerPoint، يتميز تطبيق Microsoft Word بمزيد من الأدوات أو الوظائف للمحتوى. 
* إلى جانب وظائف التحرير في Word، يمكنك أيضًا الاستفادة من ميزات التعاون المحسّنة والطباعة والمشاركة. 

{{% alert color="primary" %}} 
قد ترغب في تجربة [**محول العرض التقديمي إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لمعرفة ما يمكنك الاستفادة منه عند العمل على المحتوى النصي من الشرائح. 
{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) و[ Aspose.Words for C++](https://products.aspose.com/words/cpp/). 

كمكتبة مستقلة، يقدم [Aspose.Slides](https://products.aspose.app/slides) لـ C++ وظائف تتيح لك استخراج النصوص من العروض التقديمية. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) هي واجهة برمجة تطبيقات متقدمة لمعالجة المستندات تسمح للتطبيقات بإنشاء، تعديل، تحويل، عرض، طباعة الملفات، وأداء مهام أخرى مع المستندات دون الحاجة إلى Microsoft Word.

## **تحويل عرض PowerPoint إلى مستند Word**

استخدم مقتطف الشيفرة التالي لتحويل PowerPoint إلى Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // يقوم بإنشاء وإدراج صورة الشريحة
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // يدخل نصوص الشريحة
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```


## **الأسئلة المتكررة**

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint و OpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة الحزم الخاصة بـ [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) و[Aspose.Words for C++](https://releases.aspose.com/words/cpp/) إلى مشروعك. تعمل المكتبتان كمكتبات مستقلة، ولا توجد حاجة لتثبيت Microsoft Office.

**هل يتم دعم جميع صيغ عروض PowerPoint و OpenDocument؟**

يدعم Aspose.Slides جميع صيغ العروض التقديمية، بما في ذلك PPT و PPTX و ODP وغيرها من أنواع الملفات الشائعة. يضمن لك ذلك القدرة على التعامل مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.