---
title: JavaScriptでプレゼンテーションを効果的にマージ
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript でスライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを処理することで、PowerPoint および OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、スライドをクローンしてある [プレゼンテーション](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) から別のプレゼンテーションへマージします。主な操作は [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) で、元スライドの書式を保持したままクローンするか、クローンしたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付できます。

本記事では最も一般的なマージワークフローを取り上げます。

- すべてのスライドを元の書式を保持してマージ
- 任意のスライドのみをマージ
- 宛先プレゼンテーションのマスターを適用
- 宛先プレゼンテーションの特定レイアウトを適用
- マージ前にスライドサイズを正規化
- セクションへクローンしたスライドを追加
- 複数のプレゼンテーションをエンドツーエンドでマージ
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドに関する考慮事項

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから多くの外観を継承します。そのため、選択するクローンのオーバーロードが、マージされたスライドが宛先プレゼンテーションにどのように統合されるかを決定します。

以下のいずれかの方法で [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) を使用してください。

- `addClone(sourceSlide)` — 元スライドのレイアウトと書式を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じ元マスターを使用するスライドが繰り返しクローンされても重複クローンを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンしたスライドを特定の宛先 [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) に添付します。Aspose.Slides はそのマスター下でレイアウトタイプまたは名前に基づく一致レイアウトを探します。
- `addClone(sourceSlide, destinationLayout)` — クローンしたスライドを特定の宛先 [LayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) に直接添付します。

`addClone` のオーバーロードに渡すマスターまたはレイアウトは **宛先** プレゼンテーションに属している必要があり、元プレゼンテーションのものを使用してはいけません。

## **プレゼンテーション全体をマージして元の書式を保持する**

最もシンプルなマージは、元プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーする方法です。インポートしたスライドが元のテーマ、マスター、レイアウトの関係をそのまま保持すべき場合に適しています。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

元と宛先でデザインが異なる場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これは元書式を意図的に保持した場合の期待通りの動作です。

## **選択したスライドだけをマージ**

すべてのスライドをクローンする必要はありません。以下の例は、元プレゼンテーションから選択したスライドインデックスだけをインポートします。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ユーザー入力や外部設定から取得したインデックスの場合は、クローン前に必ず検証してください。

## **宛先マスターを使用してスライドをマージ**

インポートしたスライドがすでに宛先プレゼンテーションに存在するマスターに従うべき場合は、[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides は、指定されたマスター下で元レイアウトのタイプまたは名前に合致する適切なレイアウトを選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、元レイアウトがクローンされスライドが追加されます。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) がスローされます。

マージが失敗することを望む場合は、`false` を使用して追加レイアウトが宛先マスターに導入されないようにしてください。

## **特定の宛先レイアウトを使用してスライドをマージ**

インポートしたスライドが必ず使用すべき宛先レイアウトが決まっている場合は、[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) オーバーロードを使用します。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

宛先レイアウトを適用すると継承されるレイアウトの関係が変わりますが、元スライドのコンテンツ自体が再設計されるわけではありません。元レイアウトと宛先レイアウトのプレースホルダー構造が異なる場合は、継承された書式とプレースホルダー動作が期待通りかどうか結果を確認してください。

## **スライドサイズが異なるプレゼンテーションをマージ**

スライドサイズが異なるプレゼンテーション同士でもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再配置されません。その結果、シェイプがずれたり、スケールが変わったり、スライド領域外に出ることがあります。

