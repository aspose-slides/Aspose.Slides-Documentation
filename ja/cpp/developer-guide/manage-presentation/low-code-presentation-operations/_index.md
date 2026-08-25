---
title: C++ のロウコード プレゼンテーション操作
linktitle: ロウコード API
type: docs
weight: 50
url: /ja/cpp/low-code-presentation-operations/
keywords:
- ロウコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復
- シェイプの反復
- テキストの反復
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスター スライドの削除
- 未使用レイアウト スライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で Aspose.Slides のロウコード API を使用して、プレゼンテーションの変換と結合、コンテンツの反復、シェイプの収集、プレゼンテーションサイズの削減を行います。"
---
## **概要**

[Aspose::Slides::LowCode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/) 名前空間は、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を少ないコードで実行できるようにします。

Low-code ヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/cpp/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです：

| ヘルパー | 使用用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/convert/) | ファイル間の直接呼び出しでプレゼンテーションを別形式に変換する |
| [Merger](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/merger/) | 同じ形式のプレゼンテーションファイル全体を結合する |
| [ForEach](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/) | 各スライド、シェイプ、段落、テキスト部分に対してアクションを実行する |
| [Collect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に利用する |
| [Compress](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減する |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を決定できる場合は、[Convert::AutoByExtension](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/convert/autobyextension/) を使用します。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判断して結果を書き込みます。

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/convert/) クラスは PDF、SVG、JPEG、PNG、TIFF 出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査・修正したり、選択したヘルパーが提供しないエクスポートオプションを構成する必要がある場合は、フルオブジェクトモデルを使用してください。形式別のワークフローとオプションについては、[Convert Presentation](/slides/ja/cpp/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

[Merger::Process](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/merger/process/) を使用すると、1 回の呼び出しでプレゼンテーションファイル全体を結合できます。入力プレゼンテーションは同じファイル形式である必要があります。

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

すべてのスライドを個別に選択または再マッピングせずに 1 つの結果に追加したい場合にこのヘルパーは適しています。選択したスライドだけを結合したり、宛先マスターやレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整したりする必要がある場合は、フルオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/slides/ja/cpp/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/) クラスは、要求されたプレゼンテーション要素のタイプごとにコールバックを呼び出します。ネストしたコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

次の例は、[ForEach::Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/slide/)、[ForEach::Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/paragraph/)、および [ForEach::Portion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/portion/) を使用して対応する要素を検査します：

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

デフォルトでは、プレゼンテーション全体のシェイプとテキストの走査には通常スライド、マスタースライド、レイアウトスライドが含まれます。`includeNotes` パラメーターを持つオーバーロードを使用すると、ノートスライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、または詳細な親子制御が重要な場合は、直接のコレクションループを使用してください。

## **シェイプの収集**

各シェイプに対するコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要な場合は、[Collect::Shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/collect/shapes/) を使用します。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

各シェイプをすぐに処理でき、収集結果を保持する必要がない場合は、代わりに [ForEach::Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/shape/) を使用してください。

## **プレゼンテーション コンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/) クラスは未使用の構造要素を削除し、埋め込みフォントデータを削減できます：

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) は、通常のスライドから参照されていないレイアウトスライドを削除します。
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) は、使用されていなくなったマスタースライドを削除します。
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) は、埋め込みフォントから未使用の文字を削除します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

未使用のレイアウトを先に削除し、その後未使用のマスターを削除してください。レイアウトのクリーンアップ後に参照がなくなったマスターも削除対象になります。最適化されたプレゼンテーションを新しいファイルに保存すれば、後で元のマスター、レイアウト、または完全な埋め込みフォントデータが必要になる場合に備えられます。詳細は [Slide Master](/slides/ja/cpp/slide-master/) と [Embedded Font](/slides/ja/cpp/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフル オブジェクトモデルの代わりに使用すべきタイミングは？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合に low-code ヘルパーを使用します。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、途中状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合はフルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

できません。[Merger::Process](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/merger/process/) は、入力プレゼンテーションが同じ形式であることを要求します。まず [Convert::AutoByExtension](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/convert/autobyextension/) などで入力ファイルを共通の形式に変換し、その後で変換後のファイルを結合してください。

**ForEach はマスター、レイアウト、ノート スライドも処理しますか？**

[ForEach::Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/slide/) は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の [ForEach::Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/paragraph/)、および [ForEach::Portion](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/portion/) はデフォルトで通常スライド、マスター、レイアウトスライドを含みます。`includeNotes` を `true` に設定したオーバーロードを使用すれば、ノートスライドも含められます。

**ForEach::Shape と Collect::Shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理したい場合は [ForEach::Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/shape/) を使用します。シェイプの集合を保持し、後でフィルタリング、カウント、または複数回走査したい場合は [Collect::Shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/collect/shapes/) を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果はプレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress] 操作はファイルサイズを減少させないことがあります。

**ForEach や Compress によって加えられた変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ内の [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトに対して操作を行います。[ForEach](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/foreach/) のコールバック内で要素を変更したり、[Compress](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/) を実行した後は、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) を呼び出して結果を書き出す必要があります。

## **Related Articles**

- [プレゼンテーションの変換](/slides/ja/cpp/convert-presentation/)
- [プレゼンテーションの結合](/slides/ja/cpp/merge-presentation/)
- [スライド マスター](/slides/ja/cpp/slide-master/)
- [テキスト ボックスの管理](/slides/ja/cpp/manage-textbox/)
- [埋め込みフォント](/slides/ja/cpp/embedded-font/)