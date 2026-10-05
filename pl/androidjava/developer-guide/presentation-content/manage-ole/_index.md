---
title: Zarządzanie OLE w prezentacjach na Androidzie
linktitle: Zarządzanie OLE
type: docs
weight: 40
url: /pl/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie. Osadzaj, aktualizuj i eksportuj treść OLE bezproblemowo.
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) jest technologią firmy Microsoft, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji za pomocą łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres jest następnie umieszczany wewnątrz slajdu PowerPoint. Ten wykres Excela jest uważany za obiekt OLE. 

- Obiekt OLE może pojawić się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel) lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu.
- Obiekt OLE może wyświetlać swoje rzeczywiste zawartości, takie jak zawartość wykresu. W tym przypadku wykres jest aktywowany w programie PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) umożliwia wstawianie OLE Objects do slajdów jako OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Dodaj ramki obiektów OLE do slajdów**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for Android via Java, you can do it this way:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Odczytaj plik Excel jako tablicę bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) do slajdu, zawierając tablicę bajtów i inne informacje o obiekcie OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

In the example below, we added a chart from an Excel file to a slide as an OLE object frame using Aspose.Slides for Android via Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Przygotuj dane dla obiektu OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Dodaj ramkę obiektu OLE do slajdu.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Dodaj połączone ramki obiektów OLE**

Aspose.Slides for Android via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) bez osadzania danych, a jedynie z odwołaniem do pliku.

This Java code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) with a linked Excel file to a slide:

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

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

```java 
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

### **Uzyskaj właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonej ramki obiektu OLE.

This Java code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (oleFrame.isObjectLink()) {
        // Wypisz pełną ścieżkę do połączonego pliku.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Wypisz względną ścieżkę do połączonego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Zmień dane obiektu OLE**

{{% alert color="info" title="Note" %}}

In this section, the code example below uses [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do kształtu ramki obiektu OLE.  
   W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanej `Worksheet` i zmień dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.

```java 
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

    // Wczytaj dane obiektu OLE jako obiekt Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modyfikuj dane workbooka.
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

Besides Excel charts, Aspose.Slides for Android via Java umożliwia osadzenie innych typów plików w slajdach. Na przykład możesz wstawić pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie lub zostaje poproszony o wybranie odpowiedniego programu do otwarcia.

This Java code shows you how to embed HTML and ZIP into a slide:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **Ustaw typy plików dla osadzonych obiektów**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for Android via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

This Java code shows you how to set the file type for an embedded OLE object to `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Zmień typ pliku na ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ustaw obrazy ikon i tytuły dla osadzonych obiektów**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for Android via Java.

This Java code shows you how to set the icon image and title for an embedded object:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **Zapobiegaj zmianie rozmiaru i położenia ramki obiektu OLE**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, call the [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) method of the [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) interface with `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Wyodrębnij osadzone pliki**

Aspose.Slides for Android via Java umożliwia wyodrębnienie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Uzyskaj dostęp do danych osadzonych plików z ramek OLE i zapisz je na dysku.

This Java code shows you how to extract files embedded in a slide as OLE objects:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

**Will the OLE content be rendered when exporting slides to PDF/images?**

What is visible on the slide is rendered—the icon/substitute image (preview). The "live" OLE content is not executed during rendering. If needed, set your own preview image to ensure the expected appearance in the exported PDF.

To also preserve the embedded file as a PDF attachment, call [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) with `true`. This option is disabled by default. For an example and instructions for checking the attachment, see [Preserve Embedded OLE Files as PDF Attachments](/slides/pl/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

Lock the shape: Aspose.Slides provides shape-level locks. This is not encryption, but it effectively prevents accidental edits and movement.

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint may refresh the preview of the linked OLE. For a stable appearance, follow the [Working Solution for Worksheet Resizing](/slides/pl/androidjava/working-solution-for-worksheet-resizing/) practices—either fit the frame to the range, or scale the range to a fixed frame and set an appropriate substitute image.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

In PPTX, "relative path" information is not available—only the full path. Relative paths are found in the older PPT format. For portability, prefer reliable absolute paths/accessible URIs or embedding.