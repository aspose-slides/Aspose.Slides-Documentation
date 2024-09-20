---
title: Изменение размеров фигур на слайде
type: docs
weight: 130
url: /net/re-sizing-shapes-on-slide/
---

## **Изменение размеров фигур на слайде**
Один из самых частых вопросов, задаваемых клиентами Aspose.Slides для .NET, заключается в том, как изменить размеры фигур, чтобы данные не обрезались при изменении размера слайда. Этот короткий технический совет показывает, как этого добиться.

Чтобы избежать дезориентации фигур, каждую фигуру на слайде необходимо обновить в соответствии с новым размером слайда.

```c#
 //Загрузите презентацию
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//Старый размер слайда
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Изменение размера слайда
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//Новый размер слайда
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//Изменение позиции
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//Изменение размера фигуры, если требуется 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Если на слайде есть таблица, то вышеуказанный код не сработает корректно. В этом случае каждую ячейку таблицы нужно изменить.

{{% /alert %}} 

Вам нужно использовать следующий код, если вам нужно изменить размеры слайдов с таблицами. Установка ширины или высоты таблицы – это особый случай в фигурах, где необходимо изменить высоту отдельных строк и ширину столбцов, чтобы изменить высоту и ширину таблицы.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//Старый размер слайда
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Изменение размера слайда
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//Новый размер слайда
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;


float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //Изменение позиции
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Изменение размера фигуры, если требуется 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //Изменение позиции
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //Изменение размера фигуры, если требуется 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //Изменение позиции
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Изменение размера фигуры, если требуется 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;
        if (shape is ITable)
        {
            ITable table = (ITable)shape;
            foreach (IRow row in table.Rows)
            {
                row.MinimalHeight = row.MinimalHeight * ratioHeight;
                //   row.Height = row.Height * ratioHeight;
            }
            foreach (IColumn col in table.Columns)
            {
                col.Width = col.Width * ratioWidth;

            }
        }

    }
}

presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);
```