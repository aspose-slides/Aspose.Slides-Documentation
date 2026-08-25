---
title: Android でプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションをマージする
type: docs
weight: 40
url: /ja/androidjava/merge-presentation/
keywords:
- PowerPoint のマージ
- プレゼンテーションのマージ
- スライドのマージ
- PPT のマージ
- PPTX のマージ
- ODP のマージ
- PowerPoint の結合
- プレゼンテーションの結合
- スライドの結合
- PPT の結合
- PPTX の結合
- ODP の結合
- Android
- Java
- Aspose.Slides
description: "Android でスライドをクローンし、マスターやレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを扱うことで、PowerPoint および OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、ある [プレゼンテーション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) から別のプレゼンテーションへスライドをクローンすることでプレゼンテーションをマージします。主な操作は [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) で、元のスライドの書式設定を保持したり、クローンされたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この記事では、最も一般的なマージワークフローを取り上げます：

- 元の書式設定を保持しながらすべてのスライドをマージする;
- 選択したスライドをマージする;
- 宛先プレゼンテーションのマスターを適用する;
- 宛先プレゼンテーションの特定のレイアウトを適用する;
- マージ前に異なるスライドサイズを正規化する;
- クローンしたスライドをセクションに追加する;
- 複数のプレゼンテーションを1つのエンドツーエンドワークフローでマージする;
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大きなファイル、マルチスレッドに関する問題を処理する。

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の多くを継承します。そのため、選択したクローンのオーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

次のいずれかの方法で [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) を使用します：

- `addClone(sourceSlide)` — 元のスライドのレイアウトと書式設定を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じマスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) に添付します。Aspose.Slides はそのマスター下でレイアウトタイプまたは名前に基づいて一致するレイアウトを検索します。
- `addClone(sourceSlide, destinationLayout)` — クローンされたスライドを直接特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/) に添付します。

`addClone` オーバーロードに渡すマスターまたはレイアウトは、**宛先** プレゼンテーションに属している必要があり、元のプレゼンテーションには属していません。

## **プレゼンテーション全体をマージし、元の書式設定を保持する**

最も簡単なマージは、元のプレゼンテーションからすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を維持すべき場合に適しています。

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

元と宛先でデザインが異なる場合、結果のプレゼンテーションには複数のマスターが含まれることがあります。これは、元の書式設定を意図的に保持したときに予想される動作です。

## **選択したスライドをマージする**

すべてのスライドをクローンする必要はありません。次の例は、元のプレゼンテーションから選択したスライドインデックスのみをインポートします。

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

ユーザー入力や外部設定から取得したスライドインデックスは、クローンする前に検証してください。

## **宛先マスターを使用してスライドをマージする**

