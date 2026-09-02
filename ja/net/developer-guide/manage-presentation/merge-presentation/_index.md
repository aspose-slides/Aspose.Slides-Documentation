---
title: ".NET でプレゼンテーションを効率的にマージする"
linktitle: "プレゼンテーションのマージ"
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords:
- "PowerPoint をマージ"
- "プレゼンテーションをマージ"
- "スライドをマージ"
- "PPT をマージ"
- "PPTX をマージ"
- "ODP をマージ"
- "PowerPoint を結合"
- "プレゼンテーションを結合"
- "スライドを結合"
- "PPT を結合"
- "PPTX を結合"
- "ODP を結合"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "スライドをクローンし、マスターとレイアウトを制御し、スライド コンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを扱うことで、.NET で PowerPoint と OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for .NET は、ある [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) から別のプレゼンテーションへスライドをクローンすることでプレゼンテーションをマージします。主要な操作は [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) で、元のスライドの書式設定を保持したままクローンしたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付できます。

本記事では最も一般的なマージ ワークフローを取り上げます。

- すべてのスライドを元の書式を保持してマージする  
- 選択したスライドのみをマージする  
- 宛先プレゼンテーションのマスターを適用する  
- 宛先プレゼンテーションの特定のレイアウトを適用する  
- マージ前にスライドサイズを正規化する  
- クローンしたスライドをセクションに追加する  
- 複数のプレゼンテーションをエンドツーエンドのワークフローでマージする  
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドの考慮事項を扱う  

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の多くを継承します。そのため、選択したクローンのオーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を使用します。

- `AddClone(sourceSlide)` — 元のスライドのレイアウトと書式設定を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同一マスターを使用する重複スライドが繰り返しクローンされるのを防ぎます。  
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンしたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) に添付します。Aspose.Slides はそのマスター下でレイアウトタイプまたは名前に基づいて一致するレイアウトを検索します。  
- `AddClone(sourceSlide, destinationLayout)` — クローンしたスライドを特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/) に直接添付します。  

`AddClone` のオーバーロードに渡すマスターまたはレイアウトは **宛先** プレゼンテーションに属している必要があり、ソースプレゼンテーションに属していてはいけません。

## **プレゼンテーション全体をマージして元の書式を保持する**

最もシンプルなマージは、ソースプレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウト 関係を保持すべき場合に適しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

ソースと宛先が異なるデザインを使用している場合、結果として複数のマスターがプレゼンテーションに含まれることがあります。これは、ソースの書式設定を意図的に保持したときに予想される動作です。

## **選択したスライドのみをマージする**

すべてのスライドをクローンする必要はありません。以下の例は、ソースプレゼンテーションから選択したスライドインデックスだけをインポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

ユーザー入力や外部構成から取得したインデックスの場合は、クローン前にインデックスの有効性を確認してください。

## **宛先マスターを使用してスライドをマージする**

