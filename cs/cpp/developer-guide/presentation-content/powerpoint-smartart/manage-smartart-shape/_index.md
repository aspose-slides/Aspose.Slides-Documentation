---
title: Spravovat grafiku SmartArt v prezentacích pomocí C++
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/cpp/manage-smartart-shape/
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
- C++
- Aspose.Slides
description: "Automatizujte tvorbu, úpravu a stylování SmartArt v PowerPointu v C++ pomocí Aspose.Slides, s stručnými ukázkami kódu a radami zaměřenými na výkon."
---
## **Přehled**

Aspose.Slides umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt do snímku, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vizuální vzhled změnou stylu SmartArt nebo barevného stylu.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo prozkoumat jeho vlastnosti.

## **Vytvořit tvar SmartArt**
Aspose.Slides pro C++ nyní usnadňuje přidání vlastních tvarů SmartArt do snímků od nuly. Aspose.Slides pro C++ poskytuje nejjednodušší API pro vytvoření tvarů SmartArt nejjednodušším způsobem. Pro vytvoření tvaru SmartArt ve snímku postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte tvar SmartArt nastavením jeho LayoutType.
- Uložte upravenou prezentaci jako soubor PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Přístup k tvaru SmartArt na snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme každý tvar uvnitř snímku a zkontrolujeme, zda se jedná o tvar SmartArt. Pokud je tvar typu SmartArt, převedeme jej na instanci SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Níže uvedený ukázkový kód pomůže získat tvar SmartArt s konkrétním LayoutType. Všimněte si, že LayoutType SmartArt nelze změnit, protože je jen ke čtení a nastavuje se pouze při přidání tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt a pokud ano, převedte vybraný tvar na SmartArt.
- Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované kroky.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Změna stylu tvaru SmartArt**
Níže uvedený ukázkový kód pomůže získat tvar SmartArt s konkrétním LayoutType.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt a pokud ano, převedte vybraný tvar na SmartArt.
- Najděte tvar SmartArt s konkrétním Style.
- Nastavte nový Style pro tvar SmartArt.
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Změna barevného stylu tvaru SmartArt**
V tomto příkladu se naučíme změnit barevný styl libovolného tvaru SmartArt. V následujícím ukázkovém kódu získáme tvar SmartArt s konkrétním barevným stylem a změníme jej.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci s tvarem SmartArt.
- Získejte odkaz na první snímek pomocí jeho indexu.
- Projděte každý tvar uvnitř prvního snímku.
- Zkontrolujte, zda je tvar typu SmartArt a pokud ano, převedte vybraný tvar na SmartArt.
- Najděte tvar SmartArt s konkrétním Color Style.
- Nastavte nový Color Style pro tvar SmartArt.
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Mohu animovat SmartArt jako jeden objekt?**

Ano. SmartArt je tvar, takže můžete pomocí API animací použít [standardní animace](/slides/cs/cpp/powerpoint-animation/) (vstup, výstup, zdůraznění, pohybové cesty) stejně jako u ostatních tvarů.

**Jak mohu najít konkrétní SmartArt na snímku, pokud neznám jeho interní ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty – to je doporučený způsob, jak najít požadovaný tvar.

**Mohu seskupit SmartArt s jinými tvary?**

Ano. Můžete seskupit SmartArt s jinými tvary (obrázky, tabulkami atd.) a poté [manipulovat skupinou](/slides/cs/cpp/group/).

**Jak získám obrázek konkrétního SmartArt (např. pro náhled nebo zprávu)?**

Exportujte náhled/obrázek tvaru; knihovna může [vykreslit jednotlivé tvary](/slides/cs/cpp/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Zůstane vzhled SmartArt zachován při převodu celé prezentace do PDF?**

Ano. Vykreslovací engine cílí na vysokou věrnost při [exportu do PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), s řadou možností ohledně kvality a kompatibility.