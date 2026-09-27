---
title: "Aspose.Slides を評価する"
type: docs
weight: 120
url: /ja/nodejs-java/evaluate-aspose-slides/
keywords:
- "Aspose.Slides を評価"
- "Aspose.Slides の評価"
- "評価版"
- "フル機能"
- "評価用透かし"
- "Aspose.Slides の購入"
- "制限"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Java を介して Node.js 用 Aspose.Slides を評価し、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーション向けの API 機能を確認しましょう — 無料トライアルを開始してください。"
---
## **Aspose.Slides 評価**

評価用に Aspose.Slides をダウンロードできます。評価パッケージは購入パッケージと同一で、ライセンスを適用するための数行のコードを追加するとライセンスが有効になります。インストール方法については、[インストール](/slides/ja/nodejs-java/installation/) を参照してください。

ライセンスがない場合、Aspose.Slides は評価モードでフル機能を提供しますが、2 つの制限があります。保存する各プレゼンテーションのすべてのスライドに評価用の透かしテキストボックスが追加され、プレゼンテーションからコードが読み取るテキストが5文字を超える場合、最初の5文字に切り取られ、続いて `... text has been truncated due to evaluation version limitation.` が付加されます。5文字以下のテキストは変更されずに返され、コードが書き込むテキストは完全に保存されます。保存するたびに透かしが追加されるため、評価モードで開いて再度保存したプレゼンテーションは、各スライドに保存ごとに1つの透かしが付くことになります。

{{% alert color="info" title="Note" %}}
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 Day Temporary License** をリクエストできます。詳細については、[一時ライセンスの取得方法は？](https://purchase.aspose.com/temporary-license) を参照してください。
{{% /alert %}}

## **FAQ**

### 評価モードで、異なるスレッド間で複数のプレゼンテーションを並行してテストできますか？

はい。異なるドキュメントを並行して処理できます。ただし、同じプレゼンテーション オブジェクトを[スレッド間で](/slides/ja/nodejs-java/multithreading/)共有しないでください。評価モードはこれに影響しません。

### サーバーや CI でライブラリを評価するために Microsoft PowerPoint をインストールする必要がありますか？

いいえ。Aspose.Slides はスタンドアロン エンジンであり、評価でも本番でも PowerPoint のインストールは不要です。

### 評価モードで PPT/PPTX から PDF や画像への変換を完全にテストできますか？

はい。[コンバーター](/slides/ja/nodejs-java/convert-presentation/)は動作します。出力には透かしが含まれます。

### 透かしなしで負荷テストに一時ライセンスを使用できますか？

はい。30 日間の一時ライセンスにより評価モードの制限が解除され、透かしなしでテストできます。