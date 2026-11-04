---
title: Android で PowerPoint シェイプをフォーマットする
linktitle: シェイプの書式設定
type: docs
weight: 20
url: /ja/androidjava/shape-formatting/
keywords:
- シェイプの書式設定
- 線の書式設定
- スケッチ効果
- スケッチシェイプ線
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- シェイプの透明度
- 白黒シェイプレンダリング
- グレースケールシェイプレンダリング
- シェイプの回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android で PowerPoint シェイプをフォーマットする方法を学びます。PPT および PPTX ファイルの塗り、線、効果スタイルを正確かつ完全にコントロールできます。"
---
## **イントロダクション**

PowerPoint でシェイプの輪郭、塗りつぶし、効果を調整して書式設定します。Aspose.Slides for Android via Java を使用すると、透明度、回転、3D 書式設定などの設定をプログラムで制御できます。

![PowerPoint のシェイプ書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Android via Java は、PowerPoint で利用できる同じオプションを使用してシェイプをフォーマットできるインターフェイスとメソッドを提供します。

## **線の書式設定**

シェイプの輪郭を制御するには [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) を使用します。この例では、塗りつぶしのない長方形を作成し、青色の破線の輪郭を設定します。[ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) は太さが異なる複合線を選択し、[ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) は幅を 7 ポイントに設定し、[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) は破線パターンを選択します。

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

### **カスタム線破線パターンの設定**

事前定義された線スタイルで必要な破線の長さや間隔が得られない場合は、[ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) を使用します（例：ブランド輪郭や技術図）。パターンを割り当てると、線の破線スタイルが自動的に [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) に変更されます。

配列の要素は破線と間隔を交互に並べ、最初は破線から始まります。各値は線幅の倍数です。幅 3 ポイントで `{ 4, 2 }` を指定すると、12 ポイントの破線の後に 6 ポイントの間隔が続きます。有限かつ負でない値のペアを使用して、完全な破線‑間隔セグメントを定義します。この例では、すべての破線と間隔が可視になるように正の値を使用しています。

この例では、同じ長さで平坦なキャップを持つ 5 本の青い線を作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は最初のパターンを幅 2 倍に繰り返し、破線と間隔の長さも 2 倍にします。5 本目はカスタムパターンから実線に切り替えます。

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

代わりに事前定義された破線スタイルに戻すには、[LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) を [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) に渡します。選択されたスタイルが線の外観を制御します。

PowerPoint の結果（上から下へ）: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; および **Solid, 3 pt**。

![PowerPoint の 3 つのカスタム破線パターン、最初のパターンを使用した太い線、そして実線](custom-dash-patterns.png)

### **線のキャップ設定**

開いた線の端を設定するには [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) を使用します。[LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) クラスは、次の 3 つの明示的なキャップスタイルを提供します：

- `Flat`: ストロークは終点で止まります。
- `Round`: 半円形のキャップが線幅の半分だけ端点を超えて延びます。
- `Square`: 四角形のキャップが線幅の半分だけ端点を超えて延びます。

クラスには `NotDefined` も含まれ、これはキャップスタイルが明示的に割り当てられていないことを意味します。

キャップは、線の端にシンボルを追加する矢羽や、線分間のコーナーを制御するジョインとは異なります。この例では、[ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) と [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) を使用して矢羽を無効にし、キャップ形状のみを比較します。

以下の例では、幅 20 ポイントの水平線を 3 本作成します。上から下へ、Flat、Round、Square のキャップが適用されます。端点の水平座標は同じですが、Round と Square のキャップは各端点から 10 ポイント延びます。

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

PowerPoint の結果（上から下へ）: **Flat**, **Round**, **Square**。

![PowerPoint の同一太線における平坦、丸み、四角のキャップ](line-caps.png)

## **シェイプ線へのスケッチ効果の適用**

スケッチ効果はシェイプの線を手描きに見せます。[IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) で線設定にアクセスし、[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) でスケッチ設定にアクセスし、[ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) で [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) クラスから値を選択します。

以下の Java コードは [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) 効果の適用、明示的に割り当てられた値の取得、そして [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) が返す値はシェイプに直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される可能性がある場合は、[ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) を使用し、[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) にアクセスし、[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) を読み取ります。継承が解決された後に実際に適用された書式が有効値として返されます。この例では、最初のスライドに少なくとも 1 つのシェイプがある既存のプレゼンテーションが必要で、両方の値を出力します。

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

次の 3 つが結合タイプのオプションです：

* Round
* Miter
* Bevel

結合スタイルは、2 本の輪郭セグメントがコーナーでどのように接続されるかを制御します。**Round** は丸みを帯びたコーナー、**Miter** は鋭いコーナー、**Bevel** は平坦なコーナーに使用します。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

この例では、青い輪郭（幅 15 ポイント）を持つ黒い矩形を 3 つ作成します。[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) の miter、bevel、round の各値を適用し、コーナーの描画方法を比較します。

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

### **鋭いコーナーでのミタージョインの制限**

[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) と、[LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) に設定した [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) を組み合わせて、鋭いコーナーがどれだけ伸びるかを制限します。

制限は、結合部の内側と外側のコーナー間の距離を線幅で割った比率です。たとえば `8` の値はミタ―長さを線幅の最大 8 倍まで許容し、ポイント単位の測定ではありません。コーナーが制限を超えると、PowerPoint はそのコーナーでベベル結合を使用します。制限を大きくすると、より鋭いポイントが得られます。この設定はミタージョインにのみ影響し、コーナーが両方の制限内に収まっている場合は視覚的な変化はありません。

この例では、幅 20 ポイントの輪郭を持つ同一の塗りつぶしなし三角形を 2 つ作成します。左側の三角形は `2` の制限、右側は `8` の制限を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部コーナーのミタ―長さ‑線幅比は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベルし、右側の頂点は保持します。

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

PowerPoint の結果: 左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint の左側はミターレベル 2 の角がベベル加工され、右側はミターレベル 8 の鋭い角が保持された様子](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしはシェイプ全体に色をブレンドします。この例では、赤から紫への 45 度の線形グラデーションで楕円を塗りつぶします。使用するメソッドは [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) です。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) は 0 と 1 の位置（グラデーションの開始と終了）にカラー ストップを配置します。既存のストップをクリアすることで、使用される色はこの 2 つだけになります。

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

