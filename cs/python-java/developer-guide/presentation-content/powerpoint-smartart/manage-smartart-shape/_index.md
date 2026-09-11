---
title: Správa grafiky SmartArt v prezentacích pomocí Pythonu
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/python-java/manage-smartart-shape/
keywords:
- objekt SmartArt
- grafika SmartArt
- styl SmartArt
- barva SmartArt
- vytvořit SmartArt
- přidat SmartArt
- upravit SmartArt
- změnit SmartArt
- přístup k SmartArt
- typ rozvržení SmartArt
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Automatizujte vytváření, úpravy a stylování SmartArt v PowerPointu v Pythonu pomocí Aspose.Slides, s přehlednými ukázkami kódu a radami zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt na snímek, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vzhled změnou stylu SmartArt nebo stylu barev.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo prohlédnout jeho vlastnosti.

## **Vytvoření tvaru SmartArt**
Aspose.Slides for Python via Java poskytuje rozhraní API pro vytváření tvarů SmartArt. Chcete-li vytvořit tvar SmartArt na snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte snímek podle jeho indexu.
3. [Přidejte tvar SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addSmartArt) zadáním [SmartArtLayoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartartlayouttype/).
4. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidat tvar SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Uložit prezentaci.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt přidaný na snímek**|

## **Přístup k tvaru SmartArt na snímku**
Následující příklad přistupuje k tvarům SmartArt na snímku prezentace. Prochází všechny tvary na snímku a kontroluje, zda je tvar instancí [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Projít všechny tvary na prvním snímku.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující příklad přistupuje k tvaru [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/) který má konkrétní typ rozvržení, vrácený metodou [SmartArt.getLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/#getLayout).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
2. Získejte první snímek podle jeho indexu.
3. Projděte všechny tvary na prvním snímku.
4. Zkontrolujte, zda je tvar instancí [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
5. Zkontrolujte, zda má tvar SmartArt zadaný typ rozvržení, a proveďte požadovanou operaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Projít všechny tvary na prvním snímku.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Zkontrolovat rozvržení SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Změna stylu tvaru SmartArt**
Tento příklad ukazuje, jak změnit rychlý styl tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
2. Získejte první snímek podle jeho indexu.
3. Projděte všechny tvary na prvním snímku.
4. Zkontrolujte, zda je tvar instancí [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
5. Najděte tvar SmartArt se zadaným stylem.
6. Nastavte nový styl pro tvar SmartArt.
7. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Projít všechny tvary na prvním snímku.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Zkontrolovat a změnit styl SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným stylem**|

## **Změna stylu barev tvaru SmartArt**
Tento příklad přistupuje k tvaru SmartArt s konkrétním stylem barev a mění tento styl.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující tvar SmartArt.
2. Získejte první snímek podle jeho indexu.
3. Projděte všechny tvary na prvním snímku.
4. Zkontrolujte, zda je tvar instancí [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/).
5. Najděte tvar SmartArt se zadaným stylem barev.
6. Nastavte nový styl barev pro tvar SmartArt.
7. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Projít všechny tvary na prvním snímku.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Zkontrolovat a změnit styl SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným stylem barev**|

## **FAQ**

**Mohu animovat SmartArt jako jediný objekt?**

Ano. SmartArt je tvar, takže můžete pomocí API animací použít [standardní animace](/slides/cs/python-java/powerpoint-animation/) (vstup, odchod, důraz, dráhy pohybu) stejně jako u ostatních tvarů.

**Jak mohu najít konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**

Nastavte a použijte [alternativní text](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setAlternativeText) a vyhledejte tvar podle této hodnoty - jedná se o doporučený způsob, jak najít cílový tvar.

**Mohu seskupit SmartArt s jinými tvary?**

Ano. Můžete seskupit SmartArt s jinými tvary (obrázky, tabulky atd.) a poté [manipulovat se skupinou](/slides/cs/python-java/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**

Exportujte miniaturu/obrázek tvaru; knihovna může [vykreslit jednotlivé tvary](/slides/cs/python-java/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při konverzi celé prezentace do PDF?**

Ano. Vykreslovací engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.