---
title: Správa uzlů tvarů SmartArt v prezentacích pomocí Pythonu
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/python-java/manage-smartart-shape-node/
keywords:
- Uzel SmartArt
- Poduzel
- Přidat uzel
- Pozice uzlu
- Přístup k uzlu
- Odstranit uzel
- Vlastní pozice
- Uzel asistenta
- Formát výplně
- Vykreslit uzel
- PowerPoint
- Prezentace
- Python
- Aspose.Slides
description: "Spravujte uzly tvarů SmartArt v PPT a PPTX pomocí Aspose.Slides pro Python via Java. Získejte přehledné ukázky kódu a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je uspořádána pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odebrat uzly, pracovat s poduzly podle indexu nebo pozice, změnit uzel asistenta na běžný uzel, upravit pozici, velikost a otočení tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vytvořit miniaturu obrázku pro poduzel SmartArt.

## **Přidat uzel SmartArt**
Aspose.Slides pro Python via Java poskytuje rozhraní API pro správu tvarů SmartArt. Následující příklad přidá uzel a poduzel do tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. [Přidejte nový uzel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#addNode) do [kolekce uzlů](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getAllNodes) tvaru SmartArt a nastavte jeho text pomocí [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
1. [Přidejte](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#addNode) [poduzel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#getChildNodes) k novému uzlu a nastavte jeho text pomocí [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat uzel SmartArt na konkrétní pozici**
Následující příklad přidá poduzel na konkrétní pozici v uzlu SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek podle jeho indexu.
1. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/) s rozložením [StackedList](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/#StackedList) na snímek.
1. Získejte první uzel v přidaném tvaru SmartArt.
1. Přidejte poduzel k vybranému uzlu na pozici 2 pomocí [addNodeByPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) a nastavte jeho text.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k uzlu SmartArt**
Následující příklad přistupuje k uzlům ve tvaru SmartArt. Rozložení vrácené metodou [getLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getLayout) je pouze ke čtení a je nastaveno při přidání tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. Procházejte všechny [uzly](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getAllNodes) ve tvaru SmartArt.
1. Přečtěte a zobrazte pozici, úroveň a text každého uzlu SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Přístup k poduzlu SmartArt**
Následující příklad přistupuje k poduzlům každého uzlu ve tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. Procházejte všechny [uzly](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getAllNodes) ve tvaru SmartArt.
1. Pro každý uzel procházejte jeho [child nodes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Přečtěte a zobrazte pozici, úroveň a text [child node](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
Následující příklad přistupuje k poduzlu na konkrétním indexu v kolekci jeho nadřazeného uzlu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek podle jeho indexu.
1. Přidejte tvar SmartArt s rozložením [StackedList](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/#StackedList).
1. Získejte přidaný tvar SmartArt.
1. Získejte uzel s indexem 0 v tvaru SmartArt.
1. Získejte poduzel s indexem 1 pomocí [get_Item](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. Přečtěte a zobrazte pozici, úroveň a text [child node](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Odebrat uzel SmartArt**
Následující příklad odebere uzel ze tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. Zkontrolujte, že tvar [SmartArt] obsahuje alespoň jeden uzel.
1. Vyberte uzel SmartArt, který má být smazán.
1. Odstraňte vybraný uzel pomocí [removeNode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odebrat uzel SmartArt z konkrétní pozice**
Následující příklad odebere poduzel na konkrétním indexu v kolekci uzlů SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. Získejte uzel SmartArt s indexem 0, pokud existuje.
1. Zkontrolujte, že vybraný uzel SmartArt má alespoň dva poduzly.
1. Odstraňte poduzel s indexem 1 pomocí [removeNode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavit vlastní pozici poduzlu v objektu SmartArt**
Aspose.Slides pro Python via Java podporuje nastavení pozice [SmartArtShape] pomocí [setX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setX) a [setY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setY). Následující příklad nastaví vlastní pozici, velikost a rotaci tvarů uzlů SmartArt. Přidání nových uzlů přepočítá pozice a velikosti všech uzlů. Vlastní umístění vám umožní uspořádat uzly podle potřeby.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zkontrolovat uzel asistenta**
{{% alert color="info" title="Note" %}} 

Tato část zkoumá tvary SmartArt přidané do snímků prezentace programově pomocí Aspose.Slides pro Python via Java.

{{% /alert %}} 

Následující zdrojový tvar SmartArt je v tomto příkladu použit.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape on a slide**|

Následující příklad identifikuje uzly asistenta v kolekci uzlů SmartArt a změní je na běžné uzly.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
1. Získejte první snímek podle jeho indexu.
1. Procházejte všechny tvary na prvním snímku.
1. Zkontrolujte, zda je tvar instance [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
1. Procházejte všechny uzly ve tvaru SmartArt a zkontrolujte, zda jsou [Assistant Nodes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartnode/#isAssistant).
1. Změňte každý uzel asistenta na běžný uzel.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant nodes changed in a SmartArt shape on a slide**|

## **Nastavit výplňový formát uzlu**
Aspose.Slides pro Python via Java umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňový formát. Tento článek vysvětluje, jak vytvořit a přistupovat k tvarům SmartArt a nastavit jejich výplň pomocí Aspose.Slides pro Python via Java.

Postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte snímek podle jeho indexu.
1. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/) s rozložením [ClosedChevronProcess](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).
1. Nastavte [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getFillFormat) pro uzly tvaru SmartArt.
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvořit miniaturu poduzlu SmartArt**
Pro vytvoření miniatury poduzlu SmartArt postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. [Přidejte tvar SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Získejte uzel podle jeho indexu.
1. Získejte obrázek miniatury.
1. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Je podpora animace SmartArt?**

Ano. SmartArt je považován za běžný tvar, takže můžete [použít standardní animace](/slides/cs/python-java/shape-animation/) (vstup, odchod, zvýraznění, pohybové cesty) a upravit načasování. V případě potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je interní ID neznámé?**

Přiřaďte a vyhledejte pomocí [alternativního textu](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText). Nastavení výrazného alternativního textu u SmartArt vám umožní najít jej programově, aniž byste se spolehli na interní identifikátory.

**Zůstane vzhled SmartArt zachován při konverzi prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální přesností během [exportu do PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), zachovávají se rozložení, barvy a efekty.

**Mohu extrahovat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete vykreslit tvar SmartArt do [rastrových formátů](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) nebo do [SVG](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#writeAsSvgToBytes) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo použití na webu.