---
title: プレースホルダーの管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-placeholder/
description: JavaScript を使用して PowerPoint スライドのプレースホルダー内のテキストを変更する。JavaScript を使用して PowerPoint スライドのプレースホルダーにプロンプトテキストを設定する。
---

## **プレースホルダー内のテキストを変更する**

Using [Node.js via Java 用 Aspose.Slides](/slides/ja/nodejs-java/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダー内のテキストを置き換える方法です：

1. [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. 形状を反復処理してプレースホルダーを見つけます。
4. プレースホルダー形状を [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この JavaScript コードは、プレースホルダー内のテキストを変更する方法を示しています：
```javascript
// Presentation クラスのインスタンス化
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // プレースホルダーを見つけるためにシェイプを反復
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // 各プレースホルダーのテキストを変更
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // プレゼンテーションをディスクに保存
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **プレースホルダーのプロンプトテキストを設定する**

標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** のようなプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、好きなプロンプトテキストをプレースホルダー レイアウトに挿入できます。

この JavaScript コードは、プレースホルダーのプロンプトテキストを設定する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // スライドを反復処理
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint は "Click to add title" を表示します
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // サブタイトルを追加
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **プレースホルダー画像の透過性を設定する**

Aspose.Slides を使用すると、テキスト プレースホルダー内の背景画像の透過性を設定できます。そのフレーム内の画像の透過性を調整することで、テキストや画像を際立たせることができます（テキストと画像の色に応じて）。

この JavaScript コードは、シェイプ内の画像背景の透過性を設定する方法を示しています：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **よくある質問**

**ベース プレースホルダーとは何で、スライド上のローカル シェイプとはどのように異なるのですか？**

ベース プレースホルダーは、レイアウトまたはマスター上にある元のシェイプで、スライドのシェイプがそれから継承します。タイプ、位置、および一部の書式設定はそれから取得されます。ローカル シェイプは独立しており、ベース プレースホルダーが存在しない場合は継承が適用されません。

**プレゼンテーション全体のすべてのタイトルやキャプションを、各スライドを反復せずに更新するにはどうすればよいですか？**

レイアウトまたはマスター上の該当するプレースホルダーを編集します。これらのレイアウト/マスターに基づくスライドは自動的に変更を継承します。

**標準のヘッダー/フッター プレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御しますか？**

適切なスコープ（通常スライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用し、これらのプレースホルダーをオン/オフにしたり、内容を設定したりします。