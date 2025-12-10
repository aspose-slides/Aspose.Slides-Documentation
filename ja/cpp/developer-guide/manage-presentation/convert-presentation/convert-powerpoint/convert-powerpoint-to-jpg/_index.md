---
title: C++でPPTおよびPPTXをJPGに変換
linktitle: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- PowerPoint を JPG として保存
- プレゼンテーションを JPG として保存
- スライドを JPG として保存
- PPT を JPG として保存
- PPTX を JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides を使用し、迅速で信頼性の高いコード例で、C++ で PowerPoint (PPT、PPTX) スライドを高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for C++ を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成することが簡単になります。これにより、スライドのコピー防止や読み取り専用モードでのプレゼンテーションのデモなどに役立ちます。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

1. [プレゼンテーション](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションのスライドコレクションから [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) タイプのスライドオブジェクトを取得します。
1. [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) メソッドを使用して、スライドの画像を作成します。
1. 画像オブジェクトに対して [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="primary" %}} 

**注:** PPT、PPTX、ODP を JPG に変換する方法は、Aspose.Slides for C++ API における他の形式への変換とは異なります。通常、他の形式には [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) メソッドを使用します。ただし、JPG 変換の場合は [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) メソッドを使用する必要があります。

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 指定したスケールでスライド画像を作成します。
    auto image = slide->GetImage(scaleX, scaleY);

    // 画像を JPEG 形式でディスクに保存します。
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **カスタマイズされたサイズでスライドを JPG に変換する**

結果の JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) メソッドにサイズを渡して画像サイズを指定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、Web アプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 指定したサイズでスライド画像を作成します。
    auto image = slide->GetImage(imageSize);

    // 画像を JPEG 形式でディスクに保存します。
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **スライドを画像として保存するときにコメントを描画する**

Aspose.Slides for C++ は、プレゼンテーションのスライドを JPG 画像に変換する際にコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーションファイルを開くことなくフィードバックを確認・共有しやすくなります。

例として、コメントを含むスライドがあるプレゼンテーションファイル「sample.pptx」を考えてみます：

![コメント付きスライド](slide_with_comments.png)

次の C++ コードは、コメントを保持したままスライドを JPG 画像に変換します：

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


結果：

![コメント付き JPG 画像](image_with_comments.png)

## **関連項目**

PPT、PPTX、ODP を画像に変換する他のオプションとして、以下をご覧ください：

- [PowerPoint を GIF に変換](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、以下の無料オンラインコンバータを試してください: PowerPoint [PPTX を JPG に変換](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT を JPG に変換](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}}

![無料オンライン PPTX to JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。  

この記事で説明した原理を使用すれば、画像を別の形式に変換できます。詳細は以下のページをご参照ください: [画像を JPG に変換](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); [JPG を画像に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); [JPG を PNG に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/); [PNG を JPG に変換](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); [PNG を SVG に変換](https://products.aspose.com/slides/cpp/conversion/png-to-svg/); [SVG を PNG に変換](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一の操作で