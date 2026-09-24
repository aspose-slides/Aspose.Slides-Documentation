---
title: JavaでPowerPointテキスト段落を管理
linktitle: 段落の管理
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
  - ぶら下げインデント
  - 段落箇条書き
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
description: "Aspose.Slides for Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTMLコンテンツ、段落画像の作成と書式設定の方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、テキストをテキストフレーム、段落、およびポーションの階層として表現します：

* [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) はシェイプ内のテキスト コンテナを表し、段落コレクションへのアクセスを提供します。
* [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) はテキストフレーム内の 1 つの段落を表し、ポーションおよび段落レベルの書式設定へのアクセスを提供します。
* [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) は段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数ポーションを持つ段落の作成**

以下の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに長方形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを追加します。
6. 各段落が 3 つのポーションを含むように十分な数の [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) オブジェクトを追加します。デフォルトの段落には既に空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getPortionFormat--) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この Java の例は上記の手順を実装しています：

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

## **箇条書きリストと番号付きリストの作成**

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けは項目の把握を容易にします。Aspose.Slides では、リスト設定は [IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) を通じて定義されます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. シンボル箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) を作成します。
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-int-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落のテキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-int-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きスタイルを構成し、段落をテキストフレームに追加します。
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

### **画像箇条書きの使用**

画像箇条書きを使用すると、シンボルや番号の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、 its [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
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

### **多層リストの作成**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) を設定して、段落をリストの異なる階層に配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、そのテキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. それらの [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 値をそれぞれ `0`、`1`、`2`、`3` に設定します。
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

### **番号付きリスト項目の開始番号をカスタム値に設定**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を使用して、番号付き段落の最初に表示される番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) をそれぞれ `2`、`3`、`7` に設定します。
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

## **段落のレイアウトと終了プロパティの制御**

### **先頭行インデントの設定**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用して段落の先頭行インデントを制御します。このメソッドは段落左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃えたままです。

全体の段落を移動したい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、先頭行だけを移動したい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例は複数の段落を作成し、異なる [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を適用して、先頭行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドにアクセスします。
3. スライドに長方形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示しています：

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

![段落の先頭行インデント](first_line_indent.png)

### **ぶら下げインデントの設定**

ぶら下げインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) に負の値を渡すことで、段落本文に対して最初の行を左に移動させます。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本文の左位置を定義し、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を定義します。ぶら下げインデントを作成するには、`setMarginLeft` に正の値を、`setIndent` に負の値を渡します。

この書式設定は、文献リスト、参照、用語集エントリなど、折り返し行が段落本文の下に揃える必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドにアクセスします。
3. スライドに長方形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) に正の値を設定します。
6. [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) に負の値を渡してぶら下げインデント効果を作成します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落にぶら下げインデントを設定する方法を示しています：

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

![段落のぶら下げインデント](hanging_indent.png)

### **段落末尾実行プロパティの設定**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) は段落の終端マークの書式設定を制御します。以下の例は、2 番目の段落の終端マークにフォントサイズとラテン文字フォントを割り当てます：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) をロードし、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落の終端マーク用に [PortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portionformat/) を作成します。
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

## **描画行数の取得**

[IParagraph.getLinesCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getLinesCount--) を使用して、テキストレイアウト後に段落が占める行数（自動折り返しを含む）を取得します。これは、プレゼンテーションテンプレートでテキスト長やレイアウトを確認する際に便利です。

段落は [ITextFrame.getParagraphs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParagraphs--) の 1 アイテムであり、複数の描画行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字の数だけを数えても描画行数は得られません。

以下の例はテキストシェイプを作成し、行数をカウントし、シェイプを狭くした後に短い文字列に置き換えます。折り返しを有効にし、オートフィットを無効にしてシェイプ幅が折り返しを制御するようにしています。シェイプのサイズはポイント単位です。最後に、別の段落を追加してテキストフレーム全体の行数を合計します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

このテキストとサイズの場合、シェイプを狭めると行数が増加し、短い文字列に置き換えると減少します。正確なカウントはフォントの可用性、置換、フォントサイズ、余白、インデント、折り返し、オートフィット設定に依存します。テンプレートを確認する際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかどうかは判断できません。利用可能な高さ、行の高さ、段落および行間、オートフィット動作も考慮する必要があります。折り返しが無効な場合、単一行でも幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
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

### **段落テキストを HTML にエクスポート**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を使用して、選択した段落範囲を HTML としてエクスポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションをロードします。
2. スライドに移動し、テキストを含む [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を探します。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この Java の例は最初のテキストシェイプからすべての段落をエクスポートします：

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

### **段落を画像としてレンダリング**

[IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を返します。結果は [IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) でファイルまたはストリームに保存できます。含むシェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

段落が親コレクションに存在しない、レンダリング境界が無効、またはレンダリングできない場合、[IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) は `null` を返すことがあります。保存前に結果を確認し、使用後は画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

サンプルとして、sample.pptx というファイルに 1 枚のスライドがあり、最初のシェイプが 3 段落を含むテキストボックスであるとします。

![3 段落を含むテキストボックス](paragraph_to_image_input.png)

以下の例は、通常のテキストシェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します。`finally` ブロックで画像を正しく破棄しています。

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

![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

[IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage-float-float-) のオーバーロードを使用し、`float scaleX` と `float scaleY` パラメータで水平・垂直スケール係数を指定できます。以下の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

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

スケール係数 `1` はデフォルトのピクセルサイズを保持します。例えば、両方を `2` に設定すると幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が減少した小さな画像を生成します。段落のアスペクト比を保つには同等の係数を使用し、水平と垂直で異なる係数を設定すると出力が別々に伸びます。

シェイプ全体を画像化したい場合は [IShape.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage--) を使用しますが、段落だけの画像が必要なときは [IParagraph.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getImage--) を使用してください。

## **よくある質問**

**テキストフレーム内の折り返しを完全に無効にできますか？**

はい。`[ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)` を `0` に設定すると、テキストフレームの端で行が折り返されなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

`[IParagraph.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getRect--)` を使用して段落のバウンディング矩形を取得できます。個々のポーションの境界は `[IPortion.getRect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getRect--)` で取得できます。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

`[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)` は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して `[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)` を設定すれば、1 段落内に複数の言語を含めることができます。