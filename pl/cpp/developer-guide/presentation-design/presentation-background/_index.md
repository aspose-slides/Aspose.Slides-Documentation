---
title: Zarządzanie tłami prezentacji w C++
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/cpp/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- jednolity kolor
- gradientowy kolor
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++, z wskazówkami kodu zwiększającymi atrakcyjność twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczego slajdu) lub **slajdu nadrzędnego** (obowiązującego na wielu slajdach jednocześnie).

![Tło PowerPoint](powerpoint-background.png)

## **Ustaw tło jednolitego koloru dla normalnego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu nadrzędnego. Zmiana dotyczy tylko wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Solid`.
4. Użyj metody [get_SolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/get_solidfillcolor/) w [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład C++ pokazuje, jak ustawić niebieski jednolity kolor jako tło normalnego slajdu:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw tło jednolitego koloru dla slajdu nadrzędnego**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła slajdu nadrzędnego w prezentacji. Slajd nadrzędny działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc gdy wybierzesz jednolity kolor tła slajdu nadrzędnego, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu nadrzędnego (poprzez `get_Masters`) na `OwnBackground`.
3. Ustaw tło slajdu nadrzędnego [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Solid`.
4. Użyj metody [get_SolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/get_solidfillcolor/) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład C++ pokazuje, jak ustawić jednolity kolor (zieleń leśna) jako tło slajdu nadrzędnego:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw tło gradientowe dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Stosowany jako tło slajdu, gradient może sprawić, że prezentacje będą wyglądały bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie koloru gradientowego jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Gradient`.
4. Użyj metody [get_GradientFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/get_gradientformat/) w [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład C++ pokazuje, jak ustawić kolor gradientu jako tło slajdu:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Zastosuj efekt gradientu do tła.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Zapisz prezentację na dysku.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) na `Picture`.
4. Wczytaj obraz, którego chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [get_PictureFillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/get_picturefillformat/) w [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład C++ pokazuje, jak ustawić obraz jako tło slajdu:

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
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ustaw właściwości obrazu tła.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Wczytaj obraz.
auto image = Images::FromFile(u"Tulips.jpg");
// Dodaj obraz do kolekcji obrazów prezentacji.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Zapisz prezentację na dysku.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kafelkowy i zmodyfikować właściwości kafelkowania:

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
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}

Czytaj dalej: [**Tile Picture As Texture**](/slides/pl/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby wyróżnić zawartość slajdu. Poniższy kod C++ pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Na przykład.

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Pobierz kolekcję operacji transformacji obrazu.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Znajdź istniejący efekt stałej procentowej przezroczystości.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Ustaw nową wartość przezroczystości.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Zapisz prezentację na dysku.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Uzyskaj wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/) do pobierania efektywnych wartości tła slajdu. Interfejs ten udostępnia efektywny [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) oraz [EffectFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Korzystając z metody `get_Background` klasy [BaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

Poniższy przykład C++ pokazuje, jak uzyskać efektywną wartość tła slajdu:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Pobierz efektywne tło, uwzględniając slajd nadrzędny, układ i motyw.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/cpp/slide-layout/)/[master](/slides/pl/cpp/slide-master/) (czyli z [theme background](/slides/pl/cpp/presentation-theme/)).

### Co się stanie z tłem, jeśli później zmienię motyw prezentacji?

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/cpp/slide-layout/)/[master](/slides/pl/cpp/slide-master/), zostanie zaktualizowane, aby pasowało do [new theme](/slides/pl/cpp/presentation-theme/).