---
title: Z​arządzaj ramkami obrazu w prezentacjach przy użyciu C++
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/cpp/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- osadzony obraz
- połączony obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- skompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla C++."
---
## **Omówienie**

Ramka obrazu jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją [image collection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_images/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) kontroluje położenie obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz wektorowe obrazy SVG. Mogą także odwoływać się do połączonych obrazów zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksportowaniu, dlatego warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodawanie i formatowanie osadzonego obrazu**

W przypadku obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy pomocy [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapecollection/addpictureframe/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikselowych przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Używanie skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) udostępnia skalowanie względne szerokości i wysokości dla ramki. Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy proces wymaga zachowania proporcji względem rozmiaru obrazu źródłowego zamiast ręcznego obliczania wymiarów końcowych.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Skala względna zmienia ustawienia skali ramki; nie dokonuje przerywki ani kompresji osadzonego obrazu.

## **Obrazy osadzone i połączone**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod kątem przenośności i przewidywalnego renderowania. Obraz połączony przechowuje zewnętrzną lokalizację poprzez ścieżkę linku [ISlidesPicture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/) zamiast osadzania danych obrazu w ten sam sposób.

Połączone obrazy mogą zmniejszyć ilość danych obrazu przechowywanych w PPTX, ale wprowadzają zależność zewnętrzną. Połączony plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka ulegnie zmianie, plik zostanie przeniesiony lub zasób będzie niedostępny, połączony obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodawanie obrazu połączonego**

Poniższy przykład tworzy ramkę obrazu i wskazuje na lokalny plik obrazu. Dotyczy wyłącznie łączenia obrazów; łączenie wideo to odrębny przepływ pracy multimedialnej i celowo nie jest mieszane w tym przykładzie.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie stosuj ich wyłącznie jako zamiennika kompresji: mały PPTX z uszkodzonymi zależnościami obrazów jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnianie obrazów z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest rzeczywiście [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Połączone ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnianie obrazu rastrowego**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony rastrowy obraz na slajdzie i zapisuje go jako PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Zapis przy użyciu [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnianie obrazu SVG**

W przypadku obrazu SVG, [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast najpierw rasteryzować obraz.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG czy JPEG, koniecznie renderują tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako bit‑po‑bicie kopia oryginalnego osadzonego SVG; użyj danych osadzonego [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) wtedy, gdy wymagana jest oryginalna wektorowa zasoba.

## **Przycinanie obrazu**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycinania w [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie początkowo nie usuwa ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje ramkę obrazu i stosuje wartości przycięcia:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż możliwość odwrócenia, przycięte obszary można fizycznie usunąć, jak opisano w kolejnej sekcji.

## **Usuwanie przyciętych danych obrazu**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) usuwa dane obrazu spoza bieżącego prostokąta przycięcia i zwraca wynikowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest destrukcyjną optymalizacją: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszego odwrócenia przycięcia.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresja obrazów rastrowych**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/compressimage/) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiarem lub przycięty oraz `false`, gdy nie było konieczności zmiany.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/picturescompression/), gdy standardowa rozdzielczość docelowa jest wystarczająca:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Można również przekazać własną dodatnią wartość DPI zamiast wartości wyliczeniowej, gdy wymagana jest określona rozdzielczość docelowa.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metaplików nie jest zmniejszana tą metodą kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj rozdzielczość docelową na podstawie największego rozmiaru, w jakim obraz będzie faktycznie oglądany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Zarządzanie efektami przekształceń obrazu**

Kompletny przepływ pracy obejmujący jasność, kontrast, przekształcenia kolorów, rozmycie, efekty alfa, łańcuchy porządkowe, inspekcję, usuwanie i weryfikację dwukierunkową znajdziesz w [Image Transform Effects](/slides/pl/cpp/image-transform-effects/).

## **Blokowanie geometrii ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/) kontrolują, które operacje edycyjne są wyłączone dla ramki obrazu. Na przykład [aspect-ratio lock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) zachowuje proporcje kształtu podczas zmiany rozmiaru.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Blokada dotyczy kształtu ramki obrazu. Nie zmusza ona obrazu źródłowego do przerywki ani trwałej zmiany proporcji.

## **Dostosowanie wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycinania wybierają, która część obrazu źródłowego jest widoczna; stretch‑offset zmienia prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Używaj stretch‑offset do rozmieszczania wypełnienia. Używaj właściwości przycinania, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i kwestie eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu traktowane są oddzielnie:

- **Obrazy osadzone** sprawiają, że prezentacja jest samodzielna i są najpewniejsze przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy połączone** mogą utrzymać mniejszy pakiet, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo niedestrukcyjne. Ukryte piksele pozostają osadzone, aż do momentu jawnego usunięcia przyciętych obszarów lub usunięcia podczas kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródłowej. Powinna być stosowana po ustaleniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać w formacie SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdów do formatu rastrowego zawsze konwertuje wyrenderowany slajd do pikseli.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/), gdy to możliwe, zamiast wielokrotnego ładowania tego samego pliku w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazu jest zazwyczaj najskuteczniejsza przy selektywnym zastosowaniu: trzymaj loga i diagramy jako zawartość wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy celowe jest utrzymywanie plików obrazu poza PPTX i zewnętrzne lokalizacje mogą być niezawodnie zarządzane.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podległe piksele. Użyj [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak powinny być obsługiwane obrazy SVG?**

Trzymaj zawartość SVG jako SVG, gdy zależy Ci na wierności wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) można wyodrębnić bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczycie istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Testuj kształt przy pomocy [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) przed wykonaniem rzutowania w czasie wykonywania i przypisz wynik rzutowania do zmiennej lokalnej przed dostępem do członków specyficznych dla ramki obrazu.