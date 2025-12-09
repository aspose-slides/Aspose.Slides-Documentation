---
title: Создание презентаций в .NET
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/net/create-presentation/
keywords:
- создание презентации
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

## **Создание презентации PowerPoint**
Чтобы добавить простую обычную линию на выбранный слайд презентации, выполните следующие действия:

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
4. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
 // Создайте объект Presentation, представляющий файл презентации
 using (Presentation presentation = new Presentation())
 {
     // Получите первый слайд
     ISlide slide = presentation.Slides[0];
 
     // Добавьте автоконтур типа линия
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```


## **Создание и сохранение презентации**

<a name="csharp-create-save-presentation"><strong>Шаги: Создание и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Открытие и сохранение презентации**

<a name="csharp-open-save-presentation"><strong>Шаги: Открытие и сохранение презентации на C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с любым форматом, например PPT, PPTX, ODP и т.д.
2. Сохраните _Presentation_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// Загрузите любой поддерживаемый файл в Presentation, например ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Часто задаваемые вопросы**

**В какие форматы я могу сохранять новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/net/save-presentation/), а также экспортировать в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), [SVG](/slides/ru/net/convert-powerpoint-to-png/), и [images](/slides/ru/net/convert-powerpoint-to-png/), и др.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в требуемый формат; форматы POTX/POTM/PPTM и подобные [поддерживаются](/slides/ru/net/supported-file-formats/).

**Как задать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/net/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы уменьшить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтите файловые рабочие процессы вместо полностью оперативных потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Нельзя работать с тем же объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/net/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

**Как удалить водяной знак пробной версии и ограничения?**

[Примените лицензию](/slides/ru/net/licensing/) один раз за процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована, если задействовано несколько потоков.

**Могу ли я цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в создаваемых презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.