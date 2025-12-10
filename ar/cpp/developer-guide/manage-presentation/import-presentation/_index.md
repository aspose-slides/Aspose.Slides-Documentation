---
title: استيراد العروض التقديمية من PDF أو HTML في C++
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/cpp/import-presentation/
keywords:
- استيراد عرض تقديمي
- استيراد شريحة
- استيراد PDF
- استيراد HTML
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "استيراد مستندات PDF و HTML بسهولة إلى عروض PowerPoint و OpenDocument في C++ باستخدام Aspose.Slides لمعالجة الشرائح بسلاسة وعالية الأداء."
---

باستخدام [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)، يمكنك استيراد العروض التقديمية من ملفات بتنسيقات أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) لتتيح لك استيراد العروض التقديمية من PDF، مستندات HTML، وغيرها.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء كائن من فئة Presentation. 
2. استدعاء الطريقة [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) وتمرير ملف PDF. 
3. استخدام الطريقة [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بتنسيق PowerPoint.

هذا الكود C++ يوضح عملية التحويل من PDF إلى PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في تجربة تطبيق الويب **Aspose مجاني** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموصوفة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي PowerPoint.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). 
2. استدعاء الطريقة [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) وتمرير ملف HTML. 
3. استخدام الطريقة [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بتنسيق PowerPoint.

هذا الكود C++ يوضح عملية التحويل من HTML إلى PowerPoint:
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم الحفاظ على الجداول عند استيراد ملف PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ فإن [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) يتضمن طريقة [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) التي تُمكّن التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.