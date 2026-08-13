---
title: Správa pozadí prezentací v C++
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/cpp/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednotná barva
- přechodová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, s tipy na kód, které posílí vaše prezentace."
---
## **Úvod**

Jednobarevná pozadí, přechody a obrázky se často používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo **hlavní snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednotné barvy pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se projeví pouze na vybraném snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [get_SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_solidfillcolor/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) a určete jednotnou barvu pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit modrou jednotnou barvu jako pozadí pro normální snímek:

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

// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Nastavte barvu pozadí snímku na modrou.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Uložte prezentaci na disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení jednotné barvy pozadí pro hlavní snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednotnou barvu pro pozadí hlavního snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) hlavního snímku (prostřednictvím `get_Masters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) pozadí hlavního snímku na `Solid`.
4. Použijte metodu [get_SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_solidfillcolor/) a určete jednotnou barvu pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit jednotnou barvu (lesní zelená) jako pozadí hlavního snímku:

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

// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Nastavte barvu pozadí pro hlavní snímek na lesní zelenou.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Uložte prezentaci na disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení přechodového pozadí pro snímek**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může přechod učinit prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit přechodovou barvu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [get_GradientFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_gradientformat/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) a nakonfigurujte požadované nastavení přechodu.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit přechodovou barvu jako pozadí snímku:

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

// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Použijte gradientní efekt na pozadí.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Uložte prezentaci na disk.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednotných a přechodových výplní umožňuje Aspose.Slides použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [get_PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_picturefillformat/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) a přiřaďte obrázek jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit obrázek jako pozadí snímku:

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

// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Nastavte vlastnosti obrázku pozadí.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Načtěte obrázek.
auto image = Images::FromFile(u"Tulips.jpg");
// Přidejte obrázek do kolekce obrázků prezentace.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Uložte prezentaci na disk.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Následující ukázka kódu demonstruje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dláždění:

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

Více: [**Tile Picture As Texture**](/slides/cs/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Změna průhlednosti obrázku v pozadí**

Možná budete chtít upravit průhlednost obrázku v pozadí snímku, aby se obsah snímku lépe vynikal. Následující kód v C++ ukazuje, jak změnit průhlednost obrázku v pozadí snímku:

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

auto transparencyValue = 30; // Například.

// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Získejte kolekci operací transformace obrázku.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Najděte existující efekt průhlednosti s pevnou procentuální hodnotou.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Nastavte novou hodnotu průhlednosti.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Uložte prezentaci na disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní vystavuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Pomocí metody `get_Background` třídy [BaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad v C++ ukazuje, jak získat efektivní hodnotu pozadí snímku:

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

// Vytvořte instanci třídy Presentation.
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

## **Často kladené otázky**

### Můžu resetovat vlastní pozadí a obnovit pozadí motivu/layoutu?

Ano. Odeberte vlastní výplň snímku a pozadí bude znovu zděděno z příslušného [layoutu](/slides/cs/cpp/slide-layout/)/[masteru](/slides/cs/cpp/slide-master/) (tj. [pozadí motivu](/slides/cs/cpp/presentation-theme/)).

### Co se stane s pozadím, když později změníme motiv prezentace?

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [layoutu](/slides/cs/cpp/slide-layout/)/[masteru](/slides/cs/cpp/slide-master/), aktualizuje se podle [nového motivu](/slides/cs/cpp/presentation-theme/).