グラデーションがエクスポート画像で PowerPoint と見た目が異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されているグラデーション塗りつぶしを変更せずに、レンダリング スタイルだけを選択できます。

### **線形グラデーション角度の設定**

[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度数で測定され、時計回りに増加します：`0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされます。`[0, 360)` の範囲外の有限角度は 1 回転に正規化され、たとえば `-45` は `315` に、`360` は `0` になります。

この例では、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの矩形を作成します。スケーリングは無効にして、角度が矩形の比例に影響されずに比較できるようにします。左から右へ、最上段は `0`、`45`、`90`、次の行は `135`、`180`、`270` の角度です。

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

PowerPoint の結果:

![上段の 0°, 45°, 90° の線形グラデーションと下段の 135°, 180°, 270° の線形グラデーション](linear-gradient-angles.png)

### **シェイプで線形グラデーションをスケールする**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) は [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) を受け取ります。`False` に設定すると形状の比例が変わっても幾何学的なグラデーション角度を維持し、`True` に設定すると幅と高さに合わせてグラデーションがスケールします。スケーリングが有効な場合、非正方形の形状では見える角度が割り当てた角度と異なることがあります。

以下の例では、`45` 度の角度と同じカラー ストップを使用します。左列は `False`、右列は `True` です。各列は上に幅の広い矩形、下に高さの高い矩形を配置します。最初は同じ幅で開始し、2 番目の矩形の幅と高さを変更して、塗りつぶしがサイズ変更にどのように応答するかを示します。

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

PowerPoint の結果（左側はスケーリングが無効、右側は有効）:

![左側でスケーリングが無効、右側で有効の 45° グラデーションを持つ広い矩形と高い矩形の比較](linear-gradient-scaling.png)

スケーリングが無効な場合、対角線の色帯は両方の矩形で同じ向きを保ちます。スケーリングが有効になると、色帯は形状の比例に合わせて伸びます。これにより、テンプレートのグラデーションを別のサイズのシェイプに適応させる際に再現しやすくなります。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリングの設定は線形グラデーションにのみ適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) の塗りつぶしは制御しません。

### **角度とグラデーション方向の組み合わせ**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) は [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) クラスからグラデーション スタイルを選択しますが、数値角度の代替ではありません。線形グラデーションの場合、角度を [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) で設定したまま、コーナー スタイルで色が分布する領域を変更できます。角度やスケーリングを比較する際は方向を変更しないでください。

以下の例では、同じ設定を逆順で適用します。2 つの矩形は同一の外観となり、方向を角度の前後で設定しても結果は変わりません。

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

## **パターン塗りつぶし**

パターン塗りつぶしは、点やストライプ、チェックなどの 2 色デザインを適用します。この例では、[IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) を使用してトレリス パターンを選択します。[IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) で薄いグレーの背景色を、[IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) で黄色のパターン色を指定します。

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

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしはシェイプ内に画像を使用します。この例ではローカル画像が必要で、[Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) を使用してプレゼンテーションの画像コレクションに読み込みます。[IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) をタイル モードに設定すると、矩形内で画像が繰り返し表示されます。使用した元画像は以下です：

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

![画像塗りつぶしのシェイプ](picture-fill.png)

### **タイル画像をテクスチャとして設定**

タイル画像をテクスチャとして使用し、タイル動作をカスタマイズするには、[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます：

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 画像塗りつぶしモードを設定します（`Tile` または `Stretch`）。
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): タイルの配置をシェイプ内で指定します。
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): シェイプの基点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): シェイプの基点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールを百分率で定義します。
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールを百分率で定義します。

この例ではローカル画像が必要で、[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) を構成して元画像の 50% のサイズで繰り返します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向のフリップで繰り返しテクスチャの配置を決定します。

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

単色塗りつぶしはシェイプに単一の均一な色を付与します。この例では、[IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して単色塗りつぶしモードを選択し、[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) で黄色を割り当て、矩形をプレゼンテーションに保存します。

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

![単色塗りつぶしのシェイプ](solid-color-fill.png)

## **スライド背景をシェイプの塗りつぶしとして使用**

シェイプをスライド背景に合わせる必要がある場合（例：テンプレート）は、[IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) を使用します。最初に [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) に [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) を指定して明示的な塗りつぶしを削除します。この組み合わせにより、シェイプはスタイル塗りつぶしではなくスライド背景を使用します。フラグだけを有効にしても既存の明示的な塗りつぶしは削除されません。

[FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) とは異なり、背景塗りつぶしはシェイプの背後にあるオブジェクトをスライド背景の該当領域で覆いますが、NoFill はそれらのオブジェクトを表示したままにします。グラデーションはシェイプ内で再開せず、スライド全体に合わせて配置されます。

以下の例では、マスタ背景をスライドが継承し、3 つの矩形の背後にマゼンタ バンドを配置します。左の矩形は背景を使用し、中央は塗りつぶしなし、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

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

    // このオブジェクトを最初に追加して、矩形の背面に表示されるようにします。
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

    // 明示的な塗りつぶしを適用する前に背景塗りつぶしを無効にします。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（左から右へ）: **background fill**、**no fill**、**explicit fill**。マゼンタ バンドは左と右の矩形で隠れますが、中央の矩形では可視のままです。

![背景塗りつぶし、塗りつぶしなし、明示的なオレンジ塗りつぶしがマゼンタバンド上にある様子](background-fill.png)

同様の動作はスライドに直接定義された背景やレイアウトから継承された背景にも適用されます。シェイプはスライドの解決済み背景を使用します。例ではスライドとレイアウトの背景を未定義にし、マスタが背景を供給するようにしています。

## **透明度の設定**

単色塗りつぶしの場合、カラーのアルファ成分が不透明度を制御します。0 が完全に透明、255 が完全に不透明です。この例ではアルファ値 128 の黄色の矩形を使用し、約 50% 透明にして下の矩形が見えるようにします。カラーは [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) で割り当てます。

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

![透明なシェイプ](shape-transparency.png)

## **シェイプの回転**

[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) を使用して、スライド平面内でシェイプを回転させます。角度は度で測定され、この例では矩形を時計回りに 5 度回転させてプレゼンテーションを保存します。

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

[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を使用してシェイプに奥行きとベベルされたエッジを付与します。この例では緑の楕円にオレンジの輪郭を付け、[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) で深さを 4 ポイントに設定し、[IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) で幅と高さが 6 ポイントの円形トップベベルを適用します。正面オーソグラフィック カメラと 3 点照明によりベベルが可視化されます。

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

シェイプの 3D 表示はカメラ設定で制御されます。この例では、[ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) に緯度 40 度、経度 35 度、回転 20 度を指定します。[ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) で等角投影カメラを選択し、[ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) でバランスの取れた照明を設定して、書式設定した矩形を保存します。

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

## **シェイプの白黒レンダリング制御**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) メソッドは、プレゼンテーションが白黒モードで表示または処理されたときに個々のシェイプがどのようにレンダリングされるかを指定します。このメソッドだけで白黒表示が有効になるわけではなく、通常のカラー表示時のシェイプの塗り、線、その他の書式設定は変更されません。

[BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。例：`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレイ カラー、`BlackWhite` は黒と白のみ、`Black` と `White` は単一カラー、`Color` は通常のカラーを保持、`Hidden` は白黒モードでシェイプを除外します。`NotDefined` はシェイプレベルのモードが未設定であることを意味します。

この例ではオレンジの矩形を作成し、[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) でグレイ カラーを選択します。保存されたシェイプは通常カラー表示ではオレンジの塗りを保持し、白黒表示設定を尊重するアプリケーションではグレイ カラーとして表示されます。

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

通常カラー表示では矩形はオレンジの塗りを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレイ カラーで表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど白黒設定を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

[ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) を使用して、スライド プレースホルダーの位置、サイズ、書式設定を対応するレイアウト プレースホルダーから復元します。この例では、レイアウトにリンクされたプレースホルダーがある既存のプレゼンテーションが必要で、保存前にすべてのスライドをリセットします。対応するレイアウト プレースホルダーがないシェイプはリセットされません。

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

**シェイプの書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

カラーや線スタイル、効果設定は、埋め込み画像やメディアに比べてデータ量がほとんど増えません。画像塗りつぶしは画像がプレゼンテーションに保存されるため、ファイルサイズが増加する可能性があります。

**同一の書式設定を共有しているスライド上のシェイプを検出してグループ化するにはどうすればよいですか？**

シェイプごとの主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化して後のスタイル管理を簡素化できます。

**カスタムシェイプスタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプルシェイプをテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイル付きシェイプをクローンして、必要な場所で書式設定を再適用します。