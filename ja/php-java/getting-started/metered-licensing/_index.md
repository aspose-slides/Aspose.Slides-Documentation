---
title: メーターライセンス
type: docs
weight: 100
url: /ja/php-java/metered-licensing/
keywords:
- ライセンス
- メーターライセンス
- ライセンスキー
- 公開鍵
- プライベートキー
- 消費量
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のメーターライセンスを使用すると、PowerPoint および OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---

## **メーターキーの適用**

{{% alert color="primary" %}} 
メーターライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金したい場合は、メーターライセンスを選択します。

メーターライセンスを購入すると、キーが提供され（ライセンスファイルはありません）。このメーターキーは、Aspose が提供するメーター処理用の [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) クラスを使用して適用できます。詳しくは、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。
{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) クラスのインスタンスを作成します。

2. 公開キーとプライベートキーを [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) メソッドに渡します。

3. 処理を実行します（タスクを実行）。

4. `Metered` クラスの [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) メソッドを呼び出します。

これまでに消費した API リクエストの数/量が表示されます。

```php
// Metered クラスのインスタンスを作成します
$metered = new Metered();

try {
    // 公開キーとプライベートキーを Metered オブジェクトに渡します
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // API 呼び出し前の消費量の値を取得します
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // ここで Aspose.Slides API を使用して何か処理します
    // ...

    // API 呼び出し後の消費量の値を取得します
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="NOTE"  %}} 
メーターライセンスを使用するには、ライセンス機構がインターネットを介して当社のサービスと継続的にやり取りし計算を行うため、安定したインターネット接続が必要です。
{{% /alert %}} 

## **よくある質問**

**同じアプリケーションで、通常のライセンス（永続または一時）とメーターライセンスを併用できますか？**

はい。Metered は、既存の [licensing methods](/slides/ja/php-java/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**メーターライセンスの消費量は何がカウントされますか：操作ですかファイルですか？**

API の使用量がカウントされます。つまりリクエストまたは操作回数です。現在の消費量は [consumption‑tracking methods](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) を使用して取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバレス環境でもメーターは適していますか？**

はい。会計は API 呼び出しレベルで行われるため、頻繁なコールドスタートがあるシナリオでも、メーター計算のための安定したネットワーク接続が確保できれば問題ありません。

**永続ライセンスと比べて、メーターライセンス使用時にライブラリの機能が変わりますか？**

いいえ。これはライセンスと課金の仕組みだけで、製品の機能は同じです。

**メーターは体験版や一時ライセンスとどう関係しますか？**

体験版は制限と透かしがあり、[temporary license](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除し、メーターライセンスは使用量に基づいて課金し制限を解除します。

**消費しきい値を超えた際に自動で予算をコントロールできますか？**

はい。一般的な方法は、[consumption‑tracking methods](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) を定期的に呼び出して現在の消費量を取得し、アプリケーションや監視レベルで独自の上限やアラートを実装することです。