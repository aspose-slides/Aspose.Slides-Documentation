---
title: Obsługiwane formaty plików
type: docs
weight: 20
url: /pl/jasperreports/supported-file-formats/
description: "Zobacz, co Aspose.Slides for JasperReports przyjmuje jako dane wejściowe i do jakich formatów plików eksportuje raporty."
---
## **Input**

Aspose.Slides for JasperReports eksportuje raporty; nie konwertuje istniejących prezentacji. Jego eksporterzy przyjmują wypełniony raport JasperReports (`JasperPrint`), taki jak wynik `JasperFillManager` lub wypełniony raport załadowany z pliku *.jrprint*.

## **Formaty wyjściowe**

Poniższa tabela przedstawia formaty, do których Aspose.Slides for JasperReports eksportuje raport, oraz klasę eksportera zapisującą każdy z nich.

|**Format**|**Opis**|**Eksporter**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentacja PowerPoint 97–2003; jeden slajd na stronę raportu|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentacja PowerPoint (Office Open XML); jeden slajd na stronę raportu|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; jedna strona PDF na stronę raportu|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Pojedynczy plik HTML z jednym obrazem SVG na stronę raportu|`ASHtmlExporter`|

Nie ma eksportera dla formatów pokazu slajdów PPS i PPSX. Nadanie eksportowi PPTX nazwy pliku *.ppsx* nadal tworzy prezentację PPTX, a nie pokaz slajdów. Aby zobaczyć, jak używany jest każdy eksporter, zobacz [Eksport PPT, PPTX, PDF i HTML](/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/).