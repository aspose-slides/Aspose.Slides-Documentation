---
title: AndroidでPowerPointプレゼンテーションをアニメーションGIFに変換
linktitle: PowerPointからGIFへ
type: docs
weight: 65
url: /ja/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Javaを使用してAndroid向けAspose.SlidesでPowerPointプレゼンテーション（PPT、PPTX）を簡単にアニメーションGIFに変換します。高速で高品質な結果を提供します。"
---

## **デフォルト設定を使用してプレゼンテーションをアニメーションGIFに変換する**

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

GIFのパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions)クラスを使用できます。以下のサンプルコードをご覧ください。

{{% /alert %}} 

## **カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、カスタム設定を使用してJavaでプレゼンテーションをアニメーションGIFに変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 生成された GIF のサイズ
	gifOptions.setDefaultDelay(2000); // 各スライドが次に切り替わるまでの表示時間
	gifOptions.setTransitionFps(35); // トランジションアニメーション品質向上のために FPS を上げる
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}

Asposeが開発した無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータをチェックしてみてください。 

{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォールバックフォントを設定](/slides/ja/androidjava/powerpoint-fonts/)してください。Aspose.Slides は代替フォントを使用しますが、外観が異なる場合があります。ブランディングのためには、必要な書体が確実に利用可能であることを常に確認してください。

**GIFフレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/androidjava/watermark/)を追加すると、透かしがすべてのフレームに表示されます。