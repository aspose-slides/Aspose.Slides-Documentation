---
title: PDF veya HTML'den Sunumları C++'ta İçe Aktarma
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/cpp/import-presentation/
keywords:
- sunum içe aktarma
- slayt içe aktarma
- PDF içe aktarma
- HTML içe aktarma
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
description: "Aspose.Slides ile C++'ta PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme için zahmetsizce içe aktarın."
---
## **Giriş**

Aspose.Slides for C++ kullanarak, sunumları diğer biçimlerdeki dosyalardan içe aktarabilirsiniz. Aspose.Slides, PDF, HTML belgeleri vb. dosyalardan sunumları içe aktarmanıza olanak tanıyan SlideCollection sınıfını sağlar.

## **PDF'den PowerPoint İçe Aktarma**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation sınıfının bir nesnesini oluşturun. 
2. AddFromPdf() yöntemini çağırın ve PDF dosyasını geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için Save() yöntemini kullanın.

Bu C++ kodu PDF'den PowerPoint'e dönüşümü gösterir:

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

{{% alert title="İpucu" color="info" %}} 
Bu süreçte açıklanan işlemin canlı bir uygulamasını görmek için Aspose ücretsiz PDF'den PowerPoint'e web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint İçe Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun. 
2. AddFromHtml() yöntemini çağırın ve HTML dosyasını geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için Save() yöntemini kullanın.

Bu C++ kodu HTML'den PowerPoint'e dönüşümü gösterir:

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

{{% alert title="Not" color="warning" %}} 
Ayrıca Aspose.Slides'ı HTML'yi diğer popüler dosya biçimlerine dönüştürmek için de kullanabilirsiniz: 

* [HTML'den görüntü](https://products.aspose.com/slides/tr/cpp/conversion/html-to-image/)
* [HTML'den JPG](https://products.aspose.com/slides/tr/cpp/conversion/html-to-jpg/)
* [HTML'den XML](https://products.aspose.com/slides/tr/cpp/conversion/html-to-xml/)
* [HTML'den TIFF](https://products.aspose.com/slides/tr/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **SSS**

### PDF içe aktarırken tablolar korunur mu ve algılamaları iyileştirilebilir mi?

Tablolar içe aktarım sırasında algılanabilir; PdfImportOptions sınıfı, tablo tanımasını etkinleştiren set_DetectTables yöntemini içerir. Etkililik, PDF'nin yapısına bağlıdır.