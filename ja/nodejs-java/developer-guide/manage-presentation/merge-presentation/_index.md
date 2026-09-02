---
title: JavaScript でプレゼンテーションを効率的に結合する
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/nodejs-java/merge-presentation/
keywords:
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PowerPoint を統合
- プレゼンテーションを統合
- スライドを統合
- PPT を統合
- PPTX を統合
- ODP を統合
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript でスライドをクローンし、マスターとレイアウトを制御し、スライド コンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを処理することで、PowerPoint および OpenDocument プレゼンテーションを結合する方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、スライドを 1 つの [プレゼンテーション](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) から別のプレゼンテーションへクローンすることで、プレゼンテーションを結合します。主な操作は [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) で、元のスライドの書式設定を保持したり、クローンしたスライドを宛先プレゼンテーションのマスターやレイアウトに付属させたりできます。

本記事では最も一般的な結合ワークフローを取り上げます。

- すべてのスライドを元の書式設定を保持したまま結合
- 選択したスライドだけを結合
- 宛先プレゼンテーションのマスターを適用
- 宛先プレゼンテーションの特定レイアウトを適用
- 結合前に異なるスライドサイズを正規化
- セクションにクローンスライドを追加
- 複数のプレゼンテーションを 1 つのエンドツーエンド ワークフローで結合
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大きなファイル、マルチスレッドに関する考慮事項を扱う

## **スライド クローンがマスターとレイアウトに与える影響**

スライドはそのレイアウトとマスターから外観の多くを継承します。そのため、選択するクローンのオーバーロードが、結合されたスライドが宛先プレゼンテーションにどのように統合されるかを決定します。

以下のいずれかの方法で [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) を使用します。

- `addClone(sourceSlide)` — 元のスライドのレイアウトと書式設定を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動的にクローンされたマスターを追跡し、同一の元マスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンしたスライドを特定の宛先 [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) に付属させます。Aspose.Slides はそのマスター下でレイアウトタイプまたは名前に基づいて一致するレイアウトを検索します。
- `addClone(sourceSlide, destinationLayout)` — クローンしたスライドを特定の宛先 [LayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) に直接付属させます。

`addClone` オーバーロードに渡すマスターまたはレイアウトは、**宛先** プレゼンテーションに属している必要があり、元プレゼンテーションに属していてはいけません。

## **プレゼンテーション全体を結合し、元の書式設定を保持する**

最もシンプルな結合は、元プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適した選択です。

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

元と宛先でデザインが異なる場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これは、元の書式設定を意図的に保持した場合に予想される動作です。

## **選択したスライドだけを結合**

すべてのスライドをクローンする必要はありません。以下の例は、元プレゼンテーションから選択したスライド インデックスだけをインポートします。

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

ユーザー入力や外部設定から取得したインデックスの場合、クローン前にインデックスの有効性を検証してください。

## **宛先マスターを使用してスライドを結合**

インポートされたスライドが、すでに宛先プレゼンテーションに存在するマスターに従う必要がある場合は、[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

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

Aspose.Slides は、元レイアウトのタイプまたは名前に一致する適切なレイアウトを指定したマスター下で選択します。適切なレイアウトが存在せず、`allowCloneMissingLayout` が `true` の場合、元レイアウトがクローンされてスライドを追加できるようになります。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) がスローされます。

マスターに余分なレイアウトを追加したくない場合は、`false` を使用して結合を失敗させます。

## **特定の宛先レイアウトを使用してスライドを結合**

インポートされたスライドが使用すべき宛先レイアウトが正確に分かっている場合は、[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) オーバーロードを使用します。

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

宛先レイアウトを適用すると、継承されたレイアウト関係が変更されますが、元スライドのコンテンツ自体が再設計されるわけではありません。元と宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式設定とプレースホルダーの動作が期待通りであることを確認してください。

## **スライドサイズが異なるプレゼンテーションを結合**

スライドサイズが異なるプレゼンテーションでも結合は可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再設計されません。その結果、シェイプがずれたり、スケールが予期せず変わったり、スライド領域外に出たりすることがあります。

