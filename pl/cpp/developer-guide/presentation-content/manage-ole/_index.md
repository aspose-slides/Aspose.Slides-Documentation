---
title: Zarządzanie OLE w prezentacjach przy użyciu C++
linktitle: Zarządzanie OLE
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
description: "Optymalizuj zarządzanie obiektami OLE w programach PowerPoint i plikach OpenDocument przy użyciu Aspose.Slides dla C++. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wstęp**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) to technologia Microsoftu, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPointa. Ten wykres z Excela jest traktowany jako obiekt OLE. 

- Obiekt OLE może wyświetlać się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel) lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoje rzeczywiste treści, np. zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/pl/cpp/) umożliwia wstawianie obiektów OLE na slajdy jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/)).

{{% /alert %}} 

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już stworzyłeś wykres w Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for C++, możesz to zrobić w ten sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Odczytaj plik Excel jako tablicę bajtów. 
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) do slajdu, przekazując tablicę bajtów oraz inne informacje o obiekcie OLE. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX. 

W poniższym przykładzie dodaliśmy wykres z pliku Excel na slajd jako [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) przy użyciu Aspose.Slides for C++. **Uwaga**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu, które ma być osadzone, jako drugi parametr. To rozszerzenie pozwala PowerPointowi prawidłowo zinterpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

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

Aspose.Slides for C++ umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod C++ pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) z powiązanym plikiem Excel do slajdu:

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

Jeśli obiekt OLE jest już osadzony na slajdzie, możesz go łatwo znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu, używając jego indeksu. 
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/).
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *rzutowaliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp. 
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację. 

W poniższym przykładzie dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony na slajdzie) oraz jego danych plikowych jest uzyskany.

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

    // Pobierz dane osadzonego pliku.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Pobierz rozszerzenie osadzonego pliku.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

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

## **Zmiana danych obiektu OLE**

{{% alert color="info" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony na slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/).
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *rzutowaliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp. 
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację. 
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE. 
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane. 
7. Zapisz zaktualizowany `Workbook` do strumienia. 
8. Zmień dane obiektu OLE ze strumienia. 

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony na slajdzie) i modyfikuje jego dane plikowe, aby zaktualizować dane wykresu.

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

// Aspose.Cells for C++ musi być uruchomione przed użyciem jakichkolwiek jego typów.
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

    // Modyfikuj dane skoroszytu.
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

## **Osadzanie innych typów plików na slajdach**

Oprócz wykresów Excel, Aspose.Slides for C++ umożliwia osadzanie innych typów plików na slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie, lub użytkownik jest proszony o wybranie odpowiedniego programu do jego otwarcia.

Ten kod C++ pokazuje, jak osadzić HTML i ZIP na slajdzie:

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

Podczas pracy z prezentacjami może zajść potrzeba zamiany starych obiektów OLE na nowe lub zastąpienia nieobsługiwanego obiektu OLE obsługiwanym. Aspose.Slides for C++ umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

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

// Zmień typ pliku na ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd widzą użytkownicy przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony oraz tytuł przy użyciu Aspose.Slides for C++.

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

// Dodaj obraz do zasobów prezentacji.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Ustaw tytuł i obraz dla podglądu OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw metodę `set_UpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/) na `false`:

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

Aspose.Slides for C++ umożliwia wyodrębnienie plików osadzonych na slajdach jako obiektów OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) zawierającej obiekty OLE, które chcesz wyodrębnić. 
2. Iteruj po wszystkich kształtach w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/). 
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku. 

Ten kod C++ pokazuje, jak wyodrębnić pliki osadzone na slajdzie jako obiekty OLE:

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

### Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?

Renderowane jest to, co jest widoczne na slajdzie — ikona/obraz zastępczy (podgląd). „Na żywo” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

### Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/cpp/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczeniom.

### Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?

PowerPoint może odświeżać podgląd powiązanego OLE. Aby uzyskać stabilny wygląd, zastosuj praktyki opisane w [Working Solution for Worksheet Resizing](/slides/pl/cpp/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

### Czy ścieżki względne dla powiązanych obiektów OLE będą zachowane w formacie PPTX?

W formacie PPTX informacja o „ścieżce względnej” nie jest dostępna — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności zaleca się używanie niezawodnych ścieżek bezwzględnych/dostępnych URI lub osadzanie.