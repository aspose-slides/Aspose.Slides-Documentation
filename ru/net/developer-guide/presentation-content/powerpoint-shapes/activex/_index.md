---
title: Управление ActiveX элементами управления в презентациях в .NET
linktitle: ActiveX
type: docs
weight: 80
url: /ru/net/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для .NET использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

ActiveX‑элементы управления используются в презентациях. Aspose.Slides для .NET позволяет управлять ActiveX‑элементами, но работа с ними немного сложнее и отличается от работы с обычными фигурами презентации. Начиная с Aspose.Slides для .NET 6.9.0 компонент поддерживает управление ActiveX‑элементами. В данный момент вы можете получить доступ к уже добавленному ActiveX‑элементу в презентации и изменить или удалить его, используя различные свойства. Помните, что ActiveX‑элементы не являются фигурами и не входят в IShapeCollection презентации, а находятся в отдельном IControlCollection. В этой статье показано, как работать с ними.

## **Изменение ActiveX‑элементов управления**
Для управления простым ActiveX‑элементом, например текстовым полем и простой кнопкой‑командой на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию, содержащую ActiveX‑элементы управления.
1. Получите ссылку на слайд по его индексу.
1. Доступ к ActiveX‑элементам на слайде получите через IControlCollection.
1. Получите доступ к ActiveX‑элементу TextBox1 с помощью объекта ControlEx.
1. Измените различные свойства ActiveX‑элемента TextBox1, включая текст, шрифт, высоту шрифта и положение рамки.
1. Получите доступ ко второму элементу управления под названием CommandButton1.
1. Измените подпись кнопки, шрифт и положение.
1. Сдвиньте позиции рамок ActiveX‑элементов управления.
1. Запишите изменённую презентацию в файл PPTX.

Ниже приведён фрагмент кода, обновляющий ActiveX‑элементы на слайдах презентации, как показано ниже.
```c#
// Получение презентации с элементами управления ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Получение первого слайда в презентации
ISlide slide = presentation.Slides[0];

// Изменение текста TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX, поэтому иногда допускается оставить изображение без изменений.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Изменение подписи кнопки
    control = slide.Controls[1];

    if (control.Name == "CommandButton1" && control.Properties != null)
    {
        String newCaption = "MessageBox";
        control.Properties["Caption"] = newCaption;

        // Изменение заменяющего изображения
        Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
        Graphics graphics = Graphics.FromImage(image);
        Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
        graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
        brush.Dispose();
        System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
        brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
        SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
        graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
        brush.Dispose();
        Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
        graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
        pen.Dispose();
        pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
        graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
        pen.Dispose();
        pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
        graphics.DrawLines(pen,new System.Drawing.Point[]
        {
            new System.Drawing.Point(1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
        });
        pen.Dispose();
        pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
        graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
        pen.Dispose();
        graphics.Dispose();
        control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
    }

    // Перемещение кадров ActiveX на 100 пунктов вниз
    foreach (Control ctl in slide.Controls)
    {
        IShapeFrame frame = control.Frame;
        control.Frame = new ShapeFrame(
            frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
    }

    // Сохранение презентации с изменёнными элементами управления ActiveX
    presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


    // Теперь удаляем элементы управления
    slide.Controls.Clear();

    // Сохранение презентации с очищенными элементами управления ActiveX
    presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Добавление ActiveX‑элемента Media Player**
Чтобы добавить ActiveX‑элемент Media Player, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации с ActiveX‑элементом Media Player.
1. Создайте экземпляр целевого класса Presentation и сформируйте пустой экземпляр презентации.
1. Клонируйте слайд с ActiveX‑элементом Media Player из шаблонной презентации в целевую презентацию.
1. Получите доступ к клонированному слайду в целевой презентации.
1. Доступ к ActiveX‑элементам на слайде получите через IControlCollection.
1. Получите доступ к ActiveX‑элементу Media Player и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.
```c#
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation("template.pptx");

// Создание пустого экземпляра презентации
Presentation newPresentation = new Presentation();

// Удаление слайда по умолчанию
newPresentation.Slides.RemoveAt(0);

// Клонирование слайда с ActiveX‑элементом Media Player
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Доступ к ActiveX‑элементу Media Player и установка пути к видео
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Сохранение презентации
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑элементы управления при чтении и повторном сохранении, если они не могут быть выполнены в среде .NET?**

Да. Aspose.Slides рассматривает их как часть презентации и может считывать/изменять их свойства и рамки; выполнение самих элементов не требуется для их сохранения.

**Чем ActiveX‑элементы управления отличаются от OLE‑объектов в презентации?**

ActiveX‑элементы управления — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/net/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются иначе и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы запускаются только в PowerPoint на Windows при разрешённой безопасности. Библиотека не выполняет VBA.