---
title: Zarządzanie ramkami audio w prezentacjach w .NET
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/net/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj audio
- właściwości audio
- opcje audio
- eksportuj audio
- .NET
- C#
- Aspose.Slides
description: "Osadź dźwięk na slajdach, zmień ikonkę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów przy użyciu Aspose.Slides for .NET."
---
## **Przegląd**

Ramka audio umożliwia odtwarzanie dźwięku na slajdzie. Dzięki Aspose.Slides for .NET możesz osadzić klip audio, wybrać obraz go reprezentujący, dostosować odtwarzanie i dołączyć napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Utworzenie ramek audio**

Użyj [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwa współrzędne określają położenie ramki na slajdzie, a kolejne dwa wartości ustalają jej szerokość i wysokość, wszystko w punktach. Ten przykład ustawia [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) tak, aby klip uruchamiał się automatycznie oraz [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) na wysoką wartość.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```
## **Zmiana miniaturki ramki audio**

Domyślnie ramka audio wyświetla ikonę głośnika. Aby wyświetlić własną miniaturkę, dodaj obraz do prezentacji za pomocą [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) i przypisz go do właściwości [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) ramki. Przykład używa pliku JPEG jako miniaturki dla osadzonego klipu audio.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```
## **Zmiana opcji odtwarzania audio**

Elementy sterujące **Audio Options** w programie PowerPoint określają, kiedy klip się rozpoczyna, jak głośno brzmi i jak zachowuje się podczas pokazu slajdów.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides property |
| --- | --- |
| Rozpocznij | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Ustawienie głośności | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Odtwarzaj na wielu slajdach | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Powtarzaj aż zatrzymane | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Ukryj podczas pokazu | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Przewiń po odtworzeniu | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Płynne pojawienie | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Płynne zniknięcie | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Przytnij początkowy czas audio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Przytnij końcowy czas audio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Suwak głośności | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, ustawia [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) tak, aby odtwarzanie rozpoczynało się po kliknięciu, i wybiera niskie ustawienie głośności. Klip kontynuuje odtwarzanie na kolejnych slajdach przy wyłączonym powtarzaniu. Ikona pozostaje ukryta podczas pokazu, a klip jest przewijany po odtworzeniu.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```
Dla klipu trwającego ponad 3,5 sekundy, ten przykład pomija pierwsze 1,5 sekundy i ostatnie 2 sekundy. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mierzy czas do pominięcia na końcu klipu. Aby uzyskać czas końcowy wyświetlany w programie PowerPoint, odejmij ten offset od całkowitej długości klipu. Przycięty klip pojawia się płynnie w ciągu 200 milisekund i zanika w ciągu 500 milisekund. Wszystkie cztery właściwości przyjmują wartości w milisekundach.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```
Aby ustawić głośność odtwarzania na określony procent, użyj [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Ten przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```
## **Zarządzanie napisami audio**

Każda ramka audio posiada kolekcję [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Użyj jej do dołączania napisów WebVTT do klipu, eksportowania istniejących ścieżek lub ich usuwania.

### **Dodawanie napisów audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi wskazuje plik zawierający napisy ze znacznikami czasowymi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```
### **Eksportowanie napisów audio**

Ten przykład eksportuje każdą ścieżkę napisów podłączoną do ramki audio na pierwszym slajdzie. Zapisuje [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) ścieżki do pliku WebVTT i używa jej [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) jako nazwy pliku, aby każda ścieżka miała oddzielny wynik.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```
### **Usuwanie napisów audio**

Użyj [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) aby usunąć pojedynczą ścieżkę. Przykład używa [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```
### **Znajdowanie linii w napisach audio**

Aby znaleźć linię w napisach audio na pierwszym slajdzie, wczytaj w pamięci [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) każdej ścieżki. W czystym tekście wskazówki WebVTT linia z czasem zawiera `-->`, linie napisów następują po niej, a pusty wiersz kończy wskazówkę. Ten przykład wypisuje etykietę ścieżki oraz każdą linię napisu zawierającą „café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```
## **Eksportowanie audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, odczytaj właściwość [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) przejścia. Przykład uzyskuje dostęp do [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) dźwięku i wypisuje jego rozmiar w bajtach. Jeśli pierwszy slajd nie ma dźwięku przejścia, wypisuje komunikat.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```
## **FAQ**

**Czy mogę używać tego samego klipu audio na wielu slajdach bez jego duplikowania?**

Tak. Dodaj klip raz do [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) prezentacji i przekaż ten sam obiekt audio do [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) dla każdego slajdu.

**Czy mogę zamienić dźwięk w istniejącej ramce audio?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) tak, aby wskazywał na plik zastępczy. W przypadku dźwięku osadzonego, przypisz inny klip z kolekcji audio prezentacji do [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) i [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) ustalają granice odtwarzania. Nadal możesz pobrać pełny klip z [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).