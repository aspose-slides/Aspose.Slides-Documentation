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
description: "Aspose.Slides for PHP via Java におけるライセンスの適用、管理、トラブルシューティング方法をご案内します。ステップバイステップのライセンスガイドに従い、フル機能への継続的なアクセスを確保してください。"
---
## **はじめに**

最良の評価結果を得るために、実際に手を動かすアプローチが必要になることがあります。そのため、Aspose.Slides はさまざまな購入プランを提供するとともに、無料トライアルと30日間の一時ライセンスを評価用に提供しています。

{{% alert color="info" title="Note" %}}
一般的なポリシーや実務が多数あり、製品の評価、適切なライセンス取得、購入方法を案内しています。これらは[購入ポリシーとFAQ](https://purchase.aspose.com/policies)セクションで確認できます。
{{% /alert %}}

## **Aspose.Slides の評価**
Aspose.Slides は簡単にダウンロードして評価できます。評価用パッケージは購入版と同一です。評価版は、ライセンスを適用する数行のコードを追加するだけで、ライセンス版に切り替わります。

## **評価版の制限**
ライセンスが指定されていない Aspose.Slides の評価版は、製品の全機能を提供しますが、次の2つの制限があります。

* 各プレゼンテーションを保存する際、すべてのスライドの中央に評価用透かしテキストボックスが追加されます。
* コードがプレゼンテーションから読み取るテキストは、最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは完全に保存されます。

{{% alert color="info" title="Note" %}}
評価版の制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を取得できます。詳細は[一時ライセンスの取得方法?](https://purchase.aspose.com/temporary-license)をご参照ください。
{{% /alert %}} 

## **ライセンスについて**
Aspose.Slides for PHP via Java の評価版は、[ダウンロードページ](https://packagist.org/packages/aspose/slides)から簡単に取得できます。評価版は、ライセンス版と **全く同じ機能** を提供します。さらに、ライセンスを購入し、数行のコードでライセンスを適用すれば、評価版は自動的にライセンス版となります。

ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。このファイルはデジタル署名されているため、変更してはいけません。余計な改行を追加しただけでも無効になります。

評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定してください。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば十分です。

{{% alert color="info" title="Note" %}}
[従量制ライセンス](/slides/ja/php-java/metered-licensing/) をご覧になることをお勧めします。
{{% /alert %}} 

## **購入済みライセンス**

購入後は、ライセンスファイルまたはストリームを適用する必要があります。

{{% alert color="info" title="Note" %}}
ライセンスは次のとおり設定してください：
* アプリケーションドメインごとに一度だけ
* 他の Aspose.Slides クラスを使用する前に
{{% /alert %}}

{{% alert color="info" title="Note" %}}
価格情報は[価格情報](https://purchase.aspose.com/pricing/slides/ja/family)ページで確認できます。
{{% /alert %}}

### **Aspose.Slides for PHP via Java でのライセンス設定**

ライセンスは次の場所から適用できます。

* 明示的なパス
* ストリーム
* 従量制ライセンスとして – 新しいライセンス方式

{{% alert color="info" title="Note" %}}
**setLicense** メソッドを使用してコンポーネントにライセンスを設定します。

**setLicense** を複数回呼び出しても問題はありませんが、リソース（プロセッサ）の無駄になります。
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides でのみ有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

#### **ファイルでライセンスを適用する**

以下のコードスニペットはライセンスファイルを設定するためのものです。

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

このサンプルはスクリプトと同じディレクトリにあるライセンスファイルを想定し、絶対パスを渡します。Aspose.Slides は Tomcat 上で実行されるため、スクリプトのフォルダに対する相対パスは解決されません。setLicense メソッドを呼び出す際、ライセンス名はライセンスファイル名と同一である必要があります。例えば、ライセンスファイル名を「Aspose.Slides.lic.xml」に変更できます。その場合、コード内で setLicense メソッドに新しいライセンス名 (Aspose.Slides.lic.xml) を渡す必要があります。

#### **ストリームからライセンスを適用する**

以下のコードスニペットはストリームからライセンスを適用するためのものです。

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### 完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになるとどうなりますか？ ライブラリは動作を停止しますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日までにリリースされたバージョンは引き続き使用できますが、更新なしで新しいリリースを使用することはできません。