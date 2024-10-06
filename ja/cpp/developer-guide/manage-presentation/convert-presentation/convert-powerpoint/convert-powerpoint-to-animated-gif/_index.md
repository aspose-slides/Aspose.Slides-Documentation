---
title: PowerPointをアニメーションGIFに変換する
type: docs
weight: 65
url: /ja/cpp/convert-powerpoint-to-animated-gif/
keywords: "PowerPointをアニメーションGIFに変換する, "
description: "PowerPointをアニメーションGIFに変換する: PPTからGIF、PPTXからGIF、Aspose.Slides APIを使用して。"
---

## デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##

このC++のサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

アニメーションGIFはデフォルトのパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 

GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options)クラスを使用できます。以下のサンプルコードを参照してください。

{{% /alert %}} 

## カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##
このサンプルコードは、C++でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 得られたGIFのサイズ 
gifOptions->set_FrameSize(Size(960, 720));
// 各スライドが次のスライドに切り替わるまで表示される時間
gifOptions->set_DefaultDelay(2000);
// アニメーションの遷移品質を向上させるためにFPSを増加させる
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターをチェックすることをお勧めします。 

{{% /alert %}}