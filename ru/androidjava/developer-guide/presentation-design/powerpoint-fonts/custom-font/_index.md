---
title: Настройка шрифтов PowerPoint на Android
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Android на Java, чтобы ваши презентации были четкими и согласованными на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранить единообразие вывода презентации в разных средах. Статья также объясняет, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Script-Specific Theme Fonts](/slides/ru/androidjava/script-specific-font-mappings/) для управления сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Note" %}}

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. Смотрите [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. Смотрите [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontsLoader#clearCache--) для очистки кеша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:

```java
import com.aspose.slides.*;

// Определите папки, содержащие пользовательские файлы шрифтов.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кеш шрифтов после завершения работы.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию в операционной системе.  
2. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

В этом Java‑коде показано, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Эта строка выводит папки, в которых ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации.

В этом Java‑коде показано, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

В этом Java‑коде продемонстрирован процесс загрузки шрифта из массива байтов:

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
        // внешний шрифт загружен на время жизни презентации
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

### Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если требуется, чтобы шрифт находился внутри файла презентации, необходимо явно использовать [возможности встраивания](/slides/ru/androidjava/embedded-font/).

### Можно ли управлять поведением переключения, когда у пользовательского шрифта отсутствуют определённые глифы?

Да. Настройте [замену шрифтов](/slides/ru/androidjava/font-substitution/), [правила замены](/slides/ru/androidjava/font-replacement/) и [наборы резервных шрифтов](/slides/ru/androidjava/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии требуемого глифа.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их установки на уровне системы?

Да. Указывайте свои папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.