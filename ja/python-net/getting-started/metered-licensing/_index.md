---
title: メータード ライセンス
type: docs
weight: 90
url: /ja/python-net/metered-licensing/
keywords:
- ライセンス
- メータード ライセンス
- ライセンス キー
- 公開キー
- 秘密キー
- 消費量
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のメータード ライセンスを使用して、PowerPoint および OpenDocument ファイルを柔軟に処理し、使用量に応じて支払う方法を学びます。"
---

## **メータード キーの適用**

{{% alert color="primary" %}} 

メータード ライセンスは、既存のライセンス手法と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金したい場合は、メータード ライセンスを選択してください。

メータード ライセンスを購入すると、キー（ライセンスファイルではありません）が提供されます。このメータード キーは、Aspose が提供する [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) クラスを使用して適用できます。詳細は、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. Metered クラスのインスタンスを作成します。
2. 公開キーと秘密キーを [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) メソッドに渡します。
3. 何らかの処理（タスク）を実行します。
4. `Metered` クラスの [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) メソッドを呼び出します。

これまでに消費した API リクエストの量/数量が表示されます。

このサンプルコードは、メータード ライセンスの使用方法を示しています。

```python
import aspose.slides as slides

# Metered クラスのインスタンスを作成
metered = slides.Metered()

# 公開キーと秘密キーを Metered オブジェクトに設定
metered.set_metered_key("<valid public key>", "<valid private key>")

# API 呼び出し前の消費量を取得
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# ここで Aspose.Slides API を使用した処理を実行
# ...

# API 呼び出し後の消費量を取得
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="注"  %}} 

メータード ライセンスを使用するには、インターネット接続が安定している必要があります。ライセンス機構はインターネットを使用してサービスと継続的にやり取りし、計算を行います。

{{% /alert %}} 

## **よくある質問**

**同じアプリケーションでメータード ライセンスと通常のライセンス（永続または一時）を併用できますか？**

はい。メータードは既存の [ライセンス手法](/slides/ja/python-net/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**メータード ライセンスでの消費量は正確には何がカウントされますか：操作ですか、ファイルですか？**

API の使用量がカウントされます。つまりリクエストまたは操作の数です。現在の消費量は [消費量追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) で取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でもメータードは適していますか？**

はい。会計は API 呼び出しレベルで行われるため、コールドスタートが頻繁に発生するシナリオでも問題ありません。ただし、メータード計算のために安定したネットワーク接続が必要です。

**メータード ライセンスと永続ライセンスで、ライブラリの機能に違いがありますか？**

いいえ。これはライセンスと課金の仕組みだけに関するもので、製品の機能は同一です。

**メータードは体験版や一時ライセンスとどのように関係していますか？**

体験版は機能制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。メータードは制限を解除し、実際の使用量に基づいて課金します。

**消費しきい値を超えたときに自動で反応し、予算を制御できますか？**

はい。一般的な方法は、[追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) を定期的に呼び出して現在の消費量を取得し、アプリケーションや監視レベルで独自の上限やアラートを実装することです。