---
title: Zarządzanie OLE w prezentacjach na Androidzie
linktitle: Zarządzanie OLE
type: docs
weight: 40
url: /pl/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w PowerPoint i plikach OpenDocument przy użyciu Aspose.Slides for Android via Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) to technologia firmy Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres ten jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uznawany za obiekt OLE. 

- Obiekt OLE może pojawiać się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres otwiera się w powiązanej aplikacji (Excel), lub zostaniesz poproszony o wybranie aplikacji do otwierania lub edytowania obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, np. zawartość wykresu. W takim przypadku wykres zostaje aktywowany w PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu w ramach PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/pl/androidjava/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleObjectFrame)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Android via Java, możesz zrobić to w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
1. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
1. Odczytaj plik Excel jako tablicę bajtów.  
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleObjectFrame) do slajdu, zawierając tablicę bajtów oraz inne informacje o obiekcie OLE.  
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Android via Java.  
**Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleEmbeddedDataInfo) przyjmuje rozszerzenie obiektu możliwego do osadzenia jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo interpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Przygotuj dane dla obiektu OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Dodawanie połączonych ramek obiektów OLE**

Aspose.Slides for Android via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleObjectFrame) bez osadzania danych, a jedynie z odnośnikiem do pliku.  

Poniższy kod Java pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleObjectFrame) z połączonym plikiem Excel do slajdu:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu, używając jego indeksu.  
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OleObjectFrame). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *rzuciliśmy* (cast) ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.  
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonywać dowolne operacje na niej.  

W poniższym przykładzie dostęp uzyskano do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz jego danych plikowych.

```java 
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

### **Dostęp do właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonych ramek obiektów OLE.  

Poniższy kod Java pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (oleFrame.isObjectLink()) {
        // Wyświetl pełną ścieżkę do połączonego pliku.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Wyświetl względną ścieżkę do połączonego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Zmiana danych obiektu OLE**

{{% alert color="primary" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}} 

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do kształtu OLE object frame. W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *rzuciliśmy* (cast) ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.  
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonywać dowolne operacje na niej.  
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.  
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane.  
7. Zapisz zaktualizowany `Workbook` w strumieniu.  
8. Zmień dane obiektu OLE ze strumienia.  

W poniższym przykładzie uzyskano dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i zmodyfikowano jego dane plikowe, aby zaktualizować dane wykresu.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Odczytaj dane obiektu OLE jako obiekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Zmodyfikuj dane skoroszytu.
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

## **Osadzanie innych typów plików w slajdach**

Poza wykresami Excel, Aspose.Slides for Android via Java umożliwia osadzanie innych rodzajów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie, lub użytkownik zostaje poproszony o wybranie odpowiedniego programu do otwarcia.

Poniższy kod Java pokazuje, jak osadzić HTML i ZIP w slajdzie:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami możesz potrzebować zastąpić stare obiekty OLE nowymi lub zamienić nieobsługiwany obiekt OLE na obsługiwany. Aspose.Slides for Android via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala na aktualizację danych ramki OLE lub jej rozszerzenia.

Poniższy kod Java pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```java
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

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć określonego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł za pomocą Aspose.Slides for Android via Java.

Poniższy kod Java pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Dodaj obraz do zasobów prezentacji.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Ustaw tytuł i obraz dla podglądu OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, podczas otwierania prezentacji w PowerPoint możesz zobaczyć komunikat z prośbą o zaktualizowanie linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu tego komunikatu i aktualizacji danych obiektu, ustaw metodę `setUpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioleobjectframe/) na `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for Android via Java umożliwia wyodrębnianie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej obiekty OLE, które chcesz wyodrębnić.  
2. Iteruj przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/oleobjectframe).  
3. Uzyskaj dostęp do danych osadzonych plików z ramek OLE i zapisz je na dysku.  

Poniższy kod Java pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?**

Renderowana jest to, co jest widoczne na slajdzie — ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przemieszczać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia blokady na poziomie kształtu. Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego połączony obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd połączonego OLE. Aby uzyskać stabilny wygląd, stosuj się do zaleceń zawartych w [Working Solution for Worksheet Resizing](/slides/pl/androidjava/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy względne ścieżki do połączonych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacje o „względnej ścieżce” nie są dostępne — zachowywana jest tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności zaleca się używanie niezawodnych ścieżek bezwzględnych/ dostępnych URI lub osadzanie.