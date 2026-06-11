---
title: Lägg till linjeformer i presentationer i C++
linktitle: Linje
type: docs
weight: 50
url: /sv/cpp/line/
keywords:
- linje
- skapa linje
- lägg till linje
- enkel linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig att manipulera linjeformat i PowerPoint-presentationer med Aspose.Slides för C++. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides gör det möjligt att programatiskt lägga till linjeformer i PowerPoint‑bilder. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska inställningar för linjeformatering såsom stil, bredd, streckmönster, pilspetsalternativ och fyllningsfärg.

## **Skapa en enkel linje**
För att lägga till en enkel linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation-klass](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Line med hjälp av [AddAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addautoshape/)-metoden som exponeras av Shapes‑objektet.
- Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Skapa en pilformad linje**
Aspose.Slides för C++ låter även utvecklare konfigurera vissa egenskaper hos linjen för att göra den mer attraktiv. Låt oss konfigurera några egenskaper så att linjen ser ut som en pil. Följ stegen nedan:

- Skapa en instans av [Presentation-klass](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Line med hjälp av AddAutoShape‑metoden som exponeras av Shapes‑objektet.
- Ställ in Linjestilen till en av de stilar som erbjuds av Aspose.Slides för C++.
- Ställ in bredden på linjen.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linedashstyle/)-egenskapen för linjen till en av de stilar som erbjuds av Aspose.Slides för C++.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/cpp/aspose.slides/lineformat/)- och längd för startpunkten på linjen.
- Ställ in Arrow Head Style och längd för slutpunkten på linjen.
- Skriv den ändrade presentationen som en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Kan jag konvertera en vanlig linje till en anslutning så att den “snäpper” till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/autoshape/) av typ [Line](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapetype/)) blir inte automatiskt en anslutning. Använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/cpp/aspose.slides/connector/)-typen och de [tillhörande API:erna](/slides/sv/cpp/connector/) för anslutningar.

**Vad gör jag om en linjes egenskaper ärvs från temat och det är svårt att avgöra de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/cpp/shape-effective-properties/) via gränssnitten [ILineFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilinefillformateffectivedata/) — dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Shapes‑objekt erbjuder [lock‑objekt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/autoshape/get_autoshapelock/) som låter dig [förbjuda redigeringsåtgärder](/slides/sv/cpp/applying-protection-to-presentation/).