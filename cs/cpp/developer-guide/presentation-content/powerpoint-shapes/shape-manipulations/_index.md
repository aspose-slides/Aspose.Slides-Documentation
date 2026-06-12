---
title: Správa tvarů v prezentaci v C++
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/cpp/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- nalezení tvaru
- klonování tvaru
- odstranění tvaru
- skrytí tvaru
- změna pořadí tvaru
- získání Interop Shape ID
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnání tvaru
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro C++ a vytvářet výkonné prezentace PowerPoint."
---
## **Overview**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit jej, skrýt jej, změnit jeho pořadí, získat jeho Interop shape ID a nastavit alternativní text pro identifikaci a další zpracování.

Také se zabývá tím, jak přistupovat k formátům rozvržení pro tvary, renderovat tvar jako SVG, zarovnávat tvary na snímku a používat vlastnosti překlápění pro horizontální a vertikální zrcadlení. Navíc článek obsahuje krátkou FAQ o kombinování tvarů, pořadí vrstev a uzamčení tvaru.

## **Nalezení tvaru na snímku**
Toto téma popisuje jednoduchou techniku, která usnadňuje vývojářům najít konkrétní tvar na snímku bez použití jeho interního Id. Je důležité vědět, že soubory PowerPoint Presentation nemají žádný způsob, jak identifikovat tvary na snímku kromě interního jedinečného Id. Zdá se, že je pro vývojáře obtížné najít tvar pomocí jeho interního jedinečného Id. Všechny tvary přidané na snímky mají nějaký alternativní text. Doporučujeme vývojářům používat alternativní text pro vyhledání konkrétního tvaru. Můžete použít MS PowerPoint k definování alternativního textu pro objekty, které plánujete v budoucnu měnit.

Po nastavení alternativního textu libovolného požadovaného tvaru můžete otevřít tuto prezentaci pomocí Aspose.Slides for C++ a iterovat přes všechny tvary přidané na snímek. Během každé iterace můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude požadovaný tvar. Pro lepší demonstraci této techniky jsme vytvořili metodu, [FindShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f), která provádí hledání konkrétního tvaru na snímku a jednoduše vrací tento tvar.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Klonování tvaru**
Chcete‑li klonovat tvar na snímek pomocí Aspose.Slides for C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci snímku pomocí jeho indexu.
3. Přistupte k kolekci tvarů zdrojového snímku.
4. Přidejte nový snímek do prezentace.
5. Klonujte tvary z kolekce tvarů zdrojového snímku do nového snímku.
6. Uložte upravenou prezentaci jako soubor PPTX.

Příklad níže přidává skupinový tvar na snímek.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Odstranění tvaru**
Aspose.Slides for C++ umožňuje vývojářům odstranit libovolný tvar. Pro odstranění tvaru z libovolného snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Přistupte k prvnímu snímku.
3. Najděte tvar s konkrétním AlternativeText.
4. Odstraňte tvar.
5. Uložte soubor na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Skrytí tvaru**
Aspose.Slides for C++ umožňuje vývojářům skrýt libovolný tvar. Pro skrytí tvaru na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Přistupte k prvnímu snímku.
3. Najděte tvar s konkrétním AlternativeText.
4. Skryjte tvar.
5. Uložte soubor na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Změna pořadí tvarů**
Aspose.Slides for C++ umožňuje vývojářům změnit pořadí tvarů. Přeskupení tvarů určuje, který tvar je vpředu a který vzadu. Pro přeskupení tvarů na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Přistupte k prvnímu snímku.
3. Přidejte tvar.
4. Přidejte text do textového rámce tvaru.
5. Přidejte další tvar se stejnými souřadnicemi.
6. Přeskupte tvary.
7. Uložte soubor na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Získání Interop Shape ID**
Aspose.Slides for C++ umožňuje vývojářům získat jedinečný identifikátor tvaru v rámci snímku na rozdíl od vlastnosti UniqueId, která poskytuje jedinečný identifikátor v celém rozsahu prezentace. Vlastnost OfficeInteropShapeId byla přidána do rozhraní IShape i třídy Shape. Hodnota vrácená vlastností OfficeInteropShapeId odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Nastavení vlastnosti AlternativeText**
Aspose.Slides for C++ umožňuje vývojářům nastavit AlternateText libovolného tvaru. Pro nastavení AlternateText tvaru postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Přistupte k prvnímu snímku.
3. Přidejte libovolný tvar na snímek.
4. Proveďte požadovanou práci s nově přidaným tvarem.
5. Procházejte tvary a najděte požadovaný tvar.
6. Nastavte AlternativeText.
7. Uložte soubor na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Přístup k formátům rozvržení pro tvar**
Aspose.Slides for C++ umožňuje vývojářům přistupovat k formátům rozvržení pro tvar. Tento článek ukazuje, jak můžete získat vlastnosti **FillFormat** a **LineFormat** pro tvar.

