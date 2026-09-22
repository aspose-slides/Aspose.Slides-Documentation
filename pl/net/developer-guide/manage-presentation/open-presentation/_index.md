---
title: Otwieranie prezentacji w .NET
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/net/open-presentation/
keywords:
- otwórz PowerPoint
- otwórz prezentację
- otwórz PPTX
- otwórz PPT
- otwórz ODP
- wczytaj prezentację
- wczytaj PPTX
- wczytaj PPT
- wczytaj ODP
- zabezpieczona prezentacja
- duża prezentacja
- zasób zewnętrzny
- obiekt binarny
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w C#, podawać hasła otwarcia, kontrolować ładowanie zasobów i zmniejszyć zużycie pamięci przy użyciu Aspose.Slides dla .NET."
---
## **Wprowadzenie**

[Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji można przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/). Na przykład można podać hasło otwarcia, przechowywać duże obiekty binarne poza zarządzaną pamięcią, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Po załadowaniu pliku lub strumienia możesz [określić jego oryginalny format prezentacji](/slides/pl/net/detect-presentation-source-format/), aby wybrać sposób przetwarzania go przez aplikację.

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Zwolnij prezentację po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Poniższy przykład C# pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Hasło otwarcia szyfruje zawartość prezentacji. Aby wczytać całą prezentację, przypisz poprawne hasło do [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub nieprawidłowe.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

W celu wykrywania, weryfikacji i obsługi szyfrowania haseł zobacz [Password-Protect Presentations](/slides/pl/net/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Manage Presentation Properties](/slides/pl/net/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/blobmanagementoptions/) kontroluje, w jaki sposób Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Możesz utrzymywać plik źródłowy w stanie zablokowanym, zezwalać na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod C# demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Przy `PresentationLockingBehavior.KeepLocked` plik źródłowy pozostaje zablokowany, dopóki obiekt `Presentation` nie zostanie zwolniony. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ten obiekt jest aktywny.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. W przypadku dużych prezentacji ścieżka pliku jest zazwyczaj wydajniejsza niż strumień. Zobacz [Manage BLOBs](/slides/pl/net/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/resourceloadingcallback/) akceptuje implementację [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iresourceloadingcallback/). Wywołanie zwrotne może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego ładowania lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z regułami bezpieczeństwa lub przechowywania aplikacji.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, których aplikacja nie potrzebuje lub nie chce zachowywać. Przykłady:

- projekty VBA, dostępne poprzez [IPresentation.VbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/vbaproject/);
- osadzone dane OLE, dostępne poprzez [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- dane kontrolki ActiveX, dostępne poprzez [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/pl/net/aspose.slides/icontrol/activexcontrolbinary/).

Ustaw [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować zweryfikowany wynik.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie można go otworzyć?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie poinformować o przyczynie.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal się załadować, ale renderowanie i eksport mogą zastępować brakujące czcionki. Możesz [skonfigurować zamianę czcionek](/slides/pl/net/font-substitution/) lub [dostarczyć własne czcionki](/slides/pl/net/custom-font/), aby uzyskać bardziej przewidywalny wynik.

**Czy ładowanie prezentacji ładuje również jej osadzone multimedia?**

Osadzone audio i wideo są dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.