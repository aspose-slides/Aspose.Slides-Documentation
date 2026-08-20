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
description: "Конвертировать устаревшие файлы PPT в PPTX на Android с помощью Aspose.Slides. Включает примеры на Java для конвертации одного файла и пакетной обработки, обработку ошибок и примечания о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Android via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов, и объясняет, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Pptx). Блок `finally` освобождает презентацию и её ресурсы.

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

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/#Pptx). Держите пути ввода и вывода различными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в указанном каталоге. Каждый файл обрабатывается независимо, поэтому сбой конвертации одного файла не останавливает остальную партию.

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

Для производственных нагрузок запишите полное исключение в журнал, решите, можно ли перезаписать существующий файл вывода, и запишите имена файлов с ошибками в очередь повторной попытки или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. Смотрите [Password-Protected Presentations](/androidjava/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конвертация обычно сохраняет слайды, шаблоны, макеты, текст, формы, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, не имеющая эквивалента в PPTX или не поддерживаемая библиотекой, может быть нормализована, удалена или отображена иначе.

Проверьте конвертированный файл, если в нём есть анимации, переходы, встроенные или связанные объекты OLE, элементы управления ActiveX, встроенные медиафайлы, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте подходящий рабочий процесс с поддержкой макросов, если VBA должен оставаться доступным. Также убедитесь, что требуемые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или отображаться презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество и содержание ключевых слайдов, затем сравните его внешний вид и поведение в слайд-шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в текущих версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который легче проверять и восстанавливать, чем устаревший двоичный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверку точности.

Если вместо этого нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации для конкретного формата в [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/), а не предполагаете, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн конвертер**

Для одиночного файла или быстрой сравнительной проверки можно использовать [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторных конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте API Android via Java.

## **Связанные статьи**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Сохранить презентации на Android](/androidjava/save-presentation/)
- [Поддерживаемые форматы файлов](/androidjava/supported-file-formats/)
- [Открыть презентации на Android](/androidjava/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Android via Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конвертация PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентаций, но точная точность не гарантирована для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если он содержит макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если вы предоставите правильный пароль при загрузке файла. Отсутствие пароля или неверный пароль приводит к сбою операции загрузки.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных вам просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертируется иначе.