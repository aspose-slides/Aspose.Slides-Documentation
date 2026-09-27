---
title: Utvärdera Aspose.Slides
type: docs
weight: 120
url: /sv/nodejs-net/evaluate-aspose-slides/
keywords:
- utvärdera Aspose.Slides
- utvärderingsversion
- utvärderingsvattenmärke
- testbegränsningar
- tillfällig licens
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Vad utvärderingsversionen av Aspose.Slides för Node.js via .NET begränsar, med ett skript som visar båda begränsningarna och hur man tar bort dem med en licens."
---
## **Översikt**

Utvärderingsversionen av Aspose.Slides för Node.js via .NET är samma npm‑paket som den licensierade versionen. Utan licens körs den i utvärderingsläge: alla funktioner fungerar, men sparade presentationer och de flesta exportformat får ett vattenmärke, och text som din kod läser tillbaka kapas. Den här artikeln beskriver båda begränsningarna och visar hur du tar bort dem.

## **Begränsningar i utvärderingsversionen**

**Ett utvärderingsvattenmärke på varje bild.** När du sparar en presentation utan licens lägger Aspose.Slides till en textruta i mitten av varje bild i den sparade filen. Textrutan är låst och visar texten “Evaluation only.” följt av en produktlinje och en upphovsrättslinje. Vattenmärket skrivs in i den sparade filen, inte i presentationen i minnet, och att öppna en presentation lägger inte till ett vattenmärke. En fil som sparats i utvärderingsläge innehåller redan textrutan, så att öppna och spara den igen lägger till ett andra vattenmärke på varje bild.

Samma vattenmärke ritas in i utdata när du exporterar till PDF, XPS eller HTML, eller renderar bilder. Om du renderar en presentation som redan sparats i utvärderingsläge visar bilden både det sparade vattenmärket och det renderade.

**Avkortad text när din kod läser den.** Text som din kod läser via egenskapen `text` i en textram, ett stycke eller en delkapitel kapas till dess första fem tecken, följt av meddelandet “… text has been truncated due to evaluation version limitation.” Text med fem tecken eller färre returneras i sin helhet. Detta gäller på varje bild och även på text som din kod precis har tilldelat. Markdown‑ och HTML5‑exporter kapas på samma sätt.

Texten som din kod skriver sparas i sin helhet: PPTX‑filer, PDF‑sidor och bild­bilder innehåller den kompletta texten.

## **Se begränsningarna i ett skript**

Följande skript visar båda begränsningarna. Det förutsätter att du har installerat paketet enligt [Installation](/slides/sv/nodejs-net/installation/) och att du kör det från projektmappen. Det lägger till en rektangel med en mening på den första bilden, läser tillbaka meningen, sparar presentationen som `evaluation.pptx` och öppnar sedan filen igen för att räkna formerna på bilden.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Utan licens returneras endast de första fem tecknen.
    console.log("Text read back:", rectangle.textFrame.text);

    // Sparande lägger till utvärderingsvattenmärket på varje bild i filen.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Bilden innehåller nu rektangeln och vattenmärkes-textrutan.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Utan licens skriver skriptet ut:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Den andra formen är vattenmärkes‑textrutan. Öppna `evaluation.pptx` för att se den fullständiga meningen i rektangeln och vattenmärket i mitten av bilden.

## **Ta bort begränsningarna**

För att ta bort båda begränsningarna, applicera en licens innan du skapar något `Presentation`‑objekt. [Licensing](/slides/sv/nodejs-net/licensing/) visar hur du använder en licensfil.

{{% alert color="success" title="Tip" %}}
För att testa Aspose.Slides utan utvärderingsbegränsningarna innan du köper, begär en gratis **30‑day temporary license**. Se [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) för detaljer.
{{% /alert %}}

## **Vanliga frågor**

**Begränsar utvärderingsläget antalet bilder?**

Nej. Presentationer skapas, öppnas och sparas med alla sina bilder. Vattenmärket och avkortningen av texten gäller för varje bild lika.

**Varför visas vattenmärket två gånger på mina exporterade bildbilder?**

Presentationen sparades i utvärderingsläge innan du renderade den, så den innehåller redan en vattenmärkes‑textruta, och renderingen utan licens ritar ytterligare ett vattenmärke ovanpå den.

**Kan jag kontrollera att min kod producerar rätt text i utvärderingsläget?**

Ja. Öppna den sparade filen eller den exporterade PDF‑filen: de innehåller den kompletta texten. Endast den text som din kod läser tillbaka, samt Markdown‑ eller HTML5‑utdata, kapas.