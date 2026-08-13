---
title: Specificera reservtypsnitt för presentationer i Java
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/java/create-fallback-font/
keywords:
- reservtypsnitt
- reservregel
- tillämpa typsnitt
- ersätta typsnitt
- Unicode‑intervall
- saknad teckenform
- korrekt teckenform
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska Aspose.Slides för Java för att ange reservtypsnitt i PPT-, PPTX- och ODP‑filer, vilket säkerställer konsekvent textvisning på vilken enhet eller vilket OS som helst."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när huvudtypsnittet saknar tecken för vissa tecken.

Reservbeteendet konfigureras via reservregler. Varje regel associerar ett Unicode‑intervall med ett eller flera typsnitt som kan innehålla de nödvändiga tecken. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av reservtypsnittregler.

Reservregler är runtime‑renderingsinställningar. De ändrar inte presentationsfilen i sig och lagras inte i PPTX‑filen.

## **Regler för reservtypsnitt**

Aspose.Slides stöder [IFontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFontFallBackRule)-gränssnittet och [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)-klassen för att specificera reglerna för att tillämpa ett reservtypsnitt. [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)-klassen representerar en association mellan det angivna Unicode‑intervallet, som används för att söka efter saknade tecken, och en lista med typsnitt som kan innehålla rätt tecken:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Använd flera sätt för att lägga till teckensnittlista:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Det är också möjligt att [remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) ett reservtypsnitt eller [addFallBackFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule) objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRulesCollection) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule)‑objekt när det behövs specificera reservtypsnittsbytesregler för flera Unicode‑intervall.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/sv/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

### Vad är skillnaden mellan ett reservtypsnitt, typsnittsbyte och typsnittsinbäddning?

Ett reservtypsnitt används endast för tecken som saknas i huvudtypsnittet. [Font substitution](/slides/sv/java/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Font embedding](/slides/sv/java/embedded-font/) paketerar typsnitten i utdatafilen så att mottagare kan visa texten som avsett.

### Tillämpas reservtypsnitt vid export som PDF, PNG eller SVG, eller bara vid skärmrendering?

Ja. Reservtypsnitt påverkar alla [rendering and export operations](/slides/sv/java/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

### Ändrar konfiguration av reservtypsnitt presentationsfilen i sig, och kvarstår inställningen vid framtida öppningar?

Nej. Reservregler är runtime‑renderingsinställningar i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

### Påverkar operativsystemet (Windows/Linux/macOS) och de angivna teckensnittsmapparna valet av reservtypsnitt?

Ja. Motorn hämtar typsnitt från tillgängliga systemkataloger och eventuella [additional paths](/slides/sv/java/custom-font/) du anger. Om ett typsnitt inte är fysiskt tillgängligt kan en regel som refererar till det inte få effekt.

### Fungerar reservtypsnitt för WordArt, SmartArt och diagram?

Ja. När dessa objekt innehåller text tillämpas samma tecken‑substitutionsmekanism för att rendera saknade tecken.