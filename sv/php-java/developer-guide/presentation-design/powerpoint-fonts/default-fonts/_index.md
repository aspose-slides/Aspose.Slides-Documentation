---
title: Använda standardtypsnitt för presentationer i PHP
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "Ange standardtypsnitt i Aspose.Slides för PHP via Java för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du genererar bildminiatyrer eller exporterar en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

`setDefaultRegularFont`‑metoden definierar standardtypsnittet för vanlig text, medan `setDefaultAsianFont` definierar standardtypsnittet för asiatisk text. När dessa alternativ har angetts kan presentationen laddas och renderas med de angivna typsnitten.

## **Använd standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnitt för att rendera presentationen till PDF, XPS eller miniatyrer. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda dem som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för PHP via Java‑API:

1. Skapa en instans av [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LoadOptions).
1. Använd [DefaultRegularFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) till önskat typsnitt. I följande exempel har jag använt Wingdings.
1. Använd [DefaultAsianFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) till önskat typsnitt. Jag har använt Wingdings i följande exempel.
1. Läs in presentationen med Presentation och ange laddningsalternativen.
1. Generera nu bildminiatyren, PDF och XPS för att verifiera resultaten.

Implementeringen av ovanstående ges nedan.

```php
  # Använd laddningsalternativ för att definiera standardtypsnitten för vanlig och asiatisk text
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Läs in presentationen
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Generera bildminiatyr
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # spara bilden på disken.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Generera PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Generera XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Vad exakt påverkar DefaultRegularFont och DefaultAsianFont—endast export, eller även miniatyrer, PDF, XPS, HTML och SVG?**

De deltar i renderingspipelines för alla stödda utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/php-java/convert-powerpoint-to-png/), [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), och [SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyfupplösningslogik för dessa mål.

**Appliceras standardtypsnitt när man bara läser och sparar en PPTX utan någon renderning?**

Nej. Standardtypsnitt är relevanta när text måste mätas och ritas. En enkel öppna‑spara‑operation av en presentation ändrar inte lagrade typsnittskörningar eller filens struktur. Standardtypsnitt används vid operationer som renderar eller omflödar text.

**Om jag lägger till egna teckensnittsmappor eller tillhandahåller teckensnitt från minnet, kommer de att beaktas vid val av standardtypsnitt?**

Ja. [Anpassade typsnittskällor](/slides/sv/php-java/custom-font/) utökar katalogen med tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback‑regler](/slides/sv/php-java/fallback-font/) kommer att lösas mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmetrik (kerning, avstånd) och därmed radbrytningar och radomslag?**

Ja. Att byta typsnitt ändrar glyfmetrik och kan förändra radbrytningar, radomslag och paginering under rendering. För layoutstabilitet, [bädda in originaltypsnitten](/slides/sv/php-java/embedded-font/) eller välj metrisk kompatibla standard‑ och fallback‑familjer.

**Finns det någon nytta med att ange standardtypsnitt om alla typsnitt som används i presentationen är inbäddade?**

Ofta är det inte nödvändigt, eftersom [inbäddade typsnitt](/slides/sv/php-java/embedded-font/) redan garanterar enhetligt utseende. Standardtypsnitt hjälper ändå som en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.