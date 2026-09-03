---
title: Android でのプレゼンテーションへのフォント埋め込み
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/androidjava/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint の埋め込みフォントを管理します。フォントを追加、取得、削除、圧縮してテキストの外観を保持し、ファイルサイズを削減します。"
---
## **概要**

フォントの埋め込みは、フォントデータを PowerPoint プレゼンテーション内に格納します。ビューアーが埋め込まれたフォントをサポートしていれば、対象システムにフォントがインストールされていなくても、そのフォントでテキストを表示できます。これにより、改行位置、文字間隔、スライドレイアウトが保持されます。

Aspose.Slides for Android via Java は、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getFontsManager--) が返す [IFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/) インターフェイスを通じて、埋め込まれたフォントの取得、追加、削除が可能です。プレゼンテーションで使用していない文字を除去することで、埋め込みフォントデータのサイズを削減することもできます。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、そのフォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) を使用して、プレゼンテーションに格納されているフォントを一覧表示できます。フォントを削除するには、その一覧から取得したフォントを [IFontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) に渡し、プレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` に埋め込まれているフォントを一覧表示し、Calibre が存在すれば削除します。

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

埋め込まれたフォントを削除しても、テキストに割り当てられているフォント自体は変更されません。対象システムにそのフォントがインストールされていれば、テキストは引き続きそのフォントで表示されます。インストールされていない場合は、[フォント置換](/slides/ja/androidjava/font-substitution/) が行われ、レイアウトが崩れる可能性があります。

## **フォントデータと埋め込み許可の検査**

埋め込み前にフォントを検査するには、[IFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/) インターフェイスを使用します。[IFontsManager.getFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) でプレゼンテーションで使用されているフォントを取得し、各フォントについて [IFontData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontstyletype/) の値を渡して [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) を呼び出します。このメソッドは該当フォントスタイルのバイナリデータを返すか、利用できない場合は `null` を返します。`null` が返った状態で [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) を呼び出さないでください。このメソッドはバイト配列を必須とします。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embeddinglevel/) はフォントに保存された埋め込み制限を示すフラグ列挙型です。

- `Installable` は埋め込みと、別システムへの永久インストールを許可します（フォントのライセンスに準拠）。
- `Restricted` は唯一の使用許可フラグがこの場合、フォント所有者の許可なく埋め込みを禁止します。
- `PreviewPrint` は閲覧と印刷の一時的利用を許可します。フォントを含む文書は読み取り専用である必要があります。
- `Editable` は一時的利用を許可し、文書の編集・保存も可能です。
- `NoSubsetting` は追加の制限で、文字のサブセット埋め込みを禁止します。このフラグがある場合はすべての文字を埋め込んでください。
- `BitmapOnly` は追加の制限で、アウトラインデータではなくビットマップストライクのみの埋め込みを許可します。ビットマップストライクが存在しないフォントは埋め込めません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット単位の演算で修飾子をチェックしてください。`Installable` の値は 0 なので、使用許可ビットをマスクし、結果が `Installable` と等しいかで判定します。現在のフォントは最大で 1 つの使用許可ビットしか設定しませんが、過去のフォントで複数設定されている場合に備えて、以下のヘルパーは最も制限の緩い許可を選択します：`Editable` → `PreviewPrint` → `Restricted`。

次の例は `getFonts` で取得したすべてのフォントについて、通常・太字・斜体・太字斜体のデータを監査します。利用できないスタイル、制限付きフォント、ビットマップ専用フォント、プレビュー/印刷専用フォント（出力が編集可能になるため）およびすでに埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合は、そのフォントファミリーのすべての文字を埋め込みます。

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

この検査は各フォントファイルにエンコードされた制限情報を報告します。ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込み版を配布する前にフォントの使用許諾契約を確認する代わりになるものではありません。

## **埋め込みフォントの追加**

[IFontsManager.addEmbeddedFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) を使用してフォントを埋め込めます。オーバーロードにより、[IFontData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embedfontcharacters/) 列挙型で埋め込む文字の範囲を指定します。

- [All](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受取側がプレゼンテーションを編集し、新しいテキストを入力できるようにしたい場合に使用してください。
- [OnlyUsed](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embedfontcharacters/) はプレゼンテーションで使用されている文字だけを埋め込み、ファイルサイズを削減します。閲覧主体の完成版プレゼンテーションに適しています。

次の例は `Fonts.pptx` で使用されているフォントを [getFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) で取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントは Android デバイス上に存在するか、Aspose.Slides に登録されている必要があります。既存の埋め込みフォントは現在の文字集合を保持します。

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

## **埋め込みフォントの圧縮**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) は、未使用文字を除去することで埋め込みフォントデータを圧縮します。既に埋め込まれているフォントに対して処理を行うため、圧縮率はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します。

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

受取側が後でテキストを追加する可能性がある場合は、元ファイルを保持してください。圧縮時に削除された文字は埋め込みフォントからは利用できなくなります（当初すべての文字を埋め込んでいた場合でも同様です）。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認する方法は？**

プレゼンテーションをレンダリングする環境で [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出し、Aspose.Slides が置換するフォントを確認してください。また、[フォント置換](/slides/ja/androidjava/font-substitution/) の設定と [フォントフォールバック](/slides/ja/androidjava/fallback-font/) ルールも確認します。フォールバックは欠落文字を補完するため、フォント自体に含まれない文字は埋め込みだけでは解決できません。

**Arial や Calibri といった一般的なフォントは埋め込むべきか？**

対象環境に応じて判断してください。必要なフォントがすべてのデバイスやサーバーに既にインストールされている場合、埋め込みは不要でファイルサイズが増えるだけです。受取側やサーバーにフォントが存在しない可能性がある場合は、ライセンスが埋め込みを許可している限り、外観を保つために埋め込むことが有益です。