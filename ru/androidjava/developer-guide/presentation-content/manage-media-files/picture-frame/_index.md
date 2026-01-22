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
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Упростите рабочий процесс и улучшите дизайн слайдов."
---

Рамка изображения — это фигура, содержащая изображение; она похожа на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, изменяя свойства рамки.

{{% alert  title="Tip" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — чтобы быстро создавать презентации из изображений. 
{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage]() путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использован для заполнения фигуры.  
4. Задайте ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, доступного у объекта формы, ассоциированного с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Сохраните изменённую презентацию в файл PPTX.  

Ниже приведён Java‑код, показывающий, как создать рамку изображения:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Создает экземпляр класса Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Добавляет рамку изображения с соответствующей высотой и шириной картинки
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание рамки изображения с относительным масштабом**

Изменяя относительный масштаб изображения, можно получить более сложную рамку изображения.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использован для заполнения фигуры.  
5. Укажите относительные ширину и высоту изображения в рамке.  
6. Сохраните изменённую презентацию в файл PPTX.  

Ниже показан Java‑код для создания рамки изображения с относительным масштабом:
```java
// Создает класс Presentation, представляющий PPTX
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

Из объектов [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) можно извлекать растровые изображения и сохранять их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа *sample.pptx* и сохранить его в формате PNG.  
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

Если в презентации имеются SVG‑графика, помещённая внутри фигур [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides for Android via Java позволяет получить оригинальные векторные изображения с полной точностью. Путём обхода коллекции фигур слайда можно определить каждую [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/), проверить, содержит ли связанный объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) SVG‑контент, и затем сохранить это изображение в файл или поток в его нативном SVG‑формате.  

Ниже приведён пример кода, показывающий, как извлечь SVG‑изображение из рамки:  
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

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Пример Java‑кода:  
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

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью можно изменить рамку, чтобы она соответствовала конкретным требованиям.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection), связанный с объектом презентации, который будет использован для заполнения фигуры.  
4. Задайте ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе этих размеров через метод [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) объекта [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection), связанного с выбранным слайдом.  
6. Добавьте рамку изображения (содержащую картинку) на слайд.  
7. Установите цвет линии рамки.  
8. Установите толщину линии рамки.  
9. Поверните рамку, задав положительное или отрицательное значение.  
   * Положительное значение — поворачивает изображение по часовой стрелке.  
   * Отрицательное значение — поворачивает изображение против часовой стрелки.  
10. Добавьте рамку изображения (содержащую картинку) на слайд.  
11. Сохраните изменённую презентацию в файл PPTX.  

Пример Java‑кода, демонстрирующего процесс форматирования рамки изображения:  
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
Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этим сервисом. 
{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы уменьшить размер презентации, можно добавлять изображения (или видео) через ссылки, а не встраивать файлы непосредственно в презентацию. Пример Java‑кода, показывающий, как добавить изображение и видео в заполнитель:  
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

Пример Java‑кода, показывающий, как обрезать существующее изображение на слайде:  
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


## **Удаление обрезанных областей рамки изображения**

Если необходимо удалить обрезанные области изображения, находящегося в рамке, используйте метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Метод возвращает обрезанное изображение либо оригинал, если обрезка не требуется.  

Пример Java‑кода:  
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


{{% alert title="NOTE" color="warning" %}} 
Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в конечной презентации возрастёт.  

Метод конвертирует WMF/EMF‑метафайлы в растровое PNG‑изображение при обрезке. 
{{% /alert %}}

## **Блокировка соотношения сторон**

Чтобы фигура, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Lock Aspect Ratio*.  

Пример Java‑кода, показывающий, как заблокировать соотношение сторон фигуры:  
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

    // установить форму, чтобы сохранять соотношение сторон при изменении размера
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон самой фигуры, а не изображения, которое она содержит. 
{{% /alert %}}

## **Использование свойства StretchOff**

С помощью свойств [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) можно задать прямоугольник заполнения.  

При указании растяжения изображения исходный прямоугольник масштабируется до заданного прямоугольника заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника фигуры. Положительный процент — внутренний отступ, отрицательный — внешний выступ.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Установите тип заливки фигуры.  
6. Установите режим заливки рисунком.  
7. Добавьте изображение для заполнения фигуры.  
8. Задайте смещения изображения от соответствующих граней ограничивающего прямоугольника фигуры.  
9. Сохраните изменённую презентацию в файл PPTX.  

Пример Java‑кода, демонстрирующий процесс использования свойства StretchOff:  
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

    // Добавляет AutoShape с типом Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Устанавливает тип заливки формы
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заливки изображения формы
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Устанавливает изображение для заливки формы
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Указывает смещения изображения от соответствующего края ограничивающего прямоугольника формы
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**  

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т. д.), так и векторные (например, SVG) через объект изображения, присвоенный [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка конвертации слайдов и изображений.  

**Как добавление десятков крупных изображений скажется на размере и производительности PPTX?**  

Встраивание больших изображений увеличивает размер файла и потребление памяти; привязка изображений по ссылке помогает удержать размер презентации небольшим, но требует доступности внешних файлов. Aspose.Slides позволяет добавлять изображения по ссылке для уменьшения размера файла.  

**Как заблокировать объект изображения от случайного перемещения/изменения размеров?**  

Используйте [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) для [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) (например, отключите перемещение или изменение размеров). Механизм блокировки поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/).  

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**  

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/androidjava/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт того, что исходный SVG хранится как вектор, подтверждается поведением извлечения.