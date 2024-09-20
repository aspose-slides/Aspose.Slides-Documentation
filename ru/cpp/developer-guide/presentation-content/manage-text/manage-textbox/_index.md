---
title: Управление текстовым полем
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords: "Текстовое поле, Текстовый фрейм, Добавить текстовое поле, Текстовое поле с гиперссылкой, C++, Aspose.Slides для C++"
description: "Добавьте текстовое поле или текстовый фрейм в презентации PowerPoint на C++"
---

Тексты на слайдах обычно содержатся в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, вам нужно добавить текстовое поле и затем поместить текст внутрь текстового поля. Aspose.Slides для C++ предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape), который позволяет добавлять фигуры, содержащие текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Но фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape), могут содержать текст.

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}} 

Поэтому, когда вы работаете с фигурой, к которой вы хотите добавить текст, вам может понадобиться проверить и подтвердить, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), который является свойством интерфейса `IAutoShape`. Смотрите раздел [Обновление текста](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создать текстовое поле на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) с заданным [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) как `Rectangle` в указанной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`. 
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведенном ниже примере мы добавили следующий текст: *Aspose TextBox*
5. Наконец, сохраните файл PPTX через объект `Presentation`. 

Этот код на C++— реализация описанных шагов—показывает, как добавить текст на слайд:

```cpp
// Создает экземпляр Presentation
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд в презентации
auto sld = pres->get_Slides()->idx_get(0);

// Добавляет AutoShape с типом, установленным как Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Добавляет TextFrame к Rectangle
ashp->AddTextFrame(u" ");

// Получает текстовый фрейм
auto txtFrame = ashp->get_TextFrame();

// Создает объект Paragraph для текстового фрейма
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Создает объект Portion для абзаца
auto portion = para->get_Portions()->idx_get(0);

// Устанавливает текст
portion->set_Text(u"Aspose TextBox");

// Сохраняет презентацию на диск
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Проверка фигуры текстового поля**

Aspose.Slides предоставляет метод [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (из класса [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/)), который позволяет вам исследовать фигуры и находить текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код на C++ показывает, как проверить, была ли фигура создана как текстовое поле: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"фигура является текстовым полем") : System::String(u"фигура не является текстовым полем"));
        }
    }
}
```

## **Добавление колонок в текстовое поле**

Aspose.Slides предоставляет методы [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) и [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) и класса [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)), которые позволяют добавлять колонки в текстовые поля. Вы можете указать количество колонок в текстовом поле и установить расстояние в пунктах между колонками.

Этот код на C++ демонстрирует описанную операцию: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Получает первый слайд в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет AutoShape с типом, установленным как Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Добавляет TextFrame к Rectangle
aShape->AddTextFrame(String(u"Все эти колонки ограничены быть внутри одного текстового контейнера -- ") 
    + u"вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически подстраивается " 
    + u"подходит к контейнеру. Текст не может переходить из одного контейнера " 
    + u"в другой, однако -- мы говорим вам, что опции колонок для текста в PowerPoint ограничены!");

// Получает текстовый формат TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Указывает количество колонок в TextFrame
format->set_ColumnCount(3);

// Указывает расстояние между колонками
format->set_ColumnSpacing(10);

// Сохраняет презентацию
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Добавление колонок в текстовый фрейм**
Aspose.Slides для C++ предоставляет метод [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)), который позволяет добавлять колонки в текстовые фреймы. С помощью этого метода вы можете указать предпочтительное количество колонок в текстовом фрейме.

Этот код на C++ показывает, как добавить колонку внутри текстового фрейма:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"Все эти колонки вынуждены оставаться внутри одного текстового контейнера -- ") 
    + u"вы можете добавлять или удалять текст - и новый или оставшийся текст автоматически подстраивается " 
    + u"подходит к контейнеру. Текст не может выливаться из одного контейнера " 
    + u"в другой, однако -- потому что опции колонок PowerPoint для текста ограничены!");
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

## **Обновить текст**

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле или все тексты, содержащиеся в презентации. 

Этот код на C++ демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:

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
                    // Изменяет текст
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    // Изменяет форматирование
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

// Сохраняет измененную презентацию
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Добавить текстовое поле с гиперссылкой** 

Вы можете вставить ссылку внутри текстового поля. Когда текстовое поле будет нажато, пользователи будут направлены на открытие ссылки. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с заданным `ShapeType` как `Rectangle` в указанной позиции на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` методу [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c), связанному с предпочтительной частью `TextFrame`. 
7. Наконец, сохраните файл PPTX через объект `Presentation`. 

Этот код на C++— реализация описанных шагов—показывает, как добавить текстовое поле с гиперссылкой на слайд:

```cpp
// Создает экземпляр класса Presentation, который представляет PPTX
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд в презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет объект AutoShape с типом, установленным как Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Приводит фигуру к AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Получает свойство ITextFrame, связанное с AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Добавляет текст в фрейм
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Устанавливает гиперссылку для текста части 
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Сохраняет PPTX-презентацию
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```