---
title: C++ で PowerPoint プレゼンテーションをアニメーション GIF に変換する
linktitle: PowerPoint から GIF へ
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
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション (PPT、PPTX) を簡単にアニメーション GIF に変換できます。高速で高品質な結果を提供します。"
---

## **既定の設定でプレゼンテーションをアニメーションGIFに変換する**

このC++サンプルコードは、標準設定でプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


アニメーションGIFは既定のパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
パラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options)クラスを使用できます。以下のサンプルコードを参照してください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、C++でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 生成された GIF のサイズ 
gifOptions->set_FrameSize(Size(960, 720));
// 各スライドが次のスライドに切り替わるまでの表示時間 
gifOptions->set_DefaultDelay(2000);
// 遷移アニメーションの品質向上のために FPS を上げる 
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Asposeが提供する無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターをチェックしてみてください。 
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォントのフォールバックを構成](/slides/ja/cpp/powerpoint-fonts/)してください。Aspose.Slidesは代替フォントを使用しますが、外観が異なる場合があります。ブランドの一貫性を保つため、必要なフォントは必ず明示的に用意してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/cpp/watermark/)を追加すると、透かしがすべてのフレームに表示されます。