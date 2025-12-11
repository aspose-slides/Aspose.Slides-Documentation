---
title: AndroidでPowerPointプレゼンテーションをアニメーションGIFに変換
linktitle: PowerPointからGIFへ
type: docs
weight: 65
url: /ja/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- アニメーションGIF
- PowerPoint変換
- プレゼンテーション変換
- スライド変換
- PPT変換
- PPTX変換
- PowerPointからGIFへ
- プレゼンテーションからGIFへ
- スライドからGIFへ
- PPTからGIFへ
- PPTXからGIFへ
- PPTをGIFとして保存
- PPTXをGIFとして保存
- PPTをGIFにエクスポート
- PPTXをGIFにエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Javaを使用してAndroid向けAspose.SlidesでPowerPointプレゼンテーション（PPT、PPTX）をアニメーションGIFに簡単に変換します。高速で高品質な結果を実現します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換**

この Java のサンプルコードは、標準設定でプレゼンテーションをアニメーション GIF に変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


アニメーション GIF はデフォルト パラメータで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIF のパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions) クラスを使用できます。以下のサンプルコードを参照してください。
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換**

このサンプルコードは、Java でカスタム設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 生成された GIF のサイズ  
	gifOptions.setDefaultDelay(2000); // 各スライドが次に切り替わるまで表示される時間
	gifOptions.setTransitionFps(35); // トランジションアニメーションの品質を向上させるために FPS を増加
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose が開発した無料の [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータをぜひお試しください。
{{% /alert %}}

## **よくある質問**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうすればよいですか？**

不足しているフォントをインストールするか、[フォールバックフォントを構成](/slides/ja/androidjava/powerpoint-fonts/)してください。Aspose.Slides は代替フォントで置き換えますが、外観が変わることがあります。ブランディングのためには、必要な書体が確実に利用可能であることを常に確認してください。

**GIF フレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴを追加](/slides/ja/androidjava/watermark/)すると、透かしがすべてのフレームに表示されます。