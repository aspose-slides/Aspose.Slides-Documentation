---
title: Formats de fichiers pris en charge
type: docs
weight: 20
url: /fr/jasperreports/supported-file-formats/
description: "Découvrez ce que Aspose.Slides for JasperReports accepte en entrée et quels formats de fichiers il utilise pour exporter les rapports."
---
## **Entrée**

Aspose.Slides for JasperReports exporte des rapports ; il ne convertit pas les présentations existantes. Ses exportateurs prennent un rapport JasperReports rempli (`JasperPrint`), tel que le résultat de `JasperFillManager` ou un rapport rempli chargé depuis un fichier *.jrprint*.

## **Formats de sortie**

Le tableau suivant répertorie les formats vers lesquels Aspose.Slides for JasperReports exporte un rapport, ainsi que la classe exportatrice qui écrit chacun d’eux.

|**Format**|**Description**|**Exportateur**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97–2003 ; une diapositive par page de rapport|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint (Office Open XML) ; une diapositive par page de rapport|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format ; une page PDF par page de rapport|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Un seul fichier HTML avec une image SVG par page de rapport|`ASHtmlExporter`|

Il n'existe aucun exportateur pour les formats de diaporama PPS et PPSX. Donner à une exportation PPTX un nom de fichier *.ppsx* produit toujours une présentation PPTX, et non un diaporama. Pour voir comment chaque exportateur est utilisé, consultez [Exportation PPT, PPTX, PDF et HTML](/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/).