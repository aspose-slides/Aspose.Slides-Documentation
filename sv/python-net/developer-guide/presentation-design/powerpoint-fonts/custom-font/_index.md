---
title: Anpassa PowerPoint‑teckensnitt i Python
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/python-net/custom-font/
keywords:
- teckensnitt
- anpassat teckensnitt
- externt teckensnitt
- ladda teckensnitt
- hantera teckensnitt
- teckensnittsmapp
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Bädda in anpassade teckensnitt i PowerPoint‑bilder med Aspose.Slides för Python via .NET för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides för Python låter dig tillhandahålla anpassade teckensnitt vid körning så att presentationer renderas korrekt även när de erforderliga teckensnitten inte är installerade på värdsystemet. Vid export till PDF eller bilder kan du ange teckensnittsmappor eller teckensnitt i minnet för att bevara textlayout, glyf-mått och typografi. Detta gör server‑sidans rendering förutsägbar i olika miljöer, tar bort OS‑nivå beroenden på teckensnitt och förhindrar oönskade återgångar eller omläggning. Artikeln visar hur du registrerar teckensnittskällor.

Ett presentations‑tema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller laddar inte teckensnittsfilerna. Se [Script‑Specific Theme Fonts](/slides/sv/python-net/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

Aspose.Slides låter dig ladda följande teckensnitt med metoderna `load_external_font` och `load_external_fonts` i klassen [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/):

- TrueType‑ (.ttf) och TrueType Collection‑ (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType‑ (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Ladda anpassade teckensnitt**

Aspose.Slides gör det möjligt att ladda teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultatet – såsom PDF, bilder och andra stödda format – så att de resulterande dokumenten ser enhetliga ut i olika miljöer. Teckensnitt laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.  
2. Anropa den statiska metoden [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/load_external_fonts/) för att ladda teckensnitt från dessa mappar.  
3. Ladda och rendera/exportera presentationen.  
4. Anropa [FontsLoader.clear_cache](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/clear_cache/) för att tömma teckensnittscachen.

Följande kodexempel demonstrerar teckensnittsladdningsprocessen:

```py
import aspose.slides as slides

# Definiera mappar som innehåller anpassade teckensnittsfiler.
font_folders = ["fonts", "external_fonts"]

# Ladda anpassade teckensnitt från de angivna mapparna.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Rensa teckensnittscachen när arbetet är klart.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/load_external_fonts/) lägger till extra mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitering.  
Teckensnitt initieras i följande ordning:

1. Operativsystemets standard‑teckensnittssökväg.  
1. Sökvägarna som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Hämta mappen för anpassade teckensnitt**

Aspose.Slides tillhandahåller metoden `get_font_folders` för att hämta teckensnittsmappar. Den returnerar både de mappar som lagts till via `load_external_fonts` och systemets teckensnittsmappar.

Denna Python‑kod visar hur du använder `get_font_folders`:

```python
import aspose.slides as slides

# Detta anrop returnerar mapparna som kontrolleras för teckensnittsfiler.
# Dessa inkluderar mappar som lagts till via load_external_fonts-metoden och systemets teckensnittsmapp.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Ange anpassade teckensnitt för en presentation**

Aspose.Slides tillhandahåller egenskapen `document_level_font_sources`, som låter dig ange externa teckensnitt som ska användas med en presentation.

Följande Python‑exempel visar hur du använder `document_level_font_sources`:

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
    # CustomFont1, CustomFont2 och teckensnitt från mapparna assets\fonts och global\fonts (och deras undermappar) är tillgängliga för presentationen.
    # ...
    print(len(presentation.slides))
```

## **Ladda externa teckensnitt från binär data**

Aspose.Slides erbjuder metoden `load_external_font` för att ladda externa teckensnitt från binär data.

Följande Python‑exempel demonstrerar hur ett teckensnitt laddas från en byte‑array:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Ladda externa teckensnitt från byte-arrayer.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externa teckensnitt är tillgängliga under hela livstiden för detta presentations‑objekt.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna teckensnitt används av renderaren i alla exportformat.

### Bäddar anpassade teckensnitt automatiskt in i den resulterande PPTX‑filen?

Nej. Att registrera ett teckensnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att teckensnittet bäddas in i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/python-net/embedded-font/).

### Kan jag styra återgångsbeteende när ett anpassat teckensnitt saknar vissa glyfer?

Ja. Konfigurera [teckensnittssubstitution](/slides/sv/python-net/font-substitution/), [ersättningsregler](/slides/sv/python-net/font-replacement/) och [återgångsset](/slides/sv/python-net/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den begärda glyfen saknas.

### Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?

Ja. Peka på dina egna teckensnittsmappar eller ladda teckensnitt från byte‑arrayer. Detta tar bort alla beroenden på systemteckensnittskataloger i behållaravbilden.

### Vad gäller licensiering—kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?

Du ansvarar för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.