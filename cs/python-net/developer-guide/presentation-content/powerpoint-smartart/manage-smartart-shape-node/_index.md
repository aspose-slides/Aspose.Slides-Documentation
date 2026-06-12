---
title: Správa uzlů tvaru SmartArt v prezentacích pomocí Pythonu
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/python-net/manage-smartart-shape-node/
keywords:
- uzel SmartArt
- poduzel
- přidat uzel
- pozice uzlu
- přístup k uzlu
- odstranit uzel
- vlastní pozice
- asistenční uzel
- výplňový formát
- vykreslovat uzel
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v PPT, PPTX a ODP pomocí Aspose.Slides pro Python přes .NET. Získejte jasné ukázky kódu a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je uspořádána pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vygenerovat miniaturu pro poduzel SmartArt.

## **Přidat uzel SmartArt**
Aspose.Slides pro Python prostřednictvím .NET poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Následující ukázkový kód pomůže přidat uzel a poduzel do tvaru SmartArt.

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Přidejte nový uzel do kolekce NodeCollection tvaru SmartArt a nastavte text v TextFrame.
- Nyní přidejte poduzel do nově přidaného uzlu SmartArt a nastavte text v TextFrame.
- Uložte prezentaci.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Projít všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:

        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Přidání nového uzlu SmartArt
            node1 = shape.all_nodes.add_node()
            # Přidání textu
            node1.text_frame.text = "Test"

            # Přidání nového poduzlu do nadřazeného uzlu. Bude přidán na konec kolekce
            new_node = node1.child_nodes.add_node()

            # Přidání textu
            new_node.text_frame.text = "New Node Added"

    # Ukládání prezentace
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidat uzel SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu jsme vysvětlili, jak přidat poduzly patřící k jednotlivým uzlům tvaru SmartArt na konkrétní pozici.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Přidejte SmartArt tvar typu StackedList do přístupného snímku.
- Získejte první uzel v přidaném tvaru SmartArt.
- Nyní přidejte poduzel pro vybraný uzel na pozici 2 a nastavte jeho text.
- Uložte prezentaci.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Vytvoření instance prezentace
with slides.Presentation() as pres:
    # Přístup k snímku prezentace
    slide = pres.slides[0]

    # Přidání Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Přístup k uzlu SmartArt s indexem 0
    node = smart.all_nodes[0]

    # Přidání nového poduzlu na pozici 2 do nadřazeného uzlu
    chNode = node.child_nodes.add_node_by_position(2)

    # Přidání textu
    chNode.text_frame.text = "Sample text Added"

    # Uložení prezentace
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k uzlu SmartArt**
Následující ukázkový kód pomůže přistoupit k uzlům uvnitř tvaru SmartArt. Všimněte si, že nemůžete změnit LayoutType SmartArt, protože je jen ke čtení a nastavuje se pouze při přidání tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Získejte a zobrazte informace jako pozice uzlu SmartArt, úroveň a text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Projít všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:
        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Projít všechny uzly uvnitř SmartArt
            for i in range(len(shape.all_nodes)):
                # Přístup k uzlu SmartArt s indexem i
                node = shape.all_nodes[i]

                # Tisk parametrů uzlu SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Přístup k poduzlu SmartArt**
Následující ukázkový kód pomůže přistoupit k poduzlům patřícím jednotlivým uzlům tvaru SmartArt.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArtEx.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Pro každý vybraný uzel tvaru SmartArt projděte všechny poduzly v konkrétním uzlu.
- Získejte a zobrazte informace jako pozice poduzlu, úroveň a text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Projít všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:
        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Projít všechny uzly uvnitř SmartArt
            for node0 in shape.all_nodes:
                # Procházet poduzly
                for j in range(len(node0.child_nodes)):
                    # Přístup k poduzlu v uzlu SmartArt
                    node = node0.child_nodes[j]

                    # Tisk parametrů poduzlu SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíme přistupovat k poduzlům na konkrétní pozici, které patří jednotlivým uzlům tvaru SmartArt.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Přidejte SmartArt tvar typu StackedList.
- Získejte přidaný tvar SmartArt.
- Získejte uzel s indexem 0 v přístupném tvaru SmartArt.
- Nyní pomocí metody GetNodeByPosition() přistupte k poduzlu na pozici 1 v přístupném uzlu SmartArt.
- Získejte a zobrazte informace jako pozice poduzlu, úroveň a text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Vytvoření instance prezentace
with slides.Presentation() as pres:
    # Přístup k prvnímu snímku
    slide = pres.slides[0]
    # Přidání tvaru SmartArt na první snímek
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Přístup k uzlu SmartArt s indexem 0
    node = smart.all_nodes[0]
    # Přístup k poduzlu na pozici 1 v nadřazeném uzlu
    position = 1
    chNode = node.child_nodes[position] 
    # Tisk parametrů poduzlu SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Odstranit uzel SmartArt**
