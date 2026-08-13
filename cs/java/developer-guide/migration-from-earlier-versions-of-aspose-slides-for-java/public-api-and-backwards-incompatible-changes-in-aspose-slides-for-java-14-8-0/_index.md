---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.8.0
linktitle: Aspose.Slides pro Java 14.8.0
type: docs
weight: 70
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbití změny v Aspose.Slides pro Java a hladce migrujte svá řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) třídy, metody, vlastnosti a podobně, všechna nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) zavedená v rozhraní Aspose.Slides pro Java 14.8.0 API.

{{% /alert %}} 
## **Změny veřejného API**
### **Přidány metody Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() a setOverlap(byte)**
Metoda Aspose.Slides.Charts.IChartSeries.getOverlap() určuje, jak moc mají sloupce a pruhy překrývat na 2D grafech (v rozmezí od -100 do 100).  
Tato metoda není určena jen pro konkrétní řadu, ale pro všechny řady nadřazené skupiny řad – jde o projekci příslušné vlastnosti skupiny.

- Použijte metodu IChartSeries.getParentSeriesGroup() pro přístup k nadřazené skupině řad.  
- Použijte metody IChartSeriesGroup.getOverlap() a setOverlap(byte) pro správu hodnoty.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Přidána hodnota výčtu ShapeThumbnailBounds.Appearance**
Tato metoda vytváření náhledů tvarů umožňuje vývojářům vygenerovat náhled tvaru v mezích jeho vzhledu. Zohledňuje všechny efekty tvaru. Vygenerovaný náhled tvaru je omezen mezemi snímku.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Přidána třída VbaProject a rozhraní IVbaProject, změněny metody Presentation.getVbaProject() a setVbaProject(VbaProject)**
Nová funkce umožňuje vývojářům vytvářet a upravovat projekty VBA v prezentaci.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Vytvořte nový projekt VBA

pres.setVbaProject(new VbaProject());

// Přidejte prázdný modul do projektu VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Nastavte zdrojový kód modulu

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Vytvořte referenci na <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Vytvořte referenci na Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Přidejte odkazy do projektu VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);

```