---
title: Zarządzanie grafikami SmartArt w prezentacjach w .NET
linktitle: Grafiki SmartArt
type: docs
weight: 20
url: /pl/net/manage-smartart-shape/
keywords:
- Obiekt SmartArt
- Grafika SmartArt
- Styl SmartArt
- Kolor SmartArt
- Tworzenie SmartArt
- Dodawanie SmartArt
- Edycja SmartArt
- Zmiana SmartArt
- Dostęp do SmartArt
- Typ układu SmartArt
- PowerPoint
- Prezentacja
- .NET
- C#
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizację grafiki SmartArt w PowerPoint w .NET przy użyciu Aspose.Slides, oferując krótkie przykłady kodu i wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. W tym artykule opisano, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd wizualny, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt poprzez kolekcję kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**

Aspose.Slides dla .NET umożliwia teraz dodawanie własnych kształtów SmartArt w slajdach od podstaw. Aspose.Slides dla .NET udostępnia najprostsze API do tworzenia kształtów SmartArt w najłatwiejszy sposób. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj kształt SmartArt, ustawiając jego LayoutType.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
// Utwórz prezentację
using (Presentation pres = new Presentation())
{

    // Uzyskaj dostęp do slajdu prezentacji
    ISlide slide = pres.Slides[0];

    // Dodaj kształt SmartArt
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Zapisz prezentację
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Uzyskanie dostępu do kształtu SmartArt na slajdzie**

Poniższy kod będzie używany do uzyskania dostępu do kształtów SmartArt dodanych w slajdzie prezentacji. W przykładowym kodzie przejdziemy przez każdy kształt w slajdzie i sprawdzimy, czy jest to kształt SmartArt. Jeśli kształt jest typu SmartArt, zostanie rzutowany na instancję SmartArt.

```c#
// Wczytaj żądaną prezentację
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Przejdź przez każdy kształt na pierwszym slajdzie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **Uzyskanie dostępu do kształtu SmartArt o określonym typie układu**

Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu SmartArt o określonym LayoutType. Należy pamiętać, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i jest ustawiany wyłącznie w momencie dodawania kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Sprawdź kształt SmartArt o określonym LayoutType i wykonaj wymagane działania.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Przejdź przez każdy kształt na pierwszym slajdzie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Sprawdzanie układu SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Zmiana stylu kształtu SmartArt**

Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu SmartArt o określonym LayoutType.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Znajdź kształt SmartArt o określonym Stylu.
- Ustaw nowy Styl dla kształtu SmartArt.
- Zapisz prezentację.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Przejdź przez każdy kształt na pierwszym slajdzie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Sprawdzanie stylu SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Zmiana stylu SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Zapisywanie prezentacji
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Zmiana stylu kolorów kształtu SmartArt**

W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładowym kodzie uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy jego styl.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Znajdź kształt SmartArt o określonym Stylu Koloru.
- Ustaw nowy Styl Koloru dla kształtu SmartArt.
- Zapisz prezentację.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Przejdź przez każdy kształt w pierwszym slajdzie
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Sprawdzanie typu koloru SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Zmienianie typu koloru SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Zapisywanie prezentacji
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/net/powerpoint-animation/) za pomocą API animacji (wejścia, wyjścia, uwydatnienia, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego identyfikatora?**

Ustaw i użyj alternatywnego tekstu (AltText) oraz wyszukaj kształt według tej wartości — jest to zalecany sposób na zlokalizowanie docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazkami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/net/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturkę/obraz kształtu; biblioteka może [renderować pojedyncze kształty](/slides/pl/net/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany podczas konwersji całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksportowaniu do PDF](/slides/pl/net/convert-powerpoint-to-pdf/), oferując szereg opcji jakości i kompatybilności.