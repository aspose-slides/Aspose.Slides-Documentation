---
title: C++ でプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/cpp/merge-presentation/
keywords:
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PowerPoint を組み合わせ
- プレゼンテーションを組み合わせ
- スライドを組み合わせ
- PPT を組み合わせ
- PPTX を組み合わせ
- ODP を組み合わせ
- C++
- Aspose.Slides
description: "C++ でスライドをクローンし、マスターやレイアウトを制御し、スライドコンテンツをリサイズし、セクションを保持し、保護されたファイルや大容量ファイルを扱うことで、PowerPoint と OpenDocument のプレゼンテーションを結合する方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、ある[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)から別のプレゼンテーションへスライドをクローンすることでプレゼンテーションを結合します。主な操作は[ISlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/)で、元スライドの書式を保持したままクローンしたスライドを宛先プレゼンテーションのマスターやレイアウトに添付できます。

この項目では、最も一般的な結合ワークフローを扱います。

- すべてのスライドを元の書式を保持して結合
- 選択したスライドだけを結合
- 宛先プレゼンテーションのマスターを適用
- 宛先プレゼンテーションの特定レイアウトを適用
- 結合前に異なるスライドサイズを正規化
- セクションにクローンスライドを追加
- 複数のプレゼンテーションをエンドツーエンドで結合
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大容量ファイル、マルチスレッドに関する考慮事項

## **スライドのクローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから外観の多くを継承します。そのため、選択するクローンのオーバーロードにより、結合されたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で[ISlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/)を使用します。

- `AddClone(sourceSlide)` — 元スライドのレイアウトと書式を保持します。必要に応じて、元のマスターは自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じ元マスターを使用するスライドが繰り返しクローンされることを防ぎます。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — クローンスライドを特定の宛先[IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/)に添付します。Aspose.Slides はそのマスター配下でレイアウトタイプまたは名前で一致するレイアウトを検索します。
- `AddClone(sourceSlide, destinationLayout)` — クローンスライドを特定の宛先[ILayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/)に直接添付します。

`AddClone` のオーバーロードに渡すマスターまたはレイアウトは、**宛先**プレゼンテーションに属している必要があり、元プレゼンテーションのものは使用できません。

## **プレゼンテーション全体を結合し元書式を保持する**

最もシンプルな結合は、元プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートされたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場面で適しています。

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

元と宛先でデザインが異なる場合、結果のプレゼンテーションには複数のマスターが含まれることがあります。これは元書式を意図的に保持しているため期待される動作です。

## **選択したスライドを結合する**

すべてのスライドをクローンする必要はありません。次の例は、元プレゼンテーションから選択したスライドインデックスだけをインポートします。

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

## **宛先マスターを使用してスライドを結合する**

