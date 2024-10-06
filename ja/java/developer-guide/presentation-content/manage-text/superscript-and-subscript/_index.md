---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/java/superscript-and-subscript/
---

## **上付き文字と下付き文字のテキストを管理する**
任意の段落部分に上付き文字と下付き文字のテキストを追加できます。Aspose.Slidesのテキストフレームに上付き文字や下付き文字のテキストを追加するには、[**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-)メソッドを[PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat)クラスで使用する必要があります。

このプロパティは、上付き文字または下付き文字のテキストを返すか設定します（値は-100%（下付き文字）から100%（上付き文字）まで）。例えば：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle)タイプの[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)をスライドに追加します。
- [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)に関連付けられた[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame)にアクセスします。
- 既存の段落をクリアします。
- 上付き文字を保持するための新しい段落オブジェクトを作成し、[IParagraphsコレクション](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--)に追加します。
- 新しいポ―ションオブジェクトを作成します。
- 上付き文字を追加するためにポ―ションのEscapementプロパティを0から100の範囲で設定します。（0は上付き文字なしを意味します）
- [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)にいくつかのテキストを設定し、次にそれを段落のポーションコレクションに追加します。
- 下付き文字を保持するための新しい段落オブジェクトを作成し、ITextFrameのIParagraphsコレクションに追加します。
- 新しいポ―ションオブジェクトを作成します。
- 下付き文字を追加するためにポーションのEscapementプロパティを0から-100の範囲で設定します。（0は下付き文字なしを意味します）
- [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)にいくつかのテキストを設定し、次にそれを段落のポーションコレクションに追加します。
- プレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は以下の通りです。

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // スライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // テキストボックスを作成
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 上付き文字のテキスト用の段落を作成
    IParagraph superPar = new Paragraph();

    // 通常のテキストを持つポーションを作成
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 上付き文字のテキストを持つポーションを作成
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 下付き文字のテキスト用の段落を作成
    IParagraph paragraph2 = new Paragraph();

    // 通常のテキストを持つポーションを作成
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 下付き文字のテキストを持つポーションを作成
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // テキストボックスに段落を追加
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```