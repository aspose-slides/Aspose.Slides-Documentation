---
title: Android で PowerPoint プレゼンテーションをアニメーション GIF に変換
linktitle: PowerPoint から GIF へ
type: docs
weight: 65
url: /ja/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- アニメーション GIF
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から GIF へ
- プレゼンテーションを GIF に
- スライドを GIF に
- PPT を GIF に
- PPTX を GIF に
- PPT を GIF として保存
- PPTX を GIF として保存
- PPT を GIF にエクスポート
- PPTX を GIF にエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使って、Java で PowerPoint プレゼンテーション（PPT、PPTX）を簡単にアニメーション GIF に変換します。高速で高品質な結果を提供します。"
---
## **概要**

Aspose.Slides を使用すると、数行のコードで PowerPoint プレゼンテーションをアニメーション GIF ファイルに変換できます。これは、スライドのコンテンツを軽量で広くサポートされているアニメーション形式で共有したい場合に便利で、Web ページやメッセンジャー、ドキュメントに埋め込むことができます。本記事では、デフォルト設定でプレゼンテーションを GIF にエクスポートする方法と、[GifOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/GifOptions) を使用してフレームサイズ、スライド遅延、トランジションフレームレートなどのオプションを構成して出力をカスタマイズする方法を説明します。

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

Java のサンプルコードは、標準設定でプレゼンテーションをアニメーション GIF に変換する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

アニメーション GIF はデフォルトのパラメータで作成されます。

{{%  alert  title="TIP"  color="info"  %}} 
パラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/GifOptions) クラスを使用できます。以下のサンプルコードをご覧ください。
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、Java でカスタム設定を使用してプレゼンテーションをアニメーション GIF に変換する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 生成された GIF のサイズ  
	gifOptions.setDefaultDelay(2000); // 各スライドが次に切り替わるまでの表示時間
	gifOptions.setTransitionFps(35); // 遷移アニメーションの品質向上のために FPS を増やす
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
無料の [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバーターが Aspose によって提供されていますので、ぜひお試しください。 
{{% /alert %}}

## **FAQ**

### プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？

不足しているフォントをインストールするか、[configure fallback fonts](/slides/ja/androidjava/powerpoint-fonts/) を設定してください。Aspose.Slides は代替フォントで置き換えますが、外観が異なる場合があります。ブランドの一貫性が必要な場合は、必ず必要な書体が明示的に利用可能であることを確認してください。

### GIFフレームに透かしを重ねることはできますか？

はい。[Add a semi-transparent object/logo](/slides/ja/androidjava/watermark/) をマスタースライドまたは個々のスライドにエクスポート前に追加すれば、透かしがすべてのフレームに表示されます。