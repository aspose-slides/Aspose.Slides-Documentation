---
title: Получить полный фон слайда из презентации в виде изображения
linktitle: Полный фон слайда
type: docs
weight: 95
url: /ru/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- фон слайда
- конечный фон
- извлечь фон
- полный фон
- фон в изображении
- фон PPT
- фон PPTX
- фон ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Извлеките полные фоновые изображения слайдов из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java, упрощая визуальные рабочие процессы."
---

## **Получить весь фон слайда**

В презентациях PowerPoint фон слайда может состоять из множества элементов. Помимо изображения, установленного как [фон слайда](/slides/ru/androidjava/presentation-background/), конечный фон может зависеть от темы презентации, цветовой схемы и фигур, размещённых на главном слайде и слайде макета.

Aspose.Slides for Android via Java не предоставляет простой метод для извлечения полного фона слайда презентации в виде изображения, но вы можете выполнить следующие шаги:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда во временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает полный фон слайда презентации в виде изображения.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **Часто задаваемые вопросы**

**Сохранятся ли сложные градиенты, текстуры или заливки изображениями из главного слайда в полученном изображении фона?**

Да. Aspose.Slides отображает градиентные, рисунковые и текстурные заливки, определённые на слайде, макете или главном слайде. Если необходимо изолировать внешний вид от унаследованных мастеров, [установите собственный фон](/slides/ru/androidjava/presentation-background/) на текущем слайде перед экспортом.

**Могу ли я добавить водяной знак к полученному изображению фона перед сохранением?**

Да. Вы можете [добавить водяной знак](/slides/ru/androidjava/watermark/) в виде фигуры или изображения на рабочую [копию слайда](/slides/ru/androidjava/clone-slides/) (размещённую позади другого содержимого), а затем выполнить экспорт. Это позволяет создать изображение фона с впечённым водяным знаком.

**Можно ли получить фон для конкретного макета или главного слайда без привязки к существующему слайду?**

Да. Получите доступ к нужному мастеру или макету, примените его к [временному слайду](/slides/ru/androidjava/clone-slides/) нужного размера и экспортируйте этот слайд, чтобы получить фон, полученный из этого макета или главного слайда.

**Существует ли ограничение лицензии, влияющее на экспорт изображений?**

Функции рендеринга полностью доступны при наличии [действительной лицензии](/slides/ru/androidjava/licensing/). В режиме оценки вывод может содержать ограничения, например водяной знак. Активируйте лицензию один раз на процесс перед запуском пакетного экспорта.