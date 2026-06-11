---
title: Zarządzanie OLE w prezentacjach przy użyciu PHP
linktitle: Zarządzanie OLE
type: docs
weight: 40
url: /pl/php-java/manage-ole/
keywords:
- obiekt OLE
- Łączenie i osadzanie obiektów
- dodaj OLE
- osadź OLE
- dodaj obiekt
- osadź obiekt
- dodaj plik
- osadź plik
- połączony obiekt
- połączony plik
- zmień OLE
- ikona OLE
- tytuł OLE
- wyodrębnij OLE
- wyodrębnij obiekt
- wyodrębnij plik
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides for PHP via Java. Osadzaj, aktualizuj i eksportuj treść OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) to technologia firmy Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres ten jest następnie umieszczany w slajdzie programu PowerPoint. Ten wykres Excel jest uznawany za obiekt OLE. 

- Obiekt OLE może być wyświetlany jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres otwiera się w powiązanej aplikacji (Excel) lub pojawia się prośba o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoje rzeczywiste treści, takie jak zawartość wykresu. W takim przypadku wykres jest aktywowany w programie PowerPoint, ładuje się interfejs wykresu i można modyfikować dane wykresu w PowerPoint.

Aspose.Slides for PHP via Java umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for PHP via Java, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Odczytaj plik Excel jako tablicę bajtów.
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/) do slajdu, zawierając tablicę bajtów oraz inne informacje o obiekcie OLE.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for PHP via Java. **Uwaga**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu do osadzenia jako drugi parametr. To rozszerzenie pozwala PowerPointowi prawidłowo zinterpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Przygotuj dane dla obiektu OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Dodaj ramkę obiektu OLE do slajdu.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Dodawanie połączonych ramek obiektów OLE**

Aspose.Slides for PHP via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod PHP pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/) z połączonym plikiem Excel do slajdu:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE można wykonać dowolną operację.

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz jego danych plikowych.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Pobierz dane osadzonego pliku.
    // Pobierz rozszerzenie osadzonego pliku.
    // ...
}
```

### **Dostęp do właściwości połączonych ramek obiektów OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonych ramek obiektów OLE.

Ten kod PHP pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Wypisz pełną ścieżkę do połączonego pliku.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Wypisz względną ścieżkę do połączonego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Zmiana danych obiektu OLE**

{{% alert color="primary" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu przez jego indeks.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE można wykonać dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i modyfikuje się dane plikowe, aby zaktualizować dane wykresu.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modyfikuj dane skoroszytu.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Zmień dane obiektu ramki OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for PHP via Java umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie lub pojawia się prośba o wybranie odpowiedniego programu do jego otwarcia.

Ten kod PHP pokazuje, jak osadzić HTML i ZIP w slajdzie:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może zajść potrzeba zastąpienia starych obiektów OLE nowymi lub wymiany nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for PHP via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Ten kod PHP pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Zmień typ pliku na ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE podgląd składający się z obrazu ikony jest dodawany automatycznie. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów w podglądzie, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for PHP via Java.

Ten kod PHP pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Dodaj obraz do zasobów prezentacji.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Zapobiegaj zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w programie PowerPoint może pojawić się komunikat z prośbą o aktualizację linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu tego komunikatu i aktualizacji danych obiektu, ustaw metodę `setUpdateAutomatic` klasy [OleObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/) na `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for PHP via Java umożliwia wyodrębnienie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Iteruj po wszystkich kształtach w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleobjectframe/).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod PHP pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane — ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym pliku PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przesuwać/edytować w programie PowerPoint?**

Zablokuj kształt: Aspose.Slides oferuje blokady na poziomie kształtu. Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Czy względne ścieżki do połączonych obiektów OLE będą zachowane w formacie PPTX?**

W formacie PPTX informacja o „względnej ścieżce” nie jest dostępna — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać pewnych ścieżek bezwzględnych / dostępnych URI lub osadzania.