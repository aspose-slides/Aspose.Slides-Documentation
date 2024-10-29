---
title: تحويل PowerPoint إلى Word
type: docs
weight: 110
url: /ar/cpp/convert-powerpoint-to-word/
keywords: "تحويل PowerPoint, PPT, PPTX, عرض, Word, DOCX, DOC, PPTX إلى DOCX, PPT إلى DOC, PPTX إلى DOC, PPT إلى DOCX, C++, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى Word باستخدام C++ "
---

إذا كنت تخطط لاستخدام المحتوى النصي أو المعلومات من عرض (PPT أو PPTX) بطرق جديدة، قد تستفيد من تحويل العرض إلى Word (DOC أو DOCX).

* عند المقارنة مع Microsoft PowerPoint، فإن تطبيق Microsoft Word مجهز أكثر بالأدوات أو الوظائف للمحتوى.
* بالإضافة إلى وظائف التحرير في Word، يمكنك أيضاً الاستفادة من ميزات التعاون المطورة، والطباعة، والمشاركة.

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العرض إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك الحصول عليه من العمل مع المحتوى النصي المأخوذ من الشرائح. 

{{% /alert %}} 

### **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides لـ C++](https://products.aspose.com/slides/cpp/) و[Aspose.Words لـ C++](https://products.aspose.com/words/cpp/).

كواجهة برمجة تطبيقات مستقلة، توفر [Aspose.Slides](https://products.aspose.app/slides) لـ C++ وظائف تتيح لك استخراج النصوص من العروض.

[Aspose.Words](https://docs.aspose.com/words/cpp/) هي واجهة برمجة تطبيقات متقدمة لمعالجة المستندات تسمح للتطبيقات بإنشاء وتعديل وتحويل وعرض وطباعة الملفات، وأداء مهام أخرى مع المستندات دون استخدام Microsoft Word.

## **تحويل PowerPoint إلى Word**

استخدم هذا المقتطف البرمجي لتحويل PowerPoint إلى Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // يولد ويضيف صورة الشريحة
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // يضيف نصوص الشريحة
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