---
title: PowerPointをアニメーションGIFに変換
type: docs
weight: 65
url: /python-net/convert-powerpoint-to-animated-gif/
keywords: "PowerPointを変換, PPT, PPTX, アニメーションGIF, PPTをアニメーションGIFに, PPTXをアニメーションGIFに, Python, デフォルト設定, カスタム設定"
description: "PowerPointプレゼンテーションをアニメーションGIFに変換: PPTをGIFに, PPTXをGIFにPythonで"
---

## デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##

このPythonのサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

アニメーションGIFはデフォルトのパラメータで作成されます。 

{{%  alert  title="ヒント"  color="primary"  %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/)クラスを使用できます。以下のサンプルコードを参照してください。 

{{% /alert %}} 

## カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##
このサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法をPythonで示しています:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 結果のGIFのサイズ  
options.default_delay = 2000 # 各スライドが次に変更されるまでの表示時間
options.transition_fps = 35  # トランジションアニメーションの品質を向上させるためにFPSを増加

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="情報" color="info" %}}

Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをチェックしてみてください。 

{{% /alert %}}