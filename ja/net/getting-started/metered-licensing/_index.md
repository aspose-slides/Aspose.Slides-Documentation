---
title: メーター制ライセンス
type: docs
weight: 90
url: /ja/net/metered-licensing/
---

{{% alert color="primary" %}} 

メーター制ライセンスは、既存のライセンス方式と併用できる新しいライセンスメカニズムです。Aspose.Slides API機能の使用量に基づいて請求されることを希望する場合は、メーター制ライセンスを選択します。

メーター制ライセンスを購入すると、ライセンスファイルではなくキーが提供されます。このメーターキーは、Asposeが測定操作のために提供した[Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)クラスを使用して適用できます。詳細については、[メーター制ライセンスのFAQ](https://purchase.aspose.com/faqs/licensing/metered)を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)クラスのインスタンスを作成します。
1. [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/)メソッドに公開鍵と秘密鍵を渡します。
1. いくつかの処理を行います（タスクを実行します）。
1. メータークラスの[GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/)メソッドを呼び出します。

   これまでに消費したAPIリクエストの量/数量を確認できるはずです。

このC#コードは、メーター制の公開鍵と秘密鍵を設定する方法を示しています。

```c#
//  Meteredクラスのインスタンスを作成する
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  SetMeteredKeyプロパティにアクセスし、公開鍵と秘密鍵をパラメータとして渡す
	metered.SetMeteredKey("*****", "*****");

//  API呼び出し前のメーターデータ量を取得する
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  情報を表示する
	Console.WriteLine("消費した量（前）: " + amountbefore.ToString());

//  API呼び出し後のメーターデータ量を取得する
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  情報を表示する
	Console.WriteLine("消費した量（後）: " + amountafter.ToString());
```

{{% alert color="warning" title="注意"  %}} 

メーター制ライセンスを使用するには、ライセンスメカニズムがインターネットを使用して私たちのサービスと常に対話し、計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 