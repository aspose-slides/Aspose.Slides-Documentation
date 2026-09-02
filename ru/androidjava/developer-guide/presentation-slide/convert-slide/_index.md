---
title: Преобразование слайдов презентации в изображения на Android
linktitle: Слайд в изображение
type: docs
weight: 35
url: /ru/androidjava/convert-slide/
keywords:
- конвертировать слайд
- экспортировать слайд
- слайд в изображение
- сохранить слайд как изображение
- слайд в EMF
- слайд в PNG
- слайд в JPEG
- слайд в bitmap
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Преобразуйте слайды из презентаций PPT, PPTX и ODP в PNG, JPEG, GIF, TIFF, EMF и другие форматы изображений на Android с помощью Aspose.Slides."
---
## **Введение**

Aspose.Slides for Android via Java может рендерить отдельные слайды из презентаций PowerPoint и OpenDocument в PNG, JPEG, GIF, TIFF и другие форматы изображений.

Чтобы конвертировать слайд в изображение, выполните следующие шаги:

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Выберите слайд, который нужно отобразить.
3. При необходимости настройте рендеринг с помощью класса [RenderingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/renderingoptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/).
4. Вызовите метод [ISlide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getImage--) . Он возвращает объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/).
5. Вызовите метод [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) и укажите формат вывода значением [ImageFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/).

## **Конвертировать слайд в PNG‑изображение**

Самый простой способ использует настройки рендеринга по умолчанию. Полученный объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) можно обработать в памяти или сохранить в файл.

Ниже приведён пример Java, который рендерит первый слайд и сохраняет его как PNG‑изображение:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Конвертировать слайды в изображения с пользовательскими размерами**

Используйте перегрузку [ISlide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) , принимающую значение [Size](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.android/size/) для рендеринга слайда с точными пиксельными размерами.

В примере создаётся JPEG‑изображение 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Конвертировать слайды с заметками и комментариями в изображения**

По умолчанию изображения слайдов не включают заметки или комментарии. Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notescommentslayoutingoptions/) в метод [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) чтобы управлять расположением заметок и комментариев.

В примере показано размещение усечённых заметок под слайдом и комментариев справа от него:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Предупреждение" color="warning" %}}
Для конвертации слайд‑в‑изображение не передавайте [BottomFull](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notespositions/) в метод [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Заметки могут содержать больше текста, чем может вместить фиксированный размер изображения. Используйте вместо этого [BottomTruncated](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Конвертировать слайды в изображения с использованием TIFF‑опций**

Класс [TiffOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/) позволяет управлять размером, разрешением и другими свойствами создаваемого TIFF‑изображения.

В примере первый слайд рендерится как TIFF‑изображение 2160 × 2880 с разрешением 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Конвертировать все слайды в изображения**

Пройдитесь по коллекции слайдов, чтобы преобразовать всю презентацию в набор изображений. Скрытые слайды включаются, если явно не исключить их.

В примере каждый слайд рендерится как JPEG‑изображение с горизонтальными и вертикальными коэффициентами масштабирования, равными 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Создать вывод в формате Enhanced Metafile**

Enhanced Metafile (EMF) полезен, когда векторная графика должна быть передана Microsoft Office или другим приложениям Windows, поддерживающим Windows‑метафайлы. В отличие от растрового изображения, EMF сохраняет векторные операции рисования, которые масштабируются без потери резкости. Однако EMF в основном является совместимым форматом для приложений с поддержкой Windows‑метафайлов, а не универсальным форматом обмена. Кроме того, сложное содержимое слайда, такое как растровые изображения и некоторые эффекты, может быть сохранено как растр внутри векторного контейнера метафайла.

### **Экспортировать слайд в EMF**

Метод [ISlide.writeAsEmf](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) записывает [ISlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/) в целевой поток в формате EMF. Ниже пример, который загружает презентацию, выбирает первый слайд и записывает его в поток EMF‑файла:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Вызвавший код отвечает за закрытие потока, переданного в [ISlide.writeAsEmf](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-), как показано выше.

### **Конвертировать SVG‑изображение в EMF и добавить его в презентацию**

Используйте [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) для преобразования содержимого SVG в EMF. Полученные байты можно добавить в презентацию через [IImageCollection.addImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) и разместить на слайде с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

В примере создаётся [SvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgimage/) из SVG‑разметки, преобразуется в EMF в памяти, вставляется в первый слайд и сохраняется презентация:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) не получает владение целевым потоком. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) хранит все сгенерированные данные в памяти, поэтому перед вызовом `toByteArray` не требуется сбрасывать позицию. Возвратный массив байтов остаётся валидным после закрытия потока.

Генерация EMF доступна на поддерживаемых версиях Android и конфигурациях устройств, но рендеринг может различаться, если шрифты или графические зависимости недоступны. Установите шрифты, использованные в исходном содержимом, или настройте подходящие замены, следуйте [installation guide](/slides/ru/androidjava/install-aspose-slides-for-android-via-java/) для Aspose.Slides for Android via Java и проверьте результат в целевом приложении, потребляющем EMF. Приложения на платформах, не являющихся Windows, часто имеют ограниченную или непостоянную поддержку отображения и редактирования Windows‑метафайлов.

## **Рендеринг цветных эмодзи**

{{% alert title="Примечание" color="info" %}}
Чтобы корректно рендерить цветные эмодзи при конвертации слайдов презентации в изображения, шрифты эмодзи, используемые в презентации, должны быть установлены и доступны в системе, где выполняется конверсия. Например, если презентация использует **Segoe UI Emoji**, а этот шрифт отсутствует, эмодзи могут отображаться монохромно в результирующих изображениях.
{{% /alert %}}

## **Вопросы и ответы**

**Поддерживает ли Aspose.Slides рендеринг слайдов с анимацией?**

Нет. Метод [ISlide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getImage--) рендерит статическое изображение слайда и не экспортирует анимацию.

**Можно ли экспортировать скрытые слайды как изображения?**

Да. Скрытые слайды могут быть отрендерены так же, как обычные. Включите их в цикл обработки, как показано в примере выше.

**Сохраняются ли тени и другие эффекты в изображениях слайдов?**

Да. Aspose.Slides рендерит тени, прозрачность и другие поддерживаемые графические эффекты в изображениях слайдов.