---
title: Anpassa PowerPoint-teckensnitt i Python via Java
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/python-java/custom-font/
keywords:
- teckensnitt
- anpassat teckensnitt
- externt teckensnitt
- ladda teckensnitt
- hantera teckensnitt
- teckensnittsmapp
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint-bilder med Aspose.Slides för Python via Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från anpassade mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du inspekterar teckensnittsmappningarna som används av Aspose.Slides och hur du tömmer teckensnittscachen efter att ha arbetat med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd teckensnittsinbäddningsfunktionerna explicit.

Ett presentationstema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller läser inte in teckensnittsfilen. Se [Script‑Specific Theme Fonts](/slides/sv/python-java/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

{{% alert color="info" title="Obs" %}}
Aspose.Slides låter dig läsa in dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* TrueType (.ttf) och TrueType Collection (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata—såsom PDF, bilder och andra stödda format—så att de resulterande dokumenten ser konsekventa ut över miljöer. Teckensnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFonts) för att läsa in teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#clearCache) för att rensa teckensnittscachen.

Följande kodexempel demonstrerar processen för att läsa in teckensnitt:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definiera mappar som innehåller anpassade teckensnittsfiler.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Ladda anpassade teckensnitt från de angivna mapparna.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Rendera/exportera presentationen med de inlästa teckensnitten.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Rensa teckensnittscachen efter att arbetet är slutfört.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Obs" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFonts) lägger till ytterligare mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitialisering.  
Teckensnitt initieras i följande ordning:

1. Den standardmässiga operativsystemets teckensnittssökväg.  
1. Sökvägarna som läses in via [FontsLoader](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**

Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#getFontFolders) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via [loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFonts) metoden samt systemets teckensnittsmappar.

Den här Python‑koden visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Hämta mappar som lagts till via loadExternalFonts och systemets teckensnittsmappor.
font_folders = FontsLoader.getFontFolders()
```

## **Specificera anpassade teckensnitt som används med en presentation**

Aspose.Slides tillhandahåller metoden [getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Den här Python‑koden visar hur du använder metoden [getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Arbeta med presentationen.
    # CustomFont1, CustomFont2 och teckensnitt från assets/fonts och global/fonts
    # och deras undermappar är tillgängliga för presentationen.
    pass
finally:
    presentation.dispose()
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadExternalFont) för att låta dig läsa in externa teckensnitt från binär data.

Den här Python‑koden demonstrerar processen för att läsa in teckensnitt från en byte‑array:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Externa teckensnitt laddas under presentationens livstid.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?**  
Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

**Bäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?**  
Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du behöver att teckensnittet finns med i presentationsfilen måste du använda de uttryckliga [inbäddningsfunktionerna](/slides/sv/python-java/embedded-font/).

**Kan jag kontrollera fallback‑beteende när ett anpassat teckensnitt saknar vissa tecken?**  
Ja. Konfigurera [font substitution](/slides/sv/python-java/font-substitution/), [replacement rules](/slides/sv/python-java/font-replacement/) och [fallback sets](/slides/sv/python-java/fallback-font/) för att exakt definiera vilket teckensnitt som används när den begärda teckengrafen saknas.

**Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**  
Ja. Peka på dina egna teckensnittsmappar eller läs in teckensnitt från byte‑arrayer. Detta tar bort alla beroenden på systemteckensnittskataloger i behållarbilden.

**Vad gäller licensiering—kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?**  
Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.