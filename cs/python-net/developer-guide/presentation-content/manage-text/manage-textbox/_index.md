---
title: Správa textových polí v prezentacích pomocí Pythonu
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/python-net/manage-textbox/
keywords:
- textové pole
- textový rámeček
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte, identifikujte, formátujte a aktualizujte textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via .NET."
---
## **Úvod**

V Aspose.Slides pro Python via .NET je text snímku uložen v textových rámečcích, které patří k tvarům. Třída [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) představuje nejčastější tvar nesoucí text a zpřístupňuje svůj text prostřednictvím vlastnosti [AutoShape.text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Poznámka" %}}

Každý automatický tvar dědí z [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámeček. Při zpracování existující prezentace použijte `isinstance(shape, slides.AutoShape)`, abyste před přístupem k textu zkontrolovali typ tvaru.

{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole přidejte automatický tvar na snímek, vložte text do jeho textového rámečku a uložte prezentaci. Následující příklad vytvoří obdélníkové textové pole:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Souřadnice a rozměry předávané metodě [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_auto_shape/) jsou měřeny v bodech. [AutoShape.add_text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/add_text_frame/) inicializuje textový rámeček dodaným textem.

## **Kontrola, zda je tvar textovým polem**

Použijte vlastnost [AutoShape.is_text_box](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/is_text_box/) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak tvary nesoucí text, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad prozkoumá každý automatický tvar v prezentaci:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje neprázdný text. Text můžete dodat pomocí [AutoShape.add_text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/add_text_frame/) nebo [TextFrame.text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/text/). Přidání nebo přiřazení prázdného řetězce ponechává [is_text_box](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/is_text_box/) nastavený na `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

První dva volání vypíšou `True`; poslední dvě vypíšou `False`.

## **Najít tvar, který vlastní textový rámeček**

Obecný kód zpracovávající text může dostat [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) bez znalosti, který objekt prezentace jej obsahuje. Použijte jen‑čtenou vlastnost [TextFrame.parent_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_shape/) k navigaci zpět k vlastnímu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).

Pro textový rámeček vlastněný automatickým tvarem nebo jiným tvarem nesoucím text obsahuje [parent_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_shape/) vlastníka a [TextFrame.parent_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_cell/) je `None`. Zkontrolujte vrácenou hodnotu před přístupem. Pro identifikaci jak vlastníků tvarů, tak buněk tabulky, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/python-net/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Vlastnost [TextFrameFormat.column_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_count/) rozděluje textový rámeček na sloupce, zatímco [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_spacing/) nastavuje mezeru mezi sloupci v bodech. Obě nastavení jsou součástí [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) a lze je změnit přes textový rámeček existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

Následující příklad vytvoří textové pole se třemi sloupci a mezerou 10 bodů mezi sloupci, uloží prezentaci a načte uložená nastavení ze výstupního souboru:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extrahovat text z jednotlivých sloupců**

Použijte [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/split_text_by_columns/) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámečku. Metoda vrací jeden řetězec pro každý sloupec ve sloupcovém čtecím pořadí. Textový rámeček s jedním sloupcem vrací seznam s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují jen prostý text; formátování na úrovni částí není zachováno.

Toto je užitečné, když potřebujete:

- Extrahovat text při zachování sloupcově orientovaného pořadí čtení.
- Indexovat nebo porovnávat obsah snímků s více sloupci.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Zkontrolovat, jak je text přerozdělen po změně [TextFrameFormat.column_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_spacing/), písma nebo velikosti textového rámečku.

Metoda hlásí text rozložený v aktuálním [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/); automaticky nepřesune text mezi samostatné tvary nebo textová pole. Rozdělení sloupců může záviset na dostupných písmenech a dalších nastaveních rozvržení textu, takže se ujistěte, že požadovaná písma jsou k dispozici, pokud jsou konzistentní výsledky důležité.

Následující příklad načte prezentaci, najde první automatický tvar s více sloupci a textovým rámečkem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámeček, jsou přeskočeny.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Aktualizovat text**

Pro aktualizaci textu v celé prezentaci projděte snímky a tvary, vyberte automatické tvary a poté upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každé výskyty `years` výrazem `months` v textu automatických tvarů a učiní každou ovlivněnou část tučnou:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Tento průchod aktualizuje text jen v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje průchod jejich vlastních kolekcí.

## **Přidání textového pole s hyperodkazem**

Hyperodkaz lze přiřadit konkrétní textové části, takže jen tato část funguje jako klikací odkaz. Použijte [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) k přiřazení části k externí URL.

Následující příklad vytvoří propojený text a uloží jej do prezentace:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozložení snímku?**

[placeholder](/slides/cs/python-net/manage-placeholder/) může zdědit svou pozici a formátování z [master slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a nezíská chování zástupce při změně rozložení.

**Jak mohu nahradit text, aniž bych měnil text v grafech, tabulkách nebo SmartArt?**

Omezte průchod na instance [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/), jak je ukázáno v příkladu Aktualizovat text. Grafy, tabulky a SmartArt ukládají text ve svých vlastních objektových modelech, takže nejsou tímto cyklem upraveny.