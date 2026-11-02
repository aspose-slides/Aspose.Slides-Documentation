---
title: Управление маркированными и нумерованными списками в презентациях на C++
linktitle: Управление списками
type: docs
weight: 70
url: /ru/cpp/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- маркер‑изображение
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и форматировать маркированные, маркер‑изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого контролируются через его формат абзаца.

Use the [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) method to access paragraph-level list settings. The main entry point is [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), which returns an [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации
- прочитать фактические маркеры списка и номера рядом с текстом абзаца

## **Создание маркированного списка**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) в [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) и задайте [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) значение [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Затем можно установить [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/), и [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) для контроля внешнего вида маркера.

Следующий код C++ демонстрирует, как создать маркированный список на слайде:

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

Результат:

![Символьные маркеры](symbol_bullets.png)

## **Создание нумерованного списка**

Используйте нумерованные списки, когда порядок элементов имеет значение. Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Также можно выбрать формат нумерации с помощью [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) или задать [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), если список должен начинаться со значения, отличного от 1.

Следующий код C++ показывает, как создать нумерованный список на слайде:

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

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создание маркера‑изображения**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми изображениями, которые остаются разборчивыми при небольшом размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" title="Note" %}}
Оптимально, если вы планируете заменить обычный символ маркера изображением, лучше выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркера.

Имейте в виду, что изображение будет масштабировано до очень небольшого размера. По этой причине мы настоятельно рекомендуем выбрать изображение, которое остаётся чётким и визуально эффективным при использовании в качестве маркера в списке.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) и присвойте полученный объект [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) свойству [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) перед присвоением изображения.

Предположим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

Следующий код C++ показывает, как создать маркеры‑изображения на слайде:

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

Результат:

![Маркеры‑изображения](picture_bullets.png)

## **Создание многоуровневого списка**

Используйте [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/)เพื่อ разместить элементы списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним, и так далее.

Следующий код C++ показывает, как создать многоуровневый маркированный список:

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

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменение существующего списка**

Чтобы изменить форматирование списка в существующей презентации, получите целевой абзац и обновите его настройки [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/). Те же свойства, которые используются для создания списков, могут быть использованы для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

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

## **Чтение фактических значений маркеров**

При извлечении содержимого презентации сохраняйте маркеры списка рядом с текстом абзаца. Вызовите [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) и обратитесь к [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/), чтобы получить эффективный формат маркера. Проверьте его [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) перед чтением [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/).

Для нумерованных списков различайте следующие три значения:

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) определяет формат, например, арабские цифры с точкой или строчные буквы с точкой.
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) задаёт начальное число для группы нумерованных абзацев.
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) возвращает отформатированный маркер для конкретного абзаца. Например, второй пункт в списке, начинающемся с 5, возвращает `6.`.

Сохраняйте [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) для каждого абзаца, чтобы сохранить уровень вложенности. Фактический маркер не кодирует полную иерархию: вложенный элемент может вернуть `c.`, а не комбинированный ярлык вроде `6.c.`.

Следующий автономный пример создаёт списки, сохраняет их в презентацию и загружает презентацию заново, чтобы вывести текст каждого абзаца, глубину, тип маркера и фактическое значение. Маленький синий маркер‑изображение создаётся из встроенного SVG.

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

    // Создайте маркер‑изображение без внешнего файла изображения.
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

Исходные списки показаны ниже.

![Списки, начинающиеся с 5, вложенные элементы с буквами и римскими цифрами, символьный маркер, абзац без маркера и синий маркер‑изображение](actual_bullet_values.png)

Отчёт соответствует маркерам, отображаемым в PowerPoint:

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

Для [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/), [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) возвращает null `System::String`, а не пустую строку. Используйте `IsNull` для проверки этого значения. Обрабатывайте эти типы отдельно: у первого нет маркера, у второго требуется отдельное извлечение изображения маркера. Маркер‑изображение нельзя воспроизвести только путем извлечения текстового маркера.

## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**  
Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующее расположение текста и функции маркеров.

**Могу ли я редактировать списки в существующих презентациях?**  
Да. Загрузите презентацию, получите целевой абзац, просмотрите или обновите его настройки [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**  
Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые вам символы.