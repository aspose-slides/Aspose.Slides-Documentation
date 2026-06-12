---
title: Importovat prezentace pomocí Pythonu
linktitle: Importovat prezentaci
type: docs
weight: 60
url: /cs/python-net/import-presentation/
keywords:
- importovat PowerPoint
- importovat prezentaci
- importovat snímek
- PDF do prezentace
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentace
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- Python
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do PowerPoint a OpenDocument prezentací v Pythonu pomocí Aspose.Slides pro plynulé a výkonné zpracování snímků."
---
## **Úvod**

S [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/cs/python-net/) můžete importovat obsah do prezentace z jiných formátů souborů. Třída [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) poskytuje metody pro import snímků z PDF, HTML a dalších zdrojů.

## **Převod PDF do prezentace**

Tato sekce ukazuje, jak převést PDF do prezentace pomocí Aspose.Slides. Provede vás importem PDF, převodem jeho stránek na snímky a uložením výsledku jako souboru PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Zavolejte metodu [add_from_pdf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_from_pdf/) a předáte PDF soubor.
3. Použijte metodu [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k uložení prezentace ve formátu PowerPoint.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}Možná budete chtít vyzkoušet **bezplatnou** [PDF do PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci – je to živá implementace procesu popsaného zde.{{% /alert %}}

## **Převod HTML do prezentace**

Tato sekce ukazuje, jak importovat HTML obsah do prezentace pomocí Aspose.Slides. Popisuje načtení HTML, převod na snímky se zachovaným textem, obrázky a základním formátováním a uložení výsledku jako souboru PPTX.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Zavolejte metodu [add_from_html](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_from_html/) a předáte HTML soubor.
3. Použijte metodu [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k uložení prezentace ve formátu PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Zůstávají tabulky při importu PDF zachovány a lze jejich detekci vylepšit?**

Tabulky mohou být během importu detekovány; [PdfImportOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.importing/pdfimportoptions/) obsahuje parametr [detect_tables](https://reference.aspose.com/slides/cs/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/), který umožňuje rozpoznání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Note" color="info" %}}Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů:

* [HTML na obrázek](https://products.aspose.com/slides/cs/python-net/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/cs/python-net/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/cs/python-net/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/cs/python-net/conversion/html-to-tiff/)

{{% /alert %}}