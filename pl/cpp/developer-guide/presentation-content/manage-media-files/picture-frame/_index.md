---
title: Zarządzaj ramkami obrazu w prezentacjach przy użyciu C++
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/cpp/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- osadzony obraz
- linkowany obraz
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
description: "Twórz, formatuj, linkuj, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu, który wyświetla obraz. W Aspose.Slides zasób obrazu i kształt go wyświetlający są odrębnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją [image collection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_images/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz wektorowe obrazy SVG. Mogą także odwoływać się do obrazów linkowanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, możliwość wyodrębniania i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodaj i sformatuj osadzony obraz**

W przypadku obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy pomocy [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapecollection/addpictureframe/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę o natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

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

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się ważne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) udostępnia względne skalowanie szerokości i wysokości ramki. Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy przepływ pracy wymaga zachowania proporcji względem rozmiaru źródłowego obrazu zamiast ręcznego obliczania wymiarów końcowych.

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

Skala względna zmienia ustawienia skali ramki; nie powoduje ponownego próbkowania ani kompresji osadzonego obrazu.

## **Osadzone i linkowane obrazy**

Osadzony obraz przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Linkowany obraz przechowuje zewnętrzną lokalizację poprzez ścieżkę linku [ISlidesPicture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/) zamiast osadzania danych obrazu w ten sam sposób.

Linkowane obrazy mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zależność zewnętrzną. Plik linkowany musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, linkowany obraz może nie wyświetlić się zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zwykle bardziej niezawodne.

### **Dodaj linkowany obraz**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie linkowania obrazów; linkowanie wideo jest odrębnym przepływem mediów i celowo nie zostało połączone w tym przykładzie.

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

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie stosuj ich jedynie jako zamiennika kompresji: mały plik PPTX z zepsutymi zależnościami obrazów jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Zanim wyodrębnisz obraz z istniejącej prezentacji, sprawdź, czy kształt jest faktycznie [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Linkowane ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

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

Zapis przez [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnij obraz SVG**

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

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, muszą renderować tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowane grafiki nie powinny być traktowane jako bit‑po‑bicie kopia oryginalnego osadzonego SVG; użyj danych osadzonego [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) gdy potrzebny jest sam wektorowy zasób.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycięcie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia tylko widoczny obszar.

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

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte obszary można fizycznie usunąć, jak opisano w następnym rozdziale.

## **Usuń przycięte dane obrazu**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) usuwa dane obrazu znajdujące się poza bieżącym prostokątem przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji przywracania przycięcia.

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

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli pierwotny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/compressimage/) zmniejsza rozdzielczość obrazu rastrowego w stosunku do rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiaru lub przycięty oraz `false`, gdy nie było potrzeby zmian.

Użyj zdefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/picturescompression/) gdy wystarcza standardowa docelowa rozdzielczość:

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

Zamiast wartości wyliczeniowej można podać własną dodatnią wartość DPI, gdy wymagany jest konkretny cel.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metafile nie jest zmniejszana przez ten workflow kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte regiony nie mogą zostać odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie faktycznie oglądany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Sprawdź efekty obrazu**

Efekty obrazu są przechowywane na obrazie używanym przez ramkę. Kolekcja transformacji obrazu może zawierać efekty takie jak stała modulacja alfa dla przezroczystości oraz luminancja dla jasności i kontrastu. Poniższy przykład bezpiecznie odczytuje oba rodzaje efektów z pierwszej ramki obrazu na slajdzie:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Te efekty zmieniają sposób renderowania obrazu w ramce; nie modyfikują oryginalnych bajtów osadzonego obrazu.

## **Zablokuj geometrię ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [aspect-ratio lock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) zachowuje proporcje kształtu podczas zmiany jego rozmiaru.

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

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ponownego próbkowania ani trwałej zmiany proporcji źródłowego obrazu.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu to stretch, wartości stretch‑offset w [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem obwiedni ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, natomiast ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

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

Używaj offsetów rozciągnięcia do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i uwagi przy eksporcie**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki są traktowane oddzielnie:

- **Osadzone obrazy** sprawiają, że prezentacja jest samodzielna i są najbardziej niezawodne przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Linkowane obrazy** mogą utrzymać pakiet mniejszy, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo niedestrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną wyraźnie usunięte lub zlikwidowane podczas kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródłowej. Powinna być stosowana po ustaleniu docelowego rozmiaru obrazu na slajdzie.
- **Obrazy SVG** powinny pozostać jako SVG, gdy istotne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksporty slajdów do formatu rastrowego zawsze konwertują renderowany slajd do pikseli.
- **Powtarzane obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) zamiast wielokrotnego wczytywania tego samego pliku w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazów jest zazwyczaj najbardziej efektywna, gdy przeprowadzana jest selektywnie: pozostaw loga i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy linkować obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Linkuj obrazy tylko wtedy, gdy zamierzone jest przechowywanie plików obrazu poza PPTX i można zapewnić niezawodne utrzymanie lokalizacji zewnętrznych.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują leżące pod spodem piksele. Użyj [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą zostać trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może obniżyć zapisaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później będzie wymagana edycja w wysokiej rozdzielczości.

**Jak należy postępować z obrazami SVG?**

Zachowuj treść SVG jako SVG, gdy ważna jest dokładność wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) można wyodrębnić bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczytywaniu istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Przetestuj kształt przy pomocy [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) przed zastosowaniem rzutowania w czasie wykonywania i przypisz wynik rzutowania do zmiennej lokalnej przed dostępem do członków specyficznych dla ramki obrazu.