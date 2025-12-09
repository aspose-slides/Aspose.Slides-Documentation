---
title: Многопоточность в Aspose.Slides
type: docs
weight: 310
url: /ru/nodejs-java/multithreading/
keywords:
- PowerPoint
- презентация
- многопоточность
- параллельная работа
- преобразование слайдов
- слайды в изображения
- JavaScript
- Aspose.Slides for Node.js через Java
---

## **Введение**

Хотя параллельная работа с презентациями возможна (кроме парсинга/загрузки/клонирования) и обычно всё проходит гладко, существует небольшая вероятность получить некорректные результаты при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) в многопоточном окружении, поскольку это может привести к непредсказуемым ошибкам или сбоям, которые трудно обнаружить.

Неправильно загружать, сохранять и/или клонировать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) в нескольких потоках. Такие операции **не** поддерживаются. Если необходимо выполнять подобные задачи, следует распараллелить их, используя несколько однопоточных процессов — каждый из этих процессов должен использовать собственный экземпляр презентации.

## **Параллельное преобразование слайдов презентации в изображения**

Допустим, мы хотим параллельно преобразовать все слайды PowerPoint‑презентации в PNG‑изображения. Поскольку использование одного экземпляра `Presentation` в нескольких потоках небезопасно, мы разбиваем слайды презентации на отдельные презентации и конвертируем их в изображения параллельно, используя каждую презентацию в отдельном потоке. Ниже приведён пример кода, демонстрирующий, как это сделать.
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Извлечь слайд i в отдельную презентацию.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Ожидать завершения всех задач.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **FAQ**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз за процесс/домейн приложения до запуска потоков. Если [license setup](/slides/ru/nodejs-java/licensing/) может быть вызван одновременно (например, при ленивой инициализации), синхронизируйте этот вызов, потому что сам метод настройки лицензии не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача “живых” объектов презентации между потоками не рекомендуется: используйте независимые экземпляры в каждом потоке или заранее создайте отдельные презентации/контейнеры слайдов для каждого потока. Такой подход соответствует общему совету не делиться одним экземпляром презентации между потоками.

**Безопасно ли параллелить экспорт в разные форматы (PDF, HTML, изображения), если у каждого потока свой экземпляр `Presentation`?**

Да. При использовании независимых экземпляров и отдельных путей вывода такие задачи обычно корректно параллелятся; избегайте общих объектов презентации и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, замены) в многопоточности?**

Инициализируйте все глобальные настройки шрифтов до запуска потоков и не меняйте их во время параллельной работы. Это устраняет гонки при доступе к общим ресурсам шрифтов.