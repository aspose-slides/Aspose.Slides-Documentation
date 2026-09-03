---
title: JavaScript でのプレゼンテーションへのフォント埋め込み
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/nodejs-java/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォントの埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js via Java 用の Aspose.Slides を使用して PowerPoint の埋め込みフォントを管理します。フォントを追加、取得、削除、圧縮してテキストの外観を保ち、ファイルサイズを削減します。"
---
## **はじめに**

フォントの埋め込みは、フォントデータを PowerPoint プレゼンテーション内に格納します。ビューアが埋め込みフォントをサポートしている場合、対象システムにフォントがインストールされていなくてもそれらのフォントでテキストを表示できます。これにより、改行や文字間隔、スライドのレイアウトが保持されます。

Aspose.Slides for Node.js via Java を使用すると、[FontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/) クラスを使用して埋め込みフォントを取得、追加、削除できます。このクラスは[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getfontsmanager/)によって返されます。また、プレゼンテーションで使用されていない文字を削除することで、埋め込みフォントデータのサイズを削減できます。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、そのフォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) を使用してプレゼンテーションに格納されているフォントの一覧を取得します。フォントを削除するには、その一覧からフォントを[FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/) に渡し、プレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` に埋め込まれたフォントの一覧を表示し、存在する場合は Calibri を削除します:
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

埋め込みフォントを削除すると、保存されているフォントデータが削除されますが、テキストに割り当てられたフォントは変更されません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントを使用できます。インストールされていない場合、レンダリング時に[font substitution](/slides/ja/nodejs-java/font-substitution/)が必要になることがあり、レイアウトに影響を与える可能性があります。

## **フォントデータと埋め込み許可の検査**

[FontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/) クラスを使用して、フォントを埋め込む前に検査できます。[FontsManager.getFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getfonts/) を呼び出すと、プレゼンテーションで使用されているフォントを取得できます。各フォントについて、[FontData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontdata/) オブジェクトと必要な[FontStyleType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontstyletype/) の値を[FontsManager.getFontBytes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) に渡します。このメソッドはそのフォントスタイルのバイナリデータを返しますが、要求されたフォントまたはスタイルが利用できない場合は `null` を返します。`null` の結果を[FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) に渡さないでください。このメソッドはバイト配列を必要とします。Node.js では、返された JavaScript 配列を `java.newArray` で Java のバイト配列に変換してから `getFontEmbeddingLevel` に渡します。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/embeddinglevel/) は、フォントに保存されている埋め込み制限をフラグの集合として報告します。

- `Installable` は、フォントライセンスに従い、埋め込みと別システムへの永続的なインストールを許可します。
- `Restricted` は、他の使用許可フラグがなく、フォントの権利者から許可を得ない限り埋め込みを禁止します。
- `PreviewPrint` は、閲覧と印刷の一時的な使用を許可します。フォントを含むドキュメントは読み取り専用である必要があります。
- `Editable` は、一時的な使用を許可し、ドキュメントの編集および保存を可能にします。
- `NoSubsetting` は、グリフのサブセットのみの埋め込みを禁止する追加制限です。このフラグがある場合はすべての文字を埋め込んでください。
- `BitmapOnly` は、アウトラインデータではなくビットマップ字形のみの埋め込みを許可する追加制限です。フォントにビットマップ字形がない場合、埋め込むことはできません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット演算で修飾子を確認してください。`Installable` は 0 であるため、使用許可ビットをマスクし、フラグとしてチェックするのではなく `Installable` と比較します。現在のフォントは使用許可ビットを最大 1 つだけ設定すべきです。複数設定されている古いフォントとの互換性のため、以下のヘルパーは最も制限が緩い許可を選択します: `Editable`、次に `PreviewPrint`、最後に `Restricted`。

次の例は `getFonts` で取得したすべてのフォントについて、レギュラー、ボールド、イタリック、ボールドイタリックのデータを監査します。利用できないスタイル、制限付きフォント、ビットマップ専用フォント、プレビューと印刷に限定されたフォント（出力が編集可能なままであるため）およびすでに埋め込まれているフォントはスキップします。利用可能なスタイルのいずれかに `NoSubsetting` がある場合、そのフォントファミリのすべての文字を埋め込みます。
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

この検査は各フォントファイルにエンコードされた制限を報告します。ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込みコピーを配布する前にフォントのライセンス契約を確認することの代わりにはなりません。

## **埋め込みフォントの追加**

[FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) を使用してフォントを埋め込みます。このメソッドのオーバーロードは、[FontData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/embedfontcharacters/) は、含める文字を制御します。

- `All` はフォント内のすべての文字を埋め込みます。受信者がプレゼンテーションを編集し新しいテキストを入力できるようにする必要がある場合にこのオプションを使用します。
- `OnlyUsed` はプレゼンテーションで使用された文字のみを埋め込み、ファイルサイズを縮小します。主に閲覧用の完成したプレゼンテーションの場合はこのオプションを選択してください。

次の例は [FontsManager.getFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getfonts/) を使用して `Fonts.pptx` で使用されているフォントを取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントはコードを実行するマシン上に存在している必要があります。既存の埋め込みフォントは現在の文字セットを保持します。
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

## **埋め込みフォントの圧縮**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/compressembeddedfonts/) は、未使用の文字を削除して埋め込みフォントデータを削減します。既に埋め込まれているフォントに対して動作するため、サイズ削減はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します:
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

受信者が後でテキストを追加する可能性がある場合は、元のファイルを残しておいてください。圧縮中に削除された文字は、元々すべての文字を埋め込んでいた場合でも、埋め込みフォントからは利用できなくなります。

## **FAQ**

**埋め込みフォントがレンダリング時にまだ置換されるかどうかを確認するにはどうすればよいですか？**

プレゼンテーションをレンダリングする環境で[FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) を呼び出すと、Aspose.Slides が置換するフォントを確認できます。また、[font substitution](/slides/ja/nodejs-java/font-substitution/) の設定と[font fallback](/slides/ja/nodejs-java/fallback-font/) のルールも確認してください。フォールバックは欠落した文字を処理するため、フォントを埋め込んでもそのフォント自体に含まれない文字は解決されません。

**Arial や Calibri などの一般的なフォントを埋め込むべきですか？**

決定は対象環境に基づいて行ってください。必要なフォントがプレゼンテーションを開くまたはレンダリングするすべてのマシンで利用可能であれば、埋め込むことで不要なファイルサイズが増える可能性があります。受信者やサーバーにこれらのフォントがない場合、ライセンスが許可している限り、埋め込むことで意図した外観を保つのに役立ちます。