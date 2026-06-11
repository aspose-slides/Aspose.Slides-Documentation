---
title: Importera presentationer med Python
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/python-net/import-presentation/
keywords:
- importera PowerPoint
- importera presentation
- importera bild
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- Python
- Aspose.Slides
description: "Importera enkelt PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i Python med Aspose.Slides för sömlös, högpresterande bildbehandling."
---
## **Introduktion**

Med [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/sv/python-net/), kan du importera innehåll till en presentation från andra filformat. Klassen [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) tillhandahåller metoder för att importera bilder från PDF, HTML och andra källor.

## **Konvertera en PDF till en presentation**

Detta avsnitt visar hur du konverterar en PDF till en presentation med Aspose.Slides. Det guidar dig genom att importera PDF-filen, omvandla dess sidor till bilder och spara resultatet som en PPTX‑fil.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Anropa metoden [add_from_pdf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_from_pdf/) och skicka med PDF‑filen.
3. Använd metoden [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att spara presentationen i PowerPoint‑format.

Följande Python‑exempel demonstrerar hur en PDF konverteras till en presentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Du kanske vill prova **Asposes gratis** [PDF till PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webapp – det är en levande implementering av processen som beskrivs här.
{{% /alert %}}

## **Konvertera en HTML till en presentation**

Detta avsnitt visar hur du importerar HTML‑innehåll till en presentation med Aspose.Slides. Det beskriver hur HTML laddas, omvandlas till bilder med bevarad text, bilder och grundläggande formatering, och hur resultatet sparas som en PPTX‑fil.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Anropa metoden [add_from_html](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_from_html/) och skicka med HTML‑filen.
3. Använd metoden [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att spara presentationen i PowerPoint‑format.

Följande Python‑exempel demonstrerar hur en HTML konverteras till en presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bevaras tabeller när en PDF importeras, och kan deras detektering förbättras?**

Tabeller kan upptäckas under import; [PdfImportOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.importing/pdfimportoptions/) innehåller en [detect_tables](https://reference.aspose.com/slides/sv/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/)‑parameter som möjliggör tabelligenkänning. Effektiviteten beror på PDF:ens struktur.

{{% alert title="Note" color="info" %}}
Du kan också använda Aspose.Slides för att konvertera HTML till andra populära filformat:

* [HTML till bild](https://products.aspose.com/slides/sv/python-net/conversion/html-to-image/)
* [HTML till JPG](https://products.aspose.com/slides/sv/python-net/conversion/html-to-jpg/)
* [HTML till XML](https://products.aspose.com/slides/sv/python-net/conversion/html-to-xml/)
* [HTML till TIFF](https://products.aspose.com/slides/sv/python-net/conversion/html-to-tiff/)
{{% /alert %}}