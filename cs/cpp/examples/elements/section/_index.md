---
title: Sekce
type: docs
weight: 90
url: /cs/cpp/examples/elements/section/
keywords:
- příklad kódu
- sekce
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte sekce snímků v Aspose.Slides pro C++: vytvářejte, přejmenovávejte, měňte pořadí a seskupujte snímky pomocí příkladů v C++ pro PPT, PPTX a ODP."
---
Příklady správy sekcí prezentace – přidání, přístup, odstranění a přejmenování pomocí programování s **Aspose.Slides for C++**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Specifikujte snímek, který označuje začátek sekce.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Přístup k sekci**

Načtěte informace o sekci z prezentace.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Přístup k sekci podle indexu.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Odstraňte první sekci.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Přejmenovat sekci**

Změňte název existující sekce.

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