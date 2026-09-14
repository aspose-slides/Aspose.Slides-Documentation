---
title: Använd reservtypsnitt för presentationer i Python via Java
linktitle: Reservtypsnitt
type: docs
weight: 10
url: /sv/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Behärska Aspose.Slides för Python via Java för att ange reservtypsnitt i PPT-, PPTX- och ODP-filer, vilket skyddar konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservtypsnitt för rendering och export av presentationer. Reservtypsnitt används när huvudtypsnittet inte innehåller tecken för vissa tecken.

Reservbeteendet konfigureras via reservregler. Varje regel associerar ett Unicode‑intervall med ett eller flera typsnitt som kan innehålla de nödvändiga tecknen. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservtypsnitt från befintliga regler och organisera flera regler i en samling av reservtypsnittregler.

Reservregler är inställningar för rendering vid körning. De ändrar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Reservregler**

Aspose.Slides tillhandahåller klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/) för att specificera regler för att tillämpa reservtypsnitt. Denna klass representerar en association mellan ett Unicode‑intervall som används för att söka efter saknade tecken och en lista med typsnitt som kan innehålla de nödvändiga tecknen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Använd flera sätt för att ange en lista med typsnitt.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Du kan även ta bort ett reservtypsnitt med [remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/#remove) eller lägga till reservtypsnitt med [addFallBackFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrulescollection/) kan organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/)‑objekt när du behöver specificera reservtypsnittsersättningsregler för flera Unicode‑intervall.

{{% alert color="info" title="Se även" %}} 
- [Skapa samling av reservtypsnitt](/slides/sv/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett reservtypsnitt, typsnittsbyte och typsnitts inbäddning?**

Ett reservtypsnitt används endast för tecken som saknas i huvudtypsnittet. [Font substitution](/slides/sv/python-java/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Font embedding](/slides/sv/python-java/embedded-font/) paketerar typsnitten i utdatafilen så att mottagarna kan visa texten som avsett.

**Tillämpar reservtypsnitt vid export som PDF, PNG eller SVG, eller endast vid skärmrendering?**

Ja. Reservtypsnitt påverkar alla [renderings‑ och exportoperationer](/slides/sv/python-java/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

**Ändrar konfiguration av reservtypsnitt själva presentationsfilen, och kommer inställningen att bestå vid framtida öppningar?**

Nej. Reservregler är inställningar för rendering vid körning i din kod; de lagras inte i .pptx‑filen och visas inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av teckensnittskataloger valet av reservtypsnitt?**

Ja. Motorn hämtar typsnitt från tillgängliga systemkataloger och eventuella [extra sökvägar](/slides/sv/python-java/custom-font/) du anger. Om ett typsnitt inte finns fysiskt kan en regel som refererar till det inte verkställas.

**Fungerar reservtypsnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma teckensnittssubstitueringsmekanism för att rendera saknade tecken.