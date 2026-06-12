---
title: Správa pozadí prezentace v C++
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/cpp/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednolitá barva
- přechodová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednotné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo **hlavní snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednotné barvy pozadí pro normální snímek**

Aspose.Slides vám umožňuje nastavit jednotnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) na `Solid`.
4. Použijte metodu [get_SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_solidfillcolor/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) pro určení jednotné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit modrou jednotnou barvu jako pozadí normálního snímku:

```cpp
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

Aspose.Slides vám umožňuje nastavit jednotnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednotnou barvu pro pozadí hlavního snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) hlavního snímku (pomocí `get_Masters`) na `OwnBackground`.
3. Nastavte pozadí hlavního snímku [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) na `Solid`.
4. Použijte metodu [get_SolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_solidfillcolor/) pro určení jednotné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit jednotnou barvu (lesní zelená) jako pozadí hlavního snímku:

```cpp
// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Nastavte barvu pozadí hlavního snímku na lesní zelenou.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Uložte prezentaci na disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení přechodového pozadí pro snímek**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může přechod dodat prezentacím umělečtější a profesionálnější vzhled. Aspose.Slides vám umožňuje nastavit barvu přechodu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) na `Gradient`.
4. Použijte metodu [get_GradientFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_gradientformat/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) pro konfiguraci požadovaných nastavení přechodu.
5. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit barvu přechodu jako pozadí snímku:

```cpp
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

Kromě jednotných a přechodových výplní vám Aspose.Slides umožňuje používat obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [get_PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/get_picturefillformat/) na [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v C++ ukazuje, jak nastavit obrázek jako pozadí snímku:

```cpp
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
Více informací: [**Tile Picture As Texture**](/slides/cs/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Možná budete chtít upravit průhlednost obrázku pozadí snímku, aby se obsah snímku lépe vyzdvihl. Následující kód v C++ ukazuje, jak změnit průhlednost obrázku pozadí snímku:

```cpp
auto transparencyValue = 30; // Například.

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

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní zpřístupňuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Pomocí metody `get_Background` třídy [BaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad v C++ ukazuje, jak získat efektivní hodnotu pozadí snímku:

```cpp
// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Získejte efektivní pozadí s ohledem na hlavní snímek, rozvržení a motiv.
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

## **Často kladené dotazy**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/podoby?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího snímku [layout](/slides/cs/cpp/slide-layout/)/[master](/slides/cs/cpp/slide-master/) (tj. z [theme background](/slides/cs/cpp/presentation-theme/)).

**Co se stane s pozadím, pokud později změníte motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [layout](/slides/cs/cpp/slide-layout/)/[master](/slides/cs/cpp/slide-master/), aktualizuje se tak, aby odpovídalo [novému motivu](/slides/cs/cpp/presentation-theme/).