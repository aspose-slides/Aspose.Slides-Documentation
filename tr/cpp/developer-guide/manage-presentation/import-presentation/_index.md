---
title: C++'ta PDF veya HTML'den Sunumları İçe Aktarma
linktitle: Sunum İçe Aktarma
type: docs
weight: 60
url: /tr/cpp/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz, yüksek performanslı slayt işleme ile zahmetsizce içe aktarın."
---
## **Giriş**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/tr/cpp/) kullanarak, diğer biçimlerdeki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF, HTML belgeleri vb. gibi formatlardan sunumları içe aktarmanıza olanak sağlayan [SlideCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.slide_collection) sınıfını sağlar.

## **PDF'ten PowerPoint İçeri Aktarma**

Bu durumda, bir PDF dosyasını PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Sunum sınıfının bir örneğini oluşturun.  
2. PDF dosyasını parametre olarak geçerek [AddFromPdf()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) metodunu çağırın.  
3. [Save()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metodunu kullanarak dosyayı PowerPoint biçiminde kaydedin.

Bu C++ kodu PDF'ten PowerPoint dönüşümünü gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="primary" %}} 
Burada açıklanan sürecin canlı bir uygulaması olduğu için **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint İçeri Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun.  
2. HTML dosyasını parametre olarak geçerek [AddFromHtml()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) metodunu çağırın.  
3. [Save()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metodunu kullanarak dosyayı PowerPoint biçiminde kaydedin.

Bu C++ kodu HTML'den PowerPoint dönüşümünü gösterir:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides'ı kullanarak HTML'i diğer popüler dosya formatlarına da dönüştürebilirsiniz: 

* [HTML to image](https://products.aspose.com/slides/tr/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/tr/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/tr/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/tr/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **SSS**

**PDF içe aktarırken tablolar korunur mu ve tespiti geliştirilebilir mi?**

İçe aktarma sırasında tablolar tespit edilebilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/pdfimportoptions/) içinde tablo tanıma özelliğini etkinleştiren bir [set_DetectTables](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) metodu bulunur. Etkinlik, PDF'nin yapısına bağlıdır.