---
title: Konwertuj prezentacje PowerPoint na dokumenty Word w C++
linktitle: PowerPoint do Worda
type: docs
weight: 110
url: /pl/cpp/convert-powerpoint-to-word/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do Worda
- prezentacja do Worda
- slajd do Worda
- PPT do Worda
- PPTX do Worda
- PowerPoint do DOCX
- prezentacja do DOCX
- slajd do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentacja do DOC
- slajd do DOC
- PPT do DOC
- PPTX do DOC
- zapisz PPT jako DOCX
- zapisz PPTX jako DOCX
- eksportuj PPT do DOCX
- eksportuj PPTX do DOCX
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint PPT i PPTX na edytowalne dokumenty Word w C++ przy użyciu Aspose.Slides, zachowując dokładny układ, obrazy i formatowanie."
---
## **Wprowadzenie**

Jeśli planujesz wykorzystywać treść tekstową lub informacje z prezentacji (PPT lub PPTX) w nowy sposób, możesz skorzystać z konwersji prezentacji do Worda (DOC lub DOCX). 

* W porównaniu z Microsoft PowerPoint, aplikacja Microsoft Word oferuje więcej narzędzi i funkcji związanych z treścią. 
* Oprócz funkcji edycji w Wordzie, możesz również zyskać lepsze możliwości współpracy, drukowania i udostępniania. 

{{% alert color="primary" %}} 

Możesz wypróbować nasz [**Konwerter Prezentacji do Worda Online**](https://products.aspose.app/slides/pl/conversion/ppt-to-word), aby zobaczyć, co możesz zyskać, pracując z treścią tekstową slajdów. 

{{% /alert %}} 

## **Aspose.Slides i Aspose.Words**

Aby przekonwertować plik PowerPoint (PPTX lub PPT) na Word (DOC lub DOCX), potrzebujesz zarówno [Aspose.Slides for C++](https://products.aspose.com/slides/pl/cpp/) jak i [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Jako samodzielne API, [Aspose.Slides](https://products.aspose.app/slides) for C++ udostępnia funkcje pozwalające na wyodrębnianie tekstu z prezentacji. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) to zaawansowane API przetwarzania dokumentów, które umożliwia aplikacjom generowanie, modyfikowanie, konwertowanie, renderowanie, drukowanie plików oraz wykonywanie innych operacji na dokumentach bez użycia Microsoft Word.

## **Konwersja prezentacji PowerPoint na dokument Word**

Użyj poniższego fragmentu kodu, aby przekonwertować PowerPoint na Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generuje i wstawia obraz slajdu
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // wstawia teksty ze slajdu
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **FAQ**

**Jakie komponenty należy zainstalować, aby konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word?**

Wystarczy dodać odpowiednie pakiety dla [Aspose.Slides for C++](https://releases.aspose.com/slides/pl/cpp/) i [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) do swojego projektu. Obie biblioteki działają jako samodzielne API i nie wymagają instalacji Microsoft Office.

**Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?**

Aspose.Slides [obsługuje wszystkie formaty prezentacji](/slides/pl/cpp/supported-file-formats/), w tym PPT, PPTX, ODP oraz inne powszechne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.