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

إذا كنت تخطط لاستخدام المحتوى النصي أو المعلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، قد تستفيد من تحويل العرض التقديمي إلى Word (DOC أو DOCX). 

* مقارنةً ببرنامج Microsoft PowerPoint، تطبيق Microsoft Word مزود بأدوات أو وظائف أكثر للمحتوى. 
* بالإضافة إلى وظائف التحرير في Word، قد تستفيد أيضًا من تحسين التعاون والطباعة وميزات المشاركة. 

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العروض التقديمية إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لمعرفة ما يمكنك تحقيقه من العمل مع المحتوى النصي للشرائح. 

{{% /alert %}} 

## **Aspose.Slides and Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كلٍ من [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) و[Aspose.Words for C++](https://products.aspose.com/words/cpp/).

كـ API مستقل، يوفر [Aspose.Slides](https://products.aspose.app/slides) لـ C++ وظائف تمكّنك من استخراج النصوص من العروض التقديمية. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) هو API متقدم لمعالجة المستندات يتيح للتطبيقات إنشاء، تعديل، تحويل، عرض، طباعة الملفات، والقيام بمهام أخرى مع المستندات دون الحاجة إلى Microsoft Word.

## **تحويل عرض PowerPoint إلى مستند Word**

استخدم مقطع الشيفرة هذا لتحويل PowerPoint إلى Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // ينشئ ويدرج صورة الشريحة
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // يدراج نصوص الشريحة
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


## **FAQ**

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وعروض OpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة الحزم الخاصة بـ [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) و[Aspose.Words for C++](https://releases.aspose.com/words/cpp/) إلى مشروعك. كلا المكتبتين تعملان كـ APIs مستقلة، ولا يوجد أي اشتراط لتثبيت Microsoft Office.

**هل يتم دعم جميع صيغ عروض PowerPoint وعروض OpenDocument؟**

يدعم Aspose.Slides [جميع صيغ العروض التقديمية](/slides/ar/cpp/supported-file-formats/)، بما في ذلك PPT، PPTX، ODP، وغيرها من صيغ الملفات الشائعة. هذا يضمن إمكانية عملك مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.