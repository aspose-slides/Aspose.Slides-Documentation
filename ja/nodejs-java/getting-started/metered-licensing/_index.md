---
title: 従量課金ライセンス
type: docs
weight: 100
url: /ja/nodejs-java/metered-licensing/
keywords:
- ライセンス
- 従量課金ライセンス
- Node.js
- Java
- Node.js via Java 用 Aspose.Slides
---

## **メータードキーの適用**

{{% alert color="primary" %}} 

メータードライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金されるようにしたい場合は、メータードライセンスを選択します。

メータードライセンスを購入すると、キーが提供され（ライセンス ファイルはありません）。このメータードキーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) クラスを使用して適用できます。詳細は、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) クラスのインスタンスを作成します。

2. 公開キーとプライベートキーを [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey) メソッドに渡します。

3. 処理（タスクの実行）を行います。

4. `Metered` クラスの [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) メソッドを呼び出します。

これまでに消費した API リクエストの数/量が表示されます。

このサンプルコードは、メータードライセンスの使用方法を示しています:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creates an instance of the Metered class
// Metered クラスのインスタンスを作成します
// Passes the public and private keys to the Metered object
// Metered オブジェクトに公開キーとプライベートキーを渡します
// Gets the consumed quantity value before API calls
// API 呼び出し前に消費された数量の値を取得します
// Do something with Aspose.Slides API here
// ここで Aspose.Slides API を使用して何か処理を行います
// ...

// Gets the consumed quantity value after API calls
// API 呼び出し後に消費された数量の値を取得します
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Do something with Aspose.Slides API here
// ...

var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

メータードライセンスを使用するには、ライセンス機構がインターネットを介して当社のサービスと継続的にやり取りし、計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **FAQ**

**同じアプリケーションでメータードライセンスと通常のライセンス（永久または一時）を併用できますか？**

はい。メータードは、既存の [licensing methods](/slides/ja/nodejs-java/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するかを選択します。

**メータードライセンスでの消費は正確には何がカウントされますか：操作ですか、ファイルですか？**

API の使用量がカウントされます。つまりリクエストまたは操作の回数です。現在の消費量は、[consumption-tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) で取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境にメータードは適していますか？**

はい。計算は API 呼び出し単位で行われるため、頻繁なコールドスタートがあるシナリオでも、メータード計算用の安定したネットワークアクセスさえ確保できれば対応可能です。

**メータードライセンスと永久ライセンスを使用した場合で、ライブラリの機能に違いはありますか？**

いいえ。これはライセンスおよび課金の仕組みの違いであり、製品の機能は同一です。

**メータードはトライアル版や一時ライセンスとどのように関係していますか？**

トライアル版は制限と透かしがあります。[temporary license](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除し、メータードは制限を解除し、実際の使用量に基づいて課金します。

**消費しきい値を超えた際に自動で反応し、予算を管理できますか？**

はい。一般的な方法は、[tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) を使用して定期的に現在の消費量を取得し、アプリケーションや監視レベルで独自の制限やアラートを実装することです。