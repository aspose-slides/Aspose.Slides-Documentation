---
title: C++でプレゼンテーションスライドを画像に変換
linktitle: スライドを画像に
type: docs
weight: 41
url: /ja/cpp/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
- スライドを画像として保存
- スライドをPNGに変換
- スライドをJPEGに変換
- スライドをビットマップに変換
- スライドをTIFFに変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、PPT、PPTX、ODP のスライドを C++ で画像に変換します — 高速で高品質なレンダリングと分かりやすいコード例を提供します。"
---

## **概要**

Aspose.Slides for C++ を使用すると、PowerPoint および OpenDocument のプレゼンテーションスライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像フォーマットに簡単に変換できます。

スライドを画像に変換する手順は次のとおりです：

1. 目的の変換設定を定義し、エクスポートするスライドを次のいずれかで選択します：
    - [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) インターフェイス。
2. [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) メソッドを呼び出してスライド画像を生成します。

[Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) は、ピクセルデータで定義された画像を操作できるオブジェクトです。このクラスのインスタンスを使用して、画像を BMP、JPG、PNG などの幅広い形式で保存できます。

## **スライドをビットマップに変換し、PNG で画像を保存する**

スライドをビットマップオブジェクトに変換してそのままアプリケーションで使用できます。または、ビットマップに変換した後で JPEG や他の任意の形式で画像を保存できます。

次の C++ コードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、PNG 形式で保存する方法を示しています：
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーション内の最初のスライドをビットマップに変換します。
auto image = presentation->get_Slide(0)->GetImage();

// 画像を PNG 形式で保存します。
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```


## **カスタムサイズでスライドを画像に変換する**

特定のサイズの画像が必要な場合があります。[GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードはその手順を示しています：
```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーション内の最初のスライドを、指定したサイズのビットマップに変換します。
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 画像を JPEG 形式で保存します。
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```


## **ノートとコメントを含むスライドを画像に変換する**

スライドにはノートやコメントが含まれていることがあります。

Aspose.Slides は [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) と [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) の 2 つのインターフェイスを提供し、スライドを画像にレンダリングする際の制御が可能です。両インターフェイスには `set_SlidesLayoutOptions` メソッドがあり、変換時にノートやコメントのレンダリングを設定できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用すると、生成される画像内でノートとコメントの位置を好きな場所に指定できます。

次の C++ コードは、ノートとコメントを含むスライドを変換する方法を示しています：
```cpp 
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーションファイルを読み込む。
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // ノートの位置を設定する。
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // コメントの位置を設定する。
notesCommentsOptions->set_CommentsAreaWidth(500);                          // コメント領域の幅を設定する。
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // コメント領域の色を設定する。

// レンダリングオプションを作成する。
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// プレゼンテーションの最初のスライドを画像に変換する。
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// 画像を GIF 形式で保存する。
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```


{{% alert title="Note" color="warning" %}} 

スライドから画像への変換プロセス全体で、[set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) メソッドは `BottomFull` を適用できません。ノートのテキストが大きすぎて、指定した画像サイズに収まらない場合があるためです。

{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) インターフェイスは、サイズ、解像度、カラーパレットなどのパラメータを指定できるため、生成される TIFF 画像をより細かく制御できます。

次の C++ コードは、TIFF オプションを使用して 300 DPI の解像度で白黒画像（サイズ 2160 × 2800）を出力する変換プロセスを示しています：
```cpp 
// プレゼンテーションファイルを読み込む。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// プレゼンテーションから最初のスライドを取得。
auto slide = presentation->get_Slide(0);

// 出力TIFF画像の設定を構成する。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 画像サイズを設定する。
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // ピクセル形式（白黒）を設定する。
tiffOptions->set_DpiX(300);                                         // 水平解像度を設定する。
tiffOptions->set_DpiY(300);                                         // 垂直解像度を設定する。

// 指定したオプションでスライドを画像に変換する。
auto image = slide->GetImage(tiffOptions);

// 画像をTIFF形式で保存する。
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```


## **すべてのスライドを画像に変換する**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を画像のシリーズに変換できます。

次のサンプルコードは、C++ でプレゼンテーションのすべてのスライドを画像に変換する方法を示しています：
```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーションをスライドごとに画像にレンダリングします。
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


## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`GetImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィックエフェクトのレンダリングをサポートしています。