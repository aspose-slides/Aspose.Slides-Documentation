---
title: メーターライセンス
type: docs
weight: 100
url: /androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slidesは、開発者がメーターキーを適用することを可能にします。これは新しいライセンスメカニズムです。新しいライセンスメカニズムは、既存のライセンス方法と併用されます。API機能の使用量に基づいて請求されることを希望する顧客は、メーターライセンスを使用することができます。詳細については、[メーターライセンスのFAQ](https://purchase.aspose.com/faqs/licensing/metered)セクションを参照してください。

{{% /alert %}} 
## **メーターライセンス**
メータークラスを使用するための簡単な手順は次のとおりです。

1. メータークラスのインスタンスを作成します。

1. setMeteredKeyメソッドに公開キーと秘密キーを渡します。

1. 処理を行います（タスクを実行します）。

1. メータークラスのgetConsumptionQuantityメソッドを呼び出します。

   これにより、これまでに消費したAPIリクエストの量が返されます。

このサンプルコードは、メーターの公開キーと秘密キーを設定する方法を示しています：

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // setMeteredKeyプロパティにアクセスし、公開キーと秘密キーをパラメーターとして渡します
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // APIにアクセスする前に消費量の値を取得します
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消費量" + quantityOld);


    // APIにアクセスした後に消費量の値を取得します
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消費量" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```