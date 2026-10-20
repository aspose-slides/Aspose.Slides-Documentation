---
title: Begränsa redigering av presentationer med formlås i .NET
linktitle: Begränsa redigering av presentation
type: docs
weight: 70
url: /sv/net/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för .NET för att begränsa urval, rörelse, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning för Aspose.Slides for .NET är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar i former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort formlås i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsoperationer på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for .NET representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) eller ärver från en klass som gör det.

Olika formtyper har olika låsalternativ. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) är basgränssnittet för formlås. Aspose.Slides for .NET tillhandahåller följande låsgränssnitt:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) låser gruppformer.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) låser bildramar.  

För att tillämpa lås på en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterera genom dess bilder och ange rätt lås på varje stödd form.

## **Tillämpa och ta bort skydd**

Formlås begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oredigerbar.

### **Tillämna skydd på PPTX-former**

Aspose.Slides for .NET tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) för att arbeta med former på en bild.

Exemplet anger [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), och [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) till `true` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) för rörelse; grupper använder även [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra behandlade typerna lämnas oförändrade. Loopen traverserar inte de underordnade formerna i en grupp.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Ta bort skydd**

För att ta bort ett formlås, sätt dess värde till `false`. Följande exempel laddar en presentation med formlås och rensar urval, rörelse och storleksändringsrestriktioner via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), och [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Det rensar också [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Slutsats**

Aspose.Slides for .NET låter dig begränsa specifika redigeringsoperationer på enskilda former eller tillämpa samma begränsningar på alla bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **Vanliga frågor**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Formlås begränsar specifika redigeringsoperationer, medan [lösenordsskydd](/slides/sv/net/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tilldela lås endast till former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom gruppens [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)-samling och tillämpa lämpliga lås på varje underliggande form. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.