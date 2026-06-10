---
title: Dia
type: docs
weight: 10
url: /hu/net/examples/elements/slide/
keywords:
- dia
- dia hozzáadása
- dia elérése
- dia index
- dia klónozása
- diák átrendezése
- dia eltávolítása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Dia kezelése az Aspose.Slides for .NET-ben: létrehozás, klónozás, átrendezés, átméretezés, háttér beállítása, és átmenetek alkalmazása C#-al PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk példák sorozatát mutatja be, amelyek bemutatják, hogyan dolgozhatunk diákon a **Aspose.Slides for .NET** használatával. Megtanulja, hogyan adhat hozzá, érhet el, másolhat, rendezhet át és távolíthat el diákat a `Presentation` osztály segítségével.

Az alábbi példák mindegyike rövid magyarázatot tartalmaz, amelyet egy C# kódrészlet követ.

## **Dia hozzáadása**

Új dia hozzáadásához először ki kell választania egy elrendezést. Ebben a példában a `Blank` elrendezést használjuk, és egy üres diát adunk hozzá a prezentációhoz.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Minden dia egy elrendezésen alapul, amely maga is egy mesterdian alapul.
    // Használja a Blank elrendezést egy új dia létrehozásához.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Új üres diát ad hozzá a kiválasztott elrendezés használatával.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Megjegyzés:** Minden diaelrendezés a mesterdia alapján jön létre, amely meghatározza az általános tervezést és a helyőrző struktúrát. Az alábbi kép bemutatja, hogyan vannak a mesterdík és a hozzájuk tartozó elrendezések szervezve a PowerPointban.

![Mester és elrendezés kapcsolata](master-layout-slide.png)

## **Diák elérése index szerint**

A diák elérhetők az indexük alapján, vagy egy hivatkozás alapján megtalálhatja egy dia indexét. Ez hasznos a diák bejárásához vagy módosításához.

```csharp
static void AccessSlide()
{
    // Alapértelmezés szerint egy prezentáció egy üres diával jön létre.
    using var presentation = new Presentation();

    // Egy újabb üres diát adunk hozzá.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Diák elérése index szerint.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // A diát indexet egy hivatkozásból kérjük le, majd index szerint érjük el.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Dia klónozása**

Ez a példa bemutatja, hogyan klónozhat egy létező diát. A klónozott dia automatikusan a dia gyűjtemény végéhez kerül hozzá.

```csharp
static void CloneSlide()
{
    // Alapértelmezés szerint a prezentáció egy üres diát tartalmaz.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Klónozza az első diát; a prezentáció végére kerül hozzá.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // A klónozott dia indexe 1 (a prezentáció második diája).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Diák átrendezése**

A diák sorrendjét úgy módosíthatja, hogy egyet egy új indexre mozgat. Ebben az esetben egy klónozott diát az első pozícióba helyezzük.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Adjunk hozzá egy klónt az első diából (alapértelmezés szerint létrehozva).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // A klónozott diát az első pozícióba helyezzük (a többi lejjebb tolódik).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Dia eltávolítása**

Egy dia eltávolításához egyszerűen hivatkozzon rá és hívja meg a `Remove` metódust. Ez a példa egy második diát ad hozzá, majd eltávolítja az eredetit, így csak az új dia marad.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Adjunk hozzá egy új üres diát az alapértelmezett első dia mellett.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Távolítsuk el az első diát; csak az újonnan hozzáadott dia marad meg.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```