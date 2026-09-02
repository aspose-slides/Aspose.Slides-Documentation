---
title: Применение или изменение макетов слайдов в .NET
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/net/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- слайд заголовка
- заголовок и содержание
- заголовок раздела
- два содержания
- сравнение
- только заголовок
- пустой макет
- содержание с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- C#
- .NET
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для .NET, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет положение и форматирование элементов‑заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержание.

- **Title Slide**: Содержит элементы‑заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит элемент‑заполнитель заголовка и универсальный элемент‑заполнитель содержания.
- **Blank**: Не содержит элементов‑заполнителей содержания и полезен, когда все объекты будут размещаться вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. [главный слайд](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/) определяет тему, общие параметры форматирования, фоны и общие объекты.
2. [layout slide](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/) принадлежит главному слайду и определяет конкретное расположение элементов‑заполнителей.
3. [normal slide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/) использует один макет и сохраняет введённое для этого слайда содержимое.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от главного слайда. Значение, установленное непосредственно для обычного слайда, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, относится к обычному слайду.

Добавьте необходимые элементы‑заполнители в макет перед созданием из него слайдов. Добавление позже другого заполнителя в макет не приводит к автоматическому добавлению соответствующей формы‑заполнителя в уже существующие обычные слайды.

Эта связь имеет две важные последствия:

- Изменение унаследованного форматирования или существующей геометрии заполнителей в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Главный слайд](/slides/ru/net/slide-master/).

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов могут редактироваться пользователем и локализоваться, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется **Title and Content** в первом главном слайде. Если этот макет недоступен, он намеренно заменяется на **Blank**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Выбранный макет затем применяется к первому обычному слайду через свойство [ISlide.LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/layoutslide/).

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

Изменение макета слайда не удаляет обычные фигуры, добавленные непосредственно на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт новый. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/masterlayoutslidecollection/add/) у коллекции макетов целевого главного слайда.

В следующем примере всегда добавляется новый **Title and Content** с именем `Report Title and Content`, после чего добавляется обычный слайд, основанный на нём. Имена макетов должны быть уникальными в пределах коллекции.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в другой повторно используемой структуре. Если подходящий макет уже существует, выберите и используйте его повторно, а не создавайте дубликат.

## **Добавление заполнителей в макет слайда**

Свойство [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/placeholdermanager/) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint | Метод ILayoutPlaceholderManager |
| ----------------------------------- | ---------------------------------- |
| ![Содержание](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Содержание (вертикальное)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Текст](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Текст (вертикальный)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Изображение](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Диаграмма](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Таблица](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Медиа](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Онлайн‑изображение](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

В следующем примере проверяется, существует ли макет **Blank**, добавляются четыре заполнителя к нему, а затем создаётся обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

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

![Заполнители на макете слайда](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может повлиять на зависимые слайды. Новый добавленный заполнитель макета не заполняется в уже существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления макетов, на которые не ссылаются обычные слайды. Метод оставляет нетронутыми макеты, которые всё ещё используются.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Для удаления конкретного макета сначала используйте его свойство [HasDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/hasdependingslides/) или метод [GetDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/getdependingslides/). Переназначьте все зависимые слайды перед вызовом [ILayoutSlide.Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/remove/). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте свойство [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/headerfootermanager/) для управления этими заполнителями одного макета. Это полезно, когда, например, макеты содержимого должны отображать нижний колонтитул, а макеты заголовков — нет.

В следующем примере макет выбирается безопасно и его элементы нижнего колонтитула делают видимыми:

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

## **Управление видимостью нижнего колонтитула у главного слайда и его дочерних макетов**

Чтобы применить единые настройки нижнего колонтитула во всей иерархии главного слайда, используйте свойство [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/headerfootermanager/). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslideheaderfootermanager/) работают с главным слайдом, его зависимыми макетами слайдов и обычными слайдами; они не нацелены только на один обычный слайд.

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

**В чём разница между главным слайдом и макетом слайда?**

Главный слайд определяет тему презентации и общие параметры форматирования. Макет слайда принадлежит главному слайду и задаёт одно повторно используемое расположение заполнителей. Обычные слайды используют эти макеты и сохраняют специфическое для слайда содержание.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/globallayoutslidecollection/addclone/). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они локально не переопределяют затронутое форматирование или объекты. Поэтому геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [GetDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/getdependingslides/) для определения затронутых слайдов перед редактированием макета.

**Что происходит, если я удаляю макет, который всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления только неиспользуемых макетов.