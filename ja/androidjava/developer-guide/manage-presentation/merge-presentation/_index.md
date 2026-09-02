---
title: Android で効率的にプレゼンテーションを結合する
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "スライドをクローンし、マスターやレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを扱う方法を通じて、Android 上で PowerPoint および OpenDocument プレゼンテーションを結合する方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、ある [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) から別のプレゼンテーションにスライドをクローンすることでプレゼンテーションを結合します。主要な操作は [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) で、元のスライドの書式設定を保持するか、クローンされたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付できます。

このドキュメントでは最も一般的な結合ワークフローを取り上げます。

- ソースの書式設定を保持したまますべてのスライドを結合する;
- 選択したスライドを結合する;
- 宛先プレゼンテーションのマスターを適用する;
- 宛先プレゼンテーションの特定のレイアウトを適用する;
- 結合前に異なるスライドサイズを正規化する;
- クローンしたスライドをセクションに追加する;
- 複数のプレゼンテーションを 1 つのエンドツーエンド ワークフローで結合する;
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大きなファイル、マルチスレッドに関する問題を処理する。

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の多くを継承します。そのため、選択するクローンのオーバーロードにより、結合されたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) を次のいずれかの方法で使用します。

- `addClone(sourceSlide)` — ソーススライドのレイアウトと書式設定を保持します。必要に応じて、ソースマスターは自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じソースマスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) に添付します。Aspose.Slides はレイアウトの種類または名前でそのマスター下に一致するレイアウトを検索します。
- `addClone(sourceSlide, destinationLayout)` — クローンされたスライドを特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/) に直接添付します。

`addClone` のオーバーロードに渡すマスターまたはレイアウトは、**宛先** プレゼンテーションに属している必要があり、ソースプレゼンテーションに属していてはなりません。

## **プレゼンテーション全体を結合し、ソースの書式設定を保持する**

最も簡単な結合は、ソースプレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適した選択です。

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

ソースと宛先でデザインが異なる場合、結果のプレゼンテーションには複数のマスターが含まれることがあります。これは、ソースの書式設定を意図的に保持する場合に予想される動作です。

## **選択したスライドを結合する**

すべてのスライドをクローンする必要はありません。次の例は、ソースプレゼンテーションから選択されたスライドインデックスだけをインポートします。

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

ユーザー入力や外部設定から取得したインデックスの場合、クローンする前にスライドインデックスを検証してください。

## **宛先マスターを使用してスライドを結合する**

インポートされたスライドが既に宛先プレゼンテーションに存在するマスターに従うべき場合は、[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) オーバーロードを使用します。

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

Aspose.Slides は、ソースレイアウトの種類または名前に一致する適切なレイアウトを指定されたマスター下で選択します。一致するレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドを追加できるようになります。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、`false` を使用して結合を失敗させるようにしてください。

## **特定の宛先レイアウトを使用してスライドを結合する**

インポートされたスライドが使用すべき宛先レイアウトが明確に決まっている場合は、[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) オーバーロードを使用します。

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

宛先レイアウトを適用すると、継承されたレイアウトの関係が変更されますが、ソーススライドのコンテンツ自体は再設計されません。ソースと宛先のレイアウトでプレースホルダーの構造が異なる場合は、継承された書式設定とプレースホルダーの動作が適切であることを確認してください。

## **スライドサイズが異なるプレゼンテーションを結合する**

スライドの寸法が異なるプレゼンテーション同士でも結合は可能ですが、別サイズのプレゼンテーションにスライドをクローンしてもコンテンツは自動で新しいキャンバスに合わせて再設計されません。形状がずれたり、予期せず拡大縮小されたり、スライド領域外に出てしまうことがあります。

実用的な方法は、クローンする前にソースプレゼンテーションのサイズを変更することです。[SlideSize.setSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) メソッドは、スライド寸法を変更しながら既存コンテンツをスケーリングできます。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/) は、要求されたサイズに合わせてコンテンツをフィットさせます。

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

サイズ変更はメモリ上のソースプレゼンテーションオブジェクトを変更します。他の操作で元のソースプレゼンテーションを保持したい場合は、マージ用に別インスタンスを開いてください。

## **スライドをプレゼンテーションのセクションに結合する**

基本的なスライドクローンループは、ソースプレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[addClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) を使用してスライドを明示的にセクションへクローンしてください。

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

クローンされたスライドは指定された宛先セクションに追加されます。複数のソースセクションを保持したい場合は、宛先側に同じセクションを再作成し、各ソーススライドを対応する宛先セクションへマップしてください。

## **複数のプレゼンテーションを安全に結合する**

以下のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、コピー中のみソースを開き、最後にファイルを保存します。

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

