---
title: Конвертировать PPT в PPTX на Java
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
description: "Конвертировать устаревшие файлы PPT в PPTX на Java с помощью Aspose.Slides. Включает примеры Java для конвертации одного файла и пакетной, обработку ошибок и примечания о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, в то время как PPTX — более новый формат Open XML. Aspose.Slides for Java может загружать файл PPT и сохранять его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов, и объясняет, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) , затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/#Pptx) . Блок `finally` освобождает презентацию и её ресурсы.

```java
// Загрузить устаревшую PPT-презентацию.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Расширение файла само по себе не определяет формат вывода; аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/#Pptx) делает это. Держите входные и выходные пути разными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому одна неудачная конверсия не останавливает остальную часть пакета.

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

Для производственных нагрузок записывайте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и помещайте имена неудавшихся файлов в очередь повторной попытки или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Password-Protected Presentations](/slides/ru/java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, формы, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, не имеющая эквивалента в PPTX или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте сконвертированный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не является форматом с поддержкой макросов, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или отображаться сконвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество ключевых слайдов и содержимое, затем сравните внешний вид и поведение слайдшоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентация будет редактироваться в текущих версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или храниться в формате, который легче просматривать и восстанавливать, чем устаревший двоичный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдёт проверки точности.

Если вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте руководство по конкретному формату в [Convert Presentations to Multiple Formats](/slides/ru/java/convert-presentation/), а не полагайтесь на то, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для единичного файла или быстрой проверки можно воспользоваться [онлайн‑конвертер PPT в PPTX](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конверсий, пакетной обработки или обработки ошибок на уровне приложения используйте Java API.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/java/ppt-vs-pptx/)
- [Сохранить презентации на Java](/slides/ru/java/save-presentation/)
- [Поддерживаемые форматы файлов](/slides/ru/java/supported-file-formats/)
- [Открыть презентации на Java](/slides/ru/java/open-presentation/)

## **FAQ**

**Можно ли конвертировать PPT в PPTX без установки Microsoft PowerPoint?**

Да. Aspose.Slides for Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT‑в‑PPTX весь контент точно?**

Она сохраняет общий контент презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если он содержит макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Можно ли конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствующий или неверный пароль приводит к сбою операции загрузки.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных вам просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертируется иначе.