実用的なアプローチは、クローン前に元プレゼンテーションのサイズを変更することです。`[SlideSize.setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` メソッドは、スライドサイズを変更しながら既存コンテンツをスケーリングできます。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/)` は、要求されたサイズに合わせてコンテンツをフィットさせます。

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

リサイズはメモリ上の元プレゼンテーション オブジェクトを変更します。元プレゼンテーションを他の操作でそのまま残したい場合は、結合用に別インスタンスを開いてください。

## **スライドをプレゼンテーション セクションに結合**

基本的なスライド クローン ループは、元プレゼンテーションのセクション階層を再作成しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、`[addClone(Slide, Section)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` を使用して明示的にスライドをセクションにクローンします。

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

クローンスライドは指定された宛先セクションに追加されます。複数の元セクションを保持したい場合は、`[Presentation.getSections](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSections)` を列挙し、各元セクションの現在のスライドを `[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSlidesListOfSection)` で取得し、宛先で同名セクションを再作成して、取得したスライドを対応する宛先セクションにクローンします。完全なセクション列挙例は [スライド セクションの管理](/slides/ja/nodejs-java/slide-section/) を参照してください。空のセクションや構造変更も含まれます。

## **複数のプレゼンテーションを安全に結合**

次のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中だけ開き、最後にファイルを保存します。

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

インポートされたスライドの元書式設定を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、シンプルな `addClone(sourceSlide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウト オーバーロードに置き換えてください。

## **実用的な考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライド クローンは、必要な元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターが繰り返しクローンされるのを防ぎます。手動でクローンしたマスターはこのレジストリに登録されないため、明示的にマスター構造を制御する必要がある場合以外は事前にマスターをクローンしないでください。

名前が同じでも、2 つのマスターまたはレイアウトが視覚的に同等であるとは限りません。企業テンプレートで最終的な外観を制御する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、結合後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライド コンテンツに紐付いており、スライドがクローンされるときにコピーされます。Aspose.Slides は、[プレゼンテーション ノート](/slides/ja/nodejs-java/presentation-notes/) と [プレゼンテーション コメント](/slides/ja/nodejs-java/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーション レベルのオブジェクトであり、ソースファイル間で異なることがあるため、結合後のプレゼンテーションを必ず確認してください。レビュー ワークフローでは、異なる作者やテンプレートから結合した場合のコメント作者やスレッドコメントも検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーション レベルのリソースを参照できます。スライド自体をクローンし、表示シェイプだけをコピーしないようにして、Aspose.Slides がリソースとの関係を保持できるようにします。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままで、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後にスライドを開く環境で、リンクリソースのパスや URL が有効かテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、これは無関係なソース プレゼンテーション間で同一バイナリ リソースが常に重複排除されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定して重複排除に依存しないでください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーション レベルで管理されます。タイポグラフィを機械間で一貫させる必要がある場合、スライドだけをクローンしても目的のフォントが宛先環境に存在するとは限りません。埋め込みフォントは `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)` で確認でき、[プレゼンテーションへのフォント埋め込み](/slides/ja/nodejs-java/embedded-font/) の手順で明示的に管理してください。

また、ソースファイルで使用されているフォントを埋め込む許可があるか確認してください。フォントライセンスは埋め込みを制限することがあります。

### **パスワード保護されたプレゼンテーション**

パスワード保護されたソースは、スライドをクローンする前に正しく開く必要があります。パスワードは `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` で指定します。

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
        // 復号化されたプレゼンテーションで作業します。
    } finally {
    source.dispose();
}
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力保護を別途設定してください。

### **大規模プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む大規模プレゼンテーションは、かなりのメモリを消費します。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--)` は BLOB の取り扱いと一時ファイル使用を制御します。大容量ファイル向けの戦略は [プレゼンテーション BLOB の管理](/slides/ja/nodejs-java/manage-blob/) を参照してください。

大きなファイルの場合は、可能な限りファイル パスからロードし、マージが完了したらすぐに各ソースプレゼンテーションを破棄し、ワークフローでチェックポイントが必要でない限り中間結果の保存を繰り返さないでください。

### **スレッド安全性**

`[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/)` インスタンスを複数スレッドで同時にロード、保存、またはクローンしないでください。これらの操作はマルチスレッドでの使用をサポートしていません。独立したマージ ジョブを並列化したい場合は、各プロセスが単一スレッドで独自のプレゼンテーション インスタンスを持つようにし、[Aspose.Slides のマルチスレッド ガイド](/slides/ja/nodejs-java/multithreading/) に従ってください。

## **FAQ**

**元のデザインをそのまま保持するには？**

宛先マスターやレイアウトを指定せずに `[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)` を使用します。Aspose.Slides は、インポートされたスライドに必要な場合に元マスターを自動的にクローンできます。

**インポートされたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。宛先プレゼンテーションのマスターを渡し、元プレゼンテーションのマスターは使用しません。Aspose.Slides は、元スライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**宛先マスターではなく特定の宛先レイアウトを使用すべき場面は？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合は特定レイアウトを選択します。元レイアウトのタイプや名前に基づいてマスターのレイアウトを自動選択させたい場合は、マスターを使用します。

**スライドサイズが異なるプレゼンテーションは結合可能か？**

可能です。ただし、スライド コンテンツは宛先サイズに合わせて自動的に再設計されません。予測可能な配置が必要な場合は、`[SlideSize.setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` と `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/)` を使用して元プレゼンテーションを先にリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 ファイルに結合できるか？**

可能です。各ソース プレゼンテーションをロードし、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。プレゼンテーション形式間で機能セットが完全に一致しないため、クロスフォーマット結合後は複雑なコンテンツを必ず確認してください。対応フォーマットは [サポートされているファイル形式](/slides/ja/nodejs-java/supported-file-formats/) を参照してください。

**元のセクションは自動的に保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先で必要なセクションを再作成し、`[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` のセクション オーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドとともにコピーされます。ノートマスターのスタイリングやコメント作者、スレッド化されたレビュー情報に依存するワークフローでは、結合結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままで、マージ後もリンク先ファイルや URL が利用可能である必要があります。

**すべてのソースからの埋め込みフォントはマージ後に利用可能か？**

スライド クローンだけに依存してフォント配布を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォント埋め込みや外部フォントの可用性を明示的に管理してください。

**パスワード保護されたファイルを結合するには？**

`[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` で正しいパスワードを指定して開き、通常どおりスライドをクローンします。出力の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理オプションを使用して大容量バイナリの取り扱いを最適化し、可能な限りファイル パスからロードし、ソース プレゼンテーションはマージ後すぐに破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドからスライドを結合できるか？**

`Presentation` インスタンスのロード、保存、クローンを複数スレッドで実行しないでください。並列ジョブが必要な場合は、各ジョブを単一スレッドのプロセスとして実行し、独立したプレゼンテーション インスタンスを使用し、[Aspose.Slides のマルチスレッド ガイド](/slides/ja/nodejs-java/multithreading/) に従ってください。