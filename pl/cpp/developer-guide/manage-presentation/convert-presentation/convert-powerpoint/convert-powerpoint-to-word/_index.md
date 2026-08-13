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
description: "Konwertuj slajdy PowerPoint PPT i PPTX na edytowalne dokumenty Word w C++ przy użyciu Aspose.Slides, zachowując precyzyjny układ, obrazy i formatowanie."
---
## **Wprowadzenie**

Jeśli planujesz wykorzystać treść tekstową lub informacje z prezentacji (PPT lub PPTX) w nowych sposób, możesz skorzystać z konwersji prezentacji do formatu Word (DOC lub DOCX).

* W porównaniu do Microsoft PowerPoint, aplikacja Microsoft Word oferuje więcej narzędzi i funkcji związanych z treścią.  
* Oprócz funkcji edycji w Wordzie, możesz również zyskać korzyści dzięki ulepszonym funkcjom współpracy, drukowania i udostępniania.

{{% alert color="info" %}} 

Możesz wypróbować nasz [**Konwerter prezentacji do Worda online**](https://products.aspose.app/slides/pl/conversion/ppt-to-word), aby zobaczyć, co możesz zyskać, pracując z tekstową zawartością slajdów. 

{{% /alert %}} 

## **Aspose.Slides i Aspose.Words**

Aby przekonwertować plik PowerPoint (PPTX lub PPT) na Word (DOCX lub DOC), potrzebujesz zarówno [Aspose.Slides for C++](https://products.aspose.com/slides/pl/cpp/) jak i [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Jako samodzielne API, [Aspose.Slides](https://products.aspose.app/slides) dla C++ udostępnia funkcje pozwalające wyodrębnić teksty z prezentacji.

[Aspose.Words](https://docs.aspose.com/words/cpp/) to zaawansowane API przetwarzania dokumentów, które umożliwia aplikacjom generowanie, modyfikowanie, konwertowanie, renderowanie, drukowanie plików oraz wykonywanie innych zadań związanych z dokumentami bez użycia Microsoft Word.

## **Konwersja prezentacji PowerPoint na dokument Word**

Użyj tego fragmentu kodu, aby skonwertować PowerPoint do Worda:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generuje obraz slajdu jako strumień bajtów
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // wstawia teksty slajdu
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

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Jakie komponenty muszą być zainstalowane, aby konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word?

Wystarczy dodać odpowiednie pakiety dla [Aspose.Slides for C++](https://releases.aspose.com/slides/pl/cpp/) i [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) do swojego projektu. Obie biblioteki działają jako samodzielne API i nie ma wymogu instalacji Microsoft Office.

### Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?

Aspose.Slides [obsługuje wszystkie formaty prezentacji](/slides/pl/cpp/supported-file-formats/), w tym PPT, PPTX, ODP i inne popularne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.