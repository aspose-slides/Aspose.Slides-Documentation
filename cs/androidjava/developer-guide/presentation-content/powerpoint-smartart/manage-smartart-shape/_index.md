---
title: Správa grafiky SmartArt v prezentacích na Androidu
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/androidjava/manage-smartart-shape/
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
- Android
- Java
- Aspose.Slides
description: "Automatizujte vytváření, úpravy a stylování SmartArt v PowerPointu pomocí Aspose.Slides pro Android, s přehlednými příklady kódu v jazyce Java a návody zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt do snímku, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vzhled změnou stylu SmartArt nebo barevného stylu.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo prozkoumat jeho vlastnosti.

## **Vytvoření tvaru SmartArt**
Aspose.Slides for Android via Java poskytuje rozhraní API pro vytváření tvarů SmartArt. Chcete-li vytvořit tvar SmartArt v snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. [Přidejte tvar SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) nastavením [LayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation();
try {
    // Získání prvního snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidání tvaru Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Ukládání prezentace
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt přidaný do snímku**|

## **Přístup k tvaru SmartArt na snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme každý tvar uvnitř snímku a zkontrolujeme, zda se jedná o tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt). Pokud je tvar typu SmartArt, přetypujeme jej na instanci [**SmartArt**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt).

```java
// Načtení požadované prezentace
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Procházení každého tvaru v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kontrola, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt)
        {
            // Přetypování tvaru na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující ukázkový kód pomůže získat tvar [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt) s konkrétním LayoutType. Upozorňujeme, že LayoutType SmartArt nelze měnit, je pouze pro čtení a je nastaven při přidání tvaru [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt), a přetypujte vybraný tvar na SmartArt, pokud je to SmartArt.
1. Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované operace.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Procházet všechny tvary v prvním snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt)
        {
            // Přetypovat tvar na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kontrola rozvržení SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit rychlý styl libovolného tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt), a přetypujte vybraný tvar na SmartArt, pokud je to SmartArt.
1. Najděte tvar SmartArt s konkrétním Style.
1. Nastavte nový Style pro tvar SmartArt.
1. Uložte prezentaci.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Získání prvního snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet všechny tvary v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kontrola stylu SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Změna stylu SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Ukládání prezentace
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným stylem**|

## **Změna barevného stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit barevný styl libovolného tvaru SmartArt. V následujícím vzorovém kódu získáme tvar SmartArt s konkrétním barevným stylem a změníme jeho styl.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArt), a přetypujte vybraný tvar na SmartArt, pokud je to SmartArt.
1. Najděte tvar SmartArt s konkrétním Color Style.
1. Nastavte nový Color Style pro tvar SmartArt.
1. Uložte prezentaci.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Získání prvního snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet všechny tvary v prvním snímku
    for (IShape shape : slide.getShapes()) 
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Přetypovat tvar na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kontrola typu barvy SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Změna typu barvy SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Ukládání prezentace
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Obrázek: Tvar SmartArt se změněným barevným stylem**|

## **Často kladené otázky**

**Mohu animovat SmartArt jako jediný objekt?**

Ano. SmartArt je tvar, takže můžete použít [standardní animace](/slides/cs/androidjava/powerpoint-animation/) prostřednictvím API animací (vstup, výstup, důraz, pohybové cesty) stejně jako u ostatních tvarů.

**Jak najdu konkrétní SmartArt na snímku, pokud neznám jeho vnitřní ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty — jedná se o doporučený způsob, jak najít cílový tvar.

**Mohu seskupit SmartArt s jinými tvary?**

Ano. Můžete seskupit SmartArt s dalšími tvary (obrázky, tabulkami apod.) a poté [manipulovat se skupinou](/slides/cs/androidjava/group/).

**Jak získám obrázek konkrétního SmartArt (například pro náhled nebo zprávu)?**

Exportujte miniaturu/obrázek tvaru; knihovna může [vyrenderovat jednotlivé tvary](/slides/cs/androidjava/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při konverzi celé prezentace do PDF?**

Ano. Vykreslovací engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.