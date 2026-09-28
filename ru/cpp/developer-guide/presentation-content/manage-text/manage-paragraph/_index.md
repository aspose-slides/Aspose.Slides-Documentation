---
title: Управление абзацами PowerPoint в C++
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспорт абзаца
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) представляет пробег текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить ссылку на нужный слайд по его индексу.
3. Добавить прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры.
5. Использовать абзац по умолчанию и добавить два дополнительных объекта [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) в текстовую рамку.
6. Добавить достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) для каждого абзаца, чтобы получить по три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установить текст для каждого фрагмента.
8. Применить форматирование уровня символов через [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_portionformat/).
9. Сохранить изменённую презентацию.

Ниже пример на C++ реализации этих шагов:

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

## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Маркировка и нумерация упрощают восприятие связанных элементов. В Aspose.Slides настройки списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/).

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить ссылку на нужный слайд по его индексу.
3. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на выбранный слайд.
4. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры.
5. Удалить абзац по умолчанию из текстовой рамки.
6. Создать объект [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/) для символической марки.
7. Установить [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Symbol](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/) и задать символ маркера.
8. Задать текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавить абзац в текстовую рамку.
10. Создать второй абзац и установить [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Numbered](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/).
11. Настроить стиль нумерованного маркера и добавить абзац в текстовую рамку.
12. Сохранить презентацию.

Пример на C++ создает символический маркер и нумерованный маркер:

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

### **Использование изображений в качестве маркеров**

Изображения‑маркеры позволяют использовать собственную картинку вместо символа или числа.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить ссылку на нужный слайд по его индексу.
3. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) и получить его [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).
4. Удалить абзац по умолчанию из текстовой рамки.
5. Загрузить изображение маркера и добавить его в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).
6. Создать объект [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/) и задать его текст.
7. Установить [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/).
8. Назначить изображение через [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/set_image/) и задать высоту маркера.
9. Добавить абзац в текстовую рамку.
10. Сохранить изменённую презентацию.

Пример на C++ создаёт изображение‑маркер:

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

### **Создание многуровневого списка**

Установите [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_depth/) чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создать объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и получить слайд.
2. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) и очистить абзац по умолчанию из его текстовой рамки.
3. Создать четыре абзаца и настроить их символы маркеров.
4. Установить их значения [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_depth/) в `0`, `1`, `2` и `3`.
5. Добавить абзацы в текстовую рамку и сохранить презентацию.

Пример на C++ создаёт четырехуровневый маркированный список:

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

### **Задание пользовательских начальных номеров нумерованных пунктов**

