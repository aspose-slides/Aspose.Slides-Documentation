---
title: Optymalizacja zarządzania obrazami w prezentacjach w .NET
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/net/image/
keywords:
- dodaj obraz
- dodaj obraz
- zastąp obraz
- kolekcja obrazów
- ramka obrazu
- obraz powiązany
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie wykorzystywać, łączyć, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET."
---
## **Wprowadzenie**

Aspose.Slides dla .NET udostępnia kilka sposobów pracy z obrazami, przy czym każdy z nich służy innemu celowi. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać go jako tła slajdu, łączyć się z obrazem zewnętrznym, zastąpić współdzielony zasób obrazu lub przekonwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazów i ich użyciu w całej prezentacji. Informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu znajdziesz w sekcji [Ramka obrazu](/slides/pl/net/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie są wymienne:

- Kolekcja obrazów prezentacji ([presentation image collection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection/)) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection.AddImage](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection/addimage/) aby dodać dane obrazu i uzyskać zasób [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).
- Ramka obrazu ([picture frame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/)) jest kształtem wyświetlającym obraz na slajdzie, układzie lub masterze. Użyj [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addpictureframe/) aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się jak ramka obrazu.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/replaceimage/) zastępuje zasób obrazu. Jeśli kilka elementów prezentacji korzysta z tego zasobu, wszystkie używają zamiennika.
- Konwersja SVG na kształty tworzy edytowalne kształty slajdu. Po konwersji zawartość nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji obrazów, otrzymaj [IPPImage], a następnie użyj tego zasobu w jednej lub wielu ramach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić lokalny obraz, odczytaj plik, dodaj jego dane do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego `IPPImage`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Gdy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty przy użyciu `HttpClient`, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu tak samo jak w przypadku obrazu lokalnego.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

W długotrwałych aplikacjach ponownie używaj `HttpClient` zamiast tworzyć nową instancję przy każdym żądaniu. Również weryfikuj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji jednokrotnie i ponownie użyj zwróconego [IPPImage](/slides/pl/net/ippimage/) przy tworzeniu kolejnych ramek obrazu. Zapobiega to wielokrotnemu ładowaniu tych samych danych źródłowych i wyraźnie określa związek między współdzielonym zasobem obrazu a jego użyciem.

