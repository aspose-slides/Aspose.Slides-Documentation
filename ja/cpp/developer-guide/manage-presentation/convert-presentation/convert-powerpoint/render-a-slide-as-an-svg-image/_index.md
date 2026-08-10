---
title: C++ でプレゼンテーション スライドを SVG 画像としてレンダリング
linktitle: スライドから SVG
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG
- プレゼンテーションから SVG
- スライドから SVG
- PPT から SVG
- PPTX から SVG
- SVG エクスポート オプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVG は、スケーラブルな XML ベースの画像フォーマットで、Web 発行、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides for C++ は各スライドを個別の SVG ファイルにエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに、ブラウザ間で予測可能に、またはインタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) を作成し、スライドを選択してストリームに書き出します。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

ファイル名はループインデックスではなく [ISlide::get_SlideNumber](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/get_slidenumber/) を使用します。また、スライドビューアやウェブページが特定の形状だけを必要とする場合は、[IShape::WriteAsSvg](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/writeassvg/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_useframesize/) はテキストフレームを描画領域に含め、[SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_useframerotation/) はフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) を `true` に設定します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **テキストとフォントの制御**

### **すべてのテキストをベクトル化**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) を `true` に設定すると、スライドのすべてのテキストがベクトルグラフィックとして書き出されます。これによりフォントへの依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **外部フォントの取り扱い方法を選択**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると別個のフォントファイルへの参照が作成され、`Embed` を選択するとフォントデータが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストのみがグラフィックとして描画されます。フォントを埋め込む前に、ライセンスを必ず確認してください。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **埋め込み画像サイズの削減**

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_picturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) で切り取られた元領域を省略し、[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_jpegquality/) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **シェイプとテキストに安定した ID を割り当てる**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgshapeformattingcontroller/) を使用して各 SVG シェイプの [ISvgShape::set_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgshape/set_id/) を設定します。テキストの `tspan` 要素にも [ISvgTSpan::set_Id](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgtspan/set_id/) を設定したい場合は、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) を実装します。いずれのコントローラも [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) で割り当てます。

以下のコントローラは [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_officeinteropshapeid/) を使用します。これはシェイプの存続期間中に安定しており、テキストスパン用に再利用可能なカウンタを持ちます。このため、生成された ID は変更されていないプレゼンテーションのポストプロセッシングに適しています。

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **SVG イベントハンドラの追加**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 内で、[ISvgShape::SetEventHandler](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isvgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) で割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義します。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ機能、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**いつ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) を [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべきか？**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) は、すべてのテキストをフォントに依存しないようにしたい場合に使用します。[SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgexternalfontshandling/) は、外部フォントを使用するテキストのみをグラフィックに変換したいときに使用します。

**SVG をより小さくする最善の方法は何ですか？**

まず、埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で提供可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクトル化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコントローラで ID を割り当てた後、ポストプロセッシングツールやブラウザスクリプトで対応する SVG 要素を選択できます。