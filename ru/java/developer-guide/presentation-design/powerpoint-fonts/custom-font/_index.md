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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Java, чтобы ваши презентации оставались четкими и одинаковыми на любых устройствах."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять вывод презентации одинаковым в разных средах. В статье также объясняется, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, явно используйте функции встраивания шрифтов.

{{% alert color="info" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например в PDF, изображения и другие поддерживаемые форматы — так что получаемые документы выглядят одинаково в разных окружениях. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих папок.  
3. Загрузите и выполните рендеринг/экспорт презентации.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader#clearCache--) чтобы очистить кэш шрифтов.

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

    // Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.  
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#getFontFolders--) , позволяющий находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот пример кода на Java показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , позволяющее указать внешние шрифты, которые будут использоваться в презентации. 

Этот пример кода на Java показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts, а также их подпапок доступны презентации
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот пример кода на Java демонстрирует процесс загрузки шрифта из массива байтов:

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

## **Часто задаваемые вопросы**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Связанные шрифты используются рендерером во всех форматах экспорта.

### Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не то же самое, что встраивание его в PPTX. Если необходимо, чтобы шрифт находился внутри файла презентации, необходимо использовать явные [функции встраивания](/slides/ru/java/embedded-font/).

### Можно ли контролировать поведение резервирования, когда у пользовательского шрифта отсутствуют некоторые глифы?

Да. Настройте [замена шрифтов](/slides/ru/java/font-substitution/), [правила замены](/slides/ru/java/font-replacement/) и [множества резервных шрифтов](/slides/ru/java/fallback-font/), чтобы точно определить, какой шрифт будет использован, когда требуемый глиф отсутствует.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Укажите свои собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.