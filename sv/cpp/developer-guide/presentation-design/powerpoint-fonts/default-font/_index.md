---
title: Ange standardtypsnitt för presentation i C++
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/cpp/default-font/
keywords:
- standardtypsnitt
- vanligt typsnitt
- normalt typsnitt
- asiatiskt typsnitt
- PDF-export
- XPS-export
- bildexport
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Ställ in standardtypsnitt i Aspose.Slides för C++ för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du skapar miniatyrbilder av bilder eller exporterar en presentation till format såsom PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

`set_DefaultRegularFont`-metoden definierar standardtypsnittet för vanlig text, medan `set_DefaultAsianFont` definierar standardtypsnittet för asiatisk text. När dessa alternativ har ställts in kan presentationen laddas och renderas med de specificerade typsnitten.

## **Använd standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnitt för att rendera presentationen till PDF, XPS eller miniatyrbilder. Den här artikeln visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för C++ API:

1. Skapa en instans av LoadOptions.  
2. Ställ in DefaultRegularFont till det önskade typsnittet. I följande exempel har jag använt Wingdings.  
3. Ställ in DefaultAsianFont till det önskade typsnittet. Jag har använt Wingdings i följande exempel.  
4. Ladda presentationen med Presentation och ange laddningsalternativen.  
5. Generera nu bildminiatyrer, PDF och XPS för att verifiera resultaten.

Implementeringen av ovanstående ges nedan.

```cpp
// Använd laddningsalternativen för att ange standardvanligt och asiatiskt typsnitt
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **Vanliga frågor**

**Vad exakt påverkar DefaultRegularFont och DefaultAsianFont—endast export, eller även miniatyrbilder, PDF, XPS, HTML och SVG?**  
De deltar i renderingspipeline för alla stödda utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/sv/cpp/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/cpp/convert-powerpoint-to-png/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), och [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout- och glyfupplösningslogik för dessa mål.

**Tillämpas standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**  
Nej. Standardtypsnitt spelar roll när text måste mätas och ritas. En enkel öppna‑och‑spara av en presentation ändrar inte de lagrade typsnittsraderna eller filens struktur. Standardtypsnitt används vid operationer som renderar eller omflödar text.

**Om jag lägger till egna typsnittsmappor eller tillhandahåller typsnitt från minnet, kommer de att beaktas när standardtypsnitt väljs?**  
Ja. [Custom font sources](/slides/sv/cpp/custom-font/) utökar katalogen med tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback rules](/slides/sv/cpp/fallback-font/) kommer att sökas i dessa källor först, vilket ger en mer pålitlig täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmetrik (kerning, avstånd) och därmed radbrytningar och radomslag?**  
Ja. Att byta typsnitt förändrar glyfmetrik och kan ändra radbrytningar, radomslag och paginering under rendering. För layoutstabilitet, [embed the original fonts](/slides/sv/cpp/embedded-font/) eller välj metrisk kompatibla standard- och fallback-familjer.

**Finns det någon nytta med att ange standardtypsnitt om alla typsnitt som används i presentationen är inbäddade?**  
Ofta är det inte nödvändigt, eftersom [embedded fonts](/slides/sv/cpp/embedded-font/) redan säkerställer ett konsekvent utseende. Standardtypsnitt hjälper ändå som en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.