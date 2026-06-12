---
title: Správa grafiky SmartArt v prezentacích pomocí Javy
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/java/manage-smartart-shape/
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
- Prezentace
- Java
- Aspose.Slides
description: "Automatizujte tvorbu, editaci a stylování SmartArt v PowerPointu v Javě pomocí Aspose.Slides, včetně stručných ukázek kódu a návodů zaměřených na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt na snímek, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vizuální vzhled změnou stylu SmartArt nebo stylu barev.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo prozkoumat jeho vlastnosti.

## **Vytvoření tvaru SmartArt**
Aspose.Slides for Java poskytuje API pro vytváření tvarů SmartArt. Chcete-li vytvořit tvar SmartArt na snímku, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. [Přidejte tvar SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) nastavením [LayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType).
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořit instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidat tvar SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Ukládání prezentace
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek:** Tvar SmartArt přidaný na snímek|

## **Přístup k tvaru SmartArt na snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme každý tvar uvnitř snímku a zkontrolujeme, zda se jedná o tvar [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt). Pokud je tvar typu SmartArt, převedeme jej na instanci [**SmartArt**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt).

```java
// Načíst požadovanou prezentaci
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Procházet každý tvar uvnitř prvního snímku
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Zkontrolovat, zda je tvar typu SmartArt
        if (shape instanceof ISmartArt)
        {
            // Přetypovat tvar na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující ukázkový kód pomůže získat tvar [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt) s konkrétním LayoutType. Všimněte si, že LayoutType SmartArt nelze měnit, protože je pouze pro čtení a je nastaven pouze při přidání tvaru [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArt).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt] a pokud ano, přetypujte vybraný tvar na SmartArt.
1. Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované operace.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Procházet každý tvar uvnitř prvního snímku
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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt] a pokud ano, přetypujte vybraný tvar na SmartArt.
1. Najděte tvar SmartArt s konkrétním Style.
1. Nastavte nový Style pro tvar SmartArt.
1. Uložte prezentaci.

```java
// Vytvořit instanci třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet každý tvar uvnitř prvního snímku
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
|**Obrázek:** Tvar SmartArt se změněným Style**|

## **Změna barevného stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit barevný styl libovolného tvaru SmartArt. V následujícím ukázkovém kódu získáme tvar SmartArt s konkrétním barevným stylem a změníme jej.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte referenci na první snímek pomocí jeho indexu.
1. Projděte každý tvar uvnitř prvního snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt] a pokud ano, přetypujte vybraný tvar na SmartArt.
1. Najděte tvar SmartArt s konkrétním Color Style.
1. Nastavte nový Color Style pro tvar SmartArt.
1. Uložte prezentaci.

```java
// Vytvořit instanci třídy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Získat první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Procházet každý tvar uvnitř prvního snímku
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
|**Obrázek:** Tvar SmartArt se změněným Color Style**|

## **Často kladené otázky**

**Mohu animovat SmartArt jako jeden objekt?**

Ano. SmartArt je tvar, takže můžete pomocí API pro animace aplikovat [standardní animace](/slides/cs/java/powerpoint-animation/) (vstup, výstup, zdůraznění, pohybové cesty) stejně jako u ostatních tvarů.

**Jak mohu najít konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty – to je doporučený způsob, jak najít cílový tvar.

**Mohu seskupit SmartArt s ostatními tvary?**

Ano. Můžete seskupit SmartArt s ostatními tvary (obrázky, tabulkami atd.) a poté [manipulovat skupinou](/slides/cs/java/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**

Exportujte miniaturu/obrázek tvaru; knihovna dokáže [vykreslit jednotlivé tvary](/slides/cs/java/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při převodu celé prezentace do PDF?**

Ano. Rendering engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/java/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.