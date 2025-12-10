---
title: メータードライセンス
type: docs
weight: 100
url: /ja/java/metered-licensing/
keywords:
- ライセンス
- メータードライセンス
- ライセンスキー
- 公開鍵
- 秘密鍵
- 消費量
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のメータードライセンスを使用すると、PowerPoint および OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---

## **メータードキーの適用**

{{% alert color="primary" %}} 

メータードライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金された料金をご希望の場合は、メータードライセンスを選択してください。

メータードライセンスを購入すると、キーが提供され（ライセンスファイルはありません）。このメータードキーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) クラスで適用できます。詳細については、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) クラスのインスタンスを作成します。

1. 公開鍵と秘密鍵を [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) メソッドに渡します。

1. 処理（タスクの実行）を行います。

1. `Metered` クラスの [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) メソッドを呼び出します。

これまでに消費した API リクエストの数／量が表示されます。

以下のサンプルコードは、メータードライセンスの使用方法を示しています：

```java
// Creates an instance of the Metered class
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passes the public and private keys to the Metered object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Gets the consumed quantity value before API calls
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Do something with Aspose.Slides API here
    // ...

    // Gets the consumed quantity value after API calls
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

メータードライセンスを使用するには、ライセンス機構がインターネットを介して当社のサービスと常にやり取りし計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **よくある質問**

**同一アプリケーションでメータードライセンスと通常のライセンス（永久または一時）を併用できますか？**

はい。Metered は既存の [licensing methods](/slides/ja/java/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**メータードライセンスでは、消費量として正確に何がカウントされますか：操作かファイルか？**

API の使用がカウントされ、リクエスト数または操作回数が消費量となります。現在の消費量は [consumption-tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) で取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でメータードは適していますか？**

はい。課金は API コール単位で行われるため、頻繁なコールドスタートがあるシナリオでも、メータード計算のための安定したネットワーク接続が確保できれば問題ありません。

**永続ライセンスと比較して、メータードライセンス使用時にライブラリの機能は異なりますか？**

いいえ。これはライセンスおよび課金の仕組みの違いであり、製品の機能は同一です。

**メータードは体験版や一時ライセンスとどのように関係していますか？**

体験版は機能制限と透かしが付与され、[temporary license](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。一方、メータードは制限を解除し、実際の使用量に基づいて課金されます。

**消費量がしきい値を超えた際に自動で対応し、予算を管理できますか？**

はい。一般的な方法として、[tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) を定期的に呼び出して現在の消費量を取得し、アプリケーションまたは監視レベルで独自の上限やアラートを実装します。