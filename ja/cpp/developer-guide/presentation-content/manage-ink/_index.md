---
title: C++ でプレゼンテーションのインクオブジェクトを管理する
linktitle: インクを管理する
type: docs
weight: 95
url: /ja/cpp/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- インクのエクスポート
- インクのレンダリング
- インクを非表示
- IInkOptions
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint のインクオブジェクトを管理し、トレースとブラシプロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインクの表示を制御します。"
---
## **はじめに**

PowerPoint は、フリーハンドのストロークを描くことができるインク機能を提供しています。インクは、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/) 名前空間には、インクオブジェクトを操作するために必要なクラスとインターフェイスが含まれています。たとえば、[IInk](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iink/) インターフェイスはスライド上のインクオブジェクトを表します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint のスライド上のオブジェクトは通常、シェイプオブジェクトで表されます。最も単純な形では、シェイプはオブジェクト自体の領域（フレーム）を定義するコンテナであり、コンテナのサイズ、形状、背景などのプロパティを持ちます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/ja/cpp/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインクオブジェクトを処理する場合、サイズ以外のオブジェクトフレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは、標準の [IShape::get_Width](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_width/) および [IShape::get_Height](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_height/) メソッドによって決定されます：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクトレース**

インクトレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素です。トレースは連続したポイントのシーケンスを保持します。

最も単純なエンコード形式は、各サンプルポイントの X および Y 座標を指定します。すべての連続ポイントが描画されると、以下のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシプロパティ**

ブラシはインクトレースのポイントを結ぶ線を描くために使用されます。ブラシは独自の色とサイズを持ち、[IInkBrush::get_Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iinkbrush/get_color/) および [IInkBrush::get_Size](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iinkbrush/get_size/) メソッドで表されます。

### **インクブラシの色を設定**

この C++ コードは、インクブラシの色を設定する方法を示しています：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **インクブラシのサイズを設定**

この C++ コードは、インクブラシのサイズを設定する方法を示しています：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

一般に、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（対応するデータ セクションは灰色表示になります）。ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やして重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると想定します（前の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレース）がコンテナ（フレーム）のサイズに合わせてスケーリングされています。コンテナのサイズが変わると、ブラシサイズは一定に保たれ、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストオブジェクトでも同様の動作を使用します：

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク表示の制御**

Aspose.Slides は、エクスポートまたはレンダリングされた出力でインクオブジェクトの表示方法を制御するための [IInkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/) インターフェイスを提供します。このメソッドを使用してインクを完全に非表示にしたり、インクブラシのマスク操作の解釈方法を変更したりできます。

Ink options are available through the export or rendering options for several output types:

| 出力 | インクオプション メソッド |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

これらのメソッドでは、同じ 2 つの設定が利用できます：

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_hideink/) はインクオブジェクトを出力に含めるかどうかを決定します。そのデフォルト値は `false` です。
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) は、インクブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。そのデフォルト値は `true` です。`false` に設定すると代わりに ROP 操作が使用されます。

### **PDF 出力でインクオブジェクトを非表示にする**

デフォルトでは、エクスポート時にインクオブジェクトは表示されたままです。手書き注釈やその他のインクコンテンツを含まないクリーンな出力が必要な場合は、`true` を指定して [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_hideink/) を呼び出します。

以下の C++ の例は、すべてのインクオブジェクトを非表示にしてプレゼンテーションを PDF にエクスポートします：

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **スライドを画像としてレンダリングする際にインクオブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際にインクオブジェクトを非表示にするには、[RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) を設定し、そのレンダリングオプションを [ISlide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) メソッドに渡します。

以下の C++ の例は、インクオブジェクトを除いて最初のスライドを PNG 画像としてレンダリングします：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **インクマスクのレンダリング制御**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) メソッドは、インクブラシをレンダリングする際にマスク操作がどのように解釈されるかを制御します。デフォルト値は `true` で、不透明度として扱われます。`false` を指定して呼び出すと、代わりに ROP 操作が使用されます。

以下の C++ の例は、スライドを SVG にエクスポートし、インクマスク操作に ROP ベースのレンダリングを使用します：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

同じ設定は、プレゼンテーションをエクスポートする場合やスライドを TIFF にレンダリングする場合に、[TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) を使用して適用できます。

### **インクを非表示にするか保持するか選択**

注釈付きプレゼンテーションのクリーンなバージョン（例: レビューコメントなしで配布する最終版）としてエクスポートファイルが必要な場合は、`true` を指定して [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_hideink/) を使用します。

インク注釈が意図されたコンテンツの一部である場合（レビューコメント、手書きメモ、ハイライト、またはエクスポート結果に残すべき描画など）、インクを表示したままにしてください（デフォルトは `false` 設定）。これにより、アプリケーションは同じプレゼンテーションからソースのインクオブジェクトを変更せずに、レビュー用と最終用の別々の出力を生成できます。

## **よくある質問**

**既存のインクストロークの色やサイズを変更できますか？**

はい。まず [IInk::get_Traces](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iink/get_traces/) からトレースを取得し、[IInkTrace::get_Brush](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iinktrace/get_brush/) を変更します。ブラシに対して [IInkBrush::set_Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iinkbrush/set_color/) と [IInkBrush::set_Size](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ink/iinkbrush/set_size/) を呼び出すことができます。

**インクを非表示にしても元のプレゼンテーションは変更されますか？**

いいえ。[IInkOptions::set_HideInk](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/iinkoptions/set_hideink/) はレンダリングまたはエクスポートされた結果にのみ影響し、元のプレゼンテーション内のインクオブジェクトを削除したり変更したりしません。

**どのエクスポート形式がインクオプションに対応していますか？**

上記の対応するエクスポートまたはレンダリングオプションを使用して、PDF、HTML、SVG、TIFF、ビットマップ形式のスライド画像のインクオプションを設定できます。

## **さらに読む**

* 全体的なシェイプについては、[PowerPoint Shapes](https://docs.aspose.com/slides/ja/cpp/powerpoint-shapes/) セクションをご覧ください。
* 有効な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/ja/cpp/shape-effective-properties/#get-effective-font-height-value) を参照してください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/cpp/convert-powerpoint-to-pdf/) をご覧ください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/cpp/convert-powerpoint-to-html/) をご覧ください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/cpp/render-a-slide-as-an-svg-image/) をご覧ください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/cpp/convert-powerpoint-to-tiff/) をご覧ください。
* スライドを画像にレンダリングする詳細は、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/cpp/convert-slide/) をご覧ください。