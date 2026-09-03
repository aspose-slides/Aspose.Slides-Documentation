---
title: 在 Android 上的簡報中嵌入字型
linktitle: 嵌入的字型
type: docs
weight: 40
url: /zh-hant/androidjava/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入字型
- 新增已嵌入字型
- 移除已嵌入字型
- 壓縮已嵌入字型
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 來管理 PowerPoint 中的嵌入字型。新增、取得、移除及壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **介紹**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝該字型，也能使用該字型顯示文字。這有助於保留換行、文字間距與投影片布局。

Aspose.Slides for Android via Java 讓您透過由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getFontsManager--) 回傳的 [IFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/) 介面，取得、加入與移除嵌入字型。您也可以透過移除簡報未使用的字元來減少嵌入字型資料的大小。

以下範例適用於 PPTX 檔案。在嵌入字型之前，請確認該字型資料可供 Aspose.Slides 使用，且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) 列出簡報中儲存的字型。若要移除字型，將清單中的字型傳給 [removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)，然後儲存簡報。

以下範例列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在存在時移除 Calibri：

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

移除嵌入字型會刪除其儲存的字型資料；不會更改文字所指派的字型。若目標系統已安裝該字型，文字仍可使用它。否則，呈現過程可能需要 [字型替代](/slides/zh-hant/androidjava/font-substitution/)，這會影響版面配置。

## **檢查字型資料與嵌入權限**

使用 [IFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/) 介面在嵌入字型之前檢查字型。呼叫 [IFontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) 取得簡報中使用的字型。對於每個字型，將 [IFontData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontdata/) 物件與所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontstyletype/) 值傳給 [IFontsManager.getFontBytes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-)。此方法回傳該字型樣式的二進位資料，若請求的字型或樣式不可用則回傳 `null`。不要將 `null` 結果傳給 [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)，因為該方法需要一個位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embeddinglevel/) 是一個旗標列舉，報告字型中儲存的嵌入限制：

- `Installable` 允許嵌入並在另一系統上永久安裝，受字型授權條款限制。
- `Restricted` 禁止嵌入，除非取得字型合法擁有者的許可（當它是唯一的使用權限旗標時）。
- `PreviewPrint` 允許暫時用於檢視與列印；包含該字型的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可編輯與儲存。
- `NoSubsetting` 為額外限制，禁止僅嵌入字形子集。若出現此旗標，必須嵌入所有字元。
- `BitmapOnly` 為額外限制，僅允許嵌入點陣字形（bitmap strike），不允許嵌入輪廓資料。若字型沒有點陣字形，則無法嵌入。

前四個值描述使用權限，而 `NoSubsetting` 與 `BitmapOnly` 可與它們組合。請使用位元運算檢查這些修飾子。由於 `Installable` 為零，應對使用權限位元進行遮罩，並將結果與 `Installable` 比較，而不是將其視為旗標檢查。現行字型應最多只設定一個使用權限位元。為相容設定了多個位元的舊版字型，以下輔助程式會選取限制最少的權限：先選 `Editable`，再選 `PreviewPrint`，最後 `Restricted`。

以下範例稽核由 `getFonts` 回傳之每個字型的常規、粗體、斜體與粗斜體資料。它會跳過不可用的樣式、受限制的字型、僅點陣的字型、因輸出仍保持可編輯而受限於預覽與列印的字型，以及已經嵌入的字型。若任何可用樣式具有 `NoSubsetting`，則會為該字型家族嵌入所有字元。

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

此檢查會報告每個字型檔案所編碼的限制。它不會授予授權、證明您合法取得該字型，亦不會取代在發佈嵌入副本前檢查字型授權協議的步驟。

## **加入嵌入字型**

使用 [addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 來嵌入字型。其多載接受 [IFontData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embedfontcharacters/) 列舉控制包含哪些字元：

- [All](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embedfontcharacters/) 嵌入字型中的全部字元。當接受者需要編輯簡報並輸入新文字時，請使用此選項。
- [OnlyUsed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embedfontcharacters/) 僅嵌入簡報中使用到的字元，以減少檔案大小。對於主要供檢視的完成簡報，請選擇此選項。

以下範例使用 [getFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。欲加入的字型必須在 Android 裝置上可用或已在 Aspose.Slides 中註冊。已存在的嵌入字型會保留其目前的字元集合。

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

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 透過移除未使用的字元來減少嵌入字型資料。它作用於已嵌入的字型，因此縮減幅度取決於簡報中未使用的字型資料量。

以下範例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果儲存為另一個檔案：

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

如果接受者可能稍後需要加入文字，請保留原始檔案。壓縮時移除的字元即使最初已嵌入全部字元，也不再能從嵌入字型中取得。

## **常見問題**

**如何確認嵌入字型在呈現時仍會被替代？**

在渲染簡報的環境中呼叫 [getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以查看 Aspose.Slides 會替換哪些字型。也請檢查 [字型替代](/slides/zh-hant/androidjava/font-substitution/) 設定與 [字型備援](/slides/zh-hant/androidjava/fallback-font/) 規則。備援會處理缺少的字元，因此即使嵌入字型，也無法解決該字型本身不包含的字元。

**是否應該嵌入常見字型，如 Arial 與 Calibri？**

請根據目標環境來決定。若所有開啟或渲染簡報的裝置皆具備所需字型，嵌入它們只會增加不必要的檔案大小。若接受者或伺服器可能缺少這些字型，且其授權允許，則嵌入可協助保留預期的外觀。