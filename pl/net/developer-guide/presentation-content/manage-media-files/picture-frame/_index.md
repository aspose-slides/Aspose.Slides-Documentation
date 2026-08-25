---
title: Zarządzanie klatkami obrazu w prezentacjach w .NET
linktitle: Klatka obrazu
type: docs
weight: 10
url: /pl/net/picture-frame/
keywords:
- klatka obrazu
- dodaj klatkę obrazu
- utwórz klatkę obrazu
- osadzony obraz
- powiązany obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- kompresuj obraz
- StretchOffset
- formatowanie klatki obrazu
- skala względna
- efekt obrazu
- proporcje
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz, formatuj, powiązuj, przycinaj, wyodrębniaj i kompresuj klatki obrazu w prezentacjach przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Klatka obrazu jest elementem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją kolekcję [Images](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/images/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, rotację, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu klatek obrazu.

Klatki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą także odwoływać się do obrazów powiązanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany, zanim zastosuje się formatowanie lub optymalizację.

## **Dodaj i sformatuj osadzony obraz**

Aby dodać osadzony obraz, wstaw dane obrazu do prezentacji i utwórz klatkę obrazu przy użyciu [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addpictureframe/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę o natywnych wymiarach obrazu i stosuje formatowanie linii oraz rotację:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Klatka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) udostępnia względne skalowanie szerokości i wysokości ramki. Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy przepływ pracy wymaga zachowania proporcji względem rozmiaru źródłowego obrazu zamiast ręcznego obliczania końcowych wymiarów.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Skala względna zmienia ustawienia skali ramki; nie powoduje ponownego próbkowania ani kompresji osadzonego obrazu.

## **Obrazy osadzone i powiązane**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz powiązany przechowuje ścieżkę do zewnętrznego pliku za pomocą linku [ISlidesPicture](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy powiązane mogą zmniejszyć objętość danych obrazu w pliku PPTX, ale wprowadzają zależność zewnętrzną. Powiązany plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, powiązany obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zwykle bardziej niezawodne.

### **Dodaj obraz powiązany**

Poniższy przykład tworzy klatkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie powiązań obrazów; powiązania wideo to osobny przepływ mediów i zostały celowo pominięte w tym przykładzie.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały plik PPTX z uszkodzonymi zależnościami obrazów jest zazwyczaj mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z klatek obrazu**

Zanim wyodrębnisz obraz z istniejącej prezentacji, sprawdź, czy kształt jest rzeczywiście [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Powiązane klatki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu używa [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) bezpośrednio i nie wymaga starszego wrappera systemowego. Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Zapisywanie przez [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnij obraz SVG**

Dla obrazu SVG, [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/). Dzięki temu możesz pobrać dane SVG bezpośrednio, zamiast rasteryzować obraz najpierw.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Zachowanie zawartości SVG jako SVG zachowuje wektorowe źródło wewnątrz prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, koniecznie renderują tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako identyczna kopia oryginalnego osadzonego SVG; użyj danych osadzonego [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) wtedy, gdy wymagany jest pierwotny zasób wektorowy.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [IPictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje klatkę obrazu i stosuje wartości przycięcia:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte regiony można fizycznie usunąć, jak opisano w następnej sekcji.

## **Usuń przycięte dane obrazu**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) usuwa dane obrazu znajdujące się poza aktualnym prostokątem przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji „uncrop”.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne klatki obrazu, te klatki wciąż potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF przy użyciu tej metody rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/compressimage/) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiarem lub przycięty oraz `false`, gdy nie było konieczne wprowadzenie zmian.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/net/aspose.slides.export/picturescompression/) wtedy, gdy wystarcza standardowa docelowa rozdzielczość:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Zamiast wartości wyliczeniowej można przekazać własną dodatnią wartość DPI, gdy wymagana jest konkretna rozdzielczość docelowa.

Kompresja jest przeznaczona dla obrazów rastrowych. Treść SVG i metafile nie jest zmniejszana przez ten workflow kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość w oparciu o największy rozmiar, w jakim obraz będzie rzeczywiście oglądany lub eksportowany, zamiast stosować najniższe DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Kompletny przepływ pracy obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy uporządkowane, inspekcję, usuwanie i weryfikację dwukierunkową znajduje się w [Image Transform Effects](/slides/pl/net/image-transform-effects/).

## **Zablokuj geometrię klatki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframelock/) kontrolują, które operacje edycji są wyłączone dla klatki obrazu. Na przykład blokada proporcji zachowuje proporcje kształtu podczas zmiany rozmiaru.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Blokada dotyczy samego kształtu klatki obrazu. Nie wymusza ona ponownego próbkowania ani trwałej zmiany proporcji obrazu źródłowego.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu to „stretch”, wartości stretch‑offset w [IPictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ograniczającego pola klatki obrazu. Dodatnie wartości procentowe tworzą wcięcie od krawędzi, a ujemne wartości tworzą występ.

To różni się od przycinania. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety stretch zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Używaj offsetów stretch do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Rozważania dotyczące przechowywania, rozmiaru pliku i eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie klatki obrazu traktowane są oddzielnie:

- **Obrazy osadzone** sprawiają, że prezentacja jest samodzielna i są najpewniejsze przy udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy powiązane** mogą utrzymać pakiet mniejszy, lecz prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo nie­destrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną wyraźnie usunięte lub usunięte w trakcie kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródła. Powinna być stosowana po ustaleniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać w formacie SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdów do formatu rastrowego zawsze konwertuje renderowany slajd do pikseli.
- **Powtarzające się obrazy** powinny wykorzystywać istniejący zasób [IPPImage] kiedy to możliwe, zamiast wielokrotnie ładować ten sam plik w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazu jest najskuteczniejsza przy selektywnym podejściu: zachowaj logotypy i diagramy jako treść wektorową, kompresuj fotografie zgodnie z rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między klatką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie ramki, takie jak rozmiar, rotacja, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy zamierzone jest przechowywanie plików obrazu poza PPTX i zewnętrzne lokalizacje mogą być utrzymane w sposób niezawodny.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podległe piksele. Użyj [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć zapisaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Przechowuj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak powinny być obsługiwane obrazy SVG?**

Zachowuj zawartość SVG jako SVG, gdy zależy Ci na wierności wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczytywaniu istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla klatki obrazu. Dopasowanie wzorca z [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) lub filtrowanie kolekcji kształtów po tym interfejsie unika nieprawidłowych rzutowań i pozwala kodowi obsłużyć slajdy, które nie zawierają klatek obrazu.