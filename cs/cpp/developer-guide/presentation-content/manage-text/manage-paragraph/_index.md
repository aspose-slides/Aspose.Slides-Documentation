---
title: Správa textových odstavců PowerPoint v C++
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- import HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak vytvářet a formátovat odstavce, úseky, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ představuje text jako hierarchii textových rámečků, odstavců a úseků:

* [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) představuje kontejner pro text ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámečku a poskytuje přístup k jeho úsekům a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) představuje úsek textu v rámci odstavce. Každý úsek může mít vlastní text a formátování na úrovni znaků.

Odstavec může tedy obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více úseků.

## **Vytváření a formátování odstavců**

### **Vytvořit odstavce s více úseky**

Cílem následujících kroků je vytvořit textový rámeček se třemi odstavci, z nichž každý obsahuje tři úseky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek podle jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) do textového rámečku.
6. Přidejte dostatečné množství objektů [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) tak, aby každý odstavec obsahoval tři úseky. Výchozí odstavec již obsahuje jeden prázdný úsek.
7. Nastavte text každého úseku.
8. Použijte formátování na úrovni znaků pomocí [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_portionformat/).
9. Uložte upravenou prezentaci.

Tento příklad v C++ implementuje kroky:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vytváření odrážkových a číslovaných seznamů**

### **Vytvořit odrážkový nebo číslovaný seznam**

Odrážky a číslování usnadňují prohlížení souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [IBulletFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek podle jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámečku.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) pro symbol odrážky.
7. Nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Symbol](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámečku.
10. Vytvořte druhý odstavec a nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Numbered](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámečku.
12. Uložte prezentaci.

Tento příklad v C++ vytváří symbol odrážky a číslovanou odrážku:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Použití obrázkových odrážek**

Obrázkové odrážky vám umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek podle jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) a získejte jeho [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).
4. Odstraňte výchozí odstavec z textového rámečku.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/set_image/) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámečku.
10. Uložte upravenou prezentaci.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Vytvořit víceúrovňový seznam**

Nastavením [IParagraphFormat::set_Depth] umístíte odstavce na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation] a získejte snímek.
2. Přidejte obdélníkový [IAutoShape] a vymažte výchozí odstavec z jeho textového rámečku.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich [IParagraphFormat::set_Depth] hodnoty na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámečku a uložte prezentaci.

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Zahájit číslované položky seznamu vlastním číslem**

Použijte [IBulletFormat::set_NumberedBulletStartWith] k nastavení počátečního čísla zobrazeného u číslovaného odstavce.

1. Vytvořte [Presentation] a přidejte [IAutoShape] na snímek.
2. Odstraňte výchozí odstavec z textového rámečku tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [IBulletFormat::set_NumberedBulletStartWith] na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámečku a uložte prezentaci.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Řízení rozložení odstavců a koncových vlastností**

### **Nastavit odsazení první řádky**

Použijte [IParagraphFormat::set_Indent] ke kontrole odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat::set_MarginLeft], pokud potřebujete posunout celý odstavec. Použijte [IParagraphFormat::set_Indent], pokud potřebujete posunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty [IParagraphFormat::set_Indent] k demonstraci, jak odsazení první řádky ovlivňuje rozložení odstavce.

1. Vytvořte instanci třídy [Presentation].
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape] na snímek.
4. Získejte [ITextFrame] tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [IParagraphFormat::set_Indent].
6. Přidejte odstavce do textového rámečku.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavit odsazení závěsné (hanging indent)**

Závěsné odsazení je rozložení odstavce, ve kterém první řádek začíná vlevo od zbytku řádků. V Aspose.Slides tento efekt vytvoříte pomocí [IParagraphFormat::set_Indent]. Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [IParagraphFormat::set_MarginLeft] určuje levý polohu těla odstavce a [IParagraphFormat::set_Indent] určuje polohu první řádky vzhledem k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu margin-left a zápornou hodnotu odsazení.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde zalomené řádky musí být zarovnány pod tělo odstavce namísto pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation].
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape] na snímek.
4. Získejte [ITextFrame] tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [IParagraphFormat::set_MarginLeft].
6. Nastavte zápornou hodnotu [IParagraphFormat::set_Indent] k vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámečku.
8. Uložte upravenou prezentaci.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Závěsné odsazení odstavců](hanging_indent.png)