V tomto příkladu se naučíme odstraňovat uzly uvnitř tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Zkontrolujte, zda SmartArt má více než 0 uzlů.
- Vyberte uzel SmartArt, který má být smazán.
- Nyní odstraňte vybraný uzel pomocí metody RemoveNode() a uložte prezentaci.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Projít všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:
        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Přetypovat tvar na SmartArtEx
            if len(shape.all_nodes) > 0:
                # Přístup k uzlu SmartArt s indexem 0
                node = shape.all_nodes[0]

                # Odstranění vybraného uzlu
                shape.all_nodes.remove_node(node)

    # uložit prezentaci
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit uzel SmartArt na konkrétní pozici**
V tomto příkladu se naučíme odstraňovat uzly uvnitř tvaru SmartArt na konkrétní pozici.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Vyberte uzel tvaru SmartArt s indexem 0.
- Nyní zkontrolujte, zda vybraný uzel SmartArt má více než 2 poduzly.
- Nyní odstraňte uzel na pozici 1 pomocí metody RemoveNodeByPosition().
- Uložte prezentaci.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Projít všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:
        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Přetypovat tvar na SmartArt
            if len(shape.all_nodes) > 0:
                # Přístup k uzlu SmartArt s indexem 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Odstranění poduzlu na pozici 1
                    node.child_nodes.remove_node(1)

    # uložit prezentaci
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit vlastní pozici pro poduzel v SmartArt**
Nyní Aspose.Slides pro Python prostřednictvím .NET podporuje nastavení vlastností X a Y tvaru SmartArtShape. Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a rotaci SmartArtShape; také upozorňujeme, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Načíst požadovanou prezentaci
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Přesunout tvar SmartArt na novou pozici
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Změnit šířky tvaru SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Změnit výšku tvaru SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Změnit rotaci tvaru SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Zkontrolovat asistenční uzel**
V následujícím ukázkovém kódu prozkoumáme, jak identifikovat asistenční uzly v kolekci uzlů SmartArt a jak je měnit.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na druhý snímek pomocí jeho indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArtEx.
- Projděte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou asistenčními uzly.
- Změňte stav asistenčního uzlu na normální uzel.
- Uložte prezentaci.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Vytvoření instance prezentace
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Procházet všechny tvary v prvním snímku
    for shape in pres.slides[0].shapes:
        # Zkontrolovat, zda je tvar typu SmartArt
        if type(shape) is art.SmartArt:
            # Procházet všechny uzly tvaru SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Zkontrolovat, zda je uzel asistenční
                if node.is_assistant:
                    # Nastavení asistenčního uzlu na false a převod na normální uzel
                    node.is_assistant = False
    # Uložit prezentaci
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit výplňový formát uzlu**
Aspose.Slides pro Python prostřednictvím .NET umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňové formáty. Tento článek vysvětluje, jak vytvářet a přistupovat k tvarům SmartArt a nastavit jejich výplňový formát pomocí Aspose.Slides pro Python prostřednictvím .NET.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte tvar SmartArt nastavením jeho LayoutType.
- Nastavte FillFormat pro uzly tvaru SmartArt.
- Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Přístup k snímku
    slide = presentation.slides[0]

    # Přidání tvaru SmartArt a uzlů
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Nastavení barvy výplně uzlu
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Uložit prezentaci
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vygenerovat miniaturu poduzlu SmartArt**
Vývojáři mohou vygenerovat miniaturu poduzlu SmartArt pomocí následujících kroků:

1. Vytvořte instanci třídy `Presentation`, která představuje soubor PPTX.
2. Přidejte SmartArt.
3. Získejte odkaz na uzel pomocí jeho indexu
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu.

Níže uvedený příklad generuje miniaturu poduzlu SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Vytvoření instance třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as presentation: 
    # Přidání SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Získání odkazu na uzel pomocí jeho indexu
    node = smart.nodes[1]

    # Získat miniaturu
    with node.shapes[0].get_image() as bmp:
        # uložit miniaturu
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **Často kladené otázky**

**Je podpora animace SmartArt?**

Ano. SmartArt je považován za běžný tvar, takže můžete [aplikovat standardní animace](/slides/cs/python-net/shape-animation/) (vstupní, výstupní, zdůrazňující, pohybové cesty) a upravit časování. Také můžete animovat tvary uvnitř uzlů SmartArt, pokud je to potřeba.

**Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho vnitřní ID neznámé?**

Přiřaďte a vyhledejte podle [alternativního textu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/alternative_text/). Nastavení výrazného AltTextu pro SmartArt vám umožní najít jej programově, aniž byste se spoléhali na interní identifikátory.

**Zůstane vzhled SmartArt zachován při konverzi prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy a efekty.

**Mohu extrahovat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete vykreslit tvar SmartArt do [rastrových formátů](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/get_image/) nebo do [SVG](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/write_as_svg/) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo webové použití.