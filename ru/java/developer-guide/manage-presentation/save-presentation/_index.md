---
title: Сохранение презентаций в Java
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/java/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- сохранение прогресса
- Java
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки в Java с помощью Aspose.Slides, а также настройте вывод PPTX и отчёт о прогрессе."
---
## **Обзор**

После того как вы создадите презентацию или [откроете существующую](/slides/ru/java/open-presentation/), используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи результата. Aspose.Slides for Java может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и доступные параметры вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Значение формата определяет тип файла, создаваемого Aspose.Slides.

Следующий пример создает презентацию и сохраняет её как файл PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Добавьте или измените содержимое презентации здесь.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в их исходном формате**

Для примеров обнаружения файлов и потоков, поведения новосозданных презентаций и различий между исходным и выходным форматами см. [Determine the Original Presentation Format](/slides/ru/java/detect-presentation-source-format/).

В пакетном приложении формат входных данных может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью метода [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getSourceFormat--). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sourceformat/) в [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideutil/#toSaveFormat-int-), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/), а затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи изменённой презентации.

Следующий полный пример обрабатывает каждый файл во входном каталоге, обновляет его заголовок и сохраняет в выходной каталог в том формате, из которого он был загружен:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideutil/#toSaveFormat-int-) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он отображает только исходные форматы презентаций; он не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или неверного значения [SourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sourceformat/) приводит к [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть идентифицирован как PPT. Если необходимо сохранить эти устаревшие подтипы, сохраняйте оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени выходного файла и формата.

## **Сохранение презентаций в потоки**

Чтобы сохранить презентацию, не полагаясь на конечный путь к файлу, передайте поток для записи и значение [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Этот подход полезен, когда вывод необходимо вернуть из веб‑службы, сохранить в базе данных или обработать в памяти.

Следующий пример сохраняет новую презентацию в поток файла:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций с предопределённым типом представления**

Вы можете указать представление, в котором PowerPoint изначально открывает сохранённую презентацию. Используйте метод [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#setLastView-int-) с значением [ViewType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewtype/) перед сохранением.

Следующий пример настраивает представление Slide Master как начальное представление:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/) и используйте его метод [setConformance](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/#setConformance-int-) с параметром [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Затем передайте параметры в метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждой записи, общий размер архива и количество записей. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превышать эти ограничения. Расширения ZIP64 повышают соответствующие лимиты размера и количества записей.

Используйте метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#IfNecessary) использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Never) отключает ZIP64 расширения.
- [Always](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Always) всегда записывает ZIP64 расширения.

Следующий пример всегда включает ZIP64 расширения для выходной презентации:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Если используется [Zip64Mode.Never](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Never) и презентация не помещается в стандартные ограничения ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX вы можете сбалансировать скорость сохранения и размер файла, используя метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Класс [CompressionLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/) предоставляет следующие значения:

- [None](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#None) сохраняет данные без сжатия.
- [Level1](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level1) обеспечивает самое быстрое сжатие и наибольший размер сжатого вывода.
- [Level2](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level2)‑[Level5](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level5) постепенно предпочитают более маленький вывод в ущерб скорости сохранения.
- [Level6](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level6) балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- [Level7](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level7) и [Level8](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level8) дальше предпочитают более маленький вывод в ущерб скорости.
- [Level9](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level9) обеспечивает самое сильное сжатие и требует наибольшего времени обработки.

Следующий пример сохраняет презентацию без сжатия:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Следующий пример использует максимальный уровень сжатия:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Когда презентация сохраняется как PPTX, метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) управляет её миниатюрой документа:

- `true` восстанавливает миниатюру во время операции сохранения. Это значение по умолчанию.
- `false` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides её не генерирует.

Следующий пример сохраняет презентацию без обновления её миниатюры:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Чтобы контролировать процесс сохранения, реализуйте интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/) и передайте реализацию в метод [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides затем вызывает метод [IProgressCallback.reporting](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/#reporting-double-) с значениями прогресса во время экспорта.

Следующий пример выводит прогресс экспорта PDF в консоль:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на базе Aspose.Slides API. Он сохраняет выбранные слайды из презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое сохранение»?**

Нет. Каждая операция сохранения записывает полностью готовый выходной файл, а не обновляет только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/java/multithreading/). Доступ к каждому экземпляру и его сохранение допускаются только из одного потока одновременно.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/java/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохранённой презентации всё равно необходимо иметь доступ к их расположениям.

**Могу ли я сохранять метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/java/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.