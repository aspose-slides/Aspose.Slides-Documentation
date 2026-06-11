---
title: Strömlinjeforma teckensnittsersättning i presentationer med PHP
linktitle: Teckensnittsersättning
type: docs
weight: 60
url: /sv/php-java/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsersättning
- ändra teckensnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Ersätt teckensnitt i Aspose.Slides för PHP via Java på ett sömlöst sätt för att säkerställa konsekvent typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela presentationen. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsersättning, läs in presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa metoden för teckensnittsersättning och spara den modifierade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya teckensnittet.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Läs in den aktuella presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den modifierade presentationen som en PPTX‑fil.

Denna PHP‑kod demonstrerar teckensnittsersättning:

```php
  # Laddar en presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Laddar källteckensnittet som ska ersättas
    $sourceFont = new FontData("Arial");
    # Laddar det nya teckensnittet
    $destFont = new FontData("Times New Roman");
    # Ersätter teckensnitten
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Sparar presentationen
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

För att ställa in regler som bestämmer vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/php-java/font-substitution/).

{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/php-java/font-substitution/) är en regel som "om teckensnittet är otillgängligt, använd X." [Fallback](/slides/sv/php-java/fallback-font/) tillämpas selektivt för enskilda saknade tecken när grundteckensnittet är installerat men saknar de nödvändiga tecknen.

**Gäller ersättning för master‑bilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationselement som använder det ursprungliga teckensnittet, inklusive master‑bilder och anteckningar; kommentarer är också en del av dokumentet och tas med i beaktande av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/php-java/manage-ole/) styrs av sitt eget program. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt bara i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå av de specifika objekten/intervallen istället för att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsväljning under rendering förblir densamma.

**Hur kan jag i förväg avgöra vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getfonts/) och information om [substitutions/"unknown" fonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getsubstitutions/), vilket hjälper till att planera ersättningen.

**Fungerar teckensnittsersättning vid konvertering till PDF/bilder?**

Ja. Vid export tillämpar Aspose.Slides samma [font selection/substitution sequence](/slides/sv/php-java/font-selection-sequence/), så en tidigare utförd ersättning beaktas under konverteringen.

**Behöver jag installera mål‑teckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket tillåter [loading external fonts](/slides/sv/php-java/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/php-java/convert-powerpoint/).

**Kommer ersättning att lösa "tofu" (fyrkanter) istället för tecken?**

Endast om mål‑teckensnittet faktiskt innehåller de erforderliga glyferna. Om inte, [configure fallback](/slides/sv/php-java/fallback-font/) för att täcka de saknade tecknen.