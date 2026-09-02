---
title: Převod snímků prezentace na obrázky v C++
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/cpp/convert-slide/
keywords:
- převod snímku
- export snímku
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v C++ pomocí Aspose.Slides pro C++."
---
## **Úvod**

Aspose.Slides pro C++ může vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Chcete-li převést snímek na obrázek, postupujte podle těchto kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/).
4. Zavolejte metodu [ISlide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/). Vrátí objekt [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/).
5. Zavolejte metodu [IImage::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/) a určete výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejsnazší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) lze zpracovat v paměti nebo uložit do souboru.

Následující příklad v C++ vykreslí první snímek a uloží jej jako PNG obrázek:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Převod snímků na obrázky s vlastním rozměrem**

Použijte přetíženou metodu [ISlide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/), která přijímá hodnotu [Size](https://reference.aspose.com/slides/cs/cpp/system.drawing/size/), pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek o rozměrech 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Přiřaďte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) metodě [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/), abyste určili, kde se mají poznámky a komentáře zobrazovat.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře vpravo od něj:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Při převodu snímku na obrázek nepoužívejte metodu [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) s hodnotou [BottomFull](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notespositions/). Poznámky mohou obsahovat více textu, než co lze ve fixním rozměru obrázku zobrazit. Místo toho použijte [BottomTruncated](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/) vám umožní řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Převod všech snímků na obrázky**

Procházejte kolekci snímků a převedete celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je výslovně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek s horizontálním a vertikálním měřítkem 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je potřeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od rastrového obrázku může EMF zachovat vektorové kreslicí operace, které se měřítkem neztratí na ostrosti. EMF je však především formát kompatibility pro aplikace s podporou Windows metafile, nikoli univerzální výměnný formát. Navíc může být složitý obsah snímku, jako bitmapové obrázky a některé efekty, uložen jako rasterizované prvky uvnitř vektorového kontejneru metafile.

### **Export snímku do EMF**

Metoda [ISlide::WriteAsEmf](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/writeasemf/) zapíše [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Volající vlastní proud předaný metodě [ISlide::WriteAsEmf](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/writeasemf/) a musí jej zavřít nebo uvolnit. Aspose.Slides zapisuje na aktuální pozici proudu a ponechává proud otevřený.

### **Převod SVG obrázku na EMF a jeho přidání do prezentace**

Použijte [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/writeasemf/) k převodu SVG obsahu na EMF. Výsledné bajty lze přidat do prezentace pomocí [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/) a umístit na snímek pomocí [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addpictureframe/).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/svgimage/) ze SVG značkovacího jazyka, převede jej na EMF v paměti, vloží metafile na první snímek a uloží prezentaci:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/writeasemf/) nepřevádí vlastnictví cílového proudu. Po zápisu je pozice proudu na konci vygenerovaných dat. Příklad volá [MemoryStream::ToArray](https://reference.aspose.com/slides/cs/cpp/system.io/memorystream/toarray/) pro získání kompletního bufferu bez ohledu na aktuální pozici proudu a poté předává tento pole bajtů metodě [IImageCollection::AddImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/addimage/). Proudu nechte otevřený, dokud jej spotřebitel nedokončí číst, a poté jej zavřete.

Generování EMF je k dispozici na operačních systémech podporovaných Aspose.Slides pro C++, ale vykreslování se může lišit mezi platformami, pokud nejsou k dispozici fonty nebo nativní grafické závislosti. Nainstalujte fonty použité ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, řiďte se [požadavky na platformu](/slides/cs/cpp/system-requirements/) pro Aspose.Slides pro C++ a ověřte výsledek v cílové aplikaci, která EMF konzumuje. Aplikace pro Linux a macOS často mají omezenou nebo nekonzistentní podporu pro zobrazování a úpravu Windows metafile.

## **Vykreslování barevných emoji**

{{% alert title="Note" color="info" %}}
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být nainstalovány a dostupné na systému provádějícím převod fonty emoji použité v prezentaci. Například pokud prezentace používá **Segoe UI Emoji** a tento font chybí, mohou se emoji ve výstupních obrázcích zobrazovat černobíle.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [ISlide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/) vykreslí statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit jako běžné snímky. Začleňte je do smyčky zpracování, jak je uvedeno v výše uvedeném příkladu.

**Zůstávají ve snímkových obrázcích stíny a další efekty?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty ve snímkových obrázcích.