Используйте [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создать объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
2. Очистить абзац по умолчанию из текстовой рамки фигуры.
3. Создать три нумерованных абзаца.
4. Установить [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавить абзацы в текстовую рамку и сохранить презентацию.

Пример на C++ задаёт пользовательский начальный номер для каждого абзаца:

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

## **Управление расположением абзаца и свойствами конца**

### **Установка отступа первой строки**

Используйте [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) чтобы управлять отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение перемещает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/) когда необходимо переместить весь абзац. Используйте [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) когда нужно сдвинуть только первую строку.

Ниже пример, который создаёт несколько абзацев и применяет разные значения [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) для демонстрации влияния отступа первой строки на расположение абзаца.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить целевой слайд.
3. Добавить прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры и удалить абзац по умолчанию.
5. Создать несколько абзацев и задать им разные значения [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/).
6. Добавить абзацы в текстовую рамку.
7. Сохранить изменённую презентацию.

Пример кода, показывающий, как установить отступ абзаца:

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

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/). Установите отрицательное значение отступа, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/) определяет левую позицию тела абзаца, а [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение margin‑left и отрицательное значение indent.

Такое форматирование полезно для библиографий, ссылок, словарных статей и других абзацев, где переносимые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить целевой слайд.
3. Добавить прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры и удалить абзац по умолчанию.
5. Создать абзацы и задать каждому положительное значение [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/).
6. Задать отрицательное значение [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) для создания эффекта висячего отступа.
7. Добавить абзацы в текстовую рамку.
8. Сохранить изменённую презентацию.

Пример кода, показывающий, как задать висячий отступ абзаца:

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

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств конечного знака абзаца**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) управляет форматированием конечного знака абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Загрузить объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и получить слайд.
2. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) и очистить его абзац по умолчанию.
3. Создать два абзаца и добавить к ним текстовые фрагменты.
4. Создать объект [PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/portionformat/) для конечного знака второго абзаца.
5. Установить [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_fontheight/) и [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Применить формат с помощью [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) и сохранить презентацию.

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

## **Подсчёт отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. разделы [Control Line Breaking](/slides/ru/cpp/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/cpp/text-formatting/#control-hanging-punctuation).

Используйте [IParagraph::GetLinesCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getlinescount/) чтобы подсчитать количество строк, занимаемых абзацем после раскладки текста, включая автоматический перенос. Это полезно при проверке длины текста и раскладки в шаблонах презентаций.

Абзац — один элемент в [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_paragraphs/), и он может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца принудительно создаёт новую строку без создания отдельного абзаца. Автоматический перенос создаёт строки на основе доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строки не дает количества отрисованных строк.

В следующем примере создаётся текстовая фигура, считается её количество строк, затем форма сужается, после чего текст заменяется более короткой строкой. Перенос включён, а автоподгонка отключена, чтобы ширина фигуры управляла переносом без автоматического сжатия текста или изменения размеров фигуры. Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

С указанным текстом и размерами сужение фигуры увеличивает количество строк, а замена текста на короткую строку уменьшает его. Точные подсчёты могут различаться в зависимости от доступных шрифтов и их замен, размера шрифта, полей, отступов, переноса и настроек автоподгонки. Используйте шрифты и параметры раскладки, предназначенные для целевого окружения, при проверке шаблона.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Также важны доступная высота, высота строк, интервалы между абзацами и строками, а также поведение автоподгонки; даже одна строка может превышать доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphcollection/addfromhtml/) для преобразования HTML‑разметки в абзацы и фрагменты внутри текстовой рамки.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получить слайд и добавить [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).
3. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры и очистить её абзац по умолчанию.
4. Прочитать исходный HTML‑файл.
5. Передать строку HTML в [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Сохранить изменённую презентацию.

Пример на C++ импортирует HTML в текстовую рамку:

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

### **Экспорт текста абзаца в HTML**

Используйте [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphcollection/exporttohtml/) для экспорта выбранного диапазона абзацев в HTML.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и загрузить нужную презентацию.
2. Получить слайд и найти [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) с текстом.
3. Получить [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры.
4. Вызвать [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphcollection/exporttohtml/) с индексом начального абзаца и количеством абзацев для экспорта.
5. Записать возвращённую строку HTML в файл.

Пример на C++ экспортирует все абзацы из первой текстовой фигуры:

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

### **Отрисовка абзаца в виде изображения**

[IParagraph::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getimage/) отрисовывает отдельный абзац напрямую и возвращает объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/save/). Нет необходимости отрисовывать содержащую фигуру или вручную обрезать bitmap.

[IParagraph::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getimage/) может вернуть `nullptr`, если абзац не найден в родительской коллекции, не имеет допустимых границ отрисовки или не поддаётся отрисовке. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации `sample.pptx` с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример отрисовывает второй абзац обычной текстовой фигуры в масштабе по умолчанию и сохраняет полученное изображение в формате PNG.

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

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Отрисовка абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [IParagraph::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getimage/), которая принимает параметры `float scaleX` и `float scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. В следующем примере создаётся таблица, абзац в её первой ячейке отрисовывается в два раза шире и выше, чем по умолчанию, и результат сохраняется как PNG‑изображение.

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

Коэффициент масштаба `1` оставляет ось в её обычном пиксельном размере. Например, `2` для обеих осей создаёт изображение, ширина и высота которого примерно в два раза больше стандартных размеров, что даёт в четыре раза больше пикселей. Более крупные множители обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают расход памяти и размер файла. Множители ниже `1` создают более маленькие изображения с меньшей детализацией. Используйте одинаковые множители, чтобы сохранить соотношение сторон абзаца; разные горизонтальный и вертикальный множители растягивают вывод независимо.

Отрисовка полной фигуры с помощью [IShape::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getimage/) остаётся полезной, когда в выводе необходимо включить заливку, контур или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Используйте [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_wraptext/) чтобы отключить перенос, так что строки не будут разбиваться по краям рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Вызовите [IParagraph::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getrect/) для получения ограничивающего прямоугольника абзаца. [IPortion::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/getrect/) возвращает границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_alignment/) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки правописания только для части абзаца?**

Да. Используйте [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/) для отдельных фрагментов, так что один абзац может содержать текст на нескольких языках.