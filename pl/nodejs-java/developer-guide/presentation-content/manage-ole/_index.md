---
title: Zarządzanie OLE w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/nodejs-java/manage-ole/
keywords:
- Obiekt OLE
- Łączenie i osadzanie obiektów
- dodaj OLE
- osadź OLE
- dodaj obiekt
- osadź obiekt
- dodaj plik
- osadź plik
- obiekt powiązany
- plik powiązany
- zmień OLE
- ikona OLE
- tytuł OLE
- wyodrębnij OLE
- wyodrębnij obiekt
- wyodrębnij plik
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Node.js via Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) to technologia Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji za pomocą łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uważany za obiekt OLE. 

- Obiekt OLE może pojawić się jako ikona. W takim przypadku po dwukrotnym kliknięciu ikony wykres zostaje otwarty w powiązanej aplikacji (Excel) lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu.
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W takim przypadku wykres jest aktywowany w programie PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) pozwala wstawiać obiekty OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Node.js via Java, możesz zrobić to w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. Uzyskaj referencję do slajdu za pomocą jego indeksu.
1. Odczytaj plik Excel jako tablicę bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) do slajdu, z tablicą bajtów i innymi informacjami o obiekcie OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Node.js via Java.
**Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) przyjmuje rozszerzenie obiektu możliwego do osadzenia jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać właściwą aplikację do otwarcia tego obiektu OLE.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Dodawanie powiązanych ramek obiektów OLE**

Aspose.Slides for Node.js via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod JavaScript pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) z połączonym plikiem Excel do slajdu:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Uzyskiwanie dostępu do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w ten sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Pobierz referencję do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.

W poniższym przykładzie uzyskiwany jest dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz do danych pliku.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Pobierz dane osadzonego pliku.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Pobierz rozszerzenie osadzonego pliku.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Uzyskiwanie właściwości powiązanej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości powiązanych ramek obiektów OLE.

Ten kod JavaScript pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Sprawdź, czy obiekt OLE jest powiązany.
    if (oleFrame.isObjectLink()) {
        // Wypisz pełną ścieżkę do powiązanego pliku.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Wypisz względną ścieżkę do powiązanego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Zmiana danych obiektu OLE**

{{% alert color="info" title="Note" %}}

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Pobierz referencję do slajdu przez jego indeks.
3. Uzyskaj dostęp do kształtu ramki obiektu OLE. W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanego `Worksheet` i zmień dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie uzyskiwany jest dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i modyfikowane są jego dane pliku, aby zaktualizować dane wykresu.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modyfikuj dane workbooka.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Zmień dane obiektu ramki OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for Node.js via Java umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie, lub użytkownik jest proszony o wybranie odpowiedniego programu do jego otwarcia.

Ten kod JavaScript pokazuje, jak osadzić HTML i ZIP w slajdzie:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może być konieczna wymiana starych obiektów OLE na nowe lub zamiana nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for Node.js via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Ten kod JavaScript pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Zmień typ pliku na ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE podgląd składający się z obrazu ikony jest dodawany automatycznie. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for Node.js via Java.

Ten kod JavaScript pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Dodaj obraz do zasobów prezentacji.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Ustaw tytuł i obraz dla podglądu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Zapobieganie zmianie rozmiaru i pozycji ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w programie PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie łączy. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, wywołaj metodę [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) klasy [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) z wartością `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for Node.js via Java umożliwia wyodrębnienie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) zawierającej obiekty OLE, które zamierzasz wyodrębnić.
2. Iteruj po wszystkich kształtach w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod JavaScript pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane — ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

Aby także zachować osadzony plik jako załącznik PDF, wywołaj [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) z wartością `true`. Opcja ta jest domyślnie wyłączona. Przykład i instrukcje sprawdzania załącznika znajdziesz w [Zachowanie osadzonych plików OLE jako załączników PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w programie PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia blokady na poziomie kształtu. Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczeniom.

**Czy ścieżki względne dla powiązanych obiektów OLE będą zachowane w formacie PPTX?**

W formacie PPTX informacje o „ścieżce względnej” nie są dostępne — jedynie pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać niezawodnych ścieżek bezwzględnych/dostępnych identyfikatorów URI lub osadzania.