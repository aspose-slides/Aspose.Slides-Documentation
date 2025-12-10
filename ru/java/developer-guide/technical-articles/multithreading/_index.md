---
title: Многопоточность в Aspose.Slides для Java
linktitle: Многопоточность
type: docs
weight: 310
url: /ru/java/multithreading/
keywords:
- многопоточность
- несколько потоков
- параллельная работа
- преобразование слайдов
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Многопоточность Aspose.Slides для Java ускоряет обработку PowerPoint и OpenDocument. Узнайте лучшие практики эффективных рабочих процессов с презентациями."
---

## **Введение**

Хотя параллельная работа с презентациями возможна (кроме разбора/загрузки/клонирования) и в большинстве случаев всё идёт гладко, существует небольшая вероятность получения некорректных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) в многопоточной среде, поскольку это может привести к непредсказуемым ошибкам или сбоям, которые трудно обнаружить. 

Загрузка, сохранение и/или клонирование экземпляра класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) в нескольких потоках **не** безопасно. Такие операции **не** поддерживаются. Если необходимо выполнить такие задачи, следует параллелить их, используя несколько однопоточных процессов — каждый из этих процессов должен использовать свой собственный экземпляр презентации. 

## **Параллельное преобразование слайдов презентации в изображения**

Допустим, мы хотим параллельно преобразовать все слайды презентации PowerPoint в PNG‑изображения. Поскольку использование одного экземпляра `Presentation` в нескольких потоках небезопасно, мы разделяем слайды презентации на отдельные презентации и преобразуем их в изображения параллельно, используя каждую презентацию в отдельном потоке. Ниже приведён пример кода, показывающий, как это сделать.
```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Извлечь слайд i в отдельную презентацию.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Преобразовать слайд в изображение в отдельной задаче.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Ожидать завершения всех задач.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **FAQ**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз на процесс/домён приложения до запуска потоков. Если [настройку лицензии](/slides/ru/java/licensing/) может вызываться одновременно (например, при ленивой инициализации), синхронизируйте этот вызов, потому что метод настройки лицензии сам по себе не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры для каждого потока или заранее создайте отдельные презентации/контейнеры слайдов для каждого потока. Такой подход соответствует общей рекомендации не делиться одним экземпляром презентации между потоками.

**Безопасно ли параллельно экспортировать в разные форматы (PDF, HTML, изображения), если у каждого потока свой экземпляр `Presentation`?**

Да. При наличии независимых экземпляров и отдельных путей вывода такие задачи обычно корректно параллелятся; избегайте общих объектов презентаций и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, подстановки) в многопоточной среде?**

Инициализируйте все глобальные [настройки шрифтов](/slides/ru/java/powerpoint-fonts/) перед запуском потоков и не меняйте их во время параллельной работы. Это устраняет гонки при доступе к общим ресурсам шрифтов.