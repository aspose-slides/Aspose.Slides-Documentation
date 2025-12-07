---
title: C++でPowerPointプレゼンテーションをアニメーションGIFに変換
linktitle: PowerPointからGIFへ
type: docs
weight: 65
url: /ja/cpp/convert-powerpoint-to-animated-gif/
keywords:
- アニメーションGIF
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをGIFに変換
- プレゼンテーションをGIFに変換
- スライドをGIFに変換
- PPTをGIFに変換
- PPTXをGIFに変換
- PPTをGIFとして保存
- PPTXをGIFとして保存
- PPTをGIFにエクスポート
- PPTXをGIFにエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPointプレゼンテーション（PPT、PPTX）をアニメーションGIFに簡単に変換します。高速で高品質な結果を提供します。"
---

## **デフォルト設定を使用してプレゼンテーションをアニメーションGIFに変換**

このC++のサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


アニメーションGIFはデフォルトパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換**

このサンプルコードは、C++でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します。
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 結果として得られるGIFのサイズ
gifOptions->set_FrameSize(Size(960, 720));
// 各スライドが次のスライドに変わるまでの表示時間
gifOptions->set_DefaultDelay(2000);
// 遷移アニメーションの品質を向上させるためにFPSを増やす
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバーターをチェックしてみてください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/cpp/powerpoint-fonts/)してください。Aspose.Slides は代替しますが、外観が異なる場合があります。ブランディングのため、必ず必要な書体が明示的に利用可能であることを確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/cpp/watermark/)を追加してください。透かしはすべてのフレームに表示されます。