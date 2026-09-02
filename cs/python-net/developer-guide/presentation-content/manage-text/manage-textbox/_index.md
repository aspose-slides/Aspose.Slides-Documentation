---
title: Správa textových polí v prezentacích pomocí Pythonu
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/python-net/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hypertextový odkaz
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Aspose.Slides pro Python prostřednictvím .NET usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zvyšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích se obvykle nacházejí v textových polích nebo tvarech. Proto musíte pro přidání textu na snímek nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides pro Python poskytuje třídu [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/), která umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}
Aspose.Slides také poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/). Nicméně ne všechny tvary mohou obsahovat text.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Proto, když pracujete s tvarem, ke kterému chcete přidat text, můžete chtít zkontrolovat a potvrdit, že byl přetypován pomocí třídy [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/). Teprve potom budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), který je vlastností třídy [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/). Viz sekce [Update Text](/slides/cs/python-net/manage-textbox/#update-text) na této stránce.
{{% /alert %}}

## **Vytvoření textových polí na snímcích**

Chcete-li vytvořit textové pole na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na první snímek.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s `ShapeType.RECTANGLE` na požadovanou pozici na snímku.
4. Nastavte text v [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) tvaru.
5. Uložte prezentaci jako soubor PPTX.

Následující příklad v Pythonu implementuje tyto kroky:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte první snímek v prezentaci.
    slide = presentation.slides[0]

    # Přidejte AutoShape typu RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Uložte prezentaci na disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrola, zda je tvar textovým polem**

Aspose.Slides poskytuje vlastnost [is_text_box](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/is_text_box/) na třídě [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/), která vám umožní zjistit, zda je tvar textovým polem.

![Textové pole a tvar](istextbox.png)

Tento příklad v Pythonu ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Všimněte si, že pokud přidáte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) pomocí třídy [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/), vrátí vlastnost `is_text_box` hodnotu `False`. Po přidání textu – buď metodou `add_text_frame`, nebo nastavením vlastnosti `text` – vrátí `is_text_box` hodnotu `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box je false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box je true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box je false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box je true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box je false
    shape3.add_text_frame("")
    # shape3.is_text_box je false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box je false
    shape4.text_frame.text = ""
    # shape4.is_text_box je false
```

## **Nalezení tvaru, který vlastní TextFrame**

V obecně použitelném kódu pro zpracování textu můžete obdržet objekt [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte vlastnost [TextFrame.parent_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_shape/) k navigaci zpět na vlastníka, tj. na [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).

Pro textový rámec, který patří k [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) nebo jinému tvaru obsahujícímu text, je `TextFrame.parent_shape` nastaven a `TextFrame.parent_cell` je `None`. Obě vlastnosti jsou jen pro čtení a neovlivňují vlastnictví. Vždy před přístupem k tvaru zkontrolujte, zda vrácená hodnota není `None`.

Kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulky, včetně tvarů spojených s uzly SmartArt, najdete v sekci [Search and Replace Text](/slides/cs/python-net/search-and-replace-text/).

## **Přidání sloupců do textových polí**

Aspose.Slides poskytuje vlastnosti [column_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_count/) a [column_spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/column_spacing/) ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců a nastavit mezery (v bodech) mezi sloupci.

Následující kód v Pythonu demonstruje tuto operaci:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Získejte první snímek v prezentaci.
	slide = presentation.slides[0]

	# Přidejte AutoShape typu RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Přidejte TextFrame k obdélníku.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Získejte formát textu TextFrame.
	format = shape.text_frame.text_frame_format

	# Zadejte počet sloupců v TextFrame.
	format.column_count = 3

	# Zadejte mezery mezi sloupci.
	format.column_spacing = 10

	# Uložte prezentaci.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizace textu**

Aspose.Slides vám umožní aktualizovat text v jednom textovém poli nebo v celé prezentaci.

Následující příklad v Pythonu ukazuje, jak aktualizovat celý text v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Uložte upravenou prezentaci.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání textových polí s hypertextovými odkazy**

Do textového pole můžete vložit odkaz. Po kliknutí na textové pole se odkaz otevře.

Chcete-li přidat textové pole obsahující hypertextový odkaz, postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na první snímek.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s `ShapeType.RECTANGLE` na požadovanou pozici na snímku.
4. Nastavte text v [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).
5. Získejte odkaz na třídu [HyperlinkManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkmanager/).
6. Pomocí vlastnosti `hyperlink_manager` nastavte externí hypertextový odkaz pro kliknutí.
7. Uložte prezentaci jako soubor PPTX.

Tento příklad v Pythonu ukazuje, jak přidat textové pole s hypertextovým odkazem na snímek:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte první snímek v prezentaci.
    slide = presentation.slides[0]

    # Přidejte AutoShape typu RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Přidejte text do rámce.
    text_portion.text = "Aspose.Slides"

    # Nastavte hypertextový odkaz pro text úseku.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s hlavními snímky?**

Zástupce ([placeholder](/slides/cs/python-net/manage-placeholder/)) dědí styl/umístění z [masteru](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) a může být přepsán v [layoutu](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a při změně rozvržení se nemění.

**Jak mohu provést hromadnou náhradu textu v prezentaci, aniž bych zasahoval do textu v diagramech, tabulkách a SmartArt?**

Omezte iteraci na auto-tvary, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/), [tabulky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/)) tím, že jejich kolekce projdete odděleně nebo tyto typy objektů přeskočíte.