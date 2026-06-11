---
title: Använd reservteckensnitt för presentationer i C++
linktitle: Reservteckensnitt
type: docs
weight: 10
url: /sv/cpp/create-fallback-font/
keywords:
- reservteckensnitt
- reservregel
- tillämpa teckensnitt
- ersätta teckensnitt
- Unicode-intervall
- saknad glyph
- korrekt glyph
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska Aspose.Slides för C++ för att ange reservteckensnitt i PPT-, PPTX- och ODP-filer och säkerställa konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservteckensnitt för rendering och export av presentationer. Reservteckensnitt används när primära teckensnittet saknar tecken för vissa tecken.

Reservbeteendet konfigureras via reservregler. Varje regel associerar ett Unicode‑intervall med ett eller flera teckensnitt som kan innehålla de behövda teckenkorten. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservteckensnitt från befintliga regler och organisera flera regler i en samling av reservteckensnittsregler.

Reservregler är inställningar för rendering vid körning. De ändrar inte presentationsfilen i sig och sparas inte i PPTX‑filen.

## **Regler för reservteckensnitt**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) för att ange reglerna för att tillämpa ett reservteckensnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) representerar en association mellan det angivna Unicode‑intervallet, som används för att söka saknade tecken, och en lista av teckensnitt som kan innehålla korrekta tecken:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Det är också möjligt att [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/remove/) ett reservteckensnitt eller [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/) kan användas för att organisera en lista av [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) objekt, när det finns ett behov av att ange regler för reservteckensnitt för flera Unicode‑intervall.

{{% alert color="primary" title="Se även" %}} 
- [Skapa samling av reservteckensnitt](/slides/sv/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan ett reservteckensnitt, teckensnittsbyte och teckensnitts‑inbäddning?**

Ett reservteckensnitt används endast för tecken som saknas i det primära teckensnittet. [Teckensnittsbyte](/slides/sv/cpp/font-substitution/) ersätter hela det angivna teckensnittet med ett annat. [Teckensnitts‑inbäddning](/slides/sv/cpp/embedded-font/) paketar teckensnitten i utdatafilen så att mottagarna kan visa texten som avsett.

**Tillämpas reservteckensnitt vid export som PDF, PNG eller SVG, eller endast vid skärmrendering?**

Ja. Reservteckensnitt påverkar alla [renderings‑ och exportoperationer](/slides/sv/cpp/convert-presentation/) där tecken måste ritas men saknas i källteckensnittet.

**Ändrar konfiguration av reservteckensnitt själva presentationsfilen, och kvarstår inställningen vid framtida öppningar?**

Nej. Reservregler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av teckensnittskataloger valet av reservteckensnitt?**

Ja. Motorn löser teckensnitt från tillgängliga systemmappar och eventuella [ytterligare sökvägar](/slides/sv/cpp/custom-font/) du anger. Om ett teckensnitt inte finns fysiskt kan en regel som refererar till det inte verkställas.

**Fungerar reservteckensnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma tecken‑substitutionsmekanism för att rendera saknade tecken.