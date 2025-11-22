---
title: 従量課金ライセンス
type: docs
weight: 90
url: /ja/net/metered-licensing/
keywords:
- ライセンス
- 従量課金ライセンス
- C#
- Aspose.Slides for .NET
---

## **メーターキーの適用**

{{% alert color="primary" %}} 

メーターライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に応じて課金されることを希望する場合は、メーターライセンスを選択します。

メーターライセンスを購入すると、キー（ライセンスファイルではありません）が提供されます。このメーターキーは、Aspose が提供するメーター処理用の [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) クラスを使用して適用できます。詳細は [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) クラスのインスタンスを作成します。  
2. 公開キーと非公開キーを [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) メソッドに渡します。  
3. 処理（タスクの実行）を行います。  
4. `Metered` クラスの [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) メソッドを呼び出します。

これまでに消費した API リクエストの量（件数）が表示されます。

以下のサンプルコードは、メーターライセンスの使用方法を示しています。

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

メーターライセンスを使用するには、ライセンス機構がインターネット経由で当社サービスと継続的にやり取りし計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **FAQ**

**同じアプリケーションで、通常の（永続または一時）ライセンスとメーターライセンスを併用できますか？**

はい。メーターは既存の [ライセンス方法](/slides/ja/net/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**メーターライセンスで消費とみなされるのは、操作ですかファイルですか？**

API の使用量がカウントされます。つまりリクエストまたは操作の回数です。現在の消費量は [消費追跡メソッド](https://reference.aspose.com/slides/net/aspose.slides/metered/) で取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でメーターは適していますか？**

はい。請求は API 呼び出し単位で行われるため、コールドスタートが頻繁に発生するシナリオでも、メーター計算のための安定したネットワーク接続が確保できれば問題ありません。

**メーターライセンスを使用した場合、永続ライセンスと比べてライブラリの機能に違いはありますか？**

いいえ。ライセンスおよび課金機構だけが異なり、製品機能は同一です。

**メーターは評価版や一時ライセンスとどのように関係しますか？**

評価版は機能制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。メーターは制限を解除し、実際の使用量に基づいて課金します。

**消費閾値を超えたときに自動で予算を制御できますか？**

はい。一般的な手法として、[追跡メソッド](https://reference.aspose.com/slides/net/aspose.slides/metered/) で現在の消費量を定期的に取得し、アプリケーションまたは監視レベルで独自の上限やアラートを実装します。