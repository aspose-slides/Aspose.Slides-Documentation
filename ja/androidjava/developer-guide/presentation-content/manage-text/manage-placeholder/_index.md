---
title: Android でプレゼンテーションのプレースホルダーを管理
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
description: "Aspose.Slides for Android (Java) でプレースホルダーを簡単に管理できます：テキストの置換、プロンプトのカスタマイズ、PowerPoint および OpenDocument の画像透明度設定"
---

## **プレースホルダーのテキストを変更**
[Aspose.Slides for Android via Java](/slides/ja/androidjava/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索して変更できます。Aspose.Slides を使用すると、プレースホルダー内のテキストを変更できます。

**Prerequisite**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

このように Aspose.Slides を使用して、そのプレゼンテーション内のプレースホルダーのテキストを置換します:

1. [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライドの参照を取得します。
3. プレースホルダーを見つけるためにシェイプを反復処理します。
4. プレースホルダーシェイプを [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に型変換し、[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この Java コードはプレースホルダーのテキストを変更する方法を示しています:
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // プレースホルダーを探すためにシェイプを反復処理
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 各プレースホルダーのテキストを変更
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレースホルダーにプロンプトテキストを設定**
標準および事前作成されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** といったプレースホルダープロンプトテキストが含まれています。Aspose.Slides を使用すると、プレースホルダー レイアウトに好みのプロンプトテキストを挿入できます。

この Java コードはプレースホルダーにプロンプトテキストを設定する方法を示しています:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // スライドを反復処理
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint は「Click to add title」を表示します
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // サブタイトルを追加
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


## **プレースホルダー画像の透明度を設定**
Aspose.Slides を使用すると、テキスト プレースホルダー内の背景画像の透明度を設定できます。そのようなフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色に応じて）。

この Java コードはシェイプ内の画像背景の透明度を設定する方法を示しています:
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

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとはどう違うのか？**  
ベースプレースホルダーは、レイアウトまたはマスタ上の元のシェイプで、スライドのシェイプはそれから継承します。タイプ、位置、いくつかの書式設定はベースプレースホルダーから取得されます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承が適用されません。

**プレゼンテーション全体のタイトルやキャプションを、すべてのスライドを走査せずに更新するにはどうすればよいですか？**  
レイアウトまたはマスタ上の対応するプレースホルダーを編集します。これらのレイアウト/マスタを使用したスライドは、変更を自動的に継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**  
適切なスコープ（通常のスライド、レイアウト、マスタ、ノート/ハンドアウト）で HeaderFooter マネージャーを使用し、プレースホルダーのオン/オフを切り替え、内容を設定します。