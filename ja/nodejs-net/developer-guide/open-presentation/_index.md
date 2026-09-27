---
title: Node.js via .NET でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/nodejs-net/open-presentation/
keywords:
- プレゼンテーションを開く
- PowerPoint を開く
- PPTX を開く
- PPT を開く
- ODP を開く
- プレゼンテーションをロード
- バッファからのプレゼンテーション
- スライド数
- プレゼンテーションを変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET を使用して、JavaScript で PPTX、PPT、ODP プレゼンテーションを開きます。ファイルパスまたは Buffer からロードし、スライド数を取得し、別の形式で保存します。"
---
## **概要**

Aspose.Slides for Node.js via .NET は、PowerPoint および OpenDocument プレゼンテーション（PPTX、PPT、ODP ファイルなど）をファイルパスまたは Node.js `Buffer` から開きます。この記事では、両方の方法を示し、スライド数を取得し、開いたプレゼンテーションを別の形式で保存します。

例では、[Installation](/slides/ja/nodejs-net/installation/) で設定したプロジェクトフォルダーに `sample.pptx` という名前のプレゼンテーションがあることを想定しています。任意の PowerPoint プレゼンテーションで構いません。各例をプロジェクトフォルダー内に `.js` ファイルとして保存し、そのフォルダーから `node` で実行してください。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。CamelCase 名で Aspose.Slides for .NET API を鏡像として提供しているため、この記事の API リンクは [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) の該当クラスおよびメンバーに導きます。
{{% /alert %}}

## **ファイルからプレゼンテーションを開く**

プレゼンテーションを開くには、そのパスを [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) コンストラクタに渡します。Aspose.Slides は拡張子ではなくファイル内容から形式を検出するため、同じコードで PPTX、PPT、ODP ファイルを開くことができます。相対パスは現在の作業ディレクトリに対して解決され、スクリプトをそのフォルダーから実行するとプロジェクトフォルダーが基準になります。

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

スクリプトは `sample.pptx` のスライド数を出力します（例: `Slide count: 9`）。[slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションの `count` プロパティには非表示スライドも含まれます。例のように `finally` ブロックで `dispose` を呼び出し、コードが失敗した場合でもプレゼンテーション背後の .NET リソースが解放されるようにしてください。

## **バッファからプレゼンテーションを開く**

プレゼンテーションがデータベース、HTTP アップロード、またはファイルパスではなくバイト列として提供される場合は、2 番目のコンストラクタ引数に Node.js `Buffer` を、1 番目に `null` を渡します。次の例は `sample.pptx` をバッファに読み込み、そうしたソースの代わりに使用しています。

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

スクリプトは前の例と同じスライド数を出力します。2 番目の引数は必ず `Buffer` でなければなりません。`Uint8Array` など他の型を渡すとエラーは報告されず、空のスライドが 1 枚ある新しいプレゼンテーションが作成されます。まず `Buffer.from` で他のバイナリ型を変換してください。

## **別の形式でプレゼンテーションを保存する**

プレゼンテーションを別の形式に変換するには、開いた後に異なる [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) の値で保存します。次の例は Aspose.Slides が検出した形式（[sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) プロパティが返す）を表示し、OpenDocument プレゼンテーションとして保存します。

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

スクリプトは `Source format: Pptx` と出力し、同じスライドを含む `sample.odp` を作成します。`sourceFormat` は `Ppt`、`Pptx`、`Odp` のいずれかを返します。PDF や画像として保存したい場合は、[Convert PowerPoint to PDF](/slides/ja/nodejs-net/convert-powerpoint-to-pdf/) および [Convert Slides to Images](/slides/ja/nodejs-net/convert-slide/) を参照してください。

## **FAQ**

**パスワードで保護されたプレゼンテーションを開くにはどうすればよいですか？**

[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) オブジェクトを作成し、その `password` プロパティにパスワードを設定して、3 番目のコンストラクタ引数として渡します：`new Presentation("protected.pptx", null, loadOptions)`。正しいパスワードがない場合、コンストラクタはエラーをスローします。

**なぜコンストラクタが空のメッセージで `Error` をスローするのですか？**

.NET で `Presentation` コンストラクタが失敗すると（例: ファイルが存在しない、プレゼンテーションではない、別のパスワードが必要など）、JavaScript 側にはメッセージが空の `Error` が渡されます。ファイルを開く前に、`fs.existsSync` などで作業ディレクトリからの相対パスで存在するか確認してください。

**開くことができる形式は何ですか？**

PowerPoint および OpenDocument のプレゼンテーション形式で、PPT、PPTX、PPS、POT、POTX、PPTM、ODP、OTP、FODP がサポートされています。