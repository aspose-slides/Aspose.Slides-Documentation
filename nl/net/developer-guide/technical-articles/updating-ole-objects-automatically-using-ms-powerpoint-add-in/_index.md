---
title: OLE-objecten automatisch bijwerken met een PowerPoint‑add‑in
type: docs
weight: 10
url: /nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-object
- OLE bijwerken
- automatisch
- add‑in
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe je OLE‑grafieken en -objecten automatisch kunt bijwerken in PowerPoint met een add‑in en Aspose.Slides for .NET, met praktische code en optimalisatietips."
---
## **Inleiding**

Een van de meest voorkomende vragen die Aspose.Slides for .NET klanten stellen, is hoe ze bewerkbare diagrammen (of andere OLE‑objecten) kunnen maken of wijzigen zodat ze automatisch worden bijgewerkt wanneer de presentatie wordt geopend. Helaas ondersteunt PowerPoint automatische macro's niet op dezelfde manier als Excel en Word. De enige beschikbare macro's zijn `Auto_Open` en `Auto_Close`, en deze worden alleen automatisch uitgevoerd vanuit een add‑in. Deze korte technische tip laat zien hoe je dat kunt realiseren.

## **OLE-objecten automatisch bijwerken**

Eerst zijn er verschillende freeware‑add‑ins beschikbaar die de Auto_Open‑macrofunctie aan PowerPoint toevoegen, bijvoorbeeld [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) en [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Na het installeren van een van deze add‑ins kun je eenvoudig de `Auto_Open()`‑macro (of `OnPresentationOpen()` als je Event Generator gebruikt) aan je sjabloonpresentatie toevoegen zoals hieronder getoond:

```cs
public void Auto_Open()
{
    // Doorloop elke dia in de presentatie.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Doorloop alle vormen op de huidige dia.
        foreach (var oShape in oSlide.Shapes)
        {
            // Controleer of de vorm een OLE object is.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // OLE object gevonden. Haal de objectreferentie op en werk het vervolgens bij.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Sluit nu het OLE serverprogramma.
                // Dit maakt geheugen vrij, en voorkomt eventuele problemen.
                // Zet oObject ook op Nothing om het object vrij te geven.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Alle wijzigingen die je aan OLE‑objecten aanbrengt met Aspose.Slides for .NET worden automatisch bijgewerkt wanneer PowerPoint de presentatie opent. Als je veel OLE‑objecten hebt en niet allemaal wilt bijwerken, kun je eenvoudig een aangepast label toevoegen aan de vormen die je moet verwerken en hier in de macro op controleren.