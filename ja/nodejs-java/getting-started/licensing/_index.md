---
title: ライセンス
type: docs
weight: 80
url: /ja/nodejs-java/licensing/
keywords:
- ライセンス
- 一時ライセンス
- ライセンス設定
- ライセンス使用
- ライセンス検証
- ライセンスファイル
- 評価版
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js のライセンスを適用、管理、トラブルシューティングします。段階的なライセンスガイドで、フル機能への途切れないアクセスを確保してください。"
---
## **はじめに**

時には、最適な評価結果を得るために実際に手を動かすアプローチが必要になることがあります。そのため、Aspose.Slides はさまざまな購入プランを提供するとともに、無料トライアルと 30 日間の一時ライセンスを評価用に提供しています。

{{% alert color="info" title="Note" %}}
製品の評価方法、適切なライセンス取得、購入に関する一般的なポリシーや慣行が多数存在します。これらは[「購入ポリシーと FAQ」](https://purchase.aspose.com/policies) セクションで確認できます。
{{% /alert %}}

## **Aspose.Slides の評価**
Aspose.Slides を簡単にダウンロードして評価できます。評価用パッケージは購入版と同一です。評価版は、ライセンスを適用するコードを数行追加するだけで、正式にライセンスが適用された状態になります。

## **評価版の制限**
Aspose.Slides の評価版（ライセンスが指定されていない）は、上記の制限を除き製品の全機能を提供します。制限は次の二点です。

* 保存する各プレゼンテーションのすべてのスライドに、評価用の透かしテキストボックスが追加されます。
* プレゼンテーションからコードで読み取るテキストが5文字を超える場合、最初の5文字に切り取られ、続けて `... text has been truncated due to evaluation version limitation.` が付加されます。5文字以下のテキストはそのまま返され、コードで書き込むテキストは完全に保存されます。

{{% alert color="info" title="Note" %}}
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 Day Temporary License** をリクエストできます。詳細は[一時ライセンスの取得方法は？](https://purchase.aspose.com/temporary-license)をご参照ください。
{{% /alert %}}

## **ライセンスについて**
Node.js via Java 用の Aspose.Slides 評価版は、[ダウンロード ページ](https://releases.aspose.com/slides/nodejs-java/) から簡単に取得できます。評価版はライセンス版と同じ機能を持ちますが、上記の制限があります。さらに、ライセンスを購入し、数行のコードでライセンスを適用すれば評価版は正式にライセンスが適用された状態になります。

ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。ファイルはデジタル署名されているため、変更しないでください。ファイル内容に余計な改行が入るだけでも無効になります。

評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとにライセンスは一度だけ設定すれば済みます。

{{% alert color="info" title="Note" %}}
[従量課金ライセンス](/slides/ja/nodejs-java/metered-licensing/) もご覧ください。
{{% /alert %}}

## **購入ライセンス**
購入後は、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="info" title="Note" %}}
ライセンスの設定は次の点に注意してください。
* プロセスごとに一度だけ
* 他の Aspose.Slides クラスを使用する前に設定すること
{{% /alert %}}

{{% alert color="info" title="Note" %}}
価格情報は[“Pricing Information”](https://purchase.aspose.com/pricing/slides/family)ページで確認できます。
{{% /alert %}}

### **Node.js via Java 用 Aspose.Slides でのライセンス設定**

ライセンスは以下の場所から適用できます。

* 明示的なパス
* ストリーム
* Metered License として – 新しいライセンス方式

{{% alert color="info" title="Note" %}}
コンポーネントにライセンスを設定するには **setLicense** メソッドを使用します。

**setLicense** を複数回呼び出しても問題はありませんが、リソース（プロセッサ）の無駄になります。
{{% /alert %}}

#### **ファイルを使用したライセンスの適用**

このコードスニペットはライセンスファイルを設定するために使用します。

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides は Node.js を継続させる Java 仮想マシン上で実行されるため、プロセスを明示的に終了してください。
process.exit(0);
```

setLicense メソッドを呼び出す際、ライセンス名はライセンスファイル名と同じである必要があります。たとえばライセンスファイル名を "Aspose.Slides.lic.xml" に変更し、コード内で新しいライセンス名 (Aspose.Slides.lic.xml) を setLicense メソッドに渡します。ファイルが存在しない、または有効なライセンスを含まない場合、[setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) は例外をスローし、スクリプトはエラーで終了します。

#### **ストリームからのライセンス適用**

ストリームからライセンスを適用するには、[License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) オブジェクトと読み取り可能なストリームを静的な [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) メソッドに渡します。ストリームは非同期で読み取られ、ストリームに有効なライセンスが含まれていない場合はコールバックにエラーが渡されます。

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides は Node.js を継続させる Java 仮想マシン上で実行されるため、プロセスを明示的に終了してください。
    process.exit(0);
});
```

ストリーム全体が読み取られた直後、コールバックが実行される前にライセンスが適用されるため、コールバック内で他の Aspose.Slides の処理を開始してください。

両サンプルは終了時に `process.exit(0)` を呼び出します。これは Aspose.Slides を実行する Java 仮想マシンが Node.js を停止させないためです。実際のアプリケーションではプロセスを終了せず、Aspose.Slides のコードを続行してください。

## **FAQ**

### 完全にオフラインの環境（インターネットアクセスなし）でライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが終了した後はどうなりますか？ ライブラリは動作を停止しますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。