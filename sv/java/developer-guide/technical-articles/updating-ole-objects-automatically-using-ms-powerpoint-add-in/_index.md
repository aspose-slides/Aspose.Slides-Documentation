---
title: Uppdatera OLE-objekt automatiskt med ett PowerPoint-tillägg
type: docs
weight: 10
url: /sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-objekt
- uppdatera OLE
- automatiskt
- tillägg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du automatiskt uppdaterar OLE-diagram och -objekt i PowerPoint med ett tillägg och Aspose.Slides för Java, med praktisk kod och optimeringstips."
---
## **Introduktion**

En av de vanligaste frågorna som Aspose.Slides for Java‑kunder ställer är hur man skapar eller ändrar redigerbara diagram (eller andra OLE‑objekt) så att de uppdateras automatiskt när presentationen öppnas. Tyvärr stöder PowerPoint inte automatiska makron på samma sätt som Excel och Word gör. De enda makron som finns tillgängliga är `Auto_Open` och `Auto_Close`, och dessa körs bara automatiskt från ett tillägg. Detta korta tekniska tips visar hur du kan uppnå detta.

## **Uppdatera OLE‑objekt automatiskt**

Först finns flera gratis‑tillägg som lägger till funktionen Auto_Open‑makro i PowerPoint, till exempel [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) och [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Efter att du har installerat ett av dessa tillägg, lägg helt enkelt till `Auto_Open()`‑makrot (eller `OnPresentationOpen()` om du använder Event Generator) i din mallpresentation som visas nedan:

```java
// Loopa igenom varje bild i presentationen.
for (var oSlide : ActivePresentation.Slides) {
    // Loopa igenom alla former på den aktuella bilden.
    for (var oShape : oSlide.Shapes) {
        // Kontrollera om formen är ett OLE-objekt.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Hittade ett OLE-objekt. Hämta dess objektreferens och uppdatera den.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Avsluta nu OLE-serverprogrammet.
            // Detta frigör minne och förhindrar eventuella problem.
            // Sätt också oObject till Nothing för att frigöra objektet.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Alla ändringar som görs i OLE‑objekt med Aspose.Slides for Java kommer automatiskt att uppdateras när PowerPoint öppnar presentationen. Om du har många OLE‑objekt och inte vill uppdatera dem alla, lägg helt enkelt till en anpassad tagg på de former du behöver bearbeta och kontrollera den i makrot.