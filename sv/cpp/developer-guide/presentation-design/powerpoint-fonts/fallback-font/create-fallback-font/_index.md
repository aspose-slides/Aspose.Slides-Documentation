---
title: Ange reservtypsnitt för presentationer i C++
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/cpp/create-fallback-font/
keywords:
- reservtypsnitt
- reservregel
- tillämpa typsnitt
- ersätta typsnitt
- Unicode-intervall
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska Aspose.Slides för C++ för att ange reservtypsnitt i PPT-, PPTX- och ODP-filer, och säkerställa konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när primärtypsnittet inte innehåller glyfer för vissa tecken.

Fallback‑beteende konfigureras via fallback‑regler. Varje regel kopplar ett Unicode‑intervall till ett eller flera typsnitt som kan innehålla de erforderliga glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av fallback‑typsnittregler.

Fallback‑regler är inställningar för rendering vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Fallback‑regler**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) för att ange reglerna för att använda ett reservtypsnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) representerar en koppling mellan det angivna Unicode‑intervallet, som används för att söka efter saknade glyfer, och en lista med typsnitt som kan innehålla korrekta glyfer:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// På flera sätt kan du lägga till en teckensnittlista:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Det är också möjligt att [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/remove/) reservtypsnitt eller [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/)‑objekt när det finns ett behov av att ange regler för reservtypsnittsbyte för flera Unicode‑intervall.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/sv/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan ett reservtypsnitt, Font substitution och Font embedding?**

Ett reservtypsnitt används enbart för tecken som saknas i primärtypsnittet. [Font substitution](/slides/sv/cpp/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Font embedding](/slides/sv/cpp/embedded-font/) paketerar typsnitten i utdatafilen så att mottagarna kan visa texten som avsett.

**Tillämpars reservtypsnitt vid export, t.ex. PDF, PNG eller SVG, eller endast vid skärmrendering?**

Ja. Reservtypsnitt påverkar alla [rendering and export operations](/slides/sv/cpp/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

**Ändrar konfiguration av reservtypsnitt själva presentationsfilen, och kommer inställningen att bestå vid framtida öppningar?**

Nej. Fallback‑regler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av typsnittsmappar valet av reservtypsnitt?**

Ja. Motorn hämtar typsnitt från tillgängliga systemmappar och eventuella [additional paths](/slides/sv/cpp/custom-font/) du anger. Om ett typsnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

**Fungerar reservtypsnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyph‑substitutionsmekanism för att rendera saknade tecken.