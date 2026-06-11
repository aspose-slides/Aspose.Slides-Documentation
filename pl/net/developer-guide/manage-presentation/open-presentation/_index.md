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
- zewnętrzny zasób
- obiekt binarny
- .NET
- C#
- Aspose.Slides
description: "Łatwo otwieraj prezentacje PowerPoint (.pptx, .ppt) i OpenDocument (.odp) za pomocą Aspose.Slides dla .NET - szybkie, niezawodne, w pełni funkcjonalne."
---
## **Wstęp**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia także otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz odczytać informacje o niej, edytować treść slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i przekaż jej ścieżkę do pliku w konstruktorze.

Poniższy przykład w C# pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```cs
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku do jej konstruktora.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Wypisz całkowitą liczbę slajdów w prezentacji.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Otwieranie prezentacji chronionych hasłem**

Gdy musisz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło przez właściwość [Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/) klasy [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/), aby odszyfrować i załadować plik. Poniższy kod w C# demonstruje tę operację:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Wykonaj operacje na odszyfrowanej prezentacji.
}
```

## **Otwieranie dużych prezentacji**

Aspose.Slides oferuje opcje — w szczególności właściwość [BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/blobmanagementoptions/) w klasie [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/) — które pomagają ładować duże prezentacje.

Poniższy kod w C# demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez okres życia 
        // instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Duża prezentacja została załadowana i może być używana, przy jednoczesnym niskim zużyciu pamięci.

    // Wprowadź zmiany w prezentacji.
    presentation.Slides[0].Name = "Large presentation";

    // Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nie rób tego! Zostanie rzucony wyjątek I/O, ponieważ plik jest zablokowany aż do zwolnienia obiektu Presentation.
    File.Delete(filePath);
}

// Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt Presentation.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Aby obejść niektóre ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje jej skopiowanie i może spowolnić proces ładowania. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.) możesz skorzystać z [BLOB management](/slides/pl/net/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrola zasobów zewnętrznych**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/iresourceloadingcallback/), który pozwala zarządzać zasobami zewnętrznymi. Poniższy kod w C# pokazuje, jak używać interfejsu `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Wczytaj zastępczy obraz.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Ustaw zastępczy URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Pomiń wszystkie inne obrazy.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy osadzonych obiektów binarnych:

- projekt VBA (dostępny poprzez [IPresentation.VbaProject](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/vbaproject/));
- dane osadzone obiektu OLE (dostępne poprzez [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- dane binarne kontrolki ActiveX (dostępne poprzez [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/pl/net/aspose.slides/icontrol/activexcontrolbinary/)).

Używając właściwości [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) możesz załadować prezentację bez jakichkolwiek osadzonych obiektów binarnych.

Ta właściwość jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w C# demonstruje, jak załadować prezentację bez osadzonych obiektów binarnych:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Wykonaj operacje na prezentacji.
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Podczas ładowania otrzymasz wyjątek parsowania/validacji formatu. Takie błędy często zawierają informację o nieprawidłowej strukturze ZIP lub uszkodzonych rekordach PowerPoint.

**Co się stanie, jeśli przy otwieraniu brakuje wymaganych czcionek?**

Plik zostanie otwarty, ale późniejsze [renderowanie/eksport](/slides/pl/net/convert-presentation/) może podmienić czcionki. Skonfiguruj [zastępowanie czcionek](/slides/pl/net/font-substitution/) lub [dodaj wymagane czcionki](/slides/pl/net/custom-font/) do środowiska uruchomieniowego.

**A co z osadzonymi mediami (wideo/audio) przy otwieraniu?**

Stają się one dostępne jako zasoby prezentacji. Jeśli media są odwoływane za pomocą ścieżek zewnętrznych, upewnij się, że te ścieżki są dostępne w Twoim środowisku; w przeciwnym razie [renderowanie/eksport](/slides/pl/net/convert-presentation/) może pominąć media.