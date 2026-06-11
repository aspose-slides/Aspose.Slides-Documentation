---
title: Förenkla teckensnittsbyte i presentationer med С++
linktitle: Teckensnittsbyte
type: docs
weight: 60
url: /sv/cpp/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- ändra teckensnitt
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Ersätt teckensnitt sömlöst i Aspose.Slides för С++ för att säkerställa konsekvent typografi i PowerPoint- och OpenDocument-presentationer."
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

Denna C++‑kod demonstrerar teckensnittsersättning:

``` cpp
// Laddar en presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Laddar källteckensnittet som ska ersättas
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Laddar det nya teckensnittet
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Ersätter teckensnitten
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Sparar presentationen
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
För att ange regler som bestämmer vad som händer under vissa förhållanden (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/cpp/font-substitution/). 
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/cpp/font-substitution/) är en regel som "om teckensnittet är otillgängligt, använd X." [Fallback](/slides/sv/cpp/fallback-font/) tillämpas kirurgiskt för enskilda saknade tecken när basteckensnittet är installerat men saknar de nödvändiga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och tas hänsyn till av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE‑innehåll](/slides/sv/cpp/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (efter bilder eller regioner)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå av de specifika objekten/intervallen istället för att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsväljning under rendering förblir densamma.

**Hur kan jag i förväg avgöra vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getfonts/) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getsubstitutions/), vilket underlättar planeringen av ersättningen.

**Fungerar teckensnittsersättning vid konvertering till PDF/bilder?**

Ja. Vid export använder Aspose.Slides samma [font selection/substitution sequence](/slides/sv/cpp/font-selection-sequence/), så en ersättning som utförts i förväg kommer att beaktas under konverteringen.

**Behöver jag installera målteckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation är inte nödvändig: biblioteket tillåter [laddning av externa teckensnitt](/slides/sv/cpp/custom-font/) från användarmappar för användning under [rendering och export](/slides/sv/cpp/convert-powerpoint/).

**Kommer ersättning att lösa "tofu" (rutor) i stället för tecken?**

Endast om målteckensnittet faktiskt innehåller de erforderliga glyferna. Om inte, [configure fallback](/slides/sv/cpp/fallback-font/) för att täcka de saknade tecknen.