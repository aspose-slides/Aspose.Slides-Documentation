---
title: PowerPointをアニメーションGIFに変換
type: docs
weight: 65
url: /ja/androidjava/convert-powerpoint-to-animated-gif/
keywords: "PowerPointをアニメーションGIFに変換, PPTをGIFに, PPTXをGIFに"
description: "PowerPointをアニメーションGIFに変換: PPTをGIFに, PPTXをGIFに、Aspose.Slides APIを使用します。"
---

## デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##

このJavaのサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

アニメーションGIFはデフォルトのパラメータで作成されます。 

{{%  alert  title="ヒント"  color="primary"  %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions)クラスを使用できます。以下のサンプルコードを参照してください。

{{% /alert %}} 

## カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##
このサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法をJavaで示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 結果のGIFのサイズ  
	gifOptions.setDefaultDelay(2000); // 各スライドが変更されるまでの表示時間
	gifOptions.setTransitionFps(35); // より良いトランジションアニメーション品質のためにFPSを増加
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="情報" color="info" %}}

Asposeが開発した無料の[テキストからGIF](https://products.aspose.app/slides/text-to-gif)コンバータをチェックしてみてください。 

{{% /alert %}}