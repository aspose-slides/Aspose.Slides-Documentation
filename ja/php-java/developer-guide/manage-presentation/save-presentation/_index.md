---
title: PHPでプレゼンテーションを保存する
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/php-java/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進捗
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用してプレゼンテーションを保存する方法を学びます — レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---
## **概要**

[Open Presentations in PHP](/slides/ja/php-java/open-presentation/) は、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法を説明しています。この記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、終了時に保存したいでしょう。Aspose.Slides for PHP を使用すると、**ファイル**または**ストリーム**に保存できます。この記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルへのプレゼンテーションの保存**

プレゼンテーションをファイルに保存するには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスの `save` メソッドを呼び出します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // ここで何らかの処理を行います...

    // プレゼンテーションをファイルに保存します。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ストリームへのプレゼンテーションの保存**

出力ストリームを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // プレゼンテーションをストリームに保存します。
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **事前定義されたビュータイプでのプレゼンテーションの保存**

Aspose.Slides を使用すると、生成されたプレゼンテーションが開かれる際に PowerPoint が使用する初期ビューを、[ViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/) クラスで設定できます。[setLastView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#setLastView) メソッドに、[ViewType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewtype/) 列挙体の値を指定して使用します。

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Strict Office Open XML 形式でのプレゼンテーションの保存**

Aspose.Slides を使用すると、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存します。

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // Strict Office Open XML 形式でプレゼンテーションを保存します。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 モードで Office Open XML 形式のプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限があり、またアーカイブ内のファイル数は 65 535 (2^16‑1) に制限されています。ZIP64 形式拡張により、これらの制限は 2^64 まで緩和されます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは次のモードで使用できます。

- [IfNecessary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これはデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を決して使用しません。
- [Always](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションが ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **圧縮レベルを指定した Office Open XML 形式でのプレゼンテーションの保存**

大容量のプレゼンテーションを扱う場合、圧縮レベルを調整してファイルサイズと処理時間のバランスを取ることができます。要件に応じて、処理速度を優先したり、出力ファイルを小さくしたりできます。

Aspose.Slides は、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを提供しており、Office Open XML 形式で保存する際に使用する圧縮レベルを指定できます。

利用可能な圧縮レベルは以下のとおりです。

- [**None**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#None): 圧縮は適用されません。ファイルはそのまま保存されます。
- [**Level1**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level1): 圧縮率が最も低く、最速の圧縮です。
- [**Level2**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level2): **Level1** より若干高い圧縮率で、比較的高速です。
- [**Level3**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level3): **Level2** より高い圧縮率で、処理時間への影響は中程度です。
- [**Level4**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level4): **Level3** より高い圧縮率です。
- [**Level5**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level5): **Level4** よりさらに高い圧縮率で、追加の処理時間がかかります。
- [**Level6**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level6): 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。これは *デフォルトの圧縮レベル* です。
- [**Level7**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level7): **Level6** より高い圧縮率ですが、処理は遅くなります。
- [**Level8**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level8): **Level7** より高い圧縮率です。
- [**Level9**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compressionlevel/#Level9): 最大圧縮です。最も小さいファイルサイズになりますが、処理時間が最も長くなります。

以下の例は、*圧縮なし*で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

この例は、*最大圧縮*で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドは、PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。これがデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX にプレゼンテーションを保存する例です。

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
このオプションを使用すると、PPTX 形式でプレゼンテーションを保存する時間を短縮できます。
{{% /alert %}}

## **進捗をパーセンテージで更新**

保存進捗のレポートは、[SaveOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/) およびそのサブクラスの [setProgressCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/#setProgressCallback) メソッドで構成できます。Java プロキシで [IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、エクスポート中にコールバックが定期的にパーセンテージ更新を受け取ります。

以下のコードスニペットは、`IProgressCallback` の使用例を示しています。

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // ここで進捗のパーセンテージ値を使用します。
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose は、自社 API を使用した [無料の PowerPoint Splitter アプリ](https://products.aspose.app/slides/ja/splitter) を開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）は、変更部分だけを書き込む形でサポートされていますか？**

いいえ。保存は毎回完全なターゲット ファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数のスレッドから同時に保存することはスレッド セーフですか？**

いいえ。[Presentation](/slides/ja/php-java/multithreading/) インスタンスはスレッド セーフではありません。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどう扱われますか？**

[ハイパーリンク](/slides/ja/php-java/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスによる動画）は自動的にはコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の [ドキュメント プロパティ](/slides/ja/php-java/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。