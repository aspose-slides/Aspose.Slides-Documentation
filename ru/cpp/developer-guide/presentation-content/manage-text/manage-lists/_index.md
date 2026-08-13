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
- символический маркер
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

Aspose.Slides for C++ позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка представляет собой абзац, настройки маркера которого управляются через формат абзаца.

Используйте метод [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/get_paragraphformat/) для доступа к настройкам списка на уровне абзаца. Основная точка входа — [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_bullet/), который возвращает объект [IBulletFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/). С помощью этого объекта можно задать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальный номер.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/) в [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) и установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Symbol](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/). Затем можно задать [IBulletFormat::set_Char](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/get_color/) и [IBulletFormat::set_Height](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_height/) для управления внешним видом маркера.

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

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов имеет значение. Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Numbered](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/). Вы также можете выбрать формат нумерации с помощью [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) или задать [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), если список должен начинаться с значения, отличного от 1.

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

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми картинками, которые остаются разборчивыми при маленьком размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" %}}
Идеально, если вы планируете заменить обычный символ маркера изображением, выбирайте простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.

Имейте в виду, что изображение будет масштабировано до очень небольшого размера. По этой причине мы настоятельно рекомендуем выбирать изображение, которое остаётся чётким и визуально эффективным в роли маркера в списке.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [IPresentation::get_Images](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_images/) и присвойте полученный объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) свойству [IBulletFormat::get_Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/get_picture/). Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/) перед присвоением изображения.

Допустим, у нас есть файл "image.png":

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

![Маркер‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Используйте [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_depth/) для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и т.д.

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

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, обратитесь к целевому абзацу и обновите его настройки [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_bullet/). Те же свойства, которые использовались для создания списков, могут быть использованы для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

Следующий код C++ изменяет первый абзац в текстовом фрейме, чтобы использовать стиль нумерованного списка:

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

## **FAQ**

### Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?

Да. Aspose.Slides сохраняет форматирование списков, когда целевой формат поддерживает соответствующее размещение текста и функции маркеров.

### Можно ли редактировать списки в существующих презентациях?

Да. Загрузите презентацию, обратитесь к целевому абзацу, просмотрите или обновите его настройки [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_bullet/) и сохраните презентацию.

### Поддерживают ли списки нелатинский текст?

Да. Текст элементов списка может содержать Unicode‑символы, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что используемые в презентации шрифты поддерживают необходимые вам символы.