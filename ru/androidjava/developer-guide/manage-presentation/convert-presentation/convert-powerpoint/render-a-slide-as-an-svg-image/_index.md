---
title: Отображение слайда как SVG-изображения
type: docs
weight: 50
url: /ru/androidjava/render-a-slide-as-an-svg-image/
---

SVG — аббревиатура от Scalable Vector Graphics — это стандартный тип или формат графики, используемый для отображения двумерных изображений. SVG хранит изображения векторно в XML с деталями, которые определяют их поведение или внешний вид.

SVG является одним из немногих форматов для изображений, которые соответствуют очень высоким стандартам в таких аспектах, как: масштабируемость, интерактивность, производительность, доступность, программируемость и другим. По этим причинам он широко используется в веб-разработке.

Вам может понадобиться использовать SVG-файлы, когда необходимо

- **напечатать вашу презентацию в *очень большом формате*.** SVG-изображения можно масштабировать до любого разрешения или уровня. Вы можете изменять размер SVG-изображений столько раз, сколько необходимо, без потери качества.
- **использовать графики и диаграммы из ваших слайдов в *разных носителях или платформах*.** Большинство ридеров могут интерпретировать SVG-файлы.
- **использовать *наименьшие возможные размеры изображений*.** SVG-файлы, как правило, меньше своих аналогов с высоким разрешением в других форматах, особенно тех форматов, которые основаны на растровой графике (JPEG или PNG).

Aspose.Slides для Android через Java позволяет экспортировать слайды ваших презентаций в SVG-изображения. Пройдите через следующие шаги, чтобы сгенерировать SVG-изображения:

1. Создайте экземпляр класса Presentation.
2. Переберите все слайды в презентации.
3. Запишите каждый слайд в отдельный SVG-файл через FileOutputStream.

{{% alert color="primary" %}} 

Вам может быть интересно попробовать наше [бесплатное веб-приложение](https://products.aspose.app/slides/conversion/ppt-to-svg), в котором мы реализовали функцию конвертации PPT в SVG из Aspose.Slides для Android через Java.

{{% /alert %}} 

Этот образец кода на Java показывает, как конвертировать PPT в SVG с использованием Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```