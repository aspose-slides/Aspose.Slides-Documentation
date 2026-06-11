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
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++, wraz z wskazówkami kodowymi, które wzmocnią Twoje prezentacje."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **zwykłego slajdu** (pojedynczego slajdu) lub **slajdu wzorcowego** (obowiązującego dla wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla zwykłego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła dla konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu wzorcowego. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj metody [get_SolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/get_solidfillcolor/) klasy [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku C++ pokazuje, jak ustawić niebieski jednolity kolor jako tło zwykłego slajdu:

```cpp
// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ustaw kolor tła slajdu na niebieski.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Zapisz prezentację na dysku.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw jednolite tło koloru dla slajdu wzorcowego**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła slajdu wzorcowego w prezentacji. Slajd wzorcowy działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc po wybraniu jednolitego koloru tła slajdu wzorcowego zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu wzorcowego (przez `get_Masters`) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) tła slajdu wzorcowego na `Solid`.
4. Użyj metody [get_SolidFillColor], aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku C++ pokazuje, jak ustawić jednolity kolor (zieleń leśna) jako tło slajdu wzorcowego:

```cpp
// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Ustaw kolor tła slajdu Master na zielony leśny.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Zapisz prezentację na dysku.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Użyty jako tło slajdu, gradient może sprawić, że prezentacje wyglądają bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie gradientowego koloru jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj metody [get_GradientFormat] klasy [FillFormat], aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku C++ pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```cpp
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

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) tła slajdu na `Picture`.
4. Wczytaj obraz, który chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [get_PictureFillFormat] klasy [FillFormat], aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku C++ pokazuje, jak ustawić obraz jako tło slajdu:

```cpp
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

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na wzór powtarzanego obrazu i zmodyfikować właściwości kafelkowania:

```cpp
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

{{% alert color="primary" %}}
Czytaj więcej: [**Tile Picture As Texture**](/slides/pl/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby wyróżnić zawartość slajdu. Poniższy kod w C++ pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```cpp
auto transparencyValue = 30; // Na przykład.

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/) służący do pobierania rzeczywistych wartości tła slajdu. Interfejs ten udostępnia rzeczywisty [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) oraz [EffectFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Korzystając z metody `get_Background` klasy [BaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseslide/), możesz uzyskać rzeczywiste tło slajdu.

Poniższy przykład w języku C++ pokazuje, jak uzyskać rzeczywistą wartość tła slajdu:

```cpp
// Utwórz instancję klasy Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
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

**Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/cpp/slide-layout/)/[master](/slides/pl/cpp/slide-master/) (czyli z [tła motywu](/slides/pl/cpp/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/cpp/slide-layout/)/[master](/slides/pl/cpp/slide-master/), zostanie zaktualizowane, aby pasować do [nowego motywu](/slides/pl/cpp/presentation-theme/).