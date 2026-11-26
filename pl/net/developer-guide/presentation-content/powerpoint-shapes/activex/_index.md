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
- dodaj ActiveX
- modyfikuj ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie użyj kontrolki Windows Media Player w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET."
---
## **Wprowadzenie**

ActiveX controls dają slajdowi PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimediów. Aspose.Slides for .NET udostępnia kontrolki slajdu poprzez [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć ją.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby zbadać nieznany szablon, otwórz go do odczytu i iteruj po kontrolkach na każdym slajdzie. Przykład zgłasza numer slajdu, nazwę kontrolki, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), oraz każdą parę klucz-wartość w [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Odczytuje prezentację bez aktywacji kontrolek, wywoływania zdarzeń lub makr, zmieniania wartości ani zapisywania pliku.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Wybrany wynik z `ActiveX.pptm` pokazuje pole tekstowe i przycisk polecenia.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Pusta kolekcja właściwości pojawia się jako `[]`. Dla kontrolek używających binarnego przechowywania, `Properties` może zwrócić `null`, co jest wyświetlane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) po sprawdzeniu null. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikowanie kontrolek ActiveX**

Przykład zakłada prezentację z włączonymi makrami, zawierającą pole tekstowe o nazwie `TextBox1` i przycisk polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Używa [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) aby zmienić wartość pola tekstowego i podpis przycisku. Każda kontrolka ma także statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz plik PNG dla każdej kontrolki pokazujący zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy za pośrednictwem [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Przykład przesuwa każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, zmieniając jej [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Zapisuje zmodyfikowaną prezentację w formacie PPTM, a następnie używa [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) aby zapisać drugą kopię z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Dodanie kontrolki odtwarzacza multimediów ActiveX**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, rozpocznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wyniku. Wideo pozostaje zewnętrzne, więc wybierz ścieżkę, do której odtwarzacz ma dostęp podczas odtwarzania.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**  
Tak. Aspose.Slides może odczytywać i zapisywać kontrolki, w tym ich właściwości i pozycje, bez ich aktywacji.

**Czym kontrolki ActiveX różnią się od obiektów OLE?**  
Kontrolki ActiveX umożliwiają użytkownikom interakcję ze slajdem, na przykład wprowadzanie tekstu lub kliknięcie przycisku. [OLE object](/slides/pl/net/manage-ole/) pozwala slajdowi zawierać lub łączyć się z treścią zarządzaną przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX będą nadal wywoływać makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**  
Zapisz prezentację w formacie obsługującym makra, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla Windows może uruchamiać istniejące obsługi zdarzeń, gdy ustawienia zabezpieczeń zezwalają zarówno na kontrolki ActiveX, jak i na makra.