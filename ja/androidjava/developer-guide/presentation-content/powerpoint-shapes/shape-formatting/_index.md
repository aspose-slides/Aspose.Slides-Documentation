---
title: 形の書式設定
type: docs
weight: 20
url: /androidjava/shape-formatting/
keywords: "形状の書式設定, 線の書式設定, ジョインスタイルの書式設定, グラデーション塗りつぶし, パターン塗りつぶし, 画像塗りつぶし, 単色塗りつぶし, 形状の回転, 3D ベベル効果, 3D 回転効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでのPowerPointプレゼンテーションにおける形状の書式設定"
---

PowerPointでは、スライドに形状を追加できます。形状は線で構成されているため、形状の構成要素である線の修正や特定の効果の適用によって、形状を格式設定できます。加えて、形状の内部エリアがどのように塗りつぶされるかを決定する設定を指定することで、形状をも格式設定できます。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Android via Java** では、PowerPointの既知のオプションに基づいて形状を格式設定できるインターフェースとプロパティを提供します。

## **線の書式設定**

Aspose.Slidesを使用すると、形状の好みの線スタイルを指定できます。手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 形状の線の色を設定します。
5. 形状の線の幅を設定します。
6. 形状の線の[line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle)を設定します。
7. 形状の線の[dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle)を設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、長方形の `AutoShape` を格式設定した操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 長方形形状の塗りつぶし色を設定
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // 長方形の線にいくつかの書式設定を適用
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 長方形の線の色を設定
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ジョインスタイルの書式設定**
以下が3つのジョインタイプのオプションです：

* ラウンド
* ミター
* ベベル

デフォルトでは、PowerPointは2本の線を角度でジョインするときに**ラウンド**設定を使用します。ただし、非常に鋭角な形状を描画したい場合は、**ミター**を選択することをお勧めします。

![join-style-powerpoint](join-style-powerpoint.png)

このJavaでは、ミター、ベベル、ラウンドのジョインタイプ設定で3つの長方形を作成した操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 3つの長方形オートシェイプを追加
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // 長方形形状の塗りつぶし色を設定
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 線の幅を設定
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // 長方形の線の色を設定
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // ジョインスタイルを設定
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 各長方形にテキストを追加
    ((IAutoShape)shp1).getTextFrame().setText("ミタージョインスタイル");
    ((IAutoShape)shp2).getTextFrame().setText("ベベルジョインスタイル");
    ((IAutoShape)shp3).getTextFrame().setText("ラウンドジョインスタイル");

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **グラデーション塗りつぶし**
PowerPointのグラデーション塗りつぶしは、形状に連続的な色のブレンドを適用する書式設定オプションです。例えば、ある色が徐々に別の色に変わるように、2色以上を適用します。

これが、Aspose.Slidesを使用して形状にグラデーション塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 形状の[FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)を`Gradient`に設定します。
5. `GradientFormat`クラスに関連する`GradientStops`コレクションで定義された位置を持つ2つの好みの色を`Add`メソッドを使用して追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、楕円にグラデーション塗りつぶし効果を使用した操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円のオートシェイプを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 楕円にグラデーションの書式設定を適用
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // グラデーションの方向を設定
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 2つのグラデーションストップを追加
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTXファイルをディスクに書き込み
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **パターン塗りつぶし**
PowerPointのパターン塗りつぶしは、形状にドット、ストライプ、交差、またはチェックの2色デザインを適用する書式設定オプションです。また、パターンの前景色と背景色を選択できます。

Aspose.Slidesは、形状を格式設定しプレゼンテーションを豊かにするために使用できる45以上の事前定義されたスタイルを提供します。事前定義されたパターンを選択した後でも、パターンに含まれる色を指定できます。

