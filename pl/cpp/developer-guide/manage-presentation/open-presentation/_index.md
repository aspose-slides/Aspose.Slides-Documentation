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
- zabezpieczona prezentacja
- duża prezentacja
- zasób zewnętrzny
- obiekt binarny
- C++
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w C++, podawać hasła otwarcia, kontrolować ładowanie zasobów i zmniejszać zużycie pamięci przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

[Aspose.Slides for C++](https://products.aspose.com/slides/pl/cpp/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/). Na przykład możesz podać hasło otwarcia, przechowywać duże obiekty binarne poza pamięcią, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Po załadowaniu pliku lub strumienia możesz [określić jego oryginalny format prezentacji](/slides/pl/cpp/detect-presentation-source-format/), aby wybrać sposób przetwarzania go przez aplikację.

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Zwalniaj obiekt prezentacji po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Poniższy przykład C++ pokazuje, jak otworzyć prezentację i uzyskać liczbę jej slajdów:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Otwieranie zabezpieczonych hasłem prezentacji**

Hasło otwarcia szyfruje zawartość prezentacji. Aby załadować pełną prezentację, przekaż prawidłowe hasło do [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub nieprawidłowe.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Aby dowiedzieć się o wykrywaniu, weryfikacji i przepływach pracy związanych z szyfrowaniem haseł, zobacz [Password-Protect Presentations](/slides/pl/cpp/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Manage Presentation Properties](/slides/pl/cpp/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) kontroluje, w jaki sposób Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Możesz utrzymać plik źródłowy w stanie zablokowanym, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod C++ demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Przy użyciu `PresentationLockingBehavior::KeepLocked` plik źródłowy pozostaje zablokowany, dopóki obiekt `Presentation` nie zostanie zwolniony. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ten obiekt jest aktywny.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Manage BLOBs](/slides/pl/cpp/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) przyjmuje implementację [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iresourceloadingcallback/). Callback może dostarczyć dane zastępujące, przekierować zasób, użyć domyślnego ładowania lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z zasadami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachować. Przykłady obejmują:

- projekty VBA, dostępne przez [IPresentation::get_VbaProject](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_vbaproject/);
- osadzone dane OLE, dostępne przez [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- dane kontrolki ActiveX, dostępne przez [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Przekaż `true` do [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/), aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby utrwalić odsanowaną wersję.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie poinformować o przyczynie.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal się ładować, ale renderowanie i eksport mogą zastępować czcionki. Możesz [skonfigurować zamianę czcionek](/slides/pl/cpp/font-substitution/) lub [dostarczyć własne czcionki](/slides/pl/cpp/custom-font/), aby uzyskać bardziej przewidywalny wynik.

**Czy ładowanie prezentacji ładuje również osadzone media?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można odczytać.