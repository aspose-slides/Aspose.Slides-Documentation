---
title: JavaScript で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/nodejs-java/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 表示効果
- グロー効果
- WordArt 変形
- 3D 効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js で WordArt 効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者がプロフェッショナルなテキストでプレゼンテーションを向上させるのに役立ちます。"
---

## **WordArt について**

WordArt（または Word Art）は、テキストに効果を適用して目立たせる機能です。WordArt を使用すると、テキストに輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D 効果を追加したりできます。また、テキストの形状を歪めたり、曲げたり、伸縮させることもできます。 

{{% alert color="primary" %}} 
WordArt は、テキストをグラフィックオブジェクトのように扱うことができます。一般的に、WordArt はテキストをより魅力的または目立たせるために加える効果や特別な変更で構成されています。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用される効果のセットです。 

**Aspose.Slides の WordArt**

In Aspose.Slides for Node.js via Java 20.10 we implemented support for WordArt and made improvements to the feature in subsequent Aspose.Slides for Node.js via Java releases.

Aspose.Slides for Node.js via Java を使用すると、JavaScript で簡単に独自の WordArt テンプレート（単一の効果または効果の組み合わせ）を作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートの作成とテキストへの適用**

**Aspose.Slides の使用** 

まず、この JavaScript コードを使用してシンプルなテキストを作成します：
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

次に、効果がより目立つようにテキストのフォント高さを大きく設定します。以下のコードを使用します：
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint の使用**

Microsoft PowerPoint の WordArt 効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。 

以下は利用可能なパラメータまたはオプションの一部です：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、以下のコードで幅 1 の黒いテキスト枠線を追加します：
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

**Microsoft PowerPoint の使用**

プログラムのクラスから、テキスト、テキストブロック、シェイプ、または類似の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

例えば、Shadow、Reflection、Glow の効果はテキストに適用でき、3D Format と 3D Rotation の効果はテキストブロックに適用でき、Soft Edges プロパティは Shape オブジェクトに適用できます（3D Format プロパティが設定されていなくても効果があります）。

### **影効果の適用**

ここでは、テキストに関連するプロパティのみを設定することを意図しています。以下の JavaScript コードでテキストに影効果を適用します：
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


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。  
PresetShadow を使用すると、プリセット値でテキストに影を適用できます。

**Microsoft PowerPoint の使用**

PowerPoint では、1 種類の影を使用できます。例を示します：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides は、実際に InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。  
- OuterShadow と InnerShadow を同時に使用した場合、結果として適用される効果は PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 では効果が二重になりますが、PowerPoint 2007 では OuterShadow の効果が適用されます。

### **テキストへのディスプレイ効果の適用**

以下の JavaScript コードサンプルでテキストにディスプレイ効果を追加します：
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


### **テキストへのグロー効果の適用**

以下のコードでテキストにグロー効果を適用し、光らせたり目立たせたりします：
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、ディスプレイ、グローのパラメータは変更可能です。効果のプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **WordArt の変形の使用**

以下のコードで、テキスト全体に備わっている Transform プロパティを使用します：
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Node.js via Java の両方が、いくつかの事前定義された変形タイプを提供しています。 
{{% /alert %}} 

**PowerPoint の使用**  
事前定義された変形タイプにアクセスするには、**Format** -> **TextEffect** -> **Transform** の順に進みます。  

**Aspose.Slides の使用**  
変形タイプを選択するには、TextShapeType 列挙体を使用します。  

### **テキストとシェイプへの 3D 効果の適用**

以下のサンプルコードでテキストシェイプに 3D 効果を設定します：
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


結果のテキストとそのシェイプ：

![todo:image_alt_text](image-20200930114816-9.png)

以下の JavaScript コードでテキストに 3D 効果を適用します：
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


操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストやそのシェイプへの 3D 効果の適用および効果間の相互作用は、特定のルールに基づいています。

テキストとそれを含むシェイプのシーンを考慮します。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されたシーンを含みます。

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。  
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。  
- それ以外の場合、元々シェイプに 3D 効果がない場合、シェイプは平面で、3D 効果はテキストのみに適用されます。

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **テキストへの外部影効果の適用**

Aspose.Slides for Node.js via Java は、[**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/) および [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/innershadow/) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) に含まれるテキストに影効果を適用できます。以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに矩形タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを作成します。  
7. 影の BlurRadius を設定します。  
8. 影の Direction を設定します。  
9. 影の Distance を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. 影の PresetColor を Black に設定します。  
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。  

上記の手順を実装した Java のサンプルコードは、テキストに外部影効果を適用する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // スライドの参照を取得する
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加する
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 矩形に TextFrame を追加する
    ashp.addTextFrame("Aspose TextBox");
    // テキストの影を取得できるように、シェイプの塗りつぶしを無効にする
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 外部影を追加し、すべての必要なパラメータを設定する
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // プレゼンテーションをディスクに書き込む
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプへの内部影効果の適用**

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメータを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  

上記の手順に基づくこのサンプルコードは、JavaScript で 2 つのシェイプ間にコネクタを追加する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // スライドの参照を取得する
    var slide = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 矩形に TextFrame を追加する
    ashp.addTextFrame("Aspense TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // InnerShadowEffect を有効にする
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // 必要なすべてのパラメータを設定する
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType を Scheme に設定する
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme カラーを設定する
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // プレゼンテーションを保存する
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）で WordArt 効果を使用できますか？**

はい、Aspose.Slides は Unicode をサポートし、主要なフォントやスクリプトすべてで動作します。影、塗り、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性やレンダリングはシステムフォントに依存する場合があります。

**スライドマスタ要素に WordArt 効果を適用できますか？**

はい、タイトルプレースホルダー、フッター、背景テキストなど、マスタースライド上のシェイプに WordArt 効果を適用できます。マスターのレイアウトに加えた変更は、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

わずかに。影、グロー、グラデーション塗りなどの WordArt 効果は、追加の書式メタデータによりファイルサイズが若干増加する可能性がありますが、差は通常ほとんど無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) または [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) クラスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。