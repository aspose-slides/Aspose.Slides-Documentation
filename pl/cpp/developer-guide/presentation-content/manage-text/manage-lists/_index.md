---
title: Zarządzanie listami punktowanymi i numerowanymi w prezentacjach w C++
linktitle: Zarządzanie listami
type: docs
weight: 70
url: /pl/cpp/manage-lists/
keywords:
- punktor
- lista punktowana
- lista numerowana
- punkt symboliczny
- punkt graficzny
- punkt niestandardowy
- lista wielopoziomowa
- tworzenie punktora
- dodawanie punktora
- dodawanie listy
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy punktowane, graficzne, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for C++."
---
## **Przegląd**

Aspose.Slides for C++ umożliwia tworzenie i formatowanie list punktowanych oraz numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy jest akapitem, którego ustawienia punktora są kontrolowane poprzez format akapitu.

Użyj metody [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), które zwraca obiekt [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/). Dzięki temu obiektowi możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę punktowaną z własnym symbolem
- utworzyć punktor graficzny
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie list w istniejącej prezentacji
- odczytać rzeczywiste znaczniki i liczby list obok tekstu akapitu

## **Utworzenie listy punktowanej**

Aby utworzyć listę punktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) do [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) i ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Następnie możesz ustawić [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/) oraz [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/), aby kontrolować wygląd punktora.

Poniższy kod C++ pokazuje, jak utworzyć listę punktowaną na slajdzie:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

Wynik:

![Punkty symboliczne](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Możesz także wybrać format numeracji za pomocą [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) lub ustawić [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod C++ pokazuje, jak utworzyć listę numerowaną na slajdzie:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Wynik:

![Punkty numerowane](numbered_bullets.png)

## **Utworzenie punktora graficznego**

Aspose.Slides umożliwia zastąpienie zwykłego symbolu punktora obrazem. Punktory graficzne działają najlepiej z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe pliki PNG z przezroczystością.

{{% alert color="info" title="Note" %}}
Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.

Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.
{{% /alert %}}

Aby utworzyć punktor graficzny, dodaj obraz do [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) i przypisz zwrócony obiekt [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) do [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). Ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) przed przypisaniem obrazu.

Załóżmy, że mamy plik „image.png”:

![Obraz dla punktorów](picture_for_bullets.png)

Poniższy kod C++ pokazuje, jak utworzyć punktory graficzne na slajdzie:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Wynik:

![Punktory graficzne](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/), aby umieścić elementy listy na różnych poziomach. Poziom 0 jest najwyższym poziomem, poziom 1 jest zagnieżdżony pod nim i tak dalej.

Poniższy kod C++ pokazuje, jak utworzyć wielopoziomową listę punktowaną:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/). Te same właściwości użyte do tworzenia list można wykorzystać do przeglądania lub modyfikacji list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod C++ zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **Odczyt rzeczywistych wartości punktora**

Podczas wyodrębniania zawartości prezentacji należy zachować znaczniki list obok tekstu akapitu. Wywołaj [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) i uzyskaj dostęp do [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/), aby otrzymać efektywny format punktora. Sprawdź jego [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) przed odczytaniem [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/).

Dla list numerowanych rozróżnij trzy wartości:

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) określa format, np. liczby arabskie z kropką lub małe litery z kropką.
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) wskazuje numer początkowy dla grupy numerowanych akapitów.
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) zwraca sformatowany znacznik dla konkretnego akapitu. Na przykład drugi element listy zaczynającej się od 5 zwróci `6.`.

Zachowaj [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) przy każdym akapicie, aby utrzymać jego poziom zagnieżdżenia. Rzeczywisty znacznik nie koduje pełnej hierarchii: element zagnieżdżony może zwrócić `c.` zamiast połączonej etykiety takiej jak `6.c.`.

Poniższy samodzielny przykład tworzy listy, zapisuje je do prezentacji i ponownie wczytuje prezentację, aby zgłosić tekst, głębokość, typ punktora i rzeczywistą wartość każdego akapitu. Mały niebieski znacznik graficzny jest tworzony z osadzonego SVG.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IBulletFormatEffectiveData.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

