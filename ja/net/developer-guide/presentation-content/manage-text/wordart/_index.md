---
title: ワードアート
type: docs
weight: 110
url: /net/wordart/
keywords: "ワードアート, Word Art, ワードアートを作成, ワードアートテンプレート, ワードアート効果, シャドウ効果, 表示効果, グロー効果, ワードアート変換, 3D効果, 外部シャドウ効果, 内部シャドウ効果, C#, Csharp, Aspose.Slides for .NET"
description: "C# または Aspose.Slides for .NET で PowerPoint プレゼンテーションにワードアートと効果を追加、操作、管理します"
---

## **ワードアートとは？**
ワードアートは、テキストに効果を適用して目立たせる機能です。たとえば、ワードアートを使用すると、テキストにアウトラインを付けたり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。 

{{% alert color="primary" %}} 

ワードアートは、テキストをグラフィックオブジェクトとして扱うことを可能にします。ワードアートは、テキストに適用される効果や特別な変更から成り、より魅力的または目立つものになります。 

{{% /alert %}} 

**Microsoft PowerPoint のワードアート**

Microsoft PowerPoint でワードアートを使用するには、あらかじめ定義されたワードアートテンプレートのいずれかを選択する必要があります。ワードアートテンプレートは、テキストまたはその形状に適用される効果のセットです。 

**Aspose.Slides のワードアート**

Aspose.Slides for .NET 20.10 では、ワードアートのサポートを実装し、その後の Aspose.Slides for .NET のリリースで機能を改善しました。 

Aspose.Slides for .NET を使用すると、C# で独自のワードアートテンプレート（1 つの効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。 

## シンプルなワードアートテンプレートの作成とテキストへの適用

**Aspose.Slides を使用する**

まず、次の C# コードを使用してシンプルなテキストを作成します: 

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
次に、テキストのフォントサイズを大きく設定して、次のコードを通じて効果がより目立つようにします:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**Microsoft PowerPoint を使用する**

Microsoft PowerPoint でワードアート効果のメニューにアクセスします:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューからあらかじめ定義されたワードアート効果を選択できます。左のメニューからは新しいワードアートの設定を指定できます。 

利用可能なパラメータまたはオプションの一部は次のとおりです:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides を使用する**

ここでは、次のコードを使用してテキストに SmallGrid パターンカラーを適用し、幅 1 の黒いテキストボーダーを追加します:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

得られたテキスト:

![todo:image_alt_text](image-20200930114108-4.png)

## 他のワードアート効果の適用

**Microsoft PowerPoint を使用する**

プログラムのインターフェイスから、テキスト、テキストブロック、形状、または類似の要素にこれらの効果を適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、シャドウ、反射、グロー効果をテキストに適用することができ、3D形式および3D回転効果はテキストブロックに適用できます。ソフトエッジプロパティはシェイプオブジェクトにも適用できます（3D形式プロパティが設定されていない場合でも効果が残ります）。 

### シャドウ効果の適用

ここでは、テキストに関するプロパティを設定することを目的としています。次の C# コードを使用してテキストにシャドウ効果を適用します:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API は、OuterShadow、InnerShadow、および PresetShadow の 3 種類のシャドウをサポートしています。 

 PresetShadow を使用すると、テキストにシャドウを適用できます（プレセット値を使用）。 

**Microsoft PowerPoint を使用する**

PowerPoint では、1 つの種類のシャドウを使用できます。以下はその例です:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides を使用する**

Aspose.Slides では、実際に InnerShadow と PresetShadow の 2 種類のシャドウを同時に適用できます。

**注:**

- OuterShadow と PresetShadow を一緒に使用すると、OuterShadow 効果だけが適用されます。 
- OuterShadow と InnerShadow を同時に使用すると、適用される効果は PowerPoint のバージョンによって異なります。たとえば、PowerPoint 2013 では効果が二重になりますが、PowerPoint 2007 では OuterShadow 効果が適用されます。 

### テキストへの表示の適用

次の C# コードサンプルを使用して、テキストに表示を追加します:

