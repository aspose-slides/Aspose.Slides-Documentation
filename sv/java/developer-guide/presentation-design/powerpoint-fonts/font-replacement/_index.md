---
title: Strömlinjeforma teckensnittsbyte i presentationer med Java
linktitle: Teckensnittsbyte
type: docs
weight: 60
url: /sv/java/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- ändra teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Byt smidigt teckensnitt i Aspose.Slides för Java för att säkerställa konsekvent typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsbyte laddar du presentationen, definierar källteckensnittet och ersättningsteckensnittet, anropar metoden för teckensnittsbyte och sparar den ändrade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Läs in den relevanta presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den ändrade presentationen som en PPTX‑fil.

Den här Java‑koden demonstrerar teckensnittsbyte:

```java
// Läser in en presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Läser in källteckensnittet som ska ersättas
    IFontData sourceFont = new FontData("Arial");
    
    // Läser in det nya teckensnittet
    IFontData destFont = new FontData("Times New Roman");
    
    // Ersätter teckensnitten
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Sparar presentationen
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
För att ställa in regler som avgör vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/java/font-substitution/) är en regel som "om teckensnittet inte är tillgängligt, använd X." [Fallback](/slides/sv/java/fallback-font/) tillämpas selektivt för enskilda saknade glyfer när basteckensnittet är installerat men saknar de nödvändiga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och tas med i beräkningen av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/java/manage-ole/) kontrolleras av sin egna applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå av de specifika objekt/områden som krävs istället för att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsval under rendering förblir densamma.

**Hur kan jag i förväg ta reda på vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#getFonts--) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#getSubstitutions--), vilket underlättar planeringen av ersättningen.

**Fungerar teckensnittsbyte vid konvertering till PDF/bilder?**

Ja. Vid export tillämpar Aspose.Slides samma [font selection/substitution sequence](/slides/sv/java/font-selection-sequence/), så en i förväg utförd ersättning respekteras under konverteringen.

**Behöver jag installera mål‑teckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket tillåter [loading external fonts](/slides/sv/java/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/java/convert-powerpoint/).

**Kommer ersättning att åtgärda "tofu" (fyrkanter) istället för tecken?**

Endast om mål‑teckensnittet faktiskt innehåller de nödvändiga glyferna. Om inte, [configure fallback](/slides/sv/java/fallback-font/) för att täcka de saknade tecknen.