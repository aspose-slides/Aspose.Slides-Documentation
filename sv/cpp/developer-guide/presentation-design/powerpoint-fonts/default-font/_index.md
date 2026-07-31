---
title: Använd standardtypsnitt för presentation i C++
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
description: "Ange standardtypsnitt i Aspose.Slides för C++ för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du genererar bildminiaturer eller exporterar en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen läses in.

Metoden `set_DefaultRegularFont` definierar standardtypsnittet för vanlig text, medan `set_DefaultAsianFont` definierar standardtypsnittet för asiatisk text. När dessa alternativ har satts kan presentationen laddas och renderas med de angivna typsnitten.

## **Använd standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnitt för att rendera presentationen till PDF, XPS eller miniaturer. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för C++‑API:

1. Skapa en instans av LoadOptions.  
2. Ställ in DefaultRegularFont till önskat typsnitt. I följande exempel har jag använt Wingdings.  
3. Ställ in DefaultAsianFont till önskat typsnitt. Jag har använt Wingdings i följande exempel.  
4. Läs in presentationen med Presentation och ange inläsningsalternativen.  
5. Generera nu bildminiaturen, PDF och XPS för att verifiera resultaten.

Implementeringen av ovanstående ges nedan.

```cpp
// Använd inläsningsalternativen för att ange standardvanligt och asiatiskt typsnitt
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

**Vad påverkar exakt DefaultRegularFont och DefaultAsianFont – bara export, eller också miniaturer, PDF, XPS, HTML och SVG?**

De deltar i renderingspipeline för alla stödjade utdata. Detta inkluderar bildminiaturer, [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/sv/cpp/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/cpp/convert-powerpoint-to-png/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), och [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och teckenupplösningslogik för dessa mål.

**Tillämpas standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardtypsnitt spelar roll när text måste mätas och ritas. En ren öppna‑och‑spara‑operation ändrar varken teckensnittslöp eller filens struktur. Standardtypsnitt aktiveras vid operationer som renderar eller omskapar text.

**Om jag lägger till egna typsnittskataloger eller tillhandahåller typsnitt från minnet, tas de då med i valet av standardtypsnitt?**

Ja. [Anpassade teckensnittskällor](/slides/sv/cpp/custom-font/) utökar katalogen med tillgängliga familjer och tecken som motorn kan använda. Standardtypsnitt och eventuella [regler för reservteckensnitt](/slides/sv/cpp/fallback-font/) söker först i dessa källor, vilket ger bättre täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och omflyttning?**

Ja. Att byta typsnitt ändrar teckenmått och kan förändra radbrytningar, omflyttning och paginering under rendering. För layoutstabilitet, [bädda in de ursprungliga typsnitten](/slides/sv/cpp/embedded-font/) eller välj metrisk kompatibla standard‑ och reservfamiljer.

**Finns det någon nytta med att sätta standardtypsnitt om alla typsnitt i presentationen redan är inbäddade?**

Oftast är det onödigt, eftersom [inbäddade typsnitt](/slides/sv/cpp/embedded-font/) redan säkerställer enhetligt utseende. Standardtypsnitt hjälper ändå som en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.