Dla grafiki, która ma pojawiać się automatycznie na wielu slajdach, takiej jak logo firmy, rozważ umieszczenie ramki obrazu na [slide master](/slides/pl/net/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tła slajdu**

Obraz tła jest przypisany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jak zwykły obiekt slajdu.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Aby uzyskać dodatkowe opcje tła, w tym tła mastera i układów, zobacz [Presentation Background](/slides/pl/net/presentation-background/).

## **Obrazy osadzone i obrazy powiązane**

Obrazy osadzone i obrazy powiązane mają różne kompromisy dotyczące przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku obejmuje dane obrazu.
- **Obraz powiązany:** prezentacja przechowuje ścieżkę lub adres URL do zewnętrznego obrazu. Może to zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny, gdy prezentacja jest otwierana lub renderowana.

Obraz powiązany można utworzyć, przypisując zewnętrzną ścieżkę lub adres URL poprzez [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/linkpathlong/) zamiast osadzania danych obrazu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Używaj obrazów powiązanych tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny dla ikon, diagramów i innych grafik, które powinny skalować się bez utraty szczegółów typowej dla obrazów rastrowych. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść wynikowy zasób obrazu w ramce obrazu.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Pliki SVG z zasobami zewnętrznymi**

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W tych przypadkach [SvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [IExternalResourceResolver](https://reference.aspose.com/slides/pl/net/aspose.slides.import/iexternalresourceresolver/) oraz bazowy URI. Resolver może mapować względny URI na dozwolony bezwzględny URI i zwracać strumień żądanego zasobu.

Resolver udostępnia zasoby zewnętrzne podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG do dokumentu samodzielnego. Jeśli SVG musi pozostać przenośny, osadź wymagane zasoby w samym SVG, na przykład używając URI `data:` dla powiązanych obrazów.

Gdy pliki SVG pochodzą z nieznanych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może uzyskać dostęp. Rozwiązywacze sieciowe powinny także stosować limity czasu, ograniczenia rozmiaru odpowiedzi oraz walidację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może przekonwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiednie polecenie w PowerPoint.

![Menu podręczne PowerPoint](img_01_01.png)

Użyj przeciążenia [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addgroupshape/) przyjmującego [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) do wykonania konwersji.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Używaj konwersji SVG‑do‑kształtów, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być jedynie wyświetlany, trzymanie go jako obrazu jest prostsze i unika tworzenia wielu oddzielnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [IPPImage.ReplaceImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/replaceimage/) gdy chcesz zastąpić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak loga.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Jeśli wiele ramek obrazu, teł, masterów lub układów korzysta z tego samego zasobu obrazu, jego zastąpienie aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz jej inny obraz zamiast zastępować współdzielony zasób.

`ReplaceImage` udostępnia także przeciążenia przyjmujące [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) lub inny [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).

## **Praktyczne wytyczne dotyczące zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą niepotrzebnie zwiększać rozmiar prezentacji. Używaj źródłowych obrazów o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, ponownie wykorzystuj współdzielone zasoby obrazu tam, gdzie to możliwe, i unikaj osadzania wielokrotnych kopii tej samej grafiki w pełnej rozdzielczości.

Dla rastrowych obrazów już umieszczonych w ramach obrazu, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/compressimage/) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycięcia. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Ramka obrazu](/slides/pl/net/picture-frame/) pod kątem powiązanych operacji formatowania.

### **Wybór między treścią osadzoną a powiązaną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie wymagane dane obrazu podróżują razem z plikiem. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj linków tylko wtedy, gdy ta zależność jest akceptowalna i stabilna.

### **Ponowne wykorzystanie wspólnego brandingu**

Dla powtarzających się log, znaków wodnych lub elementów dekoracyjnych użyj jednego zasobu obrazu i wielokrotnie go wykorzystuj. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdów, umieść ją na masterze lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymuj zasoby SVG w wersji przenośnej**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania jednolicie niż SVG zależny od zewnętrznych plików lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Używaj nowoczesnego, wieloplatformowego API obrazu**

W nowym kodzie .NET korzystaj z API Aspose.Slides [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) i [Images](https://reference.aspose.com/slides/pl/net/aspose.slides/images/) zamiast polegać na `System.Drawing.Image` lub `Bitmap`. Zobacz [Modern API](/slides/pl/net/modern-api/) po wskazówki dotyczące migracji.

WMF i EMF wymagają szczególnej uwagi. Gdy te formaty są przekazywane przez [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection/addimage/) konwertuje metaplikę na rastrową reprezentację PNG przed wstawieniem. Jeśli zachowanie danych metapliku jest istotne, użyj przeciążenia opartego na strumieniu [ImageCollection.AddImage](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection/addimage/). Generowanie treści EMF z arkuszy kalkulacyjnych lub innych produktów to odrębny przepływ integracji i wykracza poza zakres tego artykułu.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnego użytku zasoby obrazów. Ramka obrazu jest kształtem slajdu, który wyświetla jeden z tych zasobów i zapewnia formatowanie specyficzne dla obrazu, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo wszędzie?**

Jeśli logo jest już współdzielonym zasobem obrazu, zastąp ten zasób przy użyciu [IPPImage.ReplaceImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/replaceimage/). Dla brandingu obejmującego całą prezentację umieszczenie logo na masterze lub układzie może także zmniejszyć zduplikowaną zawartość slajdów.

**Dlaczego powiązany obraz znika na innym komputerze?**

Obraz powiązany zależy od swojego zewnętrznego pliku lub URL. Jeśli ten zasób nie jest dostępny z innego komputera, powiązany obraz może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Przekonwertuj SVG za pomocą [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addgroupshape/); powstała grupa zawiera edytowalne kształty slajdu, a nie jedną grafikę SVG.

**Jak mogę utrzymać mniejsze rozmiary prezentacji z wieloma obrazami?**

Ponownie wykorzystuj współdzielone zasoby obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w miarę potrzeb, przechowuj powtarzający się branding na masterach lub układach oraz używaj obrazów powiązanych tylko wtedy, gdy zależność zewnętrzna jest akceptowalna.