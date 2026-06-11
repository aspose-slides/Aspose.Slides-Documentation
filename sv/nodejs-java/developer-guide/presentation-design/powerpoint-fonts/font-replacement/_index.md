---
title: Effektivisera teckensnittsersättning i presentationer med JavaScript
linktitle: Teckensnittsersättning
type: docs
weight: 60
url: /sv/nodejs-java/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsersättning
- byt teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Byt enkelt teckensnitt i JavaScript med Aspose.Slides för Node.js via Java för att säkerställa enhetlig typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsersättning, ladda presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa metoden för teckensnittsersättning och spara den ändrade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya teckensnittet.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Ladda den relevanta presentationen. 
2. Ladda teckensnittet som ska ersättas. 
3. Ladda det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den ändrade presentationen som en PPTX‑fil.

Denna JavaScript‑kod demonstrerar teckensnittsersättning:

```javascript
// Laddar en presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Laddar källteckensnittet som ska ersättas
    var sourceFont = new aspose.slides.FontData("Arial");
    // Laddar det nya teckensnittet
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Ersätter teckensnitten
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Sparar presentationen
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

För att ange regler som bestämmer vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/nodejs-java/font-substitution/).

{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/nodejs-java/font-substitution/) är en regel som "om teckensnittet inte är tillgängligt, använd X." [Fallback](/slides/sv/nodejs-java/fallback-font/) appliceras exakt för enskilda saknade glyfer när basteckensnittet är installerat men inte innehåller de erforderliga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och beaktas av teckensnittsmotorn.

**Kommer teckensnittet att förändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/nodejs-java/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå med de nödvändiga objekten/områdena snarare än att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsval vid rendering förblir densamma.

**Hur kan jag i förväg avgöra vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getfonts/) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), vilket underlättar planeringen av ersättningen.

**Fungerar teckensnittsersättning vid konvertering till PDF/bilder?**

Ja. Vid export använder Aspose.Slides samma [font selection/substitution sequence](/slides/sv/nodejs-java/font-selection-sequence/), så en förhandsutförd ersättning respekteras under konverteringen.

**Behöver jag installera målteckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket möjliggör [laddning av externa teckensnitt](/slides/sv/nodejs-java/custom-font/) från användarmappar för användning under [rendering och export](/slides/sv/nodejs-java/convert-powerpoint/).

**Kommer ersättning att fixa "tofu" (rutor) istället för tecken?**

Endast om målteckensnittet faktiskt innehåller de erforderliga glyferna. Om inte, [configure fallback](/slides/sv/nodejs-java/fallback-font/) för att täcka de saknade tecknen.