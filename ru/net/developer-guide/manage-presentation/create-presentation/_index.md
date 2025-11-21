---
title: Создание презентаций в .NET
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/net/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте презентации в .NET с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Создать презентацию PowerPoint**
Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его Index.
1. Добавьте AutoShape типа Line с помощью метода AddAutoShape, предоставляемого объектом Shapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
// Создайте объект Presentation, который представляет файл презентации
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа линия
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Создать и сохранить презентацию**

<a name="csharp-create-save-presentation"><strong>Шаги: создать и сохранить презентацию на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Открыть и сохранить презентацию**

<a name="csharp-open-save-presentation"><strong>Шаги: открыть и сохранить презентацию на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с любым форматом, например PPT, PPTX, ODP и т.д.
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// Загрузите любой поддерживаемый файл в Presentation, например ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **FAQ**

**В какие форматы можно сохранить новую презентацию?**

Вы можете сохранить в [PPTX, PPT, and ODP](/slides/ru/net/save-presentation/), а также экспортировать в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), [SVG](/slides/ru/net/convert-powerpoint-to-png/), и [images](/slides/ru/net/convert-powerpoint-to-png/), среди прочего.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/net/supported-file-formats/).

**Как управлять размером/соотношением сторон слайда при создании презентации?**

Установите [slide size](/slides/ru/net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и задайте, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с большим количеством медиа‑файлов), чтобы уменьшить использование памяти?**

Используйте [BLOB management strategies](/slides/ru/net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтите файловые рабочие процессы вместо полностью память‑ориентированных потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) из [multiple threads](/slides/ru/net/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как убрать водяной знак пробной версии и ограничения?**

[Apply a license](/slides/ru/net/licensing/) один раз на процесс. XML лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе с несколькими потоками.

**Можно ли цифрово подписать созданный PPTX?**

Да. [Digital signatures](/slides/ru/net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [create/edit VBA projects](/slides/ru/net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.