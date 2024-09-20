---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /java/presentation-viewer/
keywords: "Просмотрщик PowerPoint PPT"
description: "Просмотрщик PowerPoint PPT на Java"
---

{{% alert color="primary" %}} 

Aspose.Slides для Java используется для создания файлов презентаций, состоящих из слайдов. Эти слайды можно просмотреть, открыв презентации с помощью Microsoft PowerPoint. Но иногда разработчикам также может понадобиться просматривать слайды в виде изображений в своем любимом просмотрщике изображений или создать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides для Java позволяет экспортировать отдельный слайд в изображение. Эта статья описывает, как это сделать.

{{% /alert %}} 

## **Живой пример**
Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что вы можете реализовать с помощью API Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Генерация SVG-изображения из слайда**
Чтобы сгенерировать SVG-изображение из любого желаемого слайда с помощью Aspose.Slides для Java, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на желаемый слайд, используя его ID или индекс.
- Получите SVG-изображение в потоке памяти.
- Сохраните поток памяти в файл.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Создайте объект потока памяти
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Сгенерируйте SVG-изображение слайда и сохраните его в поток памяти
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Генерация SVG с пользовательскими ID форм**
Aspose.Slides для Java можно использовать для генерации [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским ID формы. Для этого используйте свойство ID из [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape), которое представляет собой пользовательский ID форм в сгенерированном SVG. CustomSvgShapeFormattingController можно использовать для установки ID формы.

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Создание миниатюры слайда**
Aspose.Slides для Java помогает вам генерировать миниатюры изображений слайдов. Чтобы сгенерировать миниатюру любого желаемого слайда с помощью Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите миниатюру изображения ссылочного слайда в заданном масштабе.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Создайте изображение в полную шкалу
    IImage slideImage = sld.getImage(1f, 1f);

    // Сохраните изображение на диск в формате JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Создание миниатюры с заданными пользователем размерами**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите миниатюру изображения ссылочного слайда в заданном масштабе.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Пользовательский размер
    int desiredX = 1200;
    int desiredY = 800;

    // Получение масштабированных значений X и Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Создайте изображение в полную шкалу
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // Сохраните изображение на диск в формате JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Создание миниатюры слайда в режиме заметок**
Чтобы сгенерировать миниатюру любого желаемого слайда в режиме заметок с помощью Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите миниатюру изображения ссылочного слайда в заданном масштабе в режиме заметок.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

Приведенный ниже фрагмент кода генерирует миниатюру первого слайда презентации в режиме заметок.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Пользовательский размер
    int desiredX = 1200;
    int desiredY = 800;

    // Получение масштабированных значений X и Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Создайте изображение в полную шкалу
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // Сохраните изображение на диск в формате JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```