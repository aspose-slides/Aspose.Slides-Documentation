---
title: Управление рамками изображений в презентациях на Android
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Оптимизируйте рабочий процесс и улучшите дизайн слайдов."
---
## **Введение**

Рамка изображения — это фигура, содержащая изображение; она похожа на картину в рамке.

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя саму рамку.

{{% alert  title="Tip" color="info" %}} 
Aspose предоставляет бесплатные конвертеры —[JPEG to PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) —которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage]() , добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IImageCollection), связанную с объектом презентации, которое будет использовано для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения через метод `AddPictureFrame`, доступный у объекта фигуры, связанного с выбранным слайдом.
6. Добавьте рамку изображения (с изображением) на слайд.
7. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать рамку изображения:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с высотой и шириной, соответствующей изображению
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание рамки изображения с относительным масштабом**

Изменяя относительный масштаб изображения, можно создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPPImage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IImageCollection), связанную с объектом презентации, которое будет использовано для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке.
6. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать рамку изображения с относительным масштабом:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

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

## **Извлечение растровых изображений из рамок изображений**

Вы можете извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PictureFrame) и сохранить их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение SVG‑изображений из рамок изображений**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides для Android на Java позволяет получить оригинальные векторные изображения с полной точностью. Как только у вас есть [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/), у которого [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) содержит SVG‑контент, вы можете считать это SVG‑изображение и сохранить его на диск или в поток в его собственном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

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

Aspose.Slides позволяет получить эффекты яркости и контрастности, применённые к изображению. Интерфейс [ILuminance](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iluminance/) представляет это преобразование изображения.

Этот Java‑код демонстрирует, как получить настройки яркости и контрастности из рамки изображения:

```java
import com.aspose.slides.*;

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

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью можно изменить рамку так, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPPImage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IImageCollection), связанную с объектом презентации, которое будет использовано для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) объекта [IShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection), связанного с выбранным слайдом.
6. Добавьте рамку изображения (с изображением) на слайд.
7. Установите цвет линии рамки.
8. Установите толщину линии рамки.
9. Поверните рамку, задав положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (с изображением) на слайд.
11. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует процесс форматирования рамки изображения:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Создает экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с высотой и шириной, соответствующей изображению
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

{{% alert title="Tip" color="info" %}}

Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), используйте этот сервис. 
{{% /alert %}}

## **Добавление изображения как ссылки**

Чтобы уменьшить размер презентации, можно добавлять изображения (или видео) через ссылки, а не встраивая файлы непосредственно в презентацию. Этот Java‑код показывает, как добавить изображение и видео в заполнитель:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

Этот Java‑код показывает, как обрезать существующее изображение на слайде:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Создает новый объект изображения
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет PictureFrame на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Обрезает изображение (значения в процентах)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Сохраняет результат
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление обрезанных областей изображения в рамке**

Если нужно удалить обрезанные области изображения, содержащегося в рамке, используйте метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Метод возвращает обрезанное изображение или оригинал, если обрезка не требуется.

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

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

{{% alert title="NOTE" color="warning" %}} 
Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/), такая настройка может снизить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение при выполнении обрезки. 
{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации, используя метод [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-).  
Метод сжимает изображение, уменьшая его размер в зависимости от размеров фигуры и заданного разрешения, с возможностью удаления обрезанных областей.

Он регулирует размер и разрешение изображения аналогично функции PowerPoint **Format Picture > Compress Pictures > Resolution**.

Ниже приведены примеры Java, демонстрирующие сжатие изображения в презентации с указанием целевого разрешения и, при необходимости, удалением обрезанных областей:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжимает изображение с целевым разрешением 150 DPI (веб-разрешение) и удаляет обрезанные области.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Проверяет результат сжатия.
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

Или с указанием собственного значения DPI напрямую:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжимает изображение до 150 DPI (веб-разрешение), удаляя обрезанные области.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Метод преобразует изображение к более низкому разрешению, опираясь на размер фигуры и указанный DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не применяется. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG‑изображения высокого разрешения. 
{{% /alert %}}

## **Блокировка соотношения сторон**

Если нужно, чтобы фигура с изображением сохраняла своё соотношение сторон даже после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки свойства *Lock Aspect Ratio*.

Этот Java‑код показывает, как заблокировать соотношение сторон фигуры:

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // установить, чтобы фигура сохраняла пропорции при изменении размера
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Настройка *Lock Aspect Ratio* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит. 
{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IPictureFillFormat) можно задать прямоугольник заполнения.

При растягивании изображения исходный прямоугольник масштабируется до указанного прямоугольника заполнения. Каждая граница прямоугольника заполнения задаётся процентным смещением от соответствующей границы ограничивающего прямоугольника фигуры. Положительный процент задаёт отступ, отрицательный – выступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заполнения фигуры.
6. Установите режим заполнения изображения.
7. Добавьте изображение‑заполнитель для фигуры.
8. Укажите смещения изображения от соответствующей границы ограничивающего прямоугольника фигуры.
9. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует процесс использования свойства StretchOff:

```java
import com.aspose.slides.*;

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

    // Добавляет AutoShape в виде прямоугольника
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Устанавливает тип заливки фигуры
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заливки фигурой изображением
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заполнения фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Указывает смещения изображения от соответствующей границы ограничивающего прямоугольника фигуры
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Как узнать, какие форматы изображений поддерживаются для PictureFrame?

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, перекрывается с возможностями движка конвертации слайдов и изображений.

### Как добавление десятков больших изображений влияет на размер и производительность PPTX?

Встраивание больших изображений увеличивает размер файла и потребление памяти; связывание изображений помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

### Как заблокировать объект изображения от случайного перемещения/изменения размеров?

Используйте [shape locks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) для [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/) (например, отключить перемещение или изменение размеров). Механизм блокировки поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/).

### Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/) в оригинальном векторном виде. При [экспорте в PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/androidjava/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.