Níže je uveden ukázkový kód.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Renderování tvaru jako SVG**
Nyní Aspose.Slides for C++ podporuje renderování tvaru jako SVG. Metoda WriteAsSvg (a její přetížení) byla přidána do třídy Shape a rozhraní IShape. Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže je ukázka kódu, jak exportovat tvar snímku do souboru SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Zarovnání tvarů**
Aspose.Slides umožňuje zarovnávat tvary buď vzhledem k okrajům snímku nebo vzhledem k sobě navzájem. K tomuto účelu byl přidán přetížený [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) metoda. Výčet [ShapesAlignmentType](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definuje možné možnosti zarovnání.

**Example 1**

Zdrojový kód níže zarovnává tvary s indexy 1, 2 a 4 podél horní hrany snímku.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Example 2**

Příklad níže ukazuje, jak zarovnat celou kolekci tvarů vzhledem k nejnižšímu tvaru v kolekci.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Vlastnosti překlápění**

V Aspose.Slides poskytuje třída [ShapeFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeframe/) řízení horizontálního a vertikálního zrcadlení tvarů pomocí vlastností `flipH` a `flipV`. Obě vlastnosti jsou typu [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/), což umožňuje hodnoty `True` pro překlápění, `False` pro žádné překlápění nebo `NotDefined` pro výchozí chování. Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_frame/) tvaru.

Pro úpravu nastavení překlápění je vytvořena nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapeframe/) s aktuální polohou a rozměry tvaru, požadovanými hodnotami pro `flipH` a `flipV` a úhlem otáčení. Přiřazením této instance k [Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_frame/) tvaru a uložením prezentace se aplikují zrcadlové transformace a uloží se do výstupního souboru.

Řekněme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlápění, jak je ukázáno níže.

![The shape to be flipped](shape_to_be_flipped.png)

Následující ukázkový kód získá aktuální vlastnosti překlápění tvaru a překlápí jej horizontálně i vertikálně.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Získání horizontálního flipu tvaru.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Získání vertikálního flipu tvaru.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Překlopit horizontálně.
auto flipV = NullableBool::True; // Překlopit horizontálně.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Mohu kombinovat tvary (sjednocení/průnik/odčerpání) na snímku jako v desktopovém editoru?**

Neexistuje vestavěné API pro Boolean operace. Můžete to přibližně simulovat tím, že si sami vytvoříte požadovaný obrys — například pomocí výpočtu výsledné geometrie (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides/geometrypath/)) a vytvoříte nový tvar s tímto konturem, případně odstraníte původní tvary.

**Jak mohu řídit pořadí vrstev (z-order), aby tvar vždy zůstal „navrchu“?**

Změňte pořadí vložení/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseslide/get_shapes/) snímku. Pro předvídatelné výsledky dokončete nastavení z‑orderu po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby uživatelé nemohli v PowerPointu upravovat?**

Ano. Nastavte [vlajky ochrany na úrovni tvaru](/slides/cs/cpp/applying-protection-to-presentation/) (např. zamknutí výběru, přesunu, změny velikosti, úprav textu). V případě potřeby aplikujte omezení i na master nebo rozvržení. Upozorňujeme, že jde o ochranu na úrovni UI, ne o bezpečnostní prvek; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou doporučení pro jen‑čtení nebo hesla (/slides/cs/cpp/password-protected-presentation/).