これが、Aspose.Slidesを使用して形状にパターン塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 形状の[FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)を`Pattern`に設定します。
5. 形状のための好みのパターンスタイルを設定します。
6. [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat)の[背景色](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--)を設定します。
7. [前景色](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--)を[PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat)に設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、長方形を美しくするためにパターン塗りつぶしを使用した操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプをパターンに設定
    shp.getFillFormat().setFillType(FillType.Pattern);

    // パターンスタイルを設定
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // パターンの背景色と前景色を設定
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像塗りつぶし**
PowerPointの画像塗りつぶしは、形状内に画像を配置する書式設定オプションです。基本的に、形状の背景として画像を使用できます。

これが、Aspose.Slidesを使用して形状に画像を塗りつぶす方法です：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 形状の[FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)を`Picture`に設定します。
5. 画像塗りつぶしモードをタイルに設定します。
6. 形状を塗りつぶすために使用する画像を利用して`IPPImage`オブジェクトを作成します。
7. `PictureFillFormat`オブジェクトの`Picture.Image`プロパティを最近作成した`IPPImage`に設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、形状に画像を塗りつぶす方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // 塗りつぶしタイプを画像に設定
    shp.getFillFormat().setFillType(FillType.Picture);

    // 画像塗りつぶしモードを設定
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 画像を設定
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **単色塗りつぶし**
PowerPointの単色塗りつぶしは、形状を単一の色で塗りつぶす書式設定オプションです。選択した色は通常、平面的な色です。色は形状の背景に適用され、特別な効果や修正が加えられます。

これが、Aspose.Slidesを使用して形状に単色塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 形状の[FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)を`Solid`に設定します。
5. 形状のための好みの色を設定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、PowerPointでボックスに単色塗りつぶしを適用する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプを単色に設定
    shape.getFillFormat().setFillType(FillType.Solid);

    // 長方形の色を設定
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **透明度の設定**

PowerPointでは、形状に単色、グラデーション、画像、またはテクスチャで塗りつぶす際に、塗りつぶしの透明度レベルを指定できます。これにより、例えば低い透明度レベルを設定すると、形状の後ろにあるスライドオブジェクトや背景が透けて見えます。

Aspose.Slidesでは、以下の方法で形状の透明度レベルを設定できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. アルファコンポーネントを設定した`new Color`を使用します。
5. オブジェクトをPowerPointファイルとして保存します。

このJavaコードは、そのプロセスを示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ソリッドシェイプを追加
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // ソリッドシェイプの上に透明なシェイプを追加
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // PPTXファイルをディスクに書き込み
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状を回転させる**
Aspose.Slidesを使用すると、スライドに追加した形状を以下のように回転させることができます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
4. 必要な度数で形状を回転させます。
5. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、形状を90度回転させる方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 形状を90度回転させる
    shp.setRotation(90);

    // PPTXファイルをディスクに書き込み
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D ベベル効果の追加**
Aspose.Slidesを使用すると、[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)プロパティを変更することにより、形状に3Dベベル効果を追加できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
3. 形状の[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)プロパティに対する好みのパラメータを設定します。
4. プレゼンテーションをディスクに書き込みます。

このJavaコードは、形状に3Dベベル効果を追加する方法を示しています：

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // スライドに形状を追加
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 形状のThreeDFormatプロパティを設定
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // プレゼンテーションをPPTXファイルとして書き込み
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **3D回転効果の追加**
Aspose.Slidesでは、[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)プロパティを変更することにより、形状に3D回転効果を適用できます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)を追加します。
3. [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--)と[LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--)に対する好みの値を指定します。
4. プレゼンテーションをディスクに書き込みます。

このJavaコードは、形状に3D回転効果を適用する方法を示しています：

```java
// プレゼンテーションクラスのインスタンスを作成
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

    // プレゼンテーションをPPTXファイルとして書き込み
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **書式設定のリセット**

このJavaコードは、スライドのプレースホルダーを持つ各形状の位置、サイズ、および書式設定を元に戻して、[LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide)で書式設定をリセットする方法を示しています：

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // レイアウトのプレースホルダーを持つスライド上の各形状が元に戻される
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```