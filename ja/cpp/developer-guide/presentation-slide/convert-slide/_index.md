---
title: C++ でプレゼンテーション スライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 41
url: /ja/cpp/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
- スライドを画像として保存
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PPT、PPTX、ODP のスライドを画像に変換します—高速で高品質なレンダリングと分かりやすいコード例を提供します。"
---
## **Introduction**

Aspose.Slides for C++ を使用すると、PowerPoint および OpenDocument のプレゼンテーション スライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換する手順は次のとおりです。

1. 目的の変換設定を定義し、エクスポートするスライドを選択します。以下のいずれかのインターフェイスを使用します。  
   - [ITiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/itiffoptions/) インターフェイス、または  
   - [IRenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/irenderingoptions/) インターフェイス。  
2. [GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) メソッドを呼び出してスライド画像を生成します。

[Bitmap](https://reference.aspose.com/slides/ja/cpp/system.drawing/bitmap/) は、ピクセル データで定義された画像を操作できるオブジェクトです。このクラスのインスタンスを使用して、BMP、JPG、PNG などの幅広い形式で画像を保存できます。

## **Convert Slides to Bitmaps and Save the Images in PNG**

スライドを Bitmap オブジェクトに変換してそのままアプリケーションで使用できます。または、スライドを Bitmap に変換した後、JPEG など任意の形式で画像を保存できます。

以下の C++ コードは、プレゼンテーションの最初のスライドを Bitmap オブジェクトに変換し、PNG 形式で保存する方法を示しています。

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーションの最初のスライドをビットマップに変換します。
auto image = presentation->get_Slide(0)->GetImage();

// 画像を PNG 形式で保存します。
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides to Images with Custom Sizes**

特定のサイズの画像が必要な場合があります。[GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードは、サイズを指定してスライドを画像に変換する方法を示しています。

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 指定したサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 画像を JPEG 形式で保存します。
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides with Notes and Comments to Images**

スライドにはノートやコメントが含まれていることがあります。

Aspose.Slides は、[ITiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/itiffoptions/) と [IRenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/irenderingoptions/) の 2 つのインターフェイスを提供し、プレゼンテーション スライドを画像にレンダリングする方法を制御できます。両インターフェイスには `set_SlidesLayoutOptions` メソッドがあり、スライドを画像に変換するときにノートやコメントのレンダリングを設定できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用すると、生成される画像内でノートとコメントの位置を好きな場所に指定できます。

以下の C++ コードは、ノートとコメントを含むスライドを変換する方法を示しています。

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーション ファイルを読み込みます。
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // ノートの位置を設定します。
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // コメントの位置を設定します。
notesCommentsOptions->set_CommentsAreaWidth(500);                          // コメント領域の幅を設定します。
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // コメント領域の色を設定します。

// レンダリング オプションを作成します。
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// プレゼンテーションの最初のスライドを画像に変換します。
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// 画像を GIF 形式で保存します。
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
スライドから画像への変換処理では、[set_NotesPosition](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) メソッドで `BottomFull` を指定できません。ノートのテキストが大きすぎて、指定した画像サイズ内に収められない可能性があるためです。
{{% /alert %}} 

## **Convert Slides to Images Using TIFF Options**

[ITiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/itiffoptions/) インターフェイスを使用すると、サイズ、解像度、カラーパレットなどのパラメータを指定して、生成される TIFF 画像を細かく制御できます。

以下の C++ コードは、TIFF オプションを使用して 300 DPI の解像度、サイズ 2160 × 2800 の白黒画像を出力する変換プロセスを示しています。

```cpp 
// プレゼンテーション ファイルを読み込みます。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// プレゼンテーションから最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// 出力 TIFF 画像の設定を構成します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 画像サイズを設定します。
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // ピクセル形式を設定します（白黒）。
tiffOptions->set_DpiX(300);                                         // 横方向の解像度を設定します。
tiffOptions->set_DpiY(300);                                         // 縦方向の解像度を設定します。

// 指定したオプションでスライドを画像に変換します。
auto image = slide->GetImage(tiffOptions);

// 画像を TIFF 形式で保存します。
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convert All Slides to Images**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を一連の画像に変換することができます。

以下のサンプルコードは、C++ でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています。

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーションをスライドごとに画像としてレンダリングします。
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // 非表示スライドを制御します（非表示スライドはレンダリングしません）。
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // スライドを画像に変換します。
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // 画像を JPEG 形式で保存します。
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Color Emoji Rendering**

{{% alert title="Note" color="warning" %}} 
プレゼンテーション スライドを画像に変換する際にカラー絵文字を正しく表示するには、変換を実行するシステムにプレゼンテーションで使用されている絵文字フォントがインストールされている必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用していてこのフォントが欠如している場合、出力画像の絵文字はモノクロで表示されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`GetImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィック効果のレンダリングをサポートしています。