---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 14.8.0
linktitle: Aspose.Slides per Java 14.8.0
type: docs
weight: 70
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) e le [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introdotte con l'API Aspose.Slides per Java 14.8.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Aggiunti i metodi Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() e setOverlap(byte)**
Il metodo Aspose.Slides.Charts.IChartSeries.getOverlap() restituisce quanto le barre e le colonne devono sovrapporsi nei grafici 2D (in un intervallo da -100 a 100).  
Questo metodo non è solo per serie specifiche, ma per tutte le serie del gruppo di serie padre – è la proiezione della proprietà di gruppo appropriata.

- Utilizzare il metodo IChartSeries.getParentSeriesGroup() per accedere al gruppo di serie padre.  
- Utilizzare i metodi IChartSeriesGroup.getOverlap() e setOverlap(byte) per gestire il valore.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Aggiunto il valore Enum ShapeThumbnailBounds.Appearance**
Questo metodo di creazione delle miniature di forme consente agli sviluppatori di generare una miniatura della forma nei limiti della sua apparizione. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata ai bordi della diapositiva.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Aggiunte la classe VbaProject e l'interfaccia IVbaProject, modificati i metodi Presentation.getVbaProject() e setVbaProject(VbaProject)**
Una nuova funzionalità consente agli sviluppatori di creare e modificare progetti VBA in una presentazione.

``` java
import com.aspose.slides.*;


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

pres.save("test.pptm", SaveFormat.Pptm);
```