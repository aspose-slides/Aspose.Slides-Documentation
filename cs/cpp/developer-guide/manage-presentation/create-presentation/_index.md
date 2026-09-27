---
title: Vytváření prezentací v C++
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/cpp/create-presentation/
keywords:
- vytvořit prezentaci
- nová prezentace
- vytvořit PPT
- nový PPT
- vytvořit PPTX
- nový PPTX
- vytvořit ODP
- nový ODP
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte prezentace v C++ pomocí Aspose.Slides — vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat textové pole na její první snímek a výsledek uložit jako soubor. Na konci je krátké FAQ, které pokrývá běžné otázky ohledně formátů, šablon, velikosti snímků, jednotek, využití paměti, vícevláknovosti, licencování, digitálního podpisu a podpory VBA.

Než začnete, přidejte Aspose.Slides do svého projektu: z NuGet ve Visual Studio projektu na Windows nebo ze ZIP balíčku s CMake na Linuxu. Viz [Installation](/slides/cs/cpp/installation/).

## **Vytvoření prezentace PowerPoint**

Chcete‑li vytvořit prezentaci a umístit textové pole na její první snímek, postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) . Nová prezentace již obsahuje jeden prázdný snímek.  
2. Získejte tento snímek pomocí metody [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) a jeho index 0.  
3. Přidejte obdélník pomocí metody [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) a nastavte jeho text metodou [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) .  
4. Uložte prezentaci jako soubor PPTX metodou [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) .

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Horní levý roh obdélníku je 50 bodů od levého okraje a 50 bodů od horního okraje snímku, šířka obdélníku je 400 bodů a výška 100 bodů. Program uloží *hello.pptx* do svého pracovního adresáře, s jedním snímkem, který obsahuje obdélník a jeho text. Bez licence Aspose.Slides také přidá vodotisk hodnocení na každý uložený snímek; viz [Licensing](/slides/cs/cpp/licensing/) .

## **Často kladené otázky**

### Do jakých formátů mohu uložit novou prezentaci?

Můžete uložit do [PPTX, PPT, and ODP](/slides/cs/cpp/save-presentation/), a exportovat do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/), a [images](/slides/cs/cpp/convert-powerpoint-to-png/), mezi jinými.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné formáty [are supported](/slides/cs/cpp/supported-file-formats/) .

### Jak mohu řídit velikost/snimej poměr při vytváření prezentace?

Nastavte [slide size](/slides/cs/cpp/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastní rozměry) a zvolte, jak se má obsah škálovat.

### V jakých jednotkách jsou měřeny velikosti a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?

Použijte [BLOB management strategies](/slides/cs/cpp/manage-blob/), omezte úložiště v paměti využíváním dočasných souborů a upřednostněte pracovní postupy založené na souborech před čistě paměťovými proudy.

### Mohu vytvářet/ukládat prezentace paralelně?

Nemůžete operovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) z [multiple threads](/slides/cs/cpp/multithreading/). Spusťte samostatné, izolované instance na každém vlákně nebo procesu.

### Jak odstranit zkušební vodotisk a omezení?

[Apply a license](/slides/cs/cpp/licensing/) jednou na proces. XML licence musí zůstat nepozměněno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

### Můžu digitálně podepsat PPTX, který vytvořím?

Ano. [Digital signatures](/slides/cs/cpp/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

### Jsou makra (VBA) podporována v vytvořených prezentacích?

Ano. Můžete [create/edit VBA projects](/slides/cs/cpp/presentation-via-vba/) a uložit soubory s makry, jako PPTM/PPSM.