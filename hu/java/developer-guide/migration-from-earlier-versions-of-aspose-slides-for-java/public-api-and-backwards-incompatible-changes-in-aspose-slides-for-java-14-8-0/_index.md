---
title: Általános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.8.0-ban
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és a törésponti változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) az Aspose.Slides for Java 14.8.0 API-val.
{{% /alert %}} 
## **Publikus API változások**
### **Hozzáadva az Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() és a setOverlap(byte) metódusok**
Az Aspose.Slides.Charts.IChartSeries.getOverlap() megadja, hogy a sávok és oszlopok mennyire fedjék egymást 2D diagramokon (‑100 és 100 közötti tartományban).  
Ez a metódus nem csak egy adott sorozatra vonatkozik, hanem a szülő sorozatcsoport összes sorozatára – ez a megfelelő csoporttulajdonság leképezése.

- Használja az IChartSeries.getParentSeriesGroup() metódust a szülő sorozatcsoport eléréséhez.
- Használja az IChartSeriesGroup.getOverlap() és a setOverlap(byte) metódusokat az érték kezeléséhez.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Hozzáadva a ShapeThumbnailBounds.Appearance enum érték**
Ez a forma bélyegképek létrehozási mód lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül generáljanak bélyegképet. Figyelembe veszi az összes formaeffektet. A létrehozott forma bélyegkép a dia határai által lesz korlátozva.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Hozzáadva a VbaProject osztály és az IVbaProject interfész, módosítva a Presentation.getVbaProject() és a setVbaProject(VbaProject) metódusok**
Új funkcióval a fejlesztők VBA projektek létrehozását és szerkesztését végezhetik egy prezentációban.

``` java

 Presentation pres = new Presentation();

// Új VBA projekt létrehozása

pres.setVbaProject(new VbaProject());

// Üres modul hozzáadása a VBA projekthez

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Modul forráskód beállítása

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Hivatkozás létrehozása a <stdole>-ra

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Hivatkozás létrehozása az Office-ra

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Hivatkozások hozzáadása a VBA projekthez

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```