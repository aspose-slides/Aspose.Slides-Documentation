---
title: プレースホルダの管理
type: docs
weight: 10
url: /ja/androidjava/manage-placeholder/
description: Javaを使用してPowerPointスライドのプレースホルダ内のテキストを変更します。Javaを使用してPowerPointスライドのプレースホルダ内にプロンプトテキストを設定します。
---

## **プレースホルダ内のテキストを変更**
[Aspose.Slides for Android via Java](/slides/ja/androidjava/)を使用すると、プレゼンテーションのスライド上のプレースホルダを見つけて変更できます。Aspose.Slidesを使用すると、プレースホルダ内のテキストを変更できます。

**前提条件**: プレースホルダを含むプレゼンテーションが必要です。このようなプレゼンテーションは、標準のMicrosoft PowerPointアプリで作成できます。

これが、Aspose.Slidesを使用してそのプレゼンテーション内のプレースホルダのテキストを置き換える方法です：

1. [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. インデックスを介してスライドの参照を取得します。
3. シェイプを反復処理してプレースホルダを見つけます。
4. プレースホルダシェイプを[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)を使用してテキストを変更します。
5. 修正したプレゼンテーションを保存します。

次のJavaコードは、プレースホルダ内のテキストを変更する方法を示しています：

```java
// Presentationクラスをインスタンス化
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // プレースホルダを見つけるためにシェイプを反復処理
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 各プレースホルダ内のテキストを変更
            ((IAutoShape) shp).getTextFrame().setText("これはプレースホルダです");
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレースホルダにプロンプトテキストを設定**
標準およびプリビルドのレイアウトには、***クリックしてタイトルを追加***や***クリックしてサブタイトルを追加***などのプレースホルダプロンプトテキストが含まれています。Aspose.Slidesを使用すると、好みのプロンプトテキストをプレースホルダレイアウトに挿入できます。

次のJavaコードは、プレースホルダにプロンプトテキストを設定する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPointは「クリックしてタイトルを追加」と表示
            {
                text = "タイトルを追加";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // サブタイトルを追加
            {
                text = "サブタイトルを追加";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("テキストを持つプレースホルダ: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレースホルダの画像の透明度を設定**

Aspose.Slidesを使用すると、テキストプレースホルダの背景画像の透明度を設定できます。このフレーム内の画像の透明度を調整することで、テキストや画像を際立たせることができます（テキストと画像の色に応じて）。

次のJavaコードは、シェイプ内の画像の背景の透明度を設定する方法を示しています：

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