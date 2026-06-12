---
title: Správa grafiky SmartArt v prezentacích pomocí JavaScriptu
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/nodejs-java/manage-smartart-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizujte tvorbu, úpravu a stylizaci SmartArt v PowerPointu pomocí JavaScriptu a Aspose.Slides, s stručnými ukázkami kódu a radami zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak do snímku přidat tvar SmartArt, jak přistupovat k existujícím tvarům SmartArt, jak najít SmartArt podle konkrétního typu rozvržení a jak aktualizovat jeho vizuální vzhled změnou stylu SmartArt nebo stylu barev.

Příklady ukazují, jak pracovat s tvary SmartArt pomocí kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo prozkoumat jeho vlastnosti.

## **Vytvoření tvaru SmartArt**
Aspose.Slides pro Node.js via Java poskytuje rozhraní API pro vytváření tvarů SmartArt. Chcete-li vytvořit tvar SmartArt ve snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho Indexu.
3. [Přidejte tvar SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) nastavením jeho [LayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArtLayoutType).
4. Uložte upravenou prezentaci jako soubor PPTX.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získat první snímek
    var slide = pres.getSlides().get_Item(0);
    // Přidat tvar Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Uložit prezentaci
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt přidaný do snímku**|

## **Přístup k tvaru SmartArt ve snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme každý tvar uvnitř snímku a zkontrolujeme, zda je to tvar [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt). Pokud je tvar typu SmartArt, převedeme jej na instanci [**SmartArt**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).

```javascript
// Načtěte požadovanou prezentaci
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Procházejte každý tvar v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující ukázkový kód pomůže získat tvar [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) s konkrétním LayoutType. Všimněte si, že LayoutType SmartArt nelze změnit, protože je jen pro čtení a nastavuje se pouze při přidání tvaru [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho Indexu.
3. Projděte každý tvar uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) a pokud ano, přetypujte vybraný tvar na SmartArt.
5. Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované operace.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Procházejte každý tvar v prvním snímku
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArtEx
            var smart = shape;
            // Kontrola rozvržení SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit rychlý styl pro libovolný tvar SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho Indexu.
3. Projděte každý tvar uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) a pokud ano, přetypujte vybraný tvar na SmartArt.
5. Najděte tvar SmartArt s konkrétním Style.
6. Nastavte nový Style pro tvar SmartArt.
7. Uložte prezentaci.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Získat první snímek
    var slide = pres.getSlides().get_Item(0);
    // Procházet každý tvar v prvním snímku
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArtEx
            var smart = shape;
            // Kontrola stylu SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Změna stylu SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Ukládání prezentace
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným Style**|

## **Změna barevného stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit barevný styl pro libovolný tvar SmartArt. V následujícím ukázkovém kódu získáme tvar SmartArt s konkrétním barevným stylem a změníme jej.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho Indexu.
3. Projděte každý tvar uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SmartArt) a pokud ano, přetypujte vybraný tvar na SmartArt.
5. Najděte tvar SmartArt s konkrétním Color Style.
6. Nastavte nový Color Style pro tvar SmartArt.
7. Uložte prezentaci.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Získat první snímek
    var slide = pres.getSlides().get_Item(0);
    // Procházet každý tvar v prvním snímku
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Zkontrolujte, zda je tvar typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Přetypujte tvar na SmartArtEx
            var smart = shape;
            // Kontrola typu barvy SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Změna typu barvy SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Ukládání prezentace
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným Color Style**|

## **FAQ**

**Mohu animovat SmartArt jako jeden objekt?**

Ano. SmartArt je tvar, takže můžete pomocí API pro animace aplikovat [standardní animace](/slides/cs/nodejs-java/powerpoint-animation/) (vstupní, výstupní, důrazové, trajektorie pohybu) stejně jako u ostatních tvarů.

**Jak mohu najít konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty — toto je doporučený způsob, jak najít cílový tvar.

**Mohu seskupit SmartArt s jinými tvary?**

Ano. Můžete seskupit SmartArt s jinými tvary (obrázky, tabulky atd.) a poté [manipulovat skupinou](/slides/cs/nodejs-java/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**

Exportujte miniaturu/obrázek tvaru; knihovna dokáže [vyrenderovat jednotlivé tvary](/slides/cs/nodejs-java/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při převodu celé prezentace do PDF?**

Ano. Vykreslovací engine usiluje o vysokou věrnost při [exportu do PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.