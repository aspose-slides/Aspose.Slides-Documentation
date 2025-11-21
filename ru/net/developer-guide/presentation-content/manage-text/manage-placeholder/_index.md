---
title: Управление заполнителями презентаций в .NET
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- подсказочный текст
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко управляйте заполнителями в Aspose.Slides для .NET: заменяйте текст, настраивайте подсказки и задавайте прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполнителе**
С помощью [Aspose.Slides for .NET](/slides/ru/net/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Требование**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте в него презентацию в качестве аргумента.  
2. Получите ссылку на слайд по его индексу.  
3. Пройдитесь по коллекции фигур, чтобы найти заполнитель.  
4. Приведите форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/), связанного с [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).  
5. Сохраните изменённую презентацию.

Это пример кода C#, показывающий, как изменить текст в заполнителе:
```c#
// Создаёт экземпляр класса Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Проходит по фигурам, чтобы найти заполнитель
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Изменяет текст в каждом заполнителе
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Сохраняет презентацию на диск
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Установить подсказочный текст в заполнителе**
В стандартных и готовых макетах содержатся подсказки заполнителей, такие как ***Click to add a title*** или ***Click to add a subtitle***. С помощью Aspose.Slides вы можете вставить свои собственные подсказочные тексты в макеты заполнителей.

Этот пример кода C# показывает, как задать подсказочный текст в заполнителе:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Проходит по слайду
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint отображает "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Добавляет подзаголовок
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **Установить прозрачность изображения заполнителя**

Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность картинки в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и картинки).

Этот пример кода C# показывает, как задать прозрачность фоновой картинки (внутри фигуры):
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


## **FAQ**

**Что такое базовый заполнитель и чем он отличается от локальной фигуры на слайде?**

Базовый заполнитель — это исходная фигура в макете или образце, от которой наследует форма слайда — тип, позиция и часть форматирования берутся от него. Локальная фигура независима; если базового заполнителя нет, наследование не применяется.

**Как можно обновить все заголовки или подписи во всей презентации без перебора каждого слайда?**

Отредактируйте соответствующий заполнитель в макете или образце. Слайды, основанные на этих макетах/образце, автоматически унаследуют изменение.

**Как управлять стандартными заполнителями колонтитулов — датой и временем, номером слайда и текстом нижнего колонтитула?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, образец, примечания/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержимое.