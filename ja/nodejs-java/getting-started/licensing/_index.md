---
title: ライセンス
description: "Aspose.Slides for Node.js via Java は、購入用のさまざまなプランを提供し、ライセンスおよびサブスクリプション ポリシーを使用した評価のために、無料トライアルと 30 日間の一時ライセンスを提供します。"
type: docs
weight: 80
url: /ja/nodejs-java/licensing/
---

場合によっては、最適な評価結果を得るために実際に試すアプローチが必要になることがあります。そのため、Aspose.Slides はさまざまな購入プランを提供し、無料トライアルと評価用の 30 日間の一時ライセンスも提供しています。

{{% alert color="primary" %}}
評価方法、正しいライセンス取得、製品の購入に関する一般的なポリシーや実務が多数あります。これらは ["購入ポリシーと FAQ"](https://purchase.aspose.com/policies) セクションで確認できます。
{{% /alert %}}

## **Aspose.Slides の評価**
Aspose.Slides を簡単にダウンロードして評価できます。評価パッケージは購入パッケージと同一です。評価版はライセンスを適用するコードを数行追加するだけで、正規ライセンス版になります。

## **評価版の制限**
ライセンスが指定されていない Aspose.Slides の評価版は、製品の全機能を提供しますが、開く、保存するたびに文書の上部に評価用の透かしが挿入されます。また、プレゼンテーションスライドからテキストを抽出する際は、1枚のスライドに限定されます。

{{% alert color="primary" %}} 
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 Day Temporary License** をリクエストできます。詳細は [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) を参照してください。
{{% /alert %}} 

## **ライセンスについて**
Node.js 用の Aspose.Slides の評価版は、Java 経由で [download page](https://releases.aspose.com/slides/nodejs-java/) から簡単にダウンロードできます。評価版は Aspose.Slides の正規版と **同一の機能** を提供します。さらに、ライセンスを購入し、ライセンス適用のコードを数行追加するだけで、評価版は正規版となります。

ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプションの有効期限などの詳細が含まれます。このファイルはデジタル署名されているため、変更しないでください。余分な改行を追加しただけでも無効になります。

評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば十分です。

{{% alert color="primary" %}}
[Metered Licensing](https://docs.aspose.com/slides/nodejs-java/metered-licensing/) をご覧になるとよいでしょう。
{{% /alert %}}

## **購入ライセンス**
購入後は、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}
ライセンスは以下のように設定する必要があります:
* アプリケーションドメインごとに一度だけ
* 他の Aspose.Slides クラスを使用する前に
{{% /alert %}}

{{% alert color="primary" %}}
価格情報は ["Pricing Information"](https://purchase.aspose.com/pricing/slides/family) ページで確認できます。
{{% /alert %}}

### **Node.js 用 Aspose.Slides（Java 経由）でのライセンス設定**
ライセンスは次の場所から適用できます:
* 明示的なパス
* ストリーム
* Metered License として – 新しいライセンス方式

{{% alert color="primary" %}}
コンポーネントのライセンスには **setLicense** メソッドを使用します。

**setLicense** を複数回呼び出しても問題はありませんが、リソース（プロセッサ）の無駄になります。
{{% /alert %}}

{{% alert color="warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。それ以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

#### **ファイルを使用したライセンスの適用**
以下のコードスニペットはライセンスファイルを設定するためのものです:

**Node.js**
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```


setLicense メソッドを呼び出す際は、ライセンス名をライセンスファイルと同じにする必要があります。例えば、ライセンスファイル名を "Aspose.Slides.lic.xml" に変更できます。その場合、コード内で setLicense メソッドに新しいライセンス名 (Aspose.Slides.lic.xml) を渡す必要があります。

#### **ストリームからのライセンスの適用**
以下のコードスニペットはストリームからライセンスを適用するためのものです:

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

**完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？**
はい。ライセンスの検証はライセンスファイルを使用してローカルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ ライブラリは動作しなくなりますか？**
いいえ。ライセンスは永久的なもので、サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できます。ただし、更新しない限り新しいリリースは利用できません。