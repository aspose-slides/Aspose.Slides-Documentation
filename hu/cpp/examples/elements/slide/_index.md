---
title: Dia
type: docs
weight: 10
url: /hu/cpp/examples/elements/slide/
keywords:
- kódpélda
- dia
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "A diák kezelése az Aspose.Slides for C++-ban: létrehozás, klónozás, átrendezés, átméretezés, háttér beállítása, és átmenetek alkalmazása C++-ban PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk példák sorozatát nyújtja, amelyek bemutatják, hogyan dolgozhatunk diák kezelése a **Aspose.Slides for C++** használatával. Megtanulja, hogyan adjon hozzá, érjen el, klónozzon, rendezzen át és távolítson el diákat a `Presentation` osztállyal.

Az alábbi példák minden egyes tartalmaz rövid magyarázatot, amelyet egy C++ kódrészlet követ.

## **Dia hozzáadása**

Új dia hozzáadásához először ki kell választani egy elrendezést. Ebben a példában a `Blank` elrendezést használjuk, és egy üres diát adunk a prezentációhoz.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Megjegyzés:** Minden diaelrendezés egy fő diából származik, amely meghatározza az általános megjelenést és a helyőrző struktúrát. Az alábbi kép szemlélteti, hogyan szerveződnek a fő diák és a kapcsolódó elrendezések a PowerPointban.

![Master and Layout Relationship](master-layout-slide.png)

## **Diák elérése index szerint**

A diákhoz elérhetjük az indexük alapján, vagy megtalálhatjuk egy dia indexét egy hivatkozás alapján. Ez hasznos a diák bejárásához vagy konkrét diák módosításához.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Adj hozzá egy másik üres diát.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Diák elérése index szerint.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Kérj le egy dia indexét egy hivatkozásból, majd index alapján érd el.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Dia klónozása**

Ez a példa bemutatja, hogyan lehet egy meglévő diát klónozni. A klónozott dia automatikusan a diákollekció végére kerül.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Diák átrendezése**

A diák sorrendjét át lehet rendezni egy dia új indexre mozgatásával. Ebben az esetben egy klónozott diát helyezünk az első pozícióba.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Dia eltávolítása**

Dia eltávolításához egyszerűen hivatkozzunk rá és hívjuk meg a `Remove` metódust. Ez a példa hozzáad egy második diát, majd eltávolítja az eredetit, így csak az új marad.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```