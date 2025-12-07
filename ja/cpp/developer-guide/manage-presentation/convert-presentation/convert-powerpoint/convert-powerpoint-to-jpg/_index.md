---
title: C++でPPTおよびPPTXをJPGに変換
linktitle: PowerPointをJPGに変換
type: docs
weight: 60
url: /ja/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをJPGに変換
- プレゼンテーションをJPGに変換
- スライドをJPGに変換
- PPTをJPGに変換
- PPTXをJPGに変換
- PowerPointをJPGとして保存
- プレゼンテーションをJPGとして保存
- スライドをJPGとして保存
- PPTをJPGとして保存
- PPTXをJPGとして保存
- PPTをJPGにエクスポート
- PPTXをJPGにエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides を使用し、速く信頼性の高いコード例で、C++でPowerPoint（PPT、PPTX）スライドを高品質なJPG画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for C++ を使用すると、PPTX、PPT、および ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成することが簡単になります。スライドのコピーから保護したい場合や、読み取り専用モードでプレゼンテーションをデモしたい場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションのスライドコレクションから [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) タイプのスライドオブジェクトを取得します。
1. [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) メソッドを使用してスライドの画像を作成します。
1. 画像オブジェクトで [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}} 

**注意:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides for C++ API における他の形式への変換とは異なります。他の形式の場合、通常は [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) メソッドを使用します。ただし、JPG 変換の場合は [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) メソッドを使用する必要があります。

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 指定されたスケールでスライド画像を作成します。
    auto image = slide->GetImage(scaleX, scaleY);

    // 画像を JPEG 形式でディスクに保存します。
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **カスタムサイズでスライドを JPG に変換**

生成される JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、ウェブアプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に役立ちます。
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 指定されたサイズでスライド画像を作成します。
    auto image = slide->GetImage(imageSize);

    // 画像を JPEG 形式でディスクに保存します。
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **画像としてスライドを保存する際にコメントをレンダリング**

Aspose.Slides for C++ は、スライドを JPG 画像に変換する際にプレゼンテーションのコメントをレンダリングする機能を提供します。この機能は、PowerPoint プレゼンテーションに共同編集者が追加した注釈、フィードバック、議論を保存するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示されるため、元のプレゼンテーションファイルを開かずにフィードバックを確認・共有できます。

例として、コメントが含まれるスライドを持つプレゼンテーション ファイル「sample.pptx」があるとします:
![コメント付きスライド](slide_with_comments.png)

以下の C++ コードは、コメントを保持したままスライドを JPG 画像に変換します。
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // スライドコメントのオプションを設定します。
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // 最初のスライドを画像に変換します。
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


結果:
![コメント付き JPG 画像](image_with_comments.png)

## **関連項目**

- [PowerPoint を GIF に変換](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、次の無料オンラインコンバータを試してください: PowerPoint [PPTX を JPG に変換](https://products.aspose.app/slides/conversion/pptx-to-jpg) および [PPT を JPG に変換](https://products.aspose.app/slides/conversion/ppt-to-jpg) を試してください。 

{{% /alert %}}

![無料オンライン PPTX から JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は、[無料 Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを利用すると、[JPG を JPG に結合](https://products.aspose.app/slides/collage/jpg) や PNG を PNG に結合、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) の作成などが可能です。

本記事で説明した同じ原則を使用して、画像をある形式から別の形式に変換できます。詳細については、次のページをご覧ください: 画像を [画像を JPG に変換](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) ; JPG を [JPG を画像に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) ; JPG を [JPG を PNG に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/) , PNG を [PNG を JPG に変換](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) ; PNG を [PNG を SVG に変換](https://products.aspose.com/slides/cpp/conversion/png-to-svg/) , SVG を [SVG を PNG に変換](https://products.aspose.com/slides/cpp/conversion/svg-to-png/) 。

{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一操作で複数のスライドを JPG にバッチ変換できます。

**変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタムフォントや欠落フォントを使用した場合、PowerPoint と比較してレンダリング精度が若干異なることがあります。

**処理できるスライド数に制限はありますか？**

Aspose.Slides 自体には処理できるスライド数に厳格な制限はありません。ただし、大規模なプレゼンテーションや高解像度画像を扱う際にメモリ不足エラーが発生する可能性があります。