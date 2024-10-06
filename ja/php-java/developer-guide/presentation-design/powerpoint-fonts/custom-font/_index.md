---
title: カスタム PowerPoint フォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/php-java/custom-font/
keywords: "フォント、カスタムフォント、PowerPoint プレゼンテーション、Java、Aspose.Slides for PHP via Java"
description: "PowerPoint カスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slides では、[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントを読み込むことができます:

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides では、インストールすることなくプレゼンテーションでレンダリングされるフォントを読み込むことができます。フォントはカスタムディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) クラスで[キャッシュをクリア](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--)します。

この PHP コードはフォント読み込みプロセスを示しています:

```php
  # フォントを探すディレクトリ
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

## **カスタムフォントフォルダの取得**
Aspose.Slides では、フォントフォルダを見つけるために [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドを通じて追加されたフォルダとシステムフォントフォルダを返します。

この PHP コードは [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) を使用する方法を示しています:

```php
  # この行はフォントファイルが検索されるフォルダを出力します。
  # それらは LoadExternalFonts メソッドを通じて追加されたフォルダとシステムフォントフォルダです。
  $fontFolders = FontsLoader->getFontFolders();

```

## **プレゼンテーションで使用されるカスタムフォントの指定**
Aspose.Slides では、プレゼンテーションで使用される外部フォントを指定するために [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

この PHP コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを使用する方法を示しています:

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
    # プレゼンテーションに関する作業
    # CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダおよびそのサブフォルダのフォントがプレゼンテーションで使用可能
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **外部フォントの管理**

Aspose.Slides では、バイナリデータから外部フォントを読み込むために [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この PHP コードはバイト配列のフォント読み込みプロセスを示しています:

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
      # プレゼンテーションのライフサイクル中に読み込まれた外部フォント
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```