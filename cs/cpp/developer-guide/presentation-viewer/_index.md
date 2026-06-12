---
title: Vytvořit prohlížeč prezentací v C++
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/cpp/presentation-viewer/
keywords:
- prohlédnout prezentaci
- prohlížeč prezentací
- vytvořit prohlížeč prezentací
- prohlédnout PPT
- prohlédnout PPTX
- prohlédnout ODP
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v C++ pomocí Aspose.Slides. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides pro C++ se používá k vytváření prezentačních souborů se snímky. Tyto snímky lze zobrazit otevřením prezentace v Microsoft PowerPointu, například. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém preferovaném prohlížeči obrázků nebo vytvořit vlastní prohlížeč prezentací. V takových případech umožňuje Aspose.Slides exportovat jednotlivý snímek jako obrázek. Tento článek popisuje, jak to provést.

## **Vytvoření SVG obrázku ze snímku**

Chcete-li vytvořit SVG obrázek z prezentačního snímku pomocí Aspose.Slides, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Otevřete souborový proud.
1. Uložte snímek jako SVG obrázek do souborového proudu.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Vytvoření SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vytvoření [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu `set_Id` z [ISvgShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` lze použít k nastavení ID tvaru.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomáhá generovat miniatury snímků. Chcete-li vygenerovat miniaturu snímku pomocí Aspose.Slides, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku v definovaném měřítku.
1. Uložte miniaturu do libovolného požadovaného formátu obrázku.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Vytvoření miniatury snímku s rozměry definovanými uživatelem**

Chcete-li vytvořit miniaturu snímku s rozměry definovanými uživatelem, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku s definovanými rozměry.
1. Uložte miniaturu do libovolného požadovaného formátu obrázku.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Vytvoření miniatury snímku s poznámkami prezentujícího**

Chcete-li vygenerovat miniaturu snímku s poznámkami prezentujícího pomocí Aspose.Slides, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/) .
1. Použijte metodu `RenderingOptions.set_SlidesLayoutOptions` k nastavení polohy poznámek prezentujícího.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu referencovaného snímku s použitím nastavení vykreslování.
1. Uložte miniaturu do libovolného požadovaného formátu obrázku.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ukázkový příklad**

Můžete vyzkoušet zdarma aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/) a zjistit, co můžete s API Aspose.Slides vytvořit:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace?**

Ano. Můžete použít Aspose.Slides na serverové straně k vykreslení snímků jako obrázky nebo HTML a zobrazit je v prohlížeči. Navigační a přiblížení lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v vlastním prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej pomocí Aspose.Slides převést do HTML a poté výstup zobrazit v ovládacím prvku picture box (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zvládnout velké prezentace s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo vykreslování snímků na vyžádání. To znamená generovat obsah snímku pouze při navigaci uživatele k němu, což snižuje paměťovou náročnost a dobu načítání.