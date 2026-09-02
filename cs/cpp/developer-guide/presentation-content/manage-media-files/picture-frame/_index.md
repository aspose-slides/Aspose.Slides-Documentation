---
title: Správa obrázkových rámečků v prezentacích pomocí C++
linktitle: Obrázkový rámeček
type: docs
weight: 10
url: /cs/cpp/picture-frame/
keywords:
- obrázkový rámeček
- přidat obrázkový rámeček
- vytvořit obrázkový rámeček
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámečku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte, formátujte, propojte, ořízněte, extrahujte a komprimujte obrázkové rámečky v prezentacích pomocí Aspose.Slides pro C++."
---
## **Přehled**

Obrázkový rámeček je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [image collection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_images/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) řídí polohu, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámečku.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uložte vrácený [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) a použijte tento zdroj obrázku při vytváření obrázkových rámečků.

Obrázkové rámečky mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo uložení bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte obrázkový rámeček pomocí [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapecollection/addpictureframe/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámeček v nativních rozměrech obrázku a aplikuje formátování čáry a otočení:

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

Obrázkový rámeček řídí zobrazenou geometrii; změna velikosti rámečku nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Tento rozdíl je důležitý při ořezávání nebo kompresi obrázku později.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) poskytuje relativní škálování šířky a výšky pro rámeček. Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup vyžaduje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámečku; neprovádí přeškálování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí cesty odkazu [ISlidesPicture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není k dispozici, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být odesílány e‑mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří obrázkový rámeček a ukáže ho na místní soubor obrázku. Zabývá se jen odkazováním na obrázek; odkazování na video je samostatný mediální pracovní tok a je záměrně v tomto příkladu odděleno.

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

Používejte odkazy, když je správa externích souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z obrázkových rámečků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené obrázkové rámečky nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Ukládání přes [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektor do pixelů. Export snímku do PDF nebo SVG je také renderovací operace, takže exportovaná grafika by neměla být považována za bit‑po‑bitu kopii původního vloženého SVG; použijte vložená data [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/), když je vyžadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámečku. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rámeček a aplikuje hodnoty ořezu:

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

Protože skrytá data obrázku stále existují, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než možnost revertu, lze ořezané oblasti fyzicky odstranit, jak je popsáno v další sekci.

## **Odstranění ořezaných dat obrázku**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jde o destruktivní optimalizaci: po uložení prezentace již nejsou odstraněné pixely k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými obrázkovými rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořez WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Kompresní rastrových obrázků**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/compressimage/) snižuje rozlišení rastrového obrázku relativně k velikosti, při které je obrázek zobrazován. Může také v téže operaci odstranit ořezané oblasti. Metoda vrací `true`, pokud byl obrázek změněn (zmenšen nebo oříznut), a `false`, pokud nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/picturescompression/), když stačí standardní cílové rozlišení:

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

Místo výčtu lze předat vlastní kladnou DPI hodnotu, pokud je vyžadován konkrétní cíl.

Kompresi zaměřujeme na rastrové obrázky. SVG a metafily nejsou tímto rasterovým kompresním pracovním tokem zmenšeny. Pamatujte také, že nižší rozlišení a odstraněné ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa efektů transformace obrázku**

Kompletní pracovní tok zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce, inspekci, odstranění a ověření round‑trip najdete v [Image Transform Effects](/slides/cs/cpp/image-transform-effects/).

## **Uzamčení geometrie obrázkového rámečku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframelock/) řídí, které operace úprav jsou pro obrázkový rámeček zakázány. Například [aspect-ratio lock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) zachová proporce tvaru při změně velikosti.

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

Uzamčení se vztahuje na tvar obrázkového rámečku. Nenutí zdrojový obrázek k přeškálování ani k trvalé změně poměru stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku „stretch“, hodnoty stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázkového rámečku. Kladná procenta vytvářejí odsazení od okraje, záporná procenta vytvoří výstupek.

To se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého se viditelná výplň obrázku roztahuje.

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

Používejte stretch offsety pro umístění výplně. Používejte vlastnosti ořezu, když chcete skrýt okraje zdrojového obrázku.

## **Úložiště, velikost souboru a úvahy o exportu**

Hlavní kompromisy jsou snazší řídit, když jsou úložiště obrázků a formátování obrázkových rámečků řešeny odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a renderování na serveru, ale velké rastrové obrázky zvyšují velikost PPTX a paměťovou náročnost.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na externích souborech, které musí zůstávat dostupné na uložených cestách nebo místech.
- **Ořez** je zpočátku ne‑destruktivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresi** může výrazně snížit velikost souboru u přemrštěných rastrových obrázků, ale snižuje rozlišení zdroje. Použijte ji po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektorů. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Export snímku do rastrových formátů vždy převádí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opětovně používat existující zdroj [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/), pokud je to možné, místo opakovaného načítání stejného souboru do pracovního toku prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: loga a diagramy nechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte ořezané pixely jen tehdy, když další úpravy nejsou potřeba, a vyhněte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi obrázkovým rámečkem a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) představuje zdroj obrázku spojený s prezentací. [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrické a formátovací údaje na úrovni rámečku, jako jsou velikost, otočení, hodnoty ořezu, efekty a uzamčení.

**Mám vložit nebo propojit obrázky?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo renderovaná bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Ne samo o sobě. Normální nastavení ořezu pouze skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rozlišení rasteru a odstranění ořezaných oblastí zahazuje data obrázku. Uchovávejte původní zdrojový obrázek mimo prezentaci, pokud může být později vyžadována úprava ve vysokém rozlišení.

**Jak zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektorů. Vložený [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) lze extrahovat přímo. Rendering snímku do rasterového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak mohu zabránit nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rámeček. Otestujte tvar pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) před aplikací runtime přetypování a přiřaďte výsledek přetypování do lokální proměnné před přístupem k členům specifickým pro obrázkový rámeček.