---
title: PHPでPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/php-java/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントのロード
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint スライドのフォントをカスタマイズし、どのデバイスでもプレゼンテーションを鮮明かつ一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides は、オペレーティングシステムにインストールせずに、プレゼンテーションでカスタムフォントを使用できるようにします。カスタムフォルダーからフォントをロードしたり、ドキュメントレベルのフォントソースを通じて特定のプレゼンテーション用のフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされるときに使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポート時です。これにより、異なる環境間でプレゼンテーションの出力が一貫します。本記事では、Aspose.Slides が使用するフォントフォルダーの確認方法と、外部フォント使用後のフォントキャッシュのクリア方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に保存する必要がある場合は、埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の文字体系ごとに異なるフォントファミリーを参照できます。これらのマッピングはフォント名を保存しますが、フォントファイルをインストールまたはロードしません。[スクリプト固有のテーマフォント](/slides/ja/php-java/script-specific-font-mappings/) を参照してマッピングを管理し、以下のロードオプションを使用して参照されたフォントを一貫したレンダリングのために利用できるようにしてください。

{{% alert color="info" title="Note" %}}
Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントをロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。
* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。
{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポート形式へのエクスポート出力が環境間で一貫します。フォントはカスタムディレクトリからロードされます。

1. フォント ファイルが格納されている 1 つ以上のフォルダーを指定します。
2. 静的な [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードしてレンダリング/エクスポートします。
4. [FontsLoader::clearCache](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#clearCache--) を呼び出してフォントキャッシュをクリアします。

以下のコード例はフォントロードのプロセスを示しています。

```php
// カスタムフォントファイルを含むフォルダーを定義します。
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスに追加フォルダーを加えますが、フォント初期化順序は変更しません。フォントは以下の順序で初期化されます。

1. デフォルトのオペレーティングシステムのフォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/) によってロードされたパス。
{{%/alert %}}

## **カスタムフォントフォルダーの取得**

Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォントフォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この PHP コードは [getFontFolders](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています。

```php
# この行はフォントファイルが検索されるフォルダーを出力します。
# これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
$fontFolders = FontsLoader::getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slides は、[LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) メソッドを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この PHP コードは [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) の使用方法を示しています。

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # プレゼンテーションを操作します
    # CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **フォントを外部で管理する**

Aspose.Slides は、バイナリ データから外部フォントをロードできる [loadExternalFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この PHP コードはバイト配列フォントのロードプロセスを示しています。

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # 外部フォントはプレゼンテーションのライフタイム中にロードされます
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **よくある質問**

### カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？

はい。接続されたフォントはすべてのエクスポート形式でレンダラによって使用されます。

### カスタムフォントは自動的に生成された PPTX に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に保持する必要がある場合は、明示的に [埋め込み機能](/slides/ja/php-java/embedded-font/) を使用してください。

### カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？

はい。[フォント置換](/slides/ja/php-java/font-substitution/)、[置換ルール](/slides/ja/php-java/font-replacement/)、および [フォールバックセット](/slides/ja/php-java/fallback-font/) を構成して、要求されたグリフが欠落しているときに使用するフォントを正確に定義できます。

### Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォントフォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナイメージ内のシステム フォント ディレクトリへの依存がなくなります。

### ライセンスについて—カスタムフォントを制限なく埋め込めますか？

フォントのライセンス コンプライアンスは利用者の責任です。ライセンス条件はさまざまで、埋め込みや商用利用を禁止するものもあります。出力を配布する前に必ずフォントの EULA を確認してください。