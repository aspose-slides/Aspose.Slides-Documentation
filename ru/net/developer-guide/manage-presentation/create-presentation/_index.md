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
description: "Создавайте презентации в .NET с Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте преимущества поддержки OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

Эта статья показывает, как создать презентацию в Aspose.Slides, добавить текстовое поле на её первый слайд и сохранить результат в файл. Также показано, как создать и сохранить пустую презентацию, а также как открыть существующую презентацию в поддерживаемом формате и сохранить её в другом формате. Краткий FAQ в конце охватывает часто задаваемые вопросы о форматах, шаблонах, размере слайдов, единицах измерения, использовании памяти, многопоточности, лицензировании, цифровых подписьах и поддержке VBA.

Перед началом добавьте Aspose.Slides в ваш проект через NuGet. См. [Установка](/slides/ru/net/installation/) для пакета, используемого в Windows, Linux и macOS.

## **Создание презентации PowerPoint**

Чтобы создать презентацию и разместить текстовое поле на её первом слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) . Новый презентация уже содержит один пустой слайд.
1. Получите этот слайд из коллекции [Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) по индексу 0.
1. Добавьте прямоугольник с помощью метода [AddAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addautoshape/) , и установите его [text](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/text/) .
1. Сохраните презентацию в файл PPTX с помощью метода [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) .

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Левый верхний угол прямоугольника находится на расстоянии 50 пунктов от левой границы и 50 пунктов от верхней границы слайда, а ширина прямоугольника составляет 400 пунктов, высота — 100 пунктов. Сохранённый файл содержит один слайд с этим прямоугольником и его текстом. Без лицензии Aspose.Slides также добавляет на каждый сохраняемый слайд оценочный водяной знак; см. [Лицензирование](/slides/ru/net/licensing/) .

## **Создание и сохранение презентации**

<a name="csharp-create-save-presentation"></a>

Чтобы создать пустую презентацию и сохранить её, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) , и сохраните её в любой формат изenumeration [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) . В результате получится презентация с одним пустым слайдом.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Открытие и сохранение презентации**

<a name="csharp-open-save-presentation"></a>

Чтобы конвертировать презентацию из одного формата в другой, откройте её, передав путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/) , затем сохраните в целевом формате. Aspose.Slides определяет входной формат (например, PPT, PPTX или ODP) по самому файлу.

Пример ниже ожидает наличие презентации OpenDocument с именем *Sample.odp* в рабочем каталоге и сохраняет её как PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### В какие форматы можно сохранить новую презентацию?

Вы можете сохранять в форматы [PPTX, PPT и ODP](/slides/ru/net/save-presentation/) , а также экспортировать в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/) , [XPS](/slides/ru/net/convert-powerpoint-to-xps/) , [HTML](/slides/ru/net/convert-powerpoint-to-html/) , [SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/net/convert-powerpoint-to-png/) , и др.

### Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/net/supported-file-formats/) .

### Как управлять размером слайда/соотношением сторон при создании презентации?

Установите [размер слайда](/slides/ru/net/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите способ масштабирования содержимого.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм равен 72 единицам.

### Как работать с очень большими презентациями (с большим количеством медиафайлов), чтобы снизить расход памяти?

Используйте [стратегии управления BLOB](/slides/ru/net/manage-blob/) , ограничьте хранение в памяти, используя временные файлы, и предпочтительно применяйте файловые процессы вместо полностью потоковых операций в памяти.

### Могу ли я создавать/сохранять презентации параллельно?

Вы не можете работать с одним и тем же экземпляром [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/net/multithreading/) . Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

### Как удалить демонстрационный водяной знак и ограничения?

[Примените лицензию](/slides/ru/net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройку лицензии следует синхронизировать, если используется несколько потоков.

### Могу ли я цифрово подписать создаваемый PPTX?

Да. [Цифровые подписи](/slides/ru/net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в создаваемых презентациях?

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.