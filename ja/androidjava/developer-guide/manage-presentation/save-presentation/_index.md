---
title: Android でプレゼンテーションを保存する
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/androidjava/save-presentation/
keywords:
- PowerPoint の保存
- OpenDocument の保存
- プレゼンテーションの保存
- スライドの保存
- PPT の保存
- PPTX の保存
- ODP の保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進捗
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でプレゼンテーションを保存する方法を紹介します。レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument 形式にエクスポートできます。"
---

## **概要**

[Open Presentations on Android](/slides/ja/androidjava/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。新規に作成する場合でも既存のものを修正する場合でも、完了したら保存したくなるでしょう。Aspose.Slides for Android を使用すると、**ファイル**または**ストリーム**に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存する**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスの `save` メソッドを呼び出すことで、プレゼンテーションをファイルに保存できます。メソッドにファイル名と保存形式を渡します。以下の例は Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // ここで処理を行います...

    // プレゼンテーションをファイルに保存します。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **ストリームにプレゼンテーションを保存する**

出力ストリームを[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことが可能です。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // プレゼンテーションをストリームに保存します。
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **事前定義されたビュータイプでプレゼンテーションを保存する**

Aspose.Slides は、生成されたプレゼンテーションが開く際に PowerPoint が使用する初期ビューを[ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/) クラスを介して設定できます。[setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) メソッドに[ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/) 列挙体の値を渡して使用します。
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Strict Office Open XML 形式でプレゼンテーションを保存する**

Aspose.Slides は、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に[PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // プレゼンテーションを Strict Office Open XML 形式で保存します。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Zip64 モードで Office Open XML 形式のプレゼンテーションを保存する**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限があり、またファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限は 2^64 まで緩和されます。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超えた場合にのみ ZIP64 形式拡張を使用します。これはデフォルトモードです。
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を一切使用しません。
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています。
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}}

[Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に[PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) がスローされます。

{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存する**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) メソッドは、PPTX に保存する際のサムネイル生成を制御します:

- `true` に設定すると、保存中にサムネイルが更新されます。これがデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存します。
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

このオプションにより、PPTX 形式での保存に要する時間を短縮できます。

{{% /alert %}}

## **進捗をパーセンテージで取得する**

[IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/) インターフェイスおよび抽象クラス[SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/) に公開されている `setProgressCallback` メソッドを介して使用されます。`setProgressCallback` に[IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) 実装を割り当てることで、保存進捗がパーセンテージで通知されます。

以下のコードスニペットは `IProgressCallback` の使用例を示します。
```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ここで進捗のパーセンテージ値を使用します。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}

Aspose は、独自 API を使用した[無料の PowerPoint Splitter アプリ](https://products.aspose.app/slides/splitter) を開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。

{{% /alert %}}

## **FAQ**

**「高速保存」(インクリメンタル保存) がサポートされ、変更分だけが書き込まれますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルな「高速保存」はサポートされていません。

**同一の Presentation インスタンスを複数スレッドから同時に保存することは安全ですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) インスタンスはスレッドセーフではありません。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[Hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで参照されるビデオ）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ (Author、Title、Company、Date) を設定/保存できますか？**

はい。標準の[document properties](/slides/ja/androidjava/presentation-properties/) がサポートされ、保存時にファイルに書き込まれます。