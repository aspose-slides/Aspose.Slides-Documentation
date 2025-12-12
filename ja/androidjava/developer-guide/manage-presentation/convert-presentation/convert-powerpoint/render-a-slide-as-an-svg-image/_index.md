---
title: Android でプレゼンテーション スライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
- PPT から SVG へ
- PPTX から SVG へ
- PPT を SVG として保存
- PPTX を SVG として保存
- PPT を SVG にエクスポート
- PPTX を SVG にエクスポート
- スライドをレンダリング
- スライドを変換
- スライドをエクスポート
- ベクター画像
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びましょう。シンプルな Java コード例で高品質なビジュアルを実現します。"
---

## **SVG フォーマット**

SVG は Scalable Vector Graphics の略称で、二次元画像を描画するために使用される標準的なグラフィック形式です。SVG は画像を XML 形式のベクターとして保存し、動作や外観を定義する詳細情報を保持します。

SVG はスケーラビリティ、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像形式のひとつです。そのため、ウェブ開発で広く使用されています。

以下のような場合に SVG ファイルの使用を検討するとよいでしょう。

- **プレゼンテーションを *非常に大きなサイズ* で印刷する**。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく何度でもサイズ変更が可能です。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用する**。多くのビューアが SVG ファイルを解釈できます。
- **画像サイズを *できるだけ小さく* したい**。SVG ファイルは、特にビットマップ形式（JPEG や PNG）に比べて高解像度版よりも一般に容量が小さくなります。

## **スライドを SVG 画像としてレンダリングする**

Aspose.Slides for Android via Java を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileOutputStream を介して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 
SVG 変換機能を実装した当社の [無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) をお試しいただけます。
{{% /alert %}} 

以下の Java サンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています。
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**ブラウザ間で生成された SVG の表示が異なるのはなぜですか？**

各ブラウザエンジンは特定の SVG 機能のサポート方法が異なるためです。`[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/)` パラメーターを使用すると、互換性の問題を緩和できます。

**スライドだけでなく個別のシェイプを SVG としてエクスポートできますか？**

はい。任意の `[shape can be saved as a separate SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)` は、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは「1 スライド → 1 SVG」です。複数のスライドを単一の SVG キャンバスに結合する場合は、アプリケーション側でのポストプロセスが必要です。