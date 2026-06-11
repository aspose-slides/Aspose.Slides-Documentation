---
title: Importowanie prezentacji z PDF lub HTML w C++
linktitle: Importowanie prezentacji
type: docs
weight: 60
url: /pl/cpp/import-presentation/
keywords:
- importowanie prezentacji
- importowanie slajdu
- importowanie PDF
- importowanie HTML
- PDF do prezentacji
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentacji
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Bez problemu importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument w C++ przy użyciu Aspose.Slides, zapewniając płynne i wysokowydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Korzystając z [**Aspose.Slides for C++**](https://products.aspose.com/slides/pl/cpp/), możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.slide_collection), która umożliwia importowanie prezentacji z plików PDF, dokumentów HTML itp.

## **Import PowerPoint z PDF**

W tym przypadku możesz przekonwertować plik PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz obiekt klasy prezentacji.  
2. Wywołaj metodę [AddFromPdf()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) i podaj plik PDF.  
3. Użyj metody [Save()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), aby zapisać plik w formacie PowerPoint.

Ten kod C++ demonstruje operację konwersji PDF do PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Wskazówka" color="primary" %}} 
Możesz chcieć wypróbować darmową aplikację internetową **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja procesu opisanego tutaj. 
{{% /alert %}} 

## **Import PowerPoint z HTML**

W tym przypadku możesz przekonwertować dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Wywołaj metodę [AddFromHtml()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) i podaj plik HTML.  
3. Użyj metody [Save()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), aby zapisać plik w formacie PowerPoint.

Ten kod C++ demonstruje operację konwersji HTML do PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Uwaga" color="warning" %}} 
Możesz również używać Aspose.Slides do konwersji HTML na inne popularne formaty plików: 

* [HTML na obraz](https://products.aspose.com/slides/pl/cpp/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/pl/cpp/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/pl/cpp/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/pl/cpp/conversion/html-to-tiff/)
{{% /alert %}}

## **FAQ**

**Czy tabele są zachowywane podczas importu PDF i czy ich wykrywanie może być ulepszone?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/pdfimportoptions/) zawiera metodę [set_DetectTables](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/), która umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.