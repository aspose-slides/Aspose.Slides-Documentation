---
title: ライセンス
description: "Aspose.Slides for Node.js via Javaは、さまざまな購入プランを提供するか、ライセンスおよびサブスクリプションポリシーを使用して評価のための無料トライアルおよび30日間の一時ライセンスを提供します。"
type: docs
weight: 80
url: /nodejs-java/licensing/
---

時には、最良の評価結果を得るために、実践的なアプローチが必要になることがあります。この理由から、Aspose.Slidesは異なる購入プランを提供し、また評価のために無料トライアルおよび30日間の一時ライセンスを提供しています。

{{% alert color="primary" %}}

評価、適切なライセンスの取得、製品の購入方法についてのガイドとなる一般的なポリシーと実践がいくつかあることに注意してください。これらは["購入ポリシーとFAQ"](https://purchase.aspose.com/policies)セクションに記載されています。

{{% /alert %}}

## **Aspose.Slidesの評価**
Aspose.Slidesの評価用パッケージを簡単にダウンロードできます。評価パッケージは購入したパッケージと同じです。評価版は、ライセンスを適用するために数行のコードを追加するとライセンス版になります。

## **評価版の制限**
Aspose.Slidesの評価版（ライセンスが指定されていない場合）は、製品の全機能を提供しますが、文書を開いたり保存したりすると、ドキュメントの上部に評価用の透かしが挿入されます。また、プレゼンテーションスライドからテキストを抽出する際は、スライド1枚に制限されます。

{{% alert color="primary" %}} 

評価版の制限なしでAspose.Slidesをテストしたい場合は、**30日間の一時ライセンス**をリクエストできます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)をご覧ください。

{{% /alert %}} 

## **ライセンスについて**
Aspose.Slides for Node.js via Javaの評価版を簡単に[ダウンロードページ](https://releases.aspose.com/slides/nodejs-java/)からダウンロードできます。評価版は、ライセンス版のAspose.Slidesと**全く同じ機能**を提供します。さらに、ライセンスを購入し、ライセンスを適用するために数行のコードを追加すると、評価版はライセンス版になります。

ライセンスは、製品名、ライセンスを受けている開発者の数、サブスクリプションの有効期限などの詳細が含まれたプレーンテキストのXMLファイルです。ファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に余分な改行を誤って追加すると、無効になります。

評価版に関連する制限を回避するには、**Aspose.Slides**を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに1回だけライセンスを設定する必要があります。

## 購入したライセンス

購入後、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}

ライセンスを設定する必要があります：
* アプリケーションドメインごとに1回だけ
* 他のAspose.Slidesクラスを使用する前に

{{% /alert %}}

{{% alert color="primary" %}}

[“価格情報”](https://purchase.aspose.com/pricing/slides/family)ページで価格情報を確認できます。

{{% /alert %}}

### **Aspose.Slides for Node.js via Javaでライセンスを設定する**

ライセンスは以下の場所から適用できます：

* 明示的なパス
* ストリーム
* メーターライセンスとして – 新しいライセンスメカニズム

{{% alert color="primary" %}}

**setLicense**メソッドを使用してコンポーネントにライセンスを設定します。

**setLicense**への複数の呼び出しは有害ではありませんが、リソース（プロセッサ）の無駄です。

{{% /alert %}}

#### **ファイルを使用してライセンスを適用する**

このコードスニペットはライセンスファイルを設定するために使用されます：

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

setLicenseメソッドを呼び出す際、ライセンス名はライセンスファイルの名前と同じである必要があります。たとえば、ライセンスファイル名を"Aspose.Slides.lic.xml"に変更できます。次に、コード内では新しいライセンス名（Aspose.Slides.lic.xml）をsetLicenseメソッドに渡す必要があります。

#### **ストリームからライセンスを適用する**

このコードスニペットはストリームからライセンスを適用するために使用されます：

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

#### メーターライセンスの適用

Aspose.Slidesは、開発者がメーターキーを適用できるようにします。これは新しいライセンスメカニズムです。

新しいライセンスメカニズムは、既存のライセンス方法とともに使用されます。API機能の使用に基づいて請求されることを希望する顧客は、メーターライセンスを利用できます。

この種類のライセンスを取得するためのすべての必要な手順を完了すると、ライセンスファイルではなくキーが受け取ります。このメーターキーは、特にこの目的のために導入された**Metered**クラスを使用して適用できます。

次のコード例は、メーター公開鍵と秘密鍵を設定する方法を示しています：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

# CADメータークラスのインスタンスを作成
var metered = new aspose.slides.Metered();

# set_metered_keyプロパティにアクセスし、公開鍵と秘密鍵をパラメータとして渡します
metered.setMeteredKey("*****", "*****");

# API呼び出し前のメーターデータ量を取得
var amountbefore = aspose.slides.Metered.getConsumptionQuantity();
# 情報を表示
console.log('消費量（呼び出し前）: " + amountbefore + "' );

# ディスクからドキュメントをロードします。
var pres = new aspose.slides.Presentation();
# ドキュメントのページ数を取得
console.log('消費量（呼び出し後）: " +  pres.getSlides().size()) + "' );
# PDFとして保存
pres.save("out_pdf.pdf", aspose.slides.SaveFormat.Pdf);

# API呼び出し後のメーターデータ量を取得
var amountafter = aspose.slides.Metered.getConsumptionQuantity();
# 情報を表示
console.log('消費量（呼び出し後）: " + amountafter + "' );
```

{{% alert color="primary" %}}

メーターライセンスの正しい使用のためには、安定したインターネット接続が必要です。メーターシステムは、正確な計算のために当社のサービスとの継続的な相互作用を要求します。詳細については、[“メーターライセンスFAQ”](https://purchase.aspose.com/faqs/licensing/metered)セクションをご覧ください。

{{% /alert %}}