---
title: Javaでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/java/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- プロンプトテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Javaでプレースホルダーを手軽に管理：テキストを置換し、プロンプトをカスタマイズし、PowerPointおよびOpenDocumentで画像の透過性を設定"
---

## **プレースホルダーのテキストを変更**

[Aspose.Slides for Java](/slides/ja/java/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索して変更できます。Aspose.Slides を使ってプレースホルダー内のテキストを変更できます。

**Prerequisite**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダーのテキストを置き換える方法です：

1. [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. シェイプを反復処理してプレースホルダーを見つけます。
4. プレースホルダーシェイプを [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この Java コードは、プレースホルダーのテキストを変更する方法を示しています：
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // プレースホルダーを見つけるためにシェイプを反復処理します
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


## **プレースホルダーのプロンプトテキストを設定**

標準および事前に用意されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** といったプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、好みのプロンプトテキストをプレースホルダーレイアウトに挿入できます。

この Java コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理します
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint は「クリックしてタイトルを追加」 と表示します 
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


## **プレースホルダー画像の透過性を設定**

Aspose.Slides を使用すると、テキストプレースホルダーの背景画像の透過性を設定できます。そのフレーム内の画像の透過性を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色に応じて）。

この Java コードは、シェイプ内の画像背景の透過性を設定する方法を示しています：
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

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとはどのように異なるか？**

ベースプレースホルダーは、レイアウトまたはマスター上の元になるシェイプで、スライドのシェイプはそれを継承します—タイプ、位置、および一部の書式設定がそこから引き継がれます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承は適用されません。

**プレゼンテーション全体のすべてのタイトルまたはキャプションを、各スライドを反復せずに更新するにはどうすればよいですか？**

レイアウトまたはマスター上の該当するプレースホルダーを編集します。そのレイアウト/マスターに基づくスライドは、変更を自動的に継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**

適切なスコープ（通常のスライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用し、これらのプレースホルダーのオン/オフを切り替え、内容を設定します。