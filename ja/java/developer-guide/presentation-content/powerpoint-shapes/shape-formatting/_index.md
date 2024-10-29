---
title: 形状の書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
keywords: "形状の書式設定, 線の書式設定, 結合スタイルの書式設定, グラデーション塗りつぶし, パターン塗りつぶし, 画像の塗りつぶし, 単色塗りつぶし, 形状の回転, 3D ベベル効果, 3D 回転効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションの形状をフォーマットする"
---

PowerPointでは、スライドに形状を追加することができます。形状は線で構成されているため、構成する線に特定の効果を変更または適用することで形状をフォーマットできます。さらに、形状がどのように塗りつぶされるかを決定する設定を指定することで形状をフォーマットできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Java** は、PowerPointの既知のオプションに基づいて形状をフォーマットするためのインターフェースとプロパティを提供します。

## **線の書式設定**

Aspose.Slidesを使用して、形状の好ましい線スタイルを指定できます。以下はその手順です。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の線の色を設定します。
5. 形状の線の幅を設定します。
6. 形状線の [線スタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) を設定します。
7. 形状線の [ダッシュスタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) を設定します。 
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、長方形の `AutoShape` をフォーマットする操作を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 長方形の形状の塗りつぶし色を設定する
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // 長方形の線に対していくつかの書式設定を適用する
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 長方形の線の色を設定する
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **結合スタイルの書式設定**
これらは3つの結合タイプのオプションです：

* ラウンド
* ミッター
* ベベル

デフォルトでは、PowerPointは角度で2つの線を結合するとき（または形状の隅で）、**ラウンド** 設定を使用します。 ただし、非常に鋭い角度を持つ形状を描くことを望んでいる場合は、**ミッター**を選択した方が良いかもしれません。

![join-style-powerpoint](join-style-powerpoint.png)

このJavaコードは、ミッター、ベベル、ラウンド結合スタイルの設定で3つの長方形（上の画像）を作成する操作を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 3つの長方形オートシェイプを追加する
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // 長方形の形状の塗りつぶし色を設定する
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 線の幅を設定する
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // 長方形の線の色を設定する
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 結合スタイルを設定する
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 各長方形にテキストを追加する
    ((IAutoShape)shp1).getTextFrame().setText("ミッター結合スタイル");
    ((IAutoShape)shp2).getTextFrame().setText("ベベル結合スタイル");
    ((IAutoShape)shp3).getTextFrame().setText("ラウンド結合スタイル");

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **グラデーション塗りつぶし**
PowerPointでは、グラデーション塗りつぶしは、形状に連続した色のブレンドを適用する書式設定オプションです。たとえば、一方の色が徐々に別の色に変わる設定で、2つ以上の色を適用することができます。

以下は、Aspose.Slidesを使用して形状にグラデーション塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) を `Gradient` に設定します。
5. `GradientFormat` クラスに関連付けられた `GradientStops` コレクションによって公開された `Add` メソッドを使用して、定義された位置を持つ2つの好ましい色を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、楕円にグラデーション塗りつぶし効果を使用する操作を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円オートシェイプを追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 楕円にグラデーション書式を適用する
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // グラデーションの方向を設定する
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 2つのグラデーションストップを追加する
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTXファイルをディスクに書き込む
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **パターン塗りつぶし**
PowerPointでは、パターン塗りつぶしは、形状にドット、ストライプ、クロスハッチ、チェックの2色デザインを適用する書式設定オプションです。さらに、パターンの前景と背景に好きな色を選択することができます。

Aspose.Slidesは、形状をフォーマットし、プレゼンテーションを豊かにするために使用できる45を超える事前定義されたスタイルを提供します。事前定義されたパターンを選択した後でも、パターンが含むべき色を指定することができます。

