---
title: スライドをSVG画像としてレンダリングする
type: docs
weight: 50
url: /ja/nodejs-java/render-a-slide-as-an-svg-image/
---

## **SVG フォーマット**

SVG は Scalable Vector Graphics の略で、2 次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクトルとして保存し、動作や外観を定義する詳細を含みます。

SVG はスケーラビリティ、インタラクティビティ、パフォーマンス、アクセシビリティ、プログラム可能性などの点で非常に高い基準を満たす数少ない画像フォーマットの一つです。そのため、Web 開発で一般的に使用されます。

以下のような場合に SVG ファイルの使用を検討してください。

- **プレゼンテーションを *非常に大きなフォーマット* で印刷する**。SVG 画像は任意の解像度やレベルにスケールアップできます。品質を犠牲にすることなく必要な回数だけ SVG 画像のサイズを変更できます。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用する**。ほとんどの閲覧者は SVG ファイルを解釈できます。
- **画像の *可能な限り最小サイズ* を使用する**。SVG ファイルはビットマップベースのフォーマット（JPEG や PNG）に比べて、同等の高解像度画像よりも一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリングする**

Aspose.Slides for Node.js via Java を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成します。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileOutputStream を使用して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java の PPT から SVG への変換機能を実装した [無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) を試してみてください。

{{% /alert %}} 

以下の JavaScript サンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**なぜブラウザー間で生成された SVG の見た目が異なることがあるのでしょうか？**

特定の SVG 機能へのサポートは、ブラウザーエンジンによって異なる実装がされています。[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) パラメータは、互換性の問題を緩和するのに役立ちます。

**スライドだけでなく個々のシェイプを SVG としてエクスポートすることは可能ですか？**

はい。任意の [シェイプを個別の SVG として保存](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) でき、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを単一の SVG（ストリップ/ドキュメント）に結合することはできますか？**

標準シナリオはスライド 1 枚 → SVG 1 枚です。複数スライドを単一の SVG キャンバスに結合するのは、アプリケーションレベルで行うポストプロセッシングのステップです。