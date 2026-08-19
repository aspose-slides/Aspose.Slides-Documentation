---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu C++
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/cpp/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- zastąp obraz
- kolekcja obrazów
- ramka obrazu
- powiązany obraz
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie używać, łączyć, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

Aspose.Slides for C++ oferuje kilka sposobów pracy z obrazami, przy czym każdy ma inny cel. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać jako tła slajdu, łączyć się z zewnętrznym obrazem, zastępować współdzielony zasób obrazu lub konwertować treść SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazu i ich użyciu w całej prezentacji. Informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu znajdziesz w sekcji [Picture Frame](/slides/pl/cpp/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą powiązane, ale nie są wymienne:

- Kolekcja obrazów prezentacji ([presentation image collection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/)) przechowuje zasoby obrazów używane w prezentacji. Użyj [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/), aby dodać dane obrazu i uzyskać zasób [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).
- [Picture frame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) to kształt wyświetlający obraz na slajdzie, układzie lub szablonie. Użyj [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addpictureframe/), aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się jak ramka obrazu.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/replaceimage/) zastępuje zasób obrazu. Jeśli kilka elementów prezentacji korzysta z tego zasobu, wszystkie użyją zamiany.
- Konwersja SVG na kształty tworzy edytowalne kształty slajdu. Po konwersji treść nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji, otrzymaj [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/), a następnie użyj tego zasobu w jednej lub kilku ramkach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić lokalny obraz, odczytaj plik, dodaj jego dane do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego zasobu [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Gdy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób, jak przy obrazie lokalnym.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sprawdzaj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane. W aplikacjach, które już używają innego klienta HTTP, możesz pobrać obraz tym klientem i przekazać otrzymane bajty lub strumień do [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/).

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny wielokrotnie, dodaj go raz do prezentacji i ponownie użyj zwróconego [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) przy tworzeniu kolejnych ramek obrazu. Dzięki temu unikniesz wielokrotnego ładowania tych samych danych źródłowych i jasno określisz zależność między współdzielonym zasobem obrazu a jego użyciem.

W przypadku grafik, które mają pojawiać się automatycznie na wielu slajdach, np. logo firmy, rozważ umieszczenie ramki obrazu na [slide master](/slides/pl/cpp/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tła slajdu**

Obraz tła jest przypisywany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jak zwykły obiekt slajdu.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dodatkowe opcje tła, w tym tła szablonów i układów, znajdziesz w sekcji [Presentation Background](/slides/pl/cpp/presentation-background/).

## **Obrazy osadzone i powiązane**

Obrazy osadzone i powiązane mają różne kompromisy pod względem przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku obejmuje dane obrazu.
- **Obraz powiązany:** prezentacja przechowuje ścieżkę lub URL do zewnętrznego obrazu. To może zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny podczas otwierania lub renderowania prezentacji.

Powiązany obraz można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/set_linkpathlong/), zamiast osadzania danych obrazu.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Używaj obrazów powiązanych tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny dla ikon, diagramów i innych grafik, które powinny skalować się bez utraty szczegółów charakterystycznych dla obrazów rastrowych. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść wynikowy zasób obrazu w ramce obrazu.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Pliki SVG z zasobami zewnętrznymi**

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [IExternalResourceResolver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/) oraz bazowy URI. Resolver może mapować względny URI na dozwolony bezwzględny URI i zwracać strumień żądanego zasobu.

Resolver udostępnia zasoby zewnętrzne podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG na dokument samodzielny. Jeśli SVG musi pozostać przenośny, osadź wymagane zasoby w samym pliku SVG, np. używając URI `data:` dla powiązanych obrazów.

Gdy pliki SVG pochodzą z niepewnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może mieć dostęp. Rozwiązywacze sieciowe powinny również stosować timeouty, limity rozmiaru odpowiedzi i walidację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może konwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiednia komenda w PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Użyj przeciążenia [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addgroupshape/) przyjmującego [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/), aby wykonać konwersję.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Używaj konwersji SVG‑do‑kształtów, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być jedynie wyświetlony, pozostawienie go jako obrazu jest prostsze i unika tworzenia wielu osobnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/replaceimage/), gdy chcesz zamienić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak loga.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jeśli wiele ramek obrazu, teł, szablonów lub układów używa tego samego zasobu, jego zamiana aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz inną grafikę do tej ramki zamiast zastępować współdzielony zasób.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/replaceimage/) oferuje także przeciążenia przyjmujące [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) lub inny [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą niepotrzebnie zwiększać rozmiar prezentacji. Używaj obrazów o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, ponownie wykorzystuj współdzielone zasoby obrazu tam, gdzie to możliwe, i unikaj osadzania wielu kopii tej samej grafiki w pełnej rozdzielczości.

Dla obrazów rastrowych już umieszczonych w ramkach, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/compressimage/) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycinania. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Picture Frame](/slides/pl/cpp/picture-frame/) pod kątem powiązanych operacji formatowania.

