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
- Тип размещения SmartArt
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint на .NET с помощью Aspose.Slides, предоставляя лаконичные примеры кода и рекомендации, ориентированные на производительность."
---

## **Создать форму SmartArt**
Aspose.Slides for .NET теперь позволяет добавлять пользовательские элементы SmartArt в слайды с нуля. Aspose.Slides for .NET предоставляет самый простой API для создания элементов SmartArt самым простым способом. Чтобы создать элемент SmartArt в слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте элемент SmartArt, задав его LayoutType.
- Сохраните изменённую презентацию в файл PPTX.
```c#
// Создать экземпляр презентации
using (Presentation pres = new Presentation())
{

    // Получить доступ к слайду презентации
    ISlide slide = pres.Slides[0];

    // Добавить форму Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Сохранить презентацию
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Доступ к элементу SmartArt на слайде**
В следующем коде будет продемонстрирован доступ к элементам SmartArt, добавленным в слайд презентации. В примере кода мы перебираем все формы на слайде и проверяем, является ли форма элементом SmartArt. Если форма относится к типу SmartArt, мы приводим её к экземпляру SmartArt.
```c#
// Загрузить нужную презентацию
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Обойти все формы на первом слайде
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверить, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести форму к SmartArt
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Доступ к элементу SmartArt с определённым типом LayoutType**
В следующем примере кода показано, как получить доступ к элементу SmartArt с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя, так как он только для чтения и задаётся лишь при добавлении элемента SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с элементом SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем формам на первом слайде.
- Проверьте, относится ли форма к типу SmartArt, и при необходимости приведите выбранную форму к SmartArt.
- Проверьте элемент SmartArt с определённым LayoutType и выполните необходимые действия.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем формам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести форму к SmartArtEx
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


## **Изменить стиль элемента SmartArt**
В следующем примере кода показано, как получить доступ к элементу SmartArt с определённым LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с элементом SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем формам на первом слайде.
- Проверьте, относится ли форма к типу SmartArt, и при необходимости приведите выбранную форму к SmartArt.
- Найдите элемент SmartArt с определённым стилем.
- Установите новый стиль для элемента SmartArt.
- Сохраните презентацию.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем формам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести форму к SmartArtEx
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


## **Изменить цветовой стиль элемента SmartArt**
В следующем примере кода показано, как получить доступ к элементу SmartArt с определённым цветовым стилем и изменить его стиль.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с элементом SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем формам на первом слайде.
- Проверьте, относится ли форма к типу SmartArt, и при необходимости приведите выбранную форму к SmartArt.
- Найдите элемент SmartArt с определённым цветовым стилем.
- Установите новый цветовой стиль для элемента SmartArt.
- Сохраните презентацию.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Пройтись по всем формам на первом слайде
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Проверить, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Проверка типа цвета SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Изменение типа цвета SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Сохранение презентации
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Можно ли анимировать SmartArt как один объект?**

Да. SmartArt — это форма, поэтому её можно анимировать с помощью [стандартных анимаций](/slides/ru/net/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения), как и другие формы.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Установите и используйте альтернативный текст (AltText) и ищите форму по этому значению — рекомендованный способ находить нужную форму.

**Можно ли группировать SmartArt с другими формами?**

Да. Вы можете сгруппировать SmartArt с другими формами (изображениями, таблицами и т.д.) и затем [управлять группой](/slides/ru/net/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [рендерить отдельные формы](/slides/ru/net/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Функция рендеринга обеспечивает высокую точность при [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/), предлагая различные параметры качества и совместимости.