以下は、Aspose.Slidesを使用して形状にパターン塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) を `Pattern` に設定します。
5. 形状の好きなパターンスタイルを設定します。 
6. [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat) の [背景色](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) を設定します。
7. [前景色](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) を [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat) に設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、長方形を装飾するためにパターン塗りつぶしを使用する操作を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形オートシェイプを追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプをパターンに設定する
    shp.getFillFormat().setFillType(FillType.Pattern);

    // パターンスタイルを設定する
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // パターンの背景色と前景色を設定する
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像塗りつぶし**
PowerPointでは、画像塗りつぶしは、形状の内部に画像を配置する書式設定オプションです。つまり、形状の背景として画像を使用することができます。

以下は、Aspose.Slidesを使用して画像で形状を塗りつぶす方法です：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) を `Picture` に設定します。
5. 画像塗りつぶしモードをタイルに設定します。
6. 形状を塗りつぶすために使用される画像を使用して `IPPImage` オブジェクトを作成します。
7. `PictureFillFormat` オブジェクトの `Picture.Image` プロパティを最近作成した `IPPImage` に設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、形状を画像で塗りつぶす方法を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形オートシェイプを追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // 塗りつぶしタイプを画像に設定する
    shp.getFillFormat().setFillType(FillType.Picture);

    // 画像塗りつぶしモードを設定する
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 画像を設定する
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **単色塗りつぶし**
PowerPointでは、単色塗りつぶしは、形状を単一の色で塗りつぶす書式設定オプションです。選択した色は一般的にプレーンな色です。この色は、特別な効果や変更なしに形状の背景に適用されます。

以下は、Aspose.Slidesを使用して形状に単色塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) を `Solid` に設定します。
5. 形状のための好ましい色を設定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、PowerPointのボックスに単色塗りつぶしを適用する方法を示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);

    // 長方形オートシェイプを追加する
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプを単色に設定する
    shape.getFillFormat().setFillType(FillType.Solid);

    // 長方形の色を設定する
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **透明度の設定**

PowerPointでは、形状の塗りつぶしに単色、グラデーション、画像、またはテクスチャを使用する場合、塗りつぶしの不透明度を決定する透明度レベルを指定できます。これにより、たとえば、低い透明度レベルを設定すると、スライドオブジェクトや背景が（形状の後ろに）透けて見えるようになります。

Aspose.Slidesは、次の方法で形状の透明度レベルを設定できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. アルファコンポーネントが設定された `new Color` を使用します。
5. オブジェクトをPowerPointファイルとして保存します。 

このJavaコードはプロセスを示しています。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ソリッドシェイプを追加する
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // ソリッドシェイプの上に透明なシェイプを追加する
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // PPTXファイルをディスクに書き込む
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状の回転**
Aspose.Slidesを使用すると、スライドに追加された形状を次の方法で回転させることができます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 必要な度で形状を回転させます。 
5. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、形状を90度回転させる方法を示します。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形オートシェイプを追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 形状を90度回転させる
    shp.setRotation(90);

    // PPTXファイルをディスクに書き込む
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D ベベル効果の追加**
Aspose.Slidesを使用すると、形状に3Dベベル効果を追加することができます。次のプロパティを変更します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. 形状の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) プロパティに対して好ましいパラメータを設定します。 
5. プレゼンテーションをディスクに保存します。

このJavaコードは、形状に3Dベベル効果を追加する方法を示します。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // スライドに形状を追加する
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 形状の3D形式のプロパティを設定する
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // プレゼンテーションをPPTXファイルとして書き込む
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D 回転効果の追加**
Aspose.Slidesを使用すると、3D回転効果を形状に適用することができます。この方法で以下を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) を追加します。
4. [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) と [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--) に対して好ましい値を指定します。
5. プレゼンテーションをディスクに保存します。 

このJavaコードは、形状に3D回転効果を適用する方法を示します。

```java
// プレゼンテーションクラスのインスタンスを初期化する
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // プレゼンテーションをPPTXファイルとして書き込む
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **書式設定のリセット**

このJavaコードは、スライドの書式設定をリセットし、レイアウトにプレースホルダーを持つすべての形状の位置、サイズ、および書式をデフォルトに戻す方法を示しています。

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // レイアウトにプレースホルダーを持つスライド上の各形状が元に戻されます
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```