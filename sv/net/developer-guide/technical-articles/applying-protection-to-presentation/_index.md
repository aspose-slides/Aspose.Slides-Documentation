---
title: Förhindra presentationredigering med formlås i .NET
linktitle: Förhindra presentationredigering
type: docs
weight: 70
url: /sv/net/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- lås form
- lås position
- lås markering
- lås storlek
- lås gruppering
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för .NET låser eller låser upp former i PPT-, PPTX- och ODP-filer, och säkrar presentationer samtidigt som kontrollerade redigeringar tillåts."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides är att skapa, uppdatera och spara Microsoft PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationer som använder Aspose.Slides på detta sätt har åtkomst till de genererade presentationerna, så att skydda dem från redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och sitt innehåll.

Den här artikeln förklarar hur presentationer och bilder är strukturerade och hur Aspose.Slides för .NET kan tillämpa skydd på en presentation och senare ta bort det. Den ger utvecklare ett sätt att kontrollera hur de presentationer som deras applikationer genererar används.

## **Komposition av en bild**

En presentationsbild består av komponenter som autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för .NET representeras varje element på en bild av ett objekt som implementerar [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)-gränssnittet eller ärver från en klass som gör det.

Strukturen för PPTX är komplex, så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, kräver olika formtyper olika lås. [IBaseShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseshapelock/)-gränssnittet är den generiska låsklassen för PPTX. Följande typer av lås stöds i Aspose.Slides för .NET för PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/sv/net/aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/sv/net/aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/igroupshapelock/) låser grupperade former.  
- [IPictureFrameLock](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframelock/) låser bildramar.  

Alla åtgärder som utförs på alla formobjekt i ett [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-objekt tillämpas på hela presentationen.

## **Tillämpa och ta bort skydd**

Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda presentationens innehåll.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides för .NET tillhandahåller [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)-gränssnittet för att arbeta med former på en bild.

Som nämnts tidigare har varje formklass en associerad låsklass för skydd. Den här artikeln fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom musklick eller andra urvalsmetoder) och att de inte kan flyttas eller ändra storlek.

Kodexemplet som följer tillämpar skydd på alla formtyper i en presentation.

```cs
// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("Sample.pptx");

// Gå igenom alla bilder i presentationen.
foreach (ISlide slide in presentation.Slides)
{
    // Gå igenom alla former i bilden.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Spara presentationsfilen.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Ta bort skydd**

För att låsa upp en form, sätt det tillämpade låsets värde till `false`. Följande kodexempel visar hur man låser upp former i en låst presentation.

```cs
// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Traversera alla bilder i presentationen.
foreach (ISlide slide in presentation.Slides)
{
    // Traversera alla former i bilden.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Sparar presentationsfilen.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Slutsats**

Aspose.Slides erbjuder flera alternativ för att skydda former i en presentation. Du kan låsa en enskild form eller iterera genom alla former i en presentation och låsa varje en för att effektivt säkra hela filen. Du kan ta bort skyddet genom att sätta låsvärdet till `false`.

## **FAQ**

**Kan jag kombinera formulås och lösenordsskydd i samma presentation?**

Ja. Lås begränsar redigering av objekt i filen, medan [lösenordsskydd](/slides/sv/net/password-protected-presentation/) styr åtkomst till att öppna och/eller spara ändringar. Dessa mekanismer kompletterar varandra och fungerar tillsammans.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås på formerna på de valda bilderna; de återstående bilderna förblir redigerbara.

**Gäller formulås för grupperade objekt och anslutningar?**

Ja. Dedikerade låstyper stöds för grupper, anslutningar, grafiska objekt och andra formtyper.