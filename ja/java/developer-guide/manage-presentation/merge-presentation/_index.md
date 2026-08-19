---
title: Java でプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/java/merge-presentation/
keywords:
- PowerPoint の結合
- プレゼンテーションの結合
- スライドの結合
- PPT の結合
- PPTX の結合
- ODP の結合
- PowerPoint の統合
- プレゼンテーションの統合
- スライドの統合
- PPT の統合
- PPTX の統合
- ODP の統合
- Java
- Aspose.Slides
description: "Java でスライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを処理することで、PowerPoint および OpenDocument プレゼンテーションを結合する方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、スライドを 1 つの[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) から別のプレゼンテーションへクローンすることでプレゼンテーションを結合します。主な操作は[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)で、ソーススライドの書式設定を保持したり、クローンされたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この記事では最も一般的な結合ワークフローを取り上げます。

- ソースの書式設定を保持しながらすべてのスライドを結合
- 選択したスライドだけを結合
- 宛先プレゼンテーションのマスターを適用
- 宛先プレゼンテーションの特定のレイアウトを適用
- 結合前にスライドサイズを正規化
- クローンしたスライドをセクションに追加
- 複数のプレゼンテーションをエンドツーエンドで結合
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大容量ファイル、マルチスレッドの考慮事項を処理

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから多くの外観を継承します。そのため、選択するクローンのオーバーロードにより、結合されたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/)を使用します。

- `addClone(sourceSlide)` — ソーススライドのレイアウトと書式設定を保持。必要に応じて、ソースマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じマスターを使用するスライドが繰り返しクローンされることを防止します。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の宛先[IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/)に添付します。Aspose.Slides はレイアウトの種類または名前でそのマスター下の一致するレイアウトを検索します。
- `addClone(sourceSlide, destinationLayout)` — クローンされたスライドを直接特定の宛先[ILayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/)に添付します。

`addClone` のオーバーロードに渡すマスターまたはレイアウトは、**宛先**プレゼンテーションに属している必要があり、ソースプレゼンテーションに属していてはいけません。

## **プレゼンテーション全体を結合し、ソースの書式設定を保持**

最も簡単な結合は、ソースプレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートしたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適しています。

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

ソースと宛先が異なるデザインを使用している場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これは、ソースの書式設定を意図的に保持した場合に予想される動作です。

## **選択したスライドだけを結合**

すべてのスライドをクローンする必要はありません。以下の例は、ソースプレゼンテーションから選択されたスライドインデックスだけをインポートします。

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

ユーザー入力や外部設定から取得したインデックスをクローンする前に必ず検証してください。

## **宛先マスターを使用してスライドを結合**

インポートされたスライドが、すでに宛先プレゼンテーションに存在するマスターに従う必要がある場合は、[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

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

Aspose.Slides は、ソースレイアウトの種類または名前に一致する適切なレイアウトを指定されたマスター下で選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドが追加されます。`false` の場合は[PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) がスローされます。

追加レイアウトを宛先マスターに導入したくない場合は、`false` を使用して結合を失敗させます。

## **特定の宛先レイアウトを使用してスライドを結合**

インポートされたスライドが使用すべき宛先レイアウトが明確に決まっている場合は、[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) オーバーロードを使用します。

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

宛先レイアウトを適用すると、継承されたレイアウトの関係が変更されますが、ソーススライドのコンテンツ自体は再設計されません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式設定とプレースホルダーの動作が期待通りか確認してください。

## **スライドサイズが異なるプレゼンテーションを結合**

スライドサイズが異なるプレゼンテーションでも結合は可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再設計されません。そのため、形状がずれたり、スケールが予期せず変わったり、スライド領域外に出ることがあります。

実用的な方法は、クローン前にソースプレゼンテーションのサイズを変更することです。`[SlideSize.setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesize/#setSize-float-float-int-)` メソッドは、スライド寸法を変更しながら既存コンテンツをスケールできます。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) はコンテンツを要求サイズ内に収めるようスケーリングします。

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

サイズ変更はメモリ内のソースプレゼンテーションオブジェクトを変更します。他の操作で元のソースを保持したい場合は、結合用に別インスタンスを開いてください。

## **プレゼンテーションのセクションへスライドを結合**

基本的なスライドクローンループは、ソースプレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[addClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) を使って明示的にスライドをクローンします。

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

クローンされたスライドは指定された宛先セクションに追加されます。複数のソースセクションを保持したい場合は、宛先側に同様のセクションを再作成し、各ソーススライドを対応する宛先セクションにマップしてください。

## **複数プレゼンテーションを安全に結合**

以下のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中のみオープンしたままにし、最終的に一度だけファイルを保存します。

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

