---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.3.0
linktitle: Aspose.Slides voor .NET 14.3.0
type: docs
weight: 50
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migratie
- legacy‑code
- moderne code
- legacy‑aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en brekende veranderingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX‑ en ODP‑presentatieoplossingen soepel te migreren."
---
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Aspose.Slides.ShapeThumbnailBounds enumeratie en Aspose.Slides.IShape.GetThumbnail() methoden toegevoegd**
De methoden GetThumbnail() en GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) worden gebruikt om een aparte vormminiatuur te genereren. De enumeratie ShapeThumbnailBounds definieert de mogelijke soorten grenzen voor vormminiaturen.
### **Eigenschap UniqueId toegevoegd aan Aspose.Slides.IShape**
De eigenschap Aspose.Slides.IShape.UniqueId levert een unieke vorm‑identificatie binnen de scope van een presentatie. Deze unieke identificatoren worden opgeslagen in aangepaste tags van de vorm.
### **Handtekening van de SetGroupingItem‑methode gewijzigd in IChartCategoryLevelsManager**
Handtekening van de IChartCategoryLevelsManager‑methode

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

is nu verouderd en vervangen door de handtekening

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Aanroepen zoals

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

moeten worden gewijzigd naar aanroepen zoals

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Geef een waarde zoals "Group 1" door aan SetGroupingItem, maar geen waarde van het type IChartDataCell. Het construeren van een IChartDataCell met een gedefinieerd werkblad, rij en kolom voor categorieniveaus moet aan bepaalde eisen voldoen en is geïncapsuleerd in de SetGroupingItem(int, object)‑methode.
### **Eigenschap SlideId toegevoegd aan de Aspose.Slides.IBaseSlide‑interface**
De eigenschap SlideId levert een unieke dia‑identificatie.
### **Eigenschap SoundName toegevoegd aan ISlideShowTransition**
Schrijf‑bare string. Bepaalt een voor mensen leesbare naam voor het geluid van de overgang. De Sound‑eigenschap moet worden toegewezen om de geluidsnaam op te halen of in te stellen. Deze naam wordt weergegeven in de PowerPoint‑gebruikersinterface bij het handmatig configureren van het overgangsgeluid. Kan een PptxException veroorzaken wanneer de Sound‑eigenschap niet is toegewezen.
### **Type van de ChartSeriesGroup.Type‑eigenschap gewijzigd**
De eigenschap ChartSeriesGroup.Type is gewijzigd van de enumeratie ChartType naar de nieuwe enumeratie CombinableSeriesTypesGroup. De enum CombinableSeriesTypesGroup vertegenwoordigt de groepen van combineerbare serietypen.
### **Ondersteuning voor het genereren van individuele vormminiaturen toegevoegd**
Aspose.Slides.ShapeThumbnailBounds

Nieuwe leden in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)