インポートされたスライドが、すでに宛先プレゼンテーションに存在するマスターに従うべき場合は、[AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides は、ソースレイアウトのタイプまたは名前に一致する適切なレイアウトを指定されたマスター下で選択します。適切なレイアウトが存在せず `allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドが追加されます。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、`false` を使用してマージを失敗させます。

## **特定の宛先レイアウトを使用してスライドをマージする**

インポートされたスライドが正確にどの宛先レイアウトを使用すべきか分かっている場合は、[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

宛先レイアウトを適用すると継承されたレイアウト関係が変更されますが、ソーススライドのコンテンツ自体が再設計されるわけではありません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式設定とプレースホルダーの動作が適切かどうか結果を確認してください。

## **スライドサイズが異なるプレゼンテーションをマージする**

スライド寸法が異なるプレゼンテーションでもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしてもコンテンツが新しいキャンバス向けに自動的に再設計されるわけではありません。そのため、形状がずれたり、予期せぬスケーリングが行われたり、スライド領域の外に出てしまうことがあります。

実用的な方法は、クローンする前にソースプレゼンテーションのサイズを変更することです。[SlideSize.SetSize](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/setsize/) メソッドは、スライド寸法を変更しつつ既存コンテンツをスケールできます。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) は、要求されたサイズに収まるようにコンテンツをスケールします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

リサイズはメモリ上のソースプレゼンテーションオブジェクトを変更します。元のソースプレゼンテーションを他の操作でそのまま保持したい場合は、マージ用に別個のインスタンスを開いてください。

## **スライドをプレゼンテーション セクションにマージする**

基本的なスライド クローン ループは、ソースプレゼンテーションのセクション階層を再作成しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を使って明示的にスライドをそのセクションにクローンします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

クローンされたスライドは指定された宛先セクションに追加されます。複数のソースセクションを保持したい場合は、宛先で同様のセクションを再作成し、各ソーススライドを対応する宛先セクションにマッピングしてください。

## **複数のプレゼンテーションを安全にマージする**

以下のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、各追加ソースのスライドサイズを正規化し、コピー中だけソースを開き、最終的に一度だけファイルを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

これはインポートされたスライドの元書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、単純な `AddClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウト オーバーロードに置き換えてください。

## **実務上の考慮事項**

### **マスター、レイアウト、および書式忠実度**

デフォルトのスライド クローン は、必要に応じてソースマスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターの内部レジストリを保持し、同一マスターの重複クローンを防止します。手動でクローンしたマスターはこのレジストリに登録されないため、マスター構造を明示的に制御する必要がない限り、事前にマスターをクローンしないでください。

同名のマスターやレイアウトが視覚的に同等であると仮定しないでください。企業テンプレートで最終外観を管理する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライド コンテンツに紐付いており、スライドがクローンされると同時にコピーされます。Aspose.Slides は [presentation notes](https://docs.aspose.com/slides/ja/net/presentation-notes/) と [presentation comments](https://docs.aspose.com/slides/ja/net/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合、ノートマスターはプレゼンテーション レベルのオブジェクトであり、ソースファイル間で異なることがあるため、マージ後のプレゼンテーションを必ず確認してください。レビュー ワークフローでは、異なる著者やテンプレートから結合した場合のコメント作者とスレッド コメントも検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーション レベルのリソースを参照できます。スライド自体をクローンし、表示形状だけをコピーしないことで、Aspose.Slides がリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままです。スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後にプレゼンテーションを開く環境で、リンクリソースのパスや URL が有効かテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、これが無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという一般的な保証になるわけではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定してから判断してください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーション レベルで管理されます。タイポグラフィを複数マシンで一貫させる必要がある場合、スライドだけをクローンしただけでは必要なフォントが宛先環境に存在するとは限りません。[FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込みフォントを確認し、[Embed Fonts in Presentations](https://docs.aspose.com/slides/ja/net/embedded-font/) に記載の手順で埋め込みを明示的に管理してください。

また、ソースファイルで使用されているフォントの埋め込みが許可されているかライセンスを確認してください。フォントライセンスは埋め込みを制限することがあります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正しく開く必要があります。パスワードは [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) で指定してください。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力側の保護を別途設定してください。

### **巨大プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む巨大プレゼンテーションは大量のメモリを消費します。[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/blobmanagementoptions/) は BLOB の処理と一時ファイル使用を制御します。大容量ファイル向けの戦略は [Manage Presentation BLOBs](https://docs.aspose.com/slides/ja/net/manage-blob/) を参照してください。

大きなファイルの場合は可能な限りファイル パスから読み込み、各ソースプレゼンテーションはマージが完了したらすぐに破棄し、ワークフローでチェックポイントが必要な場合を除き、中間結果の保存は繰り返さないでください。

### **スレッド安全性**

同じ [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーション インスタンスは 1 つのマージ操作に限定します。独立したジョブを並列化する場合は、独立したプレゼンテーション インスタンスを使用し、[Aspose.Slides マルチスレッド ガイダンス](https://docs.aspose.com/slides/ja/net/multithreading/) に従ってください。

## **FAQ**

**元のデザインをそのまま保持するにはどうすればいいですか？**

宛先マスターやレイアウトを指定せずに [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を使用します。必要に応じて Aspose.Slides がソースマスターを自動的にクローンします。

**インポートしたスライドに宛先テーマを適用するにはどうすればいいですか？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides は各ソーススライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**宛先レイアウトを使用すべきケースはいつですか？**

すべてのインポートスライドが 1 つの既知レイアウトを使用すべき場合にレイアウトを指定します。レイアウトタイプや名前に基づいてマスター側で自動選択させたい場合はマスターを使用してください。

**サイズが異なるスライドでもマージできますか？**

可能ですが、スライド コンテンツは宛先の寸法に合わせて自動的に再設計されません。予測可能な配置が必要なときは、[SlideSize.SetSize](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) を使って事前にソースプレゼンテーションのサイズを調整してください。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルにマージできますか？**

できます。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。形式間で機能セットが完全に一致しないため、クロスフォーマット マージ後は複雑なコンテンツを必ず確認してください。[Supported File Formats](https://docs.aspose.com/slides/ja/net/supported-file-formats/) を参照してください。

**ソースのセクションは自動的に保持されますか？**

スライドだけをクローンする基本ループでは保持されません。必要なセクションを宛先で再作成し、[AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) のセクション オーバーロードを使用して構造を維持してください。

**スピーカーノートとコメントは保持されますか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメント作者、スレッドレビュー情報が重要なワークフローでは、マージ後の結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどう扱われますか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のまま残るため、マージ後もリンク先ファイルや URL が利用可能であることを確認してください。

**すべてのソースから埋め込まれたフォントはマージ後に利用可能ですか？**

スライド クローンだけに依存してフォント配布を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォントの埋め込みまたは外部フォントの可用性を明示的に管理してください。

**パスワード保護されたファイルをマージする方法は？**

正しい [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) を指定して開き、その後通常通りスライドをクローンします。出力側の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うべきですか？**

BLOB 管理オプションを使用し、大容量ファイルでは可能な限りファイル パスから読み込み、ソースプレゼンテーションはマージ後すぐに破棄し、最終結果の保存は必要な時だけ行ってください。

**複数スレッドでスライドをマージできますか？**

同一の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーション インスタンスで実行し、Aspose.Slides のマルチスレッド ガイダンスに従ってください。