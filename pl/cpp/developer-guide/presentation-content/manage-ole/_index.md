---
title: Zarządzanie OLE w prezentacjach przy użyciu C++
linktitle: Zarządzanie OLE
type: docs
weight: 40
url: /pl/cpp/manage-ole/
keywords:
- Obiekt OLE
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
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Osadzaj, aktualizuj i eksportuj treść OLE bezproblemowo."
---
## **Wstęp**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) to technologia Microsoft, która pozwala umieszczać dane i obiekty utworzone w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres z Excela jest uważany za obiekt OLE. 

- Obiekt OLE może pojawiać się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel) lub wyświetlane jest zapytanie o wybór aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i można modyfikować dane wykresu w ramach PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/pl/cpp/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for C++, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Odczytaj plik Excel jako tablicę bajtów. 
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) do slajdu, zawierając tablicę bajtów oraz inne informacje o obiekcie OLE. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX. 

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) przy użyciu Aspose.Slides for C++. **Uwaga**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu do osadzenia jako drugi parametr. To rozszerzenie umożliwia PowerPoint poprawne rozpoznanie typu pliku i wybranie odpowiedniej aplikacji do otwarcia tego obiektu OLE.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Przygotuj dane dla obiektu OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Dodaj ramkę obiektu OLE do slajdu.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Dodawanie powiązanych ramek obiektów OLE**

Aspose.Slides for C++ umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) bez osadzania danych, ale jedynie z linkiem do pliku.

Poniższy kod C++ pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) z powiązanym plikiem Excel do slajdu:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony na slajdzie, możesz go łatwo odnaleźć lub uzyskać dostęp w następujący sposób:

1. Wczytaj prezentację zawierającą osadzony obiekt OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu, używając jego indeksu. 
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *rzucono* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp. 
4. Gdy ramka obiektu OLE zostanie uzyskana, możesz wykonać na niej dowolną operację. 

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego na slajdzie obiektu wykresu Excel) oraz jej danych plikowych.

``` cpp
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

Poniższy kod C++ pokazuje, jak sprawdzić, czy obiekt OLE jest powiązany, a następnie uzyskać ścieżkę do powiązanego pliku:

```cpp
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

{{% alert color="primary" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony na slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Wczytaj prezentację zawierającą osadzony obiekt OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj referencję do slajdu poprzez jego indeks. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *rzucono* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp. 
4. Gdy ramka obiektu OLE zostanie uzyskana, możesz wykonać na niej dowolną operację. 
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE. 
6. Uzyskaj dostęp do żądanego `Worksheet` i zmień dane. 
7. Zapisz zaktualizowany `Workbook` do strumienia. 
8. Zmień dane obiektu OLE ze strumienia. 

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego na slajdzie obiektu wykresu Excel) i modyfikuje się jej dane plikowe, aby zaktualizować dane wykresu.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Pobierz pierwszy kształt jako ramkę obiektu OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Zmodyfikuj dane skoroszytu.
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
```

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for C++ umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF oraz ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie lub wyświetlane jest zapytanie o wybranie odpowiedniego programu do otwarcia.

Poniższy kod C++ pokazuje, jak osadzić HTML i ZIP w slajdzie:

``` cpp
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

Podczas pracy z prezentacjami może być konieczne zastąpienie starych obiektów OLE nowymi lub wymiana nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for C++ umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Poniższy kod C++ pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

``` cpp
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

Po osadzeniu obiektu OLE, automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest widoczny dla użytkowników przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for C++.

Poniższy kod C++ pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Dodaj obraz do zasobów prezentacji.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zapobieganie zmianie rozmiaru i położenia ramki OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu tego komunikatu i aktualizacji danych obiektu, ustaw metodę `set_UpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/) na `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for C++ umożliwia wyodrębnianie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) zawierającej obiekty OLE, które zamierzasz wyodrębnić. 
2. Iteruj przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/). 
3. Uzyskaj dostęp do danych osadzonych plików z ramek OLE i zapisz je na dysk. 

Poniższy kod C++ pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

``` cpp
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

**Czy zawartość OLE zostanie wyrenderowana przy eksportowaniu slajdów do PDF/obrazów?**

Renderowana jest to, co jest widoczne na slajdzie – ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym pliku PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/cpp/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczeniom.

**Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd powiązanego obiektu OLE. Aby uzyskać stabilny wygląd, postępuj zgodnie z wytycznymi [Working Solution for Worksheet Resizing](/slides/pl/cpp/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub przeskaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy ścieżki względne do powiązanych obiektów OLE zostaną zachowane w formacie PPTX?**

W formacie PPTX informacje o „ścieżkach względnych” nie są dostępne – tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla większej przenośności lepiej używać niezawodnych ścieżek bezwzględnych/dostępnych URI lub osadzania.