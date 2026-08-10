---
title: Správa ink objektů prezentace v C++
linktitle: Spravovat ink
type: docs
weight: 95
url: /cs/cpp/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- spravovat ink
- kreslit ink
- kreslení
- export ink
- renderování ink
- skrýt ink
- IInkOptions
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte ink objekty PowerPointu, upravujte stopy a vlastnosti štětců a řiďte vzhled ink během exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro C++."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která umožňuje kreslit volné tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/) obsahuje třídy a rozhraní potřebná pro práci s objekty ink. Například rozhraní [IInk](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou obvykle reprezentovány objekty tvaru. V nejjednodušší formě je tvar kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace naleznete v [Shape Layout Format](https://docs.aspose.com/slides/cs/cpp/shape-manipulations/#access-layout-formats-for-shape).

Avšak když PowerPoint zpracovává objekt ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními metodami [IShape::get_Width](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_width/) a [IShape::get_Height](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_height/) metodami:

![ink_powerpoint1](ink_powerpoint1.png)

## **Stopy Ink**

Stopa ink je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci propojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny propojené body vykresleny, vytvoří obraz jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslení čar, které spojují body stopy ink. Štětec má svou vlastní barvu a velikost, reprezentované metodami [IInkBrush::get_Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iinkbrush/get_color/) a [IInkBrush::get_Size](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iinkbrush/get_size/) metodami.

### **Nastavení barvy štětce ink**

Tento kód C++ ukazuje, jak nastavit barvu štětce ink:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Nastavení velikosti štětce ink**

Tento kód C++ ukazuje, jak nastavit velikost štětce ink:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Obecně šířka a výška štětce nejsou stejné, takže PowerPoint nezobrazuje velikost štětce (odpovídající sekce dat je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a přezkoumáme důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců — vždy předpokládá, že tloušťka čáry je nula (viz předchozí obrázek).

Proto pro určení viditelné oblasti celého objektu ink je třeba zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) škálován na velikost kontejneru (rámce). Když se velikost kontejneru změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu Ink při exportu a vykreslování**

Aspose.Slides poskytuje rozhraní [IInkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/) pro kontrolu toho, jak mají být objekty ink zobrazeny v exportovaném nebo vykresleném výstupu. Můžete použít jeho metody k úplnému skrytí ink nebo ke změně způsobu interpretrace operací masky štětce ink.

Možnosti ink jsou k dispozici prostřednictvím možností exportu nebo vykreslování pro několik typů výstupu:

| Výstup | Metoda možností Ink |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Stejné dvě nastavení jsou k dispozici prostřednictvím těchto metod:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_hideink/) určuje, zda jsou objekty ink zahrnuty ve výstupu. Výchozí hodnota je `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) určuje, zda je operace masky interpretována jako neprůhlednost při vykreslování štětce ink. Výchozí hodnota je `true`; nastavte na `false` pro použití operace ROP místo ní.

### **Skrytí objektů Ink ve výstupu PDF**

Ve výchozím nastavení zůstávají objekty ink během exportu viditelné. Zavolejte [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_hideink/) s hodnotou `true`, když potřebujete čistý výstup bez ručně psaných anotací nebo jiného obsahu ink.

Následující příklad C++ exportuje prezentaci do PDF při skrytí všech objektů ink:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Skrytí objektů Ink při vykreslování snímku jako obrázku**

Pro skrytí objektů ink při vykreslování snímků jako bitmapové obrázky nakonfigurujte [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) a předávejte možnosti vykreslování metodě [ISlide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/).

Následující příklad C++ vykreslí první snímek jako PNG obrázek bez objektů ink:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Řízení vykreslování masky Ink**

Metoda [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) řídí, jak jsou operace masky interpretovány při vykreslování štětců ink. Výchozí hodnota je `true`, což používá neprůhlednost. Zavolejte metodu s `false` pro použití operace ROP místo ní.

Následující příklad C++ exportuje snímek do SVG a používá vykreslování založené na ROP pro operace masky ink:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Stejné nastavení lze použít prostřednictvím [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) při exportu prezentace nebo při vykreslování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat Ink**

Použijte [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_hideink/) s hodnotou `true`, když má být exportovaný soubor čistou verzí anotované prezentace, například finální kopií určenou k distribuci bez revizních značek.

Nechte ink viditelný (výchozí nastavení `false`), když jsou ink anotace součástí zamýšleného obsahu, jako jsou revizní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat viditelné ve výstupním výsledku. To umožňuje aplikacím generovat samostatné revizní a finální výstupy ze stejné prezentace bez úpravy zdrojových objektů ink.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího tahu ink?**

Ano. Získáte stopu pomocí [IInk::get_Traces](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iink/get_traces/), poté změníte její [IInkTrace::get_Brush](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iinktrace/get_brush/). Můžete zavolat [IInkBrush::set_Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iinkbrush/set_color/) a [IInkBrush::set_Size](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/iinkbrush/set_size/) na štětec.

**Mění skrytí ink zdrojovou prezentaci?**

Ne. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/iinkoptions/set_hideink/) ovlivňuje pouze vykreslený nebo exportovaný výsledek; neodstraňuje ani nemodifikuje objekty ink ve zdrojové prezentaci.

**Které exportní formáty podporují možnosti ink?**

Možnosti ink můžete konfigurovat pro PDF, HTML, SVG, TIFF a bitmapové snímky snímků prostřednictvím příslušných možností exportu nebo vykreslování uvedených výše.

**Další čtení**

* Pro čtení o tvarech obecně navštivte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/cpp/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/cpp/shape-effective-properties/#get-effective-font-height-value).
* Podrobnosti o exportu PDF najdete v [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/cpp/convert-powerpoint-to-pdf/).
* Podrobnosti o exportu HTML najdete v [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/cpp/convert-powerpoint-to-html/).
* Podrobnosti o exportu SVG najdete v [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/cpp/render-a-slide-as-an-svg-image/).
* Podrobnosti o exportu TIFF najdete v [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/cpp/convert-powerpoint-to-tiff/).
* Podrobnosti o vykreslování snímků na obrázky najdete v [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/cpp/convert-slide/).