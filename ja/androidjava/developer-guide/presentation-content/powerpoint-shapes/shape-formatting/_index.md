---
title: Android で PowerPoint の図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/androidjava/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルの書式設定
- グラデーション塗り
- パターン塗り
- 画像塗り
- テクスチャ塗り
- 単色塗り
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android で PowerPoint の図形をフォーマットする方法を学びます。PPT および PPTX ファイルの塗り、線、効果スタイルを正確かつ完全に制御できます。"
---
## **はじめに**

PowerPoint の図形のアウトライン、塗りつぶし、効果を調整して書式設定します。Aspose.Slides for Android via Java を使用すると、透明度、回転、3D 書式設定などの設定をプログラムで制御できます。

![PowerPoint の図形書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Android via Java は、PowerPoint で利用できる同じオプションを使用して図形を書式設定できるインターフェイスとメソッドを提供します。

## **線の書式設定**

[IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) を使用して図形のアウトラインを制御します。この例は、塗りつぶしなしの長方形に青色の点線アウトラインを作成します。[ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) で太さが異なる複合線を選択し、[ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) で幅を 7 ポイントに、[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) でダッシュパターンを選択します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **カスタム線ダッシュパターンの設定**

事前定義された線スタイルで必要なダッシュ長と間隔が提供されない場合は、[ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) を使用します。たとえば、ブランドのアウトラインや技術図で使用します。パターンを割り当てると、線のダッシュスタイルが [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) に自動的に変更されます。

配列の要素はダッシュとギャップの長さを交互に指定し、ダッシュから開始します。各値は線の幅の倍数です。幅が 3 ポイントの場合、`{ 4, 2 }` は 12 ポイントのダッシュと 6 ポイントのギャップになります。有限かつ非負の値のペアで完全なダッシュ‑ギャップセグメントを定義します。この例では、すべてのダッシュとギャップが見えるように正の値を使用しています。

この例は、同じ長さでフラットキャップの青色の線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は幅を 2 倍にして最初のパターンを繰り返し、ダッシュとギャップの長さも 2 倍にします。5 本目はカスタムパターンから実線に切り替えます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

事前定義された破線スタイルに戻すには、[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) に [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) を渡します。選択したスタイルが線の外観を制御します。

PowerPoint での結果（上から下へ）: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; および **Solid, 3 pt**。

![3 つのカスタムダッシュパターン、最初のパターンを使用した太い線、実線の PowerPoint 表示](custom-dash-patterns.png)

### **線キャップの設定**

[ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) を使用して開いた線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) クラスは次の 3 つの明示的なキャップスタイルを提供します。

- `Flat`: ストロークは端点で止まります。
- `Round`: 半円形のキャップが端点の外側に線幅の半分だけ伸びます。
- `Square`: 正方形のキャップが端点の外側に線幅の半分だけ伸びます。

クラスには `NotDefined` も含まれ、これはキャップスタイルが明示的に割り当てられていないことを意味します。

キャップは、線端に記号を追加する矢印ヘッドや、線セグメント間の角を制御するジョインとは異なります。この例では、[ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) と [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) で矢印ヘッドを無効にし、キャップ形状のみを比較します。

以下の例は、横方向に 20 ポイントの幅で、ほぼ同一の水平線を 3 本作成します。上から下へ、フラット、ラウンド、スクエアのキャップを使用します。端点は同じ水平座標を持ち、ラウンドとスクエアのキャップはそれぞれ端点から 10 ポイント外側に伸びます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

![PowerPoint で同一太線に適用されたフラット、ラウンド、スクエアキャップ](line-caps.png)

## **図形の線にスケッチ効果を適用する**

スケッチ効果は図形の線を手描きに見せます。[IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) で線設定にアクセスし、[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) でスケッチ設定にアクセスし、[ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) で [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) クラスから値を選択します。

