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
- フォントをロード
- フォントを管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP用 Aspose.Slides（Java）で PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のある状態に保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)メソッドを使用してこれらのフォントをロードできます。

* TrueType（.ttf）およびTrueType Collection（.ttc）フォント。詳しくは[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType（.otf）フォント。詳しくは[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slidesでは、システムにインストールせずにプレゼンテーションで使用されているフォントをロードできます。これにより、PDFや画像などのエクスポート出力や他のサポートされている形式が環境間で一貫した外観になります。フォントはカスタムディレクトリからロードされます。

1. フォントファイルが含まれるフォルダーを1つ以上指定します。
2. 静的な[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/)メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/)メソッドを呼び出してフォントキャッシュをクリアします。

以下のコード例はフォントロードプロセスを示すコード例です：
```php
// カスタムフォントファイルを含むフォルダーを定義します。
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例：PDF、画像、その他の形式）。
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="注意" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/)はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。  
フォントは以下の順序で初期化されます。

1. 既定のオペレーティングシステムのフォントパス。
1. FontsLoaderを介してロードされたパス。

{{%/alert %}}

## **カスタムフォントフォルダーの取得**
Aspose.Slidesは[getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)メソッドを提供し、フォントフォルダーを取得できます。このメソッドはLoadExternalFontsメソッドで追加されたフォルダーとシステムのフォントフォルダーを返します。

このPHPコードは[getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)の使用方法を示しています：
```php
  # この行はフォントファイルが検索されるフォルダーを出力します。
  # それらは LoadExternalFonts メソッドを介して追加されたフォルダーとシステムフォントフォルダーです。
  $fontFolders = FontsLoader->getFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slidesは[setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

このPHPコードは[setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)プロパティの使用方法を示しています：
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
    # カスタムフォント1、カスタムフォント2、および assets\fonts と global\fonts フォルダーとそのサブフォルダーのフォントはプレゼンテーションで利用可能です
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **フォントの外部管理**

Aspose.Slidesは[loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)メソッドを提供し、バイナリデータから外部フォントをロードできます。

このPHPコードはバイト配列によるフォントロードプロセスを示しています：
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
      # プレゼンテーションの実行期間中に外部フォントがロードされます
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラによって使用されます。

**カスタムフォントは生成されたPPTXに自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTXに埋め込むことと同じではありません。プレゼンテーションファイルにフォントを組み込む必要がある場合は、明示的な[embedding features](/slides/ja/php-java/embedded-font/)を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。要求されたグリフが存在しない場合に使用するフォントを正確に定義するために、[font substitution](/slides/ja/php-java/font-substitution/)、[replacement rules](/slides/ja/php-java/font-replacement/)、および[fallback sets](/slides/ja/php-java/fallback-font/)を設定します。

**Linux/Dockerコンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントをロードします。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

**ライセンスはどうですか——制限なしにカスタムフォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はさまざまで、埋め込みや商用利用を禁止しているライセンスもあります。出力を配布する前に必ずフォントのEULAを確認してください。