---
title: Vkládání fontů do prezentací pomocí C++
linktitle: Vkládání fontu
type: docs
weight: 40
url: /cs/cpp/embedded-font/
keywords:
- přidat font
- vložit font
- vkládání fontu
- získat vložený font
- přidat vložený font
- odebrat vložený font
- komprimovat vložený font
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vložte TrueType fonty do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, čímž zajistíte přesné vykreslování na všech platformách."
---
## **Úvod**

**Vložené fonty v PowerPointu** pomáhají zajistit, že vaše prezentace si zachová zamýšlený vzhled při otevření na jakémkoli systému nebo zařízení. To je zvláště důležité při použití vlastních, třetích stran nebo nestandardních fontů pro branding nebo kreativní účely. Bez vložených fontů může být text nahrazen, rozvržení se může rozbít a znaky se mohou zobrazit jako nečitelné symboly nebo obdélníky, což ohrožuje celkový design.

Aspose.Slides for C++ poskytuje sadu výkonných API pro programovou správu vložených fontů. Můžete použít třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/) a [FontData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontdata/) k prohlížení, přidávání nebo odstraňování vložených fontů ve vašich prezentačních souborech. Dále třída [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) vám umožní optimalizovat velikost souboru kompresí dat fontu, aniž by to ovlivnilo kvalitu nebo vzhled.

Tyto nástroje vám poskytují úplnou kontrolu nad vkládáním fontů, pomáhají udržovat konzistentní typografii napříč platformami a zároveň snižovat velikost souboru podle potřeby.

## **Získání vložených fontů z prezentace**

Aspose.Slides for C++ poskytuje metodu `GetEmbeddedFonts` prostřednictvím třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/), která vám umožní získat seznam fontů vložených v PowerPoint prezentaci. To může být užitečné pro auditování používání fontů, zajištění souladu s brandovými směrnicemi nebo ověření, že všechny potřebné fonty jsou před sdílením souboru řádně zahrnuty.

Následující C++ kód ukazuje, jak získat vložené fonty z prezentačního souboru:

```cpp
// Vytvořte instanci třídy Presentation, která představuje prezentační soubor.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Získejte všechny vložené fonty.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Vytiskněte názvy vložených fontů.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Přidání vložených fontů do prezentace**

Aspose.Slides for C++ vám umožňuje vložit fonty do PowerPoint prezentace pomocí metody [AddEmbeddedFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/addembeddedfont/), která má dva přetížení pro flexibilní použití. Můžete řídit, kolik části fontu bude vloženo, pomocí výčtu [EmbedFontCharacters](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedfontcharacters/) — například výběrem vložení pouze použitých znaků nebo celého sady fontu. Tato funkce je zvláště užitečná při přípravě prezentace ke sdílení nebo distribuci, zajišťuje, že vlastní nebo nestandardní fonty se na všech systémech zobrazí správně, i když nejsou nainstalovány.

Následující C++ kód kontroluje všechny fonty použité v prezentaci a vloží všechny fonty, které ještě nejsou vloženy.

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

    // Zkontrolujte, zda je font již vložen.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Vložte font do prezentace.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Uložte prezentaci na disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Odebrání vložených fontů z prezentace**

Aspose.Slides for C++ poskytuje metodu `RemoveEmbeddedFont` prostřednictvím třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/), která vám umožní odstranit konkrétní vložené fonty v PowerPoint prezentaci. To může pomoci snížit celkovou velikost souboru, zejména pokud vložené fonty již nejsou používány nebo potřebné. Odstranění nepoužívaných fontů může také zlepšit výkon a zajistit, že vaše prezentace obsahuje pouze nezbytné zdroje.

Následující C++ kód ukazuje, jak odebrat vložený font z prezentace:

```cpp
auto fontName = u"Calibri";

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Získat všechny vložené fonty.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Odstranit vložený font.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Komprese vložených fontů**

Aspose.Slides for C++ poskytuje metodu `CompressEmbeddedFonts` prostřednictvím třídy [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/), která vám umožní snížit celkovou velikost souboru prezentace optimalizací dat vložených fontů. To je zvláště užitečné, když vaše prezentace obsahuje velké nebo více fontů a chcete soubor udržet lehký pro sdílení, ukládání nebo online použití — aniž byste ohrozili vizuální věrnost obsahu.

Následující C++ kód ukazuje, jak komprimovat vložené fonty v PowerPoint prezentaci:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jak mohu zjistit, že konkrétní font v prezentaci bude i přes vložení stále nahrazen během vykreslování?**

Zkontrolujte [informace o substituci](/slides/cs/cpp/font-substitution/) ve správci fontů a [pravidla pro náhradu/substituce](/slides/cs/cpp/fallback-font/): pokud font není k dispozici nebo je omezen, bude použita náhradní varianta.

**Stojí za to vkládat „systémové“ fonty jako Arial/Calibri?**

Obvykle ne — tyto fonty jsou téměř vždy dostupné. Ale pro úplnou přenositelnost v „řídce“ vybavených prostředích (Docker, Linuxový server bez předinstalovaných fontů) může vložení systémových fontů odstranit riziko neočekávaných substitucí.