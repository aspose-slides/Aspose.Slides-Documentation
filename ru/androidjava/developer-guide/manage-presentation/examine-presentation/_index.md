---
title: Получить и обновить информацию о презентации на Android
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/androidjava/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Java для более быстрого анализа и умных аудитов контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные без создания полной модели объекта презентации. Это полезно, когда нужно классифицировать файлы, построить инвентарь или проверить свойства перед тем, как решить, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируется лёгкая проверка с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/) и [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/), а также целевые обновления через [IDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/).

## **Check a Presentation Format**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) для проверки файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). Метод [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Build a Lightweight Presentation Inventory**

Когда вы обрабатываете множество файлов презентаций, может потребоваться компактный инвентарь для валидации, индексирования или системы управления документами. В этом сценарии используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) для получения объекта [IPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/), а затем вызовите [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и не требует обхода полной модели объекта презентации.

Расширенные свойства, предоставляемые [IDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Общее количество аудио‑ и видеоклипов. |

Следующий пример читает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и выводит компактный инвентарь. Он также сочетает [getHeadingPairs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) с [getTitlesOfParts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Каждый [IHeadingPair](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iheadingpair/) поставляет имя группы и количество элементов в этой группе. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) возвращает плоский упорядоченный массив, поэтому нужно потреблять количество последовательных заголовков, указанных каждой парой заголовков.

### **Stored Metadata and Format Limitations**

Свойства инвентаря, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объекта презентации для пересчёта этих значений при этом вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, которое последним сохраняло файл, не обновило свои свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчётов слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пар заголовков и названий частей. Доступность зависит от того, какие свойства были записаны создателем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑резюме документа. Если свойство отсутствует или не было обновлено создателем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не вычисляет его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не отображаются на каждое расширенное свойство PowerPoint. Метаданные скрытых слайдов, заметок, мультимедиа, пар заголовков и названий частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объекта, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержание презентации.

## **Update Presentation Properties**

Свойства, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), также могут быть изменены без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). Примените изменения с помощью [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), а затем запишите связанную презентацию с помощью [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Следующее изображение отображает исходные свойства документа.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Следующее изображение отображает обновлённые свойства документа.

![Обновлённые свойства документа презентации PowerPoint](output_properties.png)

## **Useful Links**

Для связанных проверок безопасности и параметров защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/androidjava/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getFontsManager--). Вызовите [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) для получения встроенных шрифтов и [IFontsManager.getFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для рендеринга, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и сколько их?**

Когда метаданные документа достаточно, прочитайте [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) через [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, сохранённые метаданные могут быть отсутствующими или устаревшими, либо нужно проверить живые значения, пройдя по [Presentation.getSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlides--) и проверив у каждого слайда метод [ISlide.getHidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getHidden--).

**Можно ли определить, используется ли пользовательский размер и ориентация слайдов, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlideSize--). Используйте [ISlideSize.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidesize/#getSize--) и [ISlideSize.getOrientation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidesize/#getOrientation--) для сравнения текущих настроек с ожидаемыми предустановленными размерами и ориентацией.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждый [Chart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/) и вызовите [IChartData.getDataSourceType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Для внешней книги вызовите [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности цели требует отдельной проверки ресурсов.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Нет единого свойства сложности. Пройдите по [Presentation.getSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlides--) и по коллекции [IBaseSlide.getShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getShapes--) каждого слайда. Используйте количество фигур и наличие крупных изображений, эффектов, анимаций или мультимедиа как сигналы отбора, и измерьте репрезентативный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.