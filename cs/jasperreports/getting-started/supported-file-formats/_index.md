---
title: Podporované formáty souborů
type: docs
weight: 20
url: /cs/jasperreports/supported-file-formats/
description: "Podívejte se, jaké vstupy přijímá Aspose.Slides pro JasperReports a do jakých formátů souborů exportuje zprávy."
---
## **Vstup**

Aspose.Slides pro JasperReports exportuje zprávy; nepřevádí existující prezentace. Jeho exportéry používají vyplněnou zprávu JasperReports (`JasperPrint`), například výsledek `JasperFillManager` nebo vyplněnou zprávu načtenou ze souboru *.jrprint*.

## **Výstupní formáty**

Následující tabulka uvádí formáty, do kterých Aspose.Slides pro JasperReports exportuje zprávu, a třídu exportéru, která každý z nich zapisuje.

|**Formát**|**Popis**|**Exportér**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 prezentace; jeden snímek na stránku zprávy|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint prezentace (Office Open XML); jeden snímek na stránku zprávy|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; jedna stránka PDF na stránku zprávy|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Jednoduchý HTML soubor s jedním SVG obrázkem na stránku zprávy|`ASHtmlExporter`|

Neexistuje exportér pro formáty prezentace PPS a PPSX. Pojmenování exportu PPTX souborem *.ppsx* stále vytvoří prezentaci PPTX, nikoli slideshow. Pro zobrazení, jak se každý exportér používá, viz [Export PPT, PPTX, PDF a HTML](/slides/cs/jasperreports/ppt-pptx-pdf-and-html-export/).