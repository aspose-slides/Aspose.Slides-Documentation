---
title: Получить полный фон слайда презентации в виде изображения
type: docs
weight: 95
url: /ru/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- слайд
- фон
- фон слайда
- фон в изображение
- PowerPoint
- PPT
- PPTX
- презентация PowerPoint
- Node
- JavaScript
- Aspose.Slides for Node.js via Java
---

## **Получить полный фон слайда**

В презентациях PowerPoint фон слайда может состоять из множества элементов. Помимо изображения, установленного в качестве [фон слайда](/slides/ru/nodejs-java/presentation-background/), окончательный фон может зависеть от темы презентации, цветовой схемы и фигур, размещенных на мастер‑слайде и слайде макета.

Aspose.Slides for Node.js via Java не предоставляет простой метод для извлечения полного фона слайда презентации в виде изображения, но вы можете выполнить перечисленные ниже шаги:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда во временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает полный фон слайда презентации в виде изображения.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**Будут ли сложные градиенты, текстуры или заливки изображениями из мастер‑слайда сохранены в результирующем фоновом изображении?**

Да. Aspose.Slides отрисовывает градиентные, картинные и текстурные заливки, определённые на слайде, макете или мастере. Если необходимо изолировать внешний вид от унаследованных мастеров, [установите собственный фон](/slides/ru/nodejs-java/presentation-background/) на текущий слайд перед экспортом.

**Могу ли я добавить водяной знак к результирующему фоновому изображению перед сохранением?**

Да. Вы можете [добавить водяной знак](/slides/ru/nodejs-java/watermark/) в виде фигуры или изображения на рабочую [копию слайда](/slides/ru/nodejs-java/clone-slides/) (размещённую позади другого контента), а затем выполнить экспорт. Это позволяет создать фоновое изображение с встроенным водяным знаком.

**Могу ли я получить фон для конкретного макета или мастера без привязки к существующему слайду?**

Да. Получите доступ к нужному мастеру или макету, примените его к [временному слайду](/slides/ru/nodejs-java/clone-slides/) требуемого размера и экспортируйте этот слайд, чтобы получить фон, полученный из этого макета или мастера.

**Есть ли ограничения лицензирования, влияющие на экспорт изображений?**

Функции рендеринга полностью доступны при наличии [действующей лицензии](/slides/ru/nodejs-java/licensing/). В режиме оценки вывод может включать ограничения, такие как водяной знак. Активируйте лицензию один раз на процесс перед запуском пакетного экспорта.