---
title: Anpassa PowerPoint-typsnitt i Python
linktitle: Anpassat typsnitt
type: docs
weight: 20
url: /sv/python-net/custom-font/
keywords:
- typsnitt
- anpassat typsnitt
- externt typsnitt
- ladda typsnitt
- hantera typsnitt
- typsnittsmapp
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Bädda in anpassade typsnitt i PowerPoint-bilder med Aspose.Slides för Python via .NET för att hålla dina presentationer skarpa och konsistenta på alla enheter."
---
## **Översikt**

Aspose.Slides för Python låter dig tillhandahålla anpassade typsnitt vid körning så att presentationer renderas korrekt även när de nödvändiga typsnitten inte är installerade på värdsystemet. Vid export till PDF eller bilder kan du ange typsnittsmappor eller typsnitt i minnet för att bevara textlayout, glyfmetriker och typografi. Detta gör server‑sidigerendering förutsägbar över olika miljöer, tar bort OS‑nivå typsnittsberoenden och förhindrar oönskade reservtypsnitt eller omslagning. Artikeln visar hur du registrerar typsnittskällor.

Aspose.Slides låter dig ladda följande typsnitt med metoderna `load_external_font` och `load_external_fonts` i klassen [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) och TrueType Collection (.ttc) typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Ladda anpassade typsnitt**

Aspose.Slides gör det möjligt att ladda typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata—t.ex. PDF, bilder och andra stödjade format—så att de resulterande dokumenten ser konsekventa ut över miljöer. Typsnitt laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilerna.
2. Anropa den statiska metoden [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/load_external_fonts/) för att ladda typsnitt från dessa mappar.
3. Ladda och rendera/exportera presentationen.
4. Anropa [FontsLoader.clear_cache](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/clear_cache/) för att rensa typsnittscachen.

Följande kodexempel demonstrerar processen för att ladda typsnitt:

```py
import aspose.slides as slides

# Definiera mappar som innehåller anpassade typsnittsfiler.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Ladda anpassade typsnitt från de angivna mapparna.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa typsnitten.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Rensa typsnittscachen när arbetet är slutfört.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/load_external_fonts/) lägger till ytterligare mappar i typsnittssökvägarna, men ändrar inte ordningen för typsnittsininitiering.
Typsnitt initieras i följande ordning:

1. Standard‑operativsystemets typsnittsväg.
1. Vägarna som laddas via [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta mappen för anpassade typsnitt**

Aspose.Slides tillhandahåller metoden `get_font_folders` för att hämta typsnittsmappar. Den returnerar både de mappar som lagts till via `load_external_fonts` och systemets typsnittsmappar.

Denna Python‑kod visar hur man använder `get_font_folders`:

```python
import aspose.slides as slides

# Detta anrop returnerar mapparna som kontrolleras för typsnittsfiler.
# Dessa inkluderar mappar som lagts till via load_external_fonts-metoden och systemets typsnittsmappor.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Ange anpassade typsnitt för en presentation**

Aspose.Slides erbjuder egenskapen `document_level_font_sources`, som låter dig ange externa typsnitt att använda med en presentation.

Följande Python‑exempel visar hur man använder `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Arbeta med presentationen.
    # CustomFont1, CustomFont2 och typsnitt från mapparna assets\fonts och global\fonts (och deras undermappar) är tillgängliga för presentationen.
    # ...
    print(len(presentation.slides))
```

## **Ladda externa typsnitt från binär data**

Aspose.Slides tillhandahåller metoden `load_external_font` för att ladda externa typsnitt från binär data.

Följande Python‑exempel demonstrerar hur man laddar ett typsnitt från en byte‑array:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Ladda externa typsnitt från byte-arrayer.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externa typsnitt är tillgängliga under hela livslängden för detta presentationsobjekt.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

**Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna typsnitt används av renderaren i alla exportformat.

**Bäddas anpassade typsnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett typsnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att typsnittet finns i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/python-net/embedded-font/).

**Kan jag styra fallback‑beteendet när ett anpassat typsnitt saknar vissa glyfer?**

Ja. Konfigurera [font substitution](/slides/sv/python-net/font-substitution/), [replacement rules](/slides/sv/python-net/font-replacement/) och [fallback sets](/slides/sv/python-net/fallback-font/) för att exakt ange vilket typsnitt som ska användas när den begärda glyfen saknas.

**Kan jag använda typsnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna typsnittsmappar eller ladda typsnitt från byte‑arrayer. Detta tar bort alla beroenden av systemets typsnittskataloger i container‑avbilden.

**Hur är det med licensiering—kan jag bädda in vilket anpassat typsnitt som helst utan restriktioner?**

Du är ansvarig för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.