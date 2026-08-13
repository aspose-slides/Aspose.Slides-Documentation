---
title: C++ で PPT と PPTX を JPG に変換
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
description: "Aspose.Slides を使用し、速く信頼性の高いコード例で C++ において PowerPoint (PPT、PPTX) スライドを高品質な JPG 画像に変換します。"
---
## **Introduction**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for C++ を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりすることが簡単になります。スライドのコピーから保護したい場合や、読み取り専用モードでプレゼンテーションをデモンストレーションしたい場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **Convert Presentation Slides to JPG Images**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションのスライドコレクションから [ISlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) 型のスライドオブジェクトを取得します。
1. [ISlide.GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) メソッドを使用してスライドの画像を作成します。
1. 画像オブジェクトで [IImage.Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/save/) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="info" %}} 
**Note:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides for C++ API における他の形式への変換とは異なります。他の形式では通常、[IPresentation.Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) メソッドを使用します。ただし、JPG 変換の場合は、[IImage.Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/save/) メソッドを使用する必要があります。
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

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

## **Convert Slides to JPG with Customized Dimensions**

生成される JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値を持つ画像を生成でき、解像度やアスペクト比に対する要件を満たす出力が得られます。この柔軟性は、Web アプリケーション、レポート、ドキュメント用に画像を生成する際に、正確な画像サイズが必要な場合に特に有用です。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

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

## **Render Comments When Saving Slides as Images**

Aspose.Slides for C++ は、プレゼンテーションのスライドを JPG 画像に変換する際にコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示されるため、元のプレゼンテーションファイルを開くことなくフィードバックの確認や共有が容易になります。

例として、コメントを含むスライドがあるプレゼンテーション ファイル「sample.pptx」があるとします：

![コメント付きスライド](slide_with_comments.png)

以下の C++ コードは、スライドをコメントを保持したまま JPG 画像に変換します：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
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

## **See Also**

PPT、PPTX、または ODP を画像に変換する他のオプションとして、次のものがあります：

- [Convert PowerPoint to GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/ja/cpp/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/ja/cpp/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、以下の無料オンラインコンバータを試してください：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ja/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/ja/conversion/ppt-to-jpg)。 
{{% /alert %}}

![無料オンライン PPTX から JPG へのコンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose は、[FREE Collage web app](https://products.aspose.app/slides/ja/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/ja/collage/jpg) や PNG to PNG 画像を結合したり、[photo grids](https://products.aspose.app/slides/ja/collage/photo-grid) を作成したりすることができます。

本記事で説明したのと同じ原理を使って、画像を別の形式に変換できます。詳細については、次のページをご覧ください：convert [image to JPG](https://products.aspose.com/slides/ja/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **FAQ**

### この方法はバッチ変換をサポートしていますか？

はい、Aspose.Slides は�数のスライドを単一の操作で JPG にバッチ変換できます。

### 変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどを含むすべてのコンテンツをレンダリングします。ただし、カスタムフォントや不足しているフォントを使用した場合、PowerPoint と比較して若干精度が異なることがあります。

### 処理できるスライド数に制限はありますか？

Aspose.Slides 自体は処理できるスライド数に厳密な制限を課していません。ただし、大規模なプレゼンテーションや高解像度画像を扱う場合、メモリ不足エラーが発生する可能性があります。