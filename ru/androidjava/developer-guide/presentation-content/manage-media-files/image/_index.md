---
title: "Оптимизация управления изображениями в презентациях на Android"
linktitle: "Управление изображениями"
type: docs
weight: 10
url: /ru/androidjava/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из сети
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- внешние ресурсы SVG
- резольвер SVG
- связанные SVG‑изображения
- SVG‑шрифты
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Упрощайте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java, повышая производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и визуально привлекательными. В Microsoft PowerPoint вы можете вставлять картинки на слайды из файлов, интернета или других источников. Аналогично Aspose.Slides позволяет добавлять изображения в слайды презентации несколькими способами.

{{% alert  title="Tip" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры —[JPEG to PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) —которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Если вы хотите добавить изображение как рамку картинки —особенно если планируете менять её размер, применять эффекты или использовать другие стандартные параметры форматирования —см. [Picture Frame](/slides/ru/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Вы можете конвертировать изображения из одного формата в другой. См. следующие страницы: конвертировать [image to JPG](https://products.aspose.com/slides/ru/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/ru/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/ru/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ru/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/ru/androidjava/conversion/png-to-svg/), и [SVG to PNG](https://products.aspose.com/slides/ru/androidjava/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides поддерживает изображения популярных форматов, таких как JPEG, PNG, BMP, GIF и другие. 

## **Добавление локальных изображений на слайды**

Вы можете добавить одно или несколько изображений, хранящихся на вашем компьютере, на слайд презентации. Ниже приведён пример Java‑кода, показывающий, как добавить изображение на слайд:

```java
import com.aspose.slides.*;

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
    pres.dispose();
}
```

## **Добавление изображений из интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, не хранится на компьютере, вы можете добавить его непосредственно из интернета. 

Ниже показан пример Java‑кода, демонстрирующий, как добавить изображение из интернета на слайд:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

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

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Добавление изображений в шаблоны слайдов**

Шаблон слайда хранит и контролирует информацию, такую как тема и макет для слайдов, использующих его. При добавлении изображения в шаблон слайда изображение появляется на каждом слайде, основанном на этом шаблоне. 

Ниже приведён пример Java‑кода, показывающий, как добавить изображение в шаблон слайда:

```java
import com.aspose.slides.*;

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
    pres.dispose();
}
```

## **Добавление изображений в качестве фона слайдов**

Вы можете использовать картинку в качестве фона одного или нескольких слайдов. Подробности см. в *[Setting Images as Backgrounds for Slides](/slides/ru/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Содержимое SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgimage/). Полученный объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) затем можно добавить в коллекцию изображений презентации и использовать для создания рамки картинки.

Ниже показан пример Java, импортирующий автономную строку SVG. Все изображения, стили и прочие ресурсы, используемые этим SVG, встроены непосредственно в содержимое SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Импорт SVG‑содержимого с внешними ресурсами**

SVG‑файлы, экспортированные из дизайнерских инструментов, редакторов диаграмм, систем иконок и веб‑конвейеров, могут ссылаться на ресурсы, хранящиеся за пределами документа SVG. Например, SVG может содержать ссылку на изображение вроде `images/photo.png`, значение CSS `url(...)` или URL шрифта.

Чтобы импортировать такое SVG‑содержимое, создайте реализацию [IExternalResourceResolver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iexternalresourceresolver/) и передайте её вместе с базовым URI в соответствующий конструктор [SvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgimage/). Базовый URI определяет расположение SVG‑документа и используется для разрешения относительных ссылок.

Интерфейс [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) предоставляет доступ к информации об импортированном SVG:

- `getSvgContent()` возвращает разметку SVG в виде строки.  
- `getSvgData()` возвращает содержимое SVG в виде массива байтов.  
- `getBaseUri()` возвращает базовый URI, используемый для относительных ссылок.  
- `getExternalResourceResolver()` возвращает резольвер, назначенный для SVG‑изображения.  

### **Реализация резольвера внешних ресурсов**

У резольвера два метода:

- `resolveUri` объединяет базовый URI и относительную ссылку ресурса и возвращает абсолютный URI. Возвращайте `null`, когда ссылка не может быть разрешена или запрещена.  
- `getEntity` возвращает поток для чтения абсолютного URI ресурса. Возвращайте `null`, когда ресурс отсутствует, заблокирован или недоступен. При необходимости можно вернуть поток‑запаску.  

Ниже показан резольвер, который загружает связанные ресурсы только из разрешённого локального каталога. Сетевые ресурсы и пути за пределами разрешённого каталога блокируются. При отсутствии ссылки на изображение возвращается альтернативное изображение.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Этот резольвер намеренно позволяет только локальные файлы.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Использовать запасной вариант только для ресурсов изображений. Возврат потока изображения
            // для отсутствующего шрифта или таблицы стилей будет недопустим.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Разрешение связанных ресурсов во время импорта SVG**

Предположим, что `assets/diagram.svg` содержит относительную ссылку, например:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ниже пример Java, передающий URI SVG‑файла в качестве базового URI и предоставляющий пользовательский резольвер. Резольвер преобразует относительную ссылку на изображение в абсолютный URI и возвращает поток, содержащий связанный ресурс, пока Aspose.Slides обрабатывает SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Базовый URI указывает расположение SVG‑документа.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage предоставляет исходное содержимое, бинарные данные, базовый URI и резольвер.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Класс `SvgImage` также предоставляет перегрузки, принимающие данные SVG в виде массива байтов или входного потока, вместе с резольвером внешних ресурсов и базовым URI.

{{% alert title="Important" color="warning" %}}
Резольвер ресурсов делает внешние ресурсы доступными во время обработки и рендеринга SVG в Aspose.Slides. Он не изменяет исходную разметку SVG и не встраивает автоматически разрешённые ресурсы в неё.  

Когда объект `ISvgImage` добавляется в коллекцию изображений презентации, файл PPTX может содержать как оригинальное представление SVG, так и растровую запасную картинку. Связанный ресурс может появиться в сгенерированном запасном изображении, тогда как относительная ссылка вроде `images/photo.png` остаётся неизменной в сохранённом SVG. Приложение, отображающее нативное представление SVG, может опустить связанное содержимое, если оригинальный внешний ресурс недоступен.  
{{% /alert %}}

### **Создание переносимого SVG‑изображения**

Чтобы создать SVG‑картинку, не зависящую от внешних файлов, сделайте SVG автономным перед созданием `SvgImage`. Например, замените URL‑ы связанных изображений на URI `data:` с встроенными данными изображения:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

После того как все необходимые ресурсы будут встроены в содержимое SVG, создайте `SvgImage`, добавьте его в коллекцию изображений презентации и вставьте в рамку картинки, как показано в предыдущем примере.

### **Обработка отсутствующих или заблокированных ресурсов**

Возвращайте `null` из `resolveUri`, когда URI ресурса недопустим, запрещён или не может быть разрешён. Возвращайте `null` из `getEntity`, когда ресурс нельзя прочитать. Aspose.Slides продолжит обработку SVG без этого ресурса, если это возможно.  

Запасной поток можно вернуть для отсутствующего ресурса, но его содержимое должно соответствовать запрашиваемому типу ресурса. Например, возвращайте поток изображения только для отсутствующей картинки, а не для шрифта или таблицы стилей.

{{% alert title="Security" color="warning" %}}
Не разрешайте произвольные пути файлов или неограниченные сетевые URL‑ы из ненадёжных SVG‑файлов. Ограничьте разрешённые схемы, каталоги и хосты. Для сетевых ресурсов также применяйте тайм‑ауты соединения, ограничения размера ответа и проверку содержимого.  
{{% /alert %}}

## **Преобразование SVG в набор фигур**

Aspose.Slides может преобразовать SVG в набор фигур, аналогично соответствующей функции в PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Эта функция реализована перегрузкой метода [addGroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection), принимающего объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISvgImage) в качестве первого аргумента.

Ниже пример Java‑кода, показывающий, как использовать этот метод для преобразования SVG‑файла в набор фигур:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Имя исходного SVG‑файла.
String svgFileName = "sample.svg";

// Имя выходного файла презентации.
String outPptxPath = "presentation.pptx";

// Создать новую презентацию.
IPresentation presentation = new Presentation();
try {
    // Прочитать содержимое SVG‑файла.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Создать объект SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получить размер слайда.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Преобразовать SVG‑изображение в группу фигур и масштабировать её до размеров слайда.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Сохранить презентацию в формате PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Добавление изображений в формате EMF на слайды**

Aspose.Slides for Android via Java позволяет генерировать EMF‑изображения из листов Excel с помощью Aspose.Cells и добавлять их на слайды презентации.

Ниже пример Java‑кода, демонстрирующий, как это сделать:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Сохранить книгу в поток.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Добавить файл как есть, чтобы изображение осталось векторным EMF, а не было растеризовано.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая изображения, используемые фигурами слайдов. В этом разделе описываются несколько способов обновления изображений в коллекции. Вы можете заменить изображение, используя необработанные байтовые данные, объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) или другое изображение, уже существующее в коллекции.

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) и замените целевое изображение этим объектом.  
5. В третьем подходе замените целевое изображение изображением, уже существующим в коллекции изображений презентации.  
6. Сохраните изменённую презентацию в виде файла PPTX.  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Создать экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Первый способ.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Второй способ.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

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
С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) вы легко анимируете текст и создаёте GIF‑изображения из текста. 
{{% /alert %}}

## **FAQ**

**Сохраняется ли исходное разрешение изображения после вставки?**  
Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/androidjava/picture-frame/) масштабируется на слайде и от сжатия при сохранении.

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**  
Разместите логотип на слайде‑мастере или макете и замените его в коллекции изображений презентации —обновления распространятся на все элементы, использующие этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**  
Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.

**Как установить картинку в качестве фона для нескольких слайдов сразу?**  
[Назначьте изображение как фон](/slides/ru/androidjava/presentation-background/) на мастер‑слайде или соответствующем макете —все слайды, использующие этот мастер/макет, унаследуют фон.

**Как предотвратить чрезмерный размер презентации из‑за большого количества картинок?**  
Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте сжатие при сохранении и размещайте повторяющиеся графики в мастере, где это уместно.