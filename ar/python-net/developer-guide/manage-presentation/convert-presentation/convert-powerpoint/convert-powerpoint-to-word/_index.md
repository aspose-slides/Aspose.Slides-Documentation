---
title: تحويل PowerPoint إلى Word
type: docs
weight: 110
url: /ar/python-net/convert-powerpoint-to-word/
keywords: "تحويل PowerPoint، PPT، PPTX، عرض، Word، DOCX، DOC، PPTX إلى DOCX، PPT إلى DOC، PPTX إلى DOC، PPT إلى DOCX، Python، Aspose.Slides"
description: "تحويل عرض PowerPoint إلى Word باستخدام Python"
---

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى Word (DOC أو DOCX).

* عند المقارنة مع Microsoft PowerPoint، فإن تطبيق Microsoft Word مزود بأدوات أو وظائف أكثر لمحتوى.
* بالإضافة إلى وظائف التحرير في Word، قد تستفيد أيضًا من ميزات التعاون المعززة والطباعة ومشاركة الملفات.

{{% alert color="primary" %}}

قد ترغب في تجربة [**محول العرض إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك كسبه من العمل مع المحتوى النصي من الشرائح.

{{% /alert %}}

## **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/) و[Aspose.Words for Python via .NET](https://products.aspose.com/words/python-net/).

باعتباره واجهة برمجة تطبيقات مستقلة، فإن [Aspose.Slides](https://products.aspose.com/slides/python-net/) لـ Python عبر .NET يوفر وظائف تتيح لك استخراج النصوص من العروض التقديمية.

[Aspose.Words](https://products.aspose.com/words/python-net/) هو واجهة برمجة تطبيقات معالجة مستندات متقدمة تسمح للتطبيقات بإنشاء وتعديل وتحويل وعرض وطباعة الملفات، وأداء مهام أخرى مع المستندات دون الاستعانة بـ Microsoft Word.

## **تحويل PowerPoint إلى Word باستخدام Python**

1. أضف هذه المساحات الاسمية إلى ملف program.py لديك:

```py
import aspose.slides as slides
import aspose.words as words
```

2. استخدم هذه الشريحة من التعليمات البرمجية لتحويل PowerPoint إلى Word:

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # ينشئ صورة شريحة
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # يُدرج نصوص الشريحة
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```