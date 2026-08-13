---
title: "Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.8.0-ban"
linktitle: "Aspose.Slides for Java 14.8.0"
type: docs
weight: 70
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java publikus API frissítéseit és törő változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) a Aspose.Slides for Java 14.8.0 API-val kapcsolatban.

{{% /alert %}} 
## **Publikus API változások**
### **Hozzáadva az Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() és setOverlap(byte) metódusok**
Az Aspose.Slides.Charts.IChartSeries.getOverlap() meghatározza, hogy a sávok és oszlopok mennyire fedjék egymást a 2D diagramokon (‑100 és 100 közötti tartományban).  
Ez a metódus nem csak egy adott sorozatra vonatkozik, hanem a szülő sorozatcsoport összes sorozatára – ez a megfelelő csoporttulajdonság projekciója.

- Használja az IChartSeries.getParentSeriesGroup() metódust a szülő sorozatcsoport eléréséhez.
- Használja az IChartSeriesGroup.getOverlap() és a setOverlap(byte) metódusokat az érték kezeléséhez.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Hozzáadva a ShapeThumbnailBounds.Appearance enum érték**
Ez a formakép előállítási módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül hozzanak létre egy formaképet. Figyelembe veszi az összes formaeffektet. Az előállított formakép méretét a dia határai korlátozzák.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Hozzáadva a VbaProject osztály és az IVbaProject interfész, módosítva a Presentation.getVbaProject() és a setVbaProject(VbaProject) metódusok**
Egy új funkció lehetővé teszi a fejlesztők számára, hogy VBA projekteket hozzanak létre és szerkesszenek egy prezentációban.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Új VBA projekt létrehozása

pres.setVbaProject(new VbaProject());

// Üres modul hozzáadása a VBA projekthez

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Modul forráskód beállítása

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Hivatkozás létrehozása a <stdole> típusra

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

pres.save("test.pptm", SaveFormat.Pptm);
```