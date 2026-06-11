---
title: Slajd główny
type: docs
weight: 30
url: /pl/cpp/examples/elements/master-slide/
keywords:
- przykład kodu
- slajd główny
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj przykłady slajdów głównych Aspose.Slides dla C++: twórz, edytuj i stylizuj slajdy główne, pola zastępcze i motywy w formatach PPT, PPTX i ODP przy użyciu przejrzystego kodu C++."
---
Slajdy główne tworzą najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **Slajd główny** definiuje wspólne elementy projektowe, takie jak tła, logotypy i formatowanie tekstu. **Slajdy układu** dziedziczą po slajdach głównych, a **slajdy normalne** dziedziczą po slajdach układu.

Ten artykuł pokazuje, jak tworzyć, modyfikować i zarządzać slajdami głównymi przy użyciu Aspose.Slides for C++.

## **Dodaj slajd główny**

Ten przykład pokazuje, jak utworzyć nowy slajd główny, kopiując domyślny. Następnie dodaje baner z nazwą firmy do wszystkich slajdów poprzez dziedziczenie układu.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Skopiuj domyślny slajd główny.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Dodaj baner z nazwą firmy na górze slajdu głównego.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Przypisz nowy slajd główny do slajdu układu.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Przypisz slajd układu do pierwszego slajdu w prezentacji.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Uwaga 1:** Slajdy główne zapewniają możliwość stosowania spójnej identyfikacji wizualnej lub wspólnych elementów projektu na wszystkich slajdach. Wszelkie zmiany wprowadzone w slajdzie głównym będą automatycznie odzwierciedlane w zależnych slajdach układu i normalnych.

> 💡 **Uwaga 2:** Wszystkie kształty lub formatowanie dodane do slajdu głównego są dziedziczone przez slajdy układu i, w konsekwencji, przez wszystkie slajdy normalne korzystające z tych układów.
> Obraz poniżej ilustruje, jak pole tekstowe dodane na slajdzie głównym jest automatycznie renderowane na slajdzie końcowym.

![Przykład dziedziczenia slajdu głównego](master-slide-banner.png)

## **Uzyskaj dostęp do slajdu głównego**

Możesz uzyskać dostęp do slajdów głównych przy użyciu kolekcji slajdów głównych prezentacji. Oto jak je pobrać i pracować z nimi:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Zmień typ tła.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Usuń slajd główny**

Slajdy główne można usunąć zarówno według indeksu, jak i według odwołania.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Usuń slajd główny według indeksu.
    presentation->get_Masters()->RemoveAt(0);

    // Usuń slajd główny według odwołania.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Usuń nieużywane slajdy główne**

Niektóre prezentacje zawierają slajdy główne, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Usuń wszystkie nieużywane slajdy główne (nawet te oznaczone jako Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```