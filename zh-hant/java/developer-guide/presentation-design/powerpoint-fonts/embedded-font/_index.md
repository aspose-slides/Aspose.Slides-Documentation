---
title: 在 Java 中為簡報嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/java/embedded-font/
keywords:
- 加入字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入字型
- 新增已嵌入字型
- 移除已嵌入字型
- 壓縮已嵌入字型
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理 PowerPoint 中的嵌入字型。新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝該字型，也能使用這些字型來顯示文字。這可保留換行、文字間距與投影片版面配置。

Aspose.Slides for Java 讓您透過由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getFontsManager--) 取得的 [IFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/) 介面，來擷取、加入與移除嵌入字型。您也可以透過移除簡報未使用的字元，減少嵌入字型資料的大小。

以下範例皆使用 PPTX 檔案。嵌入字型前，請確保其字型資料可供 Aspose.Slides 使用，且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) 取得簡報中儲存的字型清單。要移除其中一個字型，將該清單中的字型傳給 [removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)，然後存檔。

下列範例列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在出現 Calibri 時將其移除：

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

移除嵌入字型會刪除其儲存的字型資料；不會變更文字所指定的字型。如果目標系統已安裝該字型，文字仍然可以使用它。否則，渲染時可能需要 [font substitution](/slides/zh-hant/java/font-substitution/)，從而影響版面配置。

## **檢查字型資料與嵌入權限**

使用 [IFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/) 介面在嵌入前檢查字型。呼叫 [IFontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getFonts--) 取得簡報中使用的字型。對於每個字型，傳入 [IFontData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontdata/) 物件以及所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontstyletype/) 值給 [IFontsManager.getFontBytes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-)。該方法會回傳該字型樣式的二進位資料，若請求的字型或樣式不存在則返回 `null`。不要將 `null` 結果傳給 [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/embeddinglevel/) 為一組旗標列舉，說明字型所儲存的嵌入限制：

- `Installable` 允許嵌入並可永久安裝至其他系統，需遵守字型授權。
- `Restricted` 除非取得字型合法擁有者的許可，否則禁止嵌入（當它是唯一的使用權限旗標時）。
- `PreviewPrint` 允許暫時用於檢視與列印；包含該字型的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可編輯與儲存。
- `NoSubsetting` 為額外限制，禁止僅嵌入字形子集。若出現此旗標，必須嵌入全部字元。
- `BitmapOnly` 為額外限制，只允許嵌入位圖字形，不能嵌入向量資料。若字型沒有位圖字形，則無法嵌入。

前四個值描述使用權限，`NoSubsetting` 與 `BitmapOnly` 可與之結合。使用位元運算檢查這些修飾子。因為 `Installable` 為 0，請先遮罩使用權限位元，然後將結果與 `Installable` 比較，而不是將它視為旗標檢查。當前的字型應最多只設定一個使用權限位元。為相容於設定了多個位元的舊字型，下列輔助程式會選取最寬鬆的權限：先選 `Editable`，再 `PreviewPrint`，最後 `Restricted`。

下列範例稽核 `getFonts` 回傳的每個字型的正規、粗體、斜體與粗斜體資料。它會跳過不存在的樣式、受限字型、僅限位圖的字型、僅限預覽與列印的字型（因為輸出仍可編輯），以及已嵌入的字型。若任何可用樣式具有 `NoSubsetting`，則為該字型家族嵌入全部字元。

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

此檢查會報告每個字型檔案中編碼的限制。它不會授予授權、證明您已合法取得字型，亦不取代在分發嵌入副本前檢查字型授權協議的流程。

## **加入嵌入字型**

使用 [addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 來嵌入字型。其多載接受 [IFontData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/embedfontcharacters/) 列舉控制要包含的字元：

- [All](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/embedfontcharacters/) 會嵌入字型中的所有字元。當收件人需要編輯簡報並輸入新文字時請使用此選項。
- [OnlyUsed](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/embedfontcharacters/) 只嵌入簡報中實際使用的字元，以減少檔案大小。對於已完成且主要供檢視的簡報，請選擇此選項。

下列範例使用 [getFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getFonts--) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。已存在的嵌入字型會保留其目前的字元集合。

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

## **壓縮嵌入字型**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 會透過移除未使用的字元來減少嵌入字型資料的大小。它針對已嵌入的字型運作，因而減少的幅度取決於簡報中未使用的字型資料量。

下列範例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果儲存為另一個檔案：

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

若收件人之後可能需要加入文字，請保留原始檔案。壓縮期間移除的字元將不再可從嵌入字型取得，即使您最初已嵌入所有字元。

## **常見問與答**

**我如何檢查嵌入的字型在渲染時是否仍會被替代？**

在渲染簡報的環境中呼叫 [getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)，即可查看 Aspose.Slides 會替換哪些字型。也請檢查 [font substitution](/slides/zh-hant/java/font-substitution/) 設定與 [font fallback](/slides/zh-hant/java/fallback-font/) 規則。Fallback 會處理缺失的字元，因此嵌入字型無法解決字型本身不包含的字元。

**我應該嵌入如 Arial 與 Calibri 這類常見字型嗎？**

決策應依目標環境而定。如果所需字型在每台開啟或渲染簡報的機器上皆已安裝，嵌入它們只會增加不必要的檔案大小。若收件人或伺服器可能缺乏這些字型，且其授權允許嵌入，則嵌入可協助保留預期的外觀。