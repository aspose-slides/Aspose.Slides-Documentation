---
title: .NET でプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "スライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズを変更し、セクションを保持し、保護されたファイルや大容量ファイルを扱うことで、.NETでPowerPointおよびOpenDocumentプレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for .NET は、ある [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) からスライドをクローンして別のプレゼンテーションにマージします。主な操作は [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) で、元スライドの書式設定を保持するか、クローンされたスライドを宛先プレゼンテーションのマスターまたはレイアウトに結び付けるかを選択できます。

本記事では、最も一般的なマージワークフローを取り上げます。

- すべてのスライドを元の書式を保持したままマージ
- 選択したスライドだけをマージ
- 宛先プレゼンテーションのマスターを適用
- 宛先プレゼンテーションの特定レイアウトを適用
- マージ前に異なるスライドサイズを正規化
- クローンされたスライドをセクションに追加
- 複数のプレゼンテーションをエンドツーエンドでマージ
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大容量ファイル、マルチスレッドに関する考慮事項

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の大部分を継承します。そのため、選択するクローンのオーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

[ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を次のいずれかの方法で使用します。

- `AddClone(sourceSlide)` — 元スライドのレイアウトと書式を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じマスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンされたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) に結び付けます。Aspose.Slides はそのマスター下でレイアウトタイプまたは名前に基づいて一致するレイアウトを検索します。
- `AddClone(sourceSlide, destinationLayout)` — クローンされたスライドを特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/) に直接結び付けます。

`AddClone` のオーバーロードに渡すマスターまたはレイアウトは **宛先** プレゼンテーションに属している必要があり、元プレゼンテーションのものは使用できません。

## **プレゼンテーション全体をマージし、元の書式を保持する**

最も簡単なマージは、元プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適しています。

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

元と宛先でデザインが異なる場合、結果のプレゼンテーションに複数のマスターが含まれることがあります。これは元の書式を意図的に保持した場合の想定通りの動作です。

## **選択したスライドだけをマージ**

すべてのスライドをクローンする必要はありません。次の例は、元プレゼンテーションから選択されたスライドインデックスだけをインポートします。

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

ユーザー入力や外部設定から取得したインデックスは、クローンする前に必ず検証してください。

## **宛先マスターを使用してスライドをマージ**

