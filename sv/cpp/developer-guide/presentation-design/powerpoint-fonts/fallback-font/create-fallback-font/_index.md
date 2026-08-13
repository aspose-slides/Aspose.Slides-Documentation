---
title: Ange reservteckensnitt för presentationer i C++
linktitle: Reservteckensnitt
type: docs
weight: 10
url: /sv/cpp/create-fallback-font/
keywords:
- reservteckensnitt
- reservregel
- tillämpa teckensnitt
- ersätt teckensnitt
- Unicode-intervall
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska Aspose.Slides för C++ för att ange reservteckensnitt i PPT-, PPTX- och ODP-filer, vilket säkerställer enhetlig textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservteckensnitt för rendering och export av presentationer. Reservteckensnitt används när huvudteckensnittet inte innehåller glyfer för vissa tecken.

Beteendet för reservteckensnitt konfigureras via reservregler. Varje regel kopplar ett Unicode‑område till en eller flera typsnitt som kan innehålla de nödvändiga glyferna. Du kan definiera regler för olika teckenområden, lägga till eller ta bort reservteckensnitt från befintliga regler och organisera flera regler i en samling av reservteckensnittregler.

Reservregler är inställningar för rendering vid körning. De ändrar inte presentationsfilen i sig och lagras inte i PPTX‑filen.

## **Regler för reservteckensnitt**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) för att ange regler för att använda ett reservteckensnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) representerar en association mellan det angivna Unicode‑intervallet, som används för att söka efter saknade glyfer, och en lista med typsnitt som kan innehålla korrekta glyfer:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Genom att använda flera sätt kan du lägga till en teckensnittlista:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Det är också möjligt att [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/remove/) reservteckensnitt eller [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/)‑objekt, när det finns ett behov av att ange reservteckensnittets ersättningsregler för flera Unicode‑områden.

{{% alert color="info" title="See also" %}} 
- [Skapa samling av reservteckensnitt](/slides/sv/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

### Vad är skillnaden mellan ett reservteckensnitt, teckensnittssubstitution och teckensnittsinbäddning?

Ett reservteckensnitt används endast för tecken som saknas i huvudteckensnittet. [Font substitution](/slides/sv/cpp/font-substitution/) ersätter hela det angivna teckensnittet med ett annat teckensnitt. [Font embedding](/slides/sv/cpp/embedded-font/) paketerar teckensnitten i utsfilen så mottagare kan visa texten som avsett.

### Tillämpas reservteckensnitt vid export som PDF, PNG eller SVG, eller bara vid rendering på skärmen?

Ja. Reservteckensnitt påverkar alla [renderings- och exportoperationer](/slides/sv/cpp/convert-presentation/) där tecken måste ritas men saknas i källteckensnittet.

### Ändrar konfiguration av reservteckensnitt presentationsfilen i sig, och kvarstår inställningen vid framtida öppningar?

Nej. Reservregler är runtime‑renderingsinställningar i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

### Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av teckensnittskataloger valet av reservteckensnitt?

Ja. Motorn löser teckensnitt från tillgängliga systemkataloger och eventuella [ytterligare sökvägar](/slides/sv/cpp/custom-font/) du anger. Om ett teckensnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

### Fungerar reservteckensnitt för WordArt, SmartArt och diagram?

Ja. När dessa objekt innehåller text tillämpas samma glyf‑substitutionsmekanism för att rendera saknade tecken.