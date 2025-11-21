---
title: Управление графикой SmartArt в презентациях в .NET
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/net/manage-smartart-shape/
keywords:
- Объект SmartArt
- Графика SmartArt
- Стиль SmartArt
- Цвет SmartArt
- Создание SmartArt
- Добавление SmartArt
- Редактирование SmartArt
- Изменение SmartArt
- Доступ к SmartArt
- Тип макета SmartArt
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint с помощью .NET и Aspose.Slides, предлагая лаконичные примеры кода и рекомендации, ориентированные на производительность."
---

## **Создание фигуры SmartArt**
Aspose.Slides for .NET теперь позволяет добавлять пользовательские фигуры SmartArt в свои слайды с нуля. Aspose.Slides for .NET предоставляет самый простой API для создания фигур SmartArt самым лёгким способом. Чтобы создать фигуру SmartArt на слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру SmartArt, установив её LayoutType.
- Сохраните изменённую презентацию как файл PPTX.
```c#
// Создать презентацию
using (Presentation pres = new Presentation())
{

    // Доступ к слайду презентации
    ISlide slide = pres.Slides[0];

    // Добавить форму Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Сохранение презентации
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Доступ к фигуре SmartArt на слайде**
Следующий код будет использоваться для доступа к фигурам SmartArt, добавленным в слайд презентации. В примере кода мы пройдемся по каждой фигуре внутри слайда и проверим, является ли она фигурой SmartArt. Если фигура типа SmartArt, то мы приведём её к экземпляру SmartArt.
```c#
 // Загрузить нужную презентацию
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // Пройтись по всем фигурам на первом слайде
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Проверить, является ли фигура типом SmartArt
         if (shape is ISmartArt)
         {
             // Приведение типа фигуры к SmartArtEx
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```


## **Доступ к фигуре SmartArt с определённым типом LayoutType**
Следующий пример кода поможет получить доступ к фигуре SmartArt с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя, так как он только для чтения и задаётся только при добавлении фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и если да, выполните приведение типа выбранной фигуры к SmartArt.
- Проверьте фигуру SmartArt с определённым LayoutType и выполните необходимые дальнейшие действия.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем фигурам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести фигуру к типу SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Проверка макета SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **Изменение стиля фигуры SmartArt**
Следующий пример кода поможет получить доступ к фигуре SmartArt с определённым LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и если да, выполните приведение типа выбранной фигуры к SmartArt.
- Найдите фигуру SmartArt с определённым Style.
- Установите новый Style для фигуры SmartArt.
- Сохраните презентацию.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем фигурам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести фигуру к типу SmartArtEx
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
В этом примере мы узнаем, как изменить цветовой стиль любой фигуры SmartArt. В следующем примере кода будет получен доступ к фигуре SmartArt с определённым цветовым стилем и изменён её стиль.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и если да, выполните приведение типа выбранной фигуры к SmartArt.
- Найдите фигуру SmartArt с определённым Color Style.
- Установите новый Color Style для фигуры SmartArt.
- Сохраните презентацию.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем фигурам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести фигуру к типу SmartArtEx
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


## **FAQ**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt — это фигура, поэтому вы можете применять [standard animations](/slides/ru/net/powerpoint-animation/) через API анимаций (вход, выход, выделение, пути движения) как и для других фигур.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Задайте и используйте альтернативный текст (AltText) и ищите фигуру по этому значению — это рекомендованный способ найти нужную фигуру.

**Могу ли я сгруппировать SmartArt с другими фигурами?**

Да. Вы можете сгруппировать SmartArt с другими фигурами (изображения, таблицы и т.д.), а затем [manipulate the group](/slides/ru/net/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение фигуры; библиотека может [render individual shapes](/slides/ru/net/create-shape-thumbnails/) в растр‑файлы (PNG/JPG/TIFF).

**Сохраняется ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок обеспечивает высокую точность при [PDF export](/slides/ru/net/convert-powerpoint-to-pdf/), предоставляя разнообразные параметры качества и совместимости.