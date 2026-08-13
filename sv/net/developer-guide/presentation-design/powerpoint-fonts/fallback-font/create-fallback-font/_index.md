---
title: An

linktitle: Reservfont
type: docs
weight: 10
url: /sv/net/create-fallback-font/
keywords:
- reservfont
- reservregel
- tillämpa font
- ersätta font
- Unicode-område
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska Aspose.Slides för .NET för att ställa in reservfonter i PPT-, PPTX- och ODP-filer, vilket säkerställer konsekvent textvisning på vilken enhet eller operativsystem som helst."
---
## **Översikt**

Aspose.Slides låter dig ange reservfonter för presentation rendering och exportoperationer. Reservfonter används när primärfonten inte innehåller glyfer för vissa tecken.

Reservbeteende konfigureras via reservregler. Varje regel associerar ett Unicode‑område med en eller flera fonter som kan innehålla de nödvändiga glyferna. Du kan definiera regler för olika teckenuppsättningar, lägga till eller ta bort reservfonter från befintliga regler, och organisera flera regler i en samling av reservfontregler.

Reservregler är inställningar för rendering vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Reservregler**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/iFontFallBackRule) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) för att ange reglerna för att tillämpa en reservfont. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) representerar en association mellan det angivna Unicode‑området, som används för att söka efter saknade glyfer, och en lista med fonter som kan innehålla korrekta glyfer:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Använd flera sätt för att lägga till en fontlista:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [Remove()](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontfallbackrule/methods/remove) reservfont eller [AddFallBackFonts()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection)kan användas för att organisera en lista av [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) objekt, när det finns ett behov av att ange reservfontbytesregler för flera Unicode‑områden.

{{% alert color="info" title="Se även" %}} 
- [Skapa en samling av reservfonter](/slides/sv/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

### Vad är skillnaden mellan en reservfont, font substitution och font embedding?

En reservfont används endast för tecken som saknas i primärfonten. [Font substitution](/slides/sv/net/font-substitution/) ersätter hela den angivna fonten med en annan font. [Font embedding](/slides/sv/net/embedded-font/) paketar fonterna i utdatafilen så att mottagare kan visa texten som avsett.

### Tillämpas reservfonter under export som PDF, PNG eller SVG, eller endast vid skärmrendering?

Ja. Reservfonter påverkar alla [renderings- och exportoperationer](/slides/sv/net/convert-presentation/) där tecken måste ritas men saknas i källfonten.

### Ändrar konfiguration av reservfonter själva presentationsfilen, och kommer inställningen att bestå för framtida öppningar?

Nej. Reservregler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

### Påverkar operativsystemet (Windows/Linux/macOS) och mängden fontkataloger valet av reservfont?

Ja. Motorn hämtar fonter från tillgängliga systemkataloger och eventuella [ytterligare sökvägar](/slides/sv/net/custom-font/) du anger. Om en font inte är fysiskt tillgänglig kan en regel som refererar till den inte verkställas.

### Fungerar reservfonter för WordArt, SmartArt och diagram?

Ja. När dessa objekt innehåller text tillämpas samma glyf‑substitutionsmekanism för att rendera saknade tecken.