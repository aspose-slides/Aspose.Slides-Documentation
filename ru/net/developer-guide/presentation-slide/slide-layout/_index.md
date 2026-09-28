---
title: Применение или изменение макетов слайдов в .NET
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/net/slide-layout/
keywords:
- макет слайда
- макет контента
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и контент
- заголовок раздела
- два блока контента
- сравнение
- только заголовок
- пустой макет
- контент с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- C#
- .NET
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для .NET, добавляйте заполнители, удаляйте неиспользуемые макеты и контролируйте видимость нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета придаёт слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержимое.

Наиболее часто используемые макеты включают:

- **Title Slide**: Содержит заполнитель заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель контента.
- **Blank**: Не содержит заполнителей контента и полезен, когда все фигуры позиционируются вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. [master slide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/) определяет тему, общие форматы, фон и общие объекты.
2. [layout slide](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/) принадлежит мастеру и определяет конкретное расположение заполнителей.
3. [normal slide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/) использует один макет и хранит содержимое, введённое для этого слайда.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследуется от своего мастера. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. Когда создаётся обычный слайд, его фигуры‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания из него слайдов. Добавление другого заполнителя в макет позже не добавляет автоматически соответствующую фигуру‑заполнитель в уже существующие обычные слайды.

Эта связь имеет два важных последствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, зависящий от него. Перед редактированием макета, уже используемого, проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Slide Master](/slides/ru/net/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные фигуры мастера на одном слайде или через общий макет, см. [Control the Visibility of Master Graphics](/slides/ru/net/slide-master/). В примере сравниваются два слайда, использующие один и тот же мастер.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируются пользователем и могут быть локализованы, поэтому выбор на основе имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется **Title and Content** на первом мастере. Если такой макет недоступен, он преднамеренно переключается на **Blank**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Выбранный макет затем применяется к первому обычному слайду через свойство [ISlide.LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Изменение макета слайда не удаляет обычные фигуры, добавленные напрямую к слайду. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макетного слайда**

Выбор и создание — отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/masterlayoutslidecollection/add/) у коллекции макетов целевого мастера.

В следующем примере всегда добавляется новый макет **Title and Content** с именем `Report Title and Content`, затем добавляется обычный слайд на его основе. Имена макетов должны быть уникальны в пределах коллекции.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в новой переиспользуемой структуре. Если подходящий макет уже существует, выбирайте и переиспользуйте его вместо создания дубликата.

## **Добавление заполнителей в макетный слайд**

Свойство [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/placeholdermanager/) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutplaceholdermanager/) для добавления фигур‑заполнителей в макет.

| Заполнитель PowerPoint               | `ILayoutPlaceholderManager` Method |
| ------------------------------------ | ---------------------------------- |
| ![Контент](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Контент (вертикальный)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Текст](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Текст (вертикальный)](textV.png)   | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Изображение](picture.png)          | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Диаграмма](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Таблица](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Медиа](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Онлайн‑изображение](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

В следующем примере проверяется, существует ли макет **Blank**, добавляются четыре заполнителя, а затем создаётся обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие фигуры‑заполнители на этом слайде.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Результат:

![Заполнители на макетном слайде](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Новый добавленный заполнитель макета не заполняется в существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетных слайдов**

Используйте метод [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления макетов, на которые не ссылается ни один обычный слайд. Метод оставляет неизменными макеты, которые всё ещё используются.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Чтобы удалить конкретный макет, сначала используйте его свойство [HasDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/hasdependingslides/) или метод [GetDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/getdependingslides/). Переназначьте все зависимые слайды перед вызовом [ILayoutSlide.Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/remove/). Попытка удалить использующийся макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макетном слайде**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты/времени. Используйте свойство [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/headerfootermanager/) для управления этими заполнителями для одного макета. Это полезно, например, когда макеты контента должны показывать нижние колонтитулы, а макеты заголовков — нет.

В следующем примере макет безопасно выбирается и его элементы нижнего колонтитула делаются видимыми:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Управление видимостью нижнего колонтитула на мастере и его дочерних макетах**

Чтобы применить единые настройки нижнего колонтитула по всей иерархии мастера, используйте свойство [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/headerfootermanager/). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslideheaderfootermanager/) работают с мастером и его зависимыми макетными и обычными слайдами; они не ориентированы только на один обычный слайд.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Какова разница между мастер‑слайдом и макетным слайдом?**

Мастер‑слайд определяет тему презентации и общие форматы. Макетный слайд принадлежит мастеру и определяет одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят контент, специфичный для конкретного слайда.

**Можно ли скопировать макетный слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/globallayoutslidecollection/addclone/). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю уже используемый макет?**

Зависимые слайды наследуют изменения макета, если только они не переопределяют затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [GetDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/getdependingslides/) для определения затронутых слайдов перед редактированием макета.

**Что происходит, если удалить макет, который всё ещё используется?**

Aspose.Slides выдает [PptxEditException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления только неиспользуемых макетов.