---
title: Effektivisera teckensnittsbyte i presentationer med C++
linktitle: Teckensnittsbyte
type: docs
weight: 60
url: /sv/cpp/font-replacement/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- byta teckensnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Byt teckensnitt smidigt i Aspose.Slides för C++ för att säkerställa enhetlig typografi i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig ersätta ett teckensnitt med ett annat i hela en presentation. När ett teckensnitt ersätts ändras alla förekomster av det ursprungliga teckensnittet till det nya teckensnittet.

För att utföra teckensnittsbyte, läs in presentationen, definiera källteckensnittet och ersättningsteckensnittet, anropa metod för teckensnittsbyte och spara den ändrade presentationen som en PPTX-fil. Detta tillvägagångssätt är användbart när du avsiktligt vill byta från en teckensnittsfamilj till en annan i hela presentationen.

## **Ersätt teckensnitt**

Om du ändrar dig om att använda ett teckensnitt kan du ersätta det teckensnittet med ett annat. Alla förekomster av det gamla teckensnittet kommer att ersättas av det nya.

Aspose.Slides låter dig ersätta ett teckensnitt på följande sätt:

1. Läs in den relevanta presentationen. 
2. Läs in teckensnittet som ska ersättas. 
3. Läs in det nya teckensnittet. 
4. Ersätt teckensnittet. 
5. Spara den ändrade presentationen som en PPTX-fil.

``` cpp
// Laddar in en presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Laddar in källteckensnittet som kommer att ersättas
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Laddar in det nya teckensnittet
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Ersätter teckensnitten
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Sparar presentationen
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
För att ange regler som bestämmer vad som händer i vissa situationer (t.ex. om ett teckensnitt inte kan nås), se [**Font Substitution**](/slides/sv/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan "font replacement", "font substitution" och "fallback fonts"?**

Ersättning är ett avsiktligt byte från en familj till en annan i hela dokumentet. [Substitution](/slides/sv/cpp/font-substitution/) är en regel som "om teckensnittet är otillgängligt, använd X". [Fallback](/slides/sv/cpp/fallback-font/) tillämpas selektivt för enskilda saknade glyfer när grundteckensnittet är installerat men saknar de nödvändiga tecknen.

**Gäller ersättning för masterbilder, layouter, anteckningar och kommentarer?**

Ja. Ersättning påverkar alla presentationsobjekt som använder det ursprungliga teckensnittet, inklusive masterbilder och anteckningar; kommentarer är också en del av dokumentet och beaktas av teckensnittsmotorn.

**Kommer teckensnittet att ändras i inbäddade OLE‑objekt (t.ex. Excel)?**

Nej. [OLE content](/slides/sv/cpp/manage-ole/) styrs av sin egen applikation. Ersättning i presentationen omformaterar inte den interna OLE‑datan; den kan visas som en bild eller som externt redigerbart innehåll.

**Kan jag ersätta ett teckensnitt endast i en del av presentationen (per bild eller område)?**

Målinriktad ersättning är möjlig om du ändrar teckensnittet på nivå för de specifika objekten/områdena istället för att tillämpa en global ersättning på hela dokumentet. Den övergripande logiken för teckensnittsurval under rendering förblir densamma.

**Hur kan jag i förväg ta reda på vilka teckensnitt presentationen använder?**

Använd presentationens [font manager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/): den ger en lista över de [familjer som används](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getfonts/) och information om [substitutioner/"unknown"-teckensnitt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getsubstitutions/), vilket underlättar planering av ersättningen.

**Fungerar teckensnittsbyte vid konvertering till PDF/bilder?**

Ja. Vid export använder Aspose.Slides samma [font selection/substitution sequence](/slides/sv/cpp/font-selection-sequence/), så en ersättning som utförts i förväg kommer att respekteras under konverteringen.

**Behöver jag installera mål‑teckensnittet i systemet, eller kan jag bifoga en teckensnittsmapp?**

Installation krävs inte: biblioteket tillåter [loading external fonts](/slides/sv/cpp/custom-font/) från användarmappar för användning under [rendering and export](/slides/sv/cpp/convert-powerpoint/).

**Kommer ersättning att åtgärda "tofu" (fyrkanter) i stället för tecken?**

Endast om mål‑teckensnittet faktiskt innehåller de erforderliga glyferna. Om inte, [configure fallback](/slides/sv/cpp/fallback-font/) för att täcka de saknade tecknen.