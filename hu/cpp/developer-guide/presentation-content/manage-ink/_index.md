---
title: PowerPoint prezentáció tinta objektumok kezelése C++-ban
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/cpp/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta nyom
- tinta kezelése
- tinta rajzolása
- rajzolás
- tinta export
- tinta renderelés
- tinta elrejtése
- IInkOptions
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "PowerPoint tinta objektumok kezelése, nyomok és ecsettulajdonságok szerkesztése, valamint a tinta megjelenésének szabályozása PDF, HTML, SVG, TIFF és kép exportálása során az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

A PowerPoint egy tinta funkciót kínál, amely lehetővé teszi szabadkézi vonalak rajzolását. A tintát fel lehet használni más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő konkrét elemek figyelem felkeltésére.

Az [Aspose.Slides.Ink](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/) névtér tartalmazza a tintával kapcsolatos objektumok kezeléséhez szükséges osztályokat és interfészeket. Például az [IInk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iink/) interfész egy tintobjektumot képvisel egy dián.

## **Különbségek a szokásos objektumok és a tinta objektumok között**

A PowerPoint dián lévő objektumok általában alakzatobjektumokként vannak ábrázolva. Egyszerű formájában egy alakzat egy tároló, amely meghatározza az objektum tényleges területét (a keretét), valamint olyan tulajdonságokat, mint a tároló mérete, alakja és háttere. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/cpp/shape-manipulations/#access-layout-formats-for-shape) szakaszt.

Azonban amikor a PowerPoint tintobjektummal dolgozik, figyelmen kívül hagyja a keret (konténer) minden tulajdonságát, kivéve a méretét. A konténer területének méretét a szabványos [IShape::get_Width](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_width/) és [IShape::get_Height](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_height/) metódusok határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tinta nyomok**

A tinta nyom egy alapvető elem, amelyet a toll mozgásának rögzítésére használnak digitális tinta írásakor. Egy nyom egy összekapcsolt pontok sorozatát tárolja.

A legegyszerűbb kódolási forma megadja minden mintapont X és Y koordinátáit. Ha az összes összekapcsolt pontot megjelenítik, egy ilyen képet kapnak:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok a rajzoláshoz**

Az ecsetet a tinta nyom pontjait összekötő vonalak rajzolására használják. Az ecsetnek saját színe és mérete van, amelyet az [IInkBrush::get_Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iinkbrush/get_color/) és az [IInkBrush::get_Size](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iinkbrush/get_size/) metódusok képviselnek.

### **Állítsa be a tinta ecset színét**

Ez a C++ kód mutatja, hogyan állítható be egy tinta ecset színe:

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

### **Állítsa be a tinta ecset méretét**

Ez a C++ kód mutatja, hogyan állítható be egy tinta ecset mérete:

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

Általában az ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén jelenik meg). Amikor az ecset szélessége és magassága egyezik, a PowerPoint a következő módon mutatja a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

Áttekintésképpen növeljük a tinta objektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy gondolja, hogy a vonalvastagság nulla (lásd a fenti képet).

Ezért a teljes tinta objektum látható területének meghatározásához a nyomok ecsetméretét is figyelembe kell venni. Itt a céltárgy (a kézírásos szövegnym) a tároló (keret) méretéhez lett méretezve. Amikor a tároló mérete változik, az ecsetméret állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz szövegobjektumoknál:

![ink_powerpoint6](ink_powerpoint6.png)

## **A tinta megjelenésének vezérlése exportálás és renderelés során**

Az Aspose.Slides a [IInkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/) interfészt biztosítja a tinta objektumok megjelenésének szabályozásához exportált vagy renderelt kimenetben. A metódusait használhatja a tinta teljes elrejtésére vagy a tinta ecset maszk műveletek értelmezésének módosítására.

A tinta opciók több kimenettípus export vagy renderelési beállításain keresztül érhetők el:

