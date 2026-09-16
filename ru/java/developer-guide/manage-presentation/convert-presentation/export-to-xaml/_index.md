---
title: Экспорт презентаций в XAML на Java
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- преобразовать PowerPoint
- преобразовать OpenDocument
- преобразовать презентацию
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
- Java
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML на Java с помощью Aspose.Slides — быстрое решение без Office, сохраняющее макет."
---
## **Обзор**

В этой статье объясняется, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Она содержит краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт с помощью [XamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью стеков XAML и поведением экспорта скрытых слайдов.

## **Об XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и изменять разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример на Java показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

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

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога процесса, получаемого из пустого пути с помощью [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). Папка создаётся автоматически, и все требуемые изображения сохраняются там же.

Имя выходной папки берётся из имени исходного файла без расширения. Для `pres.pptx` файлы вывода называются `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если вы передаете абсолютный путь к входной презентации, папка вывода создаётся относительно текущего рабочего каталога, а не рядом с исходным файлом.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить результат в пользовательском месте, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/) и передайте экземпляр вашей реализации в метод [setOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) интерфейса [XamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) со значением `true`, как показано в следующем примере на Java:

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

## **Сбор всех генерируемых артефактов XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Назначьте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/) для [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-), чтобы получать эти артефакты вместо стандартного сохранения в файловой системе. Запустите экспорт с помощью перегрузки [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) для XAML, принимающей параметры XAML.

### **Понимание жизненного цикла обратного вызова**

Экспортер вызывает [IXamlOutputSaver.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, поскольку XAML может ссылаться на ресурсы через относительные пути.
- `data` содержит байты артефакта. Изображения и другие двоичные ресурсы не должны декодироваться как текст.
- Сохраняющий объект отвечает за сохранение или долговременное хранение данных до возврата. В примерах каждый массив байт копируется в память, принадлежащую приложению.
- Считайте экспорт успешным только после того, как операция сохранения презентации завершилась и каждый обратный вызов завершился успешно. Не подавляйте ошибки хранилища и не запускайте незаметные фоновое запись. Если сохранение происходит позже, сообщайте об общем успехе только после успешного завершения и этого шага.

Метод [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) также применяется к пользовательскому сохраняющему объекту. Настройка по умолчанию `false` исключает XAML‑документы скрытых слайдов. Установка `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагаете один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

В этом полном примере загружается `pres.pptx`, собираются все артефакты в [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), а затем выводятся их имя, тип и размер в байтах. Имена сохраняются точно так же, как получены. Дублирующиеся имена делают коллекцию недействительной вместо тихого перезаписывания артефакта. Пример проверяет это перед использованием результатов.

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

    // Декодировать только XAML и только при необходимости текстового осмотра.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты без изменений при хранении или передаче. Используйте конструктор [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) с UTF‑8 только для XAML, требующего текстовой обработки.

### **Упаковка собранных артефактов в ZIP‑архив**

В этом отдельном примере собирается экспорт, проверяются имена и записываются оригинальные байты в ZIP‑архив. Уникальное имя архива разделяет одновременно работающие задачи экспорта. Записи ZIP используют прямой слеш и сохраняют относительные каталоги. Неправильные имена или имена, которые конфликтуют после нормализации, приводят к отклонению всей упаковки до её записи.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Каталог ZIP был завершён закрытием перед сообщением об успешном сохранении.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Пример использует [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) для записи одного локального архива; сам экспортер не пишет отдельные файлы XAML или изображений. Для удалённого хранилища замените этап записи архива на загрузку собранных массивов байт. Используйте идентификатор задания экспорта плюс полный относительный путь к артефакту в качестве ключа блоба, либо храните идентификатор задания, относительное имя и бинарные данные в строке базы данных. Публикуйте задание только после завершения всех загрузок или фиксации транзакции базы данных. При неудаче очистите частичный вывод.

Для больших презентаций пользовательский сохраняющий объект может сохранять каждый артефакт непосредственно в хранилище приложения, чтобы избежать создания дополнительной копии всего экспорта в памяти. Держите каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранение имён ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если это требуется целевым хранилищем, но сохраняйте относительные каталоги. Не используйте только [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) если только не уверены, что каждое сгенерированное имя уникально и ссылки остаются валидными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, разрешайте назначение через [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель в проверке containment. Используйте каталог, контролируемый приложением, без символических ссылок, которые могут перенаправлять запись.
- Используйте отдельный сохраняющий объект и пространство имён хранилища для каждой задачи экспорта. Обнаруживайте конфликты после нормализации разделителей и в соответствии с правилами чувствительности к регистру целевого места.
- Перед публикацией разбирайте каждый документ XAML как XML и проверяйте его ссылки на файловые ресурсы, такие как атрибуты `Source` или `ImageSource` у изображений. Разрешайте каждый относительный URI относительно каталога содержащего артефакта XAML, нормализуйте получившееся имя хранилища и подтверждайте, что соответствующий ключ карты, запись ZIP или сохраняемый объект существует. Обрабатывайте внешние URI и выражения разметки XAML отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Хранение только `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задания и делайте эти URL‑ы ресурсов доступными потребителю XAML. Переоткройте готовый ZIP, чтобы проверить имена записей и байты ресурсов, и загрузите несколько слайдов в целевую среду XAML, чтобы убедиться, что изображения правильно разрешаются.

## **FAQ**

**Как обеспечить предсказуемость шрифтов, если оригинальный шрифт недоступен на машине?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) в [XamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/) — это резервный шрифт, используемый при экспорте, когда оригинального нет. Это не гарантирует, что сгенерированный XAML будет ссылаться именно на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, присутствуют в среде, где он отображается.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

Aspose.Slides экспортирует XAML для WPF через публичный API. Совместимость с другими стеками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Проверьте сгенерированную разметку в целевой среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Управлять этим можно через [setExportHiddenSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) в [XamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xamloptions/) — оставьте его выключенным, если экспорт скрытых слайдов не нужен.