---
title: C++でプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドをSVGへ
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPointからSVGへ
- プレゼンテーションからSVGへ
- スライドからSVGへ
- PPTからSVGへ
- PPTXからSVGへ
- SVGエクスポートオプション
- インタラクティブSVG
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++でPowerPointスライドをSVG画像としてエクスポートし、フォント、テキスト、画像、ID、イベントをAspose.Slidesで制御します。"
---
## **概要**

SVG は、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動後処理に適した、拡張性のある XML ベースの画像フォーマットです。Aspose.Slides for C++ は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブに使用できる必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) を使用します。

## **スライドを SVG としてエクスポートする**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を作成し、スライドを選択してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) を使用します。スライドビューアや Web ページが特定の形状だけを必要とする場合は、[IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG 出力の設定**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) はレンダリング領域にテキストフレームを含め、[SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) はフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) を `true` に設定します。

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

## **矢じりでの線端クロッピングの制御**

SVG 1.1 には、矢じりの下でラインを停止させる位置を指定するマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされた線を短くし、ストロークがマーカーを突き抜けないようにします。[SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) を `true` に設定すると、ストロークが元の終点まで描画されます。この設定は SVG 出力のみに影響し、スライド上の線の位置と長さは保持されます。

例では、2 ポイントと 10 ポイントの幅の線に三角形とダイヤモンドの矢じりを描画します。同じスライドを 2 回エクスポートし、クロッピングオプションだけを変更しています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

比較では、10 ポイントの線上の三角形矢じりが示されています。クロッピングを有効にすると、先端が鋭くなります。無効にすると、ストロークがマーカーの斜め側面を突き抜け、平坦な端になります。

![クロッピング有効時に鋭い先端、無効時に平坦な端を持つ拡大された 10 ポイントの三角形](line-end-cropping.png)

例の他の線では、2 ポイントの三角形では突き抜けたストロークが目立ちにくくなります。塗りつぶされたダイヤモンドは、両方の幅でストロークの端を覆います。

## **テキストとフォントの制御**

スライドを SVG にエクスポートする際、テキストをテキストとして保持するかベクターグラフィックに変換するか、外部フォントをどのように含めるか参照するかを制御できます。以下のオプションは、エクスポートされた SVG のビジュアル一貫性、テキスト選択、およびフォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクトル化**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) を `true` に設定すると、すべてのスライドテキストがベクターグラフィックとして書き込まれます。これによりフォント依存性がなくなり、ブラウザ間でビジュアルの一貫性が向上しますが、テキストは SVG テキストとして選択や検索ができなくなります。

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

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) は、外部からロードされたフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) の値を使用します。別個のフォントファイルへのリンクを参照するには `AddLinksToFontFiles`、SVG にフォントデータを埋め込むには `Embed`、外部フォントを使用するテキストだけをグラフィックとして描画するには `Vectorize` を選択してください。フォントを埋め込む前に、ライセンスを確認してください。

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

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) でクロップされた元領域を除外し、[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

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

## **メタファイルラスタライズ解像度の制御**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) は、SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF や WMF 画像をラスタライズする際に、詳細度とファイルサイズのバランスを取るために使用します。これは SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトをラスタ画像に変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このファイルには、間隔の狭い対角線を持つ EMF 画像が含まれています。以下の例は、[ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) を使用して最初のスライドを 3 つのラスタライズ解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できるようにしています。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

出力では、EMF が各 SVG に埋め込まれた PNG に変換されます。以下の測定値は提供されたプレゼンテーションに対するものであり、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、拡大表示サイズを同一にした埋め込みラスタの同じ領域を示しています。対角線は 72 DPI でピクセル化が目立ち、解像度が上がるとエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げても必ずしもすべてのディテールが向上したり、すべてのエクスポート画像が変わるわけではありません。

![72、150、300 DPI で拡大された対角線ディテール](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) は画像解像度の低減を制御し、メタファイルのラスタライズ解像度変更の影響を隠すことがあります。[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) は JPEG エンコード品質を制御し、メタファイルのラスタライズ解像度を制御するものではありません。

## **シェイプとテキストに安定した ID を割り当てる**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) を使用して、各 SVG シェイプに対して [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) を設定します。テキストの `tspan` 要素にも [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) を設定するには、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) を実装します。いずれかのコントローラは [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) で割り当てます。

以下のコントローラは、シェイプの存続期間中安定した [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) と、テキストスパン用の再現可能なカウンタを使用します。これにより、生成された ID は変更されていないプレゼンテーションの事後処理に適したものになります。

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 内で、[ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) の値を渡すことで、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) で割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義してください。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティの向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) を [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべき場合はいつですか？**

すべてのテキストをフォントに依存しないようにしたい場合は、[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は、[SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) を使用します。

**SVG を小さくする最良の方法は何ですか？**

まず、埋め込み画像を圧縮し、クロップされた画像領域を削除し、対象環境で提供可能な場合はリンクされたフォントファイルを選択してください。画像解像度の低下、JPEG 品質の低下、ベクトル化テキストはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコントローラで ID を割り当てた後、事後処理ツールやブラウザスクリプトで該当する SVG 要素を選択できます。