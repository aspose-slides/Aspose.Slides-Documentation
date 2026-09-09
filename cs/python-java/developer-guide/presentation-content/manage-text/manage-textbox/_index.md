---
title: Správa textových polí v prezentacích pomocí Pythonu přes Java
linktitle: Spravovat textové pole
type: docs
weight: 20
url: /cs/python-java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořit, identifikovat, formátovat a aktualizovat textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java."
---
## **Úvod**

V Aspose.Slides pro Python přes Java je text snímku uložen v textových rámech, které patří k tvarům. Třída [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) představuje nejběžnější tvar nesoucí text a zpřístupňuje svůj text prostřednictvím metody [AutoShape.getTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Každý automatický tvar dědí z [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracování existující prezentace zkontrolujte, že tvar je instancí [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) před přístupem k jeho textu.
{{% /alert %}}

## **Vytvořit textové pole na snímku**

Chcete‑li vytvořit textové pole, přidejte automatický tvar na snímek, vložte text do jeho textového rámce a uložte prezentaci. Následující příklad vytvoří obdélníkové textové pole:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Souřadnice a rozměry předávané metodě [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) jsou měřeny v bodech. [AutoShape.addTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#addTextFrame) inicializuje textový rámec dodaným textem.

## **Zkontrolovat, zda jde o tvar textového pole**

Použijte metodu [AutoShape.isTextBox](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#isTextBox) k určení, zda je automatický tvar považován za textové pole. Toto je užitečné, když prezentace obsahuje jak textové, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad prozkoumá každý automatický tvar v prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje neprázdný text. Text můžete dodat pomocí [AutoShape.addTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#addTextFrame) nebo [TextFrame.setText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#setText). Přidání nebo přiřazení prázdného řetězce ponechá metodu [AutoShape.isTextBox](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#isTextBox) vracející `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

První dvě volání vytisknou `True`; poslední dvě vytisknou `False`.

## **Najít tvar, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) bez toho, aby věděl, který objekt prezentace jej obsahuje. Použijte jen‑read‑only metodu [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentShape) k navigaci zpět k jeho vlastnímu [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/).

U textového rámce vlastněného automatickým tvarem nebo jiným tvarem nesoucím text metoda [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentShape) vrací vlastníka a [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentCell) vrací `None`. Před přístupem zkontrolujte vrácenou hodnotu. Pro identifikaci vlastníků jak tvaru, tak buňky tabulky, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/python-java/search-and-replace-text/).

## **Přidat sloupce do textového pole**

Metoda [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setColumnCount) rozdělí textový rámec do sloupců, zatímco [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setColumnSpacing) nastaví mezery mezi sloupci v bodech. Obě nastavení patří do [TextFrameFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/) a lze je měnit prostřednictvím textového rámce existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepokračuje do jiného tvaru.

Následující příklad vytvoří třísloupcové textové pole s 10 body mezi sloupci, uloží prezentaci a načte uložená nastavení ze souboru výstupu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Extrahovat text z jednotlivých sloupců**

Použijte [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#splitTextByColumns) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec ve sloupcovém pořadí čtení. Textový rámec s jedním sloupcem vytvoří pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze čistý text; formátování na úrovni částí není zachováno.

To je užitečné, když potřebujete:

- Extrahovat text při zachování jeho sloupcového pořadí čtení.
- Indexovat nebo porovnat obsah snímků s více sloupci.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Prozkoumat, jak je text přerozdělen po změně počtu sloupců pomocí [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setColumnCount), mezery pomocí [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setColumnSpacing), písma nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/); automaticky neprovádí tok textu mezi oddělenými tvary nebo textovými poli. Rozdělení sloupců může záviset na dostupných písmech a dalších nastaveních rozvržení textu, proto se ujistěte, že požadovaná písma jsou k dispozici, když jsou důsledné výsledky podstatné.

Následující příklad načte prezentaci, najde první automatický tvar s více sloupci a textovým rámcem, načte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Aktualizovat text**

Chcete‑li aktualizovat text napříč prezentací, projděte snímky a tvary, vyberte automatické tvary a poté upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak znakové formátování.

Následující příklad nahradí každé výskyt `years` řetězcem `months` v textu automatických tvarů a každou ovlivněnou část nastaví tučným písmem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Toto procházení aktualizuje text pouze v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje procházení kolekcí těchto objektů.

## **Přidat textové pole s hyperodkazem**

Hyperodkaz lze přiřadit konkrétní textové části, takže pouze tento text funguje jako klikací odkaz. Použijte [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) k přiřazení části k externímu URL.

Následující příklad vytvoří propojený text a uloží jej do prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a zástupcem textu na snímku šablony nebo rozvržení?**

[Placeholder](/slides/cs/python-java/manage-placeholder/) může dědit svou polohu a formátování ze [master slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a nezískává chování zástupce při změně rozvržení.

**Jak mohu nahradit text, aniž bych změnil text v grafech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které jsou instancemi [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/), jak je ukázáno v příkladu Aktualizovat text. Grafy, tabulky a SmartArt ukládají text ve svých vlastních modelových objektech, takže nejsou touto smyčkou upraveny.