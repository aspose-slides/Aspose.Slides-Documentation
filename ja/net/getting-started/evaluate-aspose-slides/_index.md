---
title: Aspose.Slides の評価
type: docs
weight: 75
url: /ja/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides を評価
- Aspose.Slides の評価
- 評価版
- フル機能
- 評価用透かし
- Aspose.Slides を購入
- 制限
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を評価し、PowerPoint (PPT, PPTX) および OpenDocument (ODP) プレゼンテーション向けの API 機能を探索しましょう—無料トライアルを開始してください。"
---
## **Aspose.Slides 評価**

評価用に Aspose.Slides をダウンロードできます。評価パッケージは購入パッケージと同一で、ライセンスを適用する数行のコードを追加するとライセンス版になります。

ライセンスがない場合、Aspose.Slides は評価モードで機能しますが、2 つの制限があります。保存する各プレゼンテーションのすべてのスライドに評価用透かしテキストボックスが追加され、プレゼンテーションからコードが読み取るテキストは最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは全体が保存されます。

![評価用透かしが付いたスライド](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細は[Temporary License の取得方法?](https://purchase.aspose.com/temporary-license)をご参照ください。
{{% /alert %}}

## **評価パッケージのインストール**

```bash
dotnet add package Aspose.Slides.NET
```

Linux と macOS では代わりに Aspose.Slides.NET6.CrossPlatform パッケージを使用できます。詳細は[インストール](/slides/ja/net/installation/)をご覧ください。

## **ライセンスの適用**

評価パッケージをライセンス化する「数行のコード」です。`Presentation` オブジェクトが作成される前、アプリケーションの起動時にライセンスを一度適用してください。以前に作成されたプレゼンテーションは評価用透かしが残ります。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` は `Stream` も受け付けます。ライセンスが埋め込みリソースとして提供される場合は、ファイルではなくストリームを使用する方が適しています。パスが間違っている、または期限切れの場合は例外がスローされ、起動時にすぐに失敗が検出されます。

ライセンスが適用されると、保存されたプレゼンテーションに透かしは付かず、テキストは全文が読み取れます。

## **FAQ**

### 評価モードで複数のプレゼンテーションを異なるスレッドで同時にテストできますか？

はい。異なるドキュメントを並行して処理できますが、同じプレゼンテーションオブジェクトを[スレッド間で共有](/slides/ja/net/multithreading/)しないでください。評価モードはこれに影響しません。

### サーバーや CI 環境でライブラリを評価するために Microsoft PowerPoint をインストールする必要がありますか？

いいえ。Aspose.Slides は単体エンジンであり、評価でも本番でも PowerPoint のインストールは不要です。

### 評価モードで PPT/PPTX から PDF や画像への変換を完全にテストできますか？

はい。[コンバータ](/slides/ja/net/convert-presentation/)は動作しますが、出力には透かしが入ります。

### 透かしなしで負荷テストを行うために一時ライセンスを使用できますか？

はい。30 日間の一時ライセンスを使用すれば、評価モードの制限が解除され、透かしなしでテストできます。