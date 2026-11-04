---
title: JavaでPowerPointシェイプをフォーマット
linktitle: シェイプの書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
keywords:
- シェイプの書式設定
- 線の書式設定
- スケッチ効果
- シェイプ線のスケッチ効果
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- シェイプの透明度
- シェイプの白黒レンダリング
- シェイプのグレースケールレンダリング
- シェイプの回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint のシェイプを書式設定する方法を学びます—PPT および PPTX ファイルの塗り、線、効果スタイルを正確かつ完全に制御できます。"
---
## **はじめに**

PowerPoint でシェイプのアウトライン、塗りつぶし、効果を調整してフォーマットします。Aspose.Slides for Java を使用すると、透明度、回転、3D フォーマットなどの設定をプログラムで制御できます。

![PowerPoint のシェイプ書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Java は、PowerPoint で利用できる同じオプションを使用してシェイプをフォーマットできるインターフェイスとメソッドを提供します。

## **線の書式設定**

[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) を使用してシェイプのアウトラインを制御します。この例では、塗りつぶしなしの矩形に青の破線アウトラインを作成します。[ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) は太さが異なる複合線を選択し、[ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) は幅を 7 ポイントに設定し、[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) はダッシュ パターンを選択します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

### **カスタム線ダッシュ パターンの設定**

事前定義された線スタイルが必要なダッシュ長やギャップを提供しない場合、たとえばブランド化されたアウトラインや技術図に対して、[ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) を使用します。パターンを割り当てると、線のダッシュ スタイルが [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) に自動的に変更されます。

配列のエントリはダッシュとギャップの長さを交互に並べ、ダッシュから開始します。各値は線幅の倍数です。幅が 3 ポイントのとき `{ 4, 2 }` は 12 ポイントのダッシュに続いて 6 ポイントのギャップを生成します。有限かつ非負のペアを使用して完全なダッシュ‑ギャップ セグメントを定義します。この例では、すべてのダッシュとギャップが見えるように正の値を使用しています。

この例は、同じ長さでフラット キャップの青色の線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は最初のパターンを幅を 2 倍にして繰り返し、ダッシュとギャップの長さも 2 倍にします。5 本目はカスタム パターンから実線に切り替えます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // 最後の線を実線スタイルに戻す。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

事前定義された破線スタイルに戻す場合は、[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) に [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) を渡します。選択したスタイルが線の外観を制御します。

PowerPoint での結果（上から下へ）: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; および **Solid, 3 pt**。

![PowerPoint の 3 つのカスタム ダッシュ パターン、最初のパターンを使用した太い線、実線](custom-dash-patterns.png)

### **線キャップの設定**

[ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) を使用して、開いた線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) クラスは 3 つの明示的なキャップ スタイルを提供します。

- `Flat`: ストロークは端点で止まります。
- `Round`: 半円形のキャップが端点を線幅の半分だけ伸ばします。
- `Square`: 正方形のキャップが端点を線幅の半分だけ伸ばします。

クラスには `NotDefined` も含まれ、これはキャップ スタイルが明示的に割り当てられていないことを意味します。

キャップは、線端にシンボルを追加する矢印ヘッドや、線セグメント間の角を制御するジョインとは異なります。この例では、[ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) と [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) を使用して矢印ヘッドを無効にし、キャップ形状だけを比較します。

以下の例は、幅 20 ポイントの水平線を 3 本作成します。上から下へ、フラット、ラウンド、スクエア キャップを使用します。端点の水平座標は同じですが、ラウンドとスクエアのキャップは各端点から 10 ポイント伸びます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint での結果（上から下へ）: **Flat**, **Round**, **Square**。

![PowerPoint の同一太線上のフラット、ラウンド、スクエア キャップ](line-caps.png)

## **シェイプ線へのスケッチ効果の適用**

スケッチ効果はシェイプの線を手描きのように見せます。[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) で線設定にアクセスし、[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) でスケッチ設定にアクセスし、[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) で [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) クラスから値を選択します。

次の Java コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) が返す値は、シェイプに直接割り当てられた設定を表します。テーマ、マスタースライド、またはレイアウトスライドから線の書式が継承される可能性がある場合は、[ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) を使用し、[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) にアクセスし、[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) を読み取ります。実効値は継承が解決された後に実際に適用される書式を反映します。この例は、最初のスライドに少なくとも 1 つのシェイプがある既存のプレゼンテーションを前提とし、両方の値を出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

結合スタイルは、2 つのアウトライン セグメントが角でどのように接続するかを制御します。丸みを帯びた角には **Round**、鋭角には **Miter**、平坦な角には **Bevel** を使用します。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

この例は、青いアウトライン（幅 15 ポイント）を持つ黒い矩形を 3 本作成します。[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) の miter、bevel、round の値をそれぞれ設定し、角がどのように描画されるかを比較します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **鋭角での Miter 結合の制限**

