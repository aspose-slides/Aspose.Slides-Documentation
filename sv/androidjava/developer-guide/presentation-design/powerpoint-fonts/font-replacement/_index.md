---
title: Optimera teckensnittsbyte i presentationer på Android
linktitle: Teckensnittsbyte
type: docs
weight: 60
url: /sv/androidjava/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittbyte
- byt teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Byt enkelt teckensnitt i Aspose.Slides för Android via Java för att säkerställa enhetlig typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides gör det möjligt att ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsbyte, läs in presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa metoden för teckensnittsbyte och spara den modifierade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Läs in den relevanta presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod demonstrerar teckensnittsbyte:

```java
// Laddar en presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laddar källteckensnittet som ska ersättas
    IFontData sourceFont = new FontData("Arial");
    
    // Laddar det nya teckensnittet
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
För att ställa in regler som bestämmer vad som händer i vissa situationer (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/androidjava/font-substitution/).
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/androidjava/font-substitution/) är en regel som "om teckensnittet inte är tillgängligt, använd X." [Fallback](/slides/sv/androidjava/fallback-font/) tillämpas selektivt för enskilda saknade glyfer när grundteckensnittet är installerat men inte innehåller de nödvändiga tecknen.

**Gäller ersättningen för master‑bilder, layouter, anteckningar och kommentarer?**

Ja. Ersättningen påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive master‑bilder och anteckningar; kommentarer är också en del av dokumentet och tas med av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/androidjava/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller region)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå med de specifika objekten/områdena istället för att tillämpa ett globalt byte i hela dokumentet. Den övergripande logiken för teckensnittsval under rendering förblir oförändrad.

**Hur kan jag i förväg ta reda på vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getFonts--) och information om [substitutioner/"unknown" fonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), vilket underlättar planeringen av ersättningen.

**Fungerar teckensnittsbyte vid konvertering till PDF/bilder?**

Ja. Vid export använder Aspose.Slides samma [font selection/substitution sequence](/slides/sv/androidjava/font-selection-sequence/), så ett tidigare utfört byte respekteras under konverteringen.

**Behöver jag installera mål‑teckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation är inte nödvändig: biblioteket tillåter [loading external fonts](/slides/sv/androidjava/custom-font/) från användarmappar för användning vid [rendering and export](/slides/sv/androidjava/convert-powerpoint/).

**Kommer ersättningen att fixa "tofu" (fyrkanter) istället för tecken?**

Endast om mål‑teckensnittet faktiskt innehåller de nödvändiga glyferna. Om inte, [configure fallback](/slides/sv/androidjava/fallback-font/) för att täcka de saknade tecknen.