---
title: Управление рамками изображений в презентациях с использованием Java
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/java/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Оптимизируйте ваш рабочий процесс и улучшите дизайн слайдов."
---
## **Введение**

Рамка изображения — это фигура, содержащая изображение, она похожа на картинку в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage]() путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заливки фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, доступного у объекта фигуры, связанного с указанным слайдом.
6. Добавьте рамку изображения (содержит картинку) на слайд.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код Java демонстрирует, как создать рамку изображения:

```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с высотой и шириной, соответствующими изображению
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. При сочетании рамки изображения с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будут интересны следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/ru/java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/ru/java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/ru/java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/ru/java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/ru/java/conversion/svg-to-png/).

{{% /alert %}} 

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заливки фигуры.
5. Укажите относительную ширину и высоту изображения в рамке изображения.
6. Сохраните изменённую презентацию в файл PPTX.

Этот код Java демонстрирует, как создать рамку изображения с относительным масштабом:

```java
// Создает экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Добавляет рамку изображения с высотой и шириной, эквивалентными изображению
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Устанавливает относительный масштаб ширины и высоты
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечение растровых изображений из рамок изображения**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/PictureFrame) и сохранять их в PNG, JPG и других форматах. Пример кода ниже показывает, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

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

## **Извлечение SVG‑изображений из рамок изображения**

Когда презентация содержит SVG‑графику, размещенную внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/), Aspose.Slides для Java позволяет получить оригинальные векторные изображения без потери качества. Проходя по коллекции фигур слайда, можно определить каждую [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/), проверить, содержит ли базовый [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) SVG‑содержимое, и затем сохранить это изображение на диск или в поток в его исходном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки изображения:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, примененный к изображению. Этот код Java демонстрирует операцию:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Получение яркости и контрастности изображения**

Aspose.Slides позволяет получить эффекты яркости и контрастности, применённые к изображению. Интерфейс [ILuminance](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iluminance/) представляет это преобразование изображения.

Этот код Java демонстрирует, как получить настройки яркости и контрастности из рамки изображения:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. Используя эти параметры, вы можете изменить рамку изображения, чтобы она соответствовала определённым требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заливки фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) , доступного у объекта [IShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection) , связанного с указанным слайдом.
6. Добавьте рамку изображения (содержит картинку) на слайд.
7. Установите цвет линии рамки изображения.
8. Установите ширину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержит картинку) на слайд.
11. Сохраните изменённую презентацию в файл PPTX.

Этот код Java демонстрирует процесс форматирования рамки изображения:

```java
// Создает экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с высотой и шириной, эквивалентными изображению
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Применяет некоторое форматирование к PictureFrameEx
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

{{% alert title="Tip" color="primary" %}}

Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в качестве ссылки**

Чтобы избежать большого размера презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот код Java показывает, как добавить изображение и видео в заполнитель:

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

## **Обрезка изображений**

Этот код Java показывает, как обрезать существующее изображение на слайде:

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

    // Добавляет рамку изображения на слайд
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

## **Удаление обрезанных областей изображения**

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, можете использовать метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот код Java демонстрирует операцию:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает рамку изображения с первого слайда
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Удаляет обрезанные области изображения в рамке и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Сохраняет результат
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Этот метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение в процессе обрезки. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации с помощью метода [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Этот метод сжимает изображение, уменьшая его размер в зависимости от размера фигуры и указанного разрешения, с возможностью удаления обрезанных областей.

Он корректирует размер и разрешение изображения аналогично функции PowerPoint **Picture Format -> Compress Pictures -> Resolution**.

Следующие примеры Java демонстрируют, как сжать изображение в презентации, задав целевое разрешение и при желании удалив обрезанные области:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжимает изображение с целевым разрешением 150 DPI (веб разрешение) и удаляет обрезанные области.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Или напрямую использовать пользовательское значение DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжимает изображение до 150 DPI (веб разрешение), удаляя обрезанные области.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод преобразует изображение к более низкому разрешению на основе размеров фигуры и указанного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не применяется. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG высокого разрешения.

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла соотношение сторон даже после изменения размеров изображения, можно использовать метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) , чтобы установить параметр *Lock Aspect Ratio*.

Этот код Java показывает, как заблокировать соотношение сторон фигуры:

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

    // установить сохранение соотношения сторон фигуры при изменении размеров
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Этот параметр *Lock Aspect Ratio* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPictureFillFormat), вы можете указать прямоугольник заливки. 

Когда для изображения задаётся растягивание, исходный прямоугольник масштабируется, чтобы вписаться в указанный прямоугольник заливки. Каждая сторона прямоугольника заливки задаётся процентным смещением от соответствующей стороны ограничивающего прямоугольника фигуры. Положительный процент обозначает внутреннее смещение, а отрицательный — внешнее.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заливки фигуры.
6. Установите режим заливки изображения фигуры.
7. Добавьте изображение для заливки фигуры.
8. Укажите смещения изображения от соответствующей стороны ограничивающего прямоугольника фигуры
9. Сохраните изменённую презентацию в файл PPTX.

Этот код Java демонстрирует процесс, в котором используется свойство StretchOff:

```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
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

    // Добавляет AutoShape, установленный в Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Устанавливает тип заливки фигуры
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заливки изображения фигуры
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заливки фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Указывает смещения изображения от соответствующей стороны ограничивающего прямоугольника фигуры
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

## **Часто задаваемые вопросы**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями движка слайдов и конвертации изображений.

**Как добавление десятков крупных изображений влияет на размер и производительность PPTX?**

Встраивание больших изображений увеличивает размер файла и потребление памяти; привязка изображений помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для уменьшения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [shape locks](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) для [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/) (например, отключите перемещение или изменение размера). Механизм блокировки описан для фигур в отдельной [статье о защите](/slides/ru/java/applying-protection-to-presentation/) и поддерживается различными типами фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/).

**Сохраняется ли векторное качество SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/) в виде оригинального вектора. При [экспорте в PDF](/slides/ru/java/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/java/convert-powerpoint-to-png/) результат может быть растрирован в зависимости от настроек экспорта; то, что оригинальный SVG хранится как вектор, подтверждается поведением извлечения.