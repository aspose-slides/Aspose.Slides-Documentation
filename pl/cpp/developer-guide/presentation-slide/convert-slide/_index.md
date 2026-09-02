---
title: Konwersja slajdów prezentacji na obrazy w C++
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/cpp/convert-slide/
keywords:
- konwertowanie slajdu
- eksport slajdu
- slajd na obraz
- zapisz slajd jako obraz
- slajd do EMF
- slajd do PNG
- slajd do JPEG
- slajd do bitmapy
- slajd do TIFF
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF i inne formaty obrazów w C++ z użyciem Aspose.Slides for C++."
---
## **Wprowadzenie**

Aspose.Slides for C++ może renderować poszczególne slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazów.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. Jeśli to konieczne, skonfiguruj renderowanie przy użyciu klasy [RenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/).
4. Wywołaj metodę [ISlide::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/).
5. Wywołaj metodę [IImage::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/) i określ format wyjściowy przy pomocy wartości [ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/).

## **Konwersja slajdu do obrazu PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Otrzymany obiekt [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład w C++ renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konwersja slajdów do obrazów o niestandardowych rozmiarach**

Użyj przeciążenia [ISlide::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/), które akceptuje wartość [Size](https://reference.aspose.com/slides/pl/cpp/system.drawing/size/), aby renderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konwersja slajdów z notatkami i komentarzami do obrazów**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przypisz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/) do metody [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/), aby kontrolować, gdzie pojawiają się notatki i komentarze.

Poniższy przykład umieszcza obcięte notatki pod slajdem oraz komentarze po jego prawej stronie:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz nie ustawiaj metody [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) na wartość [BottomFull](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notespositions/). Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Użyj zamiast tego [BottomTruncated](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Konwersja slajdów do obrazów przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/) umożliwia kontrolowanie rozmiaru, rozdzielczości i innych właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF 2160 × 2880 przy 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konwersja wszystkich slajdów do obrazów**

Iteruj po kolekcji slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pomijasz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG ze współczynnikami skalowania poziomego i pionowego równymi 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi metafile Windows. W odróżnieniu od obrazu rastrowego, EMF może zachować operacje rysowania wektorowego, które skaluje się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Ponadto złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz wektorowego kontenera metafile.

### **Eksport slajdu do EMF**

Metoda [ISlide::WriteAsEmf](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/writeasemf/) zapisuje [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Wywołujący jest właścicielem strumienia przekazanego do [ISlide::WriteAsEmf](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/writeasemf/) i musi go zamknąć lub zwolnić. Aspose.Slides zapisuje w bieżącej pozycji strumienia i pozostawia go otwartym.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/writeasemf/) aby przekonwertować zawartość SVG na EMF. Uzyskane bajty można dodać do prezentacji za pomocą [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/) i umieścić na slajdzie przy pomocy [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addpictureframe/).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/svgimage/) z kodu SVG, konwertuje go do EMF w pamięci, wstawia metafile na pierwszym slajdzie i zapisuje prezentację:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/writeasemf/) nie przejmuje własności strumienia docelowego. Po zapisie pozycja strumienia znajduje się na końcu wygenerowanych danych. Przykład wywołuje [MemoryStream::ToArray](https://reference.aspose.com/slides/pl/cpp/system.io/memorystream/toarray/) aby uzyskać pełny bufor niezależnie od bieżącej pozycji strumienia, a następnie przekazuje tę tablicę bajtów do [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/). Trzymaj strumień otwarty, dopóki konsument nie skończy go czytać, a następnie zamknij go.

Generowanie EMF jest dostępne na systemach operacyjnych obsługiwanych przez Aspose.Slides for C++, ale renderowanie może różnić się między platformami, gdy czcionki lub natywne zależności graficzne są niedostępne. Zainstaluj czcionki użyte w źródłowej zawartości lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [platform requirements](/slides/pl/cpp/system-requirements/) dla Aspose.Slides for C++ i zweryfikuj wynik w docelowej aplikacji obsługującej EMF. Aplikacje na Linuxie i macOS często mają ograniczoną lub niejednolito obsługę wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby poprawnie renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą być wyświetlane w odcieniach szarości w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**  
Nie. Metoda [ISlide::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**  
Tak. Ukryte slajdy mogą być renderowane tak jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**  
Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.