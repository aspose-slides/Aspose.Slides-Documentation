---
title: "Zarządzanie obiektami OLE w prezentacjach w .NET"
linktitle: "Zarządzaj OLE"
type: docs
weight: 40
url: /pl/net/manage-ole/
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
- .NET
- C#
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Osadzaj, aktualizuj i eksportuj treść OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) to technologia firmy Microsoft, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji za pomocą łączenia lub osadzania. 

{{% /alert %}} 

Rozważmy wykres utworzony w MS Excel. Wykres jest następnie umieszczany w slajdzie PowerPointa. Ten wykres Excel jest uznawany za obiekt OLE. 

- Obiekt OLE może wyświetlać się jako ikona. W takim przypadku podwójne kliknięcie ikony otwiera wykres w powiązanej aplikacji (Excel) lub pojawia się komunikat z prośbą o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać rzeczywistą zawartość, np. zawartość wykresu. Wtedy wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i można modyfikować dane wykresu w PowerPoint. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe)).

## **Dodaj ramki obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for .NET, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Odczytaj plik Excel jako tablicę bajtów.
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) do slajdu zawierającego tablicę bajtów i inne informacje o obiekcie OLE.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W przykładzie poniżej dodaliśmy wykres z pliku Excel do slajdu jako [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) przy użyciu Aspose.Slides for .NET.  
**Note** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu osadzalnego jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać właściwą aplikację do otwarcia tego obiektu OLE.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Przygotuj dane dla obiektu OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Dodaj ramkę obiektu OLE do slajdu.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Dodaj powiązane ramki obiektów OLE**

Aspose.Slides for .NET pozwala dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) bez osadzania danych, a jedynie z odnośnikiem do pliku.

Ten kod C# pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) z powiązanym plikiem Excel do slajdu:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.

W przykładzie poniżej dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz danych pliku jest uzyskany.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz pierwszy kształt jako ramkę obiektu OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Pobierz osadzone dane pliku.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Pobierz rozszerzenie osadzonego pliku.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Dostęp do właściwości powiązanej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości powiązanej ramki obiektu OLE.

Ten kod C# pokazuje, jak sprawdzić, czy obiekt OLE jest powiązany, a następnie uzyskać ścieżkę do powiązanego pliku:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz pierwszy kształt jako ramkę obiektu OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Sprawdź, czy obiekt OLE jest powiązany.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Wypisz pełną ścieżkę do powiązanego pliku.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Wypisz względną ścieżkę do powiązanego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Zmień dane obiektu OLE**

{{% alert color="primary" %}} 

W tej sekcji poniższy przykład kodu używa [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *cast* ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której uzyskano dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanego `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W przykładzie poniżej dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) jest uzyskany, a jego dane pliku są zmodyfikowane w celu aktualizacji danych wykresu.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz pierwszy kształt jako ramkę obiektu OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Odczytaj dane obiektu OLE jako obiekt Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Zmodyfikuj dane workbooka.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Zmień dane obiektu ramki OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Osadź inne typy plików w slajdach**

Poza wykresami Excel, Aspose.Slides for .NET umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik podwójnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub wyświetla się prośba o wybranie właściwego programu do otwarcia.

Ten kod C# pokazuje, jak osadzić HTML i ZIP w slajdzie:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ustaw typy plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może być konieczne zastąpienie starych obiektów OLE nowymi lub wymiana nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for .NET pozwala ustawić typ pliku dla osadzonego obiektu, umożliwiając aktualizację danych ramki OLE lub jej rozszerzenia.

Ten kod C# pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Zmień typ pliku na ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ustaw obrazy ikon i tytuły dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for .NET.

Ten kod C# pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Dodaj obraz do zasobów prezentacji.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Ustaw tytuł i obraz dla podglądu OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zapobiegaj zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, podczas otwierania prezentacji w PowerPoint może pojawić się komunikat z prośbą o aktualizację łączy. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw właściwość `UpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Wyodrębnij osadzone pliki**

Aspose.Slides for .NET umożliwia wyodrębnienie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod C# pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

**Czy zawartość OLE będzie renderowana podczas eksportu slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane — ikona/obraz zastępczy (podgląd). „Żywa” treść OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przemieszczać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [shape-level locks](/slides/pl/net/applying-protection-to-presentation/). To nie jest szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd powiązanego obiektu OLE. Aby uzyskać stabilny wygląd, zastosuj praktyki opisane w [Working Solution for Worksheet Resizing](/slides/pl/net/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy ścieżki względne dla powiązanych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacje o „ścieżce względnej” nie są dostępne — tylko pełna ścieżka. Ścieżki względne znajdują się w starszym formacie PPT. Dla przenośności zaleca się używanie pewnych ścieżek bezwzględnych / dostępnych URI lub osadzanie.