---
title: Spravujte grafiku SmartArt v prezentacích v .NET
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/net/manage-smartart-shape/
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
- .NET
- C#
- Aspose.Slides
description: "Automatizujte tvorbu, úpravy a stylizaci SmartArt v PowerPointu v .NET pomocí Aspose.Slides, s přehlednými ukázkami kódu a radami zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Článek vysvětluje, jak přidat tvar SmartArt do snímku, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vizuální vzhled změnou stylu SmartArt nebo barevného stylu.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a následně upravit nebo zkontrolovat jeho vlastnosti.

## **Vytvořit tvar SmartArt**
Aspose.Slides pro .NET nyní usnadňuje přidávat vlastní tvary SmartArt do svých snímků od nuly. Aspose.Slides pro .NET poskytl nejjednodušší API pro vytváření tvarů SmartArt nejjednodušším způsobem. Chcete-li vytvořit tvar SmartArt ve snímku, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte tvar SmartArt nastavením jeho LayoutType.
- Uložte upravenou prezentaci jako soubor PPTX.

```c#
 // Vytvořte instanci prezentace
 using (Presentation pres = new Presentation())
 {
 
     // Přístup k snímku prezentace
     ISlide slide = pres.Slides[0];
 
     // Přidat tvar SmartArt
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // Ukládání prezentace
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Přístup k tvaru SmartArt na snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme každý tvar uvnitř snímku a zkontrolujeme, zda se jedná o tvar SmartArt. Pokud je tvar typu SmartArt, převedeme jej na instanci SmartArt.

```c#
 // Načtěte požadovanou prezentaci
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // Procházejte každý tvar v prvním snímku
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Zkontrolujte, zda je tvar typu SmartArt
         if (shape is ISmartArt)
         {
             // Přetypujte tvar na SmartArtEx
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující ukázkový kód pomůže přistupovat k tvaru SmartArt s konkrétním LayoutType. Všimněte si, že LayoutType SmartArt nelze změnit, protože je pouze pro čtení a je nastaven pouze při přidání tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte referenci na první snímek pomocí jeho Indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované operace.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Procházet každý tvar v prvním snímku
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape is ISmartArt)
        {
            // Přetypujte tvar na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kontrola rozvržení SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Změnit styl tvaru SmartArt**
Následující ukázkový kód pomůže přistupovat k tvaru SmartArt s konkrétním LayoutType.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte referenci na první snímek pomocí jeho Indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Najděte tvar SmartArt s konkrétním Style.
- Nastavte nový Style pro tvar SmartArt.
- Uložte prezentaci.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Procházet každý tvar v prvním snímku
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape is ISmartArt)
        {
            // Přetypujte tvar na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kontrola stylu SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Změna stylu SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Ukládání prezentace
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Změnit barevný styl tvaru SmartArt**
V tomto příkladu se naučíme měnit barevný styl libovolného tvaru SmartArt. V následujícím ukázkovém kódu přistoupíme k tvaru SmartArt s konkrétním barevným stylem a změníme jej.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte referenci na první snímek pomocí jeho Indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a pokud ano, přetypujte vybraný tvar na SmartArt.
- Najděte tvar SmartArt s konkrétním Color Style.
- Nastavte nový Color Style pro tvar SmartArt.
- Uložte prezentaci.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Procházet každý tvar v prvním snímku
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Zkontrolujte, zda je tvar typu SmartArt
        if (shape is ISmartArt)
        {
            // Přetypujte tvar na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kontrola typu barvy SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Změna typu barvy SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Ukládání prezentace
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu animovat SmartArt jako jediný objekt?**  
Ano. SmartArt je tvar, takže můžete pomocí animačního API použít [standardní animace](/slides/cs/net/powerpoint-animation/) (vstup, výstup, zdůraznění, trajektorie pohybu) stejně jako u ostatních tvarů.

**Jak mohu najít konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**  
Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty – je to doporučený způsob, jak najít cílový tvar.

**Mohu seskupit SmartArt s jinými tvary?**  
Ano. Můžete seskupit SmartArt s jinými tvary (obrázky, tabulky atd.) a poté [manipulovat se skupinou](/slides/cs/net/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**  
Exportujte náhled/obrázek tvaru; knihovna může [vykreslit jednotlivé tvary](/slides/cs/net/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při konverzi celé prezentace do PDF?**  
Ano. Vykreslovací engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/net/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.