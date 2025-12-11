---
title: Android でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/androidjava/save-presentation/
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
- 保存の進行状況
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でプレゼンテーションを保存する方法を学びましょう — レイアウト、フォント、効果を保持しながら PowerPoint または OpenDocument にエクスポートできます。"
---

## **概要**

[Android でプレゼンテーションを開く](/slides/ja/androidjava/open-presentation/) は、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法を説明しています。このドキュメントでは、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。新規にプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、終了時に保存する必要があります。Aspose.Slides for Android を使用すると、**ファイル**または**ストリーム**に保存できます。この記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存**

Presentation クラスの `save` メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // ここで何らかの処理を行います...

    // プレゼンテーションをファイルに保存します。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **ストリームにプレゼンテーションを保存**

出力ストリームを Presentation クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリーム型に書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
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


## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides を使用すると、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを ViewProperties クラスで設定できます。[setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) メソッドに ViewType 列挙体の値を指定して使用します。
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides を使用すると、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に PptxOptions クラスを使用し、その conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存します。
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


## **Office Open XML 形式で Zip64 モードでプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限を課し、さらにアーカイブ内のファイル数は 65,535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限は 2^64 まで緩和されます。

IPptxOptions.setZip64Mode メソッドを使用すると、Office Open XML ファイルを保存するときに ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます。

- IfNecessary は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。デフォルトのモードです。
- Never は、ZIP64 形式拡張を使用しません。
- Always は、常に ZIP64 形式拡張を使用します。

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
Zip64Mode.Never で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に PptxException がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存**

PptxOptions.setRefreshThumbnail メソッドは、プレゼンテーションを PPTX に保存する際のサムネイル生成を制御します：

- `true` に設定すると、保存時にサムネイルが更新されます。デフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存しています。
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
このオプションにより、PPTX 形式でプレゼンテーションを保存する時間が短縮されます。
{{% /alert %}}

## **パーセンテージで保存進行状況を更新**

IProgressCallback インターフェイスは、ISaveOptions インターフェイスと抽象クラス SaveOptions が公開する `setProgressCallback` メソッドを通じて使用されます。`setProgressCallback` で IProgressCallback 実装を割り当てると、保存進行状況がパーセンテージで通知されます。

以下のコードスニペットは、IProgressCallback の使用方法を示しています。
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
        // ここで進捗パーセンテージの値を使用します。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose は独自の API を使用した無料の PowerPoint Splitter アプリを開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **よくある質問**

**「高速保存」（増分保存）は、変更分だけが書き込まれるようにサポートされていますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。増分の「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数のスレッドから保存することはスレッドセーフですか？**

いいえ。Presentation インスタンスはスレッドセーフではありません。単一のスレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

ハイパーリンクは保持されます。外部リンクされたファイル（例: 相対パスで参照される動画など）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（Author、Title、Company、Date）を設定／保存できますか？**

はい。標準のドキュメントプロパティがサポートされており、保存時にファイルへ書き込まれます。