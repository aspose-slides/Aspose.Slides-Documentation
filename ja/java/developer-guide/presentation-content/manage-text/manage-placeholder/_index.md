---
title: プレースホルダーの管理
type: docs
weight: 10
url: /ja/java/manage-placeholder/
description: Javaを使用してPowerPointスライドのプレースホルダー内のテキストを変更します。Javaを使用してPowerPointスライドのプレースホルダー内にプロンプトテキストを設定します。
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for Java](/slides/ja/java/)を使用すると、プレゼンテーション内のスライドでプレースホルダーを見つけて修正できます。Aspose.Slidesを使用すると、プレースホルダー内のテキストを変更することができます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。このようなプレゼンテーションは標準のMicrosoft PowerPointアプリで作成できます。

これがそのプレゼンテーション内のプレースホルダーのテキストを置き換えるためにAspose.Slidesを使用する方法です：

1. [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. インデックスを通じてスライドリファレンスを取得します。
3. プレースホルダーを見つけるためにシェイプを反復処理します。
4. プレースホルダーシェイプを[`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape)に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)を使用してテキストを変更します。
5. 修正されたプレゼンテーションを保存します。

以下はプレースホルダー内のテキストを変更する方法を示すJavaコードです：

```java
// Presentationクラスをインスタンス化
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // プレースホルダーを見つけるためにシェイプを反復処理
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 各プレースホルダーのテキストを変更
            ((IAutoShape) shp).getTextFrame().setText("これはプレースホルダーです");
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには ***タイトルを追加するにはクリックしてください*** や ***サブタイトルを追加するにはクリックしてください*** といったプレースホルダープロンプトテキストが含まれています。Aspose.Slidesを使用すると、お好みのプロンプトテキストをプレースホルダーレイアウトに挿入できます。

以下はプレースホルダーにプロンプトテキストを設定する方法を示すJavaコードです：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPointは「タイトルを追加するにはクリックしてください」と表示
            {
                text = "タイトルを追加";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // サブタイトルを追加
            {
                text = "サブタイトルを追加";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("テキスト付きプレースホルダー: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレースホルダー画像の透明度を設定する**

Aspose.Slidesを使用すると、テキストプレースホルダー内の背景画像の透明度を設定できます。このようなフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色によって異なります）。

以下はシェイプ内の画像背景の透明度を設定する方法を示すJavaコードです：

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
        System.out.println("現在の透明度の値: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```