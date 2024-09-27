---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/androidjava/presentation-viewer/
keywords: "Просмотрщик PowerPoint PPT"
description: "Просмотрщик PowerPoint PPT на Java"
---

{{% alert color="primary" %}} 

Aspose.Slides для Android через Java используется для создания файлов презентаций с слайдами. Эти слайды можно просматривать, открывая презентации с помощью Microsoft PowerPoint. Но иногда разработчикам также может понадобиться просматривать слайды в виде изображений в их любимом просмотрщике изображений или создать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides для Android через Java позволяет экспортировать отдельный слайд в изображение. Эта статья описывает, как это сделать.

{{% /alert %}} 

## **Живой пример**
Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что вы можете реализовать с помощью API Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Генерация изображения SVG из слайда**
Чтобы сгенерировать изображение SVG из любого нужного слайда с помощью Aspose.Slides для Android через Java, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на нужный слайд, используя его ID или индекс.
- Получите изображение SVG в памяти.
- Сохраните поток памяти в файл.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Создайте объект потока памяти
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Генерируйте изображение SVG слайда и сохраняйте в поток памяти
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Генерация SVG с пользовательскими ID фигур**
Aspose.Slides для Android через Java может быть использован для генерации [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским ID фигур. Для этого используйте свойство ID из [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgShape), которое представляет собой пользовательский ID фигур в сгенерированном SVG. CustomSvgShapeFormattingController может быть использован для установки ID фигуры.

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

## **Создание эскиза изображения слайда**
Aspose.Slides для Android через Java помогает вам генерировать эскизы изображений слайдов. Чтобы сгенерировать эскиз любого нужного слайда с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на любой нужный слайд, используя его ID или индекс.
1. Получите изображение эскиза указанного слайда на заданном масштабе.
1. Сохраните изображение эскиза в любом нужном формате.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Создайте изображение полного масштаба
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

## **Создание эскиза с пользовательскими размерами**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на любой нужный слайд, используя его ID или индекс.
1. Получите изображение эскиза указанного слайда на заданном масштабе.
1. Сохраните изображение эскиза в любом нужном формате.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Пользовательские размеры
    int desiredX = 1200;
    int desiredY = 800;

    // Получите масштабированное значение X и Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Создайте изображение полного масштаба
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

## **Создание эскиза из слайда в режиме заметок**
Чтобы сгенерировать эскиз любого нужного слайда в режиме заметок, используя Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на любой нужный слайд, используя его ID или индекс.
1. Получите изображение эскиза указанного слайда на заданном масштабе в режиме заметок.
1. Сохраните изображение эскиза в любом нужном формате.

Приведенный ниже фрагмент кода создает эскиз первого слайда презентации в режиме заметок.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Получите доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Пользовательские размеры
    int desiredX = 1200;
    int desiredY = 800;

    // Получите масштабированное значение X и Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Создайте изображение полного масштаба
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