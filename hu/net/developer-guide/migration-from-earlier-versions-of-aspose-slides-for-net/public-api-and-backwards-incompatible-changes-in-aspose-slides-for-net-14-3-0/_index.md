---
title: Nyilvános API és visszafelé kompatibilitási problémákat okozó változások az Aspose.Slides for .NET 14.3.0-ban
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migrálás
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé kompatibilitási változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
## **Nyilvános API és visszafelé kompatibilitási problémákat okozó változások**
### **Aspose.Slides.ShapeThumbnailBounds felsorolás és Aspose.Slides.IShape.GetThumbnail() metódusok hozzáadva**
A GetThumbnail() és a GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) metódusok egy külön alakzat‑miniatűr létrehozására szolgálnak. A ShapeThumbnailBounds felsorolás meghatározza a lehetséges alakzat‑miniatűr határ típusaikat.
### **Az UniqueId tulajdonság hozzá lett adva az Aspose.Slides.IShape-hez**
Az Aspose.Slides.IShape.UniqueId tulajdonság egy prezentáció keretében egyedi alakzat‑azonosítót ad. Ezek az egyedi azonosítók az alakzat egyéni címkéiben tárolódnak.
### **A SetGroupingItem metódus aláírása megváltozott az IChartCategoryLevelsManager‑ben**
Az IChartCategoryLevelsManager metódus aláírása

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

elavult, és helyettesítve lett a következő aláírással

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Az olyan hívásokat, mint

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

meg kell változtatni a következőre

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

A SetGroupingItem‑ba „Group 1” típusú értéket kell átadni, nem IChartDataCell típusút. Az IChartDataCell létrehozása egy meghatározott munkalappal, sorral és oszloppal a kategória szintekhez bizonyos követelményeket kell, hogy teljesítsen, és ez be van foglalva a SetGroupingItem(int, object) metódusba.
### **SlideId tulajdonság hozzáadva az Aspose.Slides.IBaseSlide interfészhez**
A SlideId tulajdonság egy egyedi diavetítés‑azonosítót ad.
### **SoundName tulajdonság hozzáadva az ISlideShowTransition‑hez**
Olvasható‑írható karakterlánc. Az átmenet hangjának emberi olvasásra alkalmas nevét adja meg. A Sound tulajdonságot meg kell adni a hangnév lekérdezéséhez vagy beállításához. Ez a név megjelenik a PowerPoint felhasználói felületén, amikor kézzel állítják be az átmenet hangját. PptxException‑t dobhat, ha a Sound tulajdonság nincs megadva.
### **A ChartSeriesGroup.Type tulajdonság típusa megváltozott**
A ChartSeriesGroup.Type tulajdonság a ChartType felsorolásról az új CombinableSeriesTypesGroup felsorolásra változott. A CombinableSeriesTypesGroup felsorolás a kombinálható sorozattípusok csoportjait képviseli.
### **Támogatás egyedi alakzat‑miniatűrök létrehozásához hozzáadva**
Aspose.Slides.ShapeThumbnailBounds

Új tagok az Aspose.Slides.IShape, Aspose.Slides.Shape osztályokban:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)