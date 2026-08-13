---
title: Ange reservtypsnitt för presentationer på Android
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/androidjava/create-fallback-font/
keywords:
- reservtypsnitt
- reservregel
- tillämpa typsnitt
- ersätt typsnitt
- Unicode-område
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska Aspose.Slides för Android via Java för att ange reservtypsnitt i PPT-, PPTX- och ODP-filer, vilket säkerställer konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när det primära typsnittet inte innehåller glyfer för specifika tecken.

Reservbeteende konfigureras via reservregler. Varje regel kopplar ett Unicode‑område till ett eller flera typsnitt som kan innehålla de nödvändiga glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av reservtypsnittsregler.

Reservregler är renderingsinställningar vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Reservregler**

Aspose.Slides stödjer gränssnittet [IFontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IFontFallBackRule) och klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) för att specificera reglerna för att använda ett reservtypsnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) representerar en koppling mellan det angivna Unicode‑området, som används för att söka efter saknade glyfer, och en lista av typsnitt som kan innehålla korrekta glyfer:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Genom flera sätt kan du lägga till en lista med typsnitt:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [ta bort](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) reservtypsnitt eller [lägga till reservtypsnitt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule)-objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista av [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule)-objekt, när det finns ett behov av att specificera reservtypsnittsbytesregler för flera Unicode‑områden.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/sv/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Vad är skillnaden mellan ett reservtypsnitt, typsnittsbyte och typsnitts inbäddning?

Ett reservtypsnitt används endast för tecken som saknas i det primära typsnittet. [Typsnittsbyte](/slides/sv/androidjava/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Typsnitts inbäddning](/slides/sv/androidjava/embedded-font/) paketerar typsnitten i utdatafilen så att mottagarna kan visa texten som avsett.

### Tillämpas reservtypsnitt vid export som PDF, PNG eller SVG, eller endast vid skärmrendering?

Ja. Reserv påverkar alla [renderings- och exportoperationer](/slides/sv/androidjava/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

### Ändrar konfiguration av reservtypsnitt själva presentationsfilen, och kommer inställningen att bestå vid framtida öppningar?

Nej. Reservregler är renderingsinställningar vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

### Påverkar operativsystemet (Windows/Linux/macOS) och mängden fontkataloger reservvalet?

Ja. Motorn hämtar typsnitt från tillgängliga systemmappar och eventuella [ytterligare sökvägar](/slides/sv/androidjava/custom-font/) du anger. Om ett typsnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte verkställas.

### Fungerar reservtypsnitt för WordArt, SmartArt och diagram?

Ja. När dessa objekt innehåller text tillämpas samma glyf‑bytesmekanism för att rendera saknade tecken.