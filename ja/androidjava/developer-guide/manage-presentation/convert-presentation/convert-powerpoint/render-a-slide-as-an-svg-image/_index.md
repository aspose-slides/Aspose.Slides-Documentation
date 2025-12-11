---
title: Android でプレゼンテーションスライドを SVG 画像としてレンダリング
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
description: Aspose.Slides for Android を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルな Java コード例で高品質なビジュアルを実現。
---

## **SVG フォーマット**

SVG（Scalable Vector Graphics の略称）は、2 次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクターとして保存し、動作や外観を定義する詳細情報を含みます。

SVG は、スケーラビリティ、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像フォーマットの一つです。そのため、ウェブ開発で広く使用されています。

SVG ファイルを使用したい状況は次の通りです。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する**。SVG 画像は任意の解像度やレベルに拡大でき、品質を犠牲にせずに何度でもリサイズ可能です。
- **スライドのチャートやグラフを*異なる媒体やプラットフォーム*で使用する**。ほとんどのリーダーが SVG ファイルを解釈できます。
- **画像を*可能な限り最小のサイズ*で使用する**。SVG ファイルは、特にビットマップ（JPEG や PNG）ベースのフォーマットに比べて、同等の高解像度画像よりも一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリングする**

Aspose.Slides for Android via Java は、プレゼンテーションのスライドを SVG 画像としてエクスポートすることを可能にします。以下の手順で SVG 画像を生成します。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを繰り返し処理します。
3. 各スライドを FileOutputStream を使用して個別の SVG ファイルに書き出します。

{{% alert color="primary" %}} 
Aspose.Slides for Android via Java の PPT から SVG への変換機能を実装した[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)をぜひお試しください。 
{{% /alert %}} 

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


## **よくある質問**

**なぜ生成された SVG はブラウザ間で見た目が異なることがあるのでしょうか？**

特定の SVG 機能のサポートは、ブラウザエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) パラメータを使用すると、非互換性を緩和できます。

**スライドだけでなく個々のシェイプを SVG にエクスポートすることは可能ですか？**

はい。任意の[シェイプは個別の SVG として保存できます](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを単一の SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオはスライド 1 枚につき SVG 1 枚です。複数のスライドを単一の SVG キャンバスに結合するのは、アプリケーション側で行うポストプロセスのステップです。