実用的なアプローチは、クローン前に元プレゼンテーションのサイズを変更することです。`[SlideSize.setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` メソッドは、スライドサイズを変更しつつ既存コンテンツをスケーリングできます。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/)` はコンテンツを要求サイズ内に収めるようスケールします。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

サイズ変更はメモリ上の元プレゼンテーションオブジェクトを変更します。元プレゼンテーションを他の操作でもそのまま残したい場合は、マージ用に別インスタンスを開いてください。

## **プレゼンテーションセクションへスライドをマージ**

基本的なスライドクローンループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要になる場合は、宛先プレゼンテーションにセクションを作成または選択し、`[addClone(Slide, Section)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` を使用して明示的にスライドをクローンしてください。

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

クローンされたスライドは指定された宛先セクションに追加されます。複数の元セクションを保持したい場合は、宛先側に同じセクションを再作成し、各元スライドを対応する宛先セクションにマッピングしてください。

## **複数プレゼンテーションを安全にマージ**

以下のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、追加の各元プレゼンテーションのスライドサイズを正規化し、コピー中だけ元を開き、最後に一度だけファイルを保存します。

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

これはインポートしたスライドの元書式を保持するための基本的な手順です。単一の宛先テーマを使用したい場合は、前述の宛先マスターまたは宛先レイアウトオーバーロードに置き換えてください。

## **実用的な考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じて元マスターを自動的に宛先プレゼンテーションに持ち込むことがあります。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同一マスターの重複クローンを防ぎます。手動でクローンしたマスターはこのレジストリに登録されないため、明示的な制御が必要な場合以外は事前クローンを避けてください。

同名のマスターやレイアウトが視覚的に同等であると決めつけてはいけません。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を必ず検証してください。

### **ノートとコメント**

スピーカーノートやスライドコメントはスライドコンテンツに紐付いており、スライドがクローンされる際にコピーされます。Aspose.Slides は [presentation notes](https://docs.aspose.com/slides/ja/nodejs-java/presentation-notes/) と [presentation comments](https://docs.aspose.com/slides/ja/nodejs-java/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式が重要な場合は、マスターがプレゼンテーションレベルのオブジェクトであり、元ファイル間で異なることがあるため、マージ後にノートの整合性を確認してください。レビュー業務では、異なる作者やテンプレートから統合した場合のコメント作者やスレッド構造も検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声・動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンすることで、Aspose.Slides がリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは別扱いすべきです。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままで、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後に使用される環境でリンク先パスや URL が有効かテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、これは無関係な元プレゼンテーション間で同一バイナリリソースが必ず重複除去されることを保証するものではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、実際のサイズを測定してください。

### **埋め込みフォントとフォント可用性**

フォントはプレゼンテーションレベルで管理されます。機器間でタイポグラフィを一致させる必要がある場合、スライドだけをクローンしただけでは目的のフォントが宛先環境に存在するとは限りません。`[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)` で埋め込みフォントを確認し、[Embed Fonts in Presentations](https://docs.aspose.com/slides/ja/nodejs-java/embedded-font/) に従って明示的に埋め込みを管理してください。

また、元ファイルで使用されているフォントの埋め込みが許可されているかライセンスを確認してください。

### **パスワード保護されたプレゼンテーション**

パスワード保護された元ファイルは、スライドをクローンする前に正しく開く必要があります。パスワードは `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` で設定します。

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業する。
} finally {
    source.dispose();
}
```

暗号化された元を開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力側の保護を別途設定してください。

### **巨大プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画などの大容量バイナリオブジェクトを含む巨大プレゼンテーションは、かなりのメモリを消費します。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--)` は BLOB の取り扱いと一時ファイル使用を制御します。大ファイル向けの戦略は [Manage Presentation BLOBs](https://docs.aspose.com/slides/ja/nodejs-java/manage-blob/) を参照ください。

大容量ファイルでは、可能な限りファイルパスからロードし、マージが完了したらすぐに各元プレゼンテーションを破棄し、ワークフローでチェックポイントが不要なら中間結果の保存は避けてください。

### **スレッド安全性**

`[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/)` インスタンスを複数スレッドで同時にロード、保存、クローンしないでください。これらの操作はマルチスレッド環境での使用はサポートされていません。独立したマージジョブを並列化したい場合は、プレゼンテーションインスタンスをそれぞれ持つ複数のシングルスレッドプロセスを使用し、[Aspose.Slides マルチスレッド ガイダンス](httpshttps://docs.aspose.com/slides/ja/nodejs-java/multithreading/) に従ってください。

## **FAQ**

**各元プレゼンテーションの元デザインを保持するには？**

宛先マスターやレイアウトを指定せず、[`addClone(sourceSlide)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) を使用してください。必要に応じて Aspose.Slides が自動的に元マスターをクローンします。

**インポートしたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用してください。マスターは元ではなく宛先プレゼンテーションから取得します。Aspose.Slides は各元スライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**宛先マスターではなく特定の宛先レイアウトを使用すべきタイミングは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合は特定レイアウトを使用します。元レイアウトのタイプや名前に応じて自動選択させたい場合はマスターを使用してください。

**サイズが異なるプレゼンテーションはマージできるか？**

可能です。ただしスライドコンテンツは自動的に新しいサイズに再設計されません。予測可能な配置が必要な場合は、`[SlideSize.setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` と `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/)` を使って元プレゼンテーションを先にリサイズしてください。

**PPT、PPTX、ODP プレゼンテーションを 1 ファイルにマージできるか？**

可能です。各元プレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。フォーマット間で機能セットが完全に一致しないため、クロスフォーマットマージ後は複雑なコンテンツを必ず確認してください。詳しくは [Supported File Formats](https://docs.aspose.com/slides/ja/nodejs-java/supported-file-formats/) を参照してください。

**元のセクションは自動で保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先に事前にセクションを作成し、`[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターの書式、コメント作者、スレッド構造が重要なワークフローでは、マージ後に結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままで、マージ後もリンク先ファイルや URL が利用可能である必要があります。

**すべての元から埋め込まれたフォントはマージ後に利用可能か？**

スライドクローンだけに依存してフォント展開を保証しないでください。宛先の埋め込みフォントを確認し、必要に応じて明示的にフォント埋め込みまたは外部フォントの配置を管理してください。

**パスワード保護されたファイルをマージするには？**

正しい `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` で開き、通常通りスライドをクローンしてください。出力時の保護は別途設定します。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理オプションを使用し、大容量ファイルは可能な限りファイルパスから読み込み、マージ完了後すぐに元プレゼンテーションを破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドでスライドをマージできるか？**

`Presentation` インスタンスのロード、保存、クローンを複数スレッドで同時に実行しないでください。並列マージが必要な場合は、各スレッドが独立したプロセスとプレゼンテーションインスタンスを持つ構成にし、[Aspose.Slides マルチスレッド ガイダンス](https://docs.aspose.com/slides/ja/nodejs-java/multithreading/) に従ってください。