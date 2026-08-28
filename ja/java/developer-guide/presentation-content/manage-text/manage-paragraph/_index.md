---
title: JavaでPowerPointテキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落の箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLをインポート
- テキストをHTMLに変換
- 段落をHTMLに変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for Java はテキストをテキストフレーム、段落、およびポーションの階層として表現します：

* [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) はシェイプ内のテキストコンテナを表し、その段落コレクションへのアクセスを提供します。
* [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) はテキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) は段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数ポーションで段落を作成する**

次の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを追加します。
6. 各段落が 3 つのポーションを含むように、十分な数の [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getPortionFormat--) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この Java の例が手順を実装しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **箇条書きおよび番号付きリストの作成**

### **箇条書きまたは番号付きリストを作成する**

箇条書きと番号付けは、関連項目を視認しやすくします。Aspose.Slides では、リスト設定は [IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) を介して定義されます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. シンボル箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) を作成します。
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-int-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落テキスト、インデント、箇条書きの色、および箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-int-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この Java の例はシンボル箇条書きと番号付き箇条書きを作成します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **画像箇条書きを使用する**

画像箇条書きを使用すると、シンボルや数字の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、その [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、プレゼンテーションの画像コレクションに [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) として追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-int-) を [BulletType.Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/) に設定します。
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#getPicture--) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更したプレゼンテーションを保存します。

この Java の例は画像箇条書きを作成します：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **多層リストを作成する**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) を設定して、リスト内の段落を異なるレベルに配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、テキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. それぞれの [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) を `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Java の例は 4 レベルの箇条書きリストを作成します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **番号付きリスト項目の開始番号をカスタム値にする**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を使用して、番号付き段落の最初に表示される番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Java の例は各段落にカスタム開始番号を割り当てます：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **段落のレイアウトと末端プロパティの制御**

### **最初の行インデントを設定する**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用して段落の最初の行インデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右方向にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動したい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動したい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例では複数の段落を作成し、異なる [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を適用して、最初の行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The first-line indent of the paragraphs](first_line_indent.png)

### **ハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) に負の値を渡すことでこの効果を実現します。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本文の左位置を定義し、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、`setMarginLeft` に正の値、`setIndent` に負の値をそれぞれ渡します。

この書式設定は、文献リスト、参考文献、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) に正の値を設定して段落を作成します。
6. [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) に負の値を渡してハンギングインデント効果を作成します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落にハンギングインデントを設定する方法を示します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The hanging indent of the paragraphs](hanging_indent.png)

### **段落末端の実行プロパティを設定する**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) は段落末端記号の書式設定を制御します。次の例は、2 番目の段落の末端記号にフォントサイズとラテンフォントを割り当てます：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を読み込み、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落の末端記号用に [PortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portionformat/) を作成します。
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) と [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) を設定します。
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) で書式を割り当て、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポートする**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) を使用すると、HTML マークアップをテキストフレーム内の段落とポーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにアクセスし、[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソースの HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) に渡します。
6. 変更したプレゼンテーションを保存します。

この Java の例は HTML をテキストフレームにインポートします：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **段落テキストを HTML にエクスポートする**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を使用して、選択した範囲の段落を HTML としてエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. スライドにアクセスし、テキストを含む [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を見つけます。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を呼び出します。
5. 返された HTML 文字列を書き出してファイルに保存します。

この Java の例は最初のテキストシェイプのすべての段落をエクスポートします：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **段落を画像としてレンダリングする**

[IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を返します。結果は [IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) でファイルまたはストリームに保存できます。親シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) は、段落が親コレクションに存在しない、または有効なレンダリング領域がない、あるいはレンダリングできない場合に `null` を返すことがあります。保存する前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリングする**

sample.pptx というプレゼンテーションファイルに 1 つのスライドがあり、最初のシェイプが 3 つの段落を含むテキストボックスであるとします。

![The text box with three paragraphs](paragraph_to_image_input.png)

次の例は、通常のテキストシェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します。`finally` ブロックは画像が正しく破棄されることを保証します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

結果：

![The paragraph image](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリングする**

`float scaleX` と `float scaleY` パラメータを受け取る [IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage-float-float-) のオーバーロードを使用して、横方向と縦方向のスケール係数を設定します。以下の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` のスケールはその軸をデフォルトのピクセルサイズのままにします。例として、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。等しい係数を使用すると段落のアスペクト比が保たれ、異なる水平・垂直係数は出力を個別に伸縮させます。

シェイプ全体を [IShape.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage--) でレンダリングすることは、シェイプの塗りつぶし、枠線、その他の視覚コンテキストを含める必要がある場合に有用です。段落のみの画像が必要な場合は [IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) を使用してください。

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。[ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) を設定してラッピングを無効にすると、行はテキストフレームの端で改行されません。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

[IParagraph.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getRect--) を使用して段落の境界矩形を取得します。[IPortion.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getRect--) は個別のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御されますか？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を設定すると、1 つの段落内で複数の言語のテキストを含めることができます。