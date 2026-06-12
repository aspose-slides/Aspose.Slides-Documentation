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
description: "Aspose.Slides pro C++ usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zlepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle umístěny v textových polích nebo tvarech. Proto musíte pro přidání textu na snímek nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides for C++ poskytuje rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape), které umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}

Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape), které umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) však mohou text obsahovat. 

{{% /alert %}}

{{% alert title="Poznámka" color="warning" %}} 

Proto, když pracujete s tvarem, ke kterému chcete přidat text, je vhodné ověřit a potvrdit, že byl přetypován pomocí rozhraní `IAutoShape`. Pouze pak budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame), což je vlastnost pod `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/cpp/manage-textbox/#update-text) na této stránce. 

{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation). 
2. Získejte odkaz na první snímek nově vytvořené prezentace. 
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) s [ShapeType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) nastaveným na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt `IAutoShape`. 
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V ukázce níže jsme přidali tento text: *Aspose TextBox* 
5. Nakonec pomocí objektu `Presentation` zapište soubor PPTX. 

Tento C++ kód — implementace výše uvedených kroků — ukazuje, jak přidat text na snímek:

```cpp
// Vytvoří instanci Presentation
auto pres = System::MakeObject<Presentation>();

// Získá první snímek v prezentaci
auto sld = pres->get_Slides()->idx_get(0);

// Přidá AutoShape s typem nastaveným na Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Přidá TextFrame k obdélníku
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

## **Kontrola, zda se jedná o tvar textového pole**

Aspose.Slides poskytuje metodu [get_IsTextBox](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_istextbox/) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/), která vám umožní prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento C++ kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

Všimněte si, že pokud jen přidáte automatický tvar pomocí metody `AddAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/), metoda `get_IsTextBox` vrátí `false`. Po přidání textu do automatického tvaru metodou `AddTextFrame` nebo `set_Text` metoda `get_IsTextBox` vrátí `true`.

```cpp
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

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje metody [set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) a [set_ColumnSpacing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format)), které umožňují přidat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezeru mezi sloupci v bodech. 

Tento C++ kód demonstruje popsanou operaci: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Získá první snímek v prezentaci
auto slide = presentation->get_Slides()->idx_get(0);

// Přidá AutoShape s typem nastaveným na Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Přidá TextFrame k obdélníku
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Získá formát textu TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Určuje počet sloupců v TextFrame
format->set_ColumnCount(3);

// Určuje mezery mezi sloupci
format->set_ColumnSpacing(10);

// Uloží prezentaci
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Přidání sloupců do textového rámce**

Aspose.Slides for C++ poskytuje metodu [set_ColumnCount](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame_format)), která umožňuje přidávat sloupce v textových rámcích. Touto metodou můžete určit požadovaný počet sloupců v textovém rámci. 

Tento C++ kód ukazuje, jak přidat sloupec do textového rámce:

```cpp
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

Aspose.Slides vám umožňuje měnit nebo aktualizovat text obsažený v textovém poli nebo všechny texty v celé prezentaci. 

Tento C++ kód demonstruje operaci, při které jsou všechny texty v prezentaci aktualizovány nebo změněny:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
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

## **Přidání textového pole s hyperodkazem** 

Do textového pole můžete vložit odkaz. Po kliknutí na textové pole jsou uživatelé přesměrováni na otevření odkazu. 

Pro přidání textového pole obsahujícího odkaz postupujte takto:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek nově vytvořené prezentace. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape. 
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude mít *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `IHyperlinkManager`. 
6. Přiřaďte objekt `IHyperlinkManager` metodě [set_HyperlinkClick](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) spojené s požadovanou částí `TextFrame`. 
7. Nakonec pomocí objektu `Presentation` zapište soubor PPTX. 

Tento C++ kód — implementace výše uvedených kroků — ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```cpp
// Vytvoří instanci třídy Presentation, která představuje PPTX
auto presentation = System::MakeObject<Presentation>();

// Získá první snímek v prezentaci
auto slide = presentation->get_Slides()->idx_get(0);

// Přidá objekt AutoShape s typem nastaveným na Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Přetypuje tvar na AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Přistupuje k vlastnosti ITextFrame spojené s AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Přidá nějaký text do rámce
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Nastaví hyperodkaz pro text části
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Uloží PPTX prezentaci
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **Často kladené dotazy**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s hlavními snímky?**

[Placeholder](/slides/cs/cpp/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslide/) a může být přepsán na [layoutu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a nemění se při přepínání layoutů.

**Jak mohu provést hromadnou výměnu textu v celé prezentaci, aniž bych zasáhl do textu uvnitř grafů, tabulek a SmartArt?**

Omezte iteraci na automatické tvary, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/), [tabulky](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/)) tím, že jejich kolekce procházíte zvlášť nebo tyto typy objektů přeskočíte.