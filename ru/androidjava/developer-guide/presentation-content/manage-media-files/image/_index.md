---
title: Изображение
type: docs
weight: 10
url: /androidjava/image/
description: Работа с изображениями в слайдах PowerPoint с использованием Java. Добавление изображений с диска или из сети в слайды PowerPoint с использованием Java. Добавление изображений в мастер-слайды или в качестве фонового изображения с использованием Java. Добавление SVG в презентацию PowerPoint с использованием Java. Конвертация SVG в фигуры в PowerPoint с использованием Java. Добавление изображений как EMF в слайды с использованием Java.
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более привлекательными и интересными. В Microsoft PowerPoint вы можете вставлять изображения из файла, интернета или других мест на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами. 

{{% alert title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение как объект рамки—особенно если вы планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и так далее—посмотрите [Рамка для изображения](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

{{% alert title="Заметка" color="warning" %}}

Вы можете манипулировать операциями ввода/вывода с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. Посмотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, GIF и других. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода на Java показывает, как добавить изображение на слайд:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление изображений из интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение напрямую из интернета. 

Этот пример кода показывает, как добавить изображение из интернета на слайд на Java:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
            outputStream.write(buffer, 0, read);

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление изображений в мастер-слайды**

Мастер-слайд является верхним слайдом, который хранит и контролирует информацию (тема, макет и т.д.) обо всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер-слайд, это изображение появляется на каждом слайде под этим мастер-слайдом. 

Этот пример кода на Java показывает, как добавить изображение в мастер-слайд:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам необходимо посмотреть *[Установка изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавлять или вставлять любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Чтобы создать объект изображения на основе изображения SVG, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection
2. Создайте объект PPImage из ISvgImage
3. Создайте объект PictureFrame с использованием интерфейса IPPImage

Этот пример кода показывает, как реализовать описанные шаги для добавления изображения SVG в презентацию:
```java 
// Создайте экземпляр класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертация SVG в набор фигур**
Конвертация SVG в набор фигур Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с изображениями SVG:

![Всплывающее меню PowerPoint](img_01_01.png)

Функциональность предоставляется одним из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для конвертации файла SVG в набор фигур:

```java 
// Создание новой презентации
IPresentation presentation = new Presentation();
try {
    // Чтение содержимого файла SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Создание объекта SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получение размеров слайда
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Конвертация изображения SVG в группу фигур с увеличением до размера слайда
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Сохранение презентации в формате PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Добавление изображений как EMF на слайды**
Aspose.Slides для Android через Java позволяет генерировать EMF изображения из листов Excel и добавлять изображения как EMF на слайды с использованием Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Сохранение книги в поток
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
                    (float)pres.getSlideSize().getSize().getWidth(), 
                    (float)pres.getSlideSize().getSize().getHeight(), 
                    picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Информация" color="info" %}}

Используя бесплатный конвертер Aspose [Текст в GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать тексты, создавать GIF из текстов и т.д. 

{{% /alert %}}