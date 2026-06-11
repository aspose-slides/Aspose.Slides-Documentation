---
title: Ange reservteckensnitt för presentationer på Android
linktitle: Reservteckensnitt
type: docs
weight: 10
url: /sv/androidjava/create-fallback-font/
keywords:
- reservteckensnitt
- reservregel
- tillämpa teckensnitt
- ersätta teckensnitt
- Unicode‑område
- saknad tecken
- korrekt tecken
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska Aspose.Slides för Android via Java för att ange reservteckensnitt i PPT, PPTX och ODP‑filer, vilket säkerställer konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservteckensnitt för rendering och export av presentationer. Reservteckensnitt används när huvudteckensnittet inte innehåller tecken för specifika tecken.

Beteendet för reservteckensnitt konfigureras via reservteckensnittregler. Varje regel associerar ett Unicode‑område med ett eller flera teckensnitt som kan innehålla de nödvändiga tecknen. Du kan definiera regler för olika teckenområden, lägga till eller ta bort reservteckensnitt från befintliga regler och organisera flera regler i en samling av reservteckensnittregler.

Reservteckensnittregler är inställningar för rendering vid körning. De ändrar inte presentationsfilen i sig och lagras inte i PPTX‑filen.

## **Reservteckensnittregler**

Aspose.Slides stöder gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IFontFallBackRule) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) för att ange regler för att tillämpa ett reservteckensnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) representerar en koppling mellan det angivna Unicode‑området, som används för att söka efter saknade tecken, och en lista med teckensnitt som kan innehålla rätt tecken:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Med flera sätt kan du lägga till en lista med teckensnitt:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [ta bort](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) reservteckensnitt eller [addFallBackFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule)‑objekt, när det finns ett behov av att ange regler för reservteckensnittsutbyte för flera Unicode‑områden.

{{% alert color="primary" title="Se också" %}}
- [Skapa samling med reservteckensnitt](/slides/sv/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

**What is the difference between a fallback font, font substitution, and font embedding?**

Ett reservteckensnitt används endast för tecken som saknas i huvudteckensnittet. [Font substitution](/slides/sv/androidjava/font-substitution/) ersätter hela det angivna teckensnittet med ett annat teckensnitt. [Font embedding](/slides/sv/androidjava/embedded-font/) paketerar teckensnitten i utskriftsfilen så att mottagarna kan se texten som avsett.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Ja. Reservteckensnitt påverkar alla [renderings- och exportoperationer](/slides/sv/androidjava/convert-presentation/) där tecken måste ritas men saknas i källteckensnittet.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

Nej. Reservteckensnittregler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Ja. Motorn löser teckensnitt från tillgängliga systemmappar och eventuella [ytterligare sökvägar](/slides/sv/androidjava/custom-font/) du tillhandahåller. Om ett teckensnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

**Does fallback work for WordArt, SmartArt, and charts?**

Ja. När dessa objekt innehåller text tillämpas samma teckensubstitutionsmekanism för att rendera saknade tecken.