[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) と、[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) に設定して、鋭角がどれだけ伸びるかを制限します。

制限は、結合の内側と外側の角間の距離と線幅の比率です。たとえば、値 `8` は線幅の最大 8 倍までのミタ長を許可し、ポイントでの測定ではありません。角が制限を超える場合、PowerPoint はその角でベベル結合を使用します。制限が大きいほど鋭い点になります。この設定はミタ結合にのみ影響し、角が両方の制限内に留まる場合は目に見える影響はありません。

この例は、幅 20 ポイントのアウトラインを持つ同一の塗りなし三角形を 2 つ作成します。左側の三角形は `2` の制限、右側は `8` の制限を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角のミタ長と線幅の比率は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベルし、右側の頂点は鋭く保ちます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint の結果: 左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint のベベル頂点（左はミタ制限 2、右はミタ制限 8）](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしはシェイプ全体に色をブレンドします。この例は、[IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) を使用して、赤から紫への 45 度角の線形グラデーションで楕円を塗りつぶします。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) メソッドは、グラデーションの開始 (0) と終了 (1) にカラーストップを配置します。既存のストップをクリアすることで、これら 2 色のみが使用されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

### **線形グラデーションの角度の設定**

[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度数で測定され、時計回りに増加します: `0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされます。`[0, 360)` の範囲外の有限角度は 1 回転に正規化され、たとえば `-45` は `315`、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの矩形を作成します。スケーリングは無効にして、角度を矩形の比例に依存せずに比較できるようにします。左から右への角度は、最上段が `0`、`45`、`90`、下段が `135`、`180`、`270` です。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint の結果:

![上段 0°,45°,90°、下段 135°,180°,270° の線形グラデーション](linear-gradient-angles.png)

### **シェイプに合わせた線形グラデーションのスケーリング**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) は [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 値を受け取ります。`False` に設定すると形状の比例が変わっても幾何学的なグラデーション角度を維持し、`True` に設定すると形状の幅と高さに合わせてグラデーションがスケーリングされます。スケーリングが有効な場合、非正方形のシェイプでは見える角度が割り当てた角度と異なることがあります。

以下の例は、`45` 度の角度と同じカラーストップを使用します。左列は `False`、右列は `True` です。各列は上部に横長矩形、下部に縦長矩形を配置します。両方とも同じ幅で開始し、2 番目の矩形の幅と高さを変更して、塗りつぶし設定を変えずにリサイズに対する応答を示します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint の結果（左はスケーリング無効、右は有効）:

![左側は LinearGradientScaled が False、右側は True の 45° グラデーションの横長・縦長矩形](linear-gradient-scaling.png)

スケーリングが無効な場合、対角線状のカラー バンドは両矩形で同じ向きを保ちます。スケーリングが有効になると、バンドはシェイプの比例に合わせて伸びます。これは、異なるサイズにシェイプを適用する際にテンプレートのグラデーションを再現するのに役立ちます。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリングの設定は線形グラデーションにのみ適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) の塗りつぶしには影響しません。

### **角度とグラデーション方向の組み合わせ**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) は [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) クラスからグラデーション スタイルを選択します。数値角度の代替にはなりません。線形グラデーションの場合、コーナー スタイルにより、[setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) で割り当てた角度を変更せずに色が分布する領域を変えることができます。角度やスケーリングを比較する際は、方向は変更しないでください。

以下の例は、同じ設定を順序を入れ替えて適用します。2 つの矩形は同一の外観になります。方向を角度の前後に設定しても結果は変わりません。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **パターン塗りつぶし**

パターン塗りつぶしは、ドット、ストライプ、チェックなどの 2 色デザインを適用します。この例は、[IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) でトレリス パターンを選択します。[IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) で淡いグレーの背景を、[IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) で黄色のパターン色を指定します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしはシェイプ内に画像を使用します。この例はローカル画像を必要とし、[Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) でプレゼンテーションの画像コレクションにロードします。[IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) をタイル モードに設定すると、画像が矩形内で繰り返し表示されます。使用した元画像は下に示しています。

![ロータスの画像](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![画像塗りつぶしのシェイプ](picture-fill.png)

### **テクスチャとして画像をタイル表示**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): `Tile` または `Stretch` の画像塗りつぶしモードを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): シェイプ内のタイル配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): シェイプの原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): シェイプの原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元サイズの 50% に縮小して繰り返すように [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) を構成します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向の反転で繰り返しテクスチャの配置を決定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

単色塗りつぶしはシェイプに単一の均一な色を付けます。この例は、[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) で単色塗りつぶしモードを設定し、[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) で黄色を割り当て、矩形をプレゼンテーションに保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![単色塗りつぶしのシェイプ](solid-color-fill.png)

## **スライドの背景をシェイプの塗りつぶしとして使用**

スライド背景と一致させるシェイプが必要な場合（たとえばプレゼンテーションテンプレートで）には、[IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) を使用します。まず、[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) で [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を設定して明示的な塗りを削除します。この組み合わせにより、シェイプはスタイル塗りではなくスライドの背景を使用します。フラグを有効にするだけでは既存の明示的な塗りは削除されません。

これは [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) とは異なります。NoFill はシェイプの背後にあるオブジェクトをスライド背景で隠さずに表示させ、単純に塗りがない状態にします。グラデーションは各シェイプ内で再開されず、スライド全体に対して整列したままです。

以下の例は、スライドが継承するマスタ背景を作成し、3 つの矩形の背後にマゼンタ帯を配置します。左の矩形は背景塗り、中央は NoFill、右は背景塗りから明示的なオレンジ塗りに切り替えます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // マスタからグラデーションを継承します。
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // このオブジェクトを最初に追加して矩形の背後に表示させます。
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // 明示的な塗りを適用する前に背景塗りを無効にします。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（左から右へ）: **背景塗り**、**NoFill**、**明示的な塗り**。マゼンタ帯は左右の矩形で隠れますが、中央の矩形を通しては見えます。

![マゼンタ帯上の背景塗り、NoFill、明示的なオレンジ塗り](background-fill.png)

同じ動作はスライド上で直接定義された背景やレイアウトから継承された背景にも適用されます。シェイプは解決されたスライド背景を使用します。この例ではスライドとレイアウトの背景を未定義のままにし、マスタが提供するようにしています。

## **透明度の設定**

単色塗りの場合、色のアルファ成分が不透明度を制御します。0 は完全に透明、255 は完全に不透明です。この例は、アルファ値 128 の黄色の矩形を使用し、約 50% の透明度にして下の矩形が見えるようにします。色は [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) で割り当てられます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明なシェイプ](shape-transparency.png)

## **シェイプの回転**

[IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) を使用して、スライド平面上でシェイプを回転させます。角度は度数で測定され、この例では矩形を時計回りに 5 度回転させ、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![シェイプの回転](shape-rotation.png)

## **3D ベベル効果の追加**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) を使用して、シェイプに奥行きとベベル エッジを付けます。この例は緑の楕円にオレンジのアウトラインを付け、[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) で深さを 4 ポイントに設定し、[IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) を使用して幅と高さが 6 ポイントの円形上ベベルを適用します。正面からの正投影カメラと 3 点照明によりベベルが可視化されます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

シェイプの 3D 表示はカメラ設定で制御されます。この例は、[ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) を使用して緯度、経度、回転角度をそれぞれ 40°, 35°, 20° に設定します。[ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) で等角投影カメラを選択し、[ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) でバランス光源を設定し、書式設定された矩形を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D 回転効果](3D-rotation-effect.png)

## **シェイプの白黒レンダリングの制御**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに、個々のシェイプがどのようにレンダリングされるかを指定します。これは単独で白黒表示を有効にするものではなく、通常のカラー モードでのシェイプの塗り、線、その他の書式設定を変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` は灰色で、`BlackWhite` は黒白のみ、`Black` と `White` は単一色、`Color` は通常の色を保持し、`Hidden` は白黒モードでシェイプを除外します。`NotDefined` はシェイプレベルのモードが割り当てられていないことを意味します。

この例はオレンジの矩形を作成し、[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) でモードを灰色に設定します。保存されたシェイプは通常のカラー表示ではオレンジの塗りを保持し、黒白表示をサポートするアプリケーションでは灰色で表示されます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常のカラー モードでは矩形はオレンジの塗りを保持します。白黒表示のワークフローでは `Gray` モードが設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他黒白表示設定を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

[ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) を使用して、スライド プレースホルダーの位置、サイズ、書式設定を対応するレイアウト プレースホルダーから復元します。この例は、レイアウトにリンクされたプレースホルダーがある既存のプレゼンテーションを前提とし、保存前にすべてのスライドをリセットします。対応するレイアウト プレースホルダーがないシェイプはリセットされません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**シェイプの書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

色、線スタイル、効果設定は、埋め込み画像やメディアに比べてデータ量がほとんど増えません。画像塗りつぶしは、画像がプレゼンテーションに保存されるためファイル サイズを増加させる可能性があります。

**同一の書式設定を持つスライド上のシェイプを検出してグループ化するにはどうすればよいですか？**

各シェイプの主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にシェイプをグループ化します。これにより、後続のスタイル管理が簡素化されます。

**カスタム シェイプ スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル シェイプをテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイル付きシェイプをクローンし、必要な場所で書式設定を再適用します。