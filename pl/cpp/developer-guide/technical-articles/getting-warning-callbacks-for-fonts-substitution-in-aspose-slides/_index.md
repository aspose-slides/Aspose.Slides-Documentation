---
title: Pobieranie wywołań zwrotnych ostrzeżeń o zamianie czcionek
type: docs
weight: 70
url: /pl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- wywołanie zwrotne ostrzeżenia
- zamiana czcionki
- proces renderowania
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak otrzymywać wywołania zwrotne ostrzeżeń o zamianie czcionek w Aspose.Slides dla C++ oraz dokładnie wyświetlać prezentacje PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for C++ umożliwia otrzymywanie wywołań zwrotnych ostrzeżeń o zamianie czcionek, gdy wymagana czcionka nie jest dostępna na komputerze podczas renderowania. Te wywołania pomagają diagnozować problemy z brakującymi lub niedostępnymi czcionkami.

## **Włączanie wywołań zwrotnych ostrzeżeń**

Aspose.Slides for C++ udostępnia proste API do odbierania wywołań zwrotnych ostrzeżeń podczas renderowania slajdów prezentacji. Postępuj zgodnie z poniższymi krokami, aby skonfigurować wywołania zwrotne ostrzeżeń:

1. Utwórz własną klasę wywołania zwrotnego, która implementuje interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.warnings/iwarningcallback/) do obsługi ostrzeżeń.
1. Ustaw wywołanie zwrotne ostrzeżenia przy użyciu klas opcji, takich jak [RenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/), i innych.
1. Załaduj prezentację, która używa czcionki niedostępnej na docelowym komputerze.
1. Wygeneruj miniaturę slajdu lub wyeksportuj prezentację, aby zobaczyć efekt.

**Niestandardowa klasa wywołania zwrotnego ostrzeżenia:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Przykładowe wyjście:
//
// Czcionka zostanie zamieniona z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Wygeneruj miniaturę slajdu:**

```cpp
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas renderowania slajdów.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Załaduj prezentację z określonej ścieżki pliku.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Wygeneruj obraz miniatury dla każdego slajdu w prezentacji.
for(auto&& slide : presentation->get_Slides())
{
    // Uzyskaj obraz miniatury slajdu przy użyciu określonych opcji renderowania.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Eksportuj do formatu PDF:**

```cpp
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas eksportu do PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Załaduj prezentację z określonej ścieżki pliku.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Wyeksportuj prezentację jako PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Eksportuj do formatu HTML:**

```cpp
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas eksportu do HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Załaduj prezentację z określonej ścieżki pliku.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Wyeksportuj prezentację w formacie HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```