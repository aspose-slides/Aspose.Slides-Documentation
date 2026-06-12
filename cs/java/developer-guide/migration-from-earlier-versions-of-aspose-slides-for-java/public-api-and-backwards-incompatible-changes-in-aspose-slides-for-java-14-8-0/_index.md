---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.8.0
linktitle: Aspose.Slides pro Java 14.8.0
type: docs
weight: 70
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbíjející změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) třídy, metody, vlastnosti a podobně, jakékoli nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) zavedené v rozhraní Aspose.Slides for Java 14.8.0 API.
{{% /alert %}} 
## **Změny veřejného API**
### **Přidány metody Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() a setOverlap(byte)**
Metoda Aspose.Slides.Charts.IChartSeries.getOverlap() určuje, jak moc se mají pruhy a sloupce překrývat v 2D grafech (v rozsahu od -100 do 100).  
Tato metoda není určena jen pro konkrétní sérii, ale pro všechny série v nadřazené skupině sérií – jedná se o projekci příslušné vlastnosti skupiny.

- Použijte metodu IChartSeries.getParentSeriesGroup() pro přístup k nadřazené skupině sérií.  
- Použijte metody IChartSeriesGroup.getOverlap() a setOverlap(byte) k nastavení hodnoty.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Přidána hodnota výčtu ShapeThumbnailBounds.Appearance**
Tato metoda vytváření náhledů tvarů umožňuje vývojářům vygenerovat náhled tvaru v mezích jeho vzhledu. Zohledňuje všechny efekty tvaru. Vygenerovaný náhled tvaru je omezen mezemi snímku.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Přidána třída VbaProject a rozhraní IVbaProject, změněny metody Presentation.getVbaProject() a setVbaProject(VbaProject)**
Nová funkce umožňuje vývojářům vytvářet a upravovat VBA projekty v prezentaci.

``` java

 Presentation pres = new Presentation();

// Vytvořte nový VBA projekt

pres.setVbaProject(new VbaProject());

// Přidejte prázdný modul do VBA projektu

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Nastavte zdrojový kód modulu

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Vytvořte odkaz na <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Vytvořte odkaz na Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Přidejte odkazy do VBA projektu

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```