---
title: OLE-objecten automatisch bijwerken met een PowerPoint-add-in
type: docs
weight: 10
url: /nl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-object
- OLE bijwerken
- automatisch
- add-in
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u OLE-diagrammen en -objecten automatisch kunt bijwerken in PowerPoint met een add-in en Aspose.Slides for Java, met praktische code en optimalisatietips."
---
## **Inleiding**

Een van de meest voorkomende vragen die klanten van Aspose.Slides for Java stellen, is hoe ze bewerkbare diagrammen (of andere OLE‑objecten) kunnen maken of aanpassen zodat ze automatisch bijgewerkt worden wanneer de presentatie wordt geopend. Helaas ondersteunt PowerPoint automatische macro's niet op dezelfde manier als Excel en Word. De enige beschikbare macro's zijn `Auto_Open` en `Auto_Close`, en deze worden alleen automatisch uitgevoerd vanuit een add‑in. Deze korte technische tip laat zien hoe u dat kunt realiseren.

## **OLE‑objecten automatisch bijwerken**

Ten eerste zijn er verschillende gratis add‑ins beschikbaar die de Auto_Open‑macrofunctie aan PowerPoint toevoegen, bijvoorbeeld [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) en [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Na het installeren van een van deze add‑ins voegt u eenvoudig de macro `Auto_Open()` toe (of `OnPresentationOpen()` als u Event Generator gebruikt) aan uw sjabloonpresentatie zoals hieronder weergegeven:

```java
// Doorloop elke dia in de presentatie.
for (var oSlide : ActivePresentation.Slides) {
    // Doorloop alle vormen op de huidige dia.
    for (var oShape : oSlide.Shapes) {
        // Controleer of de vorm een OLE object is.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // OLE object gevonden. Haal de objectreferentie op en werk het vervolgens bij.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Sluit nu het OLE serverprogramma.
            // Dit maakt geheugen vrij en voorkomt problemen.
            // Stel oObject ook in op Nothing om het object vrij te geven.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Alle wijzigingen die aan OLE‑objecten worden aangebracht met Aspose.Slides for Java, worden automatisch bijgewerkt wanneer PowerPoint de presentatie opent. Als u veel OLE‑objecten hebt en ze niet allemaal wilt bijwerken, kunt u eenvoudig een aangepast label aan de vormen die u moet verwerken toevoegen en in de macro op dat label controleren.