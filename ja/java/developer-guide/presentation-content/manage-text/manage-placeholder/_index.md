---
title: Javaでプレゼンテーションのプレースホルダーを管理
linktitle: プレースホルダーの管理
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
description: "Aspose.Slides for Javaでプレースホルダーを手軽に管理: テキストの置換、プロンプトのカスタマイズ、PowerPointおよびOpenDocumentでの画像の透明度設定を行います。"
---

## **プレースホルダーのテキストを変更する**
Using [Aspose.Slides for Java](/slides/ja/java/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは、標準の Microsoft PowerPoint アプリで作成できます。

このようにして、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダー内のテキストを置換します:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class. and pass the presentation as an argument. → `Presentation` クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. Get a slide reference through its index. → インデックスを使用してスライド参照を取得します。
3. Iterate through the shapes to find the placeholder. → シェイプを列挙してプレースホルダーを見つけます。
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) associated with the [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape). → プレースホルダーシェイプを `AutoShape` に型変換し、`AutoShape` に関連付けられた `TextFrame` を使用してテキストを変更します。
5. Save the modified presentation. → 変更されたプレゼンテーションを保存します。

This Java code shows how to change the text in a placeholder:
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


## **プレースホルダーにプロンプトテキストを設定する**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This Java code shows you how to set the prompt text in a placeholder:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理します
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint は "Click to add title" を表示します
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


## **プレースホルダー画像の透明度を設定する**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This Java code shows you how to set the transparency for a picture background (inside a shape):
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

ベースプレースホルダーは、レイアウトまたはマスター上の元のシェイプで、スライドのシェイプが継承するものです─タイプ、位置、いくつかの書式設定がそれから取得されます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しなければ継承は適用されません。

**プレゼンテーション全体のすべてのタイトルやキャプションを、各スライドを走査せずに更新するにはどうすればよいですか？**

レイアウトまたはマスター上の該当するプレースホルダーを編集します。これらのレイアウト/マスターを使用しているスライドは自動的に変更を継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御しますか？**

適切なスコープ（通常スライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用して、これらのプレースホルダーのオン/オフや内容の設定を行います。