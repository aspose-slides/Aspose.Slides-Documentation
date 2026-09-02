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
description: ".NET 用 Aspose.Slides を評価し、PowerPoint (PPT, PPTX) および OpenDocument (ODP) プレゼンテーション向けの API 機能を確認しましょう――無料トライアルを開始してください。"
---
## **Aspose.Slides 評価版**

評価用に Aspose.Slides を簡単にダウンロードできます。評価パッケージは購入パッケージと同じです。評価版は、ライセンスを適用する数行のコードを追加するだけで正式にライセンスされたものになります。

ライセンスが指定されていない Aspose.Slides の評価版は、製品の全機能を提供しますが、開くおよび保存時にドキュメントの上部に評価用の透かしが挿入されます。また、プレゼンテーション スライドからテキストを抽出する際は、1 スライドに制限されます。

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細については、[How to get a Temporary License?](https://purchase.aspose.com/temporary-license) を参照してください。
{{% /alert %}}

## **評価パッケージのインストール**

```bash
dotnet add package Aspose.Slides.NET
```

## **ライセンスの適用**

これが評価パッケージをライセンス済みパッケージに変える「数行のコード」です。`Presentation` オブジェクトが作成される前に、アプリケーションの起動時にライセンスを一度適用してください。以前に作成されたプレゼンテーションは評価用の透かしを保持したままです。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` は `Stream` も受け付けます。これは、ライセンスがディスク上のファイルではなく埋め込みリソースとして提供される場合に好ましいオプションです。パスが間違っているかファイルが期限切れの場合、呼び出しは例外をスローし、起動時にすぐに失敗が表面化します。評価モードに静かに戻ることはありません。

ライセンスが適用されると透かしが消え、1 スライドのテキスト抽出制限が解除されます。

## **よくある質問**

### 評価モードで異なるスレッド間で複数のプレゼンテーションを並行してテストできますか？

はい。異なるドキュメントを並行して処理できます。同じ `Presentation` オブジェクトをスレッド間で共有すべきではありません[across threads](/slides/ja/net/multithreading/)。評価モードはこれに影響しません。

### サーバーや CI 環境でライブラリを評価するために Microsoft PowerPoint をインストールする必要がありますか？

いいえ。Aspose.Slides は単独エンジンであり、評価でも本番でも PowerPoint のインストールは不要です。

### 評価モードで PPT/PPTX を PDF や画像に変換するテストを完全に行えますか？

はい。[converters](/slides/ja/net/convert-presentation/) は機能します。出力には透かしが含まれます。

### 透かしなしで負荷テストに一時ライセンスを使用できますか？

はい。30 日間の一時ライセンスは評価モードの制限を解除し、透かしなしでテストできます。