---
title: Android でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
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
- 保存進捗
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でプレゼンテーションを保存する方法を紹介します。レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---
## **概要**

[Open Presentations on Android](/slides/ja/androidjava/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本稿では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。最初からプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなります。Aspose.Slides for Android を使用すると、**ファイル**または**ストリーム**に保存できます。本稿では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存**

プレゼンテーションをファイルに保存するには、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスの `save` メソッドを呼び出します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```java
import com.aspose.slides.*;

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

出力ストリームを [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

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

## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides では、[ViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/) クラスを介して、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。`setLastView` メソッドに [ViewType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewtype/) 列挙体から値を指定して使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides では、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/) クラスを使用し、その `conformance` プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。

```java
import com.aspose.slides.*;

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

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、圧縮前の任意のファイルサイズ、圧縮後のファイルサイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限があり、またファイル数は 65 535 (2^16‑1) に制限されています。ZIP64 形式拡張はこれらの制限を 2^64 まで緩和します。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます。

- [IfNecessary](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を一切使用しません。
- [Always](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にした状態で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```java
import com.aspose.slides.*;

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
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **圧縮レベルで Office Open XML 形式でプレゼンテーションを保存**

大規模なプレゼンテーションを扱う場合、ファイルサイズと処理時間のバランスを取るために圧縮レベルを調整できます。要件に応じて、処理速度を優先するか、出力ファイルを小さくするかを選択できます。

Aspose.Slides は、[IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) メソッドを提供しており、Office Open XML 形式で保存する際の圧縮レベルを指定できます。

利用可能な圧縮レベルは以下のとおりです。

- [**None**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#None): 圧縮が適用されません。ファイルはそのまま保存されます。
- [**Level1**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level1): 圧縮速度が最速で、圧縮率は最低です。
- [**Level2**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level2): **Level1** より若干高い圧縮率で、比較的高速です。
- [**Level3**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level3): **Level2** より高い圧縮率を提供し、処理時間への影響は中程度です。
- [**Level4**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level4): **Level3** より高い圧縮率を提供します。
- [**Level5**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level5): **Level4** より改善された圧縮率を提供しますが、処理時間が追加でかかります。
- [**Level6**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level6): 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。これが *デフォルトの圧縮レベル* です。
- [**Level7**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level7): **Level6** より高い圧縮率を提供しますが、処理は遅くなります。
- [**Level8**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level8): **Level7** より高い圧縮率を提供します。
- [**Level9**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level9): 最大の圧縮率です。最小のファイルサイズを実現しますが、処理時間が最長になります。

以下の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

この例は、最大圧縮で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) メソッドは、PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます（既定設定）。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX 形式でプレゼンテーションを保存する例です。

```java
import com.aspose.slides.*;

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
このオプションを使用すると、PPTX 形式での保存にかかる時間を短縮できます。
{{% /alert %}}

## **進捗率で保存状況を取得**

[IProgressCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isaveoptions/) インターフェイスと抽象クラス [SaveOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/) が公開する `setProgressCallback` メソッドで使用されます。`setProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprogresscallback/) の実装を割り当てることで、保存進捗をパーセンテージで受け取ることができます。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ここで進捗のパーセンテージ値を使用します。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose は独自の API を使用した無料の PowerPoint Splitter アプリ https://products.aspose.app/slides/ja/splitter を提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（増分保存）はサポートされていますか？**

いいえ。保存は毎回完全な対象ファイルを作成します。増分の「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/androidjava/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/androidjava/manage-hyperlinks/) は保持されます。外部リンクされたファイル（たとえば相対パスで参照される動画など）は自動的にはコピーされないため、参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作成者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の [ドキュメント プロパティ](/slides/ja/androidjava/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。