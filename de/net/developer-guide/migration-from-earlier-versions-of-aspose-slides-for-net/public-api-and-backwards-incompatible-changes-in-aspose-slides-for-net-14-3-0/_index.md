---
title: Öffentliche API und abwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.3.0
linktitle: Aspose.Slides für .NET 14.3.0
type: docs
weight: 50
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die kritischen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und abwärtsinkompatible Änderungen**
### **Aspose.Slides.ShapeThumbnailBounds Aufzählung und Aspose.Slides.IShape.GetThumbnail() Methoden hinzugefügt**
Die Methoden GetThumbnail() und GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) werden verwendet, um ein separates Shape‑Thumbnail zu erstellen. Die Aufzählung ShapeThumbnailBounds definiert die möglichen Typen für Shape‑Thumbnail‑Grenzen.
### **Eigenschaft UniqueId wurde zu Aspose.Slides.IShape hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.UniqueId liefert einen eindeutigen Shape‑Bezeichner im Geltungsbereich einer Präsentation. Diese eindeutigen Bezeichner werden in benutzerdefinierten Shape‑Tags gespeichert.
### **Signatur der SetGroupingItem‑Methode in IChartCategoryLevelsManager geändert**
Signatur der IChartCategoryLevelsManager‑Methode

``` csharp
 void SetGroupingItem(int level, IChartDataCell value);
``` 

ist nun veraltet und wurde durch die Signatur

``` csharp
 void SetGroupingItem(int level, object value);
``` 

ersetzt.

Aufrufe wie

``` csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
``` 

müssen geändert werden zu Aufrufen wie

``` csharp
 .SetGroupingItem(1, "Group 1");
``` 

Übergeben Sie einen Wert wie "Group 1" an SetGroupingItem, jedoch keinen Wert vom Typ IChartDataCell. Das Erzeugen eines IChartDataCell mit einem definierten Arbeitsblatt, einer Zeile und einer Spalte für Kategorienstufen muss bestimmte Anforderungen erfüllen und wurde in der Methode SetGroupingItem(int, object) gekapselt.
### **Eigenschaft SlideId zur Aspose.Slides.IBaseSlide‑Schnittstelle hinzugefügt**
Die Eigenschaft SlideId liefert eine eindeutige Folienkennung.
### **Eigenschaft SoundName zu ISlideShowTransition hinzugefügt**
Lese‑/Schreib‑String. Gibt einen menschenlesbaren Namen für den Sound der Folienübergangs‑Animation an. Die Sound‑Eigenschaft muss zugewiesen sein, um den Soundnamen zu bekommen oder zu setzen. Dieser Name wird in der PowerPoint‑Benutzeroberfläche angezeigt, wenn der Übergangssound manuell konfiguriert wird. Kann PptxException werfen, wenn die Sound‑Eigenschaft nicht zugewiesen ist.
### **Typ der Eigenschaft ChartSeriesGroup.Type geändert**
Die Eigenschaft ChartSeriesGroup.Type wurde von der Aufzählung ChartType zur neuen Aufzählung CombinableSeriesTypesGroup geändert. Das Enum CombinableSeriesTypesGroup repräsentiert Gruppen von kombinierbaren Serien‑Typen.
### **Unterstützung für das Erzeugen einzelner Shape‑Thumbnails hinzugefügt**
Aspose.Slides.ShapeThumbnailBounds

Neue Mitglieder in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)