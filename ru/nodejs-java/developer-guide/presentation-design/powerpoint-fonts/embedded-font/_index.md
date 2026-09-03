---
title: "Встраивание шрифтов в презентации на JavaScript"
linktitle: "Встроенные шрифты"
type: docs
weight: 40
url: /ru/nodejs-java/embedded-font/
keywords:
- "добавить шрифт"
- "встроить шрифт"
- "встраивание шрифтов"
- "получить встроенный шрифт"
- "добавить встроенный шрифт"
- "удалить встроенный шрифт"
- "сжать встроенный шрифт"
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides for Node.js via Java. Добавляйте, получайте, удаляйте и сжимайте шрифты, чтобы сохранять внешний вид текста и уменьшать размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда средство просмотра поддерживает встроенные шрифты, оно может отображать текст с использованием этих шрифтов, даже если они не установлены в целевой системе. Это помогает сохранять разрывы строк, интервал текста и макет слайдов.

Aspose.Slides for Node.js via Java позволяет получать, добавлять и удалять встроенные шрифты через класс [FontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/) , возвращаемый методом [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getfontsmanager/). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые не используются в презентации.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия позволяет встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) чтобы получить список шрифтов, хранящихся в презентации. Чтобы удалить один из них, передайте шрифт из этого списка в [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), затем сохраните презентацию.

В следующем примере перечислены встроенные шрифты в файле `EmbeddedFonts.pptx` и удаляется Calibri, если он присутствует:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Удаление встроенного шрифта удаляет его сохранённые данные шрифта; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [font substitution](/slides/ru/nodejs-java/font-substitution/), что может повлиять на макет.

## **Проверка данных шрифта и прав встраивания**

Используйте класс [FontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/) для проверки шрифтов перед их встраиванием. Вызовите [FontsManager.getFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getfonts/) , чтобы получить шрифты, используемые в презентации. Для каждого шрифта передайте объект [FontData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontstyletype/) в [FontsManager.getFontBytes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Метод возвращает двоичные данные для данного стиля шрифта или `null`, если запрошенный шрифт или стиль недоступны. Не передавайте результат `null` в [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), потому что этот метод требует массив байтов. В Node.js преобразуйте возвращённый массив JavaScript в массив байтов Java с помощью `java.newArray` перед передачей в `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/embeddinglevel/) сообщает ограничения на встраивание, хранящиеся в шрифте, в виде набора флагов:

- `Installable` разрешает встраивание и постоянную установку на другую систему, в соответствии с лицензией шрифта.
- `Restricted` запрещает встраивание, если не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` разрешает временное использование и позволяет документу быть отредактированным и сохранённым.
- `NoSubsetting` является дополнительным ограничением, запрещающим встраивание только части глифов. При наличии этого флага необходимо встраивать все символы.
- `BitmapOnly` является дополнительным ограничением, позволяющим встраивать только bitmap‑шрифты, а не контурные данные. Если у шрифта нет bitmap‑шрифтов, его нельзя встраивать.

Первые четыре значения описывают разрешение на использование, в то время как `NoSubsetting` и `BitmapOnly` могут быть комбинированы с ними. Проверяйте модификаторы с помощью битовых операций. Поскольку `Installable` равен нулю, маскируйте биты разрешения использования и сравнивайте результат с `Installable`, а не проверяйте его как флаг. Текущие шрифты должны задавать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые задают более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

В следующем примере проверяются обычные, жирные, курсивные и жирно‑курсивные данные, доступные для каждого шрифта, возвращённого `getFonts`. Пропускаются недоступные стили, ограниченные шрифты, шрифты только bitmap, шрифты, ограниченные просмотром и печатью, поскольку вывод остаётся редактируемым, а также уже встроенные шрифты. Если какой‑либо доступный стиль имеет `NoSubsetting`, встраиваются все символы для этой семейства шрифтов.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта проверка сообщает о ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензию, не доказывает, что вы легально получили шрифт, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) для встраивания шрифта. Его перегрузки принимают либо объект [FontData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontdata/) , либо массив байтов, содержащий данные шрифта. [EmbedFontCharacters](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/embedfontcharacters/) управляет тем, какие символы включаются:

- `All` встраивает все символы шрифта. Используйте этот вариант, когда получателям необходимо редактировать презентацию и вводить новый текст.
- `OnlyUsed` встраивает только символы, используемые в презентации, чтобы уменьшить размер файла. Выберите этот вариант для завершённой презентации, предназначенной в основном для просмотра.

В следующем примере используется [FontsManager.getFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, используемых в `Fonts.pptx`, и встраиваются те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сжатие встроенных шрифтов**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/compressembeddedfonts/) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с шрифтами, уже встроенными, поэтому снижение размера зависит от количества неиспользуемых данных шрифта в презентации.

В следующем примере сжимаются шрифты в `EmbeddedFonts.pptx` и результат сохраняется в отдельный файл:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохраните оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые при сжатии, более недоступны из встроенного шрифта, даже если изначально был встраен полностью.

## **Вопросы и ответы**

**Как проверить, будет ли встроенный шрифт всё ещё заменяться при рендеринге?**

Вызовите [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [font substitution](/slides/ru/nodejs-java/font-substitution/) и правила [font fallback](/slides/ru/nodejs-java/fallback-font/). Fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых сам шрифт не содержит.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Основанное решение должно учитывать целевую среду. Если необходимые шрифты доступны на каждом устройстве, открывающем или рендерящем презентацию, их встраивание может добавить ненужный размер файла. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание может помочь сохранить задуманное отображение, при условии, что лицензии позволяют это.