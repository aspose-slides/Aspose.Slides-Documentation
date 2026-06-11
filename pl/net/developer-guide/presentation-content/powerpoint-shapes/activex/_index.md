---
title: Zarządzanie kontrolkami ActiveX w prezentacjach w .NET
linktitle: ActiveX
type: docs
weight: 80
url: /pl/net/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikacja ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla .NET wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, dając programistom potężną kontrolę nad slajdami."
---
## **Wstęp**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides dla .NET umożliwia zarządzanie kontrolkami ActiveX, ale ich obsługa jest nieco trudniejsza i różni się od zwykłych obiektów kształtów w prezentacji. Od wersji Aspose.Slides dla .NET 6.9.0 komponent obsługuje zarządzanie kontrolkami ActiveX. Obecnie można uzyskać dostęp do już dodanej kontrolki ActiveX w prezentacji i modyfikować ją lub usuwać, korzystając z różnych jej właściwości. Pamiętaj, kontrolki ActiveX nie są kształtami i nie należą do IShapeCollection prezentacji, lecz do oddzielnego IControlCollection. Ten artykuł pokazuje, jak z nimi pracować.
## **Modyfikacja kontrolek ActiveX**
Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk polecenia na slajdzie:

1. Utwórz instancję klasy Presentation i wczytaj prezentację zawierającą kontrolki ActiveX.
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
1. Uzyskaj dostęp do kontrolki ActiveX TextBox1 przy użyciu obiektu ControlEx.
1. Zmień różne właściwości kontrolki ActiveX TextBox1, w tym tekst, czcionkę, wysokość czcionki oraz położenie ramki.
1. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
1. Zmień etykietę przycisku, czcionkę i położenie.
1. Przesuń położenie ramek kontrolek ActiveX.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy fragment kodu aktualizuje kontrolki ActiveX na slajdach prezentacji, jak pokazano poniżej.

```c#
// Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
ISlide slide = presentation.Slides[0];

// zmiana tekstu TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    //    zmiana obrazu zastępczego. PowerPoint zastąpi ten obraz podczas aktywacji ActiveX, więc czasami można pozostawić obraz niezmieniony.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// zmiana etykiety przycisku
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    //    zmiana obrazu zastępczego
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Przesunięcie ramek ActiveX o 100 punktów w dół
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Zapis prezentacji z edytowanymi kontrolkami ActiveX
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Teraz usuwanie kontrolek
slide.Controls.Clear();

// Zapis prezentacji z usuniętymi kontrolkami ActiveX
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Dodaj kontrolkę ActiveX Media Player**
Aby dodać kontrolkę ActiveX Media Player, wykonaj następujące kroki:

1. Utwórz instancję klasy Presentation i wczytaj przykładową prezentację zawierającą kontrolki ActiveX Media Player.
1. Utwórz instancję docelowej klasy Presentation i wygeneruj pustą prezentację.
1. Sklonuj slajd z kontrolką ActiveX Media Player w prezentacji szablonu do docelowej prezentacji.
1. Uzyskaj dostęp do sklonowanego slajdu w docelowej prezentacji.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
1. Uzyskaj dostęp do kontrolki ActiveX Media Player i ustaw ścieżkę do pliku wideo, korzystając z jej właściwości.
1. Zapisz prezentację do pliku PPTX.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation presentation = new Presentation("template.pptx");

// Utwórz pustą instancję prezentacji
Presentation newPresentation = new Presentation();

// Usuń domyślny slajd
newPresentation.Slides.RemoveAt(0);

// Sklonuj slajd z kontrolką Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę do wideo
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Zapisz prezentację
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX podczas odczytu i ponownego zapisu, jeśli nie mogą być uruchomione w środowisku .NET?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać oraz modyfikować ich właściwości i ramki; wykonywanie samych kontrolek nie jest wymagane do ich zachowania.

**Czym różnią się kontrolki ActiveX od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi, zarządzanymi kontrolkami (przyciski, pola tekstowe, odtwarzacz multimedialny), natomiast [OLE](/slides/pl/net/manage-ole/) odnosi się do osadzonych obiektów aplikacji (na przykład arkusz Excel). Są przechowywane i obsługiwane inaczej oraz mają różne modele właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejące oznaczenia i metadane; jednak zdarzenia i makra są uruchamiane tylko w programie PowerPoint w systemie Windows, gdy zabezpieczenia na to pozwalają. Biblioteka nie wykonuje VBA.