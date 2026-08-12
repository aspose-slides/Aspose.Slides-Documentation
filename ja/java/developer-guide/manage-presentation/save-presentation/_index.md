---
title: Java でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/java/save-presentation/
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
- 保存進行状況
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java でプレゼンテーションを保存する方法を解説します—レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---
## **概要**

[Java でプレゼンテーションを開く](/slides/ja/java/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を説明します。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロから作成する場合でも、既存のものを変更する場合でも、終了時に保存したいでしょう。Aspose.Slides for Java を使用すると、**ファイル**または**ストリーム**に保存できます。本記事ではプレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルへのプレゼンテーションの保存**

Presentation クラスの `save` メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。次の例は Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

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

## **ストリームへのプレゼンテーションの保存**

Presentation クラスの `save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリーム型に書き込むことができます。以下の例では新しいプレゼンテーションを作成し、ファイルストリームに保存します。

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

## **事前定義されたビュータイプでの保存**

Aspose.Slides では、[ViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/) クラスを通じて、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。[setLastView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#setLastView-int-) メソッドに [ViewType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewtype/) 列挙体の値を指定して使用します。

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

## **Strict Office Open XML 形式での保存**

Aspose.Slides を使用すると、Strict Office Open XML 形式でプレゼンテーションを保存できます。[PptxOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/) クラスを使用し、保存時にその conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存します。

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

## **ZIP64 モードで Office Open XML 形式での保存**

Office Open XML ファイルは ZIP アーカイブで、圧縮前のファイルサイズ、圧縮後のサイズ、アーカイブ全体のサイズが 4 GB (2^32 バイト) を超えないこと、またファイル数が 65 535 (2^16‑1) を超えないことが制限されています。ZIP64 形式拡張によりこれらの制限が 2^64 まで緩和されます。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは次のモードで使用できます。

- [IfNecessary](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。既定のモードです。
- [Never](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を使用しません。
- [Always](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にした PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

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

{{% alert title="注" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **圧縮レベルを指定した Office Open XML 形式での保存**

大容量のプレゼンテーションを扱う場合、圧縮レベルを調整してファイルサイズと処理時間のバランスを取ることができます。要件に応じて、処理速度を優先したり、出力ファイルをできるだけ小さくしたりできます。

Aspose.Slides は、[IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) メソッドを提供しており、Office Open XML 形式で保存する際の圧縮レベルを指定できます。

利用可能な圧縮レベルは次のとおりです。

- [**None**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#None): 圧縮を行わず、ファイルをそのまま保存します。
- [**Level1**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level1): 圧縮率が最も低く、最速の圧縮です。
- [**Level2**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level2): **Level1** より若干高い圧縮率で、比較的高速です。
- [**Level3**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level3): **Level2** より高い圧縮率で、処理時間への影響は中程度です。
- [**Level4**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level4): **Level3** より高い圧縮率です。
- [**Level5**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level5): **Level4** より高い圧縮率で、追加の処理時間がかかります。
- [**Level6**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level6): 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。*既定の圧縮レベル* です。
- [**Level7**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level7): **Level6** より高い圧縮率ですが、処理が遅くなります。
- [**Level8**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level8): **Level7** より高い圧縮率です。
- [**Level9**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level9): 最大圧縮で、最も小さなファイルサイズになりますが、処理時間が最長になります。

次の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

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

## **サムネイルを更新せずに保存**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) メソッドは、PPTX 形式で保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。既定値です。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX 形式でプレゼンテーションを保存します。

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

{{% alert title="情報" color="info" %}}
このオプションを使用すると、PPTX 形式での保存にかかる時間を短縮できます。
{{% /alert %}}

## **保存進行状況をパーセンテージで取得**

[IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isaveoptions/) インターフェイスと抽象クラス [SaveOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveoptions/) で公開されている `setProgressCallback` メソッドを介して使用されます。`setProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) 実装を割り当てると、保存進行状況がパーセンテージで取得できます。

以下のコードスニペットは `IProgressCallback` の使用例を示しています。

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // ここで進捗のパーセンテージ値を使用します。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="情報" color="info" %}}
Aspose は独自 API を使用した無料の PowerPoint Splitter アプリ ([https://products.aspose.app/slides/ja/splitter](https://products.aspose.app/slides/ja/splitter)) を提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数ファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（増分保存）はサポートされていますか？変更部分だけが書き込まれますか？**

いいえ。保存は毎回完全なターゲット ファイルを作成します。増分の「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスは[スレッド セーフではありません](/slides/ja/java/multithreading/); 1 つのスレッドからのみ保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/java/manage-hyperlinks/) は保持されます。外部リンクされたファイル (例: 相対パスで参照される動画) は自動的にコピーされません。参照されるパスが引き続きアクセス可能であることを確認してください。

**ドキュメント メタデータ (作成者、タイトル、会社、日付) を設定/保存できますか？**

はい。標準の[ドキュメント プロパティ](/slides/ja/java/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。