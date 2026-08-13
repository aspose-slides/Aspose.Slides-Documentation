---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.5.0-ban
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Ellenőrizze a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy gördülékenyen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) az Aspose.Slides for Java 15.5.0 API-val kapcsolatban.
{{% /alert %}} 
## **Nyilvános API változások**
### **A CommonSlideViewProperties osztály és az ICommonSlideViewProperties interfész hozzá lettek adva**
A com.aspose.slides.CommonSlideViewProperties osztály (és annak interfésze com.aspose.slides.ICommonSlideViewProperties) a közös dianézet tulajdonságokat képviseli (jelenleg a nézetméretezési beállításokat).
### **Az IAxis.getLabelOffset(), setLabelOffset(int) metódusok hozzá lettek adva**
Az IAxis.getLabelOffset(), setLabelOffset(int) metódusok lehetővé teszik a címkék tengelyhez való távolságának lekérdezését és megadását. Alkalmazható kategória vagy dátum tengelyre.
### **Az IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) metódusok hozzá lettek adva**
A getAutofitType(), setAutofitType(/**TextAutofitType**/byte) metódusok hozzá lettek adva a com.aspose.slides.IChartTextBlockFormat interfészhez. Ennek az értéknek a módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a megjelenítésre).
### **Az IChartTextBlockFormat.getWrapText(), setWrapText(byte) metódusok hozzá lettek adva**
A getWrapText(), setWrapText(/**NullableBool**/byte) metódusok hozzá lettek adva a com.aspose.slides.IChartTextBlockFormat interfészhez. Ennek az értéknek a módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2007/2013-ban).
### **A margók kezelésére szolgáló metódusok hozzá lettek adva az IChartTextBlockFormat-hoz**
A getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() és setMarginBottom(double) metódusok hozzá lettek adva a com.aspose.slides.IChartTextBlockFormat interfészhez. Ezeknek az értékeknek a módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a megjelenítésre).
### **A ViewProperties.getNotesViewProperties() metódus hozzá lett adva**
A com.aspose.slides.ViewProperties.getNotesViewProperties() tulajdonság hozzá lett adva. Ez a jegyzetnézet módhoz tartozó közös nézet tulajdonságokat adja vissza.
### **A ViewProperties.getSlideViewProperties() metódus hozzá lett adva**
A com.aspose.slides.ViewProperties.getSlideViewProperties() metódus hozzá lett adva. Ez a dianézet módhoz tartozó közös nézet tulajdonságokat adja vissza.