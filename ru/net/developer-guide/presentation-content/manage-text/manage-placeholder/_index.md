---
title: Управление Заполнитель
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "Заполнитель, Текст заполнителя, Текст подсказки, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Измените текст заполнителя и текст подсказки в презентациях PowerPoint на C# или .NET"
---

## **Изменить текст в заполнителе**
С помощью [Aspose.Slides для .NET](/slides/net/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Предварительное условие**: Вам нужна презентация, которая содержит заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Переберите фигуры, чтобы найти заполнитель.
4. Приведите форму заполнителя к [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/), связанного с [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Сохраните измененную презентацию.

Этот код C# показывает, как изменить текст в заполнителе:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Получает доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Перебирает фигуры, чтобы найти заполнитель
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Изменяет текст в каждом заполнителе
            ((IAutoShape)shp).TextFrame.Text = "Это Заполнитель";
        }

    // Сохраняет презентацию на диск
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Установить текст подсказки в заполнитель**
Стандартные и заранее подготовленные макеты содержат текст подсказки для заполнителей, например, ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставить свои предпочитаемые тексты подсказки в макеты заполнителей.

Этот код C# показывает, как установить текст подсказки в заполнитель:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Перебирает слайд
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint отображает "Нажмите, чтобы добавить заголовок"
            {
                text = "Добавить Заголовок";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Добавляет подзаголовок
            {
                text = "Добавить Подзаголовок";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Заполнитель с текстом: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Установить прозрачность изображения заполнителя**

Aspose.Slides позволяет задавать прозрачность фона изображения в текстовом заполнителе. Регулируя прозрачность изображения в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и изображения).

Этот код C# показывает, как установить прозрачность для фона изображения (внутри фигуры):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```