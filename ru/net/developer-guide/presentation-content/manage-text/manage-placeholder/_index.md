---
title: Управление заполняющими элементами презентации в .NET
linktitle: Управление заполняющими элементами
type: docs
weight: 10
url: /ru/net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- текст подсказки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Без усилий управляйте заполняющими элементами в Aspose.Slides для .NET: заменяйте текст, настраивайте подсказки и задавайте прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполняющем элементе**
Используя [Aspose.Slides for .NET](/slides/ru/net/), вы можете находить и изменять заполняющие элементы на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст заполняющего элемента.

**Требования**: Вам нужна презентация, содержащая заполняющий элемент. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполняющем элементе этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) и передайте в него презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Итерируйте по фигурам, чтобы найти заполняющий элемент.
4. Преобразуйте форму заполняющего элемента к типу [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/), связанного с [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Сохраните изменённую презентацию.

Этот код C# демонстрирует, как изменить текст в заполняющем элементе:
```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Проходит по фигурам, чтобы найти заполняющий элемент
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Изменяет текст в каждом заполняющем элементе
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Сохраняет презентацию на диск
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Установить текст подсказки в заполняющем элементе**
Стандартные и готовые макеты содержат тексты‑подсказки заполняющих элементов, такие как ***Click to add a title*** или ***Click to add a subtitle***. С помощью Aspose.Slides вы можете вставлять свои собственные тексты‑подсказки в макеты заполняющих элементов.

Этот код C# показывает, как установить текст подсказки в заполняющем элементе:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Итерирует по слайду
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


## **Установить прозрачность изображения в заполняющем элементе**
Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполняющем элементе. Регулируя прозрачность изображения в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и картинки).

Этот код C# показывает, как установить прозрачность фонового изображения (внутри фигуры):
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


## **Вопросы и ответы**

**Что такое базовый заполняющий элемент и чем он отличается от локальной фигуры на слайде?**

Базовый заполняющий элемент — это исходная форма в макете или шаблоне, от которой наследуется форма слайда: тип, положение и часть форматирования берутся из него. Локальная фигура независима; если базового заполняющего элемента нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без перебора каждого слайда?**

Отредактируйте соответствующий заполняющий элемент в макете или шаблоне. Слайды, основанные на этих макетах/шаблоне, автоматически унаследуют изменение.

**Как управлять стандартными заполняющими элементами верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом колонтитула?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, шаблон, заметки/раздачи), чтобы включать или выключать эти заполняющие элементы и задавать их содержимое.