インポートされたスライドが、すでに宛先プレゼンテーションに存在するマスターに従う必要がある場合は、[AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

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

Aspose.Slides は、元レイアウトのタイプまたは名前に一致する適切なレイアウトを指定されたマスター下で選択します。適切なレイアウトが存在せず、`allowCloneMissingLayout` が `true` の場合は、元レイアウトがクローンされてスライドが追加されます。`false` の場合は [PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、`false` を使用してマージを失敗させてください。

## **特定の宛先レイアウトを使用してスライドをマージ**

インポートされたスライドが使用すべき宛先レイアウトが明確に決まっている場合は、[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

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

宛先レイアウトを適用すると、継承されるレイアウトの関係が変更されますが、元スライドの内容自体は再設計されません。元と宛先のレイアウトでプレースホルダー構造が異なる場合は、継承された書式とプレースホルダーの動作が期待通りかどうかを確認してください。

## **スライドサイズが異なるプレゼンテーションをマージ**

スライドサイズが異なるプレゼンテーション同士でもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけでは、コンテンツが新しいキャンバスに合わせて自動的に再設計されません。その結果、形状がずれたり、スケールが予期せぬ形になったり、スライド領域外に表示されたりします。

実用的な手順としては、クローン前に元プレゼンテーションのサイズを変更します。[SlideSize.SetSize](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/setsize/) メソッドは、スライド寸法を変更しながら既存コンテンツをスケーリングできます。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) は、要求されたサイズに収まるようにコンテンツをスケーリングします。

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

リサイズはメモリ上の元プレゼンテーションオブジェクトを変更します。元プレゼンテーションを他の操作でそのまま保持したい場合は、マージ用に別インスタンスを開いてください。

## **スライドをプレゼンテーションのセクションにマージ**

基本的なスライドクローンループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を使用してスライドを明示的にセクションへクローンします。

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

クローンされたスライドは指定された宛先セクションへ追加されます。複数の元セクションを保持したい場合は、[Presentation.Sections](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sections/) を列挙し、各元セクションのスライドを [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/getslideslistofsection/) で取得し、宛先に同名セクションを再作成してから対応するスライドをクローンしてください。完全なセクション列挙サンプルは [Manage Slide Sections](/slides/ja/net/slide-section/) を参照してください。

## **複数プレゼンテーションを安全にマージ**

次のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中だけ開き、最終的に一度だけファイルを保存します。

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

これは、インポートされたスライドの元書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、単純な `AddClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実務上の考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じて元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターの内部レジストリを保持し、同一マスターの重複クローンを防ぎます。手動でクローンしたマスターはこのレジストリに登録されないため、明示的にマスター構造を制御したい場合以外は事前クローンを避けてください。

名前が同じでも、2つのマスターやレイアウトが視覚的に同等であるとは限りません。企業テンプレートで最終的な外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を必ず検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐付いており、スライドがクローンされると同時にコピーされます。Aspose.Slides は [presentation notes](/slides/ja/net/presentation-notes/) と [presentation comments](/slides/ja/net/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式が重要な場合は、ノートマスターがプレゼンテーションレベルのオブジェクトであり、元ファイル間で異なる可能性があるため、マージ後のプレゼンテーションを必ず確認してください。レビューシナリオでは、異なる作者やテンプレートから結合した場合のコメント作者やスレッド構造も検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなど、プレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないようにして、Aspose.Slides がリソースとの関係を保持できるようにしてください。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージ後に表示される環境で、リンクリソースのパスや URL が有効かテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係なソースプレゼンテーション間で同一のバイナリリソースが常に重複除去されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、実際のサイズを測定してください。

### **埋め込みフォントとフォントの利用可能性**

フォントはプレゼンテーションレベルで管理されます。タイポグラフィを複数マシンで一貫させる必要がある場合、スライドをクローンするだけでは目的のフォントが宛先環境に存在するとは限りません。[FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込みフォントを確認し、[Embed Fonts in Presentations](/slides/ja/net/embedded-font/) に示すように明示的に埋め込みを管理してください。

また、ソースファイルで使用されているフォントを埋め込む許可があるかどうかも確認してください。フォントライセンスは埋め込みを制限することがあります。

### **パスワード保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正常に開く必要があります。パスワードは [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) で指定します。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力側の保護を別途設定してください。

### **大容量プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを多数含む大容量プレゼンテーションは、かなりのメモリを消費します。[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/blobmanagementoptions/) で BLOB の取り扱いと一時ファイル使用を制御できます。大容量ファイル向けの戦略は [Manage Presentation BLOBs](/slides/ja/net/manage-blob/) を参照してください。

大きなファイルの場合は、可能な限りファイルパスからロードし、各ソースプレゼンテーションはマージ完了次第すぐに破棄し、ワークフローでチェックポイントが必要な場合を除き中間結果の保存は繰り返さないようにしてください。

### **スレッド安全性**

同一の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは単一のマージ操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッド ガイダンス](/slides/ja/net/multithreading/) に従ってください。

## **FAQ**

**各ソースプレゼンテーションの元デザインを保持するには？**

宛先マスターやレイアウトを指定せずに [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) を使用します。必要に応じて、Aspose.Slides が元マスターを自動的にクローンします。

**インポートされたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。宛先プレゼンテーションのマスターを渡し、元プレゼンテーションのものは渡さないでください。Aspose.Slides は各元スライドをそのマスター下の適切なレイアウトへマッピングしようとします。

**特定の宛先レイアウトを使用すべき場面は？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合は、特定レイアウトを使用します。元レイアウトのタイプや名前に基づいてマスターがレイアウトを選択すべき場合は、マスターを使用してください。

**スライドサイズが異なるプレゼンテーションはマージできるか？**

可能です。ただし、スライドコンテンツは宛先サイズに自動的に再設計されません。予測可能な配置が必要な場合は、[SlideSize.SetSize](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) を使って事前にソースプレゼンテーションのサイズを変更してください。

**PPT、PPTX、ODP プレゼンテーションを1つのファイルにマージできるか？**

はい。各ソースをロードし、必要なスライドを1つの宛先にクローンして、サポートされている出力形式で保存します。フォーマット間で完全に同じ機能セットが提供されていないため、クロスフォーマットのマージ後は複雑なコンテンツを必ず確認してください。対応フォーマットは [Supported File Formats](/slides/ja/net/supported-file-formats/) を参照してください。

**元のセクションは自動的に保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先にセクションを再作成し、[AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドとともにコピーされます。ノートマスターのスタイリング、コメント作者、スレッド化されたレビュー情報が重要なワークフローでは、マージ結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、マージ後も対象ファイルや URL が利用可能である必要があります。

**すべてのソースから埋め込まれたフォントはマージ後に利用可能か？**

スライドのクローンだけに依存してフォント配布を保証しないでください。宛先の埋め込みフォントを確認し、タイポグラフィが重要な場合はフォント埋め込みまたは外部フォントの利用を明示的に管理してください。

**パスワード保護されたファイルをマージする方法は？**

正しい [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) で開き、通常どおりスライドをクローンします。出力側の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うべきか？**

BLOB 管理を使用し、大容量バイナリがメモリ使用量を支配する場合はファイルパスからのロードを優先し、ソースプレゼンテーションはマージ完了次第すぐに破棄し、最終結果の保存は必要時のみ行ってください。

**複数スレッドからスライドをマージできるか？**

同一の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーションインスタンスで実行してください。