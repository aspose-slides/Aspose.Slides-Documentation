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
description: "Aspose.Slides for C++ を使用して、PowerPointプレゼンテーション（PPT、PPTX）を簡単にアニメーションGIFに変換します。高速で高品質な結果を実現します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このC++サンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


アニメーションGIFはデフォルトパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このC++サンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 生成された GIF のサイズ 
gifOptions->set_FrameSize(Size(960, 720));
// 各スライドが次へ切り替わるまでの表示時間
gifOptions->set_DefaultDelay(2000);
// トランジションアニメーションの品質向上のため FPS を増やす
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバーターをご確認いただけます。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[configure fallback fonts](/slides/ja/cpp/powerpoint-fonts/) を構成してください。Aspose.Slides は代替フォントで置き換えますが、外観が異なる場合があります。ブランドの一貫性を保つために、必要な書体が明示的に利用可能であることを常に確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。[Add a semi-transparent object/logo](/slides/ja/cpp/watermark/) をマスタースライドまたは個々のスライドにエクスポート前に追加すれば、透かしがすべてのフレームに表示されます。