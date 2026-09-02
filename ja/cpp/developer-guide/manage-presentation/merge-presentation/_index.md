---
title: C++でプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/cpp/merge-presentation/
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
- C++
- Aspose.Slides
description: "C++でスライドをクローンし、マスターやレイアウトを制御し、スライドコンテンツのサイズ変更、セクションの保持、保護されたファイルや大容量ファイルの処理を行うことで、PowerPoint および OpenDocument のプレゼンテーションをマージする方法をご紹介します。"
---
## **概要**

Aspose.Slides for C++ は、ある[プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)からスライドを複製して別のプレゼンテーションに統合します。主な操作は[ISlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/)で、元のスライドの書式を保持するか、複製されたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付できます。

本記事では最も一般的なマージワークフローを取り上げます。

- すべてのスライドを元の書式を保持したままマージする
- 選択したスライドだけをマージする
- 宛先プレゼンテーションのマスターを適用する
- 宛先プレゼンテーションの特定レイアウトを適用する
- マージ前に異なるスライドサイズを正規化する
- 複製したスライドをセクションに追加する
- 複数のプレゼンテーションをエンドツーエンドでマージする
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドに関する考慮事項を扱う

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから多くの外観を継承します。そのため、選択するクローンのオーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で[ISlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/)を使用します。

- `AddClone(sourceSlide)` — 元スライドのレイアウトと書式を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じ元マスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 複製されたスライドを特定の宛先[IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/)に添付します。Aspose.Slides はマスター内でレイアウトタイプまたは名前に基づく一致レイアウトを検索します。
- `AddClone(sourceSlide, destinationLayout)` — 複製されたスライドを特定の宛先[ILayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/)に直接添付します。

`AddClone` オーバーロードに渡すマスターまたはレイアウトは **宛先** プレゼンテーションに属している必要があり、元プレゼンテーションには属していてはいけません。

## **プレゼンテーション全体をマージして元の書式を保持する**

最もシンプルなマージは、元プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適しています。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

元と宛先でデザインが異なる場合、結果のプレゼンテーションには複数のマスターが含まれることがあります。これは元書式を意図的に保持した場合の期待通りの動作です。

## **選択したスライドだけをマージする**

すべてのスライドをクローンする必要はありません。次の例は、元プレゼンテーションから選択されたスライドインデックスだけをインポートします。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

ユーザー入力や外部設定から取得したインデックスは、クローン前に必ず検証してください。

## **宛先マスターを使用してスライドをマージする**

インポートされたスライドが、すでに宛先プレゼンテーションに存在するマスターに従う必要がある場合、[AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides は、ソースレイアウトのタイプまたは名前に一致する適切なレイアウトを指定されたマスター下で選択します。適切なレイアウトが存在せず、`allowCloneMissingLayout` が `true` の場合、ソースレイアウトがクローンされてスライドが追加されます。`false` の場合は、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/details_pptxeditexception/) がスローされます。

マージを失敗させて宛先マスターに余計なレイアウトを追加したくない場合は `false` を使用してください。

## **特定の宛先レイアウトを使用してスライドをマージする**

インポートされたスライドが正確にどの宛先レイアウトを使用すべきか分かっている場合は、[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

宛先レイアウトを適用すると継承されたレイアウトの関係が変わりますが、ソーススライドのコンテンツ自体は再設計されません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合は、結果を確認し、継承された書式とプレースホルダー動作が期待通りか検証してください。

## **異なるスライドサイズのプレゼンテーションをマージする**

スライドサイズが異なるプレゼンテーションでもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再設計されません。そのため、形状がずれたり、予期せぬスケーリングが発生したり、表示領域外に出ることがあります。

実用的なアプローチは、クローン前にソースプレゼンテーションのサイズを変更することです。[SlideSize::SetSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesize/setsize/) メソッドは、スライド寸法を変更しながら既存コンテンツをスケールできます。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/) は、要求されたサイズに合わせてコンテンツをフィットさせます。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

リサイズはメモリ上のソースプレゼンテーションオブジェクトを変更します。元のソースプレゼンテーションを他の操作でそのまま保持したい場合は、マージ用に別インスタンスを開いてください。

## **スライドをプレゼンテーションのセクションにマージする**

基本的なスライドクローンループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使ってスライドを明示的にセクションにクローンします。

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

クローンされたスライドは指定された宛先セクションに追加されます。複数の元セクションを保持したい場合は、宛先に同様のセクションを再作成し、各元スライドを対応する宛先セクションにマッピングしてください。

## **複数のプレゼンテーションを安全にマージする**

以下のエンドツーエンド例は、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、各ソースはコピー中だけ開き、最終的に一度だけファイルを保存します。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

