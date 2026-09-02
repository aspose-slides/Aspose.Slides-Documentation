---
title: Zarządzaj efektami transformacji obrazu w prezentacjach w C++
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/cpp/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
- duoton
- odcieniowanie
- HSL
- zastąpienie koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: Zastosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla C++
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/) i uzyskaj dostęp do [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/get_imagetransform/). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/) umożliwia dołączanie, enumerowanie, przeglądanie, usuwanie i czyszczenie efektów bez przepisywania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, łańcuchów efektów w ustalonej kolejności, wartości efektywnych, usuwania oraz weryfikacji rund‑trip w formacie PPTX.

## **Zrozum własność efektów i ponowne użycie obrazu**

Zasób obrazu i obraz wyświetlany w ramce to różne obiekty:

- [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/). Gdy ten sam `IPPImage` zostanie przekazany do [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addpictureframe/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie efektu szarości do jednej ramki nie powoduje, że pozostałe ramki stają się szare, mimo że wszystkie ponownie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `ISlidesPicture::get_ImageTransform` jest również używany przez inne wypełnienia obrazów, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Prezentowane metody wykorzystują następujące semantyczne zakresy i jednostki. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu nieprawidłowej wartości; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Poprawny zakres i jednostka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Brak | Brak parametrów liczbowych. Alfa pozostaje niezmieniona. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `System::Drawing::Color` używają wartości od `0` do `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odcień (`hue`) ma zakres od `0` (włącznie) do `360` (wyłącznie), w stopniach; `amount` wynosi od `-100` do `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odcień (`hue`) ma zakres od `0` (włącznie) do `360` (wyłącznie), w stopniach; nasycenie i luminancja wynoszą od `-100` do `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Kolor zamienny używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [AddBlurEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` określa, czy rozmyta zawartość może wykraczać poza pierwotne granice. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nieujemny procent. Użyj wartości od `0` do `100` dla typowego skalowania nieprzezroczystości: `0` to całkowita przezroczystość, a `100` zachowuje istniejącą alfę. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` do `100`, procentowy próg alfy. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfy, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada modulacji alfy wynoszącej 65 %.

## **Zastosuj jasność i kontrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ibrightnesscontrast/). Jej skalarnych ustawień dostarcza się w momencie tworzenia operacji. Metoda `IBrightnessContrast::GetEffective` zwraca obliczone wartości tylko do odczytu, które można przejrzeć lub zalogować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji wbudowanego obrazu:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem efektu obrazu z Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po rund‑tripie PPTX, użyj [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorów można stosować niezależnie do różnych ramek obrazu, które współużywają jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje kolejno szarość, duoton, tint, korektę HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iduotone/) zawiera dwa niezależnie edytowalne parametry koloru: `get_Color1` mapuje ciemne piksele, a `get_Color2` mapuje jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) zamienia każdy piksel na jeden stały kolor, zachowując alfa. Różni się od [AddColorChangeEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), który mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[AddBlurEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Mnoży on każdą istniejącą wartość alfy, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) natomiast przypisuje jedną wartość alfy wszystkim pikselom. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konwertuje alfę na dwa poziomy w oparciu o prog.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Inne operacje alfa nie wymagające parametrów to [AddAlphaCeilingEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), które czyni każdą niezerową alfę w pełni nieprzezroczystą; [AddAlphaFloorEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), które czyni każdą alfę poniżej 100 % całkowicie przezroczystą; oraz [AddAlphaInverseEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), które zmienia alfę na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `Add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wynik operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład szarość, po której następuje tint, najpierw usuwa informacje chromatyczne, a potem ponownie barwi wynik luminancji. Tint, po którym następuje szarość, usuwa tint. Podobnie zamiana alfy może nadpisać wartości alfy obliczone przez wcześniejsze operacje, podczas gdy modulacja alfy zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność oraz renderuje wynik po ponownym otwarciu:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Kolekcja nie narzuca macierzy kompatybilności, która ograniczałaby operacje koloru, alfy i rozmycia do osobnych łańcuchów. Można je łączyć, choć nie zawsze ma to sens. Stała zamiana koloru usuwa zmienność RGB wytworzoną przez wcześniejsze efekty koloru; szarość po duotonie usuwa dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement czy bi‑level mogą odrzucać szczegóły alfy stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną kolejnością przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.

## **Przeglądaj edytowalne i efektywne wartości**

Edytowalna operacja to obiekt przechowywany w `ISlidesPicture::get_ImageTransform`. W zależności od efektu może ona udostępniać zapisywalne pola bezpośrednio. Na przykład [IBlur](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iblur/) udostępnia `set_Radius` i `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ialphamodulatefixed/) udostępnia `set_Amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ialphabilevel/) udostępnia `set_Threshold`. Efekty kolorów, takie jak [IDuotone](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iduotone/), udostępniają modyfikowalne obiekty [IColorFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/itint/), oraz [IAlphaReplace](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ialphareplace/), nie udostępniają swoich parametrów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `GetEffective()` są obliczane i tylko do odczytu. Są przydatne do rozwiązywania zależnych od motywu kolorów oraz odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią dodatkowej warstwy edycji. Poniższy przykład enumeruje łańcuch i przegląda wartości efektywne kilku typowych operacji:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
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

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Efekty nie wymagające parametrów, takie jak szarość, alfa ceiling czy alfa inverse, nadal posiadają obiekt danych efektywnych, ale nie mają skalarnych ustawień do wyświetlenia. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuń lub wyczyść transformacje obrazu**

Użyj [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw wyszukaj docelowy element, a następnie usuń go po enumeracji. Użyj `Clear()` aby usunąć cały łańcuch.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Usuwanie lub czyszczenie transformacji zmienia wyłącznie formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie modyfikuje ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, więc PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet w PPTX nie wszystkie operacje mają identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, szarość, duoton, tint, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania rund‑tripa w PPTX. Zawsze ponownie otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy wymagana jest zachowalność.
- [BrightnessContrast](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może służyć do renderowania w pamięci, ale nie ma gwarancji, że po zapisaniu i ponownym otwarciu PPTX pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/ibrightnesscontrast/). Preferuj [AddLuminanceEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT powstał przed pełnym modelem efektów DrawingML. Zapis do PPT może pomijać nieobsługiwane operacje, redukować łańcuch do obsługiwanego podzbioru lub przybliżać wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego, edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnej `IImageTransformOperationCollection`; formaty rastrowe spłaszczają rezultat do pikseli, a eksporty dokumentów lub wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią powiązanego obrazu samodzielnym. Renderowanie podłączonego obrazu nadal wymaga dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni odbiorcy prezentacji mogą renderować przypadki brzegowe inaczej, zwłaszcza gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych wyników przetestuj zarówno edytowalny rund‑trip, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, którą stosujesz w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują wbudowane dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty leżącego pod spodem `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, współdzielą swoje efekty?**

Nie. Ponowne użycie `IPPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj posiada osobny `ISlidesPicture` i własną kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą usuwać wcześniejsze szczegóły kolorów lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozstrzygnięte kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem wybrać, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik, ponownie go otwierając. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu wizualnego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.