---
title: Impor Presentasi dari PDF atau HTML dalam C++
linktitle: Impor Presentasi
type: docs
weight: 60
url: /id/cpp/import-presentation/
keywords:
- impor presentasi
- impor slide
- impor PDF
- impor HTML
- PDF ke presentasi
- PDF ke PPT
- PDF ke PPTX
- PDF ke ODP
- HTML ke presentasi
- HTML ke PPT
- HTML ke PPTX
- HTML ke ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Impor dokumen PDF dan HTML dengan mudah ke dalam presentasi PowerPoint dan OpenDocument menggunakan C++ dengan Aspose.Slides untuk pemrosesan slide yang mulus dan berperforma tinggi."
---
## **Pendahuluan**

Dengan menggunakan [**Aspose.Slides for C++**](https://products.aspose.com/slides/id/cpp/), Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.slide_collection) untuk memungkinkan Anda mengimpor presentasi dari PDF, dokumen HTML, dll.

## **Impor PowerPoint dari PDF**

Dalam kasus ini, Anda dapat mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Buat instance objek kelas Presentation. 
2. Panggil metode [AddFromPdf()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) dan berikan file PDF. 
3. Gunakan metode [Save()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) untuk menyimpan file dalam format PowerPoint.

Kode C++ ini menunjukkan operasi PDF ke PowerPoint:

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
Anda mungkin ingin mencoba aplikasi web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) karena itu merupakan implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Impor PowerPoint dari HTML**

Dalam kasus ini, Anda dapat mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/). 
2. Panggil metode [AddFromHtml()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) dan berikan file HTML. 
3. Gunakan metode [Save()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) untuk menyimpan file dalam format PowerPoint.

Kode C++ ini menunjukkan operasi HTML ke PowerPoint:

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
Anda juga dapat menggunakan Aspose.Slides untuk mengonversi HTML ke format file populer lainnya: 

* [HTML ke gambar](https://products.aspose.com/slides/id/cpp/conversion/html-to-image/)
* [HTML ke JPG](https://products.aspose.com/slides/id/cpp/conversion/html-to-jpg/)
* [HTML ke XML](https://products.aspose.com/slides/id/cpp/conversion/html-to-xml/)
* [HTML ke TIFF](https://products.aspose.com/slides/id/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### Apakah tabel dipertahankan saat mengimpor PDF, dan apakah deteksinya dapat ditingkatkan?

Tabel dapat terdeteksi selama proses impor; [PdfImportOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/pdfimportoptions/) mencakup metode [set_DetectTables](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) yang memungkinkan pengenalan tabel. Keefektifannya tergantung pada struktur PDF.