これはインポートされたスライドのソース書式設定を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、前述の宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実用的な考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じてソースマスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターの繰り返しクローンを防止します。手動でクローンしたマスターはそのレジストリに追跡されないため、明示的にマスター構造を制御する必要がない限り、事前にマスターをクローンしないでください。

名前が同じでも、2 つのマスターやレイアウトが視覚的に同等であるとは限りません。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、結合後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐づいており、スライドがクローンされる際にコピーされます。Aspose.Slides は [presentation notes](https://docs.aspose.com/slides/ja/androidjava/presentation-notes/) と [presentation comments](https://docs.aspose.com/slides/ja/androidjava/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、ソースファイル間で異なることがあるため、結合後にプレゼンテーションを確認してください。レビューシナリオでは、異なる作者やテンプレートから結合した場合のコメント作者やスレッド構造も検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、表示形状だけをコピーしないことで、Aspose.Slides がリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは別扱いしてください。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後に環境でリンク先が正しく解決できるかテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係なソースプレゼンテーション間で同一のバイナリリソースが常に重複除去されるという保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定してください。

### **埋め込みフォントとフォントの利用可能性**

フォントはプレゼンテーションレベルで管理されます。フォントの一貫性が機械間で必要な場合、スライドだけをクローンしただけでは目的のフォントが宛先環境に存在することは保証できません。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) で埋め込みフォントを確認し、[Embed Fonts in Presentations](https://docs.aspose.com/slides/ja/androidjava/embedded-font/) の手順に従って明示的に埋め込みを管理してください。

また、ソースファイルで使用されているフォントを埋め込む権利があるかどうかも確認してください。フォントライセンスに埋め込みが制限されている場合があります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正しく開く必要があります。パスワードは [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) で指定してください。

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

### **大規模プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他の大容量バイナリオブジェクトを含む大規模プレゼンテーションは、かなりのメモリを消費します。[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) は BLOB の扱いと一時ファイル使用を制御するオプションを提供します。大容量ファイル向けの戦略は [Manage Presentation BLOBs](https://docs.aspose.com/slides/ja/androidjava/manage-blob/) を参照してください。

大きなファイルの場合、可能な限りファイルパスから読み込み、各ソースプレゼンテーションをマージ後すぐに破棄し、ワークフローでチェックポイントが必要でない限り中間結果を頻繁に保存しないでください。

### **スレッド安全性**

同一の [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを複数のスレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは 1 つのマージ操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides マルチスレッド ガイダンス](httpshttps://docs.aspose.com/slides/ja/androidjava/multithreading/) に従ってください。

## **FAQ**

**ソースプレゼンテーションの元デザインを保持するには？**

`addClone(sourceSlide)` を使用し、宛先マスターやレイアウトを指定しないでください。Aspose.Slides はインポートされたスライドに必要な場合、ソースマスターを自動的にクローンできます。

**インポートしたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用してください。宛先プレゼンテーションからマスターを渡し、ソースからは渡さないようにします。Aspose.Slides は各ソーススライドをそのマスターの適切なレイアウトにマッピングしようとします。

**マスターではなく特定の宛先レイアウトを使用すべき場合は？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合にレイアウトオーバーロードを使用します。ソースレイアウトの種類や名前に基づいてマスターがレイアウトを選択するのではなく、明示的にレイアウトを指定したい場合はマスターを使用します。

**スライドサイズが異なるプレゼンテーションは結合できるか？**

可能ですが、スライドコンテンツは宛先のサイズに自動で再設計されません。予測可能な配置が必要な場合は、[SlideSize.setSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) と [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/) を使用してソースプレゼンテーションを事前にリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルに結合できるか？**

はい。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。フォーマット間で機能セットが完全に一致しないため、クロスフォーマット結合後は複雑なコンテンツを検証してください。[Supported File Formats](https://docs.aspose.com/slides/ja/androidjava/supported-file-formats/) を参照してください。

**ソースのセクションは自動的に保持されるか？**

スライドのみをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先側で必要なセクションを再作成し、[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメント作者、スレッドレビュー情報に依存するワークフローの場合、結合結果を検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、ターゲットファイルや URL がマージ後も利用可能であることを確認してください。

**すべてのソースから埋め込まれたフォントはマージ後に利用可能か？**

スライドのクローンだけに依存せず、フォントの展開を保証しないことに注意してください。宛先の埋め込みフォントを確認し、必要に応じてフォント埋め込みや外部フォントの配置を明示的に管理してください。

**パスワード保護されたファイルを結合するには？**

正しい [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) で開き、通常通りスライドをクローンしてください。出力側の保護は別途設定します。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理オプションを使用し、大容量ファイルは可能な限りファイルパスから読み込み、ソースプレゼンテーションはマージ後すぐに破棄し、最終結果のみを保存してください。

**複数スレッドからスライドを結合できるか？**

1 つの [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーションインスタンスに限定してください。