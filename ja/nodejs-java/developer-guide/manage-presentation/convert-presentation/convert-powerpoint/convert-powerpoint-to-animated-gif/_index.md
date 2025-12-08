---
title: PowerPoint をアニメーション GIF に変換
type: docs
weight: 65
url: /ja/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint をアニメーション GIF に変換, PPT を GIF に変換, PPTX を GIF に変換"
description: "PowerPoint をアニメーション GIF に変換: PPT を GIF に変換, PPTX を GIF に変換, Aspose.Slides API を使用."
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このJavaScriptサンプルコードは、標準設定でプレゼンテーションをアニメーションGIFに変換する方法を示します：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


アニメーションGIFはデフォルトパラメータで作成されます。 

{{%  alert  title="TIP"  color="primary"  %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions)クラスを使用できます。以下のサンプルコードをご覧ください。

{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、JavaScriptでカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// 生成された GIF のサイズ
    gifOptions.setDefaultDelay(2000);// 各スライドが次のスライドに変わるまでの表示時間
    gifOptions.setTransitionFps(35);// 遷移アニメーションの品質向上のために FPS を上げる
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}

Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをご利用いただけます。 

{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうすればよいですか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/nodejs-java/powerpoint-fonts/)してください。Aspose.Slidesは代替しますが、外観が異なる場合があります。ブランドの一貫性のため、必ず必要な書体が明示的に利用可能であることを確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個別スライドに[半透明のオブジェクト/ロゴ](/slides/ja/nodejs-java/watermark/)を追加すると、透かしがすべてのフレームに表示されます。