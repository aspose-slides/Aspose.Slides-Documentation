---
title: ライセンス
type: docs
weight: 80
url: /ja/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java におけるライセンスの適用、管理、トラブルシューティングを行います。ステップバイステップのライセンスガイドで、フル機能への継続的なアクセスを確保してください。"
---

場合によっては、最良の評価結果を得るために実際に手を動かすアプローチが必要になることがあります。そのため、Aspose.Slides はさまざまな購入プランを提供し、無料トライアルと30日間の一時ライセンスも評価用に提供しています。

{{% alert color="primary" %}}
当社の製品を評価し、適切にライセンスを取得し、購入する方法を案内する一般的なポリシーや慣行が多数存在することに留意してください。これらは["Purchase Policies and FAQ"](https://purchase.aspose.com/policies)セクションで確認できます。
{{% /alert %}}

## **Aspose.Slides を評価する**
簡単に Aspose.Slides をダウンロードして評価できます。評価用パッケージは購入パッケージと同一です。評価バージョンは、ライセンスを適用するコードを数行追加するだけで正式にライセンスされます。

## **評価版の制限**
Aspose.Slides の評価版（ライセンスが指定されていない場合）は、製品の全機能を提供しますが、開くおよび保存時にドキュメントの上部に評価用ウォーターマークを挿入します。また、プレゼンテーションスライドからテキストを抽出する際は1枚のスライドに制限されます。

{{% alert color="primary" %}} 
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 Day Temporary License** をリクエストできます。詳細は[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)をご参照ください。
{{% /alert %}} 

## **ライセンスについて**
PHP 用の Aspose.Slides（Java 経由）の評価版は、[download page](https://packagist.org/packages/aspose/slides)から簡単にダウンロードできます。評価版はライセンス版と**全く同じ機能**を提供します。さらに、ライセンスを購入し、ライセンスを適用するコードを数行追加するだけで評価版は正式にライセンスされます。

ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。このファイルはデジタル署名されているため、変更しないでください。ファイルの内容に余計な改行を追加するだけでも無効になります。

評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば済みます。

{{% alert color="primary" %}}
[Metered Licensing](https://docs.aspose.com/slides/php-java/metered-licensing/)をご覧になるとよいでしょう。
{{% /alert %}}

## **購入ライセンス**
購入後は、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="primary" %}}
ライセンスを設定する必要があります:
* アプリケーションドメインごとに一度だけ
* ほかの Aspose.Slides クラスを使用する前に
{{% /alert %}}

{{% alert color="primary" %}}
価格情報は[“Pricing Information”](https://purchase.aspose.com/pricing/slides/family)ページで確認できます。
{{% /alert %}}

### **PHP via Java の Aspose.Slides でライセンスを設定する**
ライセンスは次の場所から適用できます:
* 明示的なパス
* ストリーム
* Metered License として – 新しいライセンス方式

{{% alert color="primary" %}}
コンポーネントにライセンスを設定するには **setLicense** メソッドを使用します。

**setLicense** を複数回呼び出しても問題はありませんが、リソース（プロセッサ）の無駄になります。
{{% /alert %}}

{{% alert color="warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

#### **ファイルを使用してライセンスを適用する**
以下のコードスニペットはライセンスファイルを設定するためのものです:

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


setLicense メソッドを呼び出す際は、ライセンス名をライセンスファイル名と同じにする必要があります。例えば、ライセンスファイル名を "Aspose.Slides.lic.xml" に変更できます。その場合、コード内で setLicense メソッドに新しいライセンス名 (Aspose.Slides.lic.xml) を渡す必要があります。

#### **ストリームからライセンスを適用する**
以下のコードスニペットはストリームからライセンスを適用するためのものです:
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```


## **よくある質問**

**完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？**
はい。ライセンスの検証はライセンスファイルを使用してローカルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ ライブラリは動作しなくなりますか？**
いいえ。ライセンスは永続的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。