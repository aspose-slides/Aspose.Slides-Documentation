---
title: C++ でプレゼンテーション スライドを画像に変換する
linktitle: スライドから画像へ
type: docs
weight: 41
url: /ja/cpp/convert-slide/
keywords:
- スライド変換
- スライドエクスポート
- スライドから画像へ
- スライドを画像として保存
- スライドから EMF へ
- スライドから PNG へ
- スライドから JPEG へ
- スライドからビットマップへ
- スライドから TIFF へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PPT、PPTX、ODP プレゼンテーションのスライドを PNG、JPEG、GIF、TIFF、EMF などの画像形式に C++ で変換します。"
---
## **はじめに**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF などの画像形式でレンダリングできます。

スライドを画像に変換する手順は次のとおりです。

1. プレゼンテーションを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスで読み込みます。
2. レンダリングするスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) クラスでレンダリング設定を構成します。
4. [ISlide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) メソッドを呼び出します。これは [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトを返します。
5. [IImage::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/save/) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/) の値で出力形式を指定します。

## **スライドを PNG 画像に変換する**

最もシンプルな変換はデフォルトのレンダリング設定を使用します。生成された [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトはメモリ内で処理したり、ファイルに保存したりできます。

次の C++ サンプルは最初のスライドをレンダリングし、PNG 画像として保存します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **カスタムサイズでスライドを画像に変換する**

正確なピクセル寸法でスライドをレンダリングするには、[Size](https://reference.aspose.com/slides/ja/cpp/system.drawing/size/) 値を受け取るオーバーロードの [ISlide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) を使用します。

次の例は 1820 × 1040 の JPEG 画像を作成します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **ノートとコメントを含むスライドを画像に変換する**

デフォルトでは、スライド画像にノートやコメントは含まれません。[RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) メソッドに [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを設定して、ノートとコメントの表示位置を制御します。

次の例は、スライド下に切り詰めたノートを、右側にコメントを配置します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) メソッドを [BottomFull](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notespositions/) に設定しないでください。ノートは固定画像サイズに収まらないほど長くなることがあります。代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

次の例は、最初のスライドを 2160 × 2880、300 DPI の TIFF 画像としてレンダリングします。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **すべてのスライドを画像に変換する**

スライドコレクションを反復処理して、プレゼンテーション全体を画像の連続に変換します。非表示スライドも、明示的に除外しない限り含まれます。

次の例は、すべてのスライドを水平・垂直スケール係数 2 の JPEG 画像としてレンダリングします。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **拡張メタファイル出力を作成する**

拡張メタファイル (EMF) は、Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとベクター グラフィックを交換する必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はベクター描画操作を保持でき、拡大縮小しても鋭さが失われません。ただし、EMF は主に Windows メタファイル対応アプリケーション向けの互換形式であり、汎用の交換フォーマットではありません。また、ビットマップ画像や一部のエフェクトなどの複雑なスライド コンテンツは、ベクターメタファイル内にラスタライズされた要素として格納されることがあります。

### **スライドを EMF にエクスポートする**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/writeasemf/) メソッドは、[ISlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) を EMF 形式で対象ストリームに書き込みます。次の例はプレゼンテーションを読み込み、最初のスライドを EMF ファイルストリームに書き込む方法を示します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

呼び出し側は [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/writeasemf/) に渡すストリームの所有権を持ち、ストリームを閉じるか破棄する必要があります。Aspose.Slides はストリームの現在位置から書き込み、ストリームは開いたままにします。

### **SVG 画像を EMF に変換してプレゼンテーションに追加する**

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/writeasemf/) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) でプレゼンテーションに追加でき、[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addpictureframe/) でスライド上に配置できます。

次の例は SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/svgimage/) を作成し、メモリ内の EMF に変換し、最初のスライドにメタファイルを挿入してプレゼンテーションを保存します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/writeasemf/) は宛先ストリームの所有権を取得しません。書き込み後、ストリーム位置は生成データの末尾にあります。例では [MemoryStream::ToArray](https://reference.aspose.com/slides/ja/cpp/system.io/memorystream/toarray/) を呼び出して現在位置に関係なく完全なバッファを取得し、そのバイト配列を [IImageCollection::AddImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/addimage/) に渡しています。ストリームはコンシューマが読み取り終えるまで開いたままにし、その後閉じてください。

EMF の生成は Aspose.Slides for C++ がサポートするオペレーティング システムで利用可能ですが、フォントやネイティブ グラフィック依存関係が利用できない場合、プラットフォーム間でレンダリングが異なることがあります。ソース コンテンツで使用されているフォントをインストールするか、適切な代替フォントを構成し、Aspose.Slides for C++ の [プラットフォーム要件](/slides/ja/cpp/system-requirements/) に従って、ターゲットの EMF 消費アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示や編集に対してサポートが限定的または一貫性がないことがあります。

## **カラ―絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーション スライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされている必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用しているがフォントがない場合、出力画像では絵文字がモノクロで表示されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[ISlide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) メソッドはスライドの静止画像をレンダリングし、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドは通常のスライドと同様にレンダリングできます。上記のサンプルのように処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides はスライド画像に影、透明度、その他サポートされているグラフィック効果をレンダリングします。