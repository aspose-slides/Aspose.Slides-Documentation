---
title: Támogatott fájlformátumok
type: docs
weight: 20
url: /hu/jasperreports/supported-file-formats/
description: "Tekintse meg, hogy az Aspose.Slides for JasperReports milyen bemenetet fogad, és mely fájlformátumokba exportálja a jelentéseket."
---
## **Bemenet**

Az Aspose.Slides for JasperReports jelentéseket exportál; nem konvertálja a meglévő prezentációkat. Az exportálók egy kitöltött JasperReports jelentést (`JasperPrint`) vesznek fel, például a `JasperFillManager` eredményét vagy egy *.jrprint* fájlból betöltött kitöltött jelentést.

## **Kimeneti formátumok**

Az alábbi táblázat felsorolja azokat a formátumokat, amelyekbe az Aspose.Slides for JasperReports egy jelentést exportál, valamint az egyes formátumok írásáért felelős exportáló osztályt.

|**Formátum**|**Leírás**|**Exportáló**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 prezentáció; egy dia a jelentés oldalanként|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint prezentáció (Office Open XML); egy dia a jelentés oldalanként|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; egy PDF oldal a jelentés oldalanként|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Egyetlen HTML fájl, egy SVG kép a jelentés oldalanként|`ASHtmlExporter`|

Nincs exportáló a PPS és PPSX diavetítési formátumokhoz. Ha egy PPTX exportnak *.ppsx* fájlnevet adunk, akkor is PPTX prezentáció jön létre, nem diavetítés. Ahhoz, hogy lásd, hogyan használják az egyes exportálókat, lásd a [PPT, PPTX, PDF and HTML Export](/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/).