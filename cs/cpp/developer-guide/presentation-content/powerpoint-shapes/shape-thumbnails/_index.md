---
title: Vytvořit miniatury tvarů prezentace v C++
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/cpp/shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- vykreslování tvaru
- vizuální hranice
- hranice tvaru
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro C++ - snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření prezentačních souborů, kde každá stránka je snímek. Tyto snímky lze zobrazit otevřením prezentačního souboru v Microsoft PowerPointu. Někdy však vývojáři potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides pomůže vygenerovat miniatury obrázků tvarů snímku. Jak tuto funkci použít, je popsáno v tomto článku.

Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Generování miniatury tvaru uvnitř snímku.
- Generování miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Vygenerovat miniaturu tvaru ze snímku**

Pro vygenerování miniatury tvaru z libovolného snímku pomocí Aspose.Slides pro C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) class.
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. Získejte obrázek miniatury tvaru referencovaného snímku v výchozím měřítku.
1. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Příklad níže generuje miniaturu tvaru.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Vygenerovat miniaturu s uživatelem definovaným měřítkovým faktorem**

Pro vygenerování miniatury tvaru libovolného tvaru snímku pomocí Aspose.Slides pro C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) class.
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. Získejte obrázek miniatury referencovaného snímku s omezeními tvaru.
1. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Příklad níže generuje miniaturu s uživatelem definovaným měřítkovým faktorem.

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

## **Vytvořit miniaturu vzhledu tvaru založenou na mezích**

Tato metoda pro vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena hranicemi snímku. Pro vygenerování miniatury libovolného tvaru snímku v mezích jeho vzhledu použijte následující ukázkový kód:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) class.
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. Získejte obrázek miniatury referencovaného snímku s omezeními tvaru jako vzhledem.
1. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Příklad níže vytváří miniaturu založenou na vzhledu tvaru.

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

## **Získat skutečné vizuální hranice tvaru**

Vlastnosti rámce [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` a `IShape::get_Height()` — popisují obdélník uložený v modelu prezentace. Obsah, který se skutečně vykresluje, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení textu a přetečení, generovaná geometrie SmartArt a jiné efekty vykreslování mohou změnit obsazenou oblast.

Použijte [Shape::GetVisualBounds](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getvisualbounds/) k výpočtu této obsazené oblasti bez vytváření obrázku. Metoda vrací [RectangleF](https://reference.aspose.com/slides/cs/cpp/system.drawing/rectanglef/) ve slidových souřadnicích. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, když obsah přesahuje počátek snímku.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getvisualbounds/) není v současnosti deklarována rozhraním [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/). Proto uchovávejte tvar získaný ze sbírky tvarů snímku jako hodnotu rozhraní a přetypujte ji pouze při volání metody.

Následující příklad získává a porovnává rámec a vizuální hranice:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Stejný [RectangleF](https://reference.aspose.com/slides/cs/cpp/system.drawing/rectanglef/) lze použít k zarovnání sousedních tvarů k jeho okraji `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` nebo `RectangleF::get_Bottom()`, vyhradit dostatek místa v generovaném rozvržení nebo detekovat obsah mimo povolenou oblast. Vizuální hranice jsou zvláště užitečné pro SmartArt, textová pole, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape::GetVisualBounds](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getvisualbounds/), když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [IShape::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getimage/), když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` nastaví velikost obrázku podle hranic tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds::Appearance` nastaví velikost podle vzhledu tvaru a omezuje výsledek na hranice snímku. Naopak [Shape::GetVisualBounds](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getvisualbounds/) vrací pouze vypočítaný obdélník a neodebírá jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi hranicemi Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/cpp/shape-effect/) (stíny, záblesky atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude i přesto vykreslen jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání vytvoření obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další komplexní objekty?**

Ano. Jakýkoli objekt představovaný jako [Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémové fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/cpp/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/cpp/font-substitution/)), aby se zabránilo nechtěným náhradám a přetékanému textu.