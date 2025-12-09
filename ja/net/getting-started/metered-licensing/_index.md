---
title: メータード ライセンス
type: docs
weight: 90
url: /ja/net/metered-licensing/
keywords:
- ライセンス
- メータード ライセンス
- ライセンスキー
- 公開キー
- プライベートキー
- 消費量
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のメータード ライセンスを使用すると、PowerPoint および OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---

## **メータードキーの適用**

{{% alert color="primary" %}} 

メータードライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金したい場合は、メータードライセンスを選択します。

メータードライセンスを購入すると、キー（ライセンス ファイルではなく）を取得します。このメータードキーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) クラスを使用して適用できます。詳細については、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) クラスのインスタンスを作成します。
1. 公開キーと非公開キーを [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) メソッドに渡します。
1. 何らかの処理（タスクの実行）を行います。
1. `Metered` クラスの [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) メソッドを呼び出します。

これまでに消費した API リクエストの数／量が表示されます。

以下のサンプルコードは、メータードライセンスの使用方法を示しています。

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

メータードライセンスを使用するには、インターネット接続が安定している必要があります。ライセンス機構はインターネットを介して当社のサービスと常時通信し、計算を行うためです。

{{% /alert %}} 

## **FAQ**

**メータードライセンスを通常のライセンス（永続または一時）と同じアプリケーションで併用できますか？**

はい。メータードは既存の [licensing methods](/slides/ja/net/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を使用するか選択します。

**メータードライセンスで消費とみなされるのは操作ですか、ファイルですか？**

API の使用量がカウントされます。つまりリクエスト数または操作数です。現在の消費量は [consumption‑tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) で取得できます。

**メータードはインスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境に適していますか？**

はい。課金は API 呼び出し単位で行われるため、コールドスタートが頻繁に発生するシナリオでも、メータード計算用に安定したネットワーク接続さえ確保できれば問題ありません。

**メータードライセンスを使用した場合、永続ライセンスと比べてライブラリの機能に違いがありますか？**

いいえ。機能面での違いはなく、ライセンスと課金の仕組みだけが異なります。

**メータードは体験版や一時ライセンスとどのように関係しますか？**

体験版は機能制限とウォーターマークがあり、[temporary license](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。メータードは制限を解除し、実際の使用量に基づいて課金します。

**消費閾値を超えたときに自動的に予算を制御できますか？**

はい。一般的な方法は、[tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) で現在の消費量を定期的に取得し、アプリケーションや監視レベルで独自の上限やアラートを実装することです。