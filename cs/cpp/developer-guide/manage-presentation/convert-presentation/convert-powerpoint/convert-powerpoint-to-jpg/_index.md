---
title: Převod PPT a PPTX na JPG v C++
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/cpp/convert-powerpoint-to-jpg/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint na JPG
- prezentace na JPG
- snímek na JPG
- PPT na JPG
- PPTX na JPG
- uložit PowerPoint jako JPG
- uložit prezentaci jako JPG
- uložit snímek jako JPG
- uložit PPT jako JPG
- uložit PPTX jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- C++
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v C++ pomocí Aspose.Slides s rychlými a spolehlivými ukázkami kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do JPG obrázků pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides for C++ vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky prezentace před kopírováním nebo ukázat prezentaci v režimu jen pro čtení. Aspose.Slides vám umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod snímků prezentace na JPG obrázky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) ze sbírky snímků prezentace.
1. Vytvořte obrázek snímku pomocí metody [ISlide.GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/).
1. Zavolejte metodu [IImage.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/) na objektu obrázku. Jako argumenty předávejte název výstupního souboru a formát obrázku.

{{% alert color="info" %}} 

**Poznámka:** PPT, PPTX nebo ODP na JPG konverze se liší od konverze do jiných formátů v API Aspose.Slides for C++. Pro jiné formáty obvykle používáte metodu [IPresentation.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/). Pro konverzi do JPG však musíte použít metodu [IImage.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Vytvořte obrázek snímku v určeném měřítku.
    auto image = slide->GetImage(scaleX, scaleY);

    // Uložte obrázek na disk ve formátu JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Převod snímků na JPG s přizpůsobenými rozměry**

Chcete‑li změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním parametru do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). To vám umožní generovat obrázky s konkrétními hodnotami šířky a výšky, což zajišťuje, že výstup splňuje vaše požadavky na rozlišení a poměr stran. Tato flexibilita je zvláště užitečná při vytváření obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou vyžadovány přesné rozměry obrázku.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Vytvořte obrázek snímku ve specifikované velikosti.
    auto image = slide->GetImage(imageSize);

    // Uložte obrázek na disk ve formátu JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Vykreslit komentáře při ukládání snímků jako obrázky**

Aspose.Slides for C++ poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při jejich převodu do JPG obrázků. Tato funkčnost je zvláště užitečná pro zachování anotací, zpětné vazby nebo diskusí přidaných spolupracovníky v prezentacích PowerPoint. Povolením této možnosti zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadní jejich revizi a sdílení zpětné vazby, aniž by bylo nutné otevřít původní soubor prezentace.

Řekněme, že máme soubor prezentace „sample.pptx“ se snímkem, který obsahuje komentáře:

![Snímek s komentáři](slide_with_comments.png)

Následující C++ kód převádí snímek na JPG obrázek a zachovává komentáře:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
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

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Nastavte možnosti pro komentáře snímku.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Převést první snímek na obrázek.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Výsledek:

![JPG obrázek s komentáři](image_with_comments.png)

## **Viz také**

Podívejte se na další možnosti převodu PPT, PPTX nebo ODP na obrázky, například:

- [Převést PowerPoint na GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/)
- [Převést PowerPoint na PNG](/slides/cs/cpp/convert-powerpoint-to-png/)
- [Převést PowerPoint na TIFF](/slides/cs/cpp/convert-powerpoint-to-tiff/)
- [Převést PowerPoint na SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Chcete‑li vidět, jak Aspose.Slides převádí PowerPoint na JPG obrázky, vyzkoušejte tyto bezplatné online konvertory: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT to JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg). 

{{% /alert %}}

![Bezplatný online konvertor PPTX na JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose poskytuje [GRATUÁLNÍ webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete spojit obrázky [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně.

Použitím stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Další informace najdete na těchto stránkách: převod [obrázek na JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Často kladené dotazy**

### Podporuje tato metoda hromadný převod?

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

### Podporuje převod SmartArt, grafy a další složité objekty?

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslení se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

### Existují omezení počtu snímků, které lze zpracovat?

Aspose.Slides sám neklade žádná striktní omezení na počet snímků, které můžete zpracovat. Nicméně můžete narazit na chybu nedostatku paměti při práci s velkými prezentacemi nebo obrázky s vysokým rozlišením.