### **Nastavit koncové vlastnosti úseku odstavce**

[IParagraph::set_EndParagraphPortionFormat] řídí formátování koncového značky odstavce. Následující příklad přiřadí velikost písma a latinský font k koncové značce druhého odstavce:

1. Načtěte [Presentation] a získejte snímek.
2. Přidejte [IAutoShape] a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové úseky.
4. Vytvořte [PortionFormat] pro koncovou značku druhého odstavce.
5. Nastavte [IBasePortionFormat::set_FontHeight] a [IBasePortionFormat::set_LatinFont].
6. Přiřaďte formát pomocí [IParagraph::set_EndParagraphPortionFormat] a uložte prezentaci.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Import a export obsahu odstavců**

### **Importovat HTML text do odstavců**

Použijte [IParagraphCollection::AddFromHtml] k převodu HTML značek na odstavce a úseky v textovém rámečku.

1. Vytvořte instanci třídy [Presentation].
2. Získejte snímek a přidejte [IAutoShape].
3. Získejte [ITextFrame] tvaru a odstraňte výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předložte řetězec HTML metodě [IParagraphCollection::AddFromHtml].
6. Uložte upravenou prezentaci.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Exportovat text odstavce do HTML**

Použijte [IParagraphCollection::ExportToHtml] k exportu vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation] a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [IAutoShape], který obsahuje text.
3. Získejte [ITextFrame] tvaru.
4. Zavolejte [IParagraphCollection::ExportToHtml] s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Vykreslit odstavec jako obrázek**

[IParagraph::GetImage] vykreslí jednotlivý odstavec přímo a vrátí [IImage]. Výsledek uložte do souboru nebo proudu pomocí [IImage::Save]. Není nutné vykreslovat obsahující tvar nebo ručně ořezávat bitmapu.

[IParagraph::GetImage] může vrátit `nullptr`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací rozměry nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslit odstavec ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslit odstavec v buňce tabulky se škálováním**

Použijte přetížení [IParagraph::GetImage], které přijímá parametry `float scaleX` a `float scaleY` pro nastavení vodorovných a svislých měřítkových koeficientů. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát širší a vyšší než výchozí rozměry a výsledek uloží jako PNG obrázek.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Měřítkový koeficient `1` zachová tuto osu v její výchozí pixlové velikosti. Například `2` pro oba koeficienty vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobkem výchozích rozměrů, což vede ke čtyřnásobnému počtu pixelů. Větší koeficienty obecně produkují ostřejší text pro zvětšování nebo výstup ve vysokém rozlišení, ale zároveň zvyšují paměťovou náročnost a velikost souboru. Koeficienty pod `1` vytvářejí menší obrázky s menšími detaily. Použijte stejné koeficienty pro zachování poměru stran odstavce; odlišné vodorovné a svislé koeficienty roztáhnou výstup nezávisle.

Vykreslení celého tvaru pomocí [IShape::GetImage] je užitečné, když výstup musí zahrnovat výplň, okraj nebo další vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [IParagraph::GetImage].

## **FAQ**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámečku?**

Ano. Použijte [ITextFrameFormat::set_WrapText] k zakázání zalamování, takže řádky nebudou přerušeny na okrajích textového rámečku.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Použijte [IParagraph::GetRect] k získání ohraničujícího obdélníku odstavce. [IPortion::GetRect] poskytuje ohraničení jednotlivého úseku.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[IParagraphFormat::set_Alignment] je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých úseků.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Použijte [IBasePortionFormat::set_LanguageId] pro jednotlivé úseky, takže jeden odstavec může obsahovat text v několika jazycích.