---
title: Настройка шрифтов PowerPoint в Java
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/java/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Java, чтобы ваши презентации были чёткими и согласованными на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа, или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает поддерживать консистентность вывода презентации в разных средах. В статье также объясняется, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. Смотрите [Шрифты темы, специфичные для сценария](/slides/ru/java/script-specific-font-mappings/) чтобы управлять сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Note" %}}
Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод экспорта — такой как PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader#clearCache--) для очистки кэша шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:

```java
import com.aspose.slides.*;

// Определите папки, содержащие пользовательские файлы шрифтов.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы) с использованием загруженных шрифтов.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь шрифтов операционной системы по умолчанию.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#getFontFolders--) позволяющий находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот Java‑код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) позволяющее указать внешние шрифты, которые будут использоваться с презентацией. 

Этот Java‑код показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны в презентации
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) позволяющий загружать внешние шрифты из бинарных данных.

Этот Java‑код демонстрирует процесс загрузки шрифта из массива байтов:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт загружен во время жизни презентации
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Часто задаваемые вопросы**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

### Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если нужен шрифт внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/java/embedded-font/).

### Могу ли я контролировать поведение при отсутствии некоторых глифов в пользовательском шрифте?

Да. Настройте [замена шрифтов](/slides/ru/java/font-substitution/), [правила замены](/slides/ru/java/font-replacement/), и [наборы запасных шрифтов](/slides/ru/java/fallback-font/) чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

### Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Укажите собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.