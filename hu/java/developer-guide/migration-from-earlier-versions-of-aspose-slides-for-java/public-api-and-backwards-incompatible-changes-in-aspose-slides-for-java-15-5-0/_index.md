---
title: Nyilvános API és visszamenőlegesen nem kompatibilis változások az Aspose.Slides for Java 15.5.0-ban
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) a Aspose.Slides for Java 15.5.0 API-val kapcsolatban.

{{% /alert %}} 
## **Nyilvános API változások**
### **A CommonSlideViewProperties osztály és az ICommonSlideViewProperties interfész hozzáadva**
A com.aspose.slides.CommonSlideViewProperties osztály (és annak interfésze com.aspose.slides.ICommonSlideViewProperties) közös diavetítési tulajdonságokat képviseli (jelenleg a nézet méretezési beállításait).

### **IAxis.getLabelOffset(), setLabelOffset(int) metódusok hozzáadva**
Az IAxis.getLabelOffset(), setLabelOffset(int) metódusok lehetővé teszik a címkék tengelytől való távolságának lekérdezését és beállítását. Kategória vagy dátum tengelyre alkalmazva.

### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) metódusok hozzáadva**
A getAutofitType(), setAutofitType(/**TextAutofitType**/byte) metódusok a com.aspose.slides.IChartTextBlockFormat interfészhez lettek hozzáadva.
Ennek az értéknek a módosítása csak bizonyos diagramrészekre, a DataLabel és a DataLabelFormat elemekre gyakorolhat hatást (teljes támogatás a PowerPoint 2013‑ban; a PowerPoint 2007‑ben nincs hatása a megjelenítésre).

### **Az IChartTextBlockFormat.getWrapText(), setWrapText(byte) metódusok hozzáadva**
A getWrapText(), setWrapText(/**NullableBool**/byte) metódusok a com.aspose.slides.IChartTextBlockFormat interfészhez lettek hozzáadva.
Ennek az értéknek a módosítása csak bizonyos diagramrészekre, a DataLabel és a DataLabelFormat elemekre gyakorolhat hatást (teljes támogatás a PowerPoint 2007/2013‑ban).

### **A margók kezelésére szolgáló metódusok hozzáadva az IChartTextBlockFormat-hez**
A getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() és setMarginBottom(double) metódusok a com.aspose.slides.IChartTextBlockFormat interfészhez lettek hozzáadva.
Ezeknek az értékeknek a módosítása csak bizonyos diagramrészekre, a DataLabel és a DataLabelFormat elemekre gyakorolhat hatást (teljes támogatás a PowerPoint 2013‑ban; a PowerPoint 2007‑ben nincs hatása a megjelenítésre).

### **A ViewProperties.getNotesViewProperties() metódus hozzáadva**
A com.aspose.slides.ViewProperties.getNotesViewProperties() tulajdonság hozzá lett adva. A jegyzetek nézet módjához kapcsolódó közös nézet tulajdonságokat adja vissza.

### **A ViewProperties.getSlideViewProperties() metódus hozzáadva**
A com.aspose.slides.ViewProperties.getSlideViewProperties() metódus hozzá lett adva. A diavetítés módjához kapcsolódó közös nézet tulajdonságokat adja vissza.