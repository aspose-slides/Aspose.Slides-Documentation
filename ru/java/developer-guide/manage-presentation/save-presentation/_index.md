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
- прогресс сохранения
- Java
- Aspose.Slides
description: "Узнайте, как сохранять презентации в Java с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Open Presentations in Java](/slides/ru/java/open-presentation/) описал, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) для открытия презентации. В этой статье объясняется, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вам понадобится сохранить её после завершения работы. С помощью Aspose.Slides for Java вы можете сохранять в **файл** или **поток**. Эта статья объясняет различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохранить презентацию в файл можно, вызвав метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. В следующем примере показано, как сохранить презентацию с помощью Aspose.Slides.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Выполните здесь некоторые действия...

    // Сохраните презентацию в файл.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `save` класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Презентацию можно записать во множество типов потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Сохраните презентацию в поток.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальное представление, которое PowerPoint использует при открытии сгенерированной презентации, с помощью класса [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/). Используйте метод [setLastView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#setLastView-int-) с значением из перечисления [ViewType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/) и установите его свойство conformance при сохранении. Если задать [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), файл будет сохранён в строгом формате Office Open XML.

В примере ниже создаётся презентация и сохраняется в строгом формате Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Сохраните презентацию в строгом формате Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑ар­хив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве до 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64.

Метод [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML.

Этот метод можно использовать со следующими режимами:

- [IfNecessary](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#IfNecessary) использует расширения формата ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Never) никогда не использует расширения формата ZIP64.
- [Always](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Always) всегда использует расширения формата ZIP64.

В следующем коде демонстрируется, как сохранить презентацию в файл PPTX с включёнными расширениями формата ZIP64:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
При сохранении с использованием [Zip64Mode.Never](https://reference.aspose.com/slides/ru/java/com.aspose.slides/zip64mode/#Never) будет выброшено исключение [PptxException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с большими презентациями вы можете регулировать уровень сжатия, чтобы сбалансировать размер файла и время обработки. В зависимости от требований вы можете предпочитать более быструю обработку или меньший размер окончательного файла.

Aspose.Slides предоставляет метод [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), который позволяет указать уровень сжатия, используемый при сохранении презентации в формате Office Open XML.

Доступны следующие уровни сжатия:

- [**None**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#None): Сжатие не применяется. Файлы сохраняются как есть.
- [**Level1**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level1): Самое быстрое сжатие с наименьшим коэффициентом сжатия.
- [**Level2**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level2): Более быстрое сжатие с немного лучшим коэффициентом сжатия, чем **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level3): Обеспечивает лучшее сжатие, чем **Level2**, со средним влиянием на время обработки.
- [**Level4**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level4): Обеспечивает лучшее сжатие, чем **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level5): Обеспечивает улучшенное сжатие по сравнению с **Level4**, но требует дополнительного времени обработки.
- [**Level6**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level6): Стандартное сжатие, обеспечивающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- [**Level7**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level7): Обеспечивает лучшее сжатие, чем **Level6**, но с более медленной обработкой.
- [**Level8**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level8): Обеспечивает лучшее сжатие, чем **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compressionlevel/#Level9): Максимальное сжатие. Даёт минимальный размер файла, но требует самое длительное время обработки.

В следующем примере демонстрируется, как сохранить презентацию в файл PPTX *без сжатия*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) управляет генерацией миниатюры при сохранении презентации в PPTX:

- Если установлено `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет сгенерирована.

В коде ниже презентация сохраняется в PPTX без обновления её миниатюры.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/) используется через метод `setProgressCallback`, предоставляемый интерфейсом [ISaveOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveoptions/). Присвойте реализацию [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/) с помощью `setProgressCallback`, чтобы получать обновления прогресса сохранения в процентах.

В следующем фрагменте кода показано, как использовать `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Используйте здесь значение процента прогресса.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), использующее собственное API. Приложение позволяет разбить презентацию на несколько файлов, сохранив выбранные слайды в новые файлы PPTX или PPT.
{{% /alert %}}

## **FAQ**

**Поддерживается ли «быстрое сохранение» (инкрементное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементное «быстрое сохранение» не поддерживается.

**Безопасно ли сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/java/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/java/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли установить/сохранить метаданные документа (Автор, Название, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/java/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.