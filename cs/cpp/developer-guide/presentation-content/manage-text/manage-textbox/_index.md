---
title: Správa textových polí v prezentacích pomocí C++
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/cpp/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Aspose.Slides pro C++ usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zvyšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle umístěny v textových polích nebo tvarech. Proto musíte k přidání textu na snímek nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides pro C++ poskytuje rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape), které umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}
Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape), které umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) však mohou obsahovat text. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Proto při práci s tvarem, ke kterému chcete přidat text, byste měli zkontrolovat a potvrdit, že byl přetypován přes rozhraní `IAutoShape`. Teprve pak budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame), což je vlastnost pod `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/cpp/manage-textbox/#update-text) na této stránce. 
{{% /alert %}}

## **Vytvoření textového pole na snímku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).  
2. Získejte odkaz na první snímek nově vytvořené prezentace.  
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) s [ShapeType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) nastaveným na `Rectangle` na určené pozici na snímku a získejte odkaz na nově přidaný objekt `IAutoShape`.  
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*  
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`.  

Tento C++ kód—implementace výše uvedených kroků—ukazuje, jak přidat text na snímek:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Vytvoří instanci Presentation
auto pres = System::MakeObject<Presentation>();

// Získá první snímek v prezentaci
auto sld = pres->get_Slides()->idx_get(0);

// Přidá AutoShape s typem nastaveným jako Obdélník
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Přidá TextFrame do obdélníku
ashp->AddTextFrame(u" ");

// Přistoupí k textovému rámci
auto txtFrame = ashp->get_TextFrame();

// Vytvoří objekt Paragraph pro textový rámec
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Vytvoří objekt Portion pro odstavec
auto portion = para->get_Portions()->idx_get(0);

// Nastaví text
portion->set_Text(u"Aspose TextBox");

// Uloží prezentaci na disk
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Kontrola tvaru textového pole**

Aspose.Slides poskytuje metodu [get_IsTextBox](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_istextbox/) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/), která vám umožní prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento C++ kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Všimněte si, že pokud jednoduše přidáte automatický tvar pomocí metody `AddAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/), metoda `get_IsTextBox` tohoto tvaru vrátí `false`. Po přidání textu do tvaru pomocí metody `AddTextFrame` nebo metody `set_Text` však metoda `get_IsTextBox` vrátí `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() vrací false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() vrací true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() vrací false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() vrací true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() vrací false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() vrací false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() vrací false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() vrací false
```

## **Najděte tvar, který vlastní Text Frame**

V obecném kódu pro zpracování textu můžete získat objekt [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) aniž byste věděli, který objekt prezentace jej obsahuje. K navigaci zpět na vlastníka použijte [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentshape/).

Pro textový rámec, který patří k [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) nebo jinému tvaru obsahujícímu text, metoda [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentshape/) vrací vlastníka a metoda [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentcell/) vrací `nullptr`. Obě metody poskytují pouze čtecí navigaci, takže jejich volání nemění vlastnictví. Před přístupem k tvaru vždy zkontrolujte, zda vrácená hodnota není `nullptr`.

Kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulek, včetně tvarů spojených s uzly SmartArt, najdete v sekci [Search and Replace Text](/slides/cs/cpp/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje metody [set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) a [set_ColumnSpacing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format)), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezery mezi sloupci v bodech.

Tento kód v C++ demonstruje popsanou operaci: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Získá první snímek v prezentaci
auto slide = presentation->get_Slides()->idx_get(0);

// Přidá AutoShape s typem nastaveným na Obdélník
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Přidá TextFrame do obdélníku
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Získá formát textu TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Určí počet sloupců v TextFrame
format->set_ColumnCount(3);

// Určí mezery mezi sloupci
format->set_ColumnSpacing(10);

// Uloží prezentaci
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Přidání sloupců do Text Frame**

Aspose.Slides pro C++ poskytuje metodu [set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format)), která umožňuje přidávat sloupce do textových rámců. Pomocí této metody můžete zadat požadovaný počet sloupců v textovém rámci.

Tento C++ kód ukazuje, jak přidat sloupec uvnitř textového rámce:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Aktualizace textu**

Aspose.Slides vám umožňuje změnit nebo aktualizovat text obsažený v textovém poli nebo veškerý text v prezentaci. 

Tento C++ kód demonstruje operaci, při které je aktualizován nebo změněn veškerý text v prezentaci:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Změní text
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Změní formátování
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Uloží upravenou prezentaci
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Přidání textového pole s hypertextovým odkazem** 

Můžete vložit odkaz do textového pole. Když je textové pole kliknuto, uživatelé jsou přesměrováni na otevření odkazu. 

1. Vytvořte instanci třídy `Presentation`.  
2. Získejte odkaz na první snímek nově vytvořené prezentace.  
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na určené pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape.  
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text.  
5. Vytvořte instanci třídy `IHyperlinkManager`.  
6. Přiřaďte objekt `IHyperlinkManager` k metodě [set_HyperlinkClick](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) spojené s požadovanou částí `TextFrame`.  
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento C++ kód—implementace výše uvedených kroků—ukazuje, jak přidat textové pole s hypertextovým odkazem na snímek:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Vytvoří instanci třídy Presentation, která představuje PPTX
auto presentation = System::MakeObject<Presentation>();

// Získá první snímek v prezentaci
auto slide = presentation->get_Slides()->idx_get(0);

// Přidá objekt AutoShape s typem nastaveným na Obdélník
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Přetypuje tvar na AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Přistoupí k vlastnosti ITextFrame přidružené k AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Přidá text do rámce
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Nastaví hyperodkaz pro text částí
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Uloží PPTX prezentaci
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **Často kladené dotazy**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s hlavními snímky?**

[Placeholder](/slides/cs/cpp/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslide/) a může být přepsán v [rozvrzích](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a během změny rozvržení se nemění.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasáhl do textu v grafech, tabulkách a SmartArt?**

Omezte iteraci na automatické tvary, které mají textové rámy, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/), [tabulky](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/)) tím, že projdete jejich kolekce samostatně nebo přeskočíte tyto typy objektů.