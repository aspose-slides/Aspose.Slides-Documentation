---
title: "Optimalizace správy obrázků v prezentacích pomocí C++"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/cpp/image/
keywords:
- "přidat obrázek"
- "přidat obrázek"
- "nahradit obrázek"
- "kolekce obrázků"
- "rámec obrázku"
- "propojený obrázek"
- "pozadí"
- "přidat PNG"
- "přidat JPG"
- "přidat SVG"
- "SVG na tvary"
- "externí SVG zdroje"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Naučte se, jak přidávat, znovu používat, propojit, nahrazovat a spravovat rastrové i SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++."
---
## **Úvod**

Aspose.Slides pro C++ poskytuje několik způsobů práce s obrázky a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit ho v rámečku obrázku, použít jej jako pozadí snímku, propojit na externí obrázek, nahradit sdílený obrázkový zdroj nebo převést obsah SVG na upravitelné tvary.

Tento článek se zaměřuje na obrázkové zdroje a jejich použití v celé prezentaci. Pro oříznutí, průhlednost, efekty, roztažení a další formátování aplikované na jednotlivý rámeček obrázku viz [Picture Frame](/slides/cs/cpp/picture-frame/).

## **Pochopení modelu obrázku**

Následující koncepty API jsou úzce související, ale nejsou zaměnitelné:

- [Kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/) ukládá obrázkové zdroje používané v prezentaci. Použijte [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/) k přidání dat obrázku a získání zdroje [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).
- [Rámeček obrázku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) je tvar, který zobrazuje obrázek na snímku, rozvržení nebo masteru. Použijte [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addpictureframe/) k umístění obrázkového zdroje na snímek.
- Pozadí snímku používá obrázek jako část výplně snímku, nikoli jako tvar. Proto se nechová jako rámeček obrázku.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/replaceimage/) nahrazuje obrázkový zdroj. Pokud jej používá několik prvků prezentace, všichni používají náhradu.
- Převod SVG na tvary vytvoří upravitelné tvary snímku. Po převodu není obsah již spravován jako jeden obrázkový zdroj.

Typický postup je tedy: přidat data obrázku do kolekce obrázků, získat [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/), a potom použít tento zdroj v jednom nebo více rámečcích obrázku nebo výplních.

## **Přidání vloženého obrázku**

Chcete‑li vložit lokální obrázek, načtěte soubor, přidejte jeho data do kolekce obrázků a vytvořte rámeček obrázku, který použije vrácený zdroj [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).

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

Obrázek přidaný tímto způsobem je vložen v prezentaci, takže výsledný soubor nezávisí na dostupnosti původního souboru obrázku.

### **Přidání obrázku z webu**

Když je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený obrázkový zdroj stejným způsobem jako lokální obrázek.

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

Ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný. V aplikacích, které již používají jiného HTTP klienta, můžete obrázek stáhnout tímto klientem a předat získané bajty nebo proud metodě [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/).

## **Opakované použití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a při vytváření dalších rámečků obrázku použijte vrácený [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/). Tím se vyhnete opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným obrázkovým zdrojem a jeho použitím je explicitní.

Pro grafiku, která by se měla automaticky objevovat na mnoha snímcích, např. logo společnosti, zvažte umístění rámečku obrázku na [slide master](/slides/cs/cpp/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každém snímku.

## **Použití obrázku jako pozadí snímku**

Obrázek pozadí je přiřazen výplni snímku; není přidán jako tvar rámečku obrázku. To je užitečné, když má obrázek pokrýt pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

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

Pro další možnosti pozadí, včetně pozadí masteru a rozvržení, viz [Presentation Background](/slides/cs/cpp/presentation-background/).

## **Vložené obrázky a propojené obrázky**

Vložené a propojené obrázky mají odlišné kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Propojený obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může snížit velikost prezentace, ale externí zdroj musí zůstat přístupný při otevření nebo vykreslování prezentace.

Propojený obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/set_linkpathlong/) místo vložení dat obrázku.

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

Používejte propojené obrázky jen tehdy, když prostředí nasazení může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by se měla škálovat bez ztráty detailu jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako obrázkový zdroj, tak jako zdroj pro upravitelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý obrázkový zdroj do rámečku obrázku.

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

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, styly nebo písma. Pro tyto případy [SvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/svgimage/) poskytuje konstruktory, které přijímají [IExternalResourceResolver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/) a základní URI. Rozlišovač může převést relativní URI na povolené absolutní URI a vrátit proud pro požadovaný zdroj.

