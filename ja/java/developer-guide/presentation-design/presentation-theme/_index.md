---
title: Java でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- 外部テーマ
- THMX
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でマスタープレゼンテーションテーマを作成、カスタマイズ、変換し、一貫したブランディングの PowerPoint ファイルを実現します。"
---
## **導入**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果といった調和したセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが同時に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/)で取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを保持することも可能です。マスターは[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterthememanager/)でプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/)で継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンを通して解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマ コンポーネント: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査すると、外部ソースから取得したプレゼンテーションでエントリ数や内容が異なる場合に特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数をレポートします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。対応するエントリを[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) で変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

矩形は `Accent4` にリンクされたままなので、テーマが変更された後は表示色が赤になります。シェイプ上でスキーム色を直接色に置き換えると、以後の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマ色から明暗のバリエーションを色変換により生成します。Aspose.Slides はこれらの変換を[ColorTransformOperation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマ色と追加パレットから生成された明暗色](additional-palette-colors.png)

**1** - メインテーマ色。  
**2** - メインテーマ色から生成された明暗バリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのバリエーションはテーマ色に基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント Latin（Minor Latin Font）  
* `+mj-lt` - 見出しフォント Latin（Major Latin Font）  
* `+mn-ea` - 本文フォント East Asian（Minor East Asian Font）  
* `+mj-ea` - 見出しフォント East Asian（Major East Asian Font）

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行をそれぞれ作成し、テーマフォントを変更して結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、タナ文字など、個別の文字体系向けのフォントマッピングを含めることもできます。これらのマッピングを検査、追加、置換、削除する方法は、[Script‑Specific Theme Fonts](/slides/ja/java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、テーマに関するさまざまな課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint テーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドを再スタイル化したい場合は、[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) を使用します。対象マスターは[Presentation.getMasters](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コレクション（[IMasterSlideCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) 実装）から取得し、テーマファイルのパスをメソッドに渡します。

メソッドは次の操作を実行します。

1. 選択したマスターを基に新しいマスタースライドを作成する。  
1. 外部テーマを新しいマスターに適用する。  
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てる。  
1. 新しく作成された[IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) を返す。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

無効・破損・未サポートのテーマは[PptxReadException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが指定したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用に成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドのみが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されますが、直接割り当てられた色やフォント、塗りつぶしなどの明示的書式は変更されないことがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/java/font-substitution/) を構成してください。

これはマスター レベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルまたはレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) と[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/) を使って代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに別々の外部テーマを適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

最初の呼び出しは `firstGroupMaster` に依存するスライドのみを対象とし、2 番目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象とします。他のマスターに属するスライドは再スタイル化されません。

### **スライドの移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) とクローンしたマスターでスライドをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

この方法は、ソーススライドが宛先でも同一に表示される必要がある場合の推奨ワークフローです。目的のマスターと無関係にコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターおよびレイアウトに残したままテーマを変更したい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

これにより、他のスライドが継承しているテーマはそのままで、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、個別スライドが独自のオーバーライドを持つ場合は例外となります。同じ初期化メソッドは[LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslidethememanager/) を通じて使用できます。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

多くのレイアウトやスライドが同じベースデザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを、特定のレイアウトファミリーだけ別のスタイルが必要な場合はレイアウトオーバーライドを、真正な例外の場合だけスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後からの全体テーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI では、このコレクションに実際に格納されている塗りつぶし定義数以上の背景選択肢を提示できるのは、テーマ塗りつぶしとテーマ色、その他のスタイル参照を組み合わせられるためです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の[Background.getStyleIndex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を検査してください。インデックスが `0` の場合はテーマ塗りつぶしが適用されていないことを意味し、正の値はテーマ背景スタイルへの参照です。これは Java コレクションのインデックスとは異なり、`get_Item(0)` が最初に格納された項目を指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

見た目は、マスターが参照しているテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わりません。継承後の最終背景を取得したいときは[Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号を別のファイルで同じ外観になると想定してハードコードしないでください。テーマスタイル定義はプレゼンテーションごとに異なります。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) を通じてそれぞれ塗りつぶし、線、効果スタイルのコレクションを公開します。典型的な Office テーマは、微妙、標準、強いの 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![同一シェイプに適用された微細、標準、強いテーマ効果](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapestyle/) で取得できます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変わらないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側シャドウ（距離 10 pt）を有効にして結果を保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外側シャドウが追加されます。最終的なビジュアルは、各シェイプがどのスロットを参照しているか、また直接書式がテーマを上書きしているかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **実効ソリッド塗りつぶしがテーマカラーを使用しているか判定する**

塗りつぶしはオブジェクトに直接格納されることも、段落、レイアウト、マスター、テーマスタイル、または他の書式レベルから継承されることもあります。[IFillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformat/) を呼び出して階層を解決し、変更不可の[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/) を取得します。まず[IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/) を確認し、`FillType.Solid` の場合にのみソリッド塗りつぶしプロパティを読み取ります。

ソリッド塗りつぶしの場合、[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/) は継承、テーマ参照、色変換が適用された最終 RGB 値を返します。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/) は対応する論理 [SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) スロット（例：`Text1`、`Accent6`）を返します。`SchemeColor.NotDefined` は実効ソリッド塗りつぶしがスキームカラーに基づいていないことを示します。このケースでは、塗りつぶしは直接 RGB で定義されています。

ローカルの[IColorFormat.getSchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorformat/) のみを使用して塗りつぶしを分類しないでください。たとえば、テキストの一部にローカルでスキームカラーが定義されていなくても、実効塗りつぶしはテーマカラーを継承し `Text1` や `Accent6` に解決されることがあります。逆に、`getSolidFillSchemeColor` は実効色を生成した論理テーマスロットを示しますが、どの階層（オブジェクト、段落、レイアウト、マスターなど）から取得したかは示しません。

次の例はプレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終 RGB 値と関連スキームカラーを出力し、テーマカラー変更に追随しないソリッド塗りつぶしをフラグ付けします。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` の分岐は、テーマカラー スロットの変更に反応しないソリッド塗りつぶしの監査リストを提供します。ブランドパレットが変更された際に対象となるオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

実効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから色を比較または報告してください。

## **有効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後にスライドやシェイプが実際に使用している内容を示します。スライドの場合は[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は[Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/)、塗りつぶしの場合は[FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを取得します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

レンダリング診断、検証、比較には有効データを使用してください。単に[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドにより最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの[SlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は？**

スライドを移動して元の外観を保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスターを宛先にクローンし、続いて[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) でそのマスターを使ってスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値はどのように確認できますか？**

スライドまたはレイアウトテーマについては[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を使用し、フォーマットオブジェクトについては[Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) や[FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) などの対応する有効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。