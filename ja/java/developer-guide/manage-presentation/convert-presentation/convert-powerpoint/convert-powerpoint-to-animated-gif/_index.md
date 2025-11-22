---
title: JavaでPowerPointプレゼンテーションをアニメーションGIFに変換
linktitle: PowerPointからGIFへ
type: docs
weight: 65
url: /ja/java/convert-powerpoint-to-animated-gif/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Javaを使用して、PowerPointプレゼンテーション（PPT、PPTX）を簡単にアニメーションGIFに変換できます。高速で高品質な結果を提供します。"
---

## デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##

このJavaサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


アニメーションGIFはデフォルトのパラメーターで作成されます。 

{{%  alert  title="TIP"  color="primary"  %}} 
GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions) クラスを使用できます。以下のサンプルコードをご覧ください。 
{{% /alert %}} 

## カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##
このサンプルコードは、Javaでカスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 生成された GIF のサイズ
	gifOptions.setDefaultDelay(2000); // 各スライドが次に切り替わるまでの表示時間
	gifOptions.setTransitionFps(35); // トランジションアニメーションの品質向上のために FPS を上げる
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
Asposeが提供する無料の [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバーターをご確認いただけます。 
{{% /alert %}}