---
title: API pubbliche e modifiche incompatibili con versioni precedenti in Aspose.Slides per Java 14.8.0
linktitle: Aspose.Slides per Java 14.8.0
type: docs
weight: 70
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrazione
- "codice legacy"
- "codice moderno"
- "approccio legacy"
- "approccio moderno"
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili con versioni precedenti in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà aggiunti, ecc., eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introdotte con l'Aspose.Slides for Java 14.8.0 API.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Aggiunti i metodi Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() e setOverlap(byte)**
Il metodo Aspose.Slides.Charts.IChartSeries.getOverlap() restituisce quanto le barre e le colonne devono sovrapporsi nei grafici 2D (in un intervallo da -100 a 100).  
Questo metodo non è solo per una serie specifica, ma per tutte le serie del gruppo di serie padre: è la proiezione della proprietà di gruppo appropriata.

- Utilizzare il metodo IChartSeries.getParentSeriesGroup() per accedere al gruppo di serie padre.
- Utilizzare i metodi IChartSeriesGroup.getOverlap() e setOverlap(byte) per gestire il valore.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Aggiunto il valore Enum ShapeThumbnailBounds.Appearance**
Questo metodo di creazione delle miniatura delle forme consente agli sviluppatori di generare una miniatura della forma nei limiti della sua apparizione. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai bordi della diapositiva.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Aggiunta la classe VbaProject e l'interfaccia IVbaProject, modificati i metodi Presentation.getVbaProject() e setVbaProject(VbaProject)**
Una nuova funzionalità consente agli sviluppatori di creare e modificare progetti VBA in una presentazione.

``` java

 Presentation pres = new Presentation();

// Crea nuovo progetto VBA

pres.setVbaProject(new VbaProject());

// Aggiungi modulo vuoto al progetto VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Imposta il codice sorgente del modulo

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Crea riferimento a <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crea riferimento a Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Aggiungi riferimenti al progetto VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```