---
title: Определение оригинального формата презентации в Java
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/java/detect-presentation-source-format/
keywords:
- исходный формат
- определение формата презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Чтение оригинального формата загруженной презентации в Java с помощью Aspose.Slides for Java, сравнение API обнаружения и работа с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации вызовите метод [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--) чтобы определить её оригинальный формат. Этот метод также доступен через [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getSourceFormat--). Используйте его, когда последующая обработка зависит от формата, из которого была загружена текущая копия.

Исходный формат отличается от выбранного [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) для выходного файла. Сохранение в другой формат не изменяет исходный формат существующего экземпляра.

## **Чтение исходного формата файла**

Этот пример требует существующего файла `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--), а не имя файла. Измените путь к входному файлу, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Распознавание поддерживаемых значений**

Класс [SourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sourceformat/) определяет целочисленные константы, отличающие следующие форматы презентаций. Ниже указанные расширения являются условными, а не восстановлением оригинального имени файла.

| Значение SourceFormat | Расширение | Формат |
| --- | --- | --- |
| `Ppt` | `.ppt` | Презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Презентация Office Open XML |
| `Pptm` | `.pptm` | Презентация Office Open XML с поддержкой макросов |
| `Pps` | `.pps` | Слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | Слайд-шоу Office Open XML с поддержкой макросов |
| `Pot` | `.pot` | Шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | Шаблон Office Open XML |
| `Potm` | `.potm` | Шаблон Office Open XML с поддержкой макросов |
| `Odp` | `.odp` | Презентация OpenDocument |
| `Otp` | `.otp` | Шаблон презентации OpenDocument |
| `Fodp` | `.fodp` | Презентация Flat XML ODF |
| `Xml` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата потока**

Этот пример требует существующего файла `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байт. Конструктор [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) принимает только поток.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь различить слайд-шоу или шаблон. Без имени файла содержимое старых форматов PPS и POT может быть определено как `SourceFormat.Ppt`; пример PPS выше выводит целочисленное значение `SourceFormat.Ppt`.

Если вашему приложению требуется сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение является полезной подсказкой для этих старых подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение обнаружения до и после загрузки**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) и [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) когда необходимо проанализировать файл до полной загрузки модели объектов презентации. Используйте [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--) когда экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит целочисленные значения `LoadFormat.Pptx` и `SourceFormat.Pptx` соответственно. В продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не нуждается во второй проверке только для получения её исходного формата.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Результаты используют константы из разных классов: [LoadFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sourceformat/). Не сравнивайте их числовые значения и не полагайтесь на то, что каждый формат имеет одинаковые результаты обнаружения. PowerPoint XML может быть определён как `LoadFormat.Unknown` до загрузки и как `SourceFormat.Xml` после загрузки.

## **Отдельное хранение исходного и выходного форматов**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит целочисленное значение `SourceFormat.Pptx` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из выходного файла ODP, сообщает `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Презентация, созданная с нуля с помощью `new Presentation()`, сообщает `SourceFormat.Pptx`. У неё нет входного файла: это значение по умолчанию для вновь созданного экземпляра, а не доказательство того, что был загружен файл PPTX. Отслеживайте, создал ли ваш код экземпляр или загрузил его, если это различие имеет значение.

## **Отображение исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он отображает каждое в настоящее время поддерживаемое значение [SourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sourceformat/) в условное расширение, без разбора имени входного файла. Запасной вариант предотвращает бесшумное присвоение расширения нераспознанному значению.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Это сопоставление не преобразует файл и не восстанавливает старый подтип PPS/POT, утерянный при загрузке из потока. Для фактического сохранения явно указывайте [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) или используйте конверсию, показанную в разделе [Save Presentations in Their Original Format](/slides/ru/java/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот полностью автономный пример создаёт презентацию и записывает три файла в рабочий каталог, перезаписывая файлы с теми же именами. Затем он открывает каждый результат как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, тогда как загрузка тех же байтов без имени файла сообщает `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Следующая таблица суммирует идентификацию исходного формата для презентаций с совпадающими расширениями. Имена обозначают константы; примеры на Java выводят их целочисленные значения:

| Сохранённый формат | SourceFormat из пути к файлу | SourceFormat из безымянного потока |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | То же, что и путь к файлу |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | То же, что и путь к файлу |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | То же, что и путь к файлу |
| ODP, OTP | `Odp`, `Otp` соответственно | То же, что и путь к файлу |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Содержимое PPS/POT идентифицируется как `Ppt` для безымянных потоков. Таблица описывает идентификацию форматов, а не сохранение всех особенностей презентации при конвертации.

## **FAQ**

**Изменяется ли исходный формат презентации, загруженной из PPTX, при сохранении в ODP?**

Нет. Существующий экземпляр всё ещё сообщает `Pptx`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `Odp`.

**Всегда ли поток может различать наследуемую презентацию, слайд-шоу и шаблон?**

Нет. PPT, PPS и POT используют один и тот же бинарный формат. Храните имя файла или метаданные подтипа отдельно, когда требуется различие.

**Какой API использовать, если презентация уже загружена?**

Читайте [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSourceFormat--). Для проверки до загрузки используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-).