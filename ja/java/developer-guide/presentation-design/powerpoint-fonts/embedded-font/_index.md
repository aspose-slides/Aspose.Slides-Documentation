---
title: Java でプレゼンテーションにフォントを埋め込む
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/java/embedded-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint の埋め込みフォントを管理します。フォントの追加、取得、削除、圧縮を行い、テキストの見た目を維持しつつファイルサイズを削減します。"
---
## **概要**

埋め込みフォントは、フォントデータを PowerPoint プレゼンテーション内に格納します。ビューアが埋め込みフォントに対応している場合、対象システムにフォントがインストールされていなくても、これらのフォントを使用してテキストを表示できます。これにより、改行や文字間隔、スライドレイアウトが保持されます。

Aspose.Slides for Java は、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getFontsManager--) が返す [IFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/) インターフェイスを通じて、埋め込みフォントの取得、追加、削除が可能です。また、プレゼンテーションで使用されていない文字を削除することで、埋め込みフォントデータのサイズを縮小できます。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、フォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[getEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) を使用して、プレゼンテーションに格納されているフォントの一覧を取得します。削除する場合は、その一覧からフォントを取得し、[removeEmbeddedFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) に渡してからプレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` に埋め込まれているフォントを一覧表示し、Calibri が存在すれば削除します。

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

埋め込みフォントを削除しても、テキストに割り当てられたフォント自体は変わりません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントで表示されます。インストールされていない場合は、[フォント置換](/slides/ja/java/font-substitution/) が行われ、レイアウトが変わる可能性があります。

## **フォントデータと埋め込み権限の確認**

埋め込み前にフォントを検査するには、[IFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/) インターフェイスを使用します。[IFontsManager.getFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getFonts--) でプレゼンテーションで使用されているフォントを取得し、各フォントについて [IFontData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontstyletype/) を指定して [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) を呼び出します。このメソッドはフォントスタイルのバイナリデータを返すか、該当フォントまたはスタイルが利用できない場合は `null` を返します。`null` が返された状態で [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) を呼び出さないでください。後者はバイト配列を必須とします。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embeddinglevel/) は、フォントに埋め込み制限が記録されていることを示すフラグ列挙型です。

- `Installable` は埋め込みと他システムへの永久インストールを許可します（フォントライセンスに従う）。
- `Restricted` は、唯一の使用許可フラグがこれだけの場合、フォント所有者の許可がなければ埋め込みを禁止します。
- `PreviewPrint` は閲覧と印刷の一時使用を許可します。フォントを含む文書は読み取り専用である必要があります。
- `Editable` は一時使用を許可し、文書の編集と保存を可能にします。
- `NoSubsetting` は追加の制限で、グリフのサブセット埋め込みを禁止します。このフラグがある場合はすべての文字を埋め込む必要があります。
- `BitmapOnly` は追加の制限で、アウトラインデータではなくビットマップストライクのみの埋め込みを許可します。ビットマップストライクが存在しないフォントは埋め込めません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット演算で修飾子を確認してください。`Installable` が 0 であるため、使用許可ビットをマスクして結果を `Installable` と比較し、フラグとしてチェックしないようにします。現在のフォントは最大で 1 つの使用許可ビットしか設定しませんが、古いフォントで複数設定されている場合に備えて、以下のヘルパーは最も制限の緩い許可を選択します：`Editable` → `PreviewPrint` → `Restricted`。

次の例は `getFonts` が返すすべてのフォントについて、通常、太字、斜体、太字斜体のデータを監査します。利用できないスタイル、制限付きフォント、ビットマップのみのフォント、プレビュー・印刷のみ許可されたフォント（編集可能な出力が必要なため）および既に埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合、そのフォントファミリのすべての文字を埋め込みます。

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

この検査は各フォントファイルにエンコードされた制限を報告しますが、ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込みコピーを配布する前にライセンス条件を確認することを代替するものではありません。

## **埋め込みフォントの追加**

[addEmbeddedFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) を使用してフォントを埋め込みます。オーバーロードにより、[IFontData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embedfontcharacters/) 列挙型で埋め込む文字を制御します。

- [All](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受信者がプレゼンテーションを編集し、新しいテキストを入力できるようにする場合に使用します。
- [OnlyUsed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embedfontcharacters/) はプレゼンテーションで使用された文字だけを埋め込み、ファイルサイズを削減します。閲覧主体の完成したプレゼンテーションに適しています。

次の例は `Fonts.pptx` で使用されているフォントを [getFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getFonts--) で取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントはコードを実行するマシンにインストールされている必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

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

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) は、未使用文字を削除することで埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減率はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

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

受信者が後でテキストを追加する可能性がある場合は、元のファイルを保持してください。圧縮時に削除された文字は埋め込みフォントからは利用できなくなります（最初にすべての文字を埋め込んでいた場合でも同様です）。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認する方法はありますか？**

プレゼンテーションをレンダリングする環境で [getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出し、Aspose.Slides が置換するフォントを確認してください。また、[フォント置換](/slides/ja/java/font-substitution/) の設定と [フォントフォールバック](/slides/ja/java/fallback-font/) ルールもチェックします。フォールバックは欠損文字を処理するため、フォント自体に含まれない文字は埋め込みだけでは解決できません。

**Arial や Calibri などの一般的なフォントは埋め込むべきですか？**

対象環境に基づいて判断してください。すべてのマシンで必要なフォントが利用可能であれば、埋め込みは不要なファイルサイズ増加につながります。受信者やサーバーにフォントがない可能性がある場合は、ライセンスが埋め込みを許可している限り、外観を維持するために埋め込むことが有益です。