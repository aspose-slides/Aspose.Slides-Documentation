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

* بالمقارنة مع Microsoft PowerPoint، فإن تطبيق Microsoft Word مجهّز بأدوات أو وظائف أكثر للمحتوى. 
* بالإضافة إلى وظائف التحرير في Word، يمكنك أيضًا الاستفادة من تحسين التعاون والطباعة وميزات المشاركة. 

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العرض إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لمعرفة ما يمكنك تحقيقه من العمل بالمحتوى النصي للشرائح. 

{{% /alert %}} 

## **Aspose.Slides and Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) و[Aspose.Words for C++](https://products.aspose.com/words/cpp/).

كمجموعة API مستقلة، يوفر [Aspose.Slides](https://products.aspose.app/slides) للغة C++ وظائف تتيح لك استخراج النصوص من العروض التقديمية. 

يُعد [Aspose.Words](https://docs.aspose.com/words/cpp/) واجهة برمجة تطبيقات معالجة المستندات المتقدمة التي تسمح للتطبيقات بإنشاء وتعديل وتحويل وعرض وطباعة الملفات، والقيام بمهام أخرى مع المستندات دون استخدام Microsoft Word.

## **تحويل عرض PowerPoint إلى مستند Word**

استخدم مقطع الشيفرة هذا لتحويل PowerPoint إلى Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // ينشئ ويُدرج صورة الشريحة
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // يدرج نصوص الشريحة
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

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة الحزم المقابلة لـ [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) و[Aspose.Words for C++](https://releases.aspose.com/words/cpp/) إلى مشروعك. كلا المكتبتين تعمل كواجهات API مستقلة، ولا يلزم وجود Microsoft Office مثبت.

**هل يتم دعم جميع صيغ عروض PowerPoint وOpenDocument؟**

يدعم Aspose.Slides [جميع صيغ العروض التقديمية](/slides/ar/cpp/supported-file-formats/)، بما في ذلك PPT وPPTX وODP وأنواع الملفات الشائعة الأخرى. يضمن ذلك إمكانية العمل مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.