インポートされたスライドが既に宛先プレゼンテーションに存在するマスターに従うべき場合は、[AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

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

Aspose.Slides は、元レイアウトのタイプまたは名前と一致する適切なレイアウトを指定されたマスター配下から選択します。適切なレイアウトが存在せず、`allowCloneMissingLayout` が `true` の場合は、元レイアウトがクローンされてスライドが追加されます。`false` の場合は、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/details_pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、`false` を使用して結合を失敗させます。

## **特定の宛先レイアウトを使用してスライドを結合する**

インポートされたスライドが必ず使用すべき宛先レイアウトが決まっている場合は、[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) オーバーロードを使用します。

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

宛先レイアウトを適用すると継承されたレイアウトの関係が変わりますが、元スライドのコンテンツ自体は再デザインされません。元と宛先のレイアウトでプレースホルダー構造が異なる場合は、結果を確認し、継承された書式とプレースホルダーの動作が期待通りか検証してください。

## **異なるスライドサイズのプレゼンテーションを結合する**

スライドサイズが異なるプレゼンテーションでも結合は可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけではコンテンツが新しいキャンバスに合わせて自動的に再デザインされません。そのため、形状がずれたり、予期せず拡大縮小されたり、スライド領域外に出てしまうことがあります。

実用的な方法は、クローン前に元プレゼンテーションのサイズを変更することです。`[SlideSize::SetSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesize/setsize/)` メソッドは、スライドサイズを変更しつつ既存コンテンツをスケーリングできます。`[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidesizescaletype/)` は要求されたサイズに収まるようコンテンツをスケーリングします。

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

サイズ変更はメモリ上の元プレゼンテーションオブジェクトを変更します。元プレゼンテーションを他の操作でも使い回す必要がある場合は、結合用に別インスタンスを開いてください。

## **セクションへスライドを結合する**

基本的なスライドクローンループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使ってスライドを明示的にクローンします。

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

クローンスライドは指定された宛先セクションに追加されます。複数の元セクションを保持したい場合は、[Presentation::get_Sections](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sections/) を列挙し、各元セクションのスライドを[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/getslideslistofsection/) で取得し、宛先に同名セクションを再作成して対応するセクションへクローンしてください。完全なセクション列挙例は[Manage Slide Sections](/slides/ja/cpp/slide-section/) を参照してください（空セクションや構造変更も含む）。

## **複数プレゼンテーションを安全に結合する**

以下のエンドツーエンド例は、最初のプレゼンテーションを宛先とし、追加の各ソースのスライドサイズを正規化し、コピー中だけソースを開き、最後に一度だけファイルを保存します。

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

これはインポートスライドの元書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、単純な `AddClone(slide)` 呼び出しを前述の宛先マスターまたは宛先レイアウトオーバーロードに置き換えてください。

## **実務上の考慮事項**

### **マスター、レイアウト、書式忠実度**

デフォルトのスライドクローンは、必要に応じて元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターの内部レジストリを保持し、同じマスターの繰り返しクローンを防ぎます。手動で事前にマスターをクローンした場合はこのレジストリに登録されないため、意図しない重複クローンを防ぐために事前クローンは避けてください。

同名のマスターやレイアウトが視覚的に同等であると決め付けないでください。企業テンプレートで最終外観を統制する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、結合後に結果を必ず検証します。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐づいており、スライドがクローンされる際にコピーされます。Aspose.Slides は[プレゼンテーションノート](/slides/ja/cpp/presentation-notes/) と[プレゼンテーションコメント](/slides/ja/cpp/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、元ファイル間で異なることがあります。レビュー工程では、結合後にコメント作者やスレッドコメントも必ず確認してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドはプレゼンテーションレベルのリソース（画像、埋め込み音声、埋め込み動画、OLE データ）への参照を保持できます。スライド全体をクローンし、可視形状だけをコピーしないようにしてください。これにより Aspose.Slides はリソースとの関係を維持できます。

埋め込みリソースとリンクリソースは別扱いです。リンクされた音声・動画・OLE オブジェクト・ハイパーリンクは外部ターゲットに依存したままで、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。結合後にリンク先のパスや URL が正しく解決できるか、対象環境で必ずテストしてください。

Aspose.Slides は自動クローンされたマスターを追跡しますが、無関係な元プレゼンテーション間で同一バイナリリソースが常に重複除去されるという保証ではありません。出力ファイルサイズが重要な場合は、結合パッケージを検査し、実際のサイズを測定してください。

### **埋め込みフォントとフォントの可用性**

フォントはプレゼンテーションレベルで管理されます。機種間でタイポグラフィを一致させる必要がある場合、スライドだけをクローンしただけで必ずしもすべての必要フォントが宛先環境に存在するとは限りません。`[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getembeddedfonts/)` で埋め込みフォントを確認し、[Embed Fonts in Presentations](/slides/ja/cpp/embedded-font/) に記載の方法で明示的に埋め込みを管理してください。

また、元ファイルで使用されているフォントの埋め込みが許可されているかライセンスを必ず確認してください。

### **パスワード保護されたプレゼンテーション**

パスワードで保護された元ファイルは、スライドをクローンする前に正しく開く必要があります。`[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/)` でパスワードを指定してください。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

暗号化された元を開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて出力保護を別途設定してください。

### **大容量プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他大容量バイナリオブジェクトを含む大容量プレゼンテーションは、メモリを大量に消費します。`[LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/)` で BLOB の取り扱いと一時ファイル使用を制御できます。大容量ファイル向けの戦略は[Manage Presentation BLOBs](/slides/ja/cpp/manage-blob/) を参照してください。

大容量ファイルの場合は可能な限りファイルパスからロードし、結合が完了したらすぐに各元プレゼンテーションを破棄し、ワークフローでチェックポイントが必要なとき以外は中間結果の保存を繰り返さないでください。

### **スレッド安全性**

同一の[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)インスタンスを複数スレッドから同時にロード、変更、保存、クローンしないでください。各プレゼンテーションインスタンスは 1 つの結合操作に限定してください。独立したジョブを並列化する場合は、独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッドガイダンス](/slides/ja/cpp/multithreading/) に従ってください。

## **FAQ**

**各元プレゼンテーションの元デザインを保持するには？**

宛先マスターやレイアウトを指定せずに[AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使用します。Aspose.Slides は必要に応じて元マスターを自動的にクローンします。

**インポートしたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。宛先プレゼンテーションのマスターを渡し、元のマスターは使用しません。Aspose.Slides は各元スライドをそのマスター配下の適切なレイアウトにマッピングしようとします。

**宛先レイアウトを使用すべきケースは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合はレイアウトオーバーロードを、元レイアウトのタイプや名前に応じてマスター配下のレイアウトを自動選択させたい場合はマスターオーバーロードを使用してください。

**異なるスライドサイズのプレゼンテーションは結合できるか？**

可能ですが、スライドコンテンツは自動的に新しいサイズにリデザインされません。予測可能な配置が必要な場合は、`[SlideSize::SetSize]` と `[SlideSizeScaleType::EnsureFit]` を使用して元プレゼンテーションのサイズを事前に調整してください。

**PPT、PPTX、ODP を 1 ファイルに結合できるか？**

可能です。各元プレゼンテーションをロードし、必要なスライドを 1 つの宛先にクローンして、サポートされている形式で保存します。フォーマット間で機能差があるため、クロスフォーマット結合後は複雑なコンテンツを必ず確認してください。[Supported File Formats](/slides/ja/cpp/supported-file-formats/) を参照してください。

**元セクションは自動的に保持されるか？**

スライドだけをクローンする基本ループでは保持されません。セクション構造が必要な場合は、宛先にセクションを再作成し、セクションオーバーロードの [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) を使用してください。

**スピーカーノートとコメントは保持されるか？**

クローンスライドとともにコピーされます。ノートマスターの書式やコメント作者、スレッドレビュー情報が重要なワークフローでは、結合結果を必ず検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなるか？**

埋め込みコンテンツはクローンスライドのリソース関係として持ち越されます。外部リンクは外部のままで、結合後も対象ファイルや URL が利用可能である必要があります。

**すべての元から埋め込まれたフォントは結合後に利用可能か？**

スライドクローンだけに依存してフォント展開を保証しないでください。宛先の埋め込みフォントを確認し、必要に応じて明示的に埋め込みまたは外部フォントを管理してください。

**パスワード保護されたファイルはどう結合するか？**

正しい `[LoadOptions::set_Password]` で開き、通常通りスライドをクローンします。出力の保護は別途設定してください。

**非常に大きなプレゼンテーションはどう扱うか？**

BLOB 管理オプションを使用し、可能な限りファイルパスからロードし、ソースプレゼンテーションは結合直後に速やかに破棄し、最終結果の保存は必要なときだけ行ってください。

**複数スレッドでスライドを結合できるか？**

1 つの [Presentation] インスタンスを複数スレッドで同時に使用しないでください。各スレッドは独立したプレゼンテーションインスタンスで作業し、Aspose.Slides のマルチスレッドガイドラインに従ってください。