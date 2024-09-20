---
title: Изображение
type: docs
weight: 10
url: /java/image/
description: Работа с изображениями в слайдах презентаций PowerPoint с использованием Java. Добавление изображений с диска или из Интернета в слайды PowerPoint с использованием Java. Добавление изображений в мастер-слайды или в качестве фона слайда с использованием Java. Добавление SVG в презентацию PowerPoint с использованием Java. Конвертация SVG в фигуры в PowerPoint с использованием Java. Добавление изображений в формате EMF в слайды с использованием Java.
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять изображения из файла, Интернета или других мест в слайды. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды ваших презентаций различными способами.

{{% alert title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют людям быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение как объект рамки—особенно если вы планируете использовать стандартные параметры форматирования, чтобы изменить его размер, добавить эффекты и так далее—см. [Рамка изображения](https://docs.aspose.com/slides/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}}

Вы можете манипулировать операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, GIF и других. 

## **Добавление локально хранящихся изображений в слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд презентации. Этот пример кода на Java показывает, как добавить изображение на слайд:

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

## **Добавление изображений из Интернета в слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение непосредственно из Интернета. 

Этот пример кода показывает, как добавить изображение из Интернета на слайд на Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[ЗАМЕНИТЕ НА URL]");
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

Мастер-слайд — это верхний слайд, который хранит и контролирует информацию (тема, макет и т.д.) о всех слайдах под ним. Таким образом, когда вы добавляете изображение в мастер-слайд, это изображение появляется на каждом слайде под этим мастер-слайдом. 

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

Вы можете решить использовать изображение в качестве фона для определенного слайда или нескольких слайдов. В этом случае вам необходимо ознакомиться с *[Установкой изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

Чтобы создать объект изображения на основе SVG-изображения, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection
2. Создайте объект PPImage из ISvgImage
3. Создайте объект PictureFrame, используя интерфейс IPPImage

Этот пример кода показывает, как реализовать описанные шаги для добавления SVG-изображения в презентацию:
```java 
// Создание объекта класса Presentation, представляющего файл PPTX
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
Конвертация SVG в набор фигур в Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с изображениями SVG:

![Всплывающее меню PowerPoint](img_01_01.png)

Функциональность предоставляется одним из перегруженных методов [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для конвертации SVG-файла в набор фигур:

```java 
// Создание новой презентации
IPresentation presentation = new Presentation();
try {
    // Чтение содержимого SVG-файла
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Создание объекта SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получение размера слайда
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Конвертация SVG-изображения в группу фигур с масштабированием до размера слайда
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Сохранение презентации в формате PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Добавление изображений в формате EMF в слайды**
Aspose.Slides для Java позволяет вам генерировать EMF-изображения из Excel-листов и добавлять изображения в формате EMF в слайды с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Сохранение рабочей книги в поток
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

Используя бесплатный конвертер Aspose [Текст в GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать тексты, создавать GIF-файлы из текстов и т.д. 

{{% /alert %}}