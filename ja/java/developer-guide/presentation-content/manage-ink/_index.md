---
title: Java でプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/java/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- インクのエクスポート
- インクのレンダリング
- インクの非表示
- IInkOptions
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint のインクオブジェクトを管理し、トレースやブラシプロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインクの表示を Aspose.Slides for Java で制御します。"
---
## **はじめに**

PowerPoint はインク機能を提供し、自由形式のストロークを描くことができます。インクは他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引いたりするために使用できます。

Aspose.Slides はインクオブジェクトを操作するために必要な型を提供します。たとえば、[IInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iink/) インターフェイスはスライド上のインクオブジェクトを表します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。最も単純な形では、シェイプはオブジェクト自体（フレーム）の領域と、コンテナのサイズ、形状、背景などのプロパティを定義するコンテナです。 詳細については、[Shape Layout Format](https://docs.aspose.com/slides/ja/java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインクオブジェクトを処理する場合、コンテナ（フレーム）のサイズ以外のすべてのプロパティを無視します。コンテナ領域のサイズは標準の[IShape.getWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getWidth--) と[IShape.getHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getHeight--) メソッドによって決定されます。

![ink_powerpoint1](ink_powerpoint1.png)

## **インクトレース**

インクトレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録するために使用される基本要素です。トレースは接続されたポイントのシーケンスを保持します。

最も単純なエンコーディング形式は、各サンプルポイントの X および Y 座標を指定します。すべての接続ポイントが描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

ブラシはインクトレースのポイントを接続する線を描くために使用されます。ブラシは[IInkBrush.getColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkbrush/#getColor--) および[IInkBrush.getSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkbrush/#getSize--) メソッドで表される独自の色とサイズを持ちます。

### **インクブラシの色を設定**

この Java コードはインクブラシの色を設定する方法を示しています:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **インクブラシのサイズを設定**

この Java コードはインクブラシのサイズを設定する方法を示しています:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

一般に、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（対応するデータ セクションはグレー表示になります）。幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します:

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう:

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると仮定します（前の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレース）がコンテナ（フレーム）のサイズにスケーリングされています。コンテナのサイズが変わると、ブラシサイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストオブジェクトでも同様の動作を使用します:

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク表示の制御**

Aspose.Slides は[IInkOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/) インターフェイスを提供し、エクスポートまたはレンダリングされた出力でインクオブジェクトの表示方法を制御できます。これらのプロパティを使用してインクを完全に非表示にしたり、インクブラシのマスク操作の解釈方法を変更したりできます。

インクオプションは、以下の出力タイプに対応するエクスポートまたはレンダリング オプションを通じて利用できます:

| 出力 | インク オプション プロパティ |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

次の[IInkOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/) メソッドは同じ 2 つの設定を公開します:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#getHideInk--) はインクオブジェクトが出力に含まれるかどうかを決定します。デフォルト値は `false` です。
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) はインクブラシをレンダリングするときにマスク操作を不透明度として解釈するかどうかを決定します。デフォルト値は `true` です。`false` を指定して [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出すと ROP 操作が使用されます。

### **PDF 出力でインクオブジェクトを非表示にする**

デフォルトでは、エクスポート時にインクオブジェクトは表示されたままです。手書きの注釈やその他のインク コンテンツを除いたクリーンな出力を作成するには、`true` を指定して [IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出します。

次の Java の例は、インクオブジェクトをすべて非表示にした状態でプレゼンテーションを PDF にエクスポートします:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **スライドを画像としてレンダリングする際にインクオブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際にインクオブジェクトを非表示にするには、[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/renderingoptions/#getInkOptions--) を構成し、レンダリング オプションを [ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) に渡します。

次の Java の例は、インクオブジェクトなしで最初のスライドを PNG 画像としてレンダリングします:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **インクマスクのレンダリングを制御**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 設定は、インクブラシをレンダリングするときにマスク操作がどのように解釈されるかを制御します。デフォルト値は `true` で、不透明度が使用されます。ROP 操作を使用したい場合は、`false` を指定して [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出します。

次の Java の例は、スライドを SVG にエクスポートし、インクマスク操作に ROP ベースのレンダリングを使用します:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

同じ設定は、プレゼンテーションのエクスポートまたはスライドを TIFF にレンダリングする際に [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/#getInkOptions--) を介して適用できます。

### **インクを非表示にするか保持するか選択**

注釈付きプレゼンテーションの配布用にクリーンなバージョンが必要な場合は、エクスポート時に `true` を指定して [IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出します。

インク注釈が意図したコンテンツの一部（レビュー コメント、手書きメモ、ハイライト、描画など）であり、エクスポート結果に残す必要がある場合は、[IInkOptions.getHideInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#getHideInk--) をデフォルトの `false` のままにしてください。これにより、同じプレゼンテーションからソースのインクオブジェクトを変更せずに、レビュー用と最終版の出力を別々に生成できます。

## **FAQ**

**既存のインクストロークの色やサイズを変更できますか？**

はい。[IInk.getTraces](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iink/#getTraces--) でトレースを取得し、[IInkTrace.getBrush](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinktrace/#getBrush--) を変更します。[IInkBrush.setColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) または [IInkBrush.setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) を呼び出してブラシを変更してください。

**インクを非表示にしても元のプレゼンテーションは変わりますか？**

いいえ。[IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出しても、レンダリングまたはエクスポート結果のみが影響を受け、ソース プレゼンテーション内のインクオブジェクトは削除または変更されません。

**どのエクスポート形式がインクオプションをサポートしていますか？**

PDF、HTML、SVG、TIFF、ビットマップ スライド画像の各エクスポートまたはレンダリング オプションでインクオプションを構成できます。

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes] セクションをご覧ください。
* 有効値の詳細については、[Shape Effective Properties](https://docs.aspose.com/slides/ja/java/shape-effective-properties/#get-effective-font-height-value) を参照してください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/java/convert-powerpoint-to-pdf/) をご覧ください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/java/convert-powerpoint-to-html/) をご覧ください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/java/render-a-slide-as-an-svg-image/) をご覧ください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/java/convert-powerpoint-to-tiff/) をご覧ください。
* スライド画像のレンダリングの詳細は、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/java/convert-slide/) をご覧ください。