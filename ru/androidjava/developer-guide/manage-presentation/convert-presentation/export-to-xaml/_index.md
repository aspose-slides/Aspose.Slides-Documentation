---
title: Экспорт презентаций в XAML на Android
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/androidjava/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- Android
- Java
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument в XAML на Java с помощью Aspose.Slides для Android — быстрое решение без Office, сохраняющее макет без изменений."
---
## **Обзор**

В этой статье объясняется, как экспортировать презентации PowerPoint в XAML с использованием Aspose.Slides для Android через Java. В ней содержится короткое введение в XAML, показано, как сохранить презентацию в XAML с настройками по умолчанию, а также демонстрируется, как настроить экспорт с помощью [XamlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью XAML‑стека и поведением экспорта скрытых слайдов.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

С XAML‑файлами можно работать в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример Java показывает, как экспортировать презентацию в XAML с использованием настроек по умолчанию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога процесса. Папка создаётся автоматически, и все необходимые изображения также сохраняются там.

Имя папки вывода берётся из имени исходного файла без расширения. Для `pres.pptx` выходные файлы называются `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если вы передадите абсолютный путь к входной презентации, папка вывода будет создана относительно текущего рабочего каталога, а не рядом с файлом ввода.

На Android используйте файл, доступный вашему приложению. Текущий рабочий каталог может быть недоступен для записи; используйте пользовательский сохранитель вывода, чтобы удерживать экспорт в памяти или записать его во внутреннее хранилище приложения, как показано ниже. Сгенерированный WPF‑XAML предназначен для совместимого потребителя и не является ресурсом разметки Android.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить вывод в пользовательское место, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ixamloutputsaver/) и передайте экземпляр вашей реализации в метод [setOutputSaver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) класса [XamlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) со значением `true`, как показано в следующем примере Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Сбор всех сгенерированных артефактов XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Назначьте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ixamloutputsaver/) для [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-), чтобы получать эти артефакты вместо использования сохранителя файловой системы по умолчанию. Запустите экспорт с помощью перегрузки [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) для XAML, принимающей параметры XAML.

### **Понимание жизненного цикла обратного вызова**

Экспортер вызывает [IXamlOutputSaver.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, так как XAML может ссылаться на ресурсы с помощью относительных путей.
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сохранитель обязан удержать или сохранить данные перед возвратом. Примеры копируют каждый массив байтов в память, принадлежащую приложению.
- Считайте экспорт успешным только тогда, когда операция сохранения презентации завершилась и каждый обратный вызов выполнился успешно. Не подавляйте ошибки хранилища и не запускайте незамеченные фоновые записи. Если сохранение происходит позже, сообщайте об общем успехе только после успешного завершения и этого шага.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) также применяется к пользовательскому сохранителю. Параметр по умолчанию, `false`, исключает XAML‑документы скрытых слайдов. Передача `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагайте один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

В этом полном примере загружается `pres.pptx`, собираются все артефакты в [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), а затем выводятся их имя, тип и количество байтов. Имена сохраняются точно такими, как переданы. Дублирующиеся имена делают коллекцию недействительной вместо тихого перезаписывания артефакта. Пример проверяет это перед использованием результатов.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Декодировать только XAML и только когда требуется текстовая проверка.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты неизменными при хранении или передаче. Используйте конструктор [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) с UTF‑8 только для XAML, который требует текстовой обработки.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот независимый пример собирает экспорт, проверяет имена и записывает исходные байты в ZIP‑архив. Замените `/path/to/app/files` на путь, возвращаемый методом [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir) вашего Android‑контекста. Уникальное имя архива отделяет параллельные задачи экспорта. Записи ZIP используют прямые слеши и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, отклоняют весь пакет до его записи.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Каталог ZIP был завершен закрытием перед сообщением об успехе.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Пример использует [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) для записи одного локального архива; сам экспортер не записывает отдельные файлы XAML или изображения. Для удалённого хранилища замените этап записи архива загрузкой собранных массивов байтов. Используйте идентификатор задачи экспорта плюс полное относительное имя артефакта в качестве ключа блоба, либо храните идентификатор задачи, относительное имя и бинарные данные в строке таблицы базы данных. Публикуйте задачу только после завершения всех загрузок или коммита транзакции базы данных. При ошибке сохранения очищайте частичный вывод.

Для больших презентаций пользовательский сохранитель может сохранять каждый артефакт напрямую в хранилище приложения, чтобы не держать дополнительную копию всего экспорта в памяти. Делайте каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранение имён ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если это требует место назначения, но сохраняйте относительные каталоги. Не используйте только [File.getName](https://developer.android.com/reference/java/io/File#getName/) если только не уверены, что каждое сгенерированное имя уникально и ссылки на ресурсы остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перемещения, разрешайте место назначения через [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath/), и проверяйте, что итоговый путь остаётся внутри целевого каталога экспорта, включая разделитель каталога в проверке containment. Используйте управляемый приложением каталог без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохранитель и пространство имён хранилища для каждой задачи экспорта. Обнаруживайте конфликты после нормализации разделителей и с учётом правил чувствительности к регистру места назначения.
- Перед публикацией парсите каждый XAML‑документ как XML и проверяйте его ссылки на файлы‑ресурсы, такие как атрибуты `Source` или `ImageSource` изображений. Разрешайте каждый относительный URI относительно каталога содержащего XAML‑артефакта, нормализуйте получившееся имя хранилища и подтверждайте, что соответствующий ключ карты, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и выражения разметки XAML отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Хранение лишь `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте тот же слой каталогов под префиксом задачи и делайте эти URL‑ы ресурсов доступными для потребителя XAML. Откройте завершённый ZIP, чтобы проверить имена записей и байты ресурсов, и загрузите типичные слайды в целевую XAML‑среду, чтобы убедиться, что изображения разрешаются корректно.

## **FAQ**

**Как гарантировать предсказуемый набор шрифтов, если исходный шрифт недоступен на машине?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) в [XamlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/) — он используется как резервный шрифт во время экспорта, когда оригинальный отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, доступны в окружении, где он отображается.

**Предназначен ли экспортированный XAML только для WPF или его можно использовать и в других XAML‑стэках?**

Aspose.Slides экспортирует WPF‑XAML через публичный API. Совместимость с другими XAML‑стэками, такими как UWP и Xamarin.Forms, не гарантируется. Протестируйте сгенерированную разметку в целевом окружении.

**Поддерживаются ли скрытые слайды и как можно предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) в [XamlOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/xamloptions/) — оставьте его отключённым, если вам не нужен экспорт скрытых слайдов.