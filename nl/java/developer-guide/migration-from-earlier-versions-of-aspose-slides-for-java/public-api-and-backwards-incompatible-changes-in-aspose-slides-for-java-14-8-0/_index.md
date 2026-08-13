---
title: Publieke API en onverenigbare terugwaartse wijzigingen in Aspose.Slides voor Java 14.8.0
linktitle: Aspose.Slides voor Java 14.8.0
type: docs
weight: 70
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beoordeel publieke API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) geïntroduceerd met de Aspose.Slides for Java 14.8.0 API.
{{% /alert %}} 
## **Wijzigingen in de publieke API**
### **Toegevoegd de Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() en setOverlap(byte) methoden**
De Aspose.Slides.Charts.IChartSeries.getOverlap() bepaalt hoeveel balken en kolommen moeten overlappen op 2D‑grafieken (in een bereik van -100 tot 100). Deze methode is niet alleen voor specifieke series maar voor alle series van de bovenliggende seriesgroep – dit is een projectie van de bijbehorende groeps‑eigenschap.

- Gebruik de IChartSeries.getParentSeriesGroup()‑methode om toegang te krijgen tot de bovenliggende seriesgroep.
- Gebruik de IChartSeriesGroup.getOverlap()‑ en setOverlap(byte)‑methoden om de waarde te beheren.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Toegevoegd de ShapeThumbnailBounds.Appearance enum‑waarde**
Deze methode om vorm‑miniaturen te maken stelt ontwikkelaars in staat om een vorm‑miniatuur te genereren binnen de grenzen van zijn weergave. Hierbij wordt rekening gehouden met alle vorm‑effecten. De gegenereerde vorm‑miniatuur wordt beperkt door de slide‑grenzen.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Toegevoegd de VbaProject‑klasse en IVbaProject‑interface, gewijzigd de Presentation.getVbaProject() en setVbaProject(VbaProject) methoden**
Een nieuwe functie stelt ontwikkelaars in staat om VBA‑projecten in een presentatie te maken en te bewerken.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Maak een nieuw VBA-project

pres.setVbaProject(new VbaProject());

// Voeg een lege module toe aan het VBA‑project

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Stel de broncode van de module in

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Maak verwijzing naar <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Maak verwijzing naar Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Voeg verwijzingen toe aan het VBA‑project

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```