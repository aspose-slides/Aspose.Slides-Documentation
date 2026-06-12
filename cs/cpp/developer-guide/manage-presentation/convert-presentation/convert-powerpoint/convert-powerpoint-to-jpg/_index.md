---
title: Převést PPT a PPTX na JPG v C++
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/cpp/convert-powerpoint-to-jpg/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
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
description: "Převést snímky PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v C++ pomocí Aspose.Slides s rychlými a spolehlivými ukázkami kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument na JPG obrázky usnadňuje sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides for C++ vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo ukázat prezentaci v režimu pouze ke čtení. Aspose.Slides umožňuje převést celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převést snímky prezentace na JPG obrázky**

Zde jsou kroky pro převod souboru PPT, PPTX nebo ODP na JPG:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte objekt snímku typu [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) z kolekce snímků prezentace.
3. Vytvořte obrázek snímku pomocí metody [ISlide.GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/).
4. Zavolejte metodu [IImage.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/) na objektu obrázku. Předávejte název výstupního souboru a formát obrázku jako argumenty.

{{% alert color="primary" %}} 
**Poznámka:** Převod PPT, PPTX nebo ODP na JPG se liší od převodu do jiných formátů v Aspose.Slides for C++ API. Pro jiné formáty obvykle používáte metodu [IPresentation.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/). Pro převod na JPG však musíte použít metodu [IImage.Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/).
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Vytvořit obrázek snímku v zadaném měřítku.
    auto image = slide->GetImage(scaleX, scaleY);

    // Uložit obrázek na disk ve formátu JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Převést snímky na JPG s vlastním rozměrem**

Chcete‑li změnit rozměry výsledných JPG obrázků, můžete nastavit velikost obrázku předáním parametru do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). To vám umožní generovat obrázky s konkrétními šířkami a výškami, aby výstup splňoval požadavky na rozlišení a poměr stran. Tato flexibilita je zvláště užitečná při generování obrázků pro webové aplikace, zprávy nebo dokumentaci, kde jsou vyžadovány přesné rozměry obrázku.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Vytvořit obrázek snímku v zadané velikosti.
    auto image = slide->GetImage(imageSize);

    // Uložit obrázek na disk ve formátu JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Vykreslit komentáře při ukládání snímků jako obrázky**

Aspose.Slides for C++ poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při jejich převodu do JPG obrázků. Tato funkce je zvláště užitečná pro zachování anotací, zpětné vazby nebo diskusí přidaných spolupracovníky v PowerPoint prezentacích. Povolením této možnosti zajistíte, že komentáře budou viditelné v generovaných obrázcích, což usnadňuje revizi a sdílení zpětné vazby bez nutnosti otevírat původní soubor prezentace.

Představme si, že máme soubor prezentace „sample.pptx“ se snímkem, který obsahuje komentáře:

![The slide with comments](slide_with_comments.png)

Následující C++ kód převádí snímek na JPG obrázek při zachování komentářů:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Nastavit možnosti pro komentáře snímku.
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

![The JPG image with comments](image_with_comments.png)

## **Viz také**

Podívejte se na další možnosti převodu PPT, PPTX nebo ODP na obrázky, například:

- [Převést PowerPoint na GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/)
- [Převést PowerPoint na PNG](/slides/cs/cpp/convert-powerpoint-to-png/)
- [Převést PowerPoint na TIFF](/slides/cs/cpp/convert-powerpoint-to-tiff/)
- [Převést PowerPoint na SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Chcete‑li vidět, jak Aspose.Slides převádí PowerPoint na JPG obrázky, vyzkoušejte tyto bezplatné online převodníky: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/cs/conversion/pptx-to-jpg) a [PPT to JPG](https://products.aspose.app/slides/cs/conversion/ppt-to-jpg). 
{{% /alert %}}

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose poskytuje [ZDARMA Collage webovou aplikaci](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG to JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Další informace najdete na těchto stránkách: převést [image to JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/); převést [JPG to image](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/); převést [JPG to PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/); převést [PNG to JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/); převést [PNG to SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/); převést [SVG to PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Často kladené otázky**

**Podporuje tato metoda hromadný převod?**

Ano, Aspose.Slides umožňuje hromadný převod více snímků na JPG v jedné operaci.

**Podporuje převod SmartArt, grafy a další složité objekty?**

Ano, Aspose.Slides vykresluje celý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslování se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

**Existují nějaká omezení počtu snímků, které lze zpracovat?**

Aspose.Slides nepřikládá žádná přísná omezení na počet snímků, které můžete zpracovat. Nicméně při práci s velkými prezentacemi nebo obrázky vysokého rozlišení můžete narazit na chybu nedostatku paměti.