これはインポートされたスライドの元書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、単純な `AddClone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウトオーバーロードに置き換えてください。

## **実務上の考慮点**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じて元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターの内部レジストリを保持し、同一マスターの重複クローンを防止します。手動でクローンしたマスターはこのレジストリで追跡されないため、明確な制御が必要な場合を除き事前にマスターをクローンしないでください。

名前が同じでも、2 つのマスターやレイアウトが視覚的に同等であるとは限りません。企業テンプレートで最終外観を管理する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を必ず検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐付いており、スライドをクローンすると同時にコピーされます。Aspose.Slides は[プレゼンテーションノート](https://docs.aspose.com/slides/ja/cpp/presentation-notes/)および[プレゼンテーションコメント](https://docs.aspose.com/slides/ja/cpp/presentation-comments/)用の専用 API も提供しています。

ノートページの書式が重要な場合は、ノートマスターがプレゼンテーションレベルのオブジェクトであり、元ファイル間で異なる可能性があるため、マージ後のプレゼンテーションを必ず確認してください。レビュー用ワークフローでは、異なる作者やテンプレートから結合した場合のコメント作者やスレッドコメントも検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなどのプレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないようにして、Aspose.Slides がリソースとの関係を維持できるようにしてください。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変わることはありません。マージされたプレゼンテーションが開かれる環境で、リンクリソースのパスと URL をテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、これは無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという保証ではありません。出力ファイルサイズが重要な場合は、マージ後のパッケージを検査し、結果を測定して重複除去に依存しないでください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーションレベルで管理されます。タイポグラフィをマシン間で一貫させる必要がある場合、スライドだけをクローンしただけでは必要なフォントが宛先環境に揃っているとは限りません。[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込みフォントを確認し、[プレゼンテーションへのフォント埋め込み](https://docs.aspose.com/slides/ja/cpp/embedded-font/) に記載の方法で明示的に管理してください。

また、ソースファイルで使用されているフォントを埋め込み可能かどうか、ライセンス制限も確認してください。

### **パスワード保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンできるようにまず正常に開く必要があります。パスワードは[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/)で指定します。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力保護を別途設定してください。

### **大規模プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む大規模プレゼンテーションは、かなりのメモリを消費します。[LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) で BLOB の取り扱いと一時ファイル使用を制御できます。大容量ファイル向けの戦略は[プレゼンテーション BLOB の管理](https://docs.aspose.com/slides/ja/cpp/manage-blob/)を参照してください。

大きなファイルでは、可能な限りファイルパスから読み込み、各ソースプレゼンテーションはマージ完了次第すぐに破棄し、ワークフローでチェックポイントが必要な場合を除き中間結果の保存は繰り返さないでください。

### **スレッド安全性**

同一の[プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは1つのマージ操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッドガイダンス](https://docs.aspose.com/slides/ja/cpp/multithreading/)に従ってください。

## **FAQ**

**各ソースプレゼンテーションの元デザインを保持するには？**

宛先マスターやレイアウトを指定せずに[`AddClone(sourceSlide)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使用します。必要に応じて Aspose.Slides が元マスターを自動的にクローンします。

**インポートされたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく宛先プレゼンテーションからマスターを渡してください。Aspose.Slides は各ソーススライドをそのマスター下の適切なレイアウトにマッピングしようとします。

**宛先マスターではなく特定の宛先レイアウトを使うべきケースは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合は特定レイアウトを使用します。ソースレイアウトのタイプや名前に基づいてマスター内のレイアウトを自動選択させたい場合はマスターを使用してください。

**異なるスライドサイズのプレゼンテーションはマージ可能か？**

可能ですが、スライドコンテンツは宛先サイズに合わせて自動的に再設計されません。予測可能な配置が必要な場合は、[SlideSize::SetSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesize/setsize/) と [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/) を使ってソースプレゼンテーションを事前にリサイズしてください。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルにマージできるか？**

はい。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。プレゼンテーション形式間で機能セットが完全に一致しないため、クロスフォーマットマージ後は複雑なコンテンツを必ず検証してください。[対応ファイル形式](https://docs.aspose.com/slides/ja/cpp/supported-file-formats/) を参照してください。

**元セクションは自動的に保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先で必要なセクションを再作成し、[AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) のセクションオーバーロードを使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンされたスライドと共にコピーされます。ノートマスターの書式やコメント作者、スレッドレビュー情報に依存するワークフローの場合は、マージ結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、マージ後もターゲットファイルや URL が利用可能である必要があります。

**すべてのソースから埋め込みフォントは保証されるか？**

スライドクローンだけに頼らず、フォントの展開を確認し、必要に応じて明示的に埋め込みまたは外部フォントの可用性を管理してください。

**パスワード保護されたファイルをどうマージするか？**

正しい[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/)で開き、その後スライドを通常通りクローンします。出力の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理を使用し、大容量バイナリがメモリ使用量を支配する場合はファイルパスからのロードを優先し、ソースプレゼンテーションはマージ完了次第すぐに破棄し、必要なときだけ最終結果を保存してください。

**複数スレッドからスライドをマージできるか？**

同一の[プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)インスタンスを複数スレッドで同時に使用しないでください。各マージ操作は独立したプレゼンテーションインスタンスで実行し、[Aspose.Slides のマルチスレッドガイダンス](https://docs.aspose.com/slides/ja/cpp/multithreading/)に従ってください。