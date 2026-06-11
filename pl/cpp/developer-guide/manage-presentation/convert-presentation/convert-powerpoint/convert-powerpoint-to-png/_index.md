---
title: Konwertuj slajdy PowerPoint do PNG w C++
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/cpp/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla C++, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak wczytywać pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł również demonstruje, jak dostosować generowane obrazy PNG, ustawiając wartości skali lub określając żądaną szerokość i wysokość.

## **Konwertuj PowerPoint do PNG**

Postępuj według następujących kroków:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz obiekt slajdu z kolekcji [Presentation::get_Slides()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) pod interfejsem [ISlide](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide).
3. Użyj metody [ISlide::GetImage()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage) aby uzyskać miniaturę każdego slajdu.
4. Użyj metody [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) aby zapisać miniaturę slajdu w formacie PNG.

Ten kod C++ pokazuje, jak przekonwertować prezentację PowerPoint na PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Konwertuj PowerPoint do PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary powstałej miniatury.

Ten kod w C++ demonstruje opisaną operację:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Konwertuj PowerPoint do PNG z niestandardowym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać preferowane argumenty `width` i `height` dla `ImageSize`.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint do PNG, określając rozmiar obrazów:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **FAQ**

**Jak mogę wyeksportować tylko konkretny kształt (np. wykres lub obraz) zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/cpp/create-shape-thumbnails/); możesz renderować kształt do obrazu PNG.

**Czy konwersja równoległa jest wspierana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/cpp/multithreading/) jednej instancji prezentacji pomiędzy wątkami. Użyj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do wyjściowych obrazów oraz wymusza [inne ograniczenia](/slides/pl/cpp/licensing/), dopóki nie zostanie zastosowana licencja.