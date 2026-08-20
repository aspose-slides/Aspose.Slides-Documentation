---
title: Конвертировать PPT в PPTX в Java
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/java/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX в Java с помощью Aspose.Slides. Включает примеры Java для конвертации одного файла и пакетной конвертации, обработки ошибок и заметок о точности."
---
## **Обзор**

PPT — это устаревший бинарный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. В этой статье показано, как конвертировать один файл или каталог файлов и объясняется, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/#Pptx). Блок `finally` освобождает презентацию и её ресурсы.

```java
// Загрузить устаревшую презентацию PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Расширение файла само по себе не выбирает формат вывода; это делает аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/#Pptx). Оставляйте входные и выходные пути разными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому ошибка конвертации одного файла не останавливает остальную пачку.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Для производственных задач регистрируйте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена файлов с ошибками в очередь повторной попытки или проверки. Повреждённые файлы, файлы, защищённые паролем и открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Password-Protected Presentations](/java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, образцы, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, не имеющая эквивалента в PPTX, или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверяйте полученный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, если VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или отображаться конвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество слайдов и содержимое, затем сравните его внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в актуальных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который легче исследовать и восстанавливать, чем устаревший бинарный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверку точности.

Если вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации по конкретному формату в статье [Convert Presentations to Multiple Formats](/java/convert-presentation/), а не предполагаете, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой проверки можно использовать [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конверсий, пакетной обработки или обработки ошибок на уровне приложения используйте Java API.

## **Связанные статьи**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Сохранение презентаций в Java](/java/save-presentation/)
- [Поддерживаемые форматы файлов](/java/supported-file-formats/)
- [Открытие презентаций в Java](/java/open-presentation/)

## **Часто задаваемые вопросы**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX всё содержимое точно?**

Она сохраняет обычное содержимое презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте полученный файл, если в нём есть макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствие пароля или его неверное значение приводит к ошибке загрузки.

**Нужно ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертируется иначе.