---
title: メーター制ライセンス
type: docs
weight: 90
url: /ja/python-net/metered-licensing/
keywords:
- ライセンス
- メーター制ライセンス
- ライセンスキー
- 公開キー
- 秘密キー
- 消費量
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のメーター制ライセンスを使用して、PowerPoint および OpenDocument ファイルを柔軟に処理し、使用した分だけ支払う方法を学びます。"
---

## **メーターキーの適用**

{{% alert color="primary" %}} 

メーター制ライセンスは、既存のライセンス手法と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金したい場合は、メーター制ライセンスを選択します。

メーター制ライセンスを購入すると、キー（ライセンスファイルではありません）が提供されます。このメーターキーは、Aspose がメーター操作用に提供する [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) クラスで適用できます。詳細は [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) クラスのインスタンスを作成します。
1. 公開キーと秘密キーを [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) メソッドに渡します。
1. 何らかの処理（タスク）を実行します。
1. `Metered` クラスの [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) メソッドを呼び出します。

これまでに消費した API リクエストの量/数が表示されます。

このサンプルコードは、メーター制ライセンスの使用方法を示しています:

```python
import aspose.slides as slides

# Metered クラスのインスタンスを作成します
metered = slides.Metered()

# 公開キーと秘密キーを Metered オブジェクトに渡します
metered.set_metered_key("<valid public key>", "<valid private key>")

# API 呼び出し前の消費量を取得します
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Aspose.Slides API を使用して何か処理を行います
# ...

# API 呼び出し後の消費量を取得します
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

メーター制ライセンスを使用するには、ライセンス機構がインターネットを介して継続的に当社サービスとやり取りし計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 

## **FAQ**

**メーター制ライセンスを通常のライセンス（永久または一時）と同じアプリケーションで併用できますか？**

はい。メーター制は既存の[ライセンス手法](/slides/ja/python-net/licensing/)と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**メーター制ライセンスでカウントされる消費は何ですか：操作ですか、ファイルですか？**

API の使用量がカウントされます。つまりリクエスト数または操作数です。現在の消費量は[消費量追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)で取得できます。

**メーター制はインスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境に適していますか？**

はい。会計が API 呼び出しレベルで行われるため、頻繁なコールドスタートがあるシナリオでも、メーター計算のための安定したネットワークアクセスさえあれば対応可能です。

**永続ライセンスと比較して、メーター制ライセンス使用時にライブラリの機能に違いがありますか？**

いいえ。これはライセンスと課金の仕組みの違いであり、製品の機能は同じです。

**メーター制は評価版や一時ライセンスとどのように関係していますか？**

評価版は制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/)は 30 日間制限を解除します。メーター制は制限を解除し、実際の使用量に基づいて課金します。

**消費閾値を超えた際に自動で予算を管理することはできますか？**

はい。一般的な方法は、[追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)で現在の消費量を定定期的に読み取り、アプリケーションまたは監視レベルで独自の上限やアラートを実装することです。