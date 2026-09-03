---
title: Встраивание шрифтов в презентации на Java
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/java/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифта
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides для Java. Добавляйте, получайте, удаляйте и сжимайте шрифты, чтобы сохранить внешний вид текста и уменьшить размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда просмотрщик поддерживает встроенные шрифты, он может отображать текст с использованием этих шрифтов, даже если они не установлены в целевой системе. Это помогает сохранить разрывы строк, межсимвольные интервалы и макет слайдов.

Aspose.Slides for Java позволяет получать, добавлять и удалять встроенные шрифты через интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/) , возвращаемый [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getFontsManager--). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые презентация не использует.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия разрешает встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [getEmbeddedFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) , чтобы получить список шрифтов, хранящихся в презентации. Чтобы удалить один, передайте шрифт из этого списка в [removeEmbeddedFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в файле `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Удаление встроенного шрифта удаляет его хранимые данные шрифта; это не изменяет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [замена шрифтов](/slides/ru/java/font-substitution/), что может повлиять на макет.

## **Проверка данных шрифта и прав на встраивание**

Используйте интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/) , чтобы проверять шрифты перед их встраиванием. Вызовите [IFontsManager.getFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFonts--) , чтобы получить шрифты, использованные в презентации. Для каждого шрифта передайте объект [IFontData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontstyletype/) , в метод [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) . Метод возвращает бинарные данные для данного стиля шрифта или `null`, если запрошенный шрифт или стиль недоступны. Не передавайте результат `null` в [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), поскольку этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает об ограничениях встраивания, хранящихся в шрифте:

- `Installable` разрешает встраивание и постоянную установку на другой системе, в соответствии с лицензией шрифта.
- `Restricted` запрещает встраивание, если только не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` разрешает временное использование и позволяет редактировать и сохранять документ.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага необходимо встраивать все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только растровые наборы шрифта, а не контурные данные. Если у шрифта нет растровых наборов, его нельзя встраивать.

Первые четыре значения описывают разрешения на использование, в то время как `NoSubsetting` и `BitmapOnly` могут комбинироваться с ними. Проверяйте модификаторы с помощью побитовых операций. Поскольку `Installable` равен нулю, маскируйте биты разрешения использования и сравнивайте результат с `Installable`, а не проверяйте его как флаг. Текущие шрифты должны устанавливать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые задают более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирно‑курсивные данные, доступные для каждого шрифта, возвращаемого `getFonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только с растровыми наборами, шрифты, ограниченные только просмотром и печатью, поскольку вывод остаётся редактируемым, а также уже встроенные шрифты. Если любой доступный стиль имеет `NoSubsetting`, он встраивает все символы для данного семейства шрифтов.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта проверка сообщает об ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензии, не доказывает, что вы получили шрифт легально, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [addEmbeddedFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) , чтобы встроить шрифт. Его перегрузки принимают либо объект [IFontData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontdata/) , либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embedfontcharacters/) определяет, какие символы включать:

- [All](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embedfontcharacters/) встраивает все символы шрифта. Используйте эту опцию, когда получатели нуждаются в редактировании презентации и вводе нового текста.
- [OnlyUsed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embedfontcharacters/) встраивает только символы, используемые в презентации, чтобы уменьшить размер файла. Выберите эту опцию для готовой презентации, предназначенной в основном для просмотра.

Следующий пример использует [getFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getFonts--) , чтобы получить шрифты, использованные в `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сжатие встроенных шрифтов**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) уменьшает данные встроенных шрифтов, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень уменьшения размера зависит от количества неиспользуемых данных шрифта в презентации.

Следующий пример сжимает шрифты в `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохраните оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые во время сжатия, больше недоступны из встроенного шрифта, даже если изначально вы встраивали все символы.

## **Часто задаваемые вопросы**

**Как проверить, будет ли встроенный шрифт заменяться при рендеринге?**

Вызовите [getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) , в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [font substitution](/slides/ru/java/font-substitution/) и правила [font fallback](/slides/ru/java/fallback-font/). Fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых в самом шрифте нет.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Решение следует принимать, исходя из целевой среды. Если необходимые шрифты доступны на каждой машине, открывающей или рендерящей презентацию, их встраивание может увеличить размер файла без необходимости. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание поможет сохранить задуманное оформление, при условии, что лицензии позволяют это.