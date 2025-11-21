---
title: WordArt
type: docs
weight: 110
url: /ja/nodejs-java/wordart/
---

## **WordArtとは？**

WordArt（または Word Art）は、テキストにさまざまな効果を適用して目立たせる機能です。たとえば、テキストの輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D 効果を追加したりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 
WordArt は、テキストをグラフィック オブジェクトのように扱うことができます。一般に、WordArt はテキストをより魅力的または目立つようにするための効果や特殊な変更の集合です。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはそのシェイプに適用される効果のセットです。

**Aspose.Slides の WordArt**

Aspose.Slides for Node.js via Java 20.10 で WordArt のサポートを実装し、以降のリリースで機能を改善しました。

Aspose.Slides for Node.js via Java を使用すると、JavaScript で独自の WordArt テンプレート（単一効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートの作成とテキストへの適用**

**Aspose.Slides を使用する場合**

まず、次の JavaScript コードでシンプルなテキストを作成します：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

次に、次のコードでテキストのフォント高さを大きく設定し、効果をより目立たせます：
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint を使用する場合**

PowerPoint の WordArt 効果メニューへ移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側メニューから事前定義された WordArt 効果を選択できます。左側メニューから新しい WordArt の設定を指定できます。

利用可能なパラメータまたはオプションの例：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides を使用する場合**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、次のコードで幅 1 の黒いテキスト枠線を追加します：
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## **その他の WordArt 効果の適用**

**Microsoft PowerPoint を使用する場合**

プログラムのクラスから、テキスト、テキストブロック、シェイプ、または類似の要素に次の効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、Shadow、Reflection、Glow 効果はテキストに、3D Format と 3D Rotation 効果はテキストブロックに、Soft Edges プロパティはシェイプ オブジェクトに適用できます（3D Format が設定されていなくても効果があります）。

### **Shadow 効果の適用**

ここではテキストにのみ関連するプロパティを設定します。次の JavaScript コードでテキストに Shadow 効果を適用します：
```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類のシャドウをサポートしています。

PresetShadow を使用すると、プリセット値でテキストにシャドウを適用できます。

**Microsoft PowerPoint を使用する場合**

PowerPoint では 1 種類のシャドウしか使用できません。以下は例です：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides を使用する場合**

Aspose.Slides は、InnerShadow と PresetShadow の 2 種類のシャドウを同時に適用できます。

**注意点：**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow 効果のみが適用されます。  
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二重になりますが、PowerPoint 2007 では OuterShadow が適用されます。

### **Display 効果の適用**

次の JavaScript サンプルでテキストに Display 効果を追加します：
```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```


### **Glow 効果の適用**

次のコードでテキストに Glow 効果を適用し、光沢を出します：
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Shadow、Display、Glow のパラメータは個別に変更できます。効果のプロパティはテキストの各部分に別々に設定されます。 
{{% /alert %}} 

### **WordArt の変形（Transform）使用**

次のコードでテキストブロック全体に適用される Transform プロパティを使用します：
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Node.js via Java の両方で、事前定義された変形タイプが一定数提供されています。 
{{% /alert %}} 

**PowerPoint を使用する場合**

事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** をたどります。

**Aspose.Slides を使用する場合**

変形タイプの選択には、TextShapeType 列挙体を使用します。

### **テキストとシェイプへの 3D 効果の適用**

次のサンプルコードでテキストシェイプに 3D 効果を設定します：
```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


結果のテキストとシェイプ：

![todo:image_alt_text](image-20200930114816-9.png)

次の JavaScript コードでテキストに 3D 効果を適用します：
```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


操作結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストまたはシェイプへの 3D 効果の適用および効果間の相互作用は、特定の規則に基づいています。テキストとそれを含むシェイプに対するシーンを考慮してください。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されたシーンを含みます。

- シーンがフィギュアとテキストの両方に設定されている場合、フィギュアのシーンが優先され、テキストのシーンは無視されます。  
- フィギュアに独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。  
- それ以外（シェイプに元々 3D 効果がない場合）では、シェイプは平面のままで、3D 効果はテキストのみに適用されます。

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **テキストへの Outer Shadow 効果の適用**

Aspose.Slides for Node.js via Java は、[**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) および [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) に含まれるテキストにシャドウ効果を適用できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに矩形タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを生成します。  
7. シャドウの BlurRadius を設定します。  
8. シャドウの Direction を設定します。  
9. シャドウの Distance を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. シャドウの PresetColor を Black に設定します。  
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順を実装した Java のサンプルコードは、テキストへの外部シャドウ効果の適用方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // スライドの参照を取得します
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加します
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 矩形に TextFrame を追加します
    ashp.addTextFrame("Aspose TextBox");
    // テキストの影を取得したい場合に備えてシェイプの塗りつぶしを無効にします
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 外部シャドウを追加し、すべての必要なパラメータを設定します
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // プレゼンテーションを書き出します
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプへの Inner Shadow 効果の適用**

手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメータを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

以下のサンプルコード（上記手順に基づく）は、JavaScript で 2 つのシェイプ間にコネクタを追加する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // スライドの参照を取得
    var slide = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 矩形に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // InnerShadowEffect を有効化
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // 必要なパラメータをすべて設定
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType を Scheme に設定
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme カラーを設定
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // プレゼンテーションを保存
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）でも WordArt 効果は使用できますか？**

はい。Aspose.Slides は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。Shadow、Fill、Outline などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性やレンダリングはシステムにインストールされているフォントに依存する場合があります。

**スライドマスターの要素にも WordArt 効果を適用できますか？**

はい。マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）にも WordArt 効果を適用できます。マスターのレイアウトを変更すると、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

若干影響します。シャドウ、グロー、グラデーション塗りなどの効果は、追加の書式設定メタデータを伴うためファイルサイズがわずかに増加しますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい。`getImage` メソッド（[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) または [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) クラス）を使用して、WordArt を含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、保存やエクスポートの前にメモリ上または画面上で結果をプレビューできます。