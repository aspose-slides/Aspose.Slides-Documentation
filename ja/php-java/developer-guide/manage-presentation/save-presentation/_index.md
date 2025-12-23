---
title: PHPでプレゼンテーションを保存する
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/php-java/save-presentation/
keywords:
- PowerPointを保存
- OpenDocumentを保存
- プレゼンテーションを保存
- スライドを保存
- PPTを保存
- PPTXを保存
- ODPを保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進行状況
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP (Java 経由) を使用してプレゼンテーションを保存する方法を紹介します — レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---

## **概要**

[PHPでプレゼンテーションを開く](/slides/ja/php-java/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも既存のものを変更する場合でも、作業が完了したら保存する必要があります。Aspose.Slides for PHP を使用すると、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **プレゼンテーションをファイルに保存**

プレゼンテーションは、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスの `save` メソッドを呼び出すことでファイルに保存できます。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation();
try {
    // ここで作業を行います...
    // プレゼンテーションをファイルに保存します。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **プレゼンテーションをストリームに保存**

出力ストリームを[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
```php
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します。
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


## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides を使用すると、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) クラスで設定できます。[ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/) 列挙体の値を使用して、[setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) メソッドを呼び出します。
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides を使用すると、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し Strict Office Open XML 形式で保存する方法を示しています。
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation();
try {
    // プレゼンテーションを Strict Office Open XML 形式で保存します。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの未圧縮サイズ、圧縮サイズ、およびアーカイブ全体のサイズに 4 GB (2^32 バイト) の制限が課され、さらにアーカイブ内のファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張はこれらの制限を 2^64 まで引き上げます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます。

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。既定のモードです。
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を使用しません。
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています。
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
[Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドは、PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。既定設定です。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存する例です。
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
このオプションは、PPTX 形式での保存に要する時間を短縮するのに役立ちます。
{{% /alert %}}

## **保存時の進行状況をパーセンテージで取得**

保存時の進行状況レポートは、[SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) およびそのサブクラスの [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) メソッドで構成します。Java のプロキシで [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、エクスポート中にコールバックが定期的にパーセンテージ更新を受け取ります。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // ここで進捗パーセンテージの値を使用します。
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
Aspose は独自の API を利用した無料の PowerPoint Splitter アプリ ([https://products.aspose.app/slides/splitter](https://products.aspose.app/slides/splitter)) を開発しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）は、変更分だけが書き込まれるようにサポートされていますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数のスレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) インスタンスは **スレッドセーフではありません** (/slides/ja/php-java/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/php-java/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで指定された動画）は自動的にはコピーされません。参照パスが引き続き利用可能であることを確認してください。

**文書メタデータ（作者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の [ドキュメント プロパティ](/slides/ja/php-java/presentation-properties/) がサポートされており、保存時にファイルへ書き込まれます。