これはインポートスライドのソース書式設定を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、簡単な `addClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実践的な考慮事項**

### **マスター、レイアウト、および書式忠実度**

デフォルトのスライドクローンは、必要に応じてソースマスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターの重複クローンを防止します。手動でクローンしたマスターはこのレジストリに登録されないため、明示的な制御が必要な場合を除き、事前にマスターをクローンしないようにしてください。

名前が同じでも、2 つのマスターやレイアウトが見た目上同等であるとは限りません。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、結合後に結果を必ず検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツと紐付いており、スライドをクローンするとコピーされます。Aspose.Slides は[プレゼンテーションノート](https://docs.aspose.com/slides/ja/java/presentation-notes/) と[プレゼンテーションコメント](https://docs.aspose.com/slides/ja/java/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、ソースファイル間で異なることがあるため、結合後に必ず確認してください。レビュー業務では、異なる著者やテンプレートから結合した際のコメント作者やスレッド構造も検証しましょう。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーションレベルリソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないことで、Aspose.Slides がリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままで、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。結合後にスライドを開く環境で、リンク先のパスや URL が正しいかテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという保証にはなりません。出力ファイルサイズが重要な場合は、結合パッケージを検査し、実際のサイズを測定して判断してください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーション単位で管理されます。機械間でタイポグラフィを一致させる必要がある場合、スライドだけをクローンしただけでは目的のフォントが宛先環境に確実に存在するとは限りません。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) で埋め込みフォントを確認し、[プレゼンテーションへのフォント埋め込み](https://docs.aspose.com/slides/ja/java/embedded-font/) に示すように明示的に管理してください。

また、ソースファイルで使用されているフォントを埋め込む権利があるか確認してください。フォントライセンスに埋め込み制限があることがあります。

### **パスワード保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正しく開く必要があります。パスワードは[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) で指定します。

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

### **大容量プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む大容量プレゼンテーションは、かなりのメモリを消費します。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) は BLOB の取り扱いと一時ファイル使用を制御します。大容量ファイル向けの戦略は[プレゼンテーション BLOB の管理](https://docs.aspose.com/slides/ja/java/manage-blob/) を参照してください。

大きなファイルの場合は、可能な限りファイルパスからロードし、各ソースプレゼンテーションは結合後すぐに破棄し、ワークフローでチェックポイントが必要な場合以外は中間結果の保存を繰り返さないようにしてください。

### **スレッド安全性**

同じ[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは 1 つの結合操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッド ガイダンス](https://docs.aspose.com/slides/ja/java/multithreading/) に従ってください。

## **FAQ**

**各ソースプレゼンテーションの元のデザインを保持するには？**

宛先マスターやレイアウトを指定せずに[`addClone(sourceSlide)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) を使用します。必要に応じて Aspose.Slides がソースマスターを自動的にクローンします。

**インポートされたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides は各ソーススライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**宛先レイアウトを使用すべきケースは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合にレイアウトを指定します。ソースレイアウトの種類や名前に基づいて Aspose.Slides に自動選択させたい場合は、マスターを指定してください。

**サイズが異なるスライドを持つプレゼンテーションは結合できるか？**

はい。ただし、スライドコンテンツは宛先サイズに自動で再設計されません。予測可能な配置が必要な場合は、[SlideSize.setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesize/#setSize-float-float-int-) と[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) を使用してソースプレゼンテーションを事前にリサイズしてください。

**PPT、PPTX、ODP を 1 つのファイルに結合できるか？**

はい。各ソースプレゼンテーションをロードし、必要なスライドを 1 つの宛先にクローンして、サポートされている出力形式で保存します。フォーマットごとに機能セットが完全に同一でないため、クロスフォーマット結合後は複雑なコンテンツを必ず確認してください。[サポートされているファイル形式](https://docs.aspose.com/slides/ja/java/supported-file-formats/) を参照してください。

**ソースセクションは自動で保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先に必要なセクションを再作成し、[addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリング、コメント作者、スレッド化されたレビュー情報が重要なワークフローでは、結合結果を検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままで、結合後も対象ファイルや URL が利用可能である必要があります。

**すべてのソースからの埋め込みフォントは結合プレゼンテーションで利用可能か？**

スライドクローンだけに頼ってフォントの展開を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォント埋め込みまたは外部フォントの可用性を明示的に管理してください。

**パスワード保護されたファイルを結合する方法は？**

正しい[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) で開き、通常通りスライドをクローンしてください。出力の保護は別途設定します。

**非常に大きなプレゼンテーションはどう扱うべきか？**

BLOB 管理オプションを使用し、大容量ファイルは可能な限りファイルパスからロードし、ソースプレゼンテーションは結合後速やかに破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドからスライドを結合できるか？**

同一の[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを複数スレッドで同時に使用しないでください。各結合操作は独立したプレゼンテーションインスタンスで実行し、Aspose.Slides のマルチスレッド ガイダンスに従ってください。