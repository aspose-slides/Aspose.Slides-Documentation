---
title: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/nodejs-java/3d-presentation/
---

## **概要**

Aspose.Slides for Java 20.9 以降、プレゼンテーションで 3D を作成できるようになりました。PowerPoint 3D はプレゼンテーションに命を吹き込む手段です。実際のオブジェクトを 3D プレゼンテーションで表示したり、将来のビジネスプロジェクトの 3D モデル、建物やインテリアの 3D モデル、ゲームキャラクターの 3D モデル、あるいはデータの 3D 表現を示したりできます。

PowerPoint 3D モデルは 2D シェイプから作成でき、次のようなエフェクトを適用します：3D 回転、3D 深さと押し出し、3D グラデーション、3D テキストなど。シェイプに適用できる 3D 機能の一覧は **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** クラスで確認できます。クラスのインスタンスは以下で取得します。

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** メソッドで PowerPoint 3D モデルを作成します。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** メソッドで 3D テキスト（WordArt）を作成します。

**[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** に実装されているすべてのエフェクトはシェイプとテキストの両方で使用できます。次に **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** クラスの主なメソッドをざっと見てみましょう。以下の例では、テキストを含む矩形の 2D シェイプを作成し、シェイプに対してカメラビューを取得して回転させ、3D モデルのように見せます。フラットライトとその方向を 3D モデルの上部に設定して、モデルにボリュームを持たせます。素材、押し出し高さ、色を変更することで、3D モデルがより生き生きとします。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


以下は生成された 3D モデルです：

![todo:image_alt_text](img_01_01.png)

## **3D 回転**

PowerPoint での 3D モデルの回転はメニューから行えます：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API で 3D モデルを回転させるには、**[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)** メソッドを使用し、カメラの回転を 3D シェイプに対して相対的に設定します：
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... 他の3Dシーンパラメータを設定
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **3D 深さと押し出し**

**[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** および **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** メソッドを使用してシェイプに押し出しを作成します：
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... 他の3Dシーンパラメータを設定
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


PowerPoint では、シェイプの深さは次のように設定します：

![todo:image_alt_text](img_02_02.png)

## **3D グラデーション**

3D グラデーションは PowerPoint 3D シェイプにボリューム感を与えます：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


実際の見た目は次のとおりです：

![todo:image_alt_text](img_02_03.png)
  
画像グラデーションも作成できます：
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. 3D 設定: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* プロパティ
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


結果は以下の通りです：

![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**

3D テキスト（WordArt）を作成する手順は次のとおりです：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // "Arch Up" WordArt の変形効果を設定
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


結果は以下のとおりです：

![todo:image_alt_text](img_02_05.png)

## **よくある質問**

**プレゼンテーションを画像／PDF／HTML にエクスポートするときに 3D エフェクトは保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式（[画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/)、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) など）へのエクスポート時に 3D エフェクトをレンダリングします。

**テーマや継承などを考慮した「実効」(最終) の 3D パラメータ値を取得できますか？**

はい。Slides は [実効値を読み取る](/slides/ja/nodejs-java/shape-effective-properties/) API を提供しており、3D の照明やベベルなどを含む最終的に適用された設定を確認できます。

**プレゼンテーションを動画に変換するときに 3D エフェクトは機能しますか？**

はい。動画用フレームを生成する際（[動画への変換](/slides/ja/nodejs-java/convert-powerpoint-to-video/)）、3D エフェクトはエクスポートされた画像と同様にレンダリングされます。