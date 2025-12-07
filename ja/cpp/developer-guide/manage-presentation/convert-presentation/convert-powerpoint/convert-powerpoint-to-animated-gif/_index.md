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
- PowerPointからGIFへ
- プレゼンテーションからGIFへ
- スライドからGIFへ
- PPTからGIFへ
- PPTXからGIFへ
- PPTをGIFとして保存
- PPTXをGIFとして保存
- PPTをGIFとしてエクスポート
- PPTXをGIFとしてエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション（PPT、PPTX）を簡単にアニメーションGIFに変換できます。高速で高品質な結果を提供します。"
---

## **デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換**

このC++サンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


アニメーションGIFはデフォルトのパラメータで作成されます。 

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options)クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換**

このサンプルコードは、C++でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 生成された GIF のサイズ 
gifOptions->set_FrameSize(Size(960, 720));
// 各スライドが次に切り替わるまでの表示時間 
gifOptions->set_DefaultDelay(2000);
// 遷移アニメーションの品質向上のために FPS を増やす 
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをご確認ください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[configure fallback fonts](/slides/ja/cpp/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、外観が異なる場合があります。ブランド向けには、必要な書体が確実に利用できるようにしてください。

**GIF フレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[Add a semi-transparent object/logo](/slides/ja/cpp/watermark/)を追加すると、透かしがすべてのフレームに表示されます。