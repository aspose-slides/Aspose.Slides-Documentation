---
title: API リファレンス
type: docs
weight: 50
url: /ja/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET は、Aspose.Slides for .NET API リファレンスで文書化されています。.NET のクラスとメンバー名が JavaScript にどのようにマッピングされるかをご覧ください。"
---
## **概要**

Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。このパッケージは Aspose.Slides for .NET のクラスを同じ名前で JavaScript に公開し、メンバー名は camelCase です。そのため、[Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) がクラス、メンバー、列挙体を文書化しています。

## **.NET の名前を JavaScript にマッピング**

.NET API リファレンスで見つけたメンバーを使用するには、以下のルールを適用してください。

- **クラスと列挙体は .NET の名前をそのまま保持します**。列挙体の値も同様です: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`。パッケージからインポートします: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`。
- **プロパティとメソッドは小文字で始まります**。`Presentation.Slides` は `presentation.slides` に、`ShapeCollection.AddAutoShape` は `shapes.addAutoShape` になります。プロパティはプロパティのままで、括弧なしで読み書きします。
- **コレクション項目は `get(index)` で取得し、項目数は `count` で取得します**: `presentation.slides.get(0)` は `presentation.Slides[0]` の代わりに使用します。
- **一部のオーバーロードは別名が付与されます**。例えば、`Slide.GetImage(Size)` オーバーロードは `slide.getImageWithImageSize({ width, height })` です。他のものはオプションの末尾引数を持つ単一メソッドで共有されます: `presentation.save(path, format, options, slides)` は複数の `Presentation.Save` オーバーロードをカバーし、`new Presentation(null, buffer)` は `Buffer` からプレゼンテーションを開きます。各クラスはパッケージの `lib` フォルダー以下の単一ファイルにあり（例: `node_modules/aspose.slides.via.net/lib/Slide.js`）、正確な名前を確認できます。
- **使用が終わったら `dispose` でプレゼンテーションを解放します**。JavaScript には `using` 文がありません。

このパッケージはすべての .NET メンバーをラップしているわけではありません。.NET API リファレンスにあるメンバーがクラスファイルに存在しない場合、JavaScript では利用できません。

## **例**

以下のスクリプトは上記のルールを使用しています。各コメントは次の行が対応する .NET 呼び出しを示しています。最初のスライドにテキスト付きの矩形を追加し、スライドを 960 × 540 ピクセルの PNG 画像としてレンダリングし、プレゼンテーションを PDF として保存します。パッケージがインストールされたプロジェクト フォルダーから、[Installation](/slides/ja/nodejs-net/installation/) に記載の手順で実行してください。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

スクリプトは `slide.png` と `slide.pdf` を現在のフォルダーに書き出します。どちらも矩形とそのテキストを表示します。ライセンスがない場合、評価用の透かしが表示されます。詳細は [Licensing](/slides/ja/nodejs-net/licensing/) を参照ください。

ここで使用されているメンバーの詳細は、Aspose.Slides for .NET API リファレンスの [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)、[ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)、[TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) および [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) を参照してください。