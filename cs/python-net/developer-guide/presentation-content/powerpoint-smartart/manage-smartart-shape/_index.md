---
title: Správa grafiky SmartArt v prezentacích pomocí Pythonu
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/python-net/manage-smartart-shape/
keywords:
- Objekt SmartArt
- Grafika SmartArt
- Styl SmartArt
- Barva SmartArt
- Vytvořit SmartArt
- Přidat SmartArt
- Upravit SmartArt
- Změnit SmartArt
- Přístup k SmartArt
- Typ rozvržení SmartArt
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Automatizujte vytváření, úpravu a stylování SmartArt v PowerPointu v Pythonu pomocí .NET a Aspose.Slides, s stručnými ukázkami kódu a radami zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt na snímek, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vizuální vzhled změnou stylu SmartArt nebo barevného stylu.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zjistit, zda je tvar SmartArt, a poté upravit nebo prozkoumat jeho vlastnosti.

## **Vytvoření tvarů SmartArt**

Aspose.Slides pro Python pomocí .NET vám umožňuje přidávat vlastní tvary SmartArt na snímky od začátku. API to usnadňuje. Jak přidat tvar SmartArt na snímek:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte cílový snímek podle jeho indexu.
3. Přidejte tvar SmartArt a určete jeho typ rozvržení.
4. Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Přístup k snímku prezentace.
    slide = presentation.slides[0]
    # Přidání tvaru SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Uložení prezentace na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k tvarům SmartArt na snímcích**

Následující kód ukazuje, jak přistupovat k tvarům SmartArt na snímku. Vzorek prochází každý tvar na snímku a kontroluje, zda se jedná o objekt [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Načíst soubor prezentace.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Projít každý tvar na prvním snímku.
    for shape in presentation.slides[0].shapes:
        # Zkontrolovat, zda je tvar tvarem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Vytisknout název tvaru.
            print("Shape name:", shape.name)
```

## **Přístup k tvarům SmartArt se zadaným typem rozvržení**

Následující příklad ukazuje, jak přistupovat k tvaru SmartArt se zadaným typem rozvržení. Všimněte si, že typ rozvržení SmartArt nelze změnit – je jen pro čtení a je nastaven při vytvoření tvaru.

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje tvar SmartArt.
2. Získejte odkaz na první snímek podle indexu.
3. Projděte každý tvar na prvním snímku.
4. Zkontrolujte, zda je tvar objekt [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/).
5. Pokud typ rozvržení tvaru SmartArt odpovídá požadovanému, proveďte potřebné akce.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Projít každý tvar na prvním snímku.
    for shape in presentation.slides[0].shapes:
        # Zkontrolovat, zda je tvar tvarem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Zkontrolovat typ rozvržení SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Změna stylu tvaru SmartArt**

Následující příklad ukazuje, jak najít tvary SmartArt a změnit jejich styl:

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte soubor, který obsahuje tvar(y) SmartArt.
2. Získejte odkaz na první snímek podle indexu.
3. Projděte každý tvar na prvním snímku.
4. Nalezněte tvar SmartArt se zadaným stylem.
5. Přiřaďte nový styl tvaru SmartArt.
6. Uložte prezentaci.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Projít každý tvar na prvním snímku.
    for shape in presentation.slides[0].shapes:
        # Zkontrolovat, zda je tvar tvarem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Zkontrolovat styl SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Změnit styl SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Uložit prezentaci.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Změna barevného stylu tvarů SmartArt**

Tento příklad ukazuje, jak změnit barevný styl tvaru SmartArt. Vzorek kódu najde tvar SmartArt se zadaným barevným stylem a aktualizuje jej.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje tvar(y) SmartArt.
2. Získejte odkaz na první snímek podle indexu.
3. Projděte každý tvar na prvním snímku.
4. Zkontrolujte, zda je tvar objektem [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/).
5. Najděte tvar SmartArt se zadaným barevným stylem.
6. Nastavte nový barevný styl pro tento tvar SmartArt.
7. Uložte prezentaci.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Projít každý tvar na prvním snímku.
    for shape in presentation.slides[0].shapes:
        # Zkontrolovat, zda je tvar tvarem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Zkontrolovat typ barvy.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Změnit typ barvy.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Uložit prezentaci.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu animovat SmartArt jako jeden objekt?**

Ano. SmartArt je tvar, takže můžete pomocí API animací použít [standardní animace](/slides/cs/python-net/powerpoint-animation/) (vstup, výstup, zdůraznění, dráhy pohybu) stejně jako u ostatních tvarů.

**Jak najdu konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty – je to doporučený způsob, jak najít požadovaný tvar.

**Mohu seskupit SmartArt s ostatními tvary?**

Ano. Můžete seskupit SmartArt s ostatními tvary (obrázky, tabulky atd.) a poté [manipulovat se skupinou](/slides/cs/python-net/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**

Exportujte miniaturu/obrázek tvaru; knihovna může [vykreslit jednotlivé tvary](/slides/cs/python-net/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při převodu celé prezentace do PDF?**

Ano. Vykreslovací engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.