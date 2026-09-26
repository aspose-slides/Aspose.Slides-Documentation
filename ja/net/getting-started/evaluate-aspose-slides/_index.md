---
title: Aspose.Slides の評価
type: docs
weight: 120
url: /ja/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides を評価
- Aspose.Slides の評価
- 評価バージョン
- フル機能
- 評価用ウォーターマーク
- Aspose.Slides の購入
- 制限
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を評価し、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーション向けの API 機能を確認しましょう — 無料トライアルを開始してください。"
---
## **Aspose.Slides 評価**

評価用に Aspose.Slides をダウンロードできます。評価パッケージは購入したパッケージと同一で、ライセンスを適用する数行のコードを追加するとライセンスが有効になります。

ライセンスがない場合、Aspose.Slides は評価モードでフル機能を提供しますが、2 つの制限があります。保存する各プレゼンテーションのすべてのスライドに評価用ウォーターマークのテキストボックスが追加され、プレゼンテーションからコードが読み取るテキストは最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは全文が保存されます。

![評価用ウォーターマークが付いたスライド](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
評価バージョンの制限なしで Aspose.Slides をテストしたい場合は、**30 Day Temporary License** をリクエストできます。詳細については、[How to get a Temporary License?](https://purchase.aspose.com/temporary-license) を参照してください。
{{% /alert %}}

## **評価パッケージのインストール**

```bash
dotnet add package Aspose.Slides.NET
```

Linux と macOS では、代わりに Aspose.Slides.NET6.CrossPlatform パッケージを使用できます。[Installation](/slides/ja/net/installation/) を参照してください。

## **ライセンスの適用**

これが評価パッケージをライセンス済みパッケージに変える「数行のコード」です。アプリケーションの開始時にライセンスを一度適用し、`Presentation` オブジェクトが作成される前に実行してください。以前に作成されたプレゼンテーションは評価用ウォーターマークを保持したままです。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` は `Stream` も受け取ります。これは、ライセンスが埋め込みリソースとして提供され、ディスク上のファイルではない場合に適した方法です。パスが間違っているかファイルの有効期限が切れていると例外がスローされるため、評価モードに静かに戻ることなく、起動時に即座に失敗が検出されます。

ライセンスが適用されると、保存されたプレゼンテーションからウォーターマークが除去され、テキストは全文が読み取られます。

## **よくある質問**

### 評価モードで、異なるスレッド間で複数のプレゼンテーションを並行してテストできますか？

はい。異なるドキュメントを並行して処理できますが、同じ `Presentation` オブジェクトを[スレッド間で共有](/slides/ja/net/multithreading/)しないでください。評価モードはこれに影響しません。

### サーバーや CI でライブラリを評価するために Microsoft PowerPoint をインストールする必要がありますか？

いいえ。Aspose.Slides は単体エンジンであり、評価でも本番でも PowerPoint のインストールは不要です。

### 評価モードで PPT/PPTX を PDF や画像に変換するテストをフルに行えますか？

はい。[コンバータ](/slides/ja/net/convert-presentation/) は機能しますが、出力にはウォーターマークが含まれます。

### ウォーターマークなしで負荷テストを行うために一時ライセンスを使用できますか？

はい。30 日間の一時ライセンスは評価モードの制限を解除し、ウォーターマークなしでテストできます。