---
title: Определение исходного формата презентации на Android
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/androidjava/detect-presentation-source-format/
keywords:
- исходный формат
- обнаружить формат презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Прочитайте оригинальный формат загруженной презентации на Android с помощью Aspose.Slides for Android через Java, сравните API обнаружения и работайте с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации вызовите метод Presentation.getSourceFormat, чтобы определить её исходный формат. Этот метод также доступен через IPresentation.getSourceFormat. Используйте его, когда дальнейшая обработка зависит от формата, из которого была загружена текущая копия.

Исходный формат отличается от SaveFormat, выбранного для выходного файла. Сохранение в другой формат не меняет исходный формат существующего экземпляра.

В примерах используется Java и пути к файлам. На Android замените примерные пути на пути к хранилищу, доступному приложению, например к внутреннему каталогу файлов вашего приложения.

## **Чтение исходного формата файла**

Для этого примера требуется существующий файл `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя Presentation.getSourceFormat, а не имя файла. Измените путь ввода, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения логикой вашего приложения.

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

## **Определение поддерживаемых значений**

Класс SourceFormat определяет целочисленные константы, отличающие следующие форматы презентаций. Приведённые ниже расширения являются условными, а не восстановлением оригинального имени файла.

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

## **Чтение исходного формата из потока**

Для этого примера требуется существующий файл `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор Presentation принимает только поток.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS и POT используют один и тот же двоичный формат. При загрузке по пути к файлу расширение может помочь отличить слайд-шоу или шаблон. Без имени файла устаревший контент PPS и POT может быть определён как `SourceFormat.Ppt`; приведённый выше пример PPS выводит целочисленное значение `SourceFormat.Ppt`.

Если вашему приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение является полезным подсказкой для этих устаревших подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение обнаружения до и после загрузки**

Используйте PresentationFactory.getPresentationInfo и IPresentationInfo.getLoadFormat, когда необходимо проанализировать файл до загрузки полной модели объектов презентации. Используйте Presentation.getSourceFormat, когда экземпляр уже существует.

Для этого примера требуется `sample.pptx` и выводятся целочисленные значения `LoadFormat.Pptx` и `SourceFormat.Pptx` соответственно. В продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не требует второго анализа только для получения её исходного формата.

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

Результаты используют константы из разных классов: LoadFormat и SourceFormat. Не сравнивайте их числовые значения и не полагайте, что каждый формат имеет одинаковые результаты обнаружения. PowerPoint XML может быть определён как `LoadFormat.Unknown` до загрузки и как `SourceFormat.Xml` после загрузки.

## **Разделяйте исходный и целевой форматы**

Для этого примера требуется `sample.pptx` и записывается `converted.odp`. Он выводит целочисленное значение `SourceFormat.Pptx` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из вывода ODP, сообщает `Odp`.

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

Презентация, созданная с нуля с помощью `new Presentation()`, сообщает `SourceFormat.Pptx`. У неё нет входного файла: это значение по умолчанию для нового экземпляра, а не свидетельство того, что был загружен файл PPTX. Отслеживайте отдельно, создало ли приложение объект или загрузило, если это различие имеет значение.

## **Сопоставление исходного формата с расширением**

Следующий пример требует `sample.pptx`. Он сопоставляет каждое поддерживаемое в настоящее время значение SourceFormat с условным расширением, не анализируя имя входного файла. Запасной вариант избегает бесшумного присвоения расширения нераспознанному значению.

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

Это сопоставление не преобразует файл и не восстанавливает устаревший подтип PPS/POT, потерянный при загрузке потока. Для реального сохранения явно указывайте SaveFormat или используйте преобразование, показанное в [Save Presentations in Their Original Format](/slides/ru/androidjava/save-presentation/#save-presentation-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создаёт презентацию и записывает три файла в рабочий каталог, перезаписывая файлы с теми же именами. Он открывает каждый результат как по пути, так и через поток памяти. Для PPTX и ODP оба способа сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, тогда как загрузка тех же байтов без имени файла сообщает `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

В следующей таблице суммированы результаты идентификации исходного формата для презентаций с совпадающими расширениями. Имена обозначают константы; примеры на Java выводят их целочисленные значения:

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

Содержимое PPS/POT определяется как `Ppt` для безымянных потоков. Таблица описывает идентификацию форматов, а не сохранение всех особенностей презентации при преобразовании.

## **FAQ**

**Изменит ли сохранение в ODP исходный формат презентации, загруженной из PPTX?**

Нет. Существующий экземпляр по‑прежнему сообщает `Pptx`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `Odp`.

**Всегда ли поток может различать устаревшую презентацию, слайд‑шоу и шаблон?**

Нет. PPT, PPS и POT используют один бинарный формат. Храните имя файла или метаданные подтипа отдельно, когда требуется такое различие.

**Какой API использовать, если презентация уже загружена?**

Читайте Presentation.getSourceFormat. Для анализа перед загрузкой используйте PresentationFactory.getPresentationInfo.