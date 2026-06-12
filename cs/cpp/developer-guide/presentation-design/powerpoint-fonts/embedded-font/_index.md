---
title: Vkládání písem do prezentací pomocí С++
linktitle: Vkládání písma
type: docs
weight: 40
url: /cs/cpp/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písem
- získat vložené písmo
- přidat vložené písmo
- odebrat vložené písmo
- komprimovat vložené písmo
- PowerPoint
- OpenDocument
- prezentace
- С++
- Aspose.Slides
description: "Vložte TrueType písma do PowerPoint a OpenDocument prezentací pomocí Aspose.Slides pro С++, což zajišťuje přesné vykreslování na všech platformách."
---
## **Úvod**

Vložená písma v PowerPointu pomáhají zajistit, že vaše prezentace si zachová požadovaný vzhled při otevření na jakémkoli systému nebo zařízení. To je zvláště důležité při použití vlastních, třetích stran nebo nestandardních písem pro branding nebo kreativní účely. Bez vložených písem může být text nahrazen, rozvržení se může rozpadnout a znaky se mohou zobrazit jako nečitelné symboly nebo obdélníky, což ohrožuje celkový design.

Aspose.Slides pro C++ poskytuje sadu výkonných API pro programovou správu vložených písem. Můžete použít třídy FontsManager a FontData k prohlížení, přidání nebo odebrání vložených písem ve vašich souborech prezentací. Navíc třída Compress vám umožní optimalizovat velikost souboru kompresí dat písem, aniž by to ovlivnilo kvalitu nebo vzhled.

Tyto nástroje vám poskytují plnou kontrolu nad vkládáním písem, pomáhají udržet konzistentní typografii napříč platformami a při tom snižovat velikost souboru podle potřeby.

## **Získání vložených písem z prezentace**

Aspose.Slides pro C++ poskytuje metodu GetEmbeddedFonts prostřednictvím třídy FontsManager, která vám umožní získat seznam písem vložených v PowerPoint prezentaci. To může být užitečné pro audit použití písem, zajištění souladu s brandingovými zásadami nebo ověření, že všechna potřebná písma jsou před sdílením souboru řádně zahrnuta.

Následující kód v C++ ukazuje, jak získat vložená písma z souboru prezentace:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Získejte všechna vložená písma.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Vytiskněte názvy vložených písem.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Přidání vložených písem do prezentace**

Aspose.Slides pro C++ vám umožňuje vložit písma do PowerPoint prezentace pomocí metody AddEmbeddedFont, která má dva přetížení pro flexibilní použití. Množství vloženého písma můžete řídit pomocí výčtu EmbedFontCharacters — například výběrem vložení pouze použitých znaků nebo celého souboru písem. Tato funkce je zvláště užitečná při přípravě prezentace ke sdílení nebo distribuci, zajišťuje, že vlastní nebo nestandardní písma se zobrazí správně na všech systémech, i když tato písma nejsou nainstalována.

Následující kód v C++ kontroluje všechna písma použitá v prezentaci a vloží všechna písma, která ještě nejsou vložena.

```cpp
// Načtěte soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Zkontrolujte, zda je písmo již vloženo.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Vložte písmo do prezentace.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Uložte prezentaci na disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Odstranění vložených písem z prezentace**

Aspose.Slides pro C++ poskytuje metodu RemoveEmbeddedFont prostřednictvím třídy FontsManager, která vám umožní odstranit konkrétní písma vložená v PowerPoint prezentaci. To může pomoci snížit celkovou velikost souboru, zejména pokud vložená písma již nejsou používána nebo nejsou potřeba. Odstranění nepoužívaných písem může také zlepšit výkon a zajistit, že vaše prezentace obsahuje pouze nezbytné zdroje.

Následující kód v C++ ukazuje, jak odebrat vložené písmo z prezentace:

```cpp
auto fontName = u"Calibri";

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Získejte všechna vložená písma.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Odstraňte vložené písmo.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Komprese vložených písem**

Aspose.Slides pro C++ poskytuje metodu CompressEmbeddedFonts prostřednictvím třídy Compress, která vám umožní snížit celkovou velikost souboru prezentace optimalizací dat vložených písem. To je zvláště užitečné, když vaše prezentace obsahuje velká nebo více písem, a chcete udržet soubor lehký pro sdílení, ukládání nebo online použití — aniž byste ohrozili vizuální věrnost obsahu.

Následující kód v C++ ukazuje, jak komprimovat vložená písma v PowerPoint prezentaci:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jak mohu zjistit, že konkrétní písmo v prezentaci bude i přes vložení stále substituováno při vykreslování?**  
Zkontrolujte [informace o substituci](/slides/cs/cpp/font-substitution/) ve správci písem a [pravidla pro záložní/substituční písma](/slides/cs/cpp/fallback-font/): pokud písmo není k dispozici nebo je omezeno, bude použito záložní písmo.

**Stojí za to vkládat systémová písma jako Arial/Calibri?**  
Obvykle ne — jsou téměř vždy dostupná. Ale pro plnou přenositelnost v „tenkých“ prostředích (Docker, Linuxový server bez předinstalovaných písem) může vložení systémových písem odstranit riziko neočekávaných substitucí.