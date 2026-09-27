---
title: ライセンス
description: "Aspose.Slides for Node.js via .NET にライセンス ファイルを適用し、評価版の制限を確認し、テスト用の無料 30 日間一時ライセンスを取得します。"
type: docs
weight: 80
url: /ja/nodejs-net/licensing/
---
## **概要**

Aspose.Slides for Node.js via .NET は評価版と本番版の両方に対応した npm パッケージです。ライセンスがない場合は評価モードで動作します。ライセンスを購入するか、30 日間の無料一時ライセンスを取得すれば、数行のコードでライセンスを適用でき、評価制限は解除されます。

{{% alert color="info" title="Note" %}}

Aspose 製品の評価、ライセンス取得、購入に関する一般的なポリシーは [購入ポリシーとFAQ](https://purchase.aspose.com/policies) にまとめられています。価格は [価格情報](https://purchase.aspose.com/pricing/slides/ja/family) ページに掲載されています。

{{% /alert %}}

## **評価版の制限**

評価版は製品のフル機能を提供しますが、次の 2 つの制限があります。

- **透かし。** 保存する各プレゼンテーションの各スライドに評価用透かしが入ります。スライドの中央に「Evaluation only.」というロックされたテキストボックスが表示されます。同じ透かしは PDF、XPS、HTML のエクスポートおよびスライド画像にも描画されます。
- **テキストの切り捨て。** コードでテキストフレーム、段落、またはポーションから取得したテキストは最初の 5 文字に切り詰められ、その後に「... text has been truncated due to evaluation version limitation.」という通知が付加されます。Markdown と HTML5 のエクスポートも同様に切り捨てられます。コードで書き込むテキストはそのまま保存されます。

[Evaluate Aspose.Slides](/slides/ja/nodejs-net/evaluate-aspose-slides/) では、これらの制限の詳細と、制限を示すサンプル スクリプトが提供されています。

{{% alert color="success" title="Tip" %}}

評価制限なしで Aspose.Slides をテストするには、無料の **30 日間の一時ライセンス** をリクエストしてください。詳細は [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) をご覧ください。

{{% /alert %}}

## **ライセンスについて**

ライセンスはプレーンテキストの XML ファイルで、製品名、許可された開発者数、サブスクリプションの有効期限などの情報が含まれます。ファイルはデジタル署名されているため、変更しないでください。余分な改行を加えるだけでも無効になります。

## **ライセンスの適用**

`License` クラスの `setLicense` メソッドでライセンスを適用します。`Presentation` オブジェクトを作成する前に、プロセスごとに一度だけ呼び出してください。再度呼び出しても問題はありませんが、処理は重複します。

以下のスクリプトは `Aspose.Slides.lic` という名前のファイルからライセンスを適用します。ファイル名は実際のライセンス ファイル名またはフルパスに置き換えてください。ファイル名は任意で構いません。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

ファイル名または相対パスは、`node` を実行した現在のフォルダーを基準に解決されます。ライセンス ファイルはプロジェクト フォルダーに置き、そこでスクリプトを実行するか、フルパスを指定してください。

ファイルが見つからない、または無効なライセンスの場合、`setLicense` はエラーをスローし、Aspose.Slides は評価モードのままになります。スクリプトはエラーを捕捉し、メッセージを出力します。ファイルが存在しない場合のメッセージは `License "Aspose.Slides.lic" doesn't exist or access is restricted.` で始まり、検索されたすべての場所が列挙されます。

このパッケージでは、ライセンスはファイルからのみ適用できます。`License` はストリームを受け付けず、メーター制ライセンスも公開されていません。パッケージがラップしているクラスについては、Aspose.Slides for .NET API リファレンスの [License](https://reference.aspose.com/slides/ja/net/aspose.slides/license/) を参照してください。