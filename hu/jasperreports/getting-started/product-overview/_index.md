---
title: Termék áttekintése
type: docs
weight: 10
url: /hu/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Üdvözöljük az Aspose.Slides for JasperReports-ben!**

Az Aspose.Slides for JasperReports egy olyan könyvtár, amelyet kifejezetten fejlesztők számára terveztek és fejlesztettek, akiknek egyszerűen kell exportálniuk a JasperReports jelentéseket Microsoft PowerPoint előadás (PPT) és Microsoft PowerPoint bemutató (PPS) formátumokba Java alkalmazásaikban. A jelentés minden funkciója a legnagyobb pontossággal kerül átalakításra Microsoft PowerPoint prezentációkká. Az Aspose.Slides for JasperReports támogatja a JasperReports 5+ verziókat.

## **A termék leírása**
JasperReports és JasperServer nem rendelkeznek beépített képességekkel a jelentések Microsoft PowerPoint prezentációként történő exportálásához, de az Aspose.Slides for JasperReports hozzáférést biztosít két további exportformátumhoz: 

- PPT – PowerPoint előadás az Aspose.Slides segítségével
- PPS – PowerPoint bemutató az Aspose.Slides segítségével
- PPTX – PowerPoint előadás az Aspose.Slides segítségével
- PPSX – PowerPoint bemutató az Aspose.Slides segítségével

Az Aspose.Slides for JasperReports belsőleg a 100%-ban tiszta Java könyvtárainkat, az Aspose.Slides for Java és az Aspose.Metafiles for Java-t használja, melyek világszínvonalú könyvtárak szerveroldali prezentációk és metafájlok feldolgozásához.

Az Aspose.Slides for JasperReports lehetővé teszi, hogy bármely jelentést PPT vagy PPS formátumban exportáljon.

### **Kimeneti példa**
Az ASPptExporter osztály az ASAbstractExporter osztályból származik, így ugyanúgy használható, mint bármely más szabványos exportáló. Ez a rövid példa tipikus kódot és egy screenshotot mutat egy MS PowerPoint-ban megnyitott jelentésről. Részletes példákat a mellékelt demo jelentésekben talál.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Az JasperReports xmldatasource demóval generált prezentáció** 

![Az JasperReports által generált prezentáció](product-overview_2.png)