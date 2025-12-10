---
title: Получить полный фон слайда из презентации в виде изображения
linktitle: Полный фон слайда
type: docs
weight: 95
url: /ru/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- фон слайда
- окончательный фон
- извлечение фона
- полный фон
- фон в изображение
- фон PPT
- фон PPTX
- фон ODP
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Извлекайте полные фоны слайдов в виде изображений из презентаций PowerPower и OpenDocument с помощью Aspose.Slides for Java, упрощая визуальные рабочие процессы."
---

## **Получить полный фон слайда**

В презентациях PowerPoint фон слайда может состоять из множества элементов. Помимо изображения, установленного как [фон слайда](/slides/ru/java/presentation-background/), окончательный фон может зависеть от темы презентации, цветовой схемы и фигур, размещённых на главном слайде и слайде макета.

Aspose.Slides для Java не предоставляет простой метод для извлечения полного фона слайда презентации в виде изображения, но вы можете выполнить следующие шаги:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда во временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры из клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает полный фон слайда презентации в виде изображения.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **Часто задаваемые вопросы**

**Будут ли сложные градиенты, текстуры или заливки изображениями из главного слайда сохранены в полученном фоновом изображении?**

Да. Aspose.Slides отображает градиентные, картинные и текстурные заливки, определённые на слайде, макете или главном слайде. Если нужно отделить внешний вид от унаследованных мастеров, [установите собственный фон](/slides/ru/java/presentation-background/) на текущем слайде перед экспортом.

**Можно ли добавить водяной знак к полученному фоновому изображению перед его сохранением?**

Да. Вы можете [добавить водяной знак](/slides/ru/java/watermark/) в виде фигуры или изображения на рабочую [копию слайда](/slides/ru/java/clone-slides/) (размещённую позади другого содержимого), а затем выполнить экспорт. Это позволяет создать фоновое изображение с встроенным водяным знаком.

**Можно ли получить фон для конкретного макета или главного слайда без привязки к существующему слайду?**

Да. Получите доступ к нужному мастеру или макету, примените его к [временному слайду](/slides/ru/java/clone-slides/) с требуемым размером и экспортируйте этот слайд, чтобы получить фон, полученный из этого макета или мастера.

**Есть ли ограничения лицензирования, влияющие на экспорт изображений?**

Возможности рендеринга полностью доступны при наличии [действующей лицензии](/slides/ru/java/licensing/). В режиме оценки вывод может включать ограничения, например водяной знак. Активируйте лицензию один раз на процесс перед запуском пакетного экспорта.