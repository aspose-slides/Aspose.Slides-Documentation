---
title: メータリング ライセンス
type: docs
weight: 90
url: /ja/python-net/metered-licensing/
keywords:
- ライセンス
- メータリング ライセンス
- ライセンス キー
- 公開キー
- プライベートキー
- 消費量
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のメータリング ライセンスを使用すると、PowerPoint と OpenDocument ファイルを柔軟に処理でき、使用した分だけ支払うことができます。"
---

## **メータリングキーの適用**

{{% alert color="primary" %}} 

メータリング ライセンスは、既存のライセンス方式と併用できる新しいライセンス メカニズムです。Aspose.Slides API の機能使用量に基づいて課金されたい場合は、メータリング ライセンスを選択します。

メータリング ライセンスを購入すると、キー（ライセンス ファイルはありません）が提供されます。このメータリング キーは、Aspose が提供するメータリング操作用の [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) クラスで適用できます。詳細については、[Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) を参照してください。

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) クラスのインスタンスを作成します。  
1. 公開キーと非公開キーを [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) メソッドに渡します。  
1. 処理（タスクの実行）を行います。  
1. `Metered` クラスの [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) メソッドを呼び出します。  

これまでに消費した API リクエストの数量/量が表示されます。

このサンプルコードは、メータリング ライセンスの使用方法を示しています：
```python
import aspose.slides as slides

# Meteredクラスのインスタンスを作成します
metered = slides.Metered()

# 公開キーと非公開キーをMeteredオブジェクトに渡します
metered.set_metered_key("<valid public key>", "<valid private key>")

# API呼び出し前に消費された数量の値を取得します
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# ここでAspose.Slides APIを使用して何か処理を行います
# ...

# API呼び出し後に消費された数量の値を取得します
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="NOTE"  %}} 

メータリング ライセンスを使用するには、インターネット接続が安定している必要があります。ライセンス メカニズムはインターネットを介して当社のサービスと継続的にやり取りし、計算を行うためです。

{{% /alert %}} 

## **よくある質問**

**メータリング ライセンスを、通常のライセンス（永続または一時）と同じアプリケーションで同時に使用できますか？**

はい。メータリングは既存の [ライセンス方式](/slides/ja/python-net/licensing/) と併用できる追加のライセンス メカニズムです。アプリケーション起動時にどのメカニズムを適用するか選択します。

**メータリング ライセンスで消費としてカウントされるものは正確には何ですか：操作ですかファイルですか？**

API の使用量がカウントされます。つまり、リクエスト数または操作回数です。現在の消費量は [消費量追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) を使用して取得できます。

**インスタンスが頻繁に再起動するマイクロサービスやサーバーレス環境でもメータリングは適していますか？**

はい。課金は API 呼び出し単位で行われるため、コールドスタートが頻繁に発生するシナリオでも、メータリング計算のためのネットワーク接続が安定していれば問題ありません。

**メータリング ライセンスを使用した場合、永続ライセンスと比べてライブラリの機能に違いはありますか？**

いいえ。これはライセンスと課金のメカニズムに関する違いであり、製品の機能は同じです。

**メータリングはトライアル版や一時ライセンスとどう関係していますか？**

トライアル版には機能制限と透かしがあり、[一時ライセンス](https://purchase.aspose.com/temporary-license/) は 30 日間制限を解除します。メータリングは制限を解除し、実際の使用量に基づいて課金します。

**消費しきい値を超えたときに自動で予算を制御することはできますか？**

はい。一般的な方法として、[追跡メソッド](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) を定期的に呼び出して現在の消費量を取得し、アプリケーションまたは監視レベルで独自の制限やアラートを実装します。