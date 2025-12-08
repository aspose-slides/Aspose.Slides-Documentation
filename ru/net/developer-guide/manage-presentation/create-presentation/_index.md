---
title: Создание презентации в .NET
linktitle: Создание презентации
type: docs
weight: 10
url: /ru/net/create-presentation/
keywords: "Создание PowerPoint, PPTX, PPT, Создание презентации, Инициализация презентации, C#, .NET"
description: "Программное создание презентаций PowerPoint на C# например PPT, PPTX, ODP и др."
---

## **Создание презентации PowerPoint**
Чтобы добавить простую прямую линию на выбранный слайд презентации, выполните следующие действия:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
1. Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд
    ISlide slide = presentation.Slides[0];

    // Добавить автоконтур типа линия
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Создание и сохранение презентации**

<a name="csharp-create-save-presentation"><strong>Шаги: создание и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Открытие и сохранение презентации**

<a name="csharp-open-save-presentation"><strong>Шаги: открытие и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) любого формата, например PPT, PPTX, ODP и т.д.
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
```c#
// Загрузите любой поддерживаемый файл в Presentation, например ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Вопросы и ответы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/net/save-presentation/), а также экспортировать в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), [SVG](/slides/ru/net/convert-powerpoint-to-png/) и [изображения](/slides/ru/net/convert-powerpoint-to-png/), и другие форматы.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/net/supported-file-formats/).

**Как контролировать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/net/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы уменьшить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочитайте файловые рабочие процессы вместо полностью в‑памяти потоков.

**Могу ли я создавать/сохранять презентации параллельно?**

Нельзя работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/net/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как убрать водяной знак и ограничения пробной версии?**

[Примените лицензию](/slides/ru/net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе с несколькими потоками.

**Могу ли я цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.