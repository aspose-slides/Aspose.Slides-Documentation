---
title: Рамка для изображения
type: docs
weight: 10
url: /ru/java/picture-frame/
keywords: "Добавить рамку для изображения, создать рамку для изображения, добавить изображение, создать изображение, извлечь изображение, свойство StretchOff, форматирование рамки для изображения, свойства рамки для изображения, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Добавьте рамку для изображения в презентацию PowerPoint на Java"

---

Рамка для изображения — это фигура, содержащая изображение, — это как картина в рамке.

Вы можете добавить изображение на слайд через рамку для изображения. Таким образом, вы можете отформатировать изображение, отформатировав рамку для изображения.

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt), которые позволяют людям быстро создавать презентации из изображений.

{{% /alert %}}

## **Создание рамки для изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage]() путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения через метод `AddPictureFrame`, предоставленный объектом фигуры, связанным с указанным слайдом.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Запишите измененную презентацию в файл PPTX.

Этот Java-код показывает, как создать рамку для изображения:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку для изображения с высотой и шириной, эквивалентными изображению
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}}

Рамки для изображений позволяют быстро создавать слайды презентации на основе изображений. Когда вы объединяете рамку для изображения с опциями сохранения Aspose.Slides, вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Вы можете ознакомиться с этими страницами: конвертировать [изображение в JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/); конвертировать [PNG в JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/); конвертировать [SVG в PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамки для изображения с относ Scale**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку для изображения.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке для изображения.
6. Запишите измененную презентацию в файл PPTX.

Этот Java-код показывает, как создать рамку для изображения с относительным масштабом:

```java
// Создает экземпляр класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Добавляет рамку для изображения с высотой и шириной, эквивалентными изображению
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Устанавливает относительное масштабирование ширины и высоты
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечение изображения из рамки для изображения**

Вы можете извлекать изображения из объектов [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) и сохранять их в формате PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
                IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
                slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
            } finally {
                     if (slideImage != null) slideImage.dispose();
                 }
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получать прозрачность изображения. Этот Java-код демонстрирует операцию:

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Прозрачность картинки: " + transparencyValue);
    }
}
```

## **Форматирование рамки для изображения**

Aspose.Slides предоставляет множество опций форматирования, которые можно применять к рамке для изображения. Используя эти опции, вы можете изменить рамку для изображения, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) объекта [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection), связанный с указанным слайдом.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Установите цвет линии рамки для изображения.
8. Установите ширину линии рамки для изображения.
9. Поверните рамку для изображения, дав ей положительное или отрицательное значение.
   * Положительное значение поворачивает изображение по часовой стрелке.
   * Отрицательное значение поворачивает изображение против часовой стрелки.
10. Добавьте рамку для изображения (содержащую изображение) на слайд.
11. Запишите измененную презентацию в файл PPTX.

Этот Java-код демонстрирует процесс форматирования рамки для изображения:

```java
// Создает экземпляр класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку для изображения с высотой и шириной, эквивалентными изображению
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Применяет некоторые форматы к PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Совет" color="primary" %}}

Aspose недавно разработала [бесплатный Коллаж Maker](https://products.aspose.app/slides/collage). Если вам когда-либо нужно будет [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG изображения, [создать сетки из фото](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этим сервисом.

{{% /alert %}}

## **Добавить изображение как ссылку**

Чтобы избежать большого размера презентации, вы можете добавлять изображения (или видео) через ссылки вместо того, чтобы вставлять файлы непосредственно в презентации. Этот Java-код показывает, как добавить изображение и видео в заполнителю:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Обрезка изображения**

Этот Java-код показывает, как обрезать существующее изображение на слайде:

```java
Presentation pres = new Presentation();
// Создает новый объект изображения
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет рамку для изображения на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Обрезает изображение (значения в процентах)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Сохраняет результат
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Удалите обрезанные области изображения

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, вы можете использовать метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Этот метод возвращает обрезанное изображение или исходное изображение, если обрезка не требуется.

Этот Java-код демонстрирует операцию:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает PictureFrame с первого слайда
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Удаляет обрезанные области изображения PictureFrame и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Сохраняет результат
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ЗАМЕТКА" color="warning" %}}

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), это может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Этот метод преобразует метафайлы WMF/EMF в растровое изображение PNG при выполнении обрезки.

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла свое соотношение сторон, даже после изменения размеров изображения, вы можете использовать метод [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Блокировка соотношения сторон*.

Этот Java-код показывает, как заблокировать соотношение сторон фигуры:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // Устанавливает фигуру, чтобы сохранить соотношение сторон при изменении размера
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ЗАМЕТКА" color="warning" %}}

Этот параметр *Блокировка соотношения сторон* сохраняет только соотношение сторон фигуры, а не изображение, которое она содержит.

{{% /alert %}}

## **Использовать свойство StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat), вы можете задать заполняющий прямоугольник.

Когда для изображения задано растяжение, исходный прямоугольник масштабируется, чтобы соответствовать указанному заполняющему прямоугольнику. Каждый край заполняющего прямоугольника определяется процентным смещением от соответствующего края рамки фигуры. Положительный процент указывает на врезание, а отрицательный процент указывает на выдвижение.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник *AutoShape*.
4. Создайте изображение.
5. Установите тип заполнения фигуры.
6. Установите режим заполнения изображения фигуры.
7. Добавьте установленное изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующего края рамки фигуры.
9. Запишите измененную презентацию в файл PPTX.

Этот Java-код демонстрирует процесс, в котором используется свойство StretchOff:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создает экземпляр класса ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет AutoShape, установлено на Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Устанавливает тип заполнения фигуры
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заполнения изображения фигуры
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заполнения фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Указывает смещения изображения от соответствующего края рамки фигуры
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```