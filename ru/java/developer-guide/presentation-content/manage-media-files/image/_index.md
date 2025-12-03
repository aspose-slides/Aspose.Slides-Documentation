---
title: Оптимизация управления изображениями в презентациях с использованием Java
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/java/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из веба
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Java, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более притягательными и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других мест на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами.

{{% alert  title="Tip" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры —[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) —которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Если вы хотите добавить изображение как объект кадра —особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.д.—см. [Picture Frame](https://docs.aspose.com/slides/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Вы можете работать с вводом/выводом, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. См. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в этих популярных форматах: JPEG, PNG, GIF и другие. 

## **Добавление изображений, хранящихся локально, на слайды**

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


## **Добавление изображений из веба на слайды**

Если нужное вам изображение недоступно на компьютере, вы можете добавить его напрямую из веба. 

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


## **Добавление изображений в мастер-слайды**

Мастер-слайд — это верхний слайд, который хранит и управляет информацией (тема, компоновка и т.д.) обо всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер-слайд, оно появляется на каждом слайде под этим мастером. 

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


## **Добавление изображений как фон слайда**

Вы можете решить использовать картинку в качестве фона для конкретного слайда или нескольких слайдов. В этом случае см. *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) , который относится к интерфейсу [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection). 

Чтобы создать объект изображения на основе SVG, вы можете сделать это следующим образом:

1. Создать объект SvgImage для вставки его в ImageShapeCollection
2. Создать объект PPImage из ISvgImage
3. Создать объект PictureFrame, используя интерфейс IPPImage

Этот пример кода показывает, как реализовать указанные шаги для добавления SVG‑изображения в презентацию:
```java
// Инстанцировать класс Presentation, представляющий файл PPTX
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

Конвертация SVG в набор фигур в Aspose.Slides похожа на функцию PowerPoint, используемую для работы с SVG‑изображениями:

![PowerPoint Popup Menu](img_01_01.png)

Эта функция предоставляется одной из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG‑файла в набор фигур:
```java
// Создать новую презентацию
IPresentation presentation = new Presentation();
try {
    // Прочитать содержимое SVG-файла
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Создать объект SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получить размер слайда
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Преобразовать SVG изображение в группу фигур, масштабируя его до размера слайда
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

Aspose.Slides для Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в виде EMF на слайды с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Сохранить рабочую книгу в поток
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

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, что использованы в элементах слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием необработанных байтов, экземпляра [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/), или другого изображения, уже присутствующего в коллекции. 

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Загрузите новое изображение из файла в массив байтов.
3. Замените целевое изображение новым, используя массив байтов.
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/), и замените целевое изображение этим объектом.
5. В третьем подходе замените целевое изображение изображением, уже присутствующим в коллекции изображений презентации.
6. Сохраните изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Первый способ.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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
С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать текст, создавать GIF‑изображения из текста и т.п. 
{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но конечный вид зависит от того, как [picture](/slides/ru/java/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Как лучше всего заменить один и тот же логотип одновременно на десятках слайдов?**

Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации —обновления распространятся на все элементы, использующие этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить картинку фоном для нескольких слайдов одновременно?**

[Назначьте изображение как фон](/slides/ru/java/presentation-background/) на мастер‑слайде или соответствующем макете —все слайды, использующие этот мастер/макет, унаследуют фон.

**Как предотвратить «разрастание» размера презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графические элементы на мастере, где это уместно.