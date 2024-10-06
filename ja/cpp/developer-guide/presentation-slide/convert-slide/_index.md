---
title: スライドの変換
type: docs
weight: 41
url: /ja/cpp/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドから画像へ
- スライドをPNGに
- スライドをJPEGに
- スライドをビットマップに
- C++
- Aspose.Slides for C++
description: "C++におけるPowerPointスライドを画像（ビットマップ、PNG、またはJPG）に変換"
---

Aspose.Slides for C++を使用すると、スライド（プレゼンテーション内）を画像に変換できます。サポートされている画像フォーマットは次のとおりです：BMP、PNG、JPG（JPEG）、GIFなど。

スライドを画像に変換するには、次のようにします：

1. 最初に、変換パラメーターと変換するスライドオブジェクトを設定します：
   * [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options)インターフェイスを使用するか
   * [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)インターフェイスを使用します。

2. 次に、[GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)メソッドを使用してスライドを画像に変換します。

## **ビットマップおよびその他の画像フォーマットについて**

[ビットマップ](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap)は、ピクセルデータによって定義された画像を操作するためのオブジェクトです。このクラスのインスタンスを使用して、さまざまなフォーマット（BMP、JPG、PNGなど）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Asposeは最近、オンラインで[テキストをGIF](https://products.aspose.app/slides/text-to-gif)に変換するツールを開発しました。

{{% /alert %}}

## **スライドをビットマップに変換し、PNG形式で画像を保存**

このC++コードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、次に画像をPNG形式で保存する方法を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// 画像をPNG形式で保存
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="ヒント" color="primary" %}} 

スライドをビットマップオブジェクトに変換して、そのオブジェクトをどこかで直接使用することもできます。または、スライドをビットマップに変換して画像をJPEGまたは他の好みのフォーマットで保存することもできます。

{{% /alert %}}  

## **カスタムサイズの画像にスライドを変換**

特定のサイズの画像を取得する必要があるかもしれません。[GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)のオーバーロードを使用して、特定の寸法（長さと幅）を持つ画像にスライドを変換できます。

このサンプルコードは、C++で[GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)メソッドを使用した提案された変換を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// プレゼンテーションの最初のスライドを指定されたサイズのビットマップに変換
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// 画像をJPEG形式で保存
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **ノートとコメント付きのスライドを画像に変換**

いくつかのスライドにはノートやコメントが含まれています。

Aspose.Slidesは、プレゼンテーションのスライドを画像に変換する際のレンダリングを制御できる2つのインターフェイス—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options)と[IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)を提供します。両方のインターフェイスには、スライドを画像に変換するときにノートやコメントを追加することを可能にする[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)インターフェイスが含まれています。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)インターフェイスを使用すると、結果の画像におけるノートとコメントの希望する位置を指定できます。

{{% /alert %}} 

このC++コードは、ノートとコメント付きのスライドの変換プロセスを示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// レンダリングオプションを作成
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// ページ上のノートの位置を設定
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// ページ上のコメントの位置を設定 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// コメント出力領域の幅を設定
notesCommentsLayouting->set_CommentsAreaWidth(500);
// コメント領域の色を設定
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// 画像をGIF形式で保存
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="注意" color="warning" %}} 

スライドを画像に変換するプロセスにおいて、[set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)メソッドにBottomFull値を渡すことはできません。なぜなら、ノートのテキストが大きい場合、指定された画像サイズに収まらない可能性があるからです。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換**

[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options)インターフェイスは、結果の画像に対するパラメータ的な制御をさらに提供します。このインターフェイスを使用すると、結果の画像のサイズ、解像度、カラーパレット、その他のパラメータを指定できます。

このC++コードは、ITiffOptionsを使用して300dpi解像度および2160 × 2800サイズの白黒画像を出力する変換プロセスを示しています：

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// インデックスでスライドを取得
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// TiffOptionsオブジェクトを作成
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// ソースフォントが見つからない場合に使用されるフォントを設定
options->set_DefaultRegularFont(u"Arial Black");

// ページ上のノートの位置を設定 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// ピクセルフォーマットを設定（白黒）
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// 解像度を設定
options->set_DpiX(300);
options->set_DpiY(300);

// スライドをビットマップオブジェクトに変換
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// 画像をBMP形式で保存
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **すべてのスライドを画像に変換**

Aspose.Slidesを使用すると、単一のプレゼンテーション内のすべてのスライドを画像に変換できます。基本的に、プレゼンテーション全体を画像に変換することができます。

このサンプルコードは、C++でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

``` cpp 
// 出力ディレクトリへのパス
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// プレゼンテーションをスライドごとに画像にレンダリング
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // 隠れたスライドを制御（隠れたスライドはレンダリングしない）
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // スライドをビットマップオブジェクトに変換
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // 画像のファイル名を作成
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // 画像をPNG形式で保存
    image->Save(outputFilePath, ImageFormat::Png);
}
```