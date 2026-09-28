---
title: Применение или изменение макетов слайдов на Android
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/androidjava/slide-layout/
keywords:
- макет слайда
- макет содержания
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
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
- Android
- Java
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для Android через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержимое.

Наиболее распространённые макеты включают:

- **Титульный слайд**: Содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержание**: Содержит заполнитель заголовка и универсальный заполнитель содержания.
- **Пустой**: Не содержит заполнителей содержания и полезен, когда каждый объект будет размещён вручную.

## **Понимание наследования макета**

Презентация имеет три взаимосвязанных уровня:

1. [главный слайд](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/) определяет тему, общие форматы, фон и общие объекты.
2. [макетный слайд](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/) принадлежит главному слайду и определяет конкретное расположение заполнителей.
3. [обычный слайд](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/) использует один макет и сохраняет введённое для этого слайда содержимое.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, при этом содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания из него слайдов. Добавление другого заполнителя в макет позже не приводит к автоматическому добавлению соответствующей формы‑заполнителя в уже существующие обычные слайды.

Эти отношения имеют две важные последствия:

- Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Главный слайд](/slides/ru/androidjava/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные элементы главного слайда на отдельном слайде или через общий макет, см. [Управление видимостью графики главного слайда](/slides/ru/androidjava/slide-master/). Пример сравнивает два слайда, использующих один и тот же главный слайд.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определением макетов PowerPoint. Имена макетов могут редактироваться пользователем и локализоваться, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется макет **Заголовок и содержание** на первом главном слайде. Если такой макет недоступен, он намеренно переходит к **Пустому**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду через метод [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Изменение макета слайда не удаляет обычные фигуры, добавленные непосредственно на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно разными макетами.

## **Добавление макетного слайда**

Выбор и создание — отдельные операции. В предыдущем примере выбирается существующий макет; он не создаётся. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) у коллекции макетов целевого главного слайда.

В следующем примере всегда добавляется новый макет **Заголовок и содержание** с именем `Report Title and Content`, после чего добавляется обычный слайд, основанный на нём. Имена макетов должны быть уникальными в пределах коллекции.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в другой переиспользуемой структуре. Если подходящий макет уже существует, выберите и используйте его повторно, вместо создания дубликата.

## **Добавление заполнителей в макетный слайд**

Метод [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), позволяющий добавлять формы‑заполнители в макет.

| Заполнитель PowerPoint              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Содержание](content.png)          | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Содержание (вертикальное)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Текст](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Текст (вертикальный)](textV.png)  | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Изображение](picture.png)         | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Диаграмма](chart.png)             | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Таблица](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Медиа](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Онлайн‑изображение](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

В следующем примере проверяется наличие макета **Пустой**, добавляются четыре заполнителя, после чего создаётся обычный слайд, использующий изменённый макет. Порядок намеренно такой: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Заполнители на макетном слайде](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может повлиять на зависимые слайды. Новый заполнитель макета не заполняет автоматически существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетных слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) для удаления макетов, на которые не ссылаются обычные слайды. Метод оставляет нетронутыми макеты, которые всё ещё используются.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить конкретный макет, сначала используйте его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) или [getDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Переназначьте все зависимые слайды перед вызовом [ILayoutSlide.remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#remove--). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макетном слайде**

У макета есть свои заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) для управления этими заполнителями для одного макета. Это полезно, например, когда в макетах содержания должны отображаться нижние колонтитулы, а в макетах заголовков — нет.

В следующем примере безопасно выбирается макет и делаются видимыми его элементы нижнего колонтитула:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление видимостью нижнего колонтитула в главном слайде и его дочерних макетах**

Чтобы применить единые настройки нижнего колонтитула по всей иерархии главного слайда, используйте метод [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) работают на главном слайде и его зависимых макетных и обычных слайдах; они не ориентированы только на один обычный слайд.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между главным слайдом и макетным слайдом?**

Главный слайд определяет тему презентации и общие форматы. Макетный слайд принадлежит главному слайду и задаёт одно переиспользуемое расположение заполнителей. Обычные слайды используют эти макеты и сохраняют содержание, специфичное для конкретного слайда.

**Можно ли скопировать макетный слайд из одной презентации в другую?**

Да. Добавьте копию в коллекцию назначения с помощью метода [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит при изменении уже используемого макета?**

Зависимые слайды наследуют изменения макета, если только они не переопределяют затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) , чтобы определить затронутые слайды перед редактированием макета.

**Что происходит, если удалить макет, который всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), чтобы удалить только непосланные макеты.