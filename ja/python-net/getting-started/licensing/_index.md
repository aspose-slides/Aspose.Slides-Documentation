---
title: ライセンス
description: "Aspose.Slides for Python via .NETは、購入のためのさまざまなプランを提供するか、ライセンスおよびサブスクリプションポリシーを使用して評価用の無料トライアルおよび30日間の一時ライセンスを提供します。"
type: docs
weight: 80
url: /ja/python-net/licensing/
---

## **Aspose.Slidesの評価**

{{% alert color="primary" %}} 

**Aspose.Slides for Python via .NET**の評価版を[ダウンロードページ](https://pypi.org/project/Aspose.Slides/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入したパッケージと同じです。評価版は、ライセンスを適用するためにいくつかのコード行を追加すると、単にライセンス版になります。

**Aspose.Slides**の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。異なるサブスクリプションの種類を確認することをお勧めします。質問がある場合は、Asposeの営業チームにお問い合わせください。

すべてのAsposeライセンスには、サブスクリプション期間内にリリースされた新しいバージョンや修正への無料アップグレードが付いてきます。ライセンス製品を持つユーザーや評価版を使用しているユーザーにも、無制限の技術サポートが提供されます。

{{% /alert %}} 

**評価版の制限事項**

* Aspose.Slides評価版（ライセンスが指定されていない）は完全な製品機能を提供しますが、開いて保存する操作時にドキュメントの上部に評価用の透かしを挿入します。
* プレゼンテーションスライドからテキストを抽出する際は、1枚のスライドに制限されます。

{{% alert color="primary" %}} 

制限なくAspose.Slidesをテストするには、**30日間の一時ライセンス**を請求できます。詳しくは[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)をご覧ください。

{{% /alert %}}

## **Aspose.Slidesのライセンス**

* 評価版はライセンスを購入し、ライセンスを適用するためにいくつかのコード行を追加するとライセンス版になります。
* ライセンスは、製品名、ライセンスが付与されている開発者数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。
* ライセンスファイルはデジタル署名されているため、ファイルを変更しないでください。たとえ無意識に余分な改行を追加しても、それが無効になります。
* Aspose.Slides for Python via .NETは通常、以下の場所でライセンスを見つけようとします：
  * 明示的なパス
  * Aspose.Slides for Python via .NETを呼び出すPythonスクリプトがあるフォルダ
* 評価版に関連する制限を回避するには、Aspose.Slidesを使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに1回ライセンスを設定するだけです。

{{% alert color="primary" %}} 

[メーター制ライセンス](/slides/ja/python-net/metered-licensing/)を確認することをお勧めします。

{{% /alert %}} 


## **ライセンスの適用**

ライセンスは**ファイル**、**ストリーム**、または**埋め込みリソース**から読み込むことができます。 

{{% alert color="primary" %}}

Aspose.Slidesではライセンス操作のために[License](https://reference.aspose.com/slides/python-net/aspose.slides/license/)クラスが提供されています。

{{% /alert %}} 

### **ファイル**

ライセンスを設定する最も簡単な方法は、ライセンスファイルをコンポーネントのDLL（Aspose.Slidesに含まれる）と同じフォルダに置き、そのパスなしでファイル名を指定することです。

このPythonコードは、ライセンスファイルを設定する方法を示しています：

``` python
import aspose.slides as slides

# Licenseクラスをインスタンス化
license = slides.License()

# ライセンスファイルのパスを設定
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置いた場合、[License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/)メソッドを呼び出すとき、指定された明示的なものの最後にあるライセンスファイル名は、あなたのライセンスファイルと同じでなければなりません。

たとえば、ライセンスファイル名を*Aspose.Slides.lic.xml*に変更できます。次に、コード内で、ファイルへのパス（*Aspose.Slides.lic.xml*で終了）を[License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/)メソッドに渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスを読み込むことができます。このPythonコードは、ストリームからライセンスを適用する方法を示しています：

``` python
import aspose.slides as slides

# Licenseクラスをインスタンス化
license = slides.License()

# ストリームを通じてライセンスを設定
license.set_license(stream)
```

## **ライセンスの検証**

ライセンスが正しく設定されているか確認するには、検証することができます。このPythonコードは、ライセンスを検証する方法を示しています：

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("ライセンスが有効です！")
```

## **スレッドセーフ**

{{% alert title="注" color="warning" %}} 

[License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/)メソッドはスレッドセーフではありません。このメソッドが多くのスレッドから同時に呼び出される必要がある場合は、問題を避けるために同期プリミティブ（ロックなど）を使用することをお勧めします。

{{% /alert %}}