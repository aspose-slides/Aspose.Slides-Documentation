---
title: 従量課金ライセンス
type: docs
weight: 100
url: /ja/java/metered-licensing/
keywords:
- ライセンス
- 従量課金ライセンス
- ライセンスキー
- 公開キー
- 秘密キー
- 消費量
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の従量課金ライセンスを使用すると、PowerPoint および OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---
## **はじめに**

従量課金ライセンスは、既存のライセンス方式と併用できるライセンス方式です。Aspose.Slides API の機能使用量に基づいて請求される場合は、従量課金ライセンスを選択します。

## **従量課金キーの適用**

{{% alert color="info" %}} 

従量課金ライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて請求される場合は、従量課金ライセンスを選択します。

従量課金ライセンスを購入すると、キー（ライセンスファイルは付属しません）が提供されます。この従量課金キーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/metered/) クラスを使用して適用できます。詳細は [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/metered/) クラスのインスタンスを作成します。

2. 公開キーと秘密キーを `setMeteredKey` メソッドに渡します。

3. 処理を実行します（タスクを実行）。

4. `Metered` クラスの `getConsumptionQuantity` メソッドを呼び出します。

これまでに消費した API リクエストの数量が表示されます。

このサンプルコードは、従量課金ライセンスの使用方法を示しています：

```java
// Metered クラスのインスタンスを作成します
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // 公開キーと秘密キーを Metered オブジェクトに渡します
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API 呼び出し前の消費量の値を取得します
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // ここで Aspose.Slides API を使用して何か処理します
    // ...

    // API 呼び出し後の消費量の値を取得します
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

従量課金ライセンスを使用するには、ライセンス機構がインターネット経由で当社のサービスと継続的に通信し計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **FAQ**

### 同じアプリケーションで従量課金ライセンスと通常のライセンス（永続または一時）を併用できますか？

はい。従量課金は既存の[ライセンス方式](/slides/ja/java/licensing/)と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

### 従量課金ライセンスでの消費量は正確には何がカウントされますか：操作ですか、ファイルですか？

API の使用量がカウントされます。つまりリクエストまたは操作の回数です。現在の消費量は[消費量追跡メソッド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/metered/)で取得できます。

### インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でも従量課金は適していますか？

はい。会計が API 呼び出しレベルで行われるため、コールドスタートが頻繁に発生するシナリオでも、メータリング計算用のネットワークアクセスが安定していれば問題ありません。

### 永続ライセンスと比較して、従量課金ライセンス使用時にライブラリの機能は変わりますか？

いいえ。ライセンスや課金方式の違いだけで、製品の機能は同じです。

### 従量課金はトライアル版や一時ライセンスとどのように関係しますか？

トライアル版は機能制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/)は 30 日間制限を解除します。従量課金は制限を解除し、実際の使用量に基づいて課金します。

### 消費量が閾値を超えたときに自動で予算を制御できますか？

はい。一般的な方法として、[追跡メソッド]（https://reference.aspose.com/slides/ja/java/com.aspose.slides/metered/）で現在の消費量を定期的に取得し、アプリケーションや監視レベルで独自の上限やアラートを実装します。