### **Wybór między zawartością osadzoną a powiązaną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie wymagane dane obrazu podróżują z plikiem. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj linków tylko wtedy, gdy taka zależność jest akceptowalna i stabilna.

### **Ponowne użycie udostępnionej identyfikacji wizualnej**

Dla powtarzających się logotypów, znaków wodnych lub elementów dekoracyjnych użyj jednego zasobu obrazu i wykorzystuj go wielokrotnie. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdów, umieść ją na szablonie lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymuj zasoby SVG przenośne**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania konsekwentnie niż SVG zależny od plików zewnętrznych lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użyj API obrazu Aspose.Slides**

W przepływach pracy z obrazami w C++ używaj interfejsów Aspose.Slides [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) i [Images](https://reference.aspose.com/slides/pl/cpp/aspose.slides/images/), gdy potrzebny jest obiekt obrazu, oraz [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/), gdy trzeba zarejestrować dane obrazu jako zasób prezentacji. Przeciążenia kolekcji obsługują także tablice bajtów i strumienie, co jest przydatne, gdy dane obrazu pochodzą z plików, klientów sieciowych, baz danych lub innych bibliotek.

Generowanie treści EMF z arkuszy kalkulacyjnych lub innego produktu to odrębny przepływ integracji i wykracza poza zakres tego artykułu. Jeśli istniejący plik WMF lub EMF ma zostać jedynie wstawiony do prezentacji, przekaż jego dane do odpowiedniego przeciążenia [IImageCollection::AddImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/addimage/) bez wprowadzania dodatkowej zależności produktu do workflow zarządzania obrazami.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnie używalne zasoby obrazów. Ramka obrazu to kształt slajdu, który wyświetla jeden z tych zasobów i zapewnia formatowanie specyficzne dla obrazu, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób, aby zastąpić to samo logo wszędzie?**

Jeśli logo jest już współdzielone jako jeden zasób obrazu, zastąp ten zasób metodą [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/replaceimage/). Dla identyfikacji wizualnej obowiązującej w całej prezentacji można również umieścić logo na szablonie lub układzie, co zmniejsza duplikację treści slajdów.

**Dlaczego powiązany obraz znika na innym komputerze?**

Powiązany obraz zależy od zewnętrznego pliku lub URL. Jeśli zasób nie jest dostępny z innego komputera, powiązany obraz może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Konwertuj SVG przy użyciu [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addgroupshape/); otrzymana grupa zawiera edytowalne kształty slajdu zamiast jednego obrazu SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami w mniejszym rozmiarze?**

Ponownie wykorzystuj współdzielone zasoby obrazu, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w razie potrzeby, przechowuj powtarzające się elementy graficzne na szablonach lub układach oraz używaj obrazów powiązanych wyłącznie wtedy, gdy zewnętrzna zależność jest akceptowalna.