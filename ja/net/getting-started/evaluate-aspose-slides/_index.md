---
title: Aspose.Slides を評価する
type: docs
weight: 120
url: /ja/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides を評価
- Aspose.Slides の評価
- 評価版
- フル機能
- 評価用透かし
- Aspose.Slides の購入
- 制限
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を評価し、PowerPoint (PPT, PPTX) と OpenDocument (ODP) プレゼンテーション向けの API 機能を確認しましょう — 無料トライアルを開始してください。"
---
## **Aspose.Slides 評価**

Aspose.Slides を簡単にダウンロードして評価できます。評価パッケージは購入パッケージと同一です。評価版は、ライセンスを適用する数行のコードを追加すれば、ライセンス版に変わります。

ライセンスが指定されていない Aspose.Slides の評価版は、製品の全機能を提供しますが、開く時と保存時にドキュメントの上部に評価用透かしが挿入されます。また、プレゼンテーション スライドからテキストを抽出する際は、1 スライドに制限されます。

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細については、[How to get a Temporary License?](https://purchase.aspose.com/temporary-license) を参照してください。 
{{% /alert %}}

## **評価パッケージのインストール**

```bash
dotnet add package Aspose.Slides.NET
```

## **ライセンスの適用**

以下は、評価パッケージをライセンス版に変える「数行のコード」です。`Presentation` オブジェクトが作成される前、アプリケーションの起動時に一度ライセンスを適用してください。以前に作成されたプレゼンテーションは評価用の透かしが残ります。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` は `Stream` も受け取ります。ライセンスが埋め込みリソースとして提供される場合、ファイルではなくストリームを使用する方が適しています。パスが間違っているかファイルが期限切れの場合は例外がスローされるため、失敗は起動時にすぐに検出され、評価モードに静かに戻ることはありません。

ライセンスを適用すると透かしが消え、1 スライドのテキスト抽出制限が解除されます。

## **FAQ**

### 評価モードで複数のプレゼンテーションを異なるスレッドで並列にテストできますか？

はい。異なるドキュメントを並列に処理できます。同じ `Presentation` オブジェクトをスレッド間で共有しないでください [across threads](/slides/ja/net/multithreading/)。評価モードはこれに影響しません。

### サーバーや CI でライブラリを評価するために Microsoft PowerPoint をインストールする必要がありますか？

いいえ。Aspose.Slides はスタンドアロン エンジンであり、評価でも本番でも PowerPoint のインストールは不要です。

### 評価モードで PPT/PPTX から PDF や画像への変換を完全にテストできますか？

はい。[converters](/slides/ja/net/convert-presentation/) は動作します。出力には透かしが含まれます。

### 透かしなしでロードテストを行うために一時ライセンスを使用できますか？

はい。30 日間の一時ライセンスは評価モードの制限を解除し、透かしなしでテストできます。