インポートされたスライドがすでに宛先プレゼンテーションに存在するマスターに従う必要がある場合は、[addClone(ISlide,IMasterSlide,boolean)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

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

Aspose.Slides は、指定されたマスター下で元レイアウトのタイプまたは名前に一致する適切なレイアウトを選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、元レイアウトがクローンされてスライドを追加できるようにします。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、`false` を使用してマージを失敗させます。

## **特定の宛先レイアウトを使用してスライドをマージする**

インポートされたスライドが正確にどの宛先レイアウトを使用すべきか分かっている場合は、[addClone(ISlide,ILayoutSlide)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) オーバーロードを使用します。

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

宛先レイアウトを適用すると、継承されたレイアウトの関係が変更されますが、元のスライドコンテンツのデザインは変更されません。元と宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式設定とプレースホルダーの動作が期待通りであることを確認してください。

## **異なるスライドサイズのプレゼンテーションをマージする**

スライドサイズが異なるプレゼンテーションでもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再設計されません。その結果、シェイプがずれたり、予期せずスケールしたり、スライド領域外に出てしまうことがあります。

実用的な方法は、クローン前に元のプレゼンテーションのサイズを変更することです。`[SlideSize.setSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` メソッドは、スライドサイズを変更しながら既存コンテンツをスケールできます。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/)` はコンテンツを指定サイズに収めるようにスケールします。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

サイズ変更はメモリ内の元プレゼンテーションオブジェクトを変更します。他の操作で元プレゼンテーションを変更せずに残す必要がある場合は、マージ用に別インスタンスを開いてください。

## **スライドをプレゼンテーションのセクションにマージする**

基本的なスライドクローンループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションにセクションを作成または選択し、`[addClone(ISlide,ISection)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` を使用してスライドを明示的にセクションへクローンします。

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

クローンされたスライドは指定した宛先セクションの末尾に追加されます。複数の元セクションを保持したい場合は、`[Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--)` でセクションを列挙し、各元セクションの現在のスライドを `[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)` で取得し、宛先で同様のセクションを再作成してから対応するセクションへスライドをクローンします。完全なセクション列挙例は [スライドセクションの管理](/slides/ja/androidjava/slide-section/) を参照してください（空セクションや構造変更も含む）。

## **複数のプレゼンテーションを安全にマージする**

次のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中だけオープンし、最終的に一度だけファイルを保存します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

これは、インポートされたスライドの元書式設定を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、シンプルな `addClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実務上の考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じて元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターの繰り返しクローンを防止します。手動でクローンしたマスターはこのレジストリに登録されないため、明示的にマスター構造を制御する必要がある場合以外は事前にマスターをクローンしないでください。

同名のマスターやレイアウトが視覚的に同等であると仮定しないでください。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐付いており、スライドがクローンされると同時にコピーされます。Aspose.Slides は [プレゼンテーションノート](/slides/ja/androidjava/presentation-notes/) と [プレゼンテーションコメント](/slides/ja/androidjava/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、元ファイル間で異なることがあるため、マージ後に必ず確認してください。レビューシナリオでは、異なる著者やテンプレートから結合した場合のコメント作者やスレッド構造も確認してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視シェイプだけをコピーしないようにして、Aspose.Slides がリソースとの関係を保持できるようにしてください。

埋め込みリソースとリンクリソースは別扱いです。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージされたプレゼンテーションが開かれる環境で、リンクリソースのパスや URL が有効であることをテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係な元プレゼンテーション間で同一のバイナリリソースが常に重複除去されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定してください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーションレベルで管理されます。タイポグラフィをマシン間で一貫させる必要がある場合、スライドのクローンだけでは目的のフォントが宛先環境に存在することを保証できません。`[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)` で埋め込みフォントを確認し、[プレゼンテーションへのフォント埋め込み](/slides/ja/androidjava/embedded-font/) に記載の方法で明示的に管理してください。

また、元ファイルで使用されているフォントの埋め込みが許可されているか確認してください。フォントライセンスにより埋め込みが制限されることがあります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護された元ファイルは、スライドをクローンする前に正常に開く必要があります。パスワードは `[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` を使用して指定します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションを操作します。
} finally {
    source.dispose();
}
```

暗号化された元を開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力保護を別途設定してください。

### **大容量プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大規模バイナリオブジェクトを含む大容量プレゼンテーションは大量のメモリを消費します。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)` は BLOB の取り扱いと一時ファイル使用を制御するオプションを提供します。大ファイル向けの戦略は [プレゼンテーション BLOB の管理](/slides/ja/androidjava/manage-blob/) を参照してください。

大容量ファイルの場合、可能な限りファイルパスからロードし、マージが完了したらすぐに各元プレゼンテーションを破棄し、ワークフローがチェックポイントを必要としない限り中間結果の保存は繰り返さないでください。

### **スレッド安全性**

同一の `[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/)` インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは 1 つのマージ操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッド ガイド](/slides/ja/androidjava/multithreading/) に従ってください。

## **FAQ**

**元のプレゼンテーションのデザインをそのまま保つには？**

宛先マスターやレイアウトを指定せずに `[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)` を使用します。Aspose.Slides は必要に応じて元マスターを自動的にクローンします。

**インポートしたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。元ではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides は元スライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**特定の宛先レイアウトを使用すべきケースは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべきときはレイアウトオーバーロードを使用し、元レイアウトのタイプや名前に基づいてマスターが自動選択する方が良い場合はマスターオーバーロードを使用します。

**スライドサイズが異なるプレゼンテーションはマージできるか？**

可能ですが、スライドコンテンツは宛先サイズに自動で再設計されません。予測可能な配置が必要な場合は、`[SlideSize.setSize]` と `[SlideSizeScaleType.EnsureFit]` を使用して元プレゼンテーションを事前にリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 ファイルにまとめられるか？**

可能です。各元プレゼンテーションをロードし、必要なスライドを 1 つの宛先にクローンして、サポートされている出力形式で保存します。フォーマットごとに機能差があるため、クロスフォーマットマージ後は複雑なコンテンツを必ず確認してください。詳しくは [サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/) を参照してください。

**元のセクションは自動的に保持されるか？**

スライドのみをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先にセクションを再作成し、`[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメント作者、スレッド化されたレビュー情報が重要な場合は、マージ後に結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、マージ後もターゲットファイルや URL が利用可能である必要があります。

**すべての元から埋め込まれたフォントはマージ後に利用可能か？**

スライドのクローンだけに依存しないでください。宛先に埋め込まれたフォントを確認し、必要に応じてフォント埋め込みや外部フォントの配置を明示的に管理してください。

**パスワード保護されたファイルはどうマージするか？**

`[LoadOptions.setPassword]` で正しいパスワードを設定して開き、通常通りスライドをクローンします。出力の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理オプションを使用し、大容量ファイルは可能な限りファイルパスからロード、ソースプレゼンテーションはマージ後すぐに破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドからスライドをマージできるか？**

同一の `[Presentation]` インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーションインスタンスで実行してください。