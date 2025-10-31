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
description: "Aspose.Slides for Python を使用して、PowerPoint プレゼンテーション (PPT, PPTX) と OpenDocument ファイル (ODP) を簡単にアニメーション GIF に変換します。高速で高品質な結果を提供します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換**

このPythonサンプルコードは、標準設定でプレゼンテーションをアニメーションGIFに変換する方法を示しています。

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

アニメーションGIFはデフォルトパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/)クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換**

このサンプルコードは、Pythonでカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています。

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 生成されたGIFのサイズ  
options.default_delay = 2000 # 各スライドが次に切り替わるまでの表示時間
options.transition_fps = 35  # トランジションアニメーションの品質向上のためFPSを増加

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをご覧ください。 
{{% /alert %}}

## **よくある質問**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/python-net/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、外観が異なる場合があります。ブランドの一貫性を保つため、必要な書体は必ず明示的に用意してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/python-net/watermark/)を追加すれば、透かしがすべてのフレームに表示されます。