---
title: Управление параграфами текста PowerPoint в C++
linktitle: Управление параграфом
type: docs
weight: 40
url: /ru/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- добавить текст
- добавить параграф
- управлять текстом
- управлять параграфом
- управлять маркером
- отступ параграфа
- висячий отступ
- маркер параграфа
- нумерованный список
- маркированный список
- свойства параграфа
- импорт HTML
- текст в HTML
- параграф в HTML
- параграф в изображение
- текст в изображение
- экспортировать параграф
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ представляет текст как иерархию текстовых рамок, абзацев и частей:

* [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к его коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его частям и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) представляет фрагмент текста внутри абзаца. Каждая часть может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько частей.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими частями**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) для каждого абзаца, чтобы они содержали три части. Абзац по умолчанию уже содержит одну пустую часть.
7. Установите текст каждой части.
8. Примените форматирование уровня символов через [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_portionformat/).
9. Сохраните изменённую презентацию.

Этот пример на C++ реализует эти шаги:

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

Маркировка и нумерация упрощают просмотр связанных элементов. В Aspose.Slides параметры списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/) для символической марки.
7. Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Symbol](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/) и укажите символ маркера.
8. Установите текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Numbered](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на C++ создаёт символический маркер и нумерованный маркер:

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

### **Использование картинок в качестве маркеров**

Картинки‑маркеры позволяют использовать собственное изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) и получите доступ к его [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/) и установите его текст.
7. Установите [IBulletFormat::set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_type/) в значение [BulletType::Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/bullettype/).
8. Назначьте изображение через [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/set_image/) и установите высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на C++ создаёт картинку‑маркер:

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

### **Создание многоуровневого списка**

Установите [IParagraphFormat::set_Depth] для размещения абзацев на разных уровнях списка. У верхнего уровня глубина `0`.

1. Создайте объект [Presentation] и получите доступ к слайду.
2. Добавьте [IAutoShape] и очистите абзац по умолчанию из его текстовой рамки.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [IParagraphFormat::set_Depth] в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на C++ создаёт четырёхуровневый маркированный список:

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

### **Начало нумерации списка с пользовательских значений**

Используйте [IBulletFormat::set_NumberedBulletStartWith] для установки начального номера, отображаемого в нумерованном абзаце.

1. Создайте объект [Presentation] и добавьте [IAutoShape] на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat::set_NumberedBulletStartWith] в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на C++ назначает пользовательский начальный номер каждому абзацу:

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

## **Управление расположением абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте [IParagraphFormat::set_Indent] для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, в то время как остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat::set_MarginLeft], когда необходимо переместить весь абзац. Используйте [IParagraphFormat::set_Indent], когда нужно переместить только первую строку.

Ниже приведён пример, создающий несколько абзацев и применяющий различные значения [IParagraphFormat::set_Indent] для демонстрации влияния отступа первой строки на расположение абзаца.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольный [IAutoShape] на слайд.
4. Получите доступ к [ITextFrame] фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и установите для них разные значения [IParagraphFormat::set_Indent].
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код показывает, как задать отступ абзаца:

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

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью [IParagraphFormat::set_Indent]. Установите отступ в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat::set_MarginLeft] задаёт левую позицию тела абзаца, а [IParagraphFormat::set_Indent] определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение margin-left и отрицательное значение отступа.

Такое форматирование полезно для библиографий, ссылок, глоссарных записей и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольный [IAutoShape] на слайд.
4. Получите доступ к [ITextFrame] фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте для каждого положительное значение [IParagraphFormat::set_MarginLeft].
6. Установите отрицательное значение [IParagraphFormat::set_Indent] для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как задать висячий отступ для абзаца:

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

### **Установка свойств конечного абзаца**

[IParagraph::set_EndParagraphPortionFormat] управляет форматированием знака конца абзаца. В следующем примере назначается размер шрифта и латинский шрифт для знака конца второго абзаца:

1. Загрузите объект [Presentation] и получите доступ к слайду.
2. Добавьте [IAutoShape] и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые части.
4. Создайте объект [PortionFormat] для знака конца второго абзаца.
5. Установите [IBasePortionFormat::set_FontHeight] и [IBasePortionFormat::set_LatinFont].
6. Примените формат с помощью [IParagraph::set_EndParagraphPortionFormat] и сохраните презентацию.

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

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [IParagraphCollection::AddFromHtml] для преобразования разметки HTML в абзацы и части внутри текстовой рамки.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к слайду и добавьте [IAutoShape].
3. Получите доступ к [ITextFrame] фигуры и очистите абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
5. Передайте строку HTML в [IParagraphCollection::AddFromHtml].
6. Сохраните изменённую презентацию.

Этот пример на C++ импортирует HTML в текстовую рамку:

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

Используйте [IParagraphCollection::ExportToHtml] для экспорта выбранного диапазона абзацев в виде HTML.

1. Создайте экземпляр класса [Presentation] и загрузите нужную презентацию.
2. Получите доступ к слайду и найдите [IAutoShape], содержащий текст.
3. Получите доступ к [ITextFrame] фигуры.
4. Вызовите [IParagraphCollection::ExportToHtml] с указанием индекса начального абзаца и количества экспортируемых абзацев.
5. Запишите возвращённую HTML‑строку в файл.

Этот пример на C++ экспортирует все абзацы из первой текстовой фигуры:

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

### **Отрисовка абзаца как изображения**

[IParagraph::GetImage] напрямую отрисовывает отдельный абзац и возвращает объект [IImage]. Сохраните результат в файл или поток с помощью [IImage::Save]. Нет необходимости отрисовывать содержащую фигуру или вручную обрезать растровое изображение.

[IParagraph::GetImage] может вернуть `nullptr`, если абзац не найден в родительской коллекции, не имеет валидных границ отрисовки или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример отрисовывает второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG.

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

Используйте перегрузку [IParagraph::GetImage], принимающую параметры `float scaleX` и `float scaleY` для установки горизонтального и вертикального коэффициентов масштабирования. В следующем примере создаётся таблица, абзац в её первой ячейке отрисовывается в два раза шире и выше стандартных размеров, и результат сохраняется как PNG‑изображение.

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

Коэффициент масштабирования `1` сохраняет ось в её стандартном пиксельном размере. Например, `2` для обеих осей создаёт изображение, ширина и высота которого примерно вдвое больше стандартных, что приводит к четырём раз большему количеству пикселей. Большие коэффициенты обычно дают более чёткий текст при масштабировании или выводе в высоком разрешении, но также увеличивают использование памяти и размер файла. Коэффициенты ниже `1` создают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [IShape::GetImage] остаётся полезной, когда вывод должен включать заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph::GetImage].

## **Часто задаваемые вопросы**

**Могу ли я полностью отключить перенос строк внутри текстовой рамки?**

Да. Используйте [ITextFrameFormat::set_WrapText], чтобы отключить перенос, чтобы строки не разрывались у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph::GetRect] для получения ограничивающего прямоугольника абзаца. [IPortion::GetRect] предоставляет границы отдельной части.

**Где управляется выравнивание абзаца (по левому, правому, по центру или по ширине)?**

[IParagraphFormat::set_Alignment] — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных частей.

**Могу ли я задать язык проверки орфографии для части абзаца?**

Да. Используйте [IBasePortionFormat::set_LanguageId] для отдельных частей, так один абзац может содержать текст на нескольких языках.