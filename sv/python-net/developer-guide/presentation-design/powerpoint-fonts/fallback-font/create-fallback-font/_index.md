---
title: Använd reservteckensnitt för presentationer i Python
linktitle: Reservteckensnitt
type: docs
weight: 10
url: /sv/python-net/create-fallback-font/
keywords:
- reservteckensnitt
- reservregel
- tillämpa typsnitt
- byta ut typsnitt
- Unicode-intervall
- saknad glyf
- korrekt glyf
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska Aspose.Slides för Python via .NET för att ange reservteckensnitt i PPT-, PPTX- och ODP-filer, vilket säkerställer konsekvent textvisning på alla enheter eller operativsystem."
---
## **Översikt**

Aspose.Slides låter dig ange reservteckensnitt för rendering och export av presentationer. Reservteckensnitt används när huvudteckensnittet inte innehåller glyfer för vissa tecken.

Beteendet för reservteckensnitt konfigureras via reservregler. Varje regel associerar ett Unicode‑intervall med ett eller flera typsnitt som kan innehålla de nödvändiga glyferna. Du kan definiera regler för olika teckenintervall, lägga till eller ta bort reservteckensnitt från befintliga regler och organisera flera regler i en samling av reservteckensnittsregler.

Reservregler är inställningar för rendering vid körning. De modifierar inte själva presentationsfilen och lagras inte i PPTX‑filen.

## **Ange reservteckensnitt**

Aspose.Slides stöder klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/FontFallBackRule/) för att ange reglerna för att tillämpa ett reservteckensnitt. Klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/FontFallBackRule/) representerar en association mellan det angivna Unicode‑intervallet, som används för att söka efter saknade glyfer, och en lista med typsnitt som kan innehålla korrekta glyfer:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Använd flera sätt kan du lägga till en lista med teckensnitt:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Det är också möjligt att [remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrule/remove/) reservteckensnitt eller [add_fall_back_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) i ett befintligt [FontFallBackRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/FontFallBackRule/)‑objekt.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrulescollection/) kan användas för att organisera en lista med [FontFallBackRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/FontFallBackRule/)‑objekt, när det behövs ange regler för reservteckensnitt för flera Unicode‑intervall.

{{% alert color="primary" title="See also" %}} 
- [Skapa samling av reservteckensnitt](/slides/sv/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Vanliga frågor**

**Vad är skillnaden mellan ett reservteckensnitt, typsnittssubstitution och typsnittsinbäddning?**

Ett reservteckensnitt används endast för tecken som saknas i huvudtypsnittet. [Font substitution](/slides/sv/python-net/font-substitution/) ersätter hela det angivna typsnittet med ett annat typsnitt. [Font embedding](/slides/sv/python-net/embedded-font/) paketerar typsnitten i utdatafilen så mottagarna kan visa texten som avsett.

**Tillämpas reservteckensnitt vid export som PDF, PNG eller SVG, eller bara vid rendering på skärmen?**

Ja. Reservteckensnitt påverkar alla [rendering and export operations](/slides/sv/python-net/convert-presentation/) där tecken måste ritas men saknas i källtypsnittet.

**Ändrar konfiguration av reservteckensnitt själva presentationsfilen, och kommer inställningen att bestå vid framtida öppningar?**

Nej. Reservregler är körningsinställningar för rendering i din kod; de sparas inte i .pptx‑filen och visas inte i PowerPoint.

**Påverkar operativsystemet (Windows/Linux/macOS) och uppsättningen av teckensnittskataloger valet av reservteckensnitt?**

Ja. Motorn hämtar typsnitt från tillgängliga systemkataloger och eventuella [additional paths](/slides/sv/python-net/custom-font/) du anger. Om ett typsnitt inte finns fysiskt kan en regel som refererar till det inte träda i kraft.

**Fungerar reservteckensnitt för WordArt, SmartArt och diagram?**

Ja. När dessa objekt innehåller text tillämpas samma glyf‑substitueringsmekanism för att rendera saknade tecken.