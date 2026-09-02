---
title: Применение или изменение макетов слайдов на Android
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/androidjava/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержание
- заголовок раздела
- два блока содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
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

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета дает слайдам единообразную структуру, позволяя каждому слайду содержать свой собственный контент.

Самыми распространёнными макетами являются:

- **Титульный слайд**: Содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержание**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Пустой**: Не содержит заполнителей содержимого и полезен, когда все объекты будут позиционироваться вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. [главный слайд](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/) определяет тему, общие форматы, фон и общие объекты.
1. [макет слайда](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/) принадлежит главному слайду и определяет конкретное расположение заполнителей.
1. [обычный слайд](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/) использует один макет и сохраняет введённое для него содержание.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует от главного слайда. Значение, установленное напрямую на обычном слайде, переопределяет унаследованное значение на этом уровне. Когда обычный слайд создаётся, его формы‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет перед созданием из него слайдов. Добавление другого заполнителя в макет позже не добавляет автоматически соответствующую форму‑заполнитель в существующие обычные слайды.

Эти взаимоотношения имеют два важных следствия:

- Изменение унаследованного форматирования или существующей геометрии заполнителя в макете может обновить каждый слайд, который от него зависит. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Главный слайд](/slides/ru/androidjava/slide-master/).

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируемы пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Title and Content** на первом главном слайде. Если этот макет недоступен, он преднамеренно переходит к **Blank**. Вторая проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду через метод [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Изменение макета слайда не удаляет обычные фигуры, добавленные непосредственно на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) в коллекции макетов целевого главного слайда.

Следующий пример всегда добавляет новый макет **Title and Content** с именем `Report Title and Content`, а затем добавляет обычный слайд, основанный на нём. Имена макетов должны быть уникальными в коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно нуждается в ещё одной переиспользуемой структуре. Если подходящий макет уже существует, выберите и повторно используйте его вместо создания дубликата.

## **Добавление заполнителей в макет слайда**

Метод [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) для добавления фигур‑заполнителей в макет.

| Заполнитель PowerPoint | Метод `ILayoutPlaceholderManager` |
| ---------------------- | --------------------------------- |
| ![Содержание](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Содержание (вертикальное)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Текст](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Текст (вертикальный)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Изображение](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Диаграмма](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Таблица](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Медиа](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Онлайн‑изображение](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Следующий пример проверяет, что макет **Blank** существует, добавляет к нему четыре заполнителя и затем создаёт обычный слайд, использующий модифицированный макет. Порядок намеренно такой: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие фигуры‑заполнители на этом слайде.

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

![Заполнители на макете слайда](add_placeholders.png)

{{% alert color="warning" title="Предупреждение" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Ново‑добавленный заполнитель макета не подтягивается в существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) для удаления макетов, которые не используются ни одним обычным слайдом. Метод оставляет нетронутыми макеты, которые всё ещё используются.

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

Чтобы удалить конкретный макет, сначала воспользуйтесь его методом [hasDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) или [getDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Переназначьте любые зависимые слайды перед вызовом [ILayoutSlide.remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#remove--). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) для управления этими заполнителями одного макета. Это полезно, когда, например, макеты с содержимым должны отображать нижний колонтитул, а макеты заголовков — нет.

Следующий пример безопасно выбирает макет и делает его элементы нижнего колонтитула видимыми:

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

Чтобы применить согласованные настройки нижнего колонтитула во всей иерархии главного слайда, используйте метод [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) работают на главном слайде и его зависимых макетных и обычных слайдах; они не ориентированы только на один обычный слайд.

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

**Какова разница между главным слайдом и макетом слайда?**

Главный слайд определяет тему презентации и общие форматирования. Макет слайда принадлежит главному слайду и определяет одну переиспользуемую расстановку заполнителей. Обычные слайды используют эти макеты и хранят контент, специфичный для конкретного слайда.

**Могу ли я скопировать макет слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, если я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) для определения затронутых слайдов перед редактированием макета.

**Что происходит, если я удаляю макет, который всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) для удаления только несовпадающих макетов.