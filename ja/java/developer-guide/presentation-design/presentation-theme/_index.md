---
title: "Java でプレゼンテーションテーマを管理する"
linktitle: "プレゼンテーションテーマ"
type: docs
weight: 10
url: /ja/java/presentation-theme/
keywords:
  - "PowerPoint テーマ"
  - "プレゼンテーションテーマ"
  - "スライドテーマ"
  - "テーマの設定"
  - "テーマの変更"
  - "テーマの管理"
  - "テーマカラー"
  - "追加パレット"
  - "テーマフォント"
  - "テーマスタイル"
  - "テーマ効果"
  - "PowerPoint"
  - "OpenDocument"
  - "プレゼンテーション"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Java でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **イントロダクション**

プレゼンテーションテーマはデザイン要素のプロパティを定義します。テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んだことになります。

PowerPoint では、テーマは色、[fonts](/slides/ja/java/powerpoint-fonts/)、[background styles](/slides/ja/java/presentation-background/)、および効果で構成されます。

![テーマの構成要素](theme-constituents.png)

## **テーマの色を変更する**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SchemeColor) 列挙体の値を提供します。

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

次のようにして、結果となるカラーの実際の値を取得できます：

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

カラー変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマ内のカラーを変更します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

新しいカラーは両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

メインテーマカラー (1) に輝度変換を適用すると、追加パレット (2) のカラーが生成されます。これらのテーマカラーを取得および設定できます。

![追加パレットのカラー](additional-palette-colors.png)

**1** - メインテーマカラー  

**2** - 追加パレットのカラー

この Java コードは、メインテーマカラーから取得した追加パレットのカラーをシェイプで使用する操作をデモンストレーションします：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // アクセント 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // アクセント 4、明度 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント 4、明度 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント 4、明度 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント 4、暗度 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4、暗度 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` を `IColorScheme` のカラーにマップする**

[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません：

`Background1`、`Background2`、`Text1`、`Text2`。

しかし、`Presentation.getMasterTheme().getColorScheme()` は [IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) を返し、対応するカラーとして次を公開します：

`Dark1`、`Dark2`、`Light1`、`Light2`。

この違いは名前だけです。これらの値は同じテーマカラー スロットを指しており、マッピングは固定されています：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。同じテーマカラーの別名にすぎません。

この名前の違いは Microsoft Office の用語に由来します。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用され、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントを変更する**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるものと同様の特殊識別子を使用します：

* **+mn-lt** - 本文フォント ラテン文字 (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン文字 (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア文字 (Minor East Asian Font)
* **+mj-ea** - 見出しフォント 東アジア文字 (Major East Asian Font)

この Java コードは、ラテン文字フォントをテーマ要素に割り当てる方法を示しています：

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

すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="info" title="TIP" %}} 
PowerPoint のフォントについては、[PowerPoint fonts](/slides/ja/java/powerpoint-fonts/) を参照してください。 
{{% /alert %}}

## **テーマの背景スタイルを変更する**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうちの 3 つだけです。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の Java コードを実行すると、プレゼンテーションに含まれる事前定義背景の数を確認できます：

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
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを、[FormatScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme) クラスから使用すると、PowerPoint テーマ内の背景スタイルを追加または取得できます。 
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

**インデックス ガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="info" title="TIP" %}} 
PowerPoint の背景については、[PowerPoint Background](/slides/ja/java/presentation-background/) をご覧ください。 
{{% /alert %}}

## **テーマ効果を変更する**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果（subtle、moderate、intense）に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FormatScheme#getEffectStyles--)）を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

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

結果として得られる塗りカラー、塗りタイプ、影効果などの変更は以下のとおりです：

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### テーマをマスターを変更せずに単一のスライドに適用できますか？

はい。Aspose.Slides はスライド レベルのテーマ オーバーライドをサポートしているため、マスターテーマを保持したまま、そのスライドだけにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidethememanager/) 経由）。

### プレゼンテーション間でテーマを安全に持ち運ぶ方法は？

[Clone slides](/slides/ja/java/clone-slides/) をマスターとともにターゲット プレゼンテーションにコピーします。これにより、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

### 継承とオーバーライドのすべての後の「実効」値を確認するには？

テーマ/カラー/フォント/効果の ["effective" views](/slides/ja/java/shape-effective-properties/) API を使用します。これらはマスターとローカル オーバーライドを適用した後の最終的に解決されたプロパティを返します。