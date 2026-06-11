---
title: Ange reservfonter för presentationer i PHP
linktitle: Reservfont
type: docs
weight: 10
url: /sv/php-java/create-fallback-font/
keywords:
- reservfont
- reservregel
- tillämpa font
- ersätta font
- Unicode-intervall
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska Aspose.Slides för PHP via Java för att ställa in reservfonter i PPT-, PPTX- och ODP-filer, vilket säkerställer enhetlig textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservfonter för rendering och export av presentationer. Reservfonter används när primärfonten saknar glyphs för vissa tecken.

Fallback‑beteende konfigureras via fallback‑regler. Varje regel associerar ett Unicode‑intervall med ett eller flera teckensnitt som kan innehålla de erforderliga glyphsen. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservfonter från befintliga regler och organisera flera regler i en samling av fallback‑fontregler.

Fallback‑regler är inställningar för rendering vid körning. De ändrar inte presentationsfilen i sig och lagras inte i PPTX‑filen.

## **Fallback‑regler**

Aspose.Slides stödjer klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule) för att ange regler för att tillämpa en reservfont. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule) representerar en association mellan det angivna Unicode‑intervallet, som används för att söka efter saknade glyphs, och en lista över teckensnitt som kan innehålla korrekta glyphs:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Genom flera sätt kan du lägga till teckensnittlista:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Det är också möjligt att [ta bort](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontfallbackrule/remove/) en reservfont eller [addFallBackFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista av [FontFallBackRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule)‑objekt, när det finns behov av att ange regler för reservfontersättning för flera Unicode‑intervall.

{{% alert color="primary" title="Se även" %}} 
- [Skapa samling av reservfonter](/slides/sv/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan en fallback‑font, font substitution och font embedding?**

En fallback‑font används endast för tecken som saknas i den primära fonten. [Font substitution](/slides/sv/php-java/font-substitution/) ersätter hela den angivna fonten med en annan font. [Font embedding](/slides/sv/php-java/embedded-font/) paketerar fonterna i utdatafilen så att mottagare kan se texten som avsett.

**Tillämpas fallback‑fonter under export som PDF, PNG eller SVG, eller bara vid skärmrendering?**

Ja. Fallback påverkar alla [rendering- och exportoperationer](/slides/sv/php-java/convert-presentation/) där tecken måste ritas men saknas i källfonten.

**Ändrar konfiguration av fallback själva presentationsfilen, och sparas inställningen för framtida öppningar?**

Nej. Fallback‑regler är runtime‑renderingsinställningar i din kod; de lagras inte i .pptx‑filen och kommer inte att visas i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av fontkataloger valet av fallback?**

Ja. Motorn hämtar fonter från tillgängliga systemkataloger och eventuella [ytterligare sökvägar](/slides/sv/php-java/custom-font/) du anger. Om en font inte finns fysiskt tillgänglig kan en regel som refererar till den inte verkställas.

**Fungerar fallback för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyph‑substitutionsmekanism för att rendera saknade tecken.