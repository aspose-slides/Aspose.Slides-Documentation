---
title: Zarządzanie obiektami OLE w prezentacjach w .NET
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
description: "Zoptymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) to technologia Microsoft, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie. 

{{% /alert %}} 

Rozważmy wykres utworzony w programie MS Excel. Wykres ten jest następnie umieszczany na slajdzie PowerPoint. Taki wykres Excel jest traktowany jako obiekt OLE. 

- Obiekt OLE może być wyświetlany jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony wykres otwiera się w powiązanej aplikacji (Excel) lub pojawia się prośba o wybranie aplikacji do otwarcia lub edycji obiektu. 
- Obiekt OLE może wyświetlać rzeczywistą zawartość, taką jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, ładuje się interfejs wykresu i możesz modyfikować dane wykresu bezpośrednio w PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/) umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w programie Microsoft Excel i chcesz osadzić go na slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for .NET, możesz to zrobić w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation). 
2. Pobierz referencję do slajdu za pomocą jego indeksu. 
3. Odczytaj plik Excel jako tablicę bajtów. 
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) do slajdu, przekazując tablicę bajtów oraz inne informacje o obiekcie OLE. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX. 

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) przy użyciu Aspose.Slides for .NET.  
**Uwaga**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie osadzanego obiektu jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

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

### **Dodawanie powiązanych ramek obiektów OLE**

Aspose.Slides for .NET pozwala dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) bez osadzania danych, jedynie z odwołaniem do pliku.

Poniższy kod C# pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) z połączonym plikiem Excel do slajdu:

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

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać dostęp w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation). 
2. Pobierz referencję do slajdu, używając jego indeksu. 
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe).  
   W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie *rzutowaliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której uzyskaliśmy dostęp. 
4. Gdy ramka obiektu OLE jest już dostępna, możesz wykonać na niej dowolną operację. 

W poniższym przykładzie uzyskiwany jest dostęp do ramki obiektu OLE (osadzony obiekt wykresu Excel na slajdzie) oraz do jego danych plikowych.

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

### **Dostęp do właściwości powiązanej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości powiązanej ramki obiektu OLE.

Poniższy kod C# pokazuje, jak sprawdzić, czy obiekt OLE jest powiązany, oraz jak uzyskać ścieżkę do połączonego pliku:

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

## **Zmiana danych obiektu OLE**

{{% alert color="info" %}} 

W tej sekcji poniższy przykład kodu wykorzystuje [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation). 
2. Pobierz referencję do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do kształtu [OLEObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe).  
   W naszym przykładzie użyliśmy wcześniej utworzonego PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie *rzutowaliśmy* ten obiekt na [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe). To była pożądana ramka obiektu OLE, do której uzyskaliśmy dostęp. 
4. Gdy ramka obiektu OLE jest już dostępna, możesz wykonać na niej dowolną operację. 
5. Utwórz obiekt `Workbook` i uzyskaj dostęp do danych OLE. 
6. Uzyskaj dostęp do żądanej `Worksheet` i zmień dane. 
7. Zapisz zaktualizowany `Workbook` w strumieniu. 
8. Zmien dane obiektu OLE z wykorzystaniem tego strumienia. 

W poniższym przykładzie uzyskiwany jest dostęp do ramki obiektu OLE (osadzony obiekt wykresu Excel na slajdzie) i modyfikowane są jego dane plikowe, aby zaktualizować dane wykresu.

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
                // Zmień dane skoroszytu.
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

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for .NET umożliwia osadzanie w slajdach innych typów plików. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub pojawia się prośba o wybranie odpowiedniego programu do otwarcia.

Poniższy kod C# pokazuje, jak osadzić HTML i ZIP w slajdzie:

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

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może zajść potrzeba zastąpienia starych obiektów OLE nowymi lub wymiany nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for .NET pozwala ustawić typ pliku dla osadzonego obiektu, umożliwiając aktualizację danych ramki OLE lub jej rozszerzenia.

Poniższy kod C# pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

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

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd to to, co użytkownicy widzą przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony oraz tytuł przy użyciu Aspose.Slides for .NET.

Poniższy kod C# pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu: 

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

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o aktualizację linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd. Aby zapobiec wyświetlaniu tego komunikatu, ustaw właściwość `UpdateAutomatic` interfejsu [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Zachowaj rozmiar i położenie ramki obiektu OLE, gdy PowerPoint aktualizuje link.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for .NET umożliwia wyodrębnianie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającą obiekty OLE, które chcesz wyodrębnić. 
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OLEObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe). 
3. Uzyskaj dostęp do danych osadzonych plików z ramek OLE i zapisz je na dysku. 

Poniższy kod C# pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

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

### Czy zawartość OLE będzie renderowana przy eksporcie slajdów do PDF/obrazów?

Rysowane jest to, co jest widoczne na slajdzie – ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

### Jak zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/net/applying-protection-to-presentation/). To nie jest szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

### Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?

PowerPoint może odświeżać podgląd powiązanego OLE. Aby uzyskać stabilny wygląd, stosuj praktyki opisane w [Rozwiązaniu dla zmiany rozmiaru arkusza](/slides/pl/net/working-solution-for-worksheet-resizing/) – dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

### Czy relatywne ścieżki do powiązanych obiektów OLE zostaną zachowane w formacie PPTX?

W PPTX informacje o „relatywnej ścieżce” nie są dostępne – przechowywana jest jedynie pełna ścieżka. Relatywne ścieżki występowały w starszym formacie PPT. Dla przenośności zaleca się używanie niezawodnych ścieżek bezwzględnych / dostępnych URI lub osadzanie.