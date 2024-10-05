---
title: PowerPointをアニメーションGIFに変換する
type: docs
weight: 65
url: /java/convert-powerpoint-to-animated-gif/
keywords: "PowerPointをアニメーションGIFに変換する, PPTをGIFに, PPTXをGIFに"
description: "Aspose.Slides APIを使用して、PowerPointをアニメーションGIFに変換します: PPTをGIFに, PPTXをGIFに。"
---

## デフォルト設定を使用してプレゼンテーションをアニメーションGIFに変換する ##

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

{{% alert title="ヒント" color="primary" %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions)クラスを使用できます。以下のサンプルコードを参照してください。 

{{% /alert %}} 

## カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する ##
このサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 結果のGIFのサイズ  
	gifOptions.setDefaultDelay(2000); // 各スライドが次のスライドに変更されるまでの表示時間
	gifOptions.setTransitionFps(35); // トランジションアニメーションの品質向上のためにFPSを増やす
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="情報" color="info" %}}

Asposeによって開発された無料の[テキストからGIF](https://products.aspose.app/slides/text-to-gif)コンバータをチェックしてみてください。 

{{% /alert %}}