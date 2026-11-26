---
title: Управление элементами управления ActiveX в презентациях с использованием C++
linktitle: ActiveX
type: docs
weight: 80
url: /ru/cpp/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Редактировать текстовые поля и кнопки ActiveX, обновлять превью элементов управления и повторно использовать элемент управления Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides для C++."
---
## **Введение**

Элементы управления ActiveX предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides для C++ предоставляет доступ к элементам управления слайда через [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Используйте эту коллекцию, чтобы изменить элемент управления, переместить его на слайде или удалить его.

## **Список ActiveX‑элементов управления и их сохранённых свойств**

Чтобы изучить неизвестный шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), а также каждую пару ключ‑значение в [stored properties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Он читает презентацию без активации элементов управления, вызова событий или макросов, изменения значений или сохранения файла.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и кнопку команды.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих бинарное хранилище, `get_Properties` может возвращать `nullptr`, отображаемое как `Properties unavailable`. Если нужны только имена, используйте [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) после проверки наличия коллекции. Отчёт перечисляет свойства, доступные в презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменение ActiveX‑элементов управления**

В примере ожидается презентация с поддержкой макросов, содержащая текстовое поле с именем `TextBox1` и кнопку команды с именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может показать до активации. Предоставьте PNG‑изображение для каждого элемента управления, отображающее обновлённый текст и внешний вид. Пример назначает эти изображения через [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Пример перемещает каждый элемент управления на первом слайде вниз на 100 пунктов, изменяя его [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) to save a second copy with all ActiveX controls removed from that slide.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **Добавление элемента управления медиаплеером ActiveX**

Чтобы переиспользовать уже настроенный элемент управления Windows Media Player, начните с шаблона, у которого первый слайд содержит плеер с именем `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в выходном файле. Видео остаётся внешним, поэтому укажите путь, доступный плееру во время воспроизведения.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides сохранять элементы управления ActiveX без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и положения, без их активации.

**В чём разница между элементами управления ActiveX и объектами OLE?**

Элементы управления ActiveX позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE‑объект](/slides/ru/cpp/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например рабочую книгу Excel.

**Будут ли события ActiveX по‑прежнему вызывать VBA‑макросы после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате с поддержкой макросов, например PPTM, чтобы сохранить её проект VBA. PowerPoint для Windows может выполнять существующие обработчики событий, если параметры безопасности позволяют использовать как элементы управления ActiveX, так и макросы.