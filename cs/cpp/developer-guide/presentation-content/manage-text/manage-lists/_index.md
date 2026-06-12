---
title: Spravovat odrážkové a číslované seznamy v prezentacích v C++
linktitle: Spravovat seznamy
type: docs
weight: 70
url: /cs/cpp/manage-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolická odrážka
- obrázková odrážka
- vlastní odrážka
- víceúrovňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro C++ vytvářet a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides for C++ vám umožňuje vytvářet a formátovat odrážkové a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno prostřednictvím formátu odstavce.

Použijte metodu [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/get_paragraphformat/) pro přístup k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_bullet/), který vrací objekt [IBulletFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci

## **Vytvořit odrážkový seznam**

Chcete‑li vytvořit odrážkový seznam, přidejte objekty [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) do [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) a nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Symbol](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/). Poté můžete nastavit [IBulletFormat::set_Char](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/get_color/) a [IBulletFormat::set_Height](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_height/) pro ovládání vzhledu odrážky.

Následující C++ kód ukazuje, jak vytvořit odrážkový seznam na snímku:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvořit číslovaný seznam**

Používejte číslované seznamy, když je na pořadí položek záležet. Nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Numbered](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) nebo nastavit [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), pokud má seznam začínat hodnotou jinou než 1.

Následující C++ kód ukazuje, jak vytvořit číslovaný seznam na snímku:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvořit obrázkovou odrážku**

Aspose.Slides umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné při malé velikosti, například ikony nebo malé transparentní PNG soubory.

{{% alert color="primary" %}}
Ideální je, pokud plánujete nahradit běžný symbol odrážky obrázkem, zvolit jednoduchou grafiku s transparentním pozadím. Takové obrázky se dobře hodí jako vlastní symboly odrážek.

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme vybrat obrázek, který zůstane čistý a vizuálně účinný, když bude použit jako odrážka v seznamu.
{{% /alert %}}

Chcete‑li vytvořit obrázkovou odrážku, přidejte obrázek do [IPresentation::get_Images](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_images/) a přiřaďte vrácený objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) k [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/get_picture/). Před přiřazením obrázku nastavte [IBulletFormat::set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/bullettype/).

Řekněme, že máme soubor „image.png“:

![Obrázek pro odrážky](picture_for_bullets.png)

Následující C++ kód ukazuje, jak vytvořit obrázkové odrážky na snímku:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvořit víceúrovňový seznam**

Použijte [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_depth/) pro umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní a tak dále.

Následující C++ kód ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Víceúrovňový seznam](multilevel_list.png)

## **Změnit existující seznam**

Pro změnu formátování seznamu v existující prezentaci přistupte k cílovému odstavci a aktualizujte jeho nastavení [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_bullet/). Stejné vlastnosti, které se používají při vytváření seznamů, lze použít k prozkoumání nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující C++ kód mění první odstavec v textovém rámečku tak, aby používal styl číslovaného seznamu:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prozkoumejte nebo aktualizujte jeho nastavení [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/get_bullet/) a prezentaci uložte.

**Mohou seznamy obsahovat ne‑latinský text?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy v vícejazykových prezentacích. Ujistěte se, že použité fonty v prezentaci podporují požadované znaky.