---
title: Оптимизация управления изображениями в презентациях на Android
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/androidjava/image/
keywords:
- добавить изображение
- добавить рисунок
- добавить битмап
- заменить изображение
- заменить рисунок
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами. 

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект рамки — особенно если планируете использовать стандартные параметры форматирования для изменения его размеров, добавления эффектов и т.д. — см. [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете выполнять операции ввода/вывода с изображениями и презентациями PowerPoint для преобразования изображения из одного формата в другой. См. эти страницы: конвертировать [image to JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в популярных форматах: JPEG, PNG, GIF и др. 

## **Добавление локально сохранённых изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд презентации. Пример кода на Java демонстрирует, как добавить изображение на слайд:
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


## **Добавление изображений из Интернета на слайды**

Если нужное вам изображение недоступно на компьютере, вы можете добавить его напрямую из Интернета. 

Этот пример кода показывает, как добавить изображение из веба на слайд в Java:
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


## **Добавление изображений в мастер‑слайды**

Мастер‑слайд — это главный слайд, который хранит и управляет информацией (тема, макет и т.д.) о всех слайдах, находящихся под ним. Поэтому, когда вы добавляете изображение в мастер‑слайд, это изображение появляется на каждом слайде, использующем данный мастер‑слайд. 

Этот пример кода на Java показывает, как добавить изображение в мастер‑слайд:
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


## **Добавление изображений в качестве фона слайдов**

Вы можете решить использовать картинку в качестве фона для конкретного слайда или нескольких слайдов. В этом случае см. *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Чтобы создать объект изображения на основе SVG, можно сделать это следующим образом:

1. Создать объект SvgImage для вставки в ImageShapeCollection  
2. Создать объект PPImage из ISvgImage  
3. Создать объект PictureFrame, используя интерфейс IPPImage  

Этот пример кода показывает, как реализовать перечисленные шаги для добавления SVG‑изображения в презентацию:
```java 
// Создать экземпляр класса Presentation, представляющего файл PPTX
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


## **Преобразование SVG в набор фигур**

Преобразование SVG в набор фигур в Aspose.Slides аналогично функциональности PowerPoint, используемой для работы с SVG‑изображениями:

![PowerPoint Popup Menu](img_01_01.png)

Функциональность предоставляется одной из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG‑файла в набор фигур:
```java 
// Создать новую презентацию
IPresentation presentation = new Presentation();
try {
    // Прочитать содержимое SVG‑файла
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Создать объект SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получить размер слайда
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Преобразовать SVG‑изображение в группу фигур, масштабируя её до размеров слайда
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Сохранить презентацию в формате PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Добавление изображений в формате EMF на слайды**

Aspose.Slides for Android via Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды в формате EMF с помощью Aspose.Cells.  

Этот пример кода показывает, как выполнить описанную задачу:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Сохранить книгу в поток
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


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, что используются в фигурах слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием необработанных байтов, экземпляра [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) или другого изображения, уже присутствующего в коллекции.

Следуйте приведённым ниже шагам:

1. Загрузить файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  
2. Загрузить новое изображение из файла в массив байтов.  
3. Заменить целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузить изображение в объект [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) и заменить целевое изображение этим объектом.  
5. В третьем подходе заменить целевое изображение изображением, уже находящимся в коллекции изображений презентации.  
6. Сохранить изменённую презентацию как файл PPTX.  

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Первый способ.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Второй способ.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Третий способ.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Сохранить презентацию в файл.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать тексты, создавать GIF‑изображения из текста и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/androidjava/picture-frame/) масштабируется на слайде и от любой компрессии, применяемой при сохранении.

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**

Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации — обновления распространятся на все элементы, использующие этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. SVG можно преобразовать в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение в качестве фона для нескольких слайдов одновременно?**

[Assign the image as the background](/slides/ru/androidjava/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.

**Как предотвратить «раздувание» размера презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графические элементы на мастере, где это уместно.