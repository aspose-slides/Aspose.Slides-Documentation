---
title: Управление формой SmartArt
type: docs
weight: 20
url: /ru/net/manage-smartart-shape/
keywords: "SmartArt shape, стиль формы SmartArt, цветовой стиль формы SmartArt, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Управление SmartArt в презентациях PowerPoint на C# или .NET"
---

## **Создать форму SmartArt**
Aspose.Slides for .NET теперь позволяет добавлять пользовательские формы SmartArt в слайды с нуля. Aspose.Slides for .NET предоставляет самый простой API для создания форм SmartArt самым легким способом. Чтобы создать форму SmartArt в слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте форму SmartArt, задав её LayoutType.
- Запишите изменённую презентацию в файл PPTX.
```c#
// Создать экземпляр презентации
using (Presentation pres = new Presentation())
{

    // Получить доступ к слайду презентации
    ISlide slide = pres.Slides[0];

    // Добавить форму Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Сохранение презентации
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Доступ к форме SmartArt в слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным в слайд презентации. В примере кода мы будем проходить по каждой форме внутри слайда и проверять, является ли она формой SmartArt. Если форма относится к типу SmartArt, мы приведём её к экземпляру SmartArt.
```c#
// Загрузить нужную презентацию
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Пройтись по всем формам на первом слайде
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверить, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Доступ к форме SmartArt с определённым типом Layout**
Следующий пример кода поможет получить форму SmartArt с конкретным LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя — он доступен только для чтения и задаётся только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по всем формам в первом слайде.
- Проверьте, является ли форма типом SmartArt, и при необходимости выполните приведение типа выбранной формы к SmartArt.
- Проверьте форму SmartArt с конкретным LayoutType и выполните необходимые дальнейшие действия.
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


## **Изменить стиль формы SmartArt**
Следующий пример кода поможет получить форму SmartArt с определённым LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по всем формам в первом слайде.
- Проверьте, является ли форма типом SmartArt, и при необходимости выполните приведение типа выбранной формы к SmartArt.
- Найдите форму SmartArt с конкретным Style.
- Установите новый Style для формы SmartArt.
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


## **Изменить цветовой стиль формы SmartArt**
В этом примере мы научимся менять цветовой стиль любой формы SmartArt. В следующем примере кода будет доступ к форме SmartArt с определённым цветовым стилем и будет изменён её стиль.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по всем формам в первом слайде.
- Проверьте, является ли форма типом SmartArt, и при необходимости выполните приведение типа выбранной формы к SmartArt.
- Найдите форму SmartArt с конкретным Color Style.
- Установите новый Color Style для формы SmartArt.
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

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является формой, поэтому вы можете применять [стандартные анимации](/slides/ru/net/powerpoint-animation/) через API анимаций (вход, выход, акцент, пути движения), как и к другим формам.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Установите и используйте альтернативный текст (AltText) и ищите форму по этому значению — это рекомендуемый способ найти целевую форму.

**Могу ли я группировать SmartArt с другими формами?**

Да. Вы можете группировать SmartArt с другими формами (изображения, таблицы и т.д.), а затем [управлять группой](/slides/ru/net/group/).

**Как получить изображение конкретного SmartArt (например, для предпросмотра или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [отображать отдельные формы](/slides/ru/net/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок ориентирован на высокую точность при [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/), предлагая широкий набор параметров качества и совместимости.