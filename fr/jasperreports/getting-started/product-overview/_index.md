---
title: Aperçu du produit
type: docs
weight: 10
url: /fr/jasperreports/product-overview/
description: "Découvrez ce que fait Aspose.Slides for JasperReports, quelles versions de JasperReports et quels formats de sortie il prend en charge, et à quoi servent ses deux jars."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Description du produit**

Aspose.Slides for JasperReports exporte des rapports JasperReports vers des présentations PowerPoint, dans les applications Java et dans JasperReports Server, sans Microsoft PowerPoint. Il prend en charge JasperReports 3.7.2 à 6.16.0, avec un jar distinct pour chaque plage de versions — voir [Installation d'Aspose.Slides for JasperReports](/slides/fr/jasperreports/installing-aspose-slides-for-jasperreports/).

Il exporte un rapport rempli vers quatre formats, une diapositive ou page par page de rapport :

- PPT – présentation PowerPoint 97–2003
- PPTX – présentation PowerPoint (Office Open XML)
- PDF
- HTML

Le produit se compose de deux parties :

- Le jar de bibliothèque ajoute les exportateurs `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` et `ASHtmlExporter` à la bibliothèque JasperReports.
- Le jar du serveur fournit des actions d'exportation pour les mêmes quatre formats, que vous enregistrez dans JasperReports Server — voir [Intégration avec JasperServer](/slides/fr/jasperreports/integration-with-jasperserver/).

### **Exemple de sortie**

Les exportateurs étendent les propres classes d'exportation de JasperReports et sont utilisés de la même manière : leur transmettre le rapport rempli et le fichier de sortie, puis appeler `exportReport`. Pour un programme complet qui remplit un rapport et l'exporte en PPTX, voir [Votre première exportation](/slides/fr/jasperreports/#your-first-export) ; pour les quatre formats, voir [Export PPT, PPTX, PDF et HTML](/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/).

![Un rapport exporté vers une présentation sans licence, avec le filigrane d'évaluation au centre de la diapositive](product-overview_2.png)