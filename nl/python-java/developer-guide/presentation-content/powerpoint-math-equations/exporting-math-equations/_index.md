---
title: Exporteer wiskundige vergelijkingen uit presentaties in Python
linktitle: Exporteer vergelijkingen
type: docs
weight: 30
url: /nl/python-java/exporting-math-equations/
keywords:
- exporteer wiskundige vergelijkingen
- exporteer vergelijkingen naar LaTeX
- PowerPoint naar LaTeX
- MathML
- LaTeX
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Exporteer wiskundige vergelijkingen uit PowerPoint-presentaties naar LaTeX of MathML direct met Aspose.Slides voor Python via Java."
---
## **Inleiding**

Aspose.Slides stelt u in staat om wiskundige vergelijkingen uit presentaties te exporteren. Bijvoorbeeld, u wilt mogelijk de wiskundige vergelijkingen op dia's (van een specifieke presentatie) extraheren en gebruiken in een ander programma of platform. 

{{% alert color="info" title="Note" %}} 

U kunt formules rechtstreeks exporteren naar LaTeX of naar MathML, een populaire standaard voor wiskundige inhoud die op het web en in vele toepassingen wordt gebruikt.

{{% /alert %}}

## **Wiskundige vergelijkingen exporteren naar LaTeX**

Aspose.Slides kan een PowerPoint‑wiskundige formule rechtstreeks naar LaTeX converteren; een tussenliggende MathML‑bestand en een externe converter zijn niet nodig. Een wiskundige formule wordt in een tekstvak opgeslagen als een [MathPortion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathportion/). Gebruik [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathportion/#getMathParagraph) om een [MathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/) te verkrijgen, en roep vervolgens [MathParagraph.toLatex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/#toLatex) aan. De methode retourneert een string die u kunt opslaan, weergeven, naar een andere toepassing kunt sturen of verder verwerken.

Het volgende voorbeeld doorloopt elk tekstvak op elke dia, zoekt alle wiskundige delen en schrijft elke formule naar een apart `.tex`‑bestand:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideutil/#getAllTextBoxes) retourneert alle tekstvakken die op een dia gevonden worden. De type‑check van [MathPortion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathportion/) scheidt echte bewerkbare formules van gewone tekst en afbeeldingen.

LaTeX‑engines en documenttemplates ondersteunen niet allemaal dezelfde commando’s, pakketten of Unicode‑tekens. Test de geretourneerde string met de LaTeX‑engine die door uw toepassing wordt gebruikt. Als een symbool of Office‑Math‑element geen geschikte weergave heeft in die omgeving, vervang het dan in de geretourneerde string door een projectspecifiek commando of sla de formule over en noteer het probleem voor later onderzoek.

## **Wiskundige vergelijkingen opslaan als MathML**

Hoewel ontwikkelaars gemakkelijk code kunnen schrijven voor sommige formuleformaten, zoals LaTeX, is MathML moeilijker handmatig te schrijven omdat het is ontworpen om automatisch door toepassingen te worden gegenereerd. Programma’s kunnen MathML eenvoudig lezen en parseren omdat het XML‑gebaseerd is, waardoor MathML vaak wordt gebruikt als uitvoer‑ en afdrukformaat in vele sectoren. 

Deze voorbeeldcode laat zien hoe u een wiskundige formule uit een presentatie exporteert naar MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Wat wordt precies geëxporteerd naar MathML—een alinea of een individuele formule‑blok?**

U kunt ofwel een volledige wiskunde‑alinea ([MathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/)) of een individueel blok ([MathBlock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathblock/)) naar MathML exporteren. Beide typen bieden een methode om naar MathML te schrijven.

**Hoe kan ik zien dat een object op een dia een wiskundige formule is en geen gewone tekst of afbeelding?**

Een formule bevindt zich in een [MathPortion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathportion/) en heeft een [MathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/). Afbeeldingen en gewone tekstonderdelen zonder een [MathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/) kunnen niet geëxporteerde formules zijn.

**Waar komt de MathML in een presentatie vandaan—is het specifiek voor PowerPoint of een standaard?**

De export richt zich op standaard MathML (XML). Aspose gebruikt Presentation MathML—het presentatiesubset van de standaard—dat breed wordt toegepast in verschillende toepassingen en op het web.

**Wordt het exporteren van formules binnen tabellen, SmartArt, groepen, enz. ondersteund?**

Ja, als die objecten tekstonderdelen bevatten met een [MathParagraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mathparagraph/) (dus echte PowerPoint‑formules), worden ze geëxporteerd. Als een formule als afbeelding is ingebed, wordt deze niet geëxporteerd.

**Wijzigt het exporteren naar MathML de originele presentatie?**

Nee. Het schrijven van MathML is een serialisatie van de inhoud van de formule; het wijzigt het presentaties‑bestand niet.