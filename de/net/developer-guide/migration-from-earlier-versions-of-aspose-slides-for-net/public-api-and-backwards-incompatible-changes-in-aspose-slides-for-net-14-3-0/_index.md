---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.3.0
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
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint-PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und rückwärts inkompatible Änderungen**
### **Aspose.Slides.ShapeThumbnailBounds Aufzählung und Aspose.Slides.IShape.GetThumbnail()-Methoden hinzugefügt**
Die Methoden GetThumbnail() und GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) werden verwendet, um ein separates Shape‑Thumbnail zu erstellen. Die Aufzählung ShapeThumbnailBounds definiert die möglichen Shape‑Thumbnail‑Grenztypen.
### **Die Eigenschaft UniqueId wurde zu Aspose.Slides.IShape hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.UniqueId liefert einen eindeutigen Shape‑Bezeichner im Gültigkeitsbereich der Präsentation. Diese eindeutigen Bezeichner werden in benutzerdefinierten Shape‑Tags gespeichert.
### **Signatur der SetGroupingItem‑Methode in IChartCategoryLevelsManager geändert**
Signatur der IChartCategoryLevelsManager‑Methode

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

ist jetzt veraltet und wurde durch die folgende Signatur ersetzt

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Aufrufe wie

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

müssen geändert werden zu Aufrufen wie

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Übergeben Sie einen Wert wie "Group 1" an SetGroupingItem, jedoch keinen Wert vom Typ IChartDataCell. Das Erzeugen eines IChartDataCell mit einem definierten Arbeitsblatt, Zeile und Spalte für Kategorie‑Ebenen muss gewisse Anforderungen erfüllen und wurde in die Methode SetGroupingItem(int, object) gekapselt.
### **SlideId‑Eigenschaft zur Aspose.Slides.IBaseSlide‑Schnittstelle hinzugefügt**
Die Eigenschaft SlideId liefert einen eindeutigen Folien‑Bezeichner.
### **SoundName‑Eigenschaft zu ISlideShowTransition hinzugefügt**
Lese‑/Schreib‑String. Gibt einen menschenlesbaren Namen für den Sound der Folienübergangs an. Die Sound‑Eigenschaft muss zugewiesen werden, um den Sound‑Namen zu erhalten oder zu setzen. Dieser Name wird in der PowerPoint‑Benutzeroberfläche angezeigt, wenn der Übergangs‑Sound manuell konfiguriert wird. Kann eine PptxException auslösen, wenn die Sound‑Eigenschaft nicht zugewiesen ist.
### **Typ der ChartSeriesGroup.Type‑Eigenschaft geändert**
Die Eigenschaft ChartSeriesGroup.Type wurde von der Aufzählung ChartType zur neuen Aufzählung CombinableSeriesTypesGroup geändert. Die Aufzählung CombinableSeriesTypesGroup repräsentiert die Gruppen kombinierbarer Serien‑Typen.
### **Unterstützung zum Erzeugen individueller Shape‑Thumbnails hinzugefügt**
Aspose.Slides.ShapeThumbnailBounds

Neue Mitglieder in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)