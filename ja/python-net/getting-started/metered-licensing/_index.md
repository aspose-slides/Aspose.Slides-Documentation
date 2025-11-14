---
title: 従量制ライセンス
type: docs
weight: 90
url: /ja/python-net/metered-licensing/
keywords:
- ライセンス
- 従量制ライセンス
- ライセンスキー
- 公開鍵
- 秘密鍵
- 使用量
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET の従量制ライセンスを使用して、PowerPoint および OpenDocument ファイルを柔軟に処理し、使用した分だけ支払う方法を学びましょう。"
---

{{% alert color="primary" %}} 

メーターライセンスは、既存のライセンス方式と併用できる新しいライセンスメカニズムです。Aspose.Slides API機能の使用量に基づいて請求されることを希望する場合、メーターライセンスを選択します。

メーターライセンスを購入すると、キー（ライセンスファイルではなく）を受け取ります。このメーターキーは、Asposeがメーター操作のために提供した[Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)クラスを使用して適用できます。詳細については、[メーターライセンスに関するFAQ](https://purchase.aspose.com/faqs/licensing/metered)を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)クラスのインスタンスを作成します。
1. `set_metered_key`メソッドに公開キーと秘密キーを渡します。
1. 一部の処理を行います（タスクを実行します）。
1. Meteredクラスの`get_consumption_quantity()`メソッドを呼び出します。

   これまでに消費したAPIリクエストの量/数量が表示されるはずです。

以下のPythonコードは、メーター公開キーと秘密キーを設定する方法を示しています：

```python
import aspose.slides as slides

# CAD Meteredクラスのインスタンスを作成
metered = slides.Metered()

# set_metered_keyプロパティにアクセスし、公開キーと秘密キーをパラメータとして渡す
metered.set_metered_key("*****", "*****")

# APIを呼び出す前のメーターデータ量を取得
amountbefore = slides.metered.get_consumption_quantity()
# 情報を表示
print("消費量（呼び出し前）: " + str(amountbefore))

# ディスクからドキュメントを読み込む。
with slides.Presentation("Presentation.pptx") as pres:
   # ドキュメントのページ数を取得
   print(len(pres.slides))
   # PDFとして保存
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# APIを呼び出した後のメーターデータ量を取得
amountafter = slides.metered.get_consumption_quantity()
# 情報を表示
print("消費量（呼び出し後）: " + str(amountafter))
```

{{% alert color="warning" title="注意"  %}} 

メーターライセンスを使用するには、ライセンスメカニズムがインターネットを使って常に私たちのサービスと相互作用し、計算を行うため、安定したインターネット接続が必要です。

{{% /alert %}} 