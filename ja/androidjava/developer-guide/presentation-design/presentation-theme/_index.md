---
title: Android でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/androidjava/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides のプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んでいることになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/androidjava/powerpoint-fonts/)、[背景スタイル](/slides/ja/androidjava/presentation-background/)、および効果で構成されます。

![テーマの構成要素](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるよう、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SchemeColor) 列挙体で値を提供しています。

この Java コードは、テーマのアクセントカラーを変更する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

この方法で、結果となる色の実効値を判定できます：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

色変更操作をさらに示すために、別の要素を作成し、（最初の操作で取得した）アクセントカラーを割り当てます。その後、テーマ内の色を変更します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー（1）に輝度変換を適用すると、追加パレット（2）から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![追加パレットの色](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - 追加パレットの色  

この Java コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // アクセント 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // アクセント 4、明るさ 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント 4、明るさ 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント 4、明るさ 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント 4、暗さ 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4、暗さ 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` を `IColorScheme` のカラーにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) を使用すると、次のテーマカラーの値が含まれていることに気付くかもしれません：

`Background1`, `Background2`, `Text1`, `Text2`.

しかし、`Presentation.getMasterTheme().getColorScheme()` は [IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) を返し、対応するカラーを次のように公開します：

`Dark1`, `Dark2`, `Light1`, `Light2`.

この差異は名前だけです。これらの値は同じテーマカラーのスロットを指しており、マッピングは固定されています：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。単に同じテーマカラーの別名です。

この命名の違いは Microsoft Office の用語から来ています。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用されていましたが、最新の UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるよう、Aspose.Slides は以下の特殊な識別子（PowerPoint で使用されるものと同様）を使用します。

* **+mn-lt** - 本文フォント ラテン文字 (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン文字 (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア文字 (Minor East Asian Font)
* **+mj-ea** - 見出しフォント 東アジア文字 (Major East Asian Font)

この Java コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

この Java コードは、プレゼンテーションのテーマフォントを変更する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="info" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/androidjava/powerpoint-fonts/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 個の事前定義された背景を提供しますが、典型的なプレゼンテーションではそのうち 3 つのみが保存されます。

![プレゼンテーション デザイン 8](presentation-design_8.png)

例として、PowerPoint アプリでプレゼンテーションを保存した後、次の Java コードを実行してプレゼンテーションに含まれる事前定義背景の数を確認できます：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを [FormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme) クラスから使用することで、PowerPoint テーマ内の背景スタイルを追加または取得できます。 
{{% /alert %}} 

この Java コードは、プレゼンテーションの背景を設定する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**インデックスガイド**: 0 は塗りなしに使用されます。インデックスは 1 から始まります。

{{% alert color="info" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/androidjava/presentation-background/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint テーマは通常、各スタイル配列に対して 3 つの値を持ちます。その配列は 3 つの効果（微妙、標準、強烈）に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです。

![プレゼンテーション デザイン 10](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--) の 3 つのプロパティを [FormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FormatScheme) クラスから使用すると、テーマ内の要素を変更できます（PowerPoint のオプションよりも柔軟に）。

この Java コードは、要素の一部を変更してテーマ効果を変更する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

結果として、塗りの色、塗りタイプ、影効果などが変化します。

![プレゼンテーション デザイン 11](presentation-design_11.png)

## **よくある質問**

### マスターを変更せずに単一スライドにテーマを適用できますか？

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままにして、そのスライドだけにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidethememanager/) を使用）。

### テーマをあるプレゼンテーションから別のプレゼンテーションへ安全に引き継ぐ最善の方法は何ですか？

[スライドのクローン](/slides/ja/androidjava/clone-slides/) とマスターを対象のプレゼンテーションにコピーすると、安全にテーマを引き継げます。これにより、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

### 継承とオーバーライド後の「実効」値を確認するには？

API の ["effective" ビュー](/slides/ja/androidjava/shape-effective-properties/)（テーマ/カラー/フォント/効果）を使用してください。これらは、マスターとローカルオーバーライドを適用した後の解決済みの最終プロパティを返します。