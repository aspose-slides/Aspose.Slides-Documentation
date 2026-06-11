---
title: Förenkla teckensnittsbyte i presentationer i .NET
linktitle: Teckensnittsbyte
type: docs
weight: 60
url: /sv/net/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- ändra teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ersätt teckensnitt smidigt i Aspose.Slides för .NET för att säkerställa enhetlig typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsbyte laddar du presentationen, definierar källteckensnittet och ersättningsteckensnittet, anropar metoden för teckensnittsbyte och sparar den modifierade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Ladda den relevanta presentationen.  
2. Ladda teckensnittet som ska ersättas.  
3. Ladda det nya teckensnittet.  
4. Ersätt teckensnittet.  
5. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod demonstrerar teckensnittsbyte:

```c#
 // Laddar en presentation
 Presentation presentation = new Presentation("Fonts.pptx");

 // Laddar källteckensnittet som ska ersättas
 IFontData sourceFont = new FontData("Arial");

 // Laddar det nya teckensnittet
 IFontData destFont = new FontData("Times New Roman");

 // Ersätter teckensnitten
 presentation.FontsManager.ReplaceFont(sourceFont, destFont);

 // Sparar presentationen
 presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 
För att ange regler som bestämmer vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/net/font-substitution/) är en regel som "om teckensnittet är otillgängligt, använd X". [Fallback](/slides/sv/net/fallback-font/) tillämpas selektivt för enskilda saknade glyfer när basteckensnittet är installerat men inte innehåller de erforderliga tecknen.

**Gäller ersättning för master‑bilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive master‑bilder och anteckningar; kommentarer är också en del av dokumentet och tas med i beräkning av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/net/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑data; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå med de specifika objekten/områdena istället för att tillämpa ett globalt byte på hela dokumentet. Den övergripande logiken för teckensnittsväljning under rendering förblir densamma.

**Hur kan jag i förväg ta reda på vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/): den ger en lista över de [familierna i bruk](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getfonts/) och information om [substitutioner/"unknown" fonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getsubstitutions/), vilket hjälper dig planera ersättningen.

**Fungerar teckensnittsbyte vid konvertering till PDF/bilder?**

Ja. Vid export tillämpar Aspose.Slides samma [font selection/substitution sequence](/slides/sv/net/font-selection-sequence/), så ett förhandsutfört byte respekteras vid konverteringen.

**Behöver jag installera mål‑teckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket tillåter [loading external fonts](/slides/sv/net/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/net/convert-powerpoint/).

**Kommer ersättning att åtgärda "tofu" (rutor) istället för tecken?**

Endast om mål‑teckensnittet faktiskt innehåller de nödvändiga glyferna. Om inte, [configure fallback](/slides/sv/net/fallback-font/) för att täcka de saknade tecknen.