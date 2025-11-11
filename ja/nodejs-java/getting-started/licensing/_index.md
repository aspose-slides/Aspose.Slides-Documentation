---
title: "ライセンス"
description: "Aspose.Slides for Node.js via Java は、購入プランが異なるか、無料トライアルと30日間の一時ライセンスを提供し、ライセンスおよびサブスクリプション ポリシーを使用した評価が可能です。"
type: docs
weight: 80
url: /ja/nodejs-java/licensing/
---

時には、最良の評価結果を得るために実践的なアプローチが必要になることがあります。そのため、Aspose.Slides はさまざまな購入プランを提供し、無料トライアルと30日間の一時ライセンスも提供しています。

{{% alert color="primary" %}}
評価方法、適切なライセンス取得、製品の購入方法についての一般的なポリシーや慣行が多数あります。これらは[「購入ポリシーとFAQ」](https://purchase.aspose.com/policies)セクションで確認できます。
{{% /alert %}}

## **Aspose.Slides の評価**
Aspose.Slides を簡単にダウンロードして評価できます。評価パッケージは購入パッケージと同一です。評価版は、ライセンスを適用する数行のコードを追加するだけで、ライセンス版になります。

## **評価版の制限**
ライセンスが指定されていない Aspose.Slides の評価版は、製品の全機能を提供しますが、開くまたは保存する際に文書の上部に評価用ウォーターマークが挿入されます。また、プレゼンテーション スライドからテキストを抽出する場合は、1 スライドに制限されます。

{{% alert color="primary" %}} 
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)をご参照ください。
{{% /alert %}} 

## **ライセンスについて**
Aspose.Slides for Node.js via Java の評価版は、[ダウンロードページ](https://releases.aspose.com/slides/nodejs-java/)から簡単に取得できます。評価版は、ライセンス版と**全く同じ機能**を提供します。さらに、ライセンスを購入し、数行のコードでライセンスを適用すれば、評価版はライセンス版になります。

ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの詳細が含まれます。このファイルはデジタル署名されているため、変更しないでください。余分な改行を追加しただけでも無効になります。

評価版の制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに1回だけ設定すればよいです。

{{% alert color="primary" %}} 
[メーター制ライセンス](https://docs.aspose.com/slides/nodejs-java/metered-licensing/)をご覧になるとよいでしょう。
{{% /alert %}} 

## **購入ライセンス**
購入後は、ライセンス ファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}
ライセンスを設定する必要があります:
* アプリケーション ドメインごとに1回だけ
* 他の Aspose.Slides クラスを使用する前に
{{% /alert %}}

{{% alert color="primary" %}}
[「価格情報」](https://purchase.aspose.com/pricing/slides/family)ページで価格情報をご確認いただけます。
{{% /alert %}}

### **Aspose.Slides for Node.js via Java でのライセンス設定**
ライセンスは次の場所から適用できます:

* 明示的なパス
* ストリーム
* メーター制ライセンスとして – 新しいライセンス方式

{{% alert color="primary" %}}
**setLicense** メソッドを使用してコンポーネントにライセンスを設定します。

**setLicense** を複数回呼び出しても問題はありませんが、リソース（プロセッサ）の無駄になります。
{{% /alert %}}

{{% alert color="warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

#### **ファイルを使用したライセンスの適用**
以下のコードスニペットは、ライセンス ファイルを設定するためのものです:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

#### **ストリームからのライセンス適用**
以下のコードスニペットは、ストリームからライセンスを適用するためのものです:

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

## **FAQ**

**完全にオフライン環境（インターネットアクセスなし）でライセンスを適用できますか？**

はい。ライセンスの検証はライセンス ファイルを使用してローカルで行われるため、インターネット接続は不要です。

**1 年のサブスクリプションが期限切れになるとどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。