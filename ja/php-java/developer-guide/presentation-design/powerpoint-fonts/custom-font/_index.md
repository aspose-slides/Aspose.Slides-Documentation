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
- フォントを読み込む
- フォントを管理する
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをあらゆるデバイスで鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は、これらのフォントを [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用して読み込むことができます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType（.otf）フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides は、フォントをインストールせずにプレゼンテーションでレンダリングされるフォントを読み込むことができます。フォントはカスタムディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [Clear the cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) を [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) クラスで実行します。

この PHP コードはフォント読み込みプロセスを示しています：
```php
  # フォントを探すフォルダー
  $folders = array($externalFontsDir );
  # カスタムフォントディレクトリのフォントを読み込む
  FontsLoader->loadExternalFonts($folders);
  # 作業を行い、プレゼンテーション/スライドのレンダリングを実行
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # フォントキャッシュをクリア
    FontsLoader->clearCache();
  }
```


## **カスタムフォントフォルダーの取得**
Aspose.Slides は、フォントフォルダーを検索できるように [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステムフォントフォルダーを返します。

この PHP コードは [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています：
```php
  # この行はフォントファイルが検索されるフォルダーを出力します。
  # それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
  $fontFolders = FontsLoader->getFontFolders();

```


## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定できるように [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

この PHP コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティの使用方法を示しています：
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
    # プレゼンテーションを操作する
    # カスタムフォント1、カスタムフォント2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダーのフォントがプレゼンテーションで使用可能です
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **外部フォントの管理**
Aspose.Slides は、バイナリデータから外部フォントを読み込むために [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この PHP コードはバイト配列フォントの読み込みプロセスを示しています：
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
      # プレゼンテーションのライフタイム中に外部フォントがロードされます
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **よくある質問**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはレンダラーによってすべてのエクスポート形式で使用されます。

**カスタムフォントは結果の PPTX に自動的に埋め込まれますか？**

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むことと同等ではありません。プレゼンテーションファイル内にフォントを保持する必要がある場合は、明示的な [埋め込み機能](/slides/ja/php-java/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフが欠けているときのフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/php-java/font-substitution/)、[置換ルール](/slides/ja/php-java/font-replacement/)、および [フォールバックセット](/slides/ja/php-java/fallback-font/) を構成して、要求されたグリフが存在しない場合に使用されるフォントを正確に定義できます。

**Linux/Docker コンテナ内でシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントを読み込むことで、コンテナイメージ内のシステムフォントディレクトリへの依存を排除できます。

**ライセンスに関して—カスタムフォントを制約なしに埋め込むことはできますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件は様々で、埋め込みや商用利用を禁止しているものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。