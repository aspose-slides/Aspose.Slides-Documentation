---
title: Управление текстовыми полями в презентациях с помощью C++
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/cpp/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++."
---
## **Введение**

В Aspose.Slides для C++ текст слайдов хранится в текстовых кадрах, принадлежащих фигурам. Интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет доступ к её тексту через метод [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}

Каждая автофигура реализует [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации убедитесь, что фигура реализует [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) перед доступом к её тексту.

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. В следующем примере создаётся прямоугольное текстовое поле:

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

Координаты и размеры, передаваемые в [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addautoshape/), измеряются в пунктах. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/addtextframe/) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли фигура текстовым полем**

Используйте метод [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/get_istextbox/) для определения, рассматривается ли автофигура как текстовое поле. Это полезно, когда презентация содержит как фигуры с текстом, так и чисто графические автофигуры.

![Текстовое поле и фигура](istextbox.png)

В следующем примере проверяется каждая автофигура в презентации:

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

Новодобавленная автофигура не считается текстовым полем, пока в ней не будет непустого текста. Вы можете задать этот текст через [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/addtextframe/) или [ITextFrame::set_Text](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/set_text/). Добавление или присваивание пустой строки приводит к тому, что [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/get_istextbox/) возвращает `false`:

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

Первые два условия возвращают `true`; последние два — `false`.

## **Найти фигуру, владеющую текстовым кадром**

Общий код обработки текста может получать объект [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) без знания, какой объект презентации его содержит. Используйте метод [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentshape/) для перехода к его владелецу — [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре с текстом, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentshape/) возвращает владельца, а [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) — `nullptr`. Оба метода предоставляют только чтение. Проверьте возвращаемое значение на `nullptr` перед доступом. Чтобы определить как владельцев фигур, так и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/cpp/search-and-replace-text/).

## **Добавление колонок в текстовое поле**

Метод [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_columncount/) делит текстовый кадр на колонки, а [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_columnspacing/) задаёт промежуток между колонками в пунктах. Оба метода принадлежат [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/) и могут вызываться через текстовый кадр существующего текстового поля. Текст перераспределяется между колонками внутри одной фигуры; он не переходит в другую фигуру.

В следующем примере создаётся трёхколоночное текстовое поле с отступом 10 пунктов между колонками, сохраняется презентация и читаются сохранённые настройки из выходного файла:

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

## **Извлечение текста из отдельных колонок**

Используйте [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/splittextbycolumns/) для получения текста, присвоенного каждой визуальной колонке в существующем текстовом кадре. Метод возвращает одну строку для каждой колонки в порядке чтения по колонкам. Текстовый кадр с одной колонкой возвращает массив из одного элемента, а пустая колонка представлена пустой строкой. Строки содержат только простой текст; форматирование уровня частей не сохраняется.

Это полезно, когда необходимо:

- Извлечь текст, сохранив порядок чтения по колонкам.  
- Индексировать или сравнить содержимое слайдов с несколькими колонками.  
- Экспортировать каждую колонку в отдельный файл, поле базы данных или другое место назначения.  
- Проанализировать, как текст перераспределяется после установки числа колонок с помощью [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_columncount/) или отступа с помощью [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_columnspacing/), а также при изменении шрифта или размера текстового кадра.

Метод сообщает о тексте, распределённом внутри текущего [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/); он не перенаправляет текст автоматически между отдельными фигурами или текстовыми полями. Распределение по колонкам может зависеть от доступных шрифтов и других настроек макета текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

В следующем примере загружается презентация, находится первая автофигура с несколькими колонками и текстовым кадром на первом слайде, читается её заданное количество колонок и записывается текст каждой колонки в отдельный файл. Фигуры без текстового кадра пропускаются.

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

## **Обновление текста**

Для обновления текста во всей презентации пройдитесь по слайдам и фигурам, выберите автофигуры и затем отредактируйте их текстовые части. Работа на уровне частей позволяет менять как текст, так и форматирование символов.

В следующем примере каждое вхождение `years` заменяется на `months` внутри отдельных частей текста автофигур, а каждую затронутую часть делают полужирной:

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

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавить текстовое поле с гиперссылкой**

Гиперссылка может быть назначена конкретной части текста, поэтому только этот текст будет кликабельным. Используйте [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) для привязки части к внешнему URL.

В следующем примере создаётся связанный текст и сохраняется в презентацию:

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

## **FAQ**

**В чём разница между текстовым полем и заполнительным текстом на мастер‑слайде или слайде‑разметке?**

[Заполнитель](/slides/ru/cpp/manage-placeholder/) может наследовать свою позицию и форматирование от [мастер‑слайда](https://reference.aspose.com/slides/ru/cpp/aspose.slides/masterslide/) или [слайда‑разметки](https://reference.aspose.com/slides/ru/cpp/aspose.slides/layoutslide/). Обычное текстовое поле — это независимая фигура на слайде, где оно было создано, и оно не приобретает поведения заполнителя при изменении разметки.

**Как заменить текст, не изменяя его в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, реализующими [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/), как показано в примере «Обновление текста». Диаграммы, таблицы и SmartArt хранят текст в своих собственных объектных моделях, поэтому они не изменяются этим циклом.