---
title: Управление элементами управления ActiveX в презентациях на .NET
linktitle: ActiveX
type: docs
weight: 80
url: /ru/net/activex/
keywords:
- ActiveX
- Элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- модификация ActiveX
- медиаплеер
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Редактируйте текстовые поля и кнопки ActiveX, обновляйте предварительные просмотры элементов управления и повторно используйте элемент управления Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides для .NET."
---
## **Введение**

Элементы управления ActiveX предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for .NET предоставляет доступ к элементам управления слайда через [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Используйте эту коллекцию для редактирования элемента управления, перемещения его на слайде или удаления.

## **Список элементов управления ActiveX и их сохранённые свойства**

Чтобы изучить неизвестный шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), а также каждую пару ключ‑значение в [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Он читает презентацию без активации элементов управления, вызова событий или макросов, изменения значений или сохранения файла.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и кнопку команд.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих двоичное хранение, `Properties` может возвращать `null`, отображаемое как `Properties unavailable`. Если нужны только имена, используйте [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) после проверки на null. Отчёт перечисляет свойства, доступные из презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменить элементы управления ActiveX**

Пример ожидает презентацию с поддержкой макросов, в которой на первом слайде находится текстовое поле с именем `TextBox1` и кнопка команд с именем `CommandButton1`. Он использует [коллекцию свойств элемента управления](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может отображать до активации. Предоставьте PNG‑изображение для каждого элемента управления, показывающее обновлённый текст и внешний вид. Пример назначает эти изображения через [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Пример перемещает каждый элемент управления на первом слайде вниз на 100 пунктов, изменяя его [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) для сохранения второй копии без всех элементов управления ActiveX на этом слайде.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Добавить элемент управления ActiveX Media Player**

Чтобы повторно использовать настроенный элемент управления Windows Media Player, начните с шаблона, у которого первый слайд содержит плеер с именем `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [коллекцию свойств](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в результате. Видео остаётся внешним, поэтому выберите путь, к которому плеер может получить доступ во время воспроизведения.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides сохранять элементы управления ActiveX без их запуска?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем элементы управления ActiveX отличаются от объектов OLE?**

Элементы управления ActiveX позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [объект OLE](/slides/ru/net/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например лист Excel.

**Будут ли события ActiveX по-прежнему вызывать VBA‑макросы после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате с поддержкой макросов, например PPTM, чтобы сохранить её проект VBA. PowerPoint для Windows может выполнять существующие обработчики событий, если настройки безопасности позволяют и элементы управления ActiveX, и макросы.