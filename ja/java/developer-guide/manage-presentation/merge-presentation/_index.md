---
title: Javaでプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/java/merge-presentation/
keywords:
- PowerPoint をマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPT をマージ
- PPTX をマージ
- ODP をマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- Java
- Aspose.Slides
description: "スライドをクローンし、マスターとレイアウトを制御し、スライド コンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大型ファイルを処理することで、Java で PowerPoint および OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、1つの [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) から別のプレゼンテーションへスライドをクローンすることでプレゼンテーションを結合します。主な操作は [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) で、ソーススライドの書式設定を保持したり、クローンされたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この記事では最も一般的な結合ワークフローを取り上げます。

- ソースの書式を保持したまますべてのスライドを結合する;
- 選択したスライドだけを結合する;
- 宛先プレゼンテーションのマスターを適用する;
- 宛先プレゼンテーションの特定のレイアウトを適用する;
- 結合前にスライドサイズを正規化する;
- セクションにクローンされたスライドを追加する;
- 複数のプレゼンテーションを 1 つのエンドツーエンド ワークフローで結合する;
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドの考慮事項を処理する。

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の大部分を継承します。そのため、選択するクローンのオーバーロードが結合後のスライドが宛先プレゼンテーションにどのように統合されるかを決定します。

以下のいずれかの方法で [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) を使用します:

- `addClone(sourceSlide)` — ソーススライドのレイアウトと書式設定を保持します。必要に応じて、ソースマスターは自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを内部で追跡し、同じソースマスターを使用するスライドが繰り返しクローンされても重複クローンが発生しません。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) に添付します。Aspose.Slides はマスター配下でレイアウトタイプまたは名前に基づいて一致するレイアウトを検索します。
- `addClone(sourceSlide, destinationLayout)` — クローンされたスライドを特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/) に直接添付します。

`addClone` オーバーロードに渡すマスターまたはレイアウトは **宛先** プレゼンテーションに属している必要があり、ソースプレゼンテーションには属していてはいけません。

## **プレゼンテーション全体を結合し、ソース書式を保持する**

最も単純な結合は、ソースプレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適した選択肢です。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ソースと宛先が異なるデザインを使用している場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これはソース書式を意図的に保持した場合に期待される動作です。

## **選択したスライドを結合する**

すべてのスライドをクローンする必要はありません。以下の例は、ソースプレゼンテーションから選択したスライド インデックスだけをインポートします。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

スライド インデックスがユーザー入力や外部設定から来る場合は、クローン前に検証してください。

## **宛先マスターを使用してスライドを結合する**

インポートされたスライドが既に宛先プレゼンテーションに存在するマスターに従うべき場合は、[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides は、ソースレイアウトのタイプまたは名前に一致する適切なレイアウトを指定されたマスター配下で選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドを追加できるようになります。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) がスローされます。

マージを失敗させて宛先マスターに余分なレイアウトを追加したくない場合は `false` を使用してください。

## **特定の宛先レイアウトを使用してスライドを結合する**

インポートされたスライドが使用すべき宛先レイアウトが正確に分かっている場合は、[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) オーバーロードを使用します。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

宛先レイアウトを適用すると、継承されたレイアウトの関係が変更されますが、ソーススライドの内容が再設計されるわけではありません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合は、結果を確認し、継承された書式とプレースホルダーの動作が適切かどうかを検証してください。

## **異なるスライドサイズのプレゼンテーションを結合する**

スライド寸法が異なるプレゼンテーションでも結合は可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバス用に自動的に再設計されません。そのため、形状がずれたり、予期せず拡大縮小されたり、スライド領域の外に出てしまうことがあります。