| Kimenet | Tintával kapcsolatos opciók metódusa |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Diakép | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Ugyanaz a két beállítás érhető el ezen metódusokkal:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_hideink/) meghatározza, hogy a tinta objektumok bele legyenek-e vonva a kimenetbe. Alapértelmezett értéke `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) azt határozza meg, hogy egy maszk műveletet átlátszatlanságként értelmeznek‑e tinta ecset renderelésekor. Alapértelmezett értéke `true`; állítsa `false`‑ra ROP művelet használatához.

### **Tinta objektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a tinta objektumok láthatóak maradnak exportáláskor. Hívja meg a [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_hideink/) metódust `true`‑val, ha tiszta kimenetre van szüksége kézírásos jegyzetek vagy egyéb tinta tartalom nélkül.

A következő C++ példa egy prezentációt PDF‑be exportál, miközben elrejti az összes tinta objektumot:

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

### **Tinta objektumok elrejtése diák képként való renderelésekor**

A tinta objektumok elrejtéséhez diák bitmap képként történő renderelésekor konfigurálja a [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) beállítást, és adja át a renderelési opciókat az [ISlide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódusnak.

A következő C++ példa az első diát PNG képként rendereli tinta objektumok nélkül:

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

### **Tintamaska renderelésének vezérlése**

Az [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) metódus szabályozza, hogyan értelmeződnek a maszk műveletek tinta ecsetek renderelésekor. Alapértelmezett értéke `true`, ami átlátszatlanságot használ. Hívja meg a metódust `false`‑val ROP művelet használatához.

A következő C++ példa egy diát SVG‑be exportál, és ROP‑alapú renderelést alkalmaz a tinta maszk műveleteknél:

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

Ugyanaz a beállítás alkalmazható a [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) használatával prezentáció exportálásakor vagy diák TIFF‑re renderelésekor.

### **Válasszon a tinták elrejtése vagy megtartása között**

Használja a [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_hideink/) metódust `true`‑val, ha az exportált fájlnak tiszta változatnak kell lennie a megjegyzésekkel ellátott prezentációból, például egy végleges, terjesztésre szánt másolat esetében, amelyben nincsenek felülvizsgálati jelek.

Hagyja a tintát láthatóan (`false` alapértelmezett beállítás), ha a tinta megjegyzések a szándékolt tartalom részei, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek a kimenetben is láthatónak kell lenniük. Ez lehetővé teszi, hogy ugyanabból a prezentációból külön felülvizsgálati és végleges kimeneteket generáljon anélkül, hogy módosítaná a forrás tinta objektumokat.

## **Gyakran ismételt kérdések**

**Megváltoztathatom egy meglévő tinta vonal színét vagy méretét?**

Igen. Szerezze be a nyomot az [IInk::get_Traces](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iink/get_traces/) metódussal, majd módosítsa az [IInkTrace::get_Brush](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iinktrace/get_brush/) értékét. Hívhatja az [IInkBrush::set_Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iinkbrush/set_color/) és az [IInkBrush::set_Size](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/iinkbrush/set_size/) metódusokat az ecseten.

**A tinta elrejtése megváltoztatja a forrás prezentációt?**

Nem. Az [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/iinkoptions/set_hideink/) csak a renderelt vagy exportált eredményt befolyásolja; nem távolítja el vagy módosítja a tinta objektumokat a forrás prezentációban.

**Mely export formátumok támogatják a tinta opciókat?**

PDF, HTML, SVG, TIFF és bitmap diaképek esetén konfigurálhatja a tinta opciókat a fenti megfelelő export vagy renderelési beállításokon keresztül.

**További olvasnivaló**

* A formákról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/cpp/powerpoint-shapes/) szakaszban.
* A hatékony értékekről a [Shape Effective Properties](https://docs.aspose.com/slides/hu/cpp/shape-effective-properties/#get-effective-font-height-value) oldalon.
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-pdf/) leírást.
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-html/) leírást.
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/cpp/render-a-slide-as-an-svg-image/) leírást.
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-tiff/) leírást.
* A diák képbe renderelés részleteiért lásd a [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/cpp/convert-slide/) leírást.