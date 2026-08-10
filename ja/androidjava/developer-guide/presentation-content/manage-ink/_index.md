---
title: Android でプレゼンテーションのインクオブジェクトを管理
linktitle: インクの管理
type: docs
weight: 95
url: /ja/androidjava/manage-ink/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint のインクオブジェクトを管理し、トレースとブラシのプロパティを編集し、PDF、HTML、SVG、TIFF、画像のエクスポート時にインクの外観を制御します。"
---
## **概要**

PowerPoint には自由曲線のストロークを描画できるインク機能があります。インクは他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides はインクオブジェクトを操作するために必要な型を提供します。たとえば、[IInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iink/) インターフェイスはスライド上のインクオブジェクトを表します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプオブジェクトで表されます。最も単純な形では、シェイプはオブジェクト自体（フレーム）の領域と、コンテナサイズ、形状、背景などのプロパティを定義するコンテナです。詳細は [Shape Layout Format](https://docs.aspose.com/slides/ja/androidjava/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインクオブジェクトを扱う場合、フレーム（コンテナ）のすべてのプロパティはサイズ以外無視されます。コンテナ領域のサイズは標準の [IShape.getWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getWidth--) および [IShape.getHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getHeight--) メソッドで決定されます。

![ink_powerpoint1](ink_powerpoint1.png)

## **インクトレース**

インクトレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素です。トレースは接続された点のシーケンスを保存します。

最も単純なエンコーディングは、各サンプル点の X および Y 座標を指定します。すべての接続点が描画されると、次のような画像になります。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

ブラシはインクトレースの点を結ぶ線を描くために使用されます。ブラシには独自の色とサイズがあり、[IInkBrush.getColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkbrush/#getColor--) および [IInkBrush.getSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkbrush/#getSize--) メソッドで取得できます。

### **インクブラシの色を設定する**

この Java コードはインクブラシの色を設定する方法を示しています。

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **インクブラシのサイズを設定する**

この Java コードはインクブラシのサイズを設定する方法を示しています。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

通常、ブラシの幅と高さは一致せず、PowerPoint はブラシサイズを表示しません（対応するデータ セクションはグレー表示）。幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮しません—常に線の太さはゼロとみなします（前の画像参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレース）をコンテナ（フレーム）のサイズに合わせてスケーリングしています。コンテナのサイズが変わってもブラシサイズは一定であり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストオブジェクトでも同様の動作をします。

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク外観の制御**

Aspose.Slides は [IInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/) インターフェイスを提供し、エクスポートまたはレンダリングされた出力でインクオブジェクトの表示方法を制御できます。プロパティを使用してインクを完全に非表示にしたり、インクブラシのマスク操作の解釈方法を変更したりできます。

インクオプションは、以下の出力タイプに対するエクスポートまたはレンダリング オプションから利用できます。

| 出力 | Ink options プロパティ |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| スライド画像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

次の [IInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/) メソッドは同じ 2 つの設定を公開します。

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) はインクオブジェクトを出力に含めるかどうかを決定します。既定値は `false` です。
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) はインクブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。既定値は `true` です。`false` を指定して ROP 操作を使用するには、[IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出します。

### **PDF 出力でインクオブジェクトを非表示にする**

既定では、エクスポート時にインクオブジェクトは表示されます。手書きの注釈やその他のインク コンテンツを除いたクリーンな出力を作成するには、`true` を指定して [IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出します。

次の Java 例は、すべてのインクオブジェクトを非表示にした状態でプレゼンテーションを PDF にエクスポートします。

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

### **スライドを画像としてレンダリングするときにインクオブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングするときにインクオブジェクトを非表示にするには、[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) を構成し、レンダリング オプションを [ISlide.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) に渡します。

次の Java 例は、インクオブジェクトなしで最初のスライドを PNG 画像としてレンダリングします。

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

### **インクマスクのレンダリングを制御する**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 設定は、インクブラシをレンダリングするときにマスク操作がどのように解釈されるかを制御します。既定値は `true`（不透明度を使用）です。ROP 操作を使用したい場合は、`false` を渡して [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出します。

次の Java 例は、スライドを SVG にエクスポートし、インクマスク操作に ROP ベースのレンダリングを使用します。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

同じ設定は、プレゼンテーションをエクスポートまたはスライドを TIFF にレンダリングするときに [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) を介して適用できます。

### **インクを非表示にするか保持するかを選択する**

配布用に注釈付きプレゼンテーションのクリーンなバージョンが必要な場合は、エクスポート時に `true` を指定して [IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出します。

インクの注釈が意図されたコンテンツ（レビューコメント、手書きメモ、ハイライト、描画など）である場合は、[IInkOptions.getHideInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) を既定の `false` のままにしておきます。これにより、同一のプレゼンテーションからソースのインクオブジェクトを変更せずに、レビュー用と最終版の別々の出力を生成できます。

## **FAQ**

**既存のインクストロークの色やサイズを変更できますか？**

はい。まず [IInk.getTraces](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iink/#getTraces--) でトレースを取得し、[IInkTrace.getBrush](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinktrace/#getBrush--) を取得します。次に [IInkBrush.setColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) または [IInkBrush.setSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) を呼び出してブラシを変更します。

**インクを非表示にするとソースのプレゼンテーションが変更されますか？**

いいえ。[IInkOptions.setHideInk](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) を呼び出しても、レンダリングまたはエクスポート結果にのみ影響し、ソースのプレゼンテーション内のインクオブジェクトは削除または変更されません。

**どのエクスポート形式がインクオプションに対応していますか？**

上表に示したとおり、PDF、HTML、SVG、TIFF、ビットマップ スライド画像の各エクスポートまたはレンダリング オプションでインクオプションを設定できます。

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/ja/androidjava/powerpoint-shapes/) を参照してください。
* 有効プロパティの詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/ja/androidjava/shape-effective-properties/#get-effective-font-height-value) をご覧ください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/androidjava/convert-powerpoint-to-pdf/) を参照してください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/androidjava/convert-powerpoint-to-html/) を参照してください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/androidjava/render-a-slide-as-an-svg-image/) を参照してください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/androidjava/convert-powerpoint-to-tiff/) を参照してください。
* スライド画像レンダリングの詳細は、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/androidjava/convert-slide/) を参照してください。