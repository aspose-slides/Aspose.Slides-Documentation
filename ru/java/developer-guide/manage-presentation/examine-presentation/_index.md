---
title: Получить и обновить информацию о презентации в Java
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- исследовать PPTX
- исследовать PPT
- исследовать ODP
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Java для более быстрых инсайтов и умных проверок контента."
---
## **Обзор**

Aspose.Slides может определять формат презентации и читать её метаданные документа без создания полной модели объектной структуры презентации. Это полезно, когда необходимо классифицировать файлы, создавать инвентарь или проверять свойства перед тем, как решить, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируется лёгкая проверка с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/) и [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/), а также целевые обновления с помощью [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/).

## **Проверка формата презентации**

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

## **Создание лёгкого инвентаря презентаций**

Когда вы обрабатываете множество файлов презентаций, может потребоваться компактный инвентарь для проверки, индексирования или системы управления документами. В данном случае используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) чтобы получить объект [IPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/), а затем вызовите [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и не требует обхода полной модели объектной структуры презентации.

Расширенные свойства, предоставляемые [IDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getSlides--) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getNotes--) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getWords--) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Общее количество аудио- и видеоклипов. |

Следующий пример считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и выводит компактный инвентарь. Он также комбинирует [getHeadingPairs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) с [getTitlesOfParts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) , чтобы отобразить группы содержимого, такие как шрифты, темы и заголовки слайдов.

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

Каждый [IHeadingPair](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iheadingpair/) предоставляет имя группы и количество элементов в этой группе. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) возвращает плоский упорядоченный массив, поэтому используйте количество последовательных заголовков, указанных для каждой пары заголовков.

### **Сохранённые метаданные и ограничения форматов**

Свойства инвентаря, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектной структуры презентации для пересчёта этих значений в этом вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, последним сохранившее файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчётов слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пар заголовков и названий частей. Доступность зависит от того, какие свойства записал производитель документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства сводки документа. Если свойство отсутствует или не было обновлено производителем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не вычисляет его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не соответствуют каждому специфическому расширенному свойству PowerPoint. Метаданные скрытых слайдов, слайдов‑заметок, мультимедиа, пар заголовков и названий частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте подход лёгких метаданных для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектной структуры, когда результат должен отражать изменения в памяти или когда необходимо проверить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) также можно изменять без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Примените изменения с помощью [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), а затем запишите связанную презентацию с помощью [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

На следующем изображении показаны исходные свойства документа PowerPoint-презентации.

![Исходные свойства документа PowerPoint-презентации](input_properties.png)

В следующем примере изменяется заголовок и время последнего сохранения, и результат записывается в новый файл:

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

![Изменённые свойства документа PowerPoint-презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты смотрите следующие статьи:

- [Защита презентаций паролем](/slides/ru/java/password-protected-presentation/)
- [Защита презентаций от записи](/slides/ru/java/write-protected-presentation/)

## **Часто задаваемые вопросы**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getFontsManager--). Вызовите [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) для получения встроенных шрифтов и [IFontsManager.getFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFonts--) для получения шрифтов, используемых в презентации. Сравните оба результата, чтобы найти шрифты, необходимые для отображения, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и сколько их?**

Если метаданные документа достаточны, считайте [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) через [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, сохранённые метаданные могут отсутствовать или быть устаревшими, либо нужно проверить живые значения, пройдите по [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) и проверьте метод [ISlide.getHidden](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getHidden--) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlideSize--). Используйте [ISlideSize.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getSize--) и [ISlideSize.getOrientation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/#getOrientation--) , чтобы сравнить текущие настройки с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ узнать, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chart/) и вызовите [IChartData.getDataSourceType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getDataSourceType--). Для внешней рабочей книги вызовите [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Тип и путь источника данных указывают на внешнюю ссылку, но проверка доступности ресурса требует отдельной проверки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Единого свойства сложности не существует. Обойдите [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) и коллекцию [IBaseSlide.getShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getShapes--) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы, а также измерьте представительный рендер или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.