{
    auto presentation = System::MakeObject<Presentation>();
    presentation->get_SlideSize()->SetSize(720, 440, SlideSizeScaleType::DoNotScale);
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_Paragraphs()->Clear();

    // Utwórz znacznik graficzny bez zewnętrznego pliku obrazu.
    auto svg = System::MakeObject<SvgImage>(u"<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    auto bulletImage = presentation->get_Images()->AddImage(svg);

    auto addParagraph = [&](System::String text, int16_t depth, BulletType type, int16_t start = 1, NumberedBulletStyle style = NumberedBulletStyle::BulletArabicPeriod)
    {
        auto paragraph = System::MakeObject<Paragraph>();
        paragraph->set_Text(text);

        auto format = paragraph->get_ParagraphFormat();
        format->set_Depth(depth);
        format->set_MarginLeft(30 + depth * 40);
        format->set_Indent(-28);
        format->set_SpaceAfter(8);
        format->get_DefaultPortionFormat()->set_FontHeight(22);
        format->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
        auto bullet = format->get_Bullet();
        bullet->set_Type(type);
        bullet->set_IsBulletHardColor(NullableBool::True);
        bullet->get_Color()->set_Color(Color::get_Black());
        if (type == BulletType::Numbered)
        {
            bullet->set_NumberedBulletStyle(style);
            bullet->set_NumberedBulletStartWith(start);
        }
        else if (type == BulletType::Symbol)
        {
            bullet->set_Char(u'\u2022');
        }
        else if (type == BulletType::Picture)
        {
            bullet->get_Picture()->set_Image(bulletImage);
        }

        textFrame->get_Paragraphs()->Add(paragraph);
    };

    addParagraph(u"First item", 0, BulletType::Numbered, 5);
    addParagraph(u"Second item", 0, BulletType::Numbered, 5);
    addParagraph(u"Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    addParagraph(u"Back to top level", 0, BulletType::Numbered, 5);
    addParagraph(u"Symbol marker", 0, BulletType::Symbol);
    addParagraph(u"No bullet", 0, BulletType::None);
    addParagraph(u"Picture marker", 0, BulletType::Picture);
    presentation->Save(u"actual_bullet_values.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}

auto loadedPresentation = System::MakeObject<Presentation>(u"actual_bullet_values.pptx");
auto loadedShape = System::ExplicitCast<IAutoShape>(loadedPresentation->get_Slide(0)->get_Shape(0));
System::Console::WriteLine(u"Text | Depth | Type | Actual value");
for (auto paragraph : loadedShape->get_TextFrame()->get_Paragraphs())
{
    auto bullet = paragraph->get_ParagraphFormat()->GetEffective()->get_Bullet();
    auto actualValue = bullet->get_ActualBulletValue();
    System::String marker;
    switch (bullet->get_Type())
    {
        case BulletType::Numbered:
        case BulletType::Symbol:
            marker = actualValue;
            break;
        case BulletType::None:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (no bullet)";
            break;
        case BulletType::Picture:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (image required)";
            break;
        default:
            marker = u"unsupported bullet type";
            break;
    }
    System::Console::WriteLine(u"{0} | {1} | {2} | {3}", paragraph->get_Text(), paragraph->get_ParagraphFormat()->get_Depth(), bullet->get_Type(), marker);
}
loadedPresentation->Dispose();
```

Poniżej pokazano źródłowe listy.

![Listy rozpoczynające się od 5, zagnieżdżone elementy literowe i rzymskie, znacznik symboliczny, akapit bez punktora oraz niebieski znacznik graficzny](actual_bullet_values.png)

Raport odpowiada znacznikom wyświetlanym w programie PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Dla [BulletType::None i BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/), [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) zwraca null `System::String`, a nie pusty ciąg. Użyj `IsNull`, aby sprawdzić tę wartość. Obsłuż te typy osobno: pierwszy nie ma znacznika, drugi wymaga osobnego wyodrębnienia obrazu punktora. Punktor graficzny nie może być odtworzony wyłącznie przez wyodrębnienie znacznika tekstowego.

## **FAQ**

**Czy listy punktowane i numerowane można eksportować do formatu PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy docelowy format obsługuje odpowiednie układy tekstu i funkcje punktorów.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), a następnie zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w prezentacjach wielojęzycznych. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.