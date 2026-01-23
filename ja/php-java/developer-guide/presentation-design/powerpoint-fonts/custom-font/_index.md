---
title: PHPでPowerPointのフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/php-java/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントの読み込み
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP (Javaを介して) を使用してPowerPointスライドのフォントをカスタマイズし、どのデバイスでもプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides では、次の [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してフォントをロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照。
* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照。

{{% /alert %}}

## **カスタム フォントのロード**

Aspose.Slides では、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより PDF、画像、その他のサポート形式へのエクスポート時に、環境間で一貫した外観が保たれます。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。
2. 静的な [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出し、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォント ロード プロセスを示しています:
```php
// カスタムフォントファイルを含むフォルダーを定義します。
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // ロードされたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) は検索パスにフォルダーを追加しますが、フォント の初期化順序は変更しません。初期化順序は以下の通りです。

1. デフォルトの OS フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) 経由でロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**
Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォント フォルダーを検索できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この PHP コードは [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています:
```php
  # この行はフォントファイルが検索されるフォルダーを出力します。
  # これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
  $fontFolders = FontsLoader->getFontFolders();
```


## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は、[setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources) メソッドを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この PHP コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources) の使用方法を示しています:
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # プレゼンテーションで作業する
    # カスタムフォント CustomFont1、CustomFont2 と assets\fonts および global\fonts フォルダーとそのサブフォルダーのフォントがプレゼンテーションで利用可能です
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントをロードできる [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この PHP コードはバイト配列によるフォント ロード プロセスをデモしています:
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # プレゼンテーションの実行中にロードされた外部フォント
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**カスタム フォントはすべての形式 (PDF、PNG、SVG、HTML) のエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラーによって使用されます。

**カスタム フォントは自動的に結果の PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイルにフォントを含める必要がある場合は、明示的な [埋め込み機能](/slides/ja/php-java/embedded-font/) を使用してください。

**カスタム フォントに特定のグリフがない場合のフォールバック 動作を制御できますか？**

はい。[フォント置換](/slides/ja/php-java/font-substitution/)、[置換ルール](/slides/ja/php-java/font-replacement/)、および [フォールバック セット](/slides/ja/php-java/fallback-font/) を設定して、要求されたグリフが欠落しているときに使用するフォントを正確に定義できます。

**Linux/Docker コンテナーでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードしてください。これにより、コンテナー イメージ内のシステム フォント ディレクトリへの依存が排除されます。

**ライセンス面では、制限なしにカスタム フォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条項はさまざまで、埋め込みや商用利用を禁止するものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。