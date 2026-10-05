---
title: Zarządzanie OLE w prezentacjach przy użyciu PHP
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/php-java/manage-ole/
keywords:
- Obiekt OLE
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
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) to technologia firmy Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji za pomocą łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres z Excela jest traktowany jako obiekt OLE. 

- Obiekt OLE może pojawić się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres otwiera się w powiązanej aplikacji (Excel), lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu.
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W takim przypadku wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) pozwala wstawiać obiekty OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Dodaj ramki obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for PHP via Java, możesz zrobić to w ten sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Odczytaj plik Excel jako tablicę bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) do slajdu, zawierającego tablicę bajtów i inne informacje o obiekcie OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for PHP via Java. **Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu, które ma być osadzone, jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo interpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

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

### **Dodaj połączone ramki obiektów OLE**

Aspose.Slides for PHP via Java pozwala dodać [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) bez osadzania danych, a jedynie za pomocą linku do pliku.

Ten kod PHP pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) z połączonym plikiem Excel do slajdu:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo go znaleźć lub uzyskać dostęp w ten sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE, możesz wykonać na niej dowolną operację.

W poniższym przykładzie dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz jego danych plikowych jest uzyskany.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Pobierz dane osadzonego pliku.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Pobierz rozszerzenie osadzonego pliku.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Uzyskaj dostęp do właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonej ramki obiektu OLE.

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

## **Zmień dane obiektu OLE**

{{% alert color="info" title="Note" %}}

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu przez jego indeks.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE, możesz wykonać na niej dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanej `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i modyfikuje jego dane plikowe, aby zaktualizować dane wykresu.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

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

## **Osadź inne typy plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for PHP via Java umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawić pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie, lub użytkownik jest proszony o wybranie odpowiedniego programu do otworzenia go.

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

## **Ustaw typy plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może zajść potrzeba zamiany starych obiektów OLE na nowe lub zastąpienia nieobsługiwanego obiektu OLE obsługiwanym. Aspose.Slides for PHP via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

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

## **Ustaw obrazy ikon i tytuły dla osadzonych obiektów**

Po osadzeniu obiektu OLE, automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for PHP via Java.

Ten kod PHP pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Dodaj obraz do zasobów prezentacji.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Ustaw tytuł i obraz dla podglądu OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Zapobiegaj zmianie rozmiaru i przemieszczeniu ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, przy otwieraniu prezentacji w PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu takiego komunikatu, wywołaj metodę [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) klasy [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) z wartością `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Wyodrębnij osadzone pliki**

Aspose.Slides for PHP via Java umożliwia wyodrębnienie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Iteruj przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Uzyskaj dostęp do danych osadzonych plików z ramek OLE i zapisz je na dysku.

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

To, co jest widoczne na slajdzie, jest renderowane — ikona/obraz zastępczy (podgląd). „żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.  
Aby także zachować osadzony plik jako załącznik PDF, wywołaj [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) z wartością `true`. Ta opcja jest domyślnie wyłączona. Przykład i instrukcje sprawdzania załącznika znajdziesz w [Zachowaj osadzone pliki OLE jako załączniki PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przemieszczać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia blokady na poziomie kształtu. Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Czy względne ścieżki dla połączonych obiektów OLE będą zachowane w formacie PPTX?**

W formacie PPTX informacje o „względnej ścieżce” nie są dostępne — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać niezawodnych ścieżek bezwzględnych/dostępnych URI lub osadzania.