---
title: "Vytvoření miniatur tvarů prezentace v C++"
linktitle: "Miniatury tvarů"
type: docs
weight: 70
url: /cs/cpp/shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- vykreslování tvaru
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro C++ – snadno vytvářejte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření prezentačních souborů, kde je každá stránka snímek. Tyto snímky lze zobrazit otevřením prezentačních souborů v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides pomůže vygenerovat miniatury obrázků tvarů snímků. Jak tuto funkci použít, je popsáno v tomto článku.

Tento článek vysvětluje, jak vygenerovat miniatury snímků různými způsoby:

- Vytvoření miniatury tvaru uvnitř snímku.
- Vytvoření miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Vytvoření miniatury tvaru v rámci ohraničení vzhledu tvaru.

## **Vytvořit miniaturu tvaru ze snímku**

Pro vytvoření miniatury tvaru z libovolného snímku pomocí Aspose.Slides for C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury tvaru referencovaného snímku v výchozím měřítku.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje miniaturu tvaru.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Vytvořit miniaturu s uživatelem definovaným škálovacím faktorem**

Pro vytvoření miniatury tvaru libovolného tvaru snímku pomocí Aspose.Slides for C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury referencovaného snímku s ohraničením tvaru.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje miniaturu s uživatelem definovaným škálovacím faktorem.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Škálování podél os X a Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Vytvořit miniaturu vzhledu tvaru na základě ohraničení**

Tato metoda pro vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v rámci ohraničení vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena ohraničením snímku. Pro vygenerování miniatury libovolného tvaru snímku v ohraničení jeho vzhledu použijte následující ukázkový kód:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury referencovaného snímku s ohraničením tvaru jako vzhledem.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad vytváří miniaturu pomocí uživatelem definovaného škálovacího faktoru.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Škálování podél os X a Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/) tím, že obsah tvaru uložíte jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/cpp/shape-effect/) (stíny, záře, atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur pro textové tvary?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/cpp/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/cpp/font-substitution/)), aby se zabránilo nechtěným náhradám a přelomu textu.