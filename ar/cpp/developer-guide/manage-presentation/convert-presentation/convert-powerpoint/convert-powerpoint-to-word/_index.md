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
## **مقدمة**

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، قد تستفيد من تحويل العرض إلى Word (DOC أو DOCX).

* مقارنةً بـ Microsoft PowerPoint، يُقدِّم تطبيق Microsoft Word أدوات أو وظائف أكثر ملاءمة للمحتوى. 
* إلى جانب وظائف التحرير في Word، يمكنك أيضًا الاستفادة من ميزات التعاون المطورة والطباعة ومشاركة الملفات. 

{{% alert color="info" %}} 
قد ترغب في تجربة [**محول العروض إلى Word عبر الإنترنت**](https://products.aspose.app/slides/ar/conversion/ppt-to-word) لمعرفة ما يمكنك الحصول عليه من العمل بالمحتوى النصي للشرائح. 
{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOC)، تحتاج إلى كل من [Aspose.Slides for C++](https://products.aspose.com/slides/ar/cpp/) و [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

كـ API مستقل، يوفر [Aspose.Slides](https://products.aspose.app/slides) للـ C++ وظائف تمكنك من استخراج النصوص من العروض التقديمية. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) هو API متقدم لمعالجة المستندات يتيح للتطبيقات إنشاء، تعديل، تحويل، عرض، طباعة الملفات، وأداء مهام أخرى مع المستندات دون استخدام Microsoft Word.

## **تحويل عرض PowerPoint إلى مستند Word**

استخدم مقطع الشفرة التالي لتحويل PowerPoint إلى Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // ينشئ صورة الشريحة كمجموعة بايت في تدفق
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // يُدرج نصوص الشريحة
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

doc->Save(u"output.docx");
presentation->Dispose();
```

## **الأسئلة الشائعة**

### ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint و OpenDocument إلى مستندات Word؟

كل ما عليك هو إضافة الحزم المناسبة لـ [Aspose.Slides for C++](https://releases.aspose.com/slides/ar/cpp/) و [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) إلى مشروعك. كلا المكتبتين تعملان كـ API مستقلة، ولا يلزم تثبيت Microsoft Office.

### هل جميع صيغ عروض PowerPoint و OpenDocument مدعومة؟

يدعم Aspose.Slides [جميع صيغ العروض](/slides/ar/cpp/supported-file-formats/)، بما في ذلك PPT، PPTX، ODP، وأنواع ملفات أخرى شائعة. يضمن لك ذلك القدرة على العمل مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.