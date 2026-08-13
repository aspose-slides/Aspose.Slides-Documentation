---
title: وارد کردن ارائه‌ها از PDF یا HTML در C++
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/cpp/import-presentation/
keywords:
- وارد کردن ارائه
- وارد کردن اسلاید
- وارد کردن PDF
- وارد کردن HTML
- PDF به ارائه
- PDF به PPT
- PDF به PPTX
- PDF به ODP
- HTML به ارائه
- HTML به PPT
- HTML به PPTX
- HTML به ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "به راحتی اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument در C++ با Aspose.Slides وارد کنید تا پردازش اسلایدهای یکپارچه و با عملکرد بالا فراهم شود."
---
## **مقدمه**

با استفاده از [**Aspose.Slides for C++**](https://products.aspose.com/slides/fa/cpp/)، می‌توانید ارائه‌ها را از فایل‌های با فرمت‌های دیگر وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.slide_collection) را فراهم می‌کند تا بتوانید ارائه‌ها را از PDF، اسناد HTML و غیره وارد کنید.

## **وارد کردن پاورپوینت از PDF**

در این حالت، می‌توانید یک PDF را به ارائهٔ پاورپوینت تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک شیء از کلاس Presentation ایجاد کنید.  
2. متد [AddFromPdf()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) را فراخوانی کنید و فایل PDF را به آن پاس دهید.  
3. از متد [Save()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) برای ذخیرهٔ فایل در قالب پاورپوینت استفاده کنید.

این کد C++ عمل تبدیل PDF به پاورپوینت را نشان می‌دهد:

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
ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید زیرا این یک پیاده‌سازی زنده از فرآیند شرح داده شده در اینجا است. 
{{% /alert %}} 

## **وارد کردن پاورپوینت از HTML**

در این حالت، می‌توانید یک سند HTML را به ارائهٔ پاورپوینت تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.  
2. متد [AddFromHtml()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) را فراخوانی کنید و فایل HTML را به آن پاس دهید.  
3. از متد [Save()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) برای ذخیرهٔ فایل در قالب پاورپوینت استفاده کنید.

این کد C++ عمل تبدیل HTML به پاورپوینت را نشان می‌دهد:

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
شما همچنین می‌توانید از Aspose.Slides برای تبدیل HTML به سایر فرمت‌های پرطرفدار استفاده کنید: 

* [HTML به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/html-to-image/)
* [HTML به JPG](https://products.aspose.com/slides/fa/cpp/conversion/html-to-jpg/)
* [HTML به XML](https://products.aspose.com/slides/fa/cpp/conversion/html-to-xml/)
* [HTML به TIFF](https://products.aspose.com/slides/fa/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **سوالات متداول**

### آیا جدول‌ها هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟

در هنگام وارد کردن می‌توان جدول‌ها را شناسایی کرد؛ [PdfImportOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/pdfimportoptions/) شامل متد [set_DetectTables](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) است که امکان تشخیص جدول را فراهم می‌آورد. کارایی آن به ساختار PDF بستگی دارد.