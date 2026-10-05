---
title: Zarządzaj obiektami OLE w prezentacjach w .NET
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/net/manage-ole/
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
- .NET
- C#
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) jest technologią Microsoftu, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres ten jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uważany za obiekt OLE. 

- Obiekt OLE może być wyświetlany jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres otwiera się w powiązanej aplikacji (Excel) lub wyświetlane jest zapytanie o wybór aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, interfejs wykresu ładuje się i można modyfikować dane wykresu bezpośrednio w PowerPoint.

[Aspose.Slides dla .NET](https://products.aspose.com/slides/net/) pozwala wstawiać obiekty OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Dodaj ramki obiektów OLE do slajdów**

Zakładając, że utworzyłeś już wykres w programie Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides dla .NET, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu przez jego indeks.
3. Odczytaj plik Excel jako tablicę bajtów.
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) do slajdu, przekazując tablicę bajtów oraz inne informacje o obiekcie OLE.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) przy użyciu Aspose.Slides dla .NET.  
**Uwaga** że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie osadzanego obiektu jako drugi parametr. To rozszerzenie pozwala PowerPoint poprawnie zinterpretować typ pliku i wybrać właściwą aplikację do otwarcia tego obiektu OLE.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

### **Dodaj ramki połączonych obiektów OLE**

Aspose.Slides dla .NET pozwala dodać [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) bez osadzania danych, a jedynie z odnośnikiem do pliku.

Ten kod w C# pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) z połączonym plikiem Excel do slajdu:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo go znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *cast* (rzutujemy) ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.

W poniższym przykładzie dostęp do ramki obiektu OLE (osadzony w slajdzie obiekt wykresu Excel) oraz jego danych plikowych jest uzyskany.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz pierwszy kształt jako ramkę obiektu OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Pobierz dane osadzonego pliku.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Pobierz rozszerzenie osadzonego pliku.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Dostęp do właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonej ramki obiektu OLE.

Ten kod w C# pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz pierwszy kształt jako ramkę obiektu OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Sprawdź, czy obiekt OLE jest połączony.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Wypisz pełną ścieżkę do połączonego pliku.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Wypisz względną ścieżkę do połączonego pliku, jeśli istnieje.
        // Tylko prezentacje PPT mogą zawierać względną ścieżkę.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Zmień dane obiektu OLE**

{{% alert color="info" title="Note" %}}

W tej sekcji poniższy przykład kodu wykorzystuje [Aspose.Cells dla .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu przez jego indeks. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *cast* (rzutujemy) ten obiekt jako [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której chcieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanej `Worksheet` i zmodyfikuj dane.
7. Zapisz zaktualizowany `Workbook` w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie dostęp do ramki obiektu OLE (osadzony w slajdzie obiekt wykresu Excel) jest uzyskany, a jego dane plikowe są modyfikowane w celu aktualizacji danych wykresu.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Zmodyfikuj dane skoroszytu.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

## **Osadzaj inne typy plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides dla .NET pozwala osadzać inne typy plików w slajdach. Na przykład można wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub wyświetlane jest zapytanie o wybranie odpowiedniego programu do otwarcia.

Ten kod w C# pokazuje, jak osadzić HTML i ZIP w slajdzie:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

Podczas pracy z prezentacjami możesz potrzebować zamienić stare obiekty OLE na nowe lub zastąpić nieobsługiwany obiekt OLE obsługiwanym. Aspose.Slides dla .NET umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Ten kod w C# pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed uzyskaniem dostępu lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony oraz tytuł przy użyciu Aspose.Slides dla .NET.

Ten kod w C# pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o aktualizację łączy. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw właściwość `UpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Zachowaj rozmiar i pozycję ramki obiektu OLE, gdy PowerPoint aktualizuje łącze.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Wyodrębnij osadzone pliki**

Aspose.Slides dla .NET pozwala wyodrębnić pliki osadzone w slajdach jako obiekty OLE w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysk.

Ten kod w C# pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```c#
using Aspose.Slides;

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

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do plików PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane – ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

Aby również zachować osadzony plik jako załącznik PDF, ustaw [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`. Opcja jest domyślnie wyłączona. Przykład i instrukcje sprawdzania załącznika znajdziesz w [Preserve Embedded OLE Files as PDF Attachments](/slides/pl/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przesuwać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [shape-level locks](/slides/pl/net/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego połączony obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd połączonego OLE. Aby uzyskać stabilny wygląd, stosuj zalecenia z [Working Solution for Worksheet Resizing](/slides/pl/net/working-solution-for-worksheet-resizing/) – dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy ścieżki względne dla połączonych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacje o „ścieżce względnej” nie są dostępne – tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać pewnych ścieżek bezwzględnych/dostępnych adresów URL albo osadzania.