---
title: Получение и обновление информации о презентации на Java
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- изучить PPTX
- изучить PPT
- изучить ODP
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с использованием Java для более быстрых выводов и более умных аудитов контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные без создания полной модели объектов презентации. Это полезно, когда необходимо классифицировать файлы, создать инвентарь или проверить свойства перед тем, как решить, загружать и обрабатывать содержимое презентации.

В этой статье показана легковесная проверка с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/) и [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/), а также целевые обновления с помощью [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/).

## **Проверка формата презентации**

Если у вас уже загружена презентация, см. [Determine the Original Presentation Format](/slides/ru/java/detect-presentation-source-format/) для обнаружения после загрузки и ограничений устаревших потоков PPT, PPS и POT.

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) для проверки файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Метод [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) сообщает обнаруженный формат, например PPTX, PPT или ODP.

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

## **Создание легковесного инвентаря презентаций**

Когда вы обрабатываете множество файлов презентаций, может потребоваться компактный инвентарь для проверки, индексации или системы управления документами. В этом случае используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) для получения объекта [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/), а затем вызовите [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getSlides--) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getNotes--) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getWords--) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Общее количество аудио- и видеоклипов. |

Следующий пример считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и выводит компактный инвентарь. Он также комбинирует [getHeadingPairs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) с [getTitlesOfParts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

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

Каждый [IHeadingPair](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iheadingpair/) предоставляет имя группы и количество элементов в этой группе. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) возвращает плоский упорядоченный массив, поэтому используйте количество последовательных заголовков, указанное каждой парой заголовков.

### **Сохранённые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не проходит по модели объектов презентации для пересчёта этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, последним сохранившее файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчётов слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пары заголовков и названия частей. Доступность зависит от того, какие свойства записал производитель документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑резюме документа. Если свойство отсутствует или не было обновлено производителем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не рассчитывает его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не соответствуют каждому расширенному свойству PowerPoint. Метаданные о скрытых слайдах, слайдах‑заметках, мультимедиа, парах заголовков и названиях частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо удостовериться в реальном содержимом презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), также можно изменить без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Примените изменения с помощью [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), а затем запишите связанную презентацию с помощью [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Следующее изображение показывает исходные свойства документа PowerPoint презентации.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

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

Следующее изображение показывает изменённые свойства документа PowerPoint презентации.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/java/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getFontsManager--). Вызовите [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) для получения встроенных шрифтов и [IFontsManager.getFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFonts--) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для отображения, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Когда достаточно сохранённых метаданных документа, прочитайте [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) через [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Это подходит для легковесного инвентаря. Если презентация изменялась в памяти, сохранённые метаданные могут отсутствовать или быть устаревшими, либо требуется проверить живые значения, тогда пройдите по [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) и проверьте метод [ISlide.getHidden](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getHidden--) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlideSize--). Используйте [ISlideSize.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getSize--) и [ISlideSize.getOrientation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getOrientation--) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chart/) и вызовите [IChartData.getDataSourceType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getDataSourceType--). Для внешней книги вызовите [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности ресурса требует отдельной проверки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Единого свойства сложности нет. Пройдите по [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) и коллекции [IBaseSlide.getShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getShapes--) каждого слайда. Используйте количество фигур и наличие крупных изображений, эффектов, анимаций или мультимедиа как сигналы, и измерьте типичный рендеринг или экспорт перед тем, как считать слайд подтверждённым узким местом производительности.