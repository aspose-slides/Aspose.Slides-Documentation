---
title: Управление фигурой SmartArt
type: docs
weight: 20
url: /ru/net/manage-smartart-shape/
keywords: "фигура SmartArt, стиль фигуры SmartArt, цветовой стиль фигуры SmartArt, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Управление SmartArt в презентациях PowerPoint на C# или .NET"
---

## **Создание фигуры SmartArt**
Aspose.Slides для .NET теперь позволяет добавлять пользовательские фигуры SmartArt на слайды с нуля. Aspose.Slides для .NET предоставил самый простой API для создания фигур SmartArt самым простым способом. Чтобы создать фигуру SmartArt на слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру SmartArt, установив ее LayoutType.
- Запишите измененную презентацию в файл PPTX.

```c#
// Создание презентации
using (Presentation pres = new Presentation())
{

    // Доступ к слайду презентации
    ISlide slide = pres.Slides[0];

    // Добавление фигуры Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Сохранение презентации
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Доступ к фигуре SmartArt на слайде**
Следующий код будет использоваться для доступа к фигурам SmartArt, добавленным на слайд презентации. В образцовом коде мы будем проходить через каждую фигуру внутри слайда и проверять, является ли она фигурой SmartArt. Если фигура типа SmartArt, мы типизируем её как экземпляр SmartArt.

```c#
// Загрузка нужной презентации
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Прохождение через каждую фигуру на первом слайде
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Типизация фигуры как SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Имя фигуры:" + smart.Name);

        }
    }
}
```



## **Доступ к фигуре SmartArt с определенным типом макета**
Следующий образец кода поможет получить доступ к фигуре SmartArt с определенным LayoutType. Обратите внимание, что вы не можете изменить LayoutType фигуры SmartArt, так как она является только для чтения и устанавливается только при добавлении фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Проходите через каждую фигуру внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и при необходимости типизируйте выбранную фигуру как SmartArt.
- Проверьте фигуру SmartArt с определенным LayoutType и выполните необходимые действия.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Прохождение через каждую фигуру на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Типизация фигуры как SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Проверка макета SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Выполните какое-либо действие здесь....");
            }
        }
    }
}
```



## **Изменение стиля фигуры SmartArt**
Следующий образец кода поможет получить доступ к фигуре SmartArt с определенным LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Проходите через каждую фигуру внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и типизируйте выбранную фигуру как SmartArt, если это SmartArt.
- Найдите фигуру SmartArt с определенным стилем.
- Установите новый стиль для фигуры SmartArt.
- Сохраните презентацию.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Прохождение через каждую фигуру на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Типизация фигуры как SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Проверка стиля SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Изменение стиля SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Сохранение презентации
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Изменение цветового стиля фигуры SmartArt**
В этом примере мы научимся изменять цветовой стиль для любой фигуры SmartArt. В следующем образце кода мы получим доступ к фигуре SmartArt с определенным цветовым стилем и изменим его стиль.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Проходите через каждую фигуру внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и типизируйте выбранную фигуру как SmartArt, если это SmartArt.
- Найдите фигуру SmartArt с определенным цветовым стилем.
- Установите новый цветовой стиль для фигуры SmartArt.
- Сохраните презентацию.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Прохождение через каждую фигуру на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Типизация фигуры как SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Проверка цветового типа SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Изменение цветового типа SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Сохранение презентации
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```