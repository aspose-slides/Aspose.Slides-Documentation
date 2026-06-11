---
title: Zarządzanie OLE w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Node.js via Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) jest technologią firmy Microsoft, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w MS Excel. Wykres jest następnie umieszczany w slajdzie PowerPoint. Ten wykres Excel jest traktowany jako obiekt OLE. 

- Obiekt OLE może być wyświetlany jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel), lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, interfejs wykresu się ładuje i możesz modyfikować dane wykresu w ramach PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/pl/nodejs-java/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleObjectFrame)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Node.js via Java, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
1. Uzyskaj odniesienie do slajdu przez jego indeks.
1. Odczytaj plik Excel jako tablicę bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleObjectFrame) do slajdu, podając tablicę bajtów i inne informacje o obiekcie OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Node.js via Java.
**Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleEmbeddedDataInfo) przyjmuje rozszerzenie obiektu, które można osadzić, jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Przygotuj dane dla obiektu OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Dodawanie połączonych ramek obiektów OLE**

Aspose.Slides for Node.js via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleObjectFrame) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod JavaScript pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleObjectFrame) z połączonym plikiem Excel do slajdu:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Uzyskiwanie dostępu do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/OleObjectFrame). W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma tylko jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację.

W poniższym przykładzie dostęp do ramki obiektu OLE (osadzonego obiektu wykresu Excel w slajdzie) oraz jego danych plikowych jest uzyskany.

```javascript
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

### **Uzyskiwanie właściwości połączonych ramek obiektów OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonych ramek obiektów OLE.

Ten kod JavaScript pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (oleFrame.isObjectLink()) {
        // Wypisz pełną ścieżkę do połączonego pliku.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Wypisz względną ścieżkę do połączonego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Zmiana danych obiektu OLE**

{{% alert color="primary" %}} 

W tej sekcji przykładowy kod poniżej używa [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Uzyskaj dostęp do kształtu ramki obiektu OLE. W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma jeden kształt na pierwszym slajdzie.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie ramka obiektu OLE (osadzony obiekt wykresu Excel w slajdzie) jest dostępna, a jej dane plikowe są modyfikowane w celu zaktualizowania danych wykresu.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modyfikuj dane skoroszytu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Zmień dane obiektu ramki OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for Node.js via Java umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawić pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, automatycznie otwiera się w odpowiednim programie lub użytkownik zostaje poproszony o wybranie odpowiedniego programu do jego otwarcia.

Ten kod JavaScript pokazuje, jak osadzić HTML i ZIP w slajdzie:

```javascript
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

Podczas pracy z prezentacjami możesz potrzebować zastąpić stare obiekty OLE nowymi lub zastąpić nieobsługiwany obiekt OLE obsługiwanym. Aspose.Slides for Node.js via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Ten kod JavaScript pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for Node.js via Java.

Ten kod JavaScript pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```javascript
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

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint możesz zobaczyć komunikat z prośbą o aktualizację linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, użyj metody `setUpdateAutomatic` klasy [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) z wartością `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for Node.js via Java umożliwia wyodrębnianie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającą obiekty OLE, które chcesz wyodrębnić.
2. Iteruj po wszystkich kształtach w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod JavaScript pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```javascript
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

**Czy zawartość OLE będzie renderowana podczas eksportu slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane — ikona/obraz zastępczy (podgląd). Żywa zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides oferuje blokady na poziomie kształtu. To nie jest szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Czy względne ścieżki dla połączonych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacja o „względnej ścieżce” nie jest dostępna — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać pewnych ścieżek bezwzględnych/ dostępnych URI lub osadzania.