---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.3.0
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
description: "Überblick über Aktualisierungen der öffentlichen API und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und rückwärtsinkompatible Änderungen**
### **Aspose.Slides.ShapeThumbnailBounds‑Aufzählung und Aspose.Slides.IShape.GetThumbnail()-Methoden hinzugefügt**
Die Methoden GetThumbnail() und GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) werden verwendet, um ein separates Shape‑Thumbnail zu erzeugen. Die Aufzählung ShapeThumbnailBounds definiert die möglichen Thumbnail‑Grenztypen für Shapes.
### **Eigenschaft UniqueId wurde zu Aspose.Slides.IShape hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.UniqueId liefert einen eindeutigen Shape‑Bezeichner im Umfang einer Präsentation. Diese eindeutigen Bezeichner werden in benutzerdefinierten Shape‑Tags gespeichert.
### **Signatur der SetGroupingItem‑Methode in IChartCategoryLevelsManager geändert**
Signatur der IChartCategoryLevelsManager‑Methode

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

ist jetzt veraltet und wurde durch die Signatur

``` csharp

 void SetGroupingItem(int level, object value);

``` 

ersetzt.

Aufrufe wie

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

müssen zu Aufrufen wie

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

geändert werden.

Übergeben Sie einen Wert wie "Group 1" an SetGroupingItem, jedoch keinen Wert vom Typ IChartDataCell. Das Erstellen eines IChartDataCell mit definiertem Arbeitsblatt, Zeile und Spalte für Kategorienstufen muss einige Voraussetzungen erfüllen und wurde in die Methode SetGroupingItem(int, object) gekapselt.
### **SlideId‑Eigenschaft zur Aspose.Slides.IBaseSlide‑Schnittstelle hinzugefügt**
Die Eigenschaft SlideId liefert einen eindeutigen Folienbezeichner.
### **SoundName‑Eigenschaft zu ISlideShowTransition hinzugefügt**
Lese‑/schreibbare Zeichenkette. Gibt einen menschenlesbaren Namen für den Sound der Übergangsanimation an. Die Sound‑Eigenschaft muss zugewiesen sein, um den Soundnamen zu erhalten oder zu setzen. Dieser Name erscheint in der PowerPoint‑Benutzeroberfläche, wenn der Übergangssound manuell konfiguriert wird. Es kann eine PptxException ausgelöst werden, wenn die Sound‑Eigenschaft nicht zugewiesen ist.
### **Typ der Eigenschaft ChartSeriesGroup.Type geändert**
Die Eigenschaft ChartSeriesGroup.Type wurde von der Aufzählung ChartType zur neuen Aufzählung CombinableSeriesTypesGroup geändert. Die Aufzählung CombinableSeriesTypesGroup repräsentiert die Gruppen kombinierbarer Serienarten.
### **Unterstützung zur Erzeugung einzelner Shape‑Thumbnails hinzugefügt**
Aspose.Slides.ShapeThumbnailBounds

Neue Mitglieder in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)