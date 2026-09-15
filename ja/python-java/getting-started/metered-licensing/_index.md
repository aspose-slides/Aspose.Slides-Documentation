---
title: 従量課金ライセンス
type: docs
weight: 100
url: /ja/python-java/metered-licensing/
keywords:
- ライセンス
- 従量課金ライセンス
- ライセンスキー
- 公開キー
- プライベートキー
- 消費量
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java の従量課金ライセンスを使用すると、PowerPoint と OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---
## **はじめに**

Metered ライセンスは、既存のライセンス方式と併用できるライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金されるようにしたい場合は、Metered ライセンスを選択してください。

## **Metered キーの適用**

{{% alert color="info" title="注" %}}
Metered ライセンスは、既存のライセンス方式と併用できる新しいライセンス機構です。Aspose.Slides API の機能使用量に基づいて課金されるようにしたい場合は、Metered ライセンスを選択してください。

Metered ライセンスを購入すると、キー（ライセンス ファイルは不要）を取得します。この Metered キーは、Aspose が提供する [Metered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) クラスを使用して適用できます。詳細は [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。
{{% /alert %}}

1. [Metered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) クラスのインスタンスを作成します。

1. 公開キーとプライベートキーを [setMeteredKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/#setMeteredKey) メソッドに渡します。

1. 処理（タスクの実行）を行います。

1. [Metered](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) クラスの [getConsumptionQuantity](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/#getConsumptionQuantity) メソッドを呼び出します。

これまでに消費した API リクエストの量/数が表示されます。

以下のサンプルコードは、Metered ライセンスの使用方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Metered クラスのインスタンスを作成します。
metered = Metered()

try:
    # Metered オブジェクトに公開キーとプライベートキーを渡します。
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # API 呼び出し前の消費量を取得します。
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # ここで Aspose.Slides API を使用して何らかの処理を行います。
    # ...

    # API 呼び出し後の消費量を取得します。
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="警告" %}}
Metered ライセンスを使用するには、ライセンス機構が継続的に当社のサービスと通信し計算を行うため、安定したインターネット接続が必要です。
{{% /alert %}}

## **FAQ**

**Metered ライセンスを通常のライセンス（永続または一時）と同じアプリケーションで併用できますか？**

はい。Metered は既存の [licensing methods](/slides/ja/python-java/licensing/) と併用できる追加のライセンス機構です。アプリケーション起動時にどの機構を適用するか選択します。

**Metered ライセンスでカウントされるのは、操作ですかファイルですか？**

API 使用量がカウント対象となります。つまりリクエスト数や操作回数です。現在の消費量は [consumption‑tracking methods](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) で取得できます。

**インスタンスの再起動が頻繁に起こるマイクロサービスやサーバーレス環境に Metered は適していますか？**

はい。会計が API 呼び出し単位で行われるため、コールドスタートが頻繁に発生するシナリオでも、Metered 計算のために安定したネットワーク接続が確保できれば問題ありません。

**Metered ライセンスを使用した場合、永続ライセンスと比べてライブラリの機能に違いがありますか？**

いいえ。これはライセンスおよび課金機構に関する違いだけで、製品の機能は同一です。

**Metered は体験版や一時ライセンスとどのように関係していますか？**

体験版は機能制限と透かしが付加され、[temporary license](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。一方、Metered は制限を解除し、実際の使用量に基づいて課金します。

**消費しきい値を超えた際に自動で予算を制御できますか？**

はい。一般的な方法は、[tracking methods](https://reference.aspose.com/slides/ja/python-java/aspose.slides/metered/) を使用して定期的に現在の消費量を取得し、アプリケーションや監視レベルで独自の上限やアラートを実装することです。