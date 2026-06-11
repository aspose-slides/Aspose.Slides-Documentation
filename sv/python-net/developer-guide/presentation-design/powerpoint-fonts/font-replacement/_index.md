---
title: Strömlinjeforma teckensnittsersättning i presentationer med Python
linktitle: Teckensnittsersättning
type: docs
weight: 60
url: /sv/python-net/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsersättning
- ändra teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Byt smidigt teckensnitt i Aspose.Slides Python via .NET för att säkerställa enhetlig typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsersättning, läs in presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa metoden för teckensnittsersättning och spara den modifierade presentationen som en PPTX-fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig kring att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya teckensnittet.

Aspose.Slides låter dig ersätta ett teckensnitt på detta sätt:

1. Läs in den relevanta presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den modifierade presentationen som en PPTX-fil.

Den här Python-koden demonstrerar teckensnittsersättning:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Laddar en presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Laddar källteckensnittet som ska ersättas
    sourceFont = slides.FontData("Arial")

    # Laddar det nya teckensnittet
    destFont = slides.FontData("Times New Roman")

    # Ersätter teckensnitten
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Sparar presentationen
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
För att ställa in regler som bestämmer vad som händer under vissa förhållanden (om ett teckensnitt till exempel inte kan nås), se [**Font Substitution**](/slides/sv/python-net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/python-net/font-substitution/) är en regel som "om teckensnittet saknas, använd X." [Fallback](/slides/sv/python-net/fallback-font/) tillämpas selektivt för enskilda saknade tecken när basteckensnittet är installerat men inte innehåller de erforderliga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och tas med i beaktande av teckensnittsmotorn.

**Kommer teckensnittet att förändras i inbäddade OLE‑objekt (till exempel Excel)?**

Nej. [OLE content](/slides/sv/python-net/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (efter bilder eller regioner)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå med de önskade objekten/områdena snarare än att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsväljning under rendering förblir densamma.

**Hur kan jag i förväg ta reda på vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_fonts/) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/), vilket underlättar planeringen av ersättningen.

**Fungerar teckensnittsersättning vid konvertering till PDF/bilder?**

Ja. Vid export tillämpar Aspose.Slides samma [font selection/substitution sequence](/slides/sv/python-net/font-selection-sequence/), så en ersättning som gjorts i förväg respekteras under konverteringen.

**Måste jag installera målteckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket tillåter [loading external fonts](/slides/sv/python-net/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/python-net/convert-powerpoint/).

**Kommer ersättning att lösa "tofu" (rutor) i stället för tecken?**

Endast om målteckensnittet faktiskt innehåller de erforderliga tecknen. Om inte, [configure fallback](/slides/sv/python-net/fallback-font/) för att täcka de saknade tecken.