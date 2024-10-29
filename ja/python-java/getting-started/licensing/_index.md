---
title: ライセンス
description: "Aspose.Slides for Python via Java は、購入用の異なるプランを提供するか、評価用のフリートライアルおよび30日間の一時ライセンスを提供しています。"
type: docs
weight: 80
url: /ja/python-java/licensing/
---

最良の評価結果を得るためには、実際に手を動かすアプローチが必要な場合があります。このため、Aspose.Slidesでは異なる購入プランを提供し、評価用のフリートライアルおよび30日間の一時ライセンスも提供しています。

{{% alert color="primary" %}}

評価、適切なライセンス取得、および製品購入の方法については、一般的なポリシーと実践がいくつかあります。これらは、["購入ポリシーとFAQ"](https://purchase.aspose.com/policies) セクションで確認できます。

{{% /alert %}}

## **Aspose.Slidesの評価**
Aspose.Slidesの評価版を簡単にダウンロードできます。評価パッケージは、購入したパッケージと同じです。評価版は、ライセンスを適用するために数行のコードを追加するだけでライセンス版に変わります。

## **評価版の制限**
Aspose.Slidesの評価版（ライセンスが指定されていないもの）は、製品の完全な機能を提供しますが、ドキュメントを開いたり保存したりすると、上部に評価用の透かしが挿入されます。また、プレゼンテーションスライドからテキストを抽出する際には、1スライドに制限されます。

{{% alert color="primary" %}} 

評価版の制限なしでAspose.Slidesをテストしたい場合は、**30日間の一時ライセンス**をリクエストできます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) を参照してください。

{{% /alert %}} 

## **ライセンスについて**
Aspose.Slides for Python via Java の評価版をその [ダウンロードページ](https://releases.aspose.com/slides/python-java/) から簡単にダウンロードできます。評価版は、ライセンス版と**まったく同じ機能**を提供します。さらに、ライセンスを購入し、ライセンスを適用するための数行のコードを追加するだけで、評価版はライセンス版になります。

ライセンスは、製品名、ライセンスされている開発者の数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。このファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に余分な改行を誤って追加するだけでも無効になります。

評価版に関連する制限を避けるには、**Aspose.Slides**を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとにライセンスを設定するのは一度だけで済みます。

## 購入したライセンス

購入後、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}

ライセンスを設定する必要があります：
* アプリケーションドメインごとに1回のみ
* 他のAspose.Slidesクラスを使用する前に

{{% /alert %}}

{{% alert color="primary" %}}

価格情報は、[「価格情報」](https://purchase.aspose.com/pricing/slides/family)ページで確認できます。

{{% /alert %}}

### **Aspose.Slides for Python via Javaでのライセンス設定**

ライセンスは、次の場所から適用できます：

* 明示的なパス
* ストリーム
* メーターライセンスとして – 新しいライセンスメカニズム

{{% alert color="primary" %}}

**setLicense**メソッドを使用してコンポーネントにライセンスを設定します。

**setLicense**への複数回の呼び出しは問題ありませんが、リソース（プロセッサ）の無駄になります。

{{% /alert %}}

#### **ファイルを使用したライセンスの適用**

このコードスニペットは、ライセンスファイルを設定するために使用されます：

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

setLicenseメソッドを呼び出すときは、ライセンス名はライセンスファイルの名前と同じでなければなりません。たとえば、ライセンスファイル名を「Aspose.Slides.lic.xml」に変更できます。その後、コード内で新しいライセンス名（Aspose.Slides.lic.xml）をsetLicenseメソッドに渡す必要があります。

#### **バイトからのライセンスの適用**

このコードスニペットは、バイトからライセンスを適用するために使用されます：

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### メーターライセンスの適用

Aspose.Slidesでは、開発者がメーターキーを適用できます。これは新しいライセンスメカニズムです。

新しいライセンスメカニズムは、既存のライセンス方式と併用されます。API機能の使用に基づいて請求を希望する顧客は、メーターライセンスを使用できます。

このタイプのライセンスを取得するために必要なすべての手順を完了すると、ライセンスファイルではなくキーが提供されます。このメーターキーは、この目的のために特別に導入された**Metered**クラスを使用して適用できます。

以下のコード例は、メーターの公開キーと秘密キーを設定する方法を示しています：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# CADメータークラスのインスタンスを作成
metered = Metered();

# set_metered_keyプロパティにアクセスし、公開キーと秘密キーをパラメータとして渡す
metered.setMeteredKey("*****", "*****");

# APIを呼び出す前のメーターデータ量を取得
amountbefore = Metered.getConsumptionQuantity()

# 情報を表示
print("消費量（前）: \" + amountbefore + \"" )

# ディスクからドキュメントをロード。
pres = Presentation();

# ドキュメントのページ数を取得
print("消費量（後）: \" +  pres.getSlides().size()) + \"" )

# PDFとして保存
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# APIを呼び出した後のメーターデータ量を取得
amountafter = Metered.getConsumptionQuantity()

# 情報を表示
print("消費量（後）: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

メーターライセンスの正しい使用には安定したインターネット接続が必須であることに注意してください。メーター機構は、正しい計算のために当社のサービスとの継続的な相互作用を必要とします。詳細については、[「メーターライセンスFAQ」](https://purchase.aspose.com/faqs/licensing/metered)セクションを参照してください。

{{% /alert %}}