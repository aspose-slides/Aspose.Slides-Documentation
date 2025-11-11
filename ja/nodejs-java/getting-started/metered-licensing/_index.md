---
title: メーター制ライセンス
type: docs
weight: 100
url: /ja/nodejs-java/metered-licensing/
keywords:
- ライセンス
- メーター制ライセンス
- Node.js
- Java
- Aspose.Slides for Node.js via Java
---

## **メーター制キーを適用する**

{{% alert color="primary" %}} 

メーター制ライセンスは、既存のライセンス方式と併用できる新しいライセンスメカニズムです。Aspose.Slides API の機能使用量に基づいて課金したい場合は、メーター制ライセンスを選択します。

メーター制ライセンスを購入すると、キー（ライセンス ファイルはありません）を取得します。このメーター制キーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) クラスで適用できます。詳細は [Metered ライセンス FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) クラスのインスタンスを作成します。

1. 公開キーとプライベートキーを [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey) メソッドに渡します。

1. 何らかの処理（タスクの実行）を行います。

1. `Metered` クラスの [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) メソッドを呼び出します。

これまでに消費した API リクエストの量/数が表示されます。

以下のサンプルコードは、メーター制ライセンスの使用方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Metered クラスのインスタンスを作成します
var metered = new aspose.slides.Metered();

// 公開キーとプライベートキーを Metered オブジェクトに渡します
metered.setMeteredKey("<valid public key>", "<valid private key>");

// API 呼び出し前に消費量の値を取得します
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Aspose.Slides API で何らかの処理を行います
// ...

// API 呼び出し後に消費量の値を取得します
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

メーター制ライセンスを使用するには、ライセンスメカニズムが常に当社サービスと通信して計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **FAQ**

**同じアプリケーションで、従来のライセンス（永続または一時）とメーター制ライセンスを併用できますか？**

はい。メーター制は既存の [ライセンス方式](/slides/ja/nodejs-java/licensing/) と併用できる追加のライセンスメカニズムです。アプリケーション起動時にどのメカニズムを適用するか選択します。

**メーター制ライセンスで消費としてカウントされるのは操作ですか、ファイルですか？**

API の使用量がカウントされます。つまりリクエストまたは操作の回数です。現在の消費量は [消費量追跡メソッド](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) で取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でメーター制は適していますか？**

はい。会計が API 呼び出し単位で行われるため、コールドスタートが頻繁に発生するシナリオでも、メーター計算用のネットワーク接続が安定していれば問題ありません。

**メーター制ライセンス使用時と永続ライセンス使用時で、ライブラリの機能に違いはありますか？**

いいえ。これはあくまでライセンスと課金のメカニズムの違いであり、製品の機能は同一です。

**メーター制はトライアル版や一時ライセンスとどのように関係していますか？**

トライアル版は機能制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。メーター制は制限を解除し、実際の使用量に基づいて課金します。

**消費しきい値を超えた際に自動で予算を制御できますか？**

はい。一般的な方法は、[追跡メソッド](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) を定期的に呼び出して現在の消費量を取得し、アプリケーションまたは監視レベルで独自の上限やアラートを実装することです。