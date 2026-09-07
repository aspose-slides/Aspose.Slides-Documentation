---
title: Převod PPT a PPTX na JPG v Pythonu
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/python-java/convert-powerpoint-to-jpg/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- PowerPoint na JPG
- PPT na JPG
- PPTX na JPG
- uložit snímek jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- Python
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) na obrázky JPG v Pythonu přes Java. Nastavte vlastní rozměry obrázku a vykreslete poznámky a komentáře pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides pro Python přes Java vám umožňuje převádět prezentace PowerPoint a OpenDocument (PPT, PPTX a ODP) na obrázky JPEG. Můžete exportovat každý snímek nebo vybraný snímek pro vytvoření náhledů, postavit prohlížeč prezentací nebo vložit náhledy snímků na webové stránky nebo do aplikace.

## **Převod PowerPoint PPT/PPTX na JPG**

1. Načtěte prezentaci pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte snímky pomocí [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides).
3. Vyvolejte [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s horizontálními a vertikálními faktory měřítka pro vykreslení každého snímku.
4. Uložte každý vykreslený obrázek jako JPEG pomocí [ImageFormat.Jpeg](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/#Jpeg), poté uvolněte zdroje obrázku.

{{% alert color="info" title="Poznámka" %}}
Export do formátu JPG vytvoří samostatný obrázek pro každý snímek. Uložte vykreslený obrázek, místo aby se prezentace ukládala přímo do formátu obrázku.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Převod PowerPoint PPT/PPTX na JPG s vlastním rozměrem**

Vypočítejte horizontální a vertikální faktory měřítka z požadovaných rozměrů v pixelech a původní velikosti snímku a poté je předáte metodě [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage). Následující příklad cílí na obrázek o rozměrech 1200 × 800 pro každý snímek.

Použití různých faktorů měřítka může snímek natáhnout. Pro zachování poměru stran použijte stejný faktor měřítka pro obě osy; výsledná šířka a výška pak budou odpovídat původnímu poměru snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Vykreslení komentářů při ukládání snímků jako obrázků**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) a aplikujte rozvržení pomocí [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Tento příklad umisťuje poznámky dolů, ořízne poznámky, které se nevejdou, a zobrazuje komentáře vpravo v oblasti široké 200 pixelů. Ukládá každý vykreslený snímek jako obrázek JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu převést více snímků nebo prezentací na JPG?**

Ano. Příklady procházejí všechny snímky a ukládají jeden JPG pro každý snímek. Pro zpracování více prezentací opakujte převod pro každý vstupní soubor a použijte samostatné výstupní složky nebo jedinečná názvy souborů, aby nedošlo k přepsání obrázků.

**Jsou v obrázcích zahrnuty grafy, SmartArt, tabulky a tvary?**

Tyto objekty jsou vykresleny jako součást snímku. Zajistěte, aby písma použité v prezentaci byla dostupná v převodním prostředí, aby se snížily rozdíly způsobené substitucí písma.

**Jak mohu snížit spotřebu paměti při exportu velkých prezentací?**

Zpracovávejte obrázky po jednom, po uložení uvolněte každý obrázek a vyhněte se zbytečně velkým výstupním rozměrům. Požadavky na paměť závisí na obsahu snímku a velikosti obrázku.

## **Viz také**

- [Převod PowerPoint na PNG](/slides/cs/python-java/convert-powerpoint-to-png/).
- [Vykreslit snímek jako SVG obrázek](/slides/cs/python-java/render-a-slide-as-an-svg-image/).