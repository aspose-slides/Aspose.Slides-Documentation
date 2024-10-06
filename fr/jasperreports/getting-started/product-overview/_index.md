---
title: Vue d'ensemble du produit
type: docs
weight: 10
url: /jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **Bienvenue dans la documentation d'Aspose.Slides pour JasperReports !**
Aspose.Slides pour JasperReports est une bibliothèque spécialement conçue et développée pour les développeurs qui ont besoin d'exporter facilement des rapports de JasperReports vers les formats de présentation Microsoft PowerPoint (PPT) et Microsoft PowerPoint Show (PPS) dans leurs applications Java. Toutes les fonctionnalités de rapport sont converties avec le plus haut degré de précision en présentations Microsoft PowerPoint. Aspose.Slides pour JasperReports inclut la prise en charge de JasperReports 5+.

{{% /alert %}} 

## **Description du produit**
JasperReports et JasperServer n'ont pas de capacités intégrées pour exporter des rapports en tant que présentations Microsoft PowerPoint, mais Aspose.Slides pour JasperReports vous donne accès à deux formats d'exportation supplémentaires : 

- PPT – Présentation PowerPoint via Aspose.Slides
- PPS - Spectacle PowerPoint via Aspose.Slides
- PPTX – Présentation PowerPoint via Aspose.Slides
- PPSX - Spectacle PowerPoint via Aspose.Slides

Aspose.Slides pour JasperReports utilise en interne nos bibliothèques 100% Java pures Aspose.Slides pour Java et Aspose.Metafiles pour Java, des bibliothèques de classe mondiale pour le traitement des présentations côté serveur et des mét fichiers.

Aspose.Slides pour JasperReports permet d'exporter n'importe quel rapport au format PPT ou PPS.

### **Exemple de sortie**
La classe ASPptExporter étend la classe ASAbstractExporter afin qu'elle puisse être utilisée de la même manière que n'importe quel autre exportateur standard. Cet exemple court montre un code typique et une capture d'écran d'un rapport visualisé dans MS PowerPoint. Des exemples détaillés peuvent être trouvés dans les rapports de démonstration fournis. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Présentation générée avec le démonstrateur xmldatasource de JasperReports** 

![todo:image_alt_text](product-overview_2.png)