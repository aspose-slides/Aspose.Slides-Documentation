---
title: ライセンス
description: "Aspose.Slides for Node.js via .NET は、購入のためのさまざまなプランを提供するか、ライセンスおよびサブスクリプションポリシーを使用して評価のための無料トライアルおよび30日間の一時ライセンスを提供します。"
type: docs
weight: 80
url: /nodejs-net/licensing/
---

時には、最良の評価結果を得るために、実地でのアプローチが必要になることがあります。この理由から、Aspose.Slidesはさまざまな購入プランを提供し、無料トライアルおよび30日間の一時ライセンスを評価用に提供します。

{{% alert color="primary" %}}

評価、適切なライセンス取得、および製品購入に関する一般的なポリシーと実践がいくつかあります。それらは["購入ポリシーおよびFAQ"](https://purchase.aspose.com/policies)セクションで見つけることができます。

{{% /alert %}}

## **Aspose.Slidesの評価**
Aspose.Slidesは簡単に評価用にダウンロードできます。評価パッケージは購入パッケージと同じです。評価版は、ライセンスを適用するための数行のコードを追加すると単にライセンス付きの状態になります。

## **評価版の制限**
Aspose.Slidesの評価版（ライセンスが指定されていない場合）は製品の全機能を提供しますが、ドキュメントを開くときと保存するときに評価用の透かしを挿入します。また、プレゼンテーションスライドからテキストを抽出する際には一枚のスライドに制限されます。

{{% alert color="primary" %}} 

Aspose.Slidesを評価版の制限なしでテストしたい場合は、**30日間の一時ライセンス**をリクエストできます。詳細については[一時ライセンスを取得する方法？](https://purchase.aspose.com/temporary-license)をご覧ください。

{{% /alert %}} 

## **ライセンスについて**
Node.js via .NET用のAspose.Slidesの評価版は、[ダウンロードページ](https://releases.aspose.com/slides/nodejs-net/)から簡単にダウンロードできます。評価版は、ライセンス版のAspose.Slidesと全く**同じ機能**を提供します。さらに、ライセンスを購入してライセンスを適用するための数行のコードを追加すると、評価版は単にライセンス状態になります。

ライセンスは、製品名、ライセンスを受けている開発者の数、サブスクリプションの期限日などの詳細を含むプレーンテキストのXMLファイルです。ファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に不要な改行を追加するだけでも無効になります。

評価版に関連する制限を回避するには、**Aspose.Slides**を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに一度ライセンスを設定するだけで済みます。

## 購入したライセンス

購入後、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}

ライセンスを設定する必要があります：
* アプリケーションドメインごとに一度だけ
* 他のAspose.Slidesクラスを使用する前に

{{% /alert %}}

{{% alert color="primary" %}}

[「価格情報」](https://purchase.aspose.com/pricing/slides/family)ページで価格情報を見つけることができます。

{{% /alert %}}

### **Node.js via .NETのAspose.Slidesでのライセンス設定**

ライセンスは以下の場所から適用できます：

* 明示的パス
* ストリーム
* メータライセンスとして – 新しいライセンス機構

{{% alert color="primary" %}}

**setLicense**メソッドを使用してコンポーネントにライセンスを付与します。

**setLicense**への複数回の呼び出しは無害ですが、リソース（プロセッサ）の無駄になります。

{{% /alert %}}

#### **ファイルを使用してライセンスを適用する**

このコードスニペットはライセンスファイルを設定するために使用されます：

**Node.js**

```javascript
// PowerPointファイル操作のためのAspose.Slidesモジュールをインポートします
const asposeSlides = require('aspose.slides.via.net');

// この関数はライセンスでAspose.Slidesライブラリを設定します
function setupAsposeSlidesLicense() {
	
    // Aspose.SlidesモジュールからLicenseクラスを初期化します
    var license = new asposeSlides.License();
    
    // ファイルからライセンスを適用します
    // "your_license_file.lic"を実際のライセンスファイルへのパスに置き換えてください
    license.setLicense("your_license_file.lic");
}

// Aspose.Slidesのライセンスを設定するために関数を実行します
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

setLicenseメソッドを呼び出すときは、ライセンス名をライセンスファイルと同じにする必要があります。たとえば、ライセンスファイル名を"Aspose.Slides.lic.xml"に変更できます。次に、コード内で新しいライセンス名（Aspose.Slides.lic.xml）をsetLicenseメソッドに渡す必要があります。

{{% /alert %}}