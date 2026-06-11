---
title: "Ange reservteckensnitt för presentationer i Java"
linktitle: "Reservteckensnitt"
type: docs
weight: 10
url: /sv/java/create-fallback-font/
keywords:
- "reservteckensnitt"
- "reservregel"
- "tillämpa teckensnitt"
- "ersätta teckensnitt"
- "Unicode-intervall"
- "saknad glyf"
- "korrekt glyf"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Java"
- "Aspose.Slides"
description: "Behärska Aspose.Slides för Java för att ange reservteckensnitt i PPT-, PPTX- och ODP-filer, vilket säkerställer enhetlig textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservteckensnitt för rendering och export av presentationer. Reservteckensnitt används när det primära teckensnittet saknar glyfer för specifika tecken.

Fallback‑beteendet konfigureras genom fallback‑regler. Varje regel associerar ett Unicode‑intervall med ett eller flera teckensnitt som kan innehålla de nödvändiga glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservteckensnitt från befintliga regler och organisera flera regler i en samling av fallback‑teckensnitt‑regler.

Fallback‑regler är inställningar för rendering vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Fallback‑regler**

Aspose.Slides stöder [IFontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFontFallBackRule)-gränssnittet och [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)-klassen för att ange reglerna för att tillämpa ett reservteckensnitt. [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)-klassen representerar en association mellan det angivna Unicode‑intervallet, som används för att söka efter saknade glyfer, och en lista med teckensnitt som kan innehålla korrekta glyfer:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Genom flera metoder kan du lägga till typsnittslistan:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) reservteckensnitt eller [addFallBackFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista av [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)‑objekt, när det behövs att specificera reservteckensnitt‑ersättningsregler för flera Unicode‑intervall.

{{% alert color="primary" title="Se också" %}} 
- [Skapa samling av reservteckensnitt](/slides/sv/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan ett reservteckensnitt, teckensnittsbyte och teckensnittsinfogning?**

Ett reservteckensnitt används endast för tecken som saknas i det primära teckensnittet. [Font substitution](/slides/sv/java/font-substitution/) ersätter hela det angivna teckensnittet med ett annat teckensnitt. [Font embedding](/slides/sv/java/embedded-font/) paketerar teckensnitten i utskriftsfilen så att mottagare kan visa texten som avsett.

**Appliceras reservteckensnitt vid export som PDF, PNG eller SVG, eller bara vid skärmrendering?**

Ja. Reservteckensnitt påverkar alla [rendering and export operations](/slides/sv/java/convert-presentation/) där tecken måste ritas men saknas i källteckensnittet.

**Ändrar konfigurationen av reservteckensnitt själva presentationsfilen, och kvarstår inställningen vid framtida öppningar?**

Nej. Fallback‑regler är runtime‑renderingsinställningar i din kod; de lagras inte i .pptx‑filen och syns inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och de angivna teckensnittskatalogerna valet av reservteckensnitt?**

Ja. Motorn löser teckensnitt från tillgängliga systemkataloger och eventuella [additional paths](/slides/sv/java/custom-font/) du anger. Om ett teckensnitt inte finns fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

**Fungerar reservteckensnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyf‑ersättningsmekanism för att rendera saknade tecken.