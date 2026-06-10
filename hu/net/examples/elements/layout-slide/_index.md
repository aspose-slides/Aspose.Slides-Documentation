---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/net/examples/elements/layout-slide/
keywords:
- elrendezési dia
- elrendezési dia hozzáadása
- elrendezési dia elérése
- elrendezési dia eltávolítása
- nem használt elrendezési dia
- elrendezési dia klónozása
- kódpélda
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET mesterelrendezési diái: válasszon, alkalmazzon és testreszabjon diaelrendezéseket, helyőrzőket és mestereket C# példákkal PPT, PPTX és ODP bemutatókhoz."
---
Ez a cikk bemutatja, hogyan dolgozhat a **Layout Slides** elemekkel az Aspose.Slides for .NET-ben. Egy elrendezési dia meghatározza a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diákat, valamint megtisztíthatja a nem használtakat a bemutató méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát az újrahasználható formázás meghatározásához. Például hozzáadhat egy szövegdobozt, amely az ezzel az elrendezéssel készült összes dián megjelenik.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Hozzon létre egy elrendezési diát üres elrendezéstípussal és egy egyéni névvel.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Adjon hozzá egy szövegdobozt az elrendezési diához.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Adjon hozzá két diát ezzel az elrendezéssel; mindkettő örökölni fogja a szöveget az elrendezésből.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Az elrendezési diák egyéni diák sablonjaként működnek. Egy közös elemet egyszer definiálhat, és számos dián újra felhasználhatja.

> 💡 **Note 2:** Amikor alakzatokat vagy szöveget ad hozzá egy elrendezési diához, az az elrendezés alapján készült összes dia automatikusan megjeleníti ezt a megosztott tartalmat.  
> Az alábbi képernyőkép két diát mutat, amelyek mindegyike ugyanabból az elrendezési diából örököl egy szövegdobozt.

![Diák, amelyek öröklik az elrendezés tartalmát](layout-slide-result.png)

## **Elrendezési dia elérése**

Az elrendezési diák index vagy elrendezéstípus (pl. `Blank`, `Title`, `SectionHeader`, stb.) alapján érhetők el.

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Index alapján elrendezési dia elérése.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Típus alapján elrendezési dia elérése.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Elrendezési dia eltávolítása**

Egy adott elrendezési diát eltávolíthat, ha már nincs rá szükség.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Szerezzen egy elrendezési diát típus alapján, és távolítsa el.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Nem használt elrendezési diák eltávolítása**

A bemutató méretének csökkentése érdekében szeretné eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Automatikusan eltávolítja az összes olyan elrendezési diát, amelyet egyetlen dia sem hivatkozik.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Elrendezési dia klónozása**

Egy elrendezési diát megkettőzhet az `AddClone` metódus használatával.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Szerezz be egy meglévő elrendezési diát típus alapján.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Klónozza az elrendezési diát a elrendezési diákat tartalmazó gyűjtemény végére.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Összefoglaló:** Az elrendezési diák hatékony eszközök a diák közötti egységes formázás kezelésére. Az Aspose.Slides teljes irányítást biztosít az elrendezési diák létrehozása, kezelése és optimalizálása felett.