``` csharp 
portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72; 
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;   
```

### テキストへのグロー効果の適用

次のコードを使用して、テキストにグロー効果を適用して目立たせます:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

操作の結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

シャドウ、表示、グローのパラメータを変更できます。効果のプロパティは、テキストの各部分に個別に設定されます。 

{{% /alert %}} 

### ワードアートでの変換の使用

次のコードを通じて、テキスト全体のブロックに固有の Transform プロパティを使用します:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint と Aspose.Slides for .NET では、あらかじめ定義された特定の変換タイプの数を提供しています。 

{{% /alert %}} 

**PowerPoint を使用する**

あらかじめ定義された変換タイプにアクセスするには、**フォーマット** -> **テキスト効果** -> **変換** を経由します。

**Aspose.Slides を使用する**

変換タイプを選択するには、TextShapeType 列挙型を使用します。 

### テキストや形状への 3D 効果の適用

次のサンプル コードを使用して、テキスト形状に 3D 効果を設定します:

``` csharp 
autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

得られたテキストとその形状:

![todo:image_alt_text](image-20200930114816-9.png)

次の C# コードを使用してテキストにも 3D 効果を適用します:

``` csharp 
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

操作の結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストやその形状への 3D 効果の適用および効果間の相互作用は、特定のルールに基づいています。 

テキストとそのテキストを含む形状のシーンを考慮してください。3D 効果には3Dオブジェクトの表現とそのオブジェクトが配置されたシーンが含まれます。 

- シーンが図とテキストの両方に設定されている場合、図のシーンが優先され、テキストのシーンは無視されます。 
- 図が独自のシーンを持っていないが 3D 表現がある場合、テキストのシーンが使用されます。 
- そうでなければ—形状に元々 3D 効果がない場合—形状は平坦で、3D 効果はテキストのみに適用されます。 

説明は、[ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) および [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera) プロパティに関連しています。

{{% /alert %}} 

## **テキストへの外部シャドウ効果の適用**
Aspose.Slides for .NET では、テキストにシャドウ効果を適用するための [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) および [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) クラスを提供しています。これらの手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形型の AutoShape を追加します。
4. AutoShape に関連付けられた TextFrame にアクセスします。
5. AutoShape の FillType を NoFill に設定します。
6. OuterShadow クラスをインスタンス化します
7. シャドウの BlurRadius を設定します。
8. シャドウの Direction を設定します。
9. シャドウの Distance を設定します。
10. RectangleAlign を TopLeft に設定します。
11. シャドウの PresetColor を Black に設定します。
12. プレゼンテーションを PPTX ファイルとして書き出します。

以下の C# コードサンプル—上記の手順の実装—では、テキストに外部シャドウ効果を適用する方法を示します:

```c#
using (Presentation pres = new Presentation())
{

    // スライドの参照を取得
    ISlide sld = pres.Slides[0];

    // 長方形型の AutoShape を追加
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加
    ashp.AddTextFrame("Aspose TextBox");

    // テキストのシャドウを取得する場合、形状の塗りつぶしを無効にします
    ashp.FillFormat.FillType = FillType.NoFill;

    // 外部シャドウを追加し、必要なすべてのパラメーターを設定します
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    // プレゼンテーションをディスクに保存
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **形状に内部シャドウ効果を適用**
以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 長方形型の AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なすべてのパラメーターを設定します。
6. ColorType を Scheme に設定します。
7. スキームカラーを設定します。
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

以下の C# コードサンプル（上記の手順に基づいて）は、2 つの形状の間にコネクタを追加する方法を示しています:

```c#
using(Presentation presentation = new Presentation())
{
    // スライドの参照を取得
    ISlide slide = presentation.Slides[0];

    // 長方形型の AutoShape を追加
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Rectangle に TextFrame を追加
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // InnerShadowEffect を有効にします    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // 必要なすべてのパラメーターを設定します
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // ColorType を Scheme に設定します
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // スキームカラーを設定します
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // プレゼンテーションを保存
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```