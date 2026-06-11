---
title: Ange reservtypsnitt för presentationer i JavaScript
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/nodejs-java/create-fallback-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska Aspose.Slides för Node.js för att ange reservtypsnitt i PPT-, PPTX- och ODP-filer med JavaScript, vilket säkerställer konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när det primära typsnittet saknar glyfer för vissa tecken.

Reservbeteendet konfigureras via reservregler. Varje regel kopplar ett Unicode‑intervall till ett eller flera typsnitt som kan innehålla de behövda glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av reservtypsnittregler.

Reservregler är renderingsinställningar som gäller vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Reservregler**

Aspose.Slides stöder [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule)‑klassen och [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule)‑klassen för att ange reglerna för att använda ett reservtypsnitt. [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule)‑klassen representerar en association mellan det specificerade Unicode‑intervallet, som används för att söka efter saknade glyfer, och en lista med typsnitt som kan innehålla korrekta glyfer:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Genom att använda flera metoder kan du lägga till en typsnittslista:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Det är också möjligt att [remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) reservtypsnitt eller [addFallBackFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule)‑objekt, när det behövs att specificera regler för reservtypsnittsbyte för flera Unicode‑intervall.

{{% alert color="primary" title="Se också" %}} 
- [Skapa en samling av reservtypsnitt](/slides/sv/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett reservtypsnitt, typsnittsutbyte och typsnittsinfästad?**

Ett reservtypsnitt används endast för tecken som saknas i det primära typsnittet. [Typsnittsutbyte](/slides/sv/nodejs-java/font-substitution/) ersätter hela det specificerade typsnittet med ett annat typsnitt. [Typsnittsinfästad](/slides/sv/nodejs-java/embedded-font/) paketerar typsnitten i utdatafilen så mottagarna kan visa texten som avsett.

**Tillämpas reservtypsnitt under export som PDF, PNG eller SVG, eller bara vid skärmrendering?**

Ja. Reservtypsnitt påverkar alla [renderings- och exportoperationer](/slides/sv/nodejs-java/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

**Ändrar konfigurationen av reservtypsnitt själva presentationsfilen, och kvarstår inställningen vid framtida öppningar?**

Nej. Reservregler är renderingsinställningar som körs i din kod; de lagras inte i .pptx och visas inte i PowerPoint.

**Påverkas reservvalet av operativsystemet (Windows/Linux/macOS) och de angivna teckensnittskatalogerna?**

Ja. Motorn löser typsnitt från tillgängliga systemkataloger och eventuella [additional paths](/slides/sv/nodejs-java/custom-font/) du anger. Om ett typsnitt inte finns fysiskt tillgängligt kan en regel som refererar till det inte träda i kraft.

**Fungerar reservtypsnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyf‑utbytesmekanism för att rendera saknade tecken.