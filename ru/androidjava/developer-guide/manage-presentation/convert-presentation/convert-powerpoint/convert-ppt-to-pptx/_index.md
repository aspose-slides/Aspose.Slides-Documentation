---
title: Конвертировать PPT в PPTX на Android
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX на Android с помощью Aspose.Slides. Включает примеры на Java для конвертации одиночного файла и пакетной обработки, обработки ошибок и заметки о точности."
---
## **Обзор**

PPT – это наследуемый бинарный формат PowerPoint, тогда как PPTX – более новый формат Open XML. Aspose.Slides for Android via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как преобразовать один файл или каталог файлов и объясняет, что проверить после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) с аргументом [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Pptx). Блок `finally` освобождает презентацию и её ресурсы.

```java
// Загрузить устаревшую PPT‑презентацию.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Pptx). Держите пути ввода и вывода разными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в указанном каталоге. Каждый файл обрабатывается независимо, поэтому ошибка конвертации одного файла не останавливает остальную часть пакета.

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

Для производственных нагрузок записывайте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и сохраняйте имена файлов с ошибками в очередь повторной попытки или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Password-Protected Presentations](/androidjava/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Обычно конвертация сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, которой нет эквивалента в PPTX, или которая не поддерживается библиотекой, может быть нормализована, опущена или отображена иначе.

Проверяйте преобразованный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные мультимедийные файлы, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться презентация.

Для важных документов повторно откройте сгенерированный PPTX программно и проверьте количество слайдов и основное содержимое, затем сравните его внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который легче проанализировать и восстановить, чем унаследованный бинарный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверку точности.

Если вместо этого нужен PDF, HTML, изображения, XPS или иной тип вывода, используйте рекомендации по конкретному формату в статье [Convert Presentations to Multiple Formats](/slides/ru/androidjava/convert-presentation/), а не предполагая, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой проверки вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте API Android via Java.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/ru/androidjava/save-presentation/)
- [Supported File Formats](/slides/ru/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/ru/androidjava/open-presentation/)

## **FAQ**

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Android via Java загружает и сохраняет файлы презентаций без необходимости наличия Microsoft PowerPoint.

**Сохранит ли конвертация PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентаций, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверяйте сгенерированный файл, если в нём есть макросы, OLE‑ или ActiveX‑объекты, медиа, специализированные анимации или редкие шрифты.

**Можно ли конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствие пароля или неверный пароль приводит к ошибке загрузки.

**Стоит ли удалять файл PPT после конвертации?**

Сохраняйте оригинал до тех пор, пока не проверите PPTX в нужных просмотрах и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция была преобразована иначе.