以下の Java コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、レイアウトスライドから線の書式設定が継承される可能性がある場合は、[ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) にアクセスし、[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) を取得し、[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) を読み取ります。Effective 値は、継承が解決された後に実際に適用される書式設定を反映します。この例は、最初のスライドに少なくとも 1 つの図形がある既存のプレゼンテーションを前提とし、両方の値を出力します。

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

結合スタイルは、2 つのアウトラインセグメントが角でどのように接続されるかを制御します。丸みを帯びた角には **Round**、鋭い角には **Miter**、平らな角には **Bevel** を使用します。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

この例は、青色のアウトラインが 15 ポイント幅の黒い長方形を 3 つ作成します。[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) の miter、bevel、round の各値を適用し、角の描画方法を比較します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **鋭角の Miter 結合を制限する**

[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) と、[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) に設定して、鋭い角がどれだけ伸びるかを制限します。

制限は、結合の内側と外側の角の距離を線幅で割った比率です。たとえば、`8` の値は線幅の最大 8 倍までの miter 長さを許可し、ポイント単位の測定ではありません。角が制限を超える場合、PowerPoint はその角で bevel 結合を使用します。より大きな制限は、より鋭いポイントを許可します。この設定は miter 結合にのみ影響し、角が両方の制限内に収まっている場合は目に見える変化はありません。

この例は、幅 20 ポイントのアウトラインを持つ同一の塗りなし三角形を 2 つ作成します。左側の三角形は `2`、右側は `8` の制限を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角の miter 長さと線幅の比率は約 `4.12` です。その結果、PowerPoint は左側の頂点を bevel にし、右側の頂点は保持します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint での結果: 左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint での bevel 頂点（Miter limit 2）と鋭い頂点（Miter limit 8）](miter-limits.png)

## **グラデーション塗り**

グラデーション塗りは形状全体に色をブレンドします。この例は、[IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) を使用して、赤から紫への 45 度角の線形グラデーションで楕円を塗りつぶします。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) メソッドは、グラデーションの開始（0）と終了（1）にカラー ストップを配置します。既存のストップをクリアすることで、これら 2 つの色だけが使用されます。

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

