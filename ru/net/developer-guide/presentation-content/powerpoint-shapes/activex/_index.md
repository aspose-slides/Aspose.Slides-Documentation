---
title: ActiveX
type: docs
weight: 80
url: /net/activex/
keywords: "ActiveX, элементы управления ActiveX, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Управляйте элементами управления ActiveX в презентации PowerPoint на C# или .NET"
---

Элементы управления ActiveX используются в презентациях. Aspose.Slides для .NET позволяет управлять элементами управления ActiveX, но делать это немного сложнее и иначе, чем с обычными фигурами презентации. Начиная с версии Aspose.Slides для .NET 6.9.0, компонент поддерживает управление элементами управления ActiveX. В данный момент вы можете получить доступ к уже добавленному элементу управления ActiveX в вашей презентации и изменять или удалять его, используя его различные свойства. Помните, что элементы управления ActiveX не являются фигурами и не входят в коллекцию IShapeCollection презентации, а являются частью отдельной IControlCollection. Эта статья показывает, как с ними работать.
## **Изменить элементы управления ActiveX**
Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию с элементами управления ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к элементу управления ActiveX TextBox1, используя объект ControlEx.
1. Измените различные свойства элемента управления ActiveX TextBox1, включая текст, шрифт, высоту шрифта и положение рамки.
1. Получите доступ ко второму элементу управления, называемому CommandButton1.
1. Измените заголовок кнопки, шрифт и положение.
1. Сдвиньте положение рамок элементов управления ActiveX.
1. Запишите измененную презентацию в файл PPTX.

Ниже приведенный фрагмент кода обновляет элементы управления ActiveX на слайдах презентации, как показано ниже.

```c#
// Доступ к презентации с элементами управления ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Доступ к первому слайду в презентации
ISlide slide = presentation.Slides[0];

// изменение текста TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Измененный текст";
    control.Properties["Value"] = newText;

    // изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX, поэтому иногда нормально оставить изображение без изменений.

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

// изменение заголовка кнопки
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "Сообщение";
    control.Properties["Caption"] = newCaption;

    // изменение заменяющего
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

// Перемещение рамок ActiveX вниз на 100 пунктов
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Сохраните презентацию с измененными элементами управления ActiveX
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Теперь удаляем элементы управления
slide.Controls.Clear();

// Сохранение презентации с очищенными элементами управления ActiveX
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Добавить элемент управления ActiveX Media Player**
Чтобы добавить элемент управления ActiveX Media Player, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации с элементами управления Media Player ActiveX.
1. Создайте экземпляр целевого класса Presentation и создайте пустую презентацию.
1. Клонируйте слайд с элементом управления Media Player ActiveX из шаблонной презентации в целевую презентацию.
1. Получите доступ к клонированному слайду в целевой презентации.
1. Получите доступ к элементам управления ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к элементу управления Media Player ActiveX и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

```c#
// Создаем экземпляр класса Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// Создайте пустую презентацию
Presentation newPresentation = new Presentation();

// Удалите стандартный слайд
newPresentation.Slides.RemoveAt(0);

// Клонируйте слайд с элементом управления Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Получите доступ к элементу управления Media Player ActiveX и задайте путь к видео
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Сохраните презентацию
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```