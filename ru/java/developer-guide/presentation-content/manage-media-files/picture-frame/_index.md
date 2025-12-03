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

Рамка изображения — это фигура, содержащая изображение, как картинка в рамке.  

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage]() путём добавления изображения в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, предоставляемого объектом фигур, связанным с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Запишите изменённую презентацию в файл PPTX.  

Этот Java‑код показывает, как создать рамку изображения:  
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с эквивалентной высотой и шириной картинки
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. При сочетании рамки изображения с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будут полезны следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, можно создать более сложную рамку изображения.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) путём добавления изображения в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
5. Укажите относительные ширину и высоту изображения в рамке изображения.  
6. Запишите изменённую презентацию в файл PPTX.  

Этот Java‑код показывает, как создать рамку изображения с относительным масштабом:  
```java
// Создаёт экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создаёт экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Добавляет рамку изображения с высотой и шириной, эквивалентными картинке
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Устанавливает относительный масштаб высоты и ширины
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

Вы можете извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) и сохранить их в PNG, JPG и другие форматы. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.  
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

Когда презентация содержит векторную графику SVG, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), Aspose.Slides for Java позволяет получить оригинальные векторные изображения с полной точностью. Путём обхода коллекции фигур слайда вы можете определить каждый [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), проверить, содержит ли базовый [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его исходном формате SVG.  

Следующий пример кода демонстрирует извлечение SVG‑изображения из рамки изображения:  
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

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот Java‑код демонстрирует операцию:  
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


## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью можно изменить рамку изображения в соответствии с конкретными требованиями.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) путём добавления изображения в [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) объекта [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection), связанного с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Установите цвет линии рамки изображения.  
8. Установите толщину линии рамки изображения.  
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавьте рамку изображения (содержащую картинку) на слайд.  
11. Запишите изменённую презентацию в файл PPTX.  

Этот Java‑код демонстрирует процесс форматирования рамки изображения:  
```java
// Создаёт экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создаёт экземпляр класса Image
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


{{% alert title="Совет" color="primary" %}}

Недавно Aspose разработал бесплатный [Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/collage/photo-grid), можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы избежать большого размера презентаций, вместо встраивания файлов можно добавлять изображения (или видео) через ссылки. Этот Java‑код показывает, как добавить изображение и видео в заполнитель:  
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

Этот Java‑код демонстрирует, как обрезать существующее изображение на слайде:  
```java
Presentation pres = new Presentation();
// Создаёт новый объект изображения
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
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
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удаление обрезанных областей изображений**

Если необходимо удалить обрезанные области изображения, содержащегося в рамке, можно использовать метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Метод возвращает обрезанное изображение или оригинал, если обрезка не требуется.  

Этот Java‑код демонстрирует операцию:  
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


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), такая настройка может снизить размер презентации. В противном случае количество изображений в итоговой презентации увеличится.  

При выполнении операции обрезки метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если требуется, чтобы фигура, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, можно вызвать метод [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Lock Aspect Ratio*.  

Этот Java‑код показывает, как заблокировать соотношение сторон фигуры:  
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


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Настройка *Lock Aspect Ratio* сохраняет только соотношение сторон самой фигуры, а не изображения, которое она содержит. 

{{% /alert %}}

## **Использование свойства StretchOff**

С помощью свойств [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) можно задать прямоугольник заполнения.  

При растягивании изображения исходный прямоугольник масштабируется так, чтобы вписаться в указанный прямоугольник заполнения. Каждая сторона прямоугольника заполнения задаётся процентным смещением от соответствующей стороны ограничивающего прямоугольника фигуры. Положительный процент задаёт впускание, отрицательный — выступание.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Установите тип заливки фигуры.  
6. Установите режим заливки картинки фигуры.  
7. Добавьте изображение, которое будет использоваться для заливки фигуры.  
8. Укажите смещения изображения от соответствующей стороны ограничивающего прямоугольника фигуры.  
9. Запишите изменённую презентацию в файл PPTX.  

Этот Java‑код демонстрирует процесс использования свойства StretchOff:  
```java
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создаёт экземпляр класса Image (ImageEx)
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

    // Устанавливает режим заливки рисунком
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заливки фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Задает смещения изображения от соответствующих границ ограничивающего прямоугольника фигуры
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


## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**  

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, который назначается [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка конвертации слайдов и изображений.  

**Как добавление десятков больших изображений влияет на размер и производительность PPTX?**  

Встраивание больших изображений увеличивает размер файла и потребление памяти; связывание изображений помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.  

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**  

Используйте [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) для [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (например, отключите перемещение или изменение размера). Механизм блокировки описан в отдельной [статье о защите](/slides/ru/java/applying-protection-to-presentation/) и поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).  

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**  

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) в исходном векторном виде. При [экспорте в PDF](/slides/ru/java/convert-powerpoint-to-pdf/) или в [растровые форматы](/slides/ru/java/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением извлечения.