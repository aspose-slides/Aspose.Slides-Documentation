---
title: C++ で PowerPoint プレゼンテーションをアニメーション GIF に変換する
linktitle: PowerPoint を GIF に変換
type: docs
weight: 65
url: /ja/cpp/convert-powerpoint-to-animated-gif/
keywords:
- アニメーション GIF
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を GIF に変換
- プレゼンテーションを GIF に変換
- スライドを GIF に変換
- PPT を GIF に変換
- PPTX を GIF に変換
- PPT を GIF として保存
- PPTX を GIF として保存
- PPT を GIF にエクスポート
- PPTX を GIF にエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション（PPT、PPTX）を簡単にアニメーション GIF に変換します。高速で高品質な結果を実現します。"
---
## **概要**

Aspose.Slides を使用すると、数行のコードだけで PowerPoint プレゼンテーションをアニメーション GIF ファイルに変換できます。これは、スライドの内容を軽量で広くサポートされたアニメーション形式で共有し、ウェブページやメッセンジャー、ドキュメントに埋め込む必要がある場合に便利です。この記事では、デフォルト設定でプレゼンテーションを GIF にエクスポートする方法と、[GifOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/gifoptions/) を使用してフレームサイズ、スライド遅延、遷移フレームレートなどのオプションを構成して出力をカスタマイズする方法を説明します。

## **デフォルト設定でプレゼンテーションをアニメーション GIF に変換する**

この C++ のサンプルコードは、標準設定でプレゼンテーションをアニメーション GIF に変換する方法を示しています:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

アニメーション GIF はデフォルトのパラメーターで作成されます。 

{{%  alert  title="TIP"  color="info"  %}} 
GIF のパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.gif_options) クラスを使用できます。以下のサンプルコードをご確認ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーション GIF に変換する**

このサンプルコードは、C++ でカスタム設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示しています:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// 生成された GIF のサイズ
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// 各スライドが次に切り替わるまでの表示時間
gifOptions->set_DefaultDelay(2000);
// 遷移アニメーションの品質向上のために FPS を増やす
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Aspose が提供する無料の [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバーターをぜひお試しください。 
{{% /alert %}}

## **よくある質問**

### プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうすればよいですか？

不足しているフォントをインストールするか、[フォールバックフォントを設定](/slides/ja/cpp/powerpoint-fonts/)してください。Aspose.Slides は代替フォントで置き換えますが、見た目が異なる場合があります。ブランドの一貫性を保つために、必要な書体が確実に利用可能であることを常に確認してください。

### GIF フレームに透かしを重ねることはできますか？

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/cpp/watermark/)を追加すると、透かしがすべてのフレームに表示されます。