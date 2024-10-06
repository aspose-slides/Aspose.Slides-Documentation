---
title: メータリングライセンス
type: docs
weight: 100
url: /ja/php-java/metered-licensing/
---

{{% alert color="primary" %}} 

メータリングライセンスは、既存のライセンス方法と併用できる新しいライセンスメカニズムです。Aspose.Slides API機能の使用量に基づいて請求されたい場合は、メータリングライセンスを選択します。

メータリングライセンスを購入すると、キーが提供されます（ライセンスファイルではありません）。このメータリングキーは、Asposeがメータリング操作のために提供した [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) クラスを使用して適用できます。詳細については、[メータリングライセンスのFAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 
1. [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) クラスのインスタンスを作成します。

1. 公開キーと秘密キーを [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) メソッドに渡します。

1. 処理を行います（タスクを実行します）。

1. Meteredクラスの [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) メソッドを呼び出します。

   これまでに消費したAPIリクエストの量/数量が表示されます。

このPHPコードは、メータリングの公開キーと秘密キーを設定する方法を示しています：

```php
  $metered = new Metered();
  try {
    // setMeteredKeyプロパティにアクセスし、公開キーと秘密キーをパラメータとして渡します
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");
    // APIにアクセスする前の消費数量の値を取得します
    $quantityOld = Metered->getConsumptionQuantity();
    echo("消費数量" . $quantityOld);
    // APIにアクセスした後の消費数量の値を取得します
    $quantity = Metered->getConsumptionQuantity();
    echo("消費数量" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="注意"  %}} 

メータリングライセンスを使用するには、ライセンスメカニズムがインターネットを使用して私たちのサービスと絶えず相互作用し、計算を実行するため、安定したインターネット接続が必要です。

{{% /alert %}} 