---
title: استيراد العروض التقديمية من PDF أو HTML في C++
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/cpp/import-presentation/
keywords:
- استيراد العرض التقديمي
- استيراد الشريحة
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
description: "استورد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument في C++ باستخدام Aspose.Slides لمعالجة الشرائح بسلاسة وعالية الأداء."
---
## **المقدمة**

باستخدام [**Aspose.Slides for C++**](https://products.aspose.com/slides/ar/cpp/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.slide_collection) للسماح لك باستيراد العروض التقديمية من PDF، مستندات HTML، إلخ.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء كائن من فئة العرض التقديمي. 
2. استدعاء الطريقة [AddFromPdf()](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) وتمرير ملف PDF. 
3. استخدام الطريقة [Save()](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بصيغة PowerPoint.

يُظهر هذا الرمز C++ عملية تحويل PDF إلى PowerPoint:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
قد ترغب في الاطلاع على تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ar/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي PowerPoint.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation/) . 
2. استدعاء الطريقة [AddFromHtml()](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) وتمرير ملف HTML. 
3. استخدام الطريقة [Save()](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بصيغة PowerPoint.

يُظهر هذا الرمز C++ عملية تحويل HTML إلى PowerPoint:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/ar/cpp/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/ar/cpp/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/ar/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **الأسئلة الشائعة**

### هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟

يمكن اكتشاف الجداول أثناء الاستيراد؛ يتضمن [PdfImportOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/pdfimportoptions/) طريقة [set_DetectTables](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) التي تتيح التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.