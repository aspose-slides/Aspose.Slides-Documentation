---
title: PythonでプレゼンテーションをアニメーションGIFに変換する
linktitle: プレゼンテーションからGIFへ
type: docs
weight: 65
url: /ja/python-net/convert-powerpoint-to-animated-gif/
keywords:
- アニメーションGIF
- PowerPoint変換
- OpenDocument変換
- プレゼンテーション変換
- スライド変換
- PPT変換
- PPTX変換
- ODP変換
- PowerPointからGIFへ
- OpenDocumentからGIFへ
- プレゼンテーションからGIFへ
- スライドからGIFへ
- PPTからGIFへ
- PPTXからGIFへ
- ODPからGIFへ
- デフォルト設定
- カスタム設定
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint プレゼンテーション（PPT、PPTX）や OpenDocument ファイル（ODP）を簡単にアニメーションGIFに変換します。高速で高品質な結果を実現します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このPythonサンプルコードは、標準設定でプレゼンテーションをアニメーションGIFに変換する方法を示しています。
```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```


アニメーションGIFはデフォルトのパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIF のパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/)クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、Python でカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 結果として得られる GIF のサイズ
options.default_delay = 2000 # 各スライドが次のスライドに切り替わるまでの表示時間
options.transition_fps = 35  # トランジションアニメーションの品質向上のために FPS を上げる

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```


{{% alert title="Info" color="info" %}}
Aspose が開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターをご利用いただけます。 
{{% /alert %}}

## **よくある質問**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/python-net/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、見た目が異なる場合があります。ブランディングのためには、必要なフォントが確実に利用可能であることを常に確認してください。

**GIF フレームにウォーターマークを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/python-net/watermark/)を追加すると、ウォーターマークがすべてのフレームに表示されます。