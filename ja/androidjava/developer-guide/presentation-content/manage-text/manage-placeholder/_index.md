---
title: Android でプレゼンテーションプレースホルダーを管理
linktitle: プレースホルダーを管理
type: docs
weight: 10
url: /ja/androidjava/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- プロンプトテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でプレースホルダーを簡単に管理：テキストの置換、プロンプトのカスタマイズ、PowerPoint および OpenDocument における画像の透過性設定"
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for Android via Java](/slides/ja/androidjava/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索して変更できます。Aspose.Slides を使用すると、プレースホルダーのテキストを変更できます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。このようなプレゼンテーションは、標準の Microsoft PowerPoint アプリで作成できます。

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライドの参照を取得します。
3. 形状を反復処理してプレースホルダーを探します。
4. プレースホルダー形状を [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に型変換し、[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この Java コードは、プレースホルダーのテキストを変更する方法を示しています:
```java
// Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // プレースホルダーを探すためにシェイプを反復処理します
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 各プレースホルダーのテキストを変更します
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // プレゼンテーションをディスクに保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** といったプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、好きなプロンプトテキストをプレースホルダーのレイアウトに挿入できます。

この Java コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理します
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint は「Click to add title」を表示します
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // サブタイトルを追加します
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレースホルダー画像の透過性を設定する**
Aspose.Slides を使用すると、テキストプレースホルダー内の背景画像の透過性を設定できます。そのフレーム内の画像の透過性を調整することで、テキストや画像を際立たせることができます（テキストと画像の色に応じて）。

この Java コードは、形状内の画像背景の透過性を設定する方法を示しています:
```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとどう違うのか？**

ベースプレースホルダーは、レイアウトまたはマスター上の元の形状で、スライドの形状がそれから継承します。タイプ、位置、いくつかの書式設定がそこから引き継がれます。一方、ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承が適用されません。

**プレゼンテーション全体のタイトルやキャプションを、すべてのスライドを反復せずに更新するにはどうすればよいですか？**

レイアウトまたはマスター上の該当するプレースホルダーを編集します。そのレイアウトやマスターに基づくスライドは、自動的に変更を継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**

適切なスコープ（通常のスライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用して、これらのプレースホルダーをオン/オフにし、内容を設定します。