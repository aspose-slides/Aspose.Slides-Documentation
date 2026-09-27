---
title: Android でプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/androidjava/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPT を作成
- 新しい PPT
- PPTX を作成
- 新しい PPTX
- ODP を作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でプレゼンテーションを作成します — PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して確実な結果を得られます。"
---
## **概要**

この文章は、Java を使用して Aspose.Slides for Android でプレゼンテーションを作成し、最初のスライドにテキスト ボックスを追加して、アプリのストレージにファイルとして保存する方法を示します。既存のプレゼンテーションを開くか別の形式で保存するには、[Open Presentation](/slides/ja/androidjava/open-presentation/) と [Save Presentation](/slides/ja/androidjava/save-presentation/) を参照してください。最後に短い FAQ があり、形式、テンプレート、スライド サイズ、単位、メモリ使用量、スレッド、ライセンス、デジタル署名、VBA サポートに関する一般的な質問に答えています。

始める前に、Aspose の Maven リポジトリから Aspose.Slides を Android プロジェクトに追加してください。[Installation](/slides/ja/androidjava/install-aspose-slides-for-android-via-java/) を参照してください。

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキスト ボックスを配置するには、次の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションにはすでに空のスライドが 1 枚含まれています。
1. そのスライドをインデックス 0 で [slide collection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) から取得します。
1. [shape collection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) の [addAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) メソッドで長方形を追加し、[text frame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) の [setText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) メソッドでテキストを設定します。
1. [save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドでプレゼンテーションを PPTX ファイルとして保存し、[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) 形式を指定します。

コードは `Activity` 内、たとえば `onCreate` メソッドで実行されます。ファイルは [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) メソッドが返すディレクトリ、すなわちアプリ固有のプライベート ストレージに保存され、権限を要求せずに書き込むことができます。

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

長方形の左上隅はスライドの左端から 50 ポイント、上端から 50 ポイントの位置にあり、幅 400 ポイント、高さ 100 ポイントです。保存されたファイルにはその長方形とテキストを含む 1 枚のスライドが含まれます。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します；[Licensing](/slides/ja/androidjava/licensing/) を参照してください。

ファイルを確認するには、Android Studio の [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) を開き、*data/data/* 配下のアプリの *files* フォルダーにある *hello.pptx* を探します。実際のアプリでは、ユーザー インターフェイスが応答し続けるように、バックグラウンド スレッドでプレゼンテーションを処理してください。

## **よくある質問**

### 新しいプレゼンテーションを保存できる形式は何ですか？

[PPTX、PPT、ODP](/slides/ja/androidjava/save-presentation/) に保存でき、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)、および [images](/slides/ja/androidjava/convert-powerpoint-to-png/) などにもエクスポートできます。

### テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は [サポートされています](/slides/ja/androidjava/supported-file-formats/)。

### プレゼンテーション作成時にスライドサイズ/アスペクト比を制御する方法は？

[スライド サイズ](/slides/ja/androidjava/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

### サイズと座標の単位は何ですか？

ポイント単位です。1 インチは 72 ポイントに相当します。

### 大容量のプレゼンテーション（多数のメディア ファイル）でメモリ使用量を削減するには？

[BLOB 管理戦略](/slides/ja/androidjava/manage-blob/) を使用し、テンポラリ ファイルを活用してメモリ内ストレージを制限します。純粋なメモリ内ストリームよりもファイルベースのワークフローを優先してください。

### プレゼンテーションの作成/保存を並列に行うことはできますか？

同じ [Presentation](/slides/ja/androidjava/presentation/) インスタンスを [複数スレッド](/slides/ja/androidjava/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々のインスタンスを実行してください。

### 評価版の透かしと制限を解除するには？

プロセスごとに一度だけ [ライセンスを適用](/slides/ja/androidjava/licensing/) します。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させてください。

### 作成した PPTX にデジタル署名を付与できますか？

はい。[デジタル署名](/slides/ja/androidjava/digital-signature-in-powerpoint/)（追加と検証）はプレゼンテーションでサポートされています。

### 作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？

はい。[VBA プロジェクトの作成/編集](/slides/ja/androidjava/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。