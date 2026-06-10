---
title: Elrendezésdia
type: docs
weight: 20
url: /hu/cpp/examples/elements/layout-slide/
keywords:
- kódpélda
- elrendezésdia
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ fő elrendezésdiai: válasszon, alkalmazzon és testreszabjon diák elrendezéseket, helyőrzőket és mesteroldalakat C++ példákkal PPT, PPTX és ODP bemutatókhoz."
---
Ez a cikk bemutatja, hogyan dolgozhat a **Layout Slides**-sal az Aspose.Slides for C++-ban. Egy elrendezésdia definiálja a normál diákra öröklődő tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezésdiókat, valamint tisztíthatja a fel nem használtakat a bemutató méretének csökkentése érdekében.

## **Elrendezésdia hozzáadása**

Létrehozhat egy egyéni elrendezésdiót az újrahasználható formázás meghatározásához. Például hozzáadhat egy szövegdobozt, amely az összes, ezt az elrendezést használó dián megjelenik.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Hozzon létre egy elrendezésdiót üres elrendezéstípussal és egy egyéni névvel.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Adj hozzá egy szövegdobozt az elrendezésdiához.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Adj hozzá két diát ezzel az elrendezéssel; mindkettő örökli a szöveget az elrendezésből.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Megjegyzés 1:** Az elrendezésdiók sablonként működnek az egyes diák számára. Egyszer definiálhat közös elemeket, és sok dián újra felhasználhatja őket.
> 💡 **Megjegyzés 2:** Ha alakzatokat vagy szöveget ad hozzá egy elrendezésdiához, az arra épülő összes dia automatikusan megjeleníti ezt a megosztott tartalmat.
> Az alábbi képernyőkép két diát mutat, amelyek mindegyike ugyanabból az elrendezésdióból örököl egy szövegdobozt.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Elrendezésdia elérése**

Az elrendezésdiók elérhetők index vagy elrendezéstípus szerint (például `Blank`, `Title`, `SectionHeader`, stb.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Index alapján elrendezésdia elérése.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Típus szerint elrendezésdia elérése.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Elrendezésdia eltávolítása**

Eltávolíthat egy adott elrendezésdiót, ha már nincs rá szükség.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Szerezzen meg egy elrendezésdiót típus szerint, és távolítsa el.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Nem használt elrendezésdiók eltávolítása**

A bemutató méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezésdiókat, amelyeket egyetlen normál dia sem használ.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Automatikusan eltávolítja az összes olyan elrendezésdiót, amelyre egyetlen dia sem hivatkozik.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Elrendezésdia klónozása**

Megkettőzheti egy elrendezésdiót az `AddClone` metódus használatával.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Szerezzen be egy meglévő elrendezésdiót típus szerint.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Klónozza az elrendezésdiót a elrendezésdiák gyűjteményének végére.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Összefoglaló:** Az elrendezésdiók hatékony eszközök a diák közötti egységes formázás kezelésére. Az Aspose.Slides teljes irányítást biztosít az elrendezésdiók létrehozása, kezelése és optimalizálása felett.