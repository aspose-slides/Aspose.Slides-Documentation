---
title: Importowanie prezentacji w Pythonie
linktitle: Import prezentacji
type: docs
weight: 60
url: /pl/python-net/import-presentation/
keywords:
- import PowerPoint
- importowanie prezentacji
- importowanie slajdu
- PDF do prezentacji
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentacji
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- Python
- Aspose.Slides
description: "Bezproblemowo importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument w Pythonie przy użyciu Aspose.Slides, zapewniając płynne i wysokowydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Za pomocą [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/pl/python-net/), możesz importować treść do prezentacji z innych formatów plików. Klasa [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) udostępnia metody do importowania slajdów z PDF, HTML i innych źródeł.

## **Konwertuj PDF do prezentacji**

Ta sekcja pokazuje, jak przekonwertować plik PDF na prezentację przy użyciu Aspose.Slides. Przeprowadza Cię przez importowanie PDF, zamienianie jego stron na slajdy oraz zapisywanie wyniku jako plik PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Wywołaj metodę [add_from_pdf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_from_pdf/) i przekaż plik PDF.
3. Użyj metody [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) aby zapisać prezentację w formacie PowerPoint.

Poniższy przykład w języku Python demonstruje konwersję PDF do prezentacji:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Możesz wypróbować **darmową** aplikację internetową [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint) firmy Aspose — jest to działająca implementacja procesu opisanego tutaj.
{{% /alert %}}

## **Konwertuj HTML do prezentacji**

Ta sekcja pokazuje, jak zaimportować treść HTML do prezentacji przy użyciu Aspose.Slides. Omówiono w niej wczytywanie HTML, przekształcanie go w slajdy z zachowaniem tekstu, obrazów i podstawowego formatowania oraz zapisywanie wyniku jako plik PPTX.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Wywołaj metodę [add_from_html](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_from_html/) i przekaż plik HTML.
3. Użyj metody [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) aby zapisać prezentację w formacie PowerPoint.

Poniższy przykład w języku Python demonstruje konwersję HTML do prezentacji:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy tabele są zachowywane przy importowaniu PDF i czy ich wykrywanie można ulepszyć?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.importing/pdfimportoptions/) zawiera parametr [detect_tables](https://reference.aspose.com/slides/pl/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/), który umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.

{{% alert title="Note" color="info" %}}
Możesz również użyć Aspose.Slides do konwersji HTML do innych popularnych formatów plików:

* [HTML do obrazu](https://products.aspose.com/slides/pl/python-net/conversion/html-to-image/)
* [HTML do JPG](https://products.aspose.com/slides/pl/python-net/conversion/html-to-jpg/)
* [HTML do XML](https://products.aspose.com/slides/pl/python-net/conversion/html-to-xml/)
* [HTML do TIFF](https://products.aspose.com/slides/pl/python-net/conversion/html-to-tiff/)

{{% /alert %}}