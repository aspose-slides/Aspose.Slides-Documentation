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
description: "Aspose.Slides for C++ упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, улучшая автоматизацию вашей презентации."
---

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, нужно добавить текстовое поле, а затем поместить в него некоторый текст. Aspose.Slides for C++ предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Info" color="info" %}}
Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape), могут содержать текст. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Поэтому, работая с фигурой, к которой вы хотите добавить текст, рекомендуется проверить и убедиться, что она приведена к интерфейсу `IAutoShape`. Только в этом случае вы сможете работать с [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), который является свойством `IAutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) на этой странице. 
{{% /alert %}}

## **Create a Text Box on a Slide**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) с параметром [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c), установленным в `Rectangle`, в указанной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`. 
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведённом ниже примере мы добавили такой текст: *Aspose TextBox* 
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код C++ — реализация указанных выше шагов — показывает, как добавить текст на слайд:
```cpp
// Создает экземпляр Presentation
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд в презентации
auto sld = pres->get_Slides()->idx_get(0);

// Добавляет AutoShape с типом Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Добавляет TextFrame к прямоугольнику
ashp->AddTextFrame(u" ");

// Получает доступ к TextFrame
auto txtFrame = ashp->get_TextFrame();

// Создает объект Paragraph для TextFrame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Создает объект Portion для параграфа
auto portion = para->get_Portions()->idx_get(0);

// Устанавливает текст
portion->set_Text(u"Aspose TextBox");

// Сохраняет презентацию на диск
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```


## **Check for a Text Box Shape**

Aspose.Slides предоставляет метод [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) из интерфейса [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), позволяющий проверять фигуры и определять текстовые поля.

![Text box and shape](istextbox.png)

Этот код C++ показывает, как проверить, была ли фигура создана как текстовое поле: 
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


Обратите внимание, что если вы просто добавите автофигуру, используя метод `AddAutoShape` из интерфейса [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/), метод `get_IsTextBox` этой автофигуры вернёт `false`. Однако после того, как вы добавите текст к автофигуре с помощью метода `AddTextFrame` или метода `set_Text`, метод `get_IsTextBox` вернёт `true`.
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() возвращает false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() возвращает true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() возвращает false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() возвращает true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() возвращает false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() возвращает false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() возвращает false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() возвращает false
```


## **Add Columns to a Text Box**

Aspose.Slides предоставляет методы [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) и [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) и класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)), которые позволяют добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и задать расстояние между столбцами в пунктах. 

Этот код на C++ демонстрирует описанную операцию: 
```cpp
auto presentation = System::MakeObject<Presentation>();
// Получает первый слайд в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет AutoShape с типом Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Добавляет TextFrame к прямоугольнику
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Получает формат текста TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Указывает количество столбцов в TextFrame
format->set_ColumnCount(3);

// Указывает интервал между столбцами
format->set_ColumnSpacing(10);

// Сохраняет презентацию
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Add Columns to a Text Frame**
Aspose.Slides for C++ предоставляет метод [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)), который позволяет добавлять столбцы в текстовые кадры. С помощью этого метода вы можете указать желаемое количество столбцов в текстовом кадре. 

Этот код C++ показывает, как добавить столбец внутри текстового кадра:
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


## **Update Text**

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, или все тексты в презентации. 

Этот код C++ демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:
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
                    //Изменяет текст
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Изменяет форматирование
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Сохраняет изменённую презентацию
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **Add a Text Box with a Hyperlink** 

Вы можете вставить ссылку внутрь текстового поля. При щелчке по текстовому полю пользователи перенаправляются к открытию ссылки. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с параметром `ShapeType`, установленным в `Rectangle`, в указанной позиции на слайде и получите ссылку на только что добавленный объект AutoShape. 
4. Добавьте `TextFrame` к объекту `AutoShape`, содержащий *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` методу [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c), связанному с желаемой частью `TextFrame`. 
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код C++ — реализация указанных выше шагов — показывает, как добавить текстовое поле со ссылкой на слайд:
```cpp
// Создает экземпляр класса Presentation, представляющего PPTX
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет объект AutoShape с типом Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Приводит форму к AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Получает доступ к свойству ITextFrame, связанному с AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Добавляет некоторый текст в кадр
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Устанавливает гиперссылку для текста части
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Сохраняет PPTX презентацию
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**В чём разница между текстовым полем и заполнительным текстом при работе с мастер‑слайдами?**

Заполнитель ([placeholder](/slides/ru/cpp/manage-placeholder/)) наследует стиль/позицию от [мастера](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/), тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте проход только авто‑фигурами, имеющими текстовые кадры, и исключите вложенные объекты ([диаграммы](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [таблицы](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)), проходя их коллекции отдельно или пропуская эти типы объектов.