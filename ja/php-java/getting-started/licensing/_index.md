---
title: ライセンス
description: "Aspose.Slides for PHP via Javaは、購入のための異なるプランを提供するか、ライセンスおよびサブスクリプションポリシーを使用した評価のための無料トライアルと30日間の一時ライセンスを提供します。"
type: docs
weight: 80
url: /php-java/licensing/
---

最良の評価結果を得るためには、実践的なアプローチが必要な場合があります。このため、Aspose.Slidesは異なる購入プランを提供し、さらに無料トライアルと30日間の一時ライセンスを評価用に提供しています。

{{% alert color="primary" %}}

評価、適切なライセンスの取得、製品の購入方法について案内する一般的なポリシーや慣行がいくつかあります。これらは["購入ポリシーとFAQ"](https://purchase.aspose.com/policies)セクションに記載されています。

{{% /alert %}}

## **Aspose.Slidesの評価**
Aspose.Slidesを簡単にダウンロードして評価できます。評価パッケージは、購入したパッケージと同じです。評価版は、ライセンスを適用するためのいくつかのコード行を追加した後にライセンスが適用されます。

## **評価版の制限**
Aspose.Slidesの評価版（ライセンスが指定されていない場合）は、製品の全機能を提供しますが、ドキュメントを開いたり保存したりするとドキュメントの上部に評価用の透かしが挿入されます。また、プレゼンテーションスライドからテキストを抽出する際に1枚のスライドに制限されます。

{{% alert color="primary" %}} 

評価版の制限なしでAspose.Slidesをテストしたい場合は、**30日間の一時ライセンス**をリクエストできます。詳細については[一時ライセンスを取得する方法？](https://purchase.aspose.com/temporary-license)を参照してください。

{{% /alert %}} 

## **ライセンスについて**
Aspose.Slides for PHP via Javaの評価版を[ダウンロードページ](https://packagist.org/packages/aspose/slides)から簡単にダウンロードできます。評価版は、ライセンス版と**まったく同じ機能**を提供します。さらに、ライセンスを購入し、ライセンスを適用するための数行のコードを追加することで、評価版は単にライセンスが適用されます。

ライセンスは、製品名、ライセンスを取得した開発者の数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。このファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に予期せぬ改行を追加すると、それが無効になります。

評価版の制限を回避するには、**Aspose.Slides**を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとにライセンスを1回設定するだけで済みます。

## 購入ライセンス

購入後は、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}

ライセンスを設定する必要があります：
* アプリケーションドメインごとに1回のみ
* 他のAspose.Slidesクラスを使用する前に

{{% /alert %}}

{{% alert color="primary" %}}

[“価格情報”](https://purchase.aspose.com/pricing/slides/family)ページで価格情報を確認できます。

{{% /alert %}}

### **Aspose.Slides for PHP via Javaでライセンスを設定する**

ライセンスは以下の場所から適用できます：

* 明示的なパス
* ストリーム
* メータライセンスとして – 新しいライセンスメカニズム

{{% alert color="primary" %}}

**setLicense**メソッドを使用してコンポーネントにライセンスを設定します。

**setLicense**への複数回の呼び出しは害はありませんが、リソース（プロセッサ）の浪費になります。

{{% /alert %}}

#### **ファイルを使用してライセンスを適用する**

このコードスニペットはライセンスファイルを設定するために使用されます：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

setLicenseメソッドを呼び出すとき、ライセンス名はライセンスファイルの名前と同じである必要があります。例えば、ライセンスファイル名を"Aspose.Slides.lic.xml"に変更できます。その後、コード内で新しいライセンス名（Aspose.Slides.lic.xml）をsetLicenseメソッドに渡す必要があります。

#### **ストリームからライセンスを適用する**

このコードスニペットはストリームからライセンスを適用するために使用されます：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### メータライセンスを適用する

Aspose.Slidesは、開発者がメータキーを適用できるようにします。これは新しいライセンスメカニズムです。

新しいライセンスメカニズムは、既存のライセンス方式とともに使用されます。API機能の使用に基づいて請求されたい顧客は、メータライセンスを使用できます。

この種のライセンスを取得するために必要な手順をすべて完了した後、ライセンスファイルではなくキーを受け取ります。このメータキーは、この目的のために特別に導入された**Metered**クラスを使用して適用できます。

以下のコード例は、メータの公開キーと秘密キーを設定する方法を示しています：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# CAD Meteredクラスのインスタンスを作成
$metered = new Metered();

# set_metered_keyプロパティにアクセスし、公開キーと秘密キーをパラメータとして渡す
$metered->setMeteredKey("*****", "*****");

# APIを呼び出す前のメータデータ量を取得
$amountbefore = Metered::getConsumptionQuantity();
# 情報を表示
echo "<script>console.log('消費量（前）: " . java_values($amountbefore) . "' );</script>";

# ディスクからドキュメントを読み込みます。
$pres = new Presentation();
# ドキュメントのページ数を取得
echo "<script>console.log('消費量（後）: " . java_values($pres->getSlides()->size()) . "' );</script>";
# PDFとして保存
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# APIを呼び出した後のメータデータ量を取得
$amountafter = Metered::getConsumptionQuantity();
# 情報を表示
echo "<script>console.log('消費量（後）: " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

メータライセンスを正しく使用するには安定したインターネット接続が必要です。メータメカニズムは、正確な計算のために当社のサービスとの常時の相互作用を必要とします。詳細については、[“メータライセンスFAQ”](https://purchase.aspose.com/faqs/licensing/metered)セクションを参照してください。

{{% /alert %}}