Rozlišovač zpřístupní externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepisuje SVG do samostatného dokumentu. Pokud musí SVG zůstat přenosný, vložte jeho potřebné zdroje přímo do SVG, například pomocí `data:` URI pro propojené obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hostitele, ke kterým může rozlišovač přistupovat. Síťové rozlišovače by měly také aplikovat časové limity, limity velikosti odpovědi a validaci obsahu.

### **Převod SVG na upravitelné tvary**

Aspose.Slides dokáže převést SVG na skupinu upravitelných tvarů snímku, podobně jako odpovídající příkaz v PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addgroupshape/) přijímající [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) k provedení převodu.

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

Používejte převod SVG‑na‑tvary, když je potřeba individuální vektorové elementy upravovat jako tvary PowerPointu. Pokud stačí SVG pouze zobrazit, je jednodušší ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího obrázkového zdroje**

Použijte [IPPImage::ReplaceImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/replaceimage/) když chcete nahradit existující obrázkový zdroj. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

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

Pokud několik rámečků obrázku, pozadí, masterů nebo rozvržení používá stejný obrázkový zdroj, jeho nahrazení aktualizuje všechny tyto použití. Pokud má změnit jen jeden rámeček, přiřaďte tomuto rámečku jiný obrázek místo nahrazení sdíleného zdroje.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/replaceimage/) také poskytuje přetížení přijímající [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) nebo jiný [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).

## **Praktické rady pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou prezentaci zbytečně zvětšit. Používejte zdrojové obrázky s rozměry vhodnými pro zamýšlenou velikost zobrazení, opakovaně využívejte sdílené obrázkové zdroje, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky ve vysokém rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámečcích, může [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/compressimage/) snížit data obrázku podle vybrané rozlišovací schopnosti a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli o správu kolekce obrázků, takže viz [Picture Frame](/slides/cs/cpp/picture-frame/) pro související operace formátování.

### **Volba mezi vloženým a propojeným obsahem**

Vkládání dělá prezentaci přenosnou, protože všechna požadovaná data obrázku cestují se souborem. Propojení může snížit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelná a stabilní.

### **Opakované využití značky**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku použijte jeden obrázkový zdroj a znovu jej využijte. Pokud grafika patří k návrhu prezentace spíše než k obsahu snímku, umístěte ji na master nebo rozvržení, aby byla zděděna příslušnými snímky.

### **Udržujte SVG zdroje přenosné**

Samostatné SVG je snazší přesouvat a vykreslovat konzistentně než SVG závislé na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je potřeba jednotlivé vektorové elementy upravovat.

### **Použití Aspose.Slides Image API**

Pro C++ workflow s obrázky používejte Aspose.Slides [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/cpp/aspose.slides/images/) API, když potřebujete objekt obrázku, a [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/), když potřebujete zaregistrovat data obrázku jako zdroj prezentace. Přetížení kolekce také podporují pole bajtů a proudy, což je užitečné, když data obrázku pocházejí ze souborů, síťových klientů, databází nebo jiných knihoven.

Generování EMF obsahu ze sešitů nebo jiného produktu je samostatný integrační proces a není předmětem tohoto článku. Pokud existující soubor WMF nebo EMF potřebujete pouze vložit do prezentace, předejte jeho data vhodnému přetížení [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/) bez přidání další závislosti produktu do workflow správy obrázků.

## **Časté otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá znovu použitelné obrázkové zdroje. Rámeček obrázku je tvar snímku, který zobrazuje jeden z těchto zdrojů a poskytuje formátování specifické pro obrázek, jako je ořez a efekty.

**Jak nejlépe nahradit stejné logo všude?**

Pokud je logo již sdíleno jako jeden obrázkový zdroj, nahraďte tento zdroj pomocí [IPPImage::ReplaceImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/replaceimage/). Pro celopodnikovou značku můžete také umístit logo na master nebo rozvržení, čímž snížíte duplicitní obsah snímků.

**Proč se propojený obrázek na jiném počítači ztratí?**

Propojený obrázek závisí na externím souboru nebo URL. Pokud z jiného počítače není tento zdroj dosažitelný, může být propojený obrázek nedostupný. V takovém případě vložte obrázek, aby byla prezentace samostatná.

**Lze vložené SVG upravovat jako tvary PowerPointu?**

Ano. Převodem SVG pomocí [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addgroupshape/) získáte skupinu upravitelných tvarů snímku místo jednoho SVG obrázku.

**Jak udržet prezentace s mnoha obrázky menší?**

Opakovaně využívejte sdílené obrázkové zdroje, vyhýbejte se zbytečně velkým rastrovým zdrojům, komprimujte vhodné rastrové obrázky podle potřeby, umisťujte opakovanou značku na master nebo rozvržení a používajte propojené obrázky jen tehdy, když je externí závislost přijatelná.