![グラデーション塗りの楕円](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りを変更せずに、レンダリング スタイルを選択できます。

### **線形グラデーションの角度を設定する**

[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) 塗りの向きを制御します。角度は度単位で時計回りに増加します: `0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされます。`[0, 360)` 以外の有限角度は 1 回転に正規化されます。たとえば、`-45` は `315` に、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの矩形を作成します。スケーリングを無効にして、角度を矩形の比率に依存せずに比較できるようにします。左から右への角度は、1 行目が `0`、`45`、`90`、2 行目が `135`、`180`、`270` です。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPoint での結果:

![上段 0、45、90 度、下段 135、180、270 度の線形グラデーション](linear-gradient-angles.png)

### **形状とともに線形グラデーションをスケールする**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) は [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) 値を受け取ります。`False` に設定すると、形状のサイズが変わっても幾何学的なグラデーション角度が保持され、`True` に設定すると形状の幅と高さに合わせてグラデーションがスケールされます。スケーリングが有効な非正方形形状では、見える角度が割り当てた角度と異なる場合があります。

以下の例は、`45` 度の角度と同じカラー ストップを使用します。左列は `False`、右列は `True` です。各列には横長の矩形の上に縦長の矩形があります。最初は同じ幅で、2 番目の矩形の幅と高さを変更して、塗りがリサイズにどのように応答するかを示します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPoint での結果（左はスケーリング無効、右は有効）:

![左は LinearGradientScaled False、右は True の 45 度グラデーションを持つ横長・縦長矩形](linear-gradient-scaling.png)

スケーリングを無効にすると、対角線の色帯は両方の矩形で同じ向きを保ちます。スケーリングを有効にすると、帯は形状の比率に合わせて伸びます。これにより、テンプレートのグラデーションを別サイズの形状に適用するときに再現しやすくなります。正方形では、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度設定とスケーリング設定は線形グラデーションにのみ適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) 塗りには影響しません。

### **角度とグラデーション方向を組み合わせる**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) は [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) クラスからグラデーション スタイルを選択します。数値角度の代替ではありません。線形グラデーションの場合、コーナースタイルは [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) で設定した角度を変えることなく、色が分布する領域を変更できます。角度やスケーリングを比較するときは、方向は変更しないでください。

以下の例は、同じ設定を順序を入れ替えて適用します。2 つの矩形は同一の外観になり、方向を角度の前後に設定しても結果は変わりません。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **パターン塗り**

パターン塗りは、ドット、ストライプ、チェックなどの二色デザインを適用します。この例は、[IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) で格子パターンを選択し、[IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) で薄い灰色の背景色を、[IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) で黄色のパターン色を指定します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![パターン塗りの矩形](pattern-fill.png)

## **画像塗り**

画像塗りは、図形内に画像を配置します。この例はローカル画像を使用し、[Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) でプレゼンテーションの画像コレクションに読み込みます。[IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) をタイル モードに設定すると、画像が矩形内で繰り返されます。使用した元画像は以下です。

![蓮の画像](lotus.png)

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

![画像塗りの図形](picture-fill.png)

### **テクスチャとして画像をタイル表示する**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): `Tile` または `Stretch` の画像塗りモードを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): タイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方にフリップするかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 形状の基点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 形状の基点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元サイズの 50% で繰り返すように [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) を構成します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向フリップで繰り返しテクスチャの配置を決定します。

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

## **単色塗り**

単色塗りは図形に単一の均一な色を付けます。この例は、[IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) で単色塗りモードを選択し、[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) で黄色を割り当て、矩形をプレゼンテーションに保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![単色塗りの図形](solid-color-fill.png)

### **テーマ参照を保持したまま色をコピーする**

[IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) を使用すると、色タイプ、テーマ参照、変換を含むカラー定義をコピーできます。これは、テーマに従い続けるべき塗り色を別の図形に転送する場合に便利です。このメソッドは色だけをコピーし、塗りタイプ、アウトライン、その他の図形書式設定はコピーしません。宛先の塗りタイプは [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) で明示的に設定してください。

この例は、左から右へ 3 つの矩形を作成します。左はソース、中央はテーマ対応コピー、右は固定 RGB コピーです。ソースは [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) で最初のアクセントカラーを参照し、[IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-) でティントを追加します。RGB コピーはソースの effective 塗り色を使用するため、最初はすべて同じ青色に見えます。[IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) を呼び出すと、固定 RGB 値が設定され、既存の色変換がクリアされます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // テーマ参照は新しいアクセントカラーに従いますが、固定された RGB 値は従いません。
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

テーマ変更前は、3 つの塗りはすべて一致します:

![ソース、copyFrom 宛先、固定 RGB 宛先の同一青塗り](color-copy-before.png)

テーマ変更後、ソースとテーマ対応コピーは新しいアクセントカラーに従いティントを保持します。固定 RGB コピーは青のままです:

![オレンジ塗りのソースと copyFrom 宛先、固定 RGB 宛先は青のまま](color-copy-after.png)

コピーされた定義はソースから独立しています。以降、ソースのテーマ参照を変更したり別の色を割り当てたり、変換を追加・削除しても宛先には影響しません。テーマ変更は両方の図形に影響しますが、各図形は同じテーマカラーを個別に参照しているためです。

保存して PPTX を再度開くと、[IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--) が返すカラータイプ、テーマ参照、[IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) が返す変換コレクションは保持され、RGB にフラット化されません。

異なるテーマコンテキスト間でコピーする場合（例: アクセント パレットが異なるプレゼンテーション間）には、コピーされた参照は宛先のテーマに対して解決されます。同じ参照と変換でも、見た目の色が変わることがあります。テーマカラーの設定方法は [Presentation Theme](/slides/ja/androidjava/presentation-theme/) を参照してください。

## **スライドの背景を図形の塗りとして使用する**

スライドの背景に合わせて図形を表示したい場合は、[IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) を使用します。まず [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) に設定して明示的な塗りを削除します。この組み合わせにより、図形はスタイル塗りではなくスライドの背景を使用します。フラグだけを有効にしても既存の明示的な塗りは削除されません。

これは [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) とは異なります。背景塗りは図形の背後にあるオブジェクトをスライド背景の該当領域で覆い、NoFill はそれらのオブジェクトを表示したままにします。グラデーションは各図形内で再開されず、スライドに合わせて配置されます。

以下の例は、スライドが継承するマスターバックグラウンドを作成し、3 つの矩形の背後にマゼンタ帯を配置します。左の矩形は背景を使用し、中央は NoFill、右は背景塗りから明示的なオレンジ塗りに切り替えます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // マスターからグラデーションを継承します。
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

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
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（左から右へ）: **背景塗り**, **NoFill**, **明示的な塗り**。マゼンタ帯は左と右の矩形で隠れますが、中央の矩形からは見えます。

![背景塗り、NoFill、オレンジの明示的塗りがマゼンタ帯の上にある様子](background-fill.png)

同じ動作は、スライド上で直接定義された背景やレイアウトから継承された背景にも適用されます。図形は解決されたスライドの背景を使用します。この例ではスライドとレイアウトの背景は未定義のままにし、マスターが提供します。

## **透明度の設定**

単色塗りの場合、色のアルファ成分が不透明度を制御します。0 が完全に透明、255 が完全に不透明です。この例は、黄色の矩形にアルファ値 128 を使用し、約 50% の透明度にして下の矩形が見えるようにします。色は [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) を介して割り当てられます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) を使用して、スライド平面上で図形を回転させます。角度は度単位で測定されます。この例は、矩形を時計回りに 5 度回転させてプレゼンテーションを保存します。

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

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を使用して、図形に奥行きとベベル エッジを付加します。この例は、緑の楕円にオレンジのアウトラインを付け、[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) で深さを 4 ポイントに設定し、[IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) で幅と高さが 6 ポイントの円形トップベベルを適用します。正面向きの正射影カメラと三点照明によりベベルが見えるようにします。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

図形の 3D 表示はカメラ設定で制御されます。この例は、[ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) に緯度 40 度、経度 35 度、回転 20 度を指定して使用します。[ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) で等角カメラを選択し、[ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) でバランスの取れた照明を設定し、書式設定された矩形を保存します。

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

## **図形の白黒レンダリングを制御する**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに、個々の図形がどのようにレンダリングされるかを指定します。これ自体で白黒表示を有効にするわけではなく、通常のカラー モードでの図形の塗り・線・その他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換方式を任せ、`Gray` と `LightGray` は灰色で表示し、`BlackWhite` は黒と白だけ、`Black` と `White` は単一色、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を省略します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

この例はオレンジの矩形を作成し、[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) で灰色表示を選択します。保存された図形は通常カラー表示ではオレンジのままで、白黒表示をサポートするアプリケーションでは灰色で表示されます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常カラー モードでは矩形はオレンジのままです。白黒表示のワークフローでは、モードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他白黒表示を尊重するワークフロー用に別の外観を定義できます。

## **書式設定のリセット**

[ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) を使用して、レイアウト プレースホルダーに対応するスライド プレースホルダーの位置、サイズ、書式設定を復元します。この例は、レイアウトにリンクされたプレースホルダーがある既存のプレゼンテーションが必要で、保存前にすべてのスライドをリセットします。対応するレイアウト プレースホルダーがない図形はリセットされません。

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

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

色、線スタイル、効果設定は、埋め込まれた画像やメディアに比べてデータ量が少ないです。画像塗りは、画像がプレゼンテーションに保存されるため、ファイル サイズが増加する可能性があります。

**同一書式設定の図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルを同一と見なし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイル付き図形をクローンして、必要な場所で書式設定を再適用します。