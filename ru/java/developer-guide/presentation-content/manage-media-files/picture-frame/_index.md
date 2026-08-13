---
title: Управление рамками изображений в презентациях с помощью Java
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
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Оптимизируйте рабочий процесс и улучшите дизайн слайдов."
---
## **Введение**

Рамка изображения — это фигура, содержащая изображение, она похожа на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, отформатировав рамку.

{{% alert  title="Tip" color="info" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage]() путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, доступного у объекта фигуры, связанного с выбранным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Сохраните изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует, как создать рамку изображения:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.IOException;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создаёт экземпляр класса Image
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

{{% alert color="warning" %}} 

Рамки изображений позволяют быстро создавать слайды презентаций на основе изображений. Комбинируя рамку изображения с параметрами сохранения Aspose.Slides, вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будут полезны следующие страницы: конвертировать [image to JPG](https://products.aspose.com/slides/ru/java/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/ru/java/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/ru/java/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/ru/java/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/ru/java/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/ru/java/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке.
6. Сохраните изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует, как создать рамку изображения с относительным масштабом:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создать экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Добавить рамку изображения с высотой и шириной, соответствующей изображению
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Установка относительного масштаба ширины и высоты
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Записать файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечение растровых изображений из рамок**

Вы можете извлечь растровые изображения из объектов [PictureFrame] и сохранить их в PNG, JPG и других форматах. Приведённый ниже пример кода демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

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

## **Извлечение SVG‑изображений из рамок**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame], Aspose.Slides for Java позволяет получить оригинальные векторные изображения без потери качества. Пройдя по коллекции фигур слайда, вы можете определить каждый [PictureFrame], проверить, содержит ли базовый [IPPImage] SVG‑контент, и затем сохранить это изображение на диск или в поток в его нативном формате SVG.

Ниже приведён пример кода, демонстрирующий, как извлечь SVG‑изображение из рамки:

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

        // getSvgImage возвращает null, когда изображение является растровым.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
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

Aspose.Slides позволяет получить эффекты яркости и контрастности, применённые к изображению. Интерфейс [ILuminance] представляет это преобразование изображения.

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

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. Используя эти параметры, вы можете изменить рамку, чтобы она соответствовала определённым требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) объекта [IShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection), связанного с выбранным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Установите цвет линий рамки изображения.
8. Установите ширину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержащую картинку) на слайд.
11. Сохраните изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует процесс форматирования рамки изображения:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создаёт экземпляр класса Image
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

Aspose недавно разработала [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам когда‑нибудь понадобится [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы избежать большого размера презентаций, вы можете добавлять изображения (или видео) через ссылки, а не встраивая файлы непосредственно в презентацию. Этот Java‑код показывает, как добавить изображение и видео в заполнитель:

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

Этот Java‑код демонстрирует, как обрезать существующее изображение на слайде:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// Creates new image object
// Создаёт новый объект изображения
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds a PictureFrame to a Slide
    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Crops the image (percentage values)
    // Обрезает изображение (значения в процентах)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Saves the result
    // Сохраняет результат
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление обрезанных областей изображения**

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, можете использовать метод [deletePictureCroppedAreas](). Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает рамку изображения с первого слайда
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Удаляет обрезанные области изображения рамки и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Сохраняет результат
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод [deletePictureCroppedAreas]() добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame], такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Этот метод в процессе обрезки преобразует метафайлы WMF/EMF в растровое PNG‑изображение. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации с помощью метода [IPictureFillFormat.compressImage](). Этот метод уменьшает изображение, уменьшая его размер в зависимости от размеров фигуры и указанного разрешения, с возможностью удаления обрезанных областей.

Он корректирует размер и разрешение изображения аналогично функции PowerPoint **Формат рисунка → Сжать рисунки → Разрешение**.

Ниже приведены примеры Java, демонстрирующие, как сжать изображение в презентации, задав целевое разрешение и, при желании, удалив обрезанные области:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжать изображение до целевого разрешения 150 DPI (веб-разрешение) и удалить обрезанные области.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Проверить результат сжатия.
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

Или напрямую указав пользовательское значение DPI:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Сжать изображение до 150 DPI (веб-разрешение), удаляя обрезанные области.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод преобразует изображение к более низкому разрешению в зависимости от размеров фигуры и указанного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не применяется. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG‑изображения высокого разрешения.

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла соотношение сторон даже после изменения размеров изображения, можно использовать метод [setAspectRatioLocked](), чтобы установить параметр *Lock Aspect Ratio*. 

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

    // установить форму так, чтобы при изменении размеров сохранялось соотношение сторон
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Настройка *Lock Aspect Ratio* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](), [StretchOffsetTop](), [StretchOffsetRight]() и [StretchOffsetBottom]() из интерфейса [IPictureFillFormat] и класса [PictureFillFormat], вы можете задать прямоугольник заполнения. 

Когда для изображения указано растягивание, исходный прямоугольник масштабируется так, чтобы соответствовать указанному прямоугольнику заполнения. Каждая сторона прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника фигуры. Положительный процент указывает вставку, отрицательный — выступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заливки фигуры.
6. Установите режим заливки изображения фигуры.
7. Добавьте изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующей грани ограничивающего прямоугольника фигуры.
9. Сохраните изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует процесс, в котором используется свойство StretchOff:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создаёт экземпляр класса ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет AutoShape типа Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Устанавливает тип заливки фигуры
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заливки изображением для фигуры
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заполнения фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Задаёт смещения изображения от соответствующей грани ограничивающего прямоугольника фигуры
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Как узнать, какие форматы изображений поддерживаются для PictureFrame?

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные изображения (например, SVG) через объект изображения, назначаемый [PictureFrame]. Список поддерживаемых форматов в целом совпадает с возможностями двигателя конвертации слайдов и изображений.

### Как добавление десятков крупных изображений повлияет на размер PPTX и производительность?

Встраивание крупных изображений увеличивает размер файла и потребление памяти; привязка изображений (link) помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

### Как заблокировать объект изображения от случайного перемещения/изменения размера?

Используйте [shape locks] для [PictureFrame] (например, отключите перемещение или изменение размера). Механизм блокировки описан для фигур в отдельной [статье по защите](/slides/ru/java/applying-protection-to-presentation/) и поддерживается различными типами фигур, включая [PictureFrame].

### Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?

Aspose.Slides позволяет извлекать SVG из [PictureFrame] как оригинальный вектор. При [экспорте в PDF](/slides/ru/java/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/java/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением извлечения.