実用的なアプローチは、クローン前にソースプレゼンテーションのサイズを変更することです。`[SlideSize.setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesize/#setSize-float-float-int-)` メソッドは、スライド寸法を変更しながら既存コンテンツをスケーリングできます。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/)` はコンテンツを要求サイズに収めるようスケーリングします。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

リサイズはメモリ上のソースプレゼンテーション オブジェクトを変更します。元のソースプレゼンテーションを他の操作でそのまま使用したい場合は、マージ用に別インスタンスを開いてください。

## **プレゼンテーションのセクションにスライドを結合する**

基本的なスライド クローン ループは、ソースプレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、`[addClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` を使用して明示的にスライドをセクションにクローンします。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

クローンされたスライドは指定された宛先セクションに追加されます。複数のソースセクションを保持したい場合は、[Presentation.getSections](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSections--) を列挙し、各ソースセクションのスライドを [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSlidesListOfSection--) で取得し、宛先で同じセクション構造を再作成してから対応するセクションにスライドをクローンしてください。完全なセクション列挙サンプルは [Manage Slide Sections](/slides/ja/java/slide-section/) を参照してください（空セクションや構造変更も含む）。

## **複数のプレゼンテーションを安全に結合する**

次のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、各追加ソースのスライドサイズを正規化し、ソースをコピー中だけ開き、最後に一度だけファイルを保存します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

これはインポートされたスライドのソース書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、単純な `addClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウト オーバーロードに置き換えてください。

## **実務上の考慮点**

### **マスター、レイアウト、および書式忠実度**

デフォルトのスライド クローン は、必要に応じてソースマスターを宛先プレゼンテーションに自動で持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターの重複クローンを防ぎます。手動で事前にマスターをクローンした場合はそのレジストリに追跡されないため、明示的な制御が必要なとき以外は事前クローンを避けてください。

同名のマスターやレイアウトが視覚的に同等であると推測しないでください。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、結合後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライド コンテンツに紐付いており、スライドがクローンされるとコピーされます。Aspose.Slides は [presentation notes](/slides/ja/java/presentation-notes/) と [presentation comments](/slides/ja/java/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式が重要な場合、ノートマスターはプレゼンテーション レベルのオブジェクトであり、ソースファイル間で異なることがあるため、結合後のプレゼンテーションを必ず確認してください。レビュー ワークフローでは、異なる作者やテンプレートから結合した場合のコメント作者やスレッド構造も検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーション レベル リソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないようにして、Aspose.Slides がリソースとの関係を保持できるようにしてください。

埋め込みリソースとリンクリソースは別扱いにすべきです。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。結合プレゼンテーションが開かれる環境で、リンクリソースのパスや URL が正しく機能するかテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係なソースプレゼンテーション間で同一バイナリ リソースが常に重複除去されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、結合後のパッケージを検査し、結果を測定して重複除去が期待通りに行われているか確認してください。

### **埋め込みフォントとフォントの利用可能性**

フォントはプレゼンテーション レベルで管理されます。タイポグラフィを機械間で一貫させる必要がある場合、スライドだけをクローンしただけでは目的のフォントが宛先環境に必ず存在するとは限りません。埋め込みフォントは `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)` で確認でき、[Embed Fonts in Presentations](/slides/ja/java/embedded-font/) の手順で明示的に埋め込みを管理してください。

また、ソースファイルで使用されているフォントを埋め込む許可があるかも確認してください。フォント ライセンスが埋め込みを制限することがあります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正常に開く必要があります。パスワードは `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` で指定します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業します。
} finally {
    source.dispose();
}
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力側の保護を別途設定してください。

### **大きなプレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他の大容量バイナリ オブジェクトを含む大規模プレゼンテーションは大量のメモリを消費します。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)` は BLOB の取り扱いと一時ファイル使用を制御するオプションを提供します。大容量ファイル向けの戦略は [Manage Presentation BLOBs](/slides/ja/java/manage-blob/) を参照してください。

大きなファイルでは可能な限りファイル パスからロードし、各ソースプレゼンテーションはマージが完了したらすぐに破棄し、ワークフローでチェックポイントが必要な場合を除き中間結果の保存は繰り返さないでください。

### **スレッド安全性**

同じ [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーション インスタンスは 1 つのマージ操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーション インスタンスを使用し、[Aspose.Slides multithreading guidance](/slides/ja/java/multithreading/) に従ってください。

## **FAQ**

**元のデザインを保持するにはどうすればよいですか？**

宛先マスターやレイアウトを指定せずに [addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) を使用します。Aspose.Slides はインポートされたスライドに必要な場合、ソースマスターを自動的にクローンします。

**インポートされたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides は各ソーススライドをそのマスター配下の適切なレイアウトにマッピングしようとします。

**特定の宛先レイアウトを使用すべきタイミングは？**

すべてのインポートスライドが既知の 1 つのレイアウトを使用すべき場合に特定のレイアウトを指定します。ソースレイアウトのタイプや名前に基づいてマスターがレイアウトを選択すべき場合はマスターを使用してください。

**異なるスライドサイズのプレゼンテーションは結合できるか？**

可能です。ただしスライド コンテンツは宛先サイズに自動で再設計されません。予測可能な配置が必要な場合は、[SlideSize.setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesize/#setSize-float-float-int-) と [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) を使用してソースプレゼンテーションを事前にリサイズしてください。

**PPT、PPTX、ODP を 1 つのファイルに結合できるか？**

はい。各ソースプレゼンテーションをロードし、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。フォーマット間で機能セットが完全に一致しないため、クロスフォーマット結合後は複雑なコンテンツを必ず確認してください。[Supported File Formats](/slides/ja/java/supported-file-formats/) を参照してください。

**ソースセクションは自動的に保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先にセクションを再作成し、`[addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` のセクション オーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメント作者、スレッド構造が重要なワークフローでは、結合結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、マージ後も対象ファイルや URL が利用可能である必要があります。

**すべてのソースから埋め込まれたフォントは結合プレゼンテーションで利用できるか？**

スライド クローン だけに依存してフォント展開を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合は明示的にフォント埋め込みや外部フォントの配置を管理してください。

**パスワード保護されたファイルを結合するには？**

正しい `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` で開き、通常通りスライドをクローンします。出力側の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うべきか？**

BLOB 管理を使用し、大容量バイナリがメモリ使用量を支配する場合はファイル パスからのロードを優先し、ソースプレゼンテーションはマージ完了後すぐに破棄し、必要なときだけ最終結果を保存してください。

**複数スレッドからスライドを結合できるか？**

同一の [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーション インスタンスに限定し、マルチスレッド ガイダンスに従ってください。