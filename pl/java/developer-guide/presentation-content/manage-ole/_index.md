---
title: Zarządzanie OLE w prezentacjach przy użyciu Javy
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w PowerPoint i plikach OpenDocument przy użyciu Aspose.Slides for Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) jest technologią firmy Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji przy użyciu łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres ten jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uważany za obiekt OLE. 

- Obiekt OLE może pojawić się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w skojarzonej aplikacji (Excel) lub pojawia się prośba o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym wypadku wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu bezpośrednio w PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/pl/java/) pozwala wstawiać obiekty OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleObjectFrame)).

## **Dodaj ramki obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Java, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). 
1. Pobierz referencję do slajdu za pomocą jego indeksu. 
1. Odczytaj plik Excel jako tablicę bajtów. 
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleObjectFrame) do slajdu, przekazując tablicę bajtów oraz inne informacje o obiekcie OLE. 
1. Zapisz zmodyfikowaną prezentację jako plik PPTX. 

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Java.  
**Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleEmbeddedDataInfo) przyjmuje rozszerzenie osadzanego obiektu jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać właściwą aplikację do otwarcia tego obiektu OLE.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Przygotuj dane dla obiektu OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Dodaj ramkę obiektu OLE do slajdu.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Dodaj połączone ramki obiektów OLE**

Aspose.Slides for Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleObjectFrame) bez osadzania danych, a jedynie z odnośnikiem do pliku.

Poniższy kod Java pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleObjectFrame) z połączonym plikiem Excel do slajdu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Uzyskaj dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). 
2. Pobierz referencję do slajdu, używając jego indeksu. 
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OleObjectFrame).  
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *rzuciliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IOleObjectFrame). To była pożądana ramka obiektu OLE, do której mieliśmy dostęp. 
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację. 

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego obiektu wykresu Excel na slajdzie) oraz do danych pliku.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Pobierz dane osadzonego pliku.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Pobierz rozszerzenie osadzonego pliku.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Uzyskaj dostęp do właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonej ramki obiektu OLE.  

Poniższy kod Java pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (oleFrame.isObjectLink()) {
        // Wyświetl pełną ścieżkę do połączonego pliku.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Wyświetl względną ścieżkę do połączonego pliku, jeśli jest dostępna.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Zmień dane obiektu OLE**

{{% alert color="info" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}} 

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). 
2. Pobierz referencję do slajdu przez jego indeks. 
3. Uzyskaj dostęp do kształtu ramki obiektu OLE.  
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *rzuciliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IOleObjectFrame). To była pożądana ramka obiektu OLE, do której mieliśmy dostęp. 
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację. 
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE. 
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane. 
7. Zapisz zaktualizowany `Workbook` w strumieniu. 
8. Zmień dane obiektu OLE z tego strumienia. 

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego obiektu wykresu Excel na slajdzie) i modyfikuje się dane pliku, aby zaktualizować dane wykresu.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modyfikuj dane skoroszytu.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Zmień dane obiektu ramki OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Osadź inne typy plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for Java pozwala osadzać w slajdach inne typy plików. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub pojawia się prośba o wybranie odpowiedniego programu do jego otwarcia.

Poniższy kod Java pokazuje, jak osadzić HTML i ZIP w slajdzie:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ustaw typy plików dla osadzonych obiektów**

Pracując z prezentacjami, możesz potrzebować zastąpić stare obiekty OLE nowymi lub zamienić nieobsługiwany obiekt OLE na obsługiwany. Aspose.Slides for Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Poniższy kod Java pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ustaw obrazy ikony i tytuły dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co widzą użytkownicy przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł za pomocą Aspose.Slides for Java.

Poniższy kod Java pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Dodaj obraz do zasobów prezentacji.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Ustaw tytuł i obraz dla podglądu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zapobiegaj zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat proszący o aktualizację łączy. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw metodę `setUpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleobjectframe/) na `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Wyodrębnij osadzone pliki**

Aspose.Slides for Java umożliwia wyodrębnienie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) zawierającej obiekty OLE, które chcesz wyodrębnić. 
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe). 
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku. 

Poniższy kod Java pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

### Czy zawartość OLE będzie renderowana podczas eksportu slajdów do PDF/obrazów?

Renderowana jest to, co jest widoczne na slajdzie — ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

### Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?

Zablokuj kształt: Aspose.Slides udostępnia [shape-level locks](/slides/pl/java/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczeniom.

### Dlaczego połączony obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?

PowerPoint może odświeżać podgląd połączonego OLE. Aby uzyskać stabilny wygląd, stosuj wytyczne z [Working Solution for Worksheet Resizing](/slides/pl/java/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

### Czy ścieżki względne dla połączonych obiektów OLE będą zachowane w formacie PPTX?

W PPTX informacje o „ścieżce względnej” nie są dostępne — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać rzetelnych ścieżek bezwzględnych/ Dostępnych URI lub osadzania.