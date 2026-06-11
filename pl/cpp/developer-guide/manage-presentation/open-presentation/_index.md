---
title: Otwieranie prezentacji w C++
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/cpp/open-presentation/
keywords:
- otwórz PowerPoint
- otwórz OpenDocument
- otwórz prezentację
- otwórz PPTX
- otwórz PPT
- otwórz ODP
- załaduj prezentację
- załaduj PPTX
- załaduj PPT
- załaduj ODP
- chroniona prezentacja
- duża prezentacja
- zewnętrzny zasób
- obiekt binarny
- C++
- Aspose.Slides
description: "Otwieraj prezentacje PowerPoint (.pptx, .ppt) i OpenDocument (.odp) bez wysiłku za pomocą Aspose.Slides dla C++ — szybkie, niezawodne, w pełni funkcjonalne."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia również otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz pobrać informacje na jej temat, edytować zawartość slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i przekaż ścieżkę do pliku do jej konstruktora.

Poniższy przykład w C++ pokazuje, jak otworzyć prezentację i uzyskać liczbę jej slajdów:
```cpp
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku do jej konstruktora.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Wypisz całkowitą liczbę slajdów w prezentacji.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Otwieranie prezentacji chronionych hasłem**

Gdy trzeba otworzyć prezentację chronioną hasłem, przekaż hasło metodą [set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) klasy [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/) aby odszyfrować i załadować ją. Poniższy kod w C++ demonstruje tę operację:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Wykonaj operacje na odszyfrowanej prezentacji.

presentation->Dispose();
```

## **Otwieranie dużych prezentacji**

Aspose.Slides udostępnia opcje — w szczególności metodę [get_BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) klasy [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/), aby pomóc w ładowaniu dużych prezentacji.

Poniższy kod w C++ demonstruje ładowanie dużej prezentacji (na przykład 2 GB):
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez cały okres życia
// instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Duża prezentacja została załadowana i może być używana, przy jednoczesnym niskim zużyciu pamięci.

// Wprowadź zmiany w prezentacji.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Nie rób tego! Zostanie rzucony wyjątek I/O, ponieważ plik jest zablokowany aż do zwolnienia obiektu prezentacji.
File::Delete(filePath);

presentation->Dispose();

// Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt prezentacji.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Aby obejść niektóre ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje kopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.), możesz użyć [BLOB management](/slides/pl/cpp/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrola zewnętrznych zasobów**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iresourceloadingcallback/), który umożliwia zarządzanie zasobami zewnętrznymi. Poniższy kod w C++ pokazuje, jak używać interfejsu `IResourceLoadingCallback`:
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Wczytaj zastępczy obraz.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Ustaw zastępczy adres URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Pomiń wszystkie pozostałe obrazy.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy osadzonych obiektów binarnych:
- Projekt VBA (dostępny przez [IPresentation::get_VbaProject](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Osadzone dane obiektów OLE (dostępne przez [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Binarny kod kontrolki ActiveX (dostępny przez [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Używając metody [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), możesz załadować prezentację bez żadnych osadzonych obiektów binarnych.

Ta metoda jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w C++ demonstruje, jak załadować prezentację bez jakichkolwiek osadzonych treści binarnych:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Wykonaj operacje na prezentacji.

presentation->Dispose();
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Podczas ładowania otrzymasz wyjątek parsowania/validacji formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli podczas otwierania brakuje wymaganych czcionek?**

Plik zostanie otwarty, ale później [rendering/export](/slides/pl/cpp/convert-presentation/) może zastąpić czcionki. [Configure font substitutions](/slides/pl/cpp/font-substitution/) lub [add the required fonts](/slides/pl/cpp/custom-font/) w środowisku uruchomieniowym.

**Co z osadzonymi mediami (wideo/audio) przy otwieraniu?**

Stają się dostępne jako zasoby prezentacji. Jeśli media są odwoływane przez zewnętrzne ścieżki, upewnij się, że te ścieżki są dostępne w twoim środowisku; w przeciwnym razie [rendering/export](/slides/pl/cpp/convert-presentation/) może pominąć media.