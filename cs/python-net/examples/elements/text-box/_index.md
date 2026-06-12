---
title: Textové pole
type: docs
weight: 40
url: /cs/python-net/examples/elements/text-box/
keywords:
- textové pole
- přidat textové pole
- přistupovat k textovému poli
- odstranit textové pole
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a formátujte textová pole v Pythonu pomocí Aspose.Slides: nastavte písma, zarovnání, zalamování, automatické přizpůsobení a odkazy pro vylepšení snímků v PowerPointu a OpenDocumentu."
---
V Aspose.Slides je **textové pole** reprezentováno pomocí `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani ohraničení a zobrazuje pouze text.

Tento průvodce vysvětluje, jak programově přidávat, přistupovat k a odstraňovat textová pole.

## **Přidání textového pole**

Textové pole je jednoduše `AutoShape` bez výplně nebo ohraničení a s nějakým formátovaným textem. Zde je, jak jedno vytvořit:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Vytvořte obdélníkový tvar (ve výchozím nastavení vyplněný okrajem a bez textu).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Odstraňte výplň a okraj, aby to vypadalo jako typické textové pole.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Nastavte formátování textu.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Přiřaďte skutečný textový obsah.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Poznámka:** Každý `AutoShape`, který obsahuje neprázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovým polím podle obsahu**

Chcete‑li najít všechna textová pole obsahující konkrétní klíčové slovo (např. „Slide“), projděte tvary a zkontrolujte jejich text:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Pouze AutoShape mohou obsahovat editovatelný text.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Proveďte něco s odpovídajícím textovým polem.
                    pass
```

## **Odstranění textových polí podle obsahu**

Tento příklad vyhledá a smaže všechna textová pole na první snímku, která obsahují konkrétní klíčové slovo:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Najděte tvary k odstranění, které jsou AutoShape a obsahují slovo "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Odstraňte každý odpovídající tvar ze snímku.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Při iteraci vždy vytvořte kopii kolekce tvarů, než ji během iterace upravíte, abyste se vyhnuli chybám při změně kolekce.