---
title: Zarządzanie OLE w prezentacjach przy użyciu C++
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/cpp/manage-ole/
keywords:
- obiekt OLE
- Łączenie i osadzanie obiektów
- dodaj OLE
- osadź OLE
- dodaj obiekt
- osadź obiekt
- dodaj plik
- osadź plik
- powiązany obiekt
- powiązany plik
- zmień OLE
- ikona OLE
- tytuł OLE
- wyodrębnij OLE
- wyodrębnij obiekt
- wyodrębnij plik
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w PowerPoint i plikach OpenDocument przy użyciu Aspose.Slides dla C++. Osadzaj, aktualizuj i eksportuj zawartość OLE płynnie."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) to technologia Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji za pomocą łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uważany za obiekt OLE. 

- Obiekt OLE może być wyświetlany jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel) lub pojawia się prośba o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym wypadku wykres jest aktywowany w PowerPoint, interfejs wykresu się ładuje i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz go osadzić w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for C++, możesz zrobić to w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Odczytaj plik Excel jako tablicę bajtów.
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) do slajdu, zawierając tablicę bajtów oraz inne informacje o obiekcie OLE.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) przy użyciu Aspose.Slides for C++. **Uwaga**, że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu do osadzenia jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo rozpoznać typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Dodawanie powiązanych ramek obiektów OLE**

Aspose.Slides for C++ umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod C++ pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) z powiązanym plikiem Excel do slajdu:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.

W poniższym przykładzie dostęp uzyskano do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz do danych pliku.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Pobierz osadzone dane pliku.
    // Pobierz rozszerzenie osadzonego pliku.
    // ...
}
```

### **Dostęp do właściwości powiązanej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości powiązanej ramki obiektu OLE.

Ten kod C++ pokazuje, jak sprawdzić, czy obiekt OLE jest powiązany, a następnie uzyskać ścieżkę do powiązanego pliku:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Sprawdź, czy obiekt OLE jest powiązany.
    if (oleFrame->get_IsObjectLink())
    {
        // Wypisz pełną ścieżkę do powiązanego pliku.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Wypisz względną ścieżkę do powiązanego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Zmienianie danych obiektu OLE**

{{% alert color="info" title="Note" %}}

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanej `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie dostęp uzyskano do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i zmodyfikowano dane pliku, aby zaktualizować dane wykresu.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ musi być uruchomiony przed użyciem jakichkolwiek jego typów.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modyfikuj dane workbooka.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Zmień dane obiektu ramki OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Osadzanie innych typów plików w slajdach**

Poza wykresami Excel, Aspose.Slides for C++ umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub pojawia się prośba o wybranie odpowiedniego programu do otwarcia.

Ten kod C++ pokazuje, jak osadzić HTML i ZIP w slajdzie:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami możesz potrzebować zastąpić stare obiekty OLE nowymi lub wymienić nieobsługiwany obiekt OLE na obsługiwany. Aspose.Slides for C++ pozwala ustawić typ pliku dla osadzonego obiektu, umożliwiając aktualizację danych ramki OLE lub jej rozszerzenia.

Ten kod C++ pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie obrazów ikony i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd widzą użytkownicy przed uzyskaniem dostępu lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for C++.

Ten kod C++ pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, gdy otworzysz prezentację w PowerPoint, możesz zobaczyć komunikat z prośbą o aktualizację linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, wywołaj metodę [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) z wartością `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for C++ umożliwia wyodrębnianie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) zawierającej obiekty OLE, które zamierzasz wyodrębnić.
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod C++ pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**Czy zawartość OLE będzie renderowana podczas eksportowania slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane – ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

Aby również zachować osadzony plik jako załącznik PDF, wywołaj [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) z wartością `true`. Opcja ta jest domyślnie wyłączona. Przykład i instrukcje sprawdzania załącznika znajdziesz w [Zachowaj osadzone pliki OLE jako załączniki PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przesuwać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/cpp/applying-protection-to-presentation/). To nie jest szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd powiązanego OLE. Aby uzyskać stabilny wygląd, stosuj praktyki opisane w [Rozwiązanie działające przy zmianie rozmiaru arkusza](/slides/pl/cpp/working-solution-for-worksheet-resizing/) – dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy względne ścieżki dla powiązanych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacje o „względnej ścieżce” nie są dostępne – jedynie pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać niezawodnych ścieżek bezwzględnych/dostępnych URI lub osadzania.