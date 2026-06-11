---
title: Ange reservtypsnitt för presentationer i .NET
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Behärska Aspose.Slides för .NET för att ange reservtypsnitt i PPT-, PPTX- och ODP-filer, vilket säkerställer konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när huvudtypsnittet saknar glyfer för vissa tecken.

Beteendet för reservtypsnitt konfigureras via reservregler. Varje regel associerar ett Unicode‑intervall med ett eller flera typsnitt som kan innehålla de erforderliga glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av reservtypsnittregler.

Reservregler är inställningar för rendering vid körning. De ändrar inte presentationsfilen i sig och lagras inte i PPTX‑filen.

## **Reservregler**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/iFontFallBackRule) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) för att ange reglerna för att använda ett reservtypsnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) representerar en association mellan det angivna Unicode‑intervallet, som används för att söka missade glyfer, och en lista med typsnitt som kan innehålla korrekta glyfer:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Genom att använda flera sätt kan du lägga till en typsnittlista:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [Remove()](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontfallbackrule/methods/remove) reservtypsnitt eller [AddFallBackFonts()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection)kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) objekt, när det behövs att ange regler för reservtypsnittsbyte för flera Unicode‑intervall.

{{% alert color="primary" title="Se också" %}} 
- [Skapa en samling av reservtypsnitt](/slides/sv/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett reservtypsnitt, teckensnittssubstitution och teckensnittsinbäddning?**

Ett reservtypsnitt används endast för tecken som saknas i huvudtypsnittet. [Font substitution](/slides/sv/net/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Font embedding](/slides/sv/net/embedded-font/) paketerar typsnitten i utdatafilen så mottagarna kan visa texten som avsett.

**Tillämpas reservtypsnitt vid export som PDF, PNG eller SVG, eller endast vid skärmrending?**

Ja. Reservtypsnitt påverkar alla [rendering and export operations](/slides/sv/net/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

**Ändrar konfigurering av reservtypsnitt presentationsfilen i sig, och sparas inställningen för framtida öppningar?**

Nej. Reservregler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av typsnittskataloger valet av reservtypsnitt?**

Ja. Motorn hämtar typsnitt från tillgängliga systemkataloger och eventuella [additional paths](/slides/sv/net/custom-font/) du anger. Om ett typsnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

**Fungerar reservtypsnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyf‑substitutionsmekanism för att rendera saknade tecken.