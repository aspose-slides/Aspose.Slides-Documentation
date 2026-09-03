---
title: Správa textových polí v prezentacích pomocí C++
linktitle: Spravovat textové pole
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
description: "Vytvářejte, identifikujte, formátujte a aktualizujte textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++."
---
## **Úvod**

V Aspose.Slides pro C++ je text snímku uložen v textových rámcích, které patří k tvarem. Rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) představuje nejběžnější tvar nesoucí text a zpřístupňuje jeho text prostřednictvím metody [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}
Každý automatický tvar implementuje [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracování existující prezentace zkontrolujte, že tvar implementuje [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/), než k jeho textu přistoupíte.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole přidejte automatický tvar na snímek, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytváří obdélníkové textové pole:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Souřadnice a rozměry předávané metodě [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addautoshape/) jsou měřeny v bodech. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/) inicializuje textový rámec s dodaným textem.

## **Kontrola, zda je tvar textovým polem**

Použijte metodu [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_istextbox/) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak tvary nesoucí text, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad prochází každý automatický tvar v prezentaci:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje neprázdný text. Tento text můžete poskytnout prostřednictvím [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/) nebo [ITextFrame::set_Text](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/set_text/). Přidání nebo přiřazení prázdného řetězce způsobí, že [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_istextbox/) vrátí `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

První dvě kontroly vrací `true`; poslední dvě vrací `false`.

## **Najít tvar, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) aniž by věděl, který objekt prezentace jej obsahuje. Použijte metodu [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentshape/) k návratu k jeho vlastníkovi [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/).

Pro textový rámec vlastněný automatickým tvarem nebo jiným tvarem nesoucím text metoda [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentshape/) vrací vlastníka a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_parentcell/) vrací `nullptr`. Obě metody poskytují pouze‑čtení navigaci. Před přístupem zkontrolujte vrácenou hodnotu na `nullptr`. Chcete-li identifikovat jak vlastníky tvarů, tak buněk tabulky, včetně tvarů spojených s uzly SmartArt, viz [Vyhledat a nahradit text](/slides/cs/cpp/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Metoda [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_columncount/) rozdělí textový rámec do sloupců, zatímco [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_columnspacing/) nastaví mezeru mezi sloupci v bodech. Obě metody patří do [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/) a lze je volat přes textový rámec existujícího textového pole. Text se v rámci stejného tvaru přetéká mezi sloupci; nepřechází do jiného tvaru.

Následující příklad vytvoří třísloupcové textové pole s 10 body mezi sloupci, uloží prezentaci a načte uložená nastavení zpět ze výstupního souboru:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extrahování textu z jednotlivých sloupců**

Použijte [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/splittextbycolumns/) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec ve sloupcovém pořadí čtení. Jednosloupcový textový rámec vytvoří pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni částí není zachováno.

To je užitečné, když potřebujete:
- Extrahovat text při zachování jeho sloupcového pořadí čtení.
- Indexovat nebo porovnat obsah vícesloupcových snímků.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Zkontrolovat, jak je text přerozdělen po nastavení počtu sloupců pomocí [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_columncount/) nebo mezery pomocí [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframeformat/set_columnspacing/), či po změně písma nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/); automaticky nepřetéká text mezi samostatnými tvary nebo textovými poli. Rozdělení sloupců může záviset na dostupných fontech a dalších nastaveních rozvržení textu, proto se ujistěte, že požadované fonty jsou k dispozici, když jsou důležité konzistentní výsledky.

Následující příklad načte prezentaci, najde první vícesloupcový automatický tvar s textovým rámcem na prvním snímku, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Aktualizace textu**

Pro aktualizaci textu v celé prezentaci projděte snímky a tvary, vyberte automatické tvary a poté upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každou výskyt `years` za `months` v jednotlivých textových částech automatického tvaru a učiní každou dotčenou část tučnou:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Toto procházení aktualizuje text pouze v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje procházení vlastních kolekcí těchto objektů.

## **Přidání textového pole s hyperodkazem**

Hyperodkaz může být přiřazen konkrétní textové části, takže pouze tento text funguje jako klikací odkaz. Použijte [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) k propojení této části s externí URL.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozložení snímku?**

Zástupce [placeholder](/slides/cs/cpp/manage-placeholder/) může zdědit svou pozici a formátování z [hlavního snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslide/) nebo [rozložení snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a nezíská chování zástupce, když se rozložení změní.

**Jak mohu nahradit text, aniž bych změnil text v grafech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které implementují [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/), jak je ukázáno v příkladu Aktualizace textu. Grafy, tabulky a SmartArt ukládají text ve svých vlastních modelových objektech, takže nejsou tímto cyklem upraveny.