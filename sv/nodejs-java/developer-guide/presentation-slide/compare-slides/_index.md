---
title: Jämför presentationsbilder i JavaScript
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/nodejs-java/compare-slides/
keywords:
- jämföra bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för Node.js via Java. Identifiera skillnader i bilder i koden snabbt."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av `equals`‑metoden som tillhandahålls av `BaseSlide`‑klassen. Denna metod returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**

Equals‑metoden har lagts till i klassen [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide) och klassen [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide). Den returnerar true för bilder/layout‑ och bilder/master‑bilder som är identiska i sin struktur och statiska innehåll.  

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar osv. är lika. Jämförelsen tar inte hänsyn till unika identifieringsvärden, t.ex. SlideId, och dynamiskt innehåll, t.ex. aktuellt datumvärde i datum‑platshållare.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Vanliga frågor**

**Påverkar det att en bild är dold jämförelsen av själva bilderna?**

[Dold status](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/gethidden/) är en egenskap på presentations‑/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; enbart det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar i beaktande?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänkåtgärden skiljer sig, betraktas detta normalt som en skillnad i det statiska innehållet.

**Om ett diagram refererar till en extern Excel‑fil, kommer innehållet i den filen att tas i beaktande?**

Nej. Jämförelsen utförs baserat på bilderna själva. Externa datakällor läses normalt inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.