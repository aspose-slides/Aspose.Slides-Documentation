---
title: Strömlinjeforma teckensnittsersättning i presentationer med Python via Java
linktitle: Teckensnittsersättning
type: docs
weight: 60
url: /sv/python-java/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsersättning
- byt teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Ersätt teckensnitt sömlöst i Aspose.Slides för Python via Java för att säkerställa konsekvent typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsersättning, läs in presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa ersättningsmetoden och spara den ändrade presentationen som en PPTX‑fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det med ett annat teckensnitt. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya.

Aspose.Slides låter dig ersätta ett teckensnitt på detta sätt:

1. Läs in den relevanta presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Skriv den ändrade presentationen som en PPTX‑fil.

Den här Python‑koden demonstrerar teckensnittsersättning:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Läs in en presentation.
presentation = Presentation("Fonts.pptx")
try:
    # Läs in källteckensnittet som ska ersättas.
    source_font = FontData("Arial")

    # Läs in det nya teckensnittet.
    destination_font = FontData("Times New Roman")

    # Ersätt teckensnittet.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Spara presentationen.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Obs" color="info" %}} 

För att ange regler som bestämmer vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [Teckensnittsersättning](/slides/sv/python-java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/python-java/font-substitution/) är en regel som "om teckensnittet är otillgängligt, använd X." [Fallback](/slides/sv/python-java/fallback-font/) tillämpas på enskilda saknade tecken när basteckensnittet är installerat men inte innehåller de erforderliga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och beaktas av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/python-java/manage-ole/) styrs av sitt eget program. Ersättning i presentationen omformaterar inte den interna OLE‑data; den kan visas som en bild eller som redigerbart innehåll externt.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivån för de specifika objekten/områdena istället för att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsurval under rendering kvarstår.

**Hur kan jag i förväg avgöra vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFonts) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions), vilket hjälper dig planera ersättningen.

**Fungerar teckensnittsersättning vid konvertering till PDF/bilder?**

Ja. Vid export använder Aspose.Slides samma [font selection/substitution sequence](/slides/sv/python-java/font-selection-sequence/), så en förhandsutförd ersättning kommer att respekteras under konverteringen.

**Behöver jag installera målteckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation är inte nödvändig: biblioteket möjliggör [loading external fonts](/slides/sv/python-java/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/python-java/convert-powerpoint/).

**Kommer ersättning att fixa "tofu" (fyrkanter) i stället för tecken?**

Endast om målteckensnittet faktiskt innehåller de erforderliga glyferna. Om inte, [configure fallback](/slides/sv/python-java/fallback-font/) för att täcka de saknade tecknen.