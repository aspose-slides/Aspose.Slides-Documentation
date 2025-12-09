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
description: "Создавайте презентации в .NET с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте преимущества поддержки OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Создать презентацию PowerPoint**
Чтобы добавить простую линию к выбранному слайду презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его Index.
1. Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию к первому слайду презентации.
```c#
 // Создайте объект Presentation, представляющий файл презентации
 using (Presentation presentation = new Presentation())
 {
     // Получить первый слайд
     ISlide slide = presentation.Slides[0];

     // Добавить AutoShape типа линия
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```


## **Создание и сохранение презентации**

<a name="csharp-create-save-presentation"><strong>Шаги: создание и сохранение презентации в C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Открытие и сохранение презентации**

<a name="csharp-open-save-presentation"><strong>Шаги: открытие и сохранение презентации в C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с любым форматом, например PPT, PPTX, ODP и т.д.
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// Загрузите любой поддерживаемый файл в объект Presentation, например ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Часто задаваемые вопросы**

**В какие форматы можно сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/net/save-presentation/), а также экспортировать в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), [SVG](/slides/ru/net/convert-powerpoint-to-png/), и [images](/slides/ru/net/convert-powerpoint-to-png/), среди прочего.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в необходимый формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/net/supported-file-formats/).

**Как управлять размером слайда/соотношением сторон при создании презентации?**

Установите [slide size](/slides/ru/net/slide-size/) (включая пресеты 4:3 и 16:9 или пользовательские размеры) и выберите, как масштабировать содержимое.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм = 72 единицы.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы сократить использование памяти?**

Используйте [BLOB management strategies](/slides/ru/net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтите файловые рабочие процессы вместо полностью потоковых решений в памяти.

**Могу ли я создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) из [multiple threads](/slides/ru/net/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как удалить пробный водяной знак и ограничения?**

[Apply a license](/slides/ru/net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а установка лицензии должна быть синхронной при работе в нескольких потоках.

**Могу ли я цифрово подписать создаваемый PPTX?**

Да. [Digital signatures](/slides/ru/net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в создаваемых презентациях?**

Да. Вы можете [create/edit VBA projects](/slides/ru/net/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.