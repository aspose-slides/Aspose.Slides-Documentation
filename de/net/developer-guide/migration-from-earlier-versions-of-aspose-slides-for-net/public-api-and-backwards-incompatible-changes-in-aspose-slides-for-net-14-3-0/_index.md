---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.3.0
linktitle: Aspose.Slides für .NET 14.3.0
type: docs
weight: 50
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderne Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über Aktualisierungen der öffentlichen API und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und rückwärtsinkompatible Änderungen**
### **Enumeration Aspose.Slides.ShapeThumbnailBounds und Methoden Aspose.Slides.IShape.GetThumbnail() hinzugefügt**
Die Methoden GetThumbnail() und GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) werden verwendet, um ein separates Formulargestelltes Miniaturbild zu erstellen. Die Enumeration ShapeThumbnailBounds definiert die möglichen Arten von Formulargestellten Miniaturbildgrenzen.
### **Eigenschaft UniqueId wurde zu Aspose.Slides.IShape hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.UniqueId liefert einen eindeutigen Formenbezeichner im Geltungsbereich einer Präsentation. Diese eindeutigen Bezeichner werden in benutzerdefinierten Form‑Tags gespeichert.
### **Signatur der Methode SetGroupingItem in IChartCategoryLevelsManager geändert**
Die Signatur der Methode IChartCategoryLevelsManager

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

müssen in Aufrufe wie

``` csharp
 .SetGroupingItem(1, "Group 1");
```

geändert werden.

Übergeben Sie einen Wert wie "Group 1" an SetGroupingItem, jedoch keinen Wert vom Typ IChartDataCell. Das Erzeugen eines IChartDataCell mit einem definierten Arbeitsblatt, einer Zeile und einer Spalte für Kategorienstufen muss bestimmte Anforderungen erfüllen und wurde in der Methode SetGroupingItem(int, object) gekapselt.
### **Eigenschaft SlideId zur Aspose.Slides.IBaseSlide‑Schnittstelle hinzugefügt**
Die Eigenschaft SlideId liefert einen eindeutigen Folienbezeichner.
### **Eigenschaft SoundName zu ISlideShowTransition hinzugefügt**
Schreib‑/lesbare Zeichenkette. Gibt einen menschenlesbaren Namen für den Sound des Übergangs an. Die Eigenschaft Sound muss zugewiesen sein, um den Soundnamen zu erhalten oder festzulegen. Dieser Name wird in der PowerPoint‑Benutzeroberfläche angezeigt, wenn der Übergangssound manuell konfiguriert wird. Kann eine PptxException auslösen, wenn die Sound‑Eigenschaft nicht zugewiesen ist.
### **Typ der Eigenschaft ChartSeriesGroup.Type geändert**
Die Eigenschaft ChartSeriesGroup.Type wurde von der Enumeration ChartType zur neuen Enumeration CombinableSeriesTypesGroup geändert. Die Enumeration CombinableSeriesTypesGroup stellt die Gruppen kombinierbarer Serienarten dar.
### **Unterstützung zum Erzeugen einzelner Formulargestellter Miniaturbilder hinzugefügt**
Aspose.Slides.ShapeThumbnailBounds

Neue Mitglieder in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)