---
title: Szakasz
type: docs
weight: 90
url: /hu/cpp/examples/elements/section/
keywords:
- kódpélda
- szakasz
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "A diák szakaszainak kezelése az Aspose.Slides for C++-ban: létrehozás, átnevezés, újrarendezés és diák csoportosítása C++ példákkal a PPT, PPTX és ODP formátumokhoz."
---
Példák a bemutató szakaszok kezelésére – hozzáadás, elérés, eltávolítás és átnevezés programozott módon a **Aspose.Slides for C++** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy olyan szakaszt, amely egy adott dián kezdődik.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adja meg azt a diát, amely a szakasz kezdetét jelöli.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Szakasz elérése**

Olvassa be a szakasz információit egy bemutatóból.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Szakaszt index alapján érjünk el.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Szakasz eltávolítása**

Törölje a korábban hozzáadott szakaszt.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Távolítsa el az első szakaszt.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Szakasz átnevezése**

Módosítsa egy meglévő szakasz nevét.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```