---
title: Оптимизация управления изображениями в презентациях на Android
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения в слайдах презентаций**

Изображения делают презентацию более увлекательной и интересной. В Microsoft PowerPoint вы можете вставлять картинки из файла, из интернета или из других источников на слайды. Аналогично Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами. 

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект рамки — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.д. — см. [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете выполнять операции ввода/вывода, связанные с изображениями и презентациями PowerPoint, для конвертации изображения из одного формата в другой. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в популярных форматах: JPEG, PNG, GIF и других. 

## **Добавление изображений, хранящихся локально, на слайды**

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


## **Добавление изображений из веба на слайды**

Если нужное изображение недоступно на вашем компьютере, его можно добавить напрямую из интернета. 

Этот пример кода демонстрирует, как добавить изображение из веба на слайд в Java:
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


## **Добавление изображений в шаблоны слайдов**

Шаблон слайда (slide master) — это главный слайд, который хранит и управляет информацией (тема, макет и т.п.) о всех слайдах, использующих его. Поэтому, когда вы добавляете изображение в шаблон слайда, это изображение появляется на каждом слайде, основанном на данном шаблоне. 

Этот пример кода на Java показывает, как добавить изображение в шаблон слайда:
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

Вы можете использовать картинку в качестве фона для отдельного слайда или группы слайдов. В этом случае смотрите *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентацию**

Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Чтобы создать объект изображения на основе SVG, выполните следующие шаги:

1. Создать объект SvgImage для вставки в ImageShapeCollection  
2. Создать объект PPImage из ISvgImage  
3. Создать объект PictureFrame, используя интерфейс IPPImage  

Этот пример кода демонстрирует, как реализовать вышеперечисленные шаги для добавления SVG‑изображения в презентацию:
```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX
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

Конвертация SVG в набор фигур в Aspose.Slides аналогична функции PowerPoint для работы с SVG‑изображениями:

![Всплывающее меню PowerPoint](img_01_01.png)

Эта возможность реализована через одну из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для конвертации SVG‑файла в набор фигур:
```java 
 // Создать новую презентацию
 IPresentation presentation = new Presentation();
 try {
     // Прочитать содержимое SVG файла
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

Aspose.Slides for Android via Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды в сочетании с Aspose.Cells.  

Этот пример кода демонстрирует, как выполнить описанную задачу:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Сохранить рабочую книгу в поток
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

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, что используются в формах слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием сырого массива байтов, экземпляра [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) или другого изображения, уже находящегося в коллекции.

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) и замените целевое изображение этим объектом.  
5. В третьем подходе замените целевое изображение на изображение, уже существующее в коллекции изображений презентации.  
6. Сохраните изменённую презентацию как файл PPTX.  
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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
    
    // Сохраните презентацию в файл.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете анимировать текст, создавать GIF‑файлы из текста и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/androidjava/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**

Разместите логотип на шаблоне слайда или макете и замените его в коллекции изображений презентации — изменения будут автоматически применены ко всем элементам, использующим этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые формы?**

Да. SVG можно конвертировать в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить картинку фоном сразу для нескольких слайдов?**

[Назначьте изображение в качестве фона](/slides/ru/androidjava/presentation-background/) в шаблоне слайда или соответствующем макете — все слайды, использующие этот шаблон/макет, унаследуют фон.

**Как избежать «раздувания» размера презентации из‑за большого количества картинок?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте часто повторяющиеся графические элементы в шаблоне, где это уместно.