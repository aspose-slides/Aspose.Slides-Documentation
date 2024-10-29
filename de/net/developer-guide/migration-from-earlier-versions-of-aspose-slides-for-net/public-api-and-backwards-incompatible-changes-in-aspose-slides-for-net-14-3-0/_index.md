---
title: Public API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 14.3.0
type: docs
weight: 50
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **Öffentliche API und nicht rückwärtskompatible Änderungen**
### **Enumeration Aspose.Slides.ShapeThumbnailBounds und Methoden Aspose.Slides.IShape.GetThumbnail() hinzugefügt**
Die Methoden GetThumbnail() und GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) werden verwendet, um ein separates Form-Thumbnail zu erstellen. Die Enumeration ShapeThumbnailBounds definiert die möglichen Typen von Form-Thumbnail-Grenzen.
### **Eigenschaft UniqueId wurde zu Aspose.Slides.IShape hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.UniqueId erhält eine eindeutige Identifikationsnummer für Formen im Präsentationskontext. Diese eindeutigen Identifikatoren werden in benutzerdefinierten Tags der Form gespeichert.
### **Signatur der Methode SetGroupingItem in IChartCategoryLevelsManager geändert**
Die Signatur der Methode IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

ist jetzt veraltet und wurde durch die Signatur

``` csharp

 void SetGroupingItem(int level, object value);

``` 

ersetzt. Aufrufe wie

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Gruppe 1"));

``` 

müssen in Aufrufe wie

``` csharp

 .SetGroupingItem(1, "Gruppe 1");

``` 

geändert werden. Übergeben Sie einen Wert wie "Gruppe 1" an SetGroupingItem, aber nicht einen Wert vom Typ IChartDataCell. Die Konstruktion von IChartDataCell mit einem definierten Arbeitsblatt, Zeile und Spalte für Kategorien muss bestimmten Anforderungen genügen und wurde in die Methode SetGroupingItem(int, object) gekapselt.
### **Eigenschaft SlideId wurde zur Aspose.Slides.IBaseSlide-Schnittstelle hinzugefügt**
Die Eigenschaft SlideId erhält eine eindeutige Identifikationsnummer für Folien.
### **Eigenschaft SoundName wurde zu ISlideShowTransition hinzugefügt**
Schreib- und lesbares Zeichenfolgenfeld. Gibt einen für den Menschen lesbaren Namen für den Ton der Übergangs animation an. Die Eigenschaft Sound muss zugewiesen werden, um den oder die Soundnamen zu erhalten oder zu setzen. Dieser Name erscheint in der PowerPoint-Benutzeroberfläche, wenn der Übergangston manuell konfiguriert wird. Kann eine PptxException auslösen, wenn die Eigenschaft Sound nicht zugewiesen ist.
### **Typ der Eigenschaft ChartSeriesGroup.Type geändert**
Die Eigenschaft ChartSeriesGroup.Type wurde von der Enumeration ChartType auf die neue Enumeration CombinableSeriesTypesGroup geändert. Die Enumeration CombinableSeriesTypesGroup repräsentiert die Gruppen von kombinierbaren Serienarten.
### **Unterstützung zur Generierung individueller Form-Thumbnails hinzugefügt**
Aspose.Slides.ShapeThumbnailBounds

Neue Mitglieder in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)