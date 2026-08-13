---
title: ライセンス
type: docs
weight: 90
url: /ja/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java のライセンスを適用、管理、トラブルシューティングします。ライセンスガイドでフル機能への継続的なアクセスを確保してください。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版は製品版と同じ機能を提供しますが、プレゼンテーションを開くまたは保存する際に評価用ウォーターマークが追加され、テキスト抽出は 1 スライドに制限されます。

本記事では Aspose.Slides のライセンスの仕組みと、ライブラリを使用する前にライセンスを適用する方法について説明します。`License` クラスを使用して、ライセンスはファイル、ストリーム、または埋め込みリソースからロードできます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" %}} 

**Aspose.Slides for Android via Java** の評価版は、[ダウンロードページ](https://releases.aspose.com/slides/ja/androidjava/) から入手できます。評価版は製品版と同じ機能を提供します。評価パッケージは購入したパッケージと同一です。評価版は、ライセンスを適用するための数行のコードを追加するだけでライセンス版になります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy) できます。さまざまなサブスクリプションタイプをご確認ください。質問がある場合は、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品（評価版でも可）を使用しているユーザーは、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない Aspose.Slides の評価版は製品の完全な機能を提供しますが、開くまたは保存する際にドキュメント上部に評価用ウォーターマークを挿入します。  
* プレゼンテーションスライドからテキストを抽出する場合、1 スライドに制限されます。

{{% alert color="info" %}} 

制限なしで Aspose.Slides をテストするには、**30 日間の一時ライセンス** を取得できます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードを追加してライセンスを適用するとライセンス版になります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの情報が含まれます。  
* ライセンスファイルはデジタル署名されているため、変更してはいけません。余分な改行を追加しただけでも無効になります。  
* Aspose.Slides for Android via Java は通常、以下の場所でライセンスを検索します:  
  * 明示的なパス  
  * Aspose.Slides.jar を含むフォルダー  
* 評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すればよいです。

## **ライセンスの適用**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="info" %}}

Aspose.Slides はライセンス操作のために [License](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/) クラスを提供します。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみ有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンスファイルを Aspose.Slides.jar を含むフォルダーまたはアプリケーションの jar に配置することです。

以下の Java コードはライセンスファイルの設定方法を示しています。

``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンスファイルのパスを設定します
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに配置した場合、[SetLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドを呼び出す際、指定した明示的パスの末尾にあるライセンスファイル名は実際のライセンスファイルと同じでなければなりません。

例えば、ライセンスファイル名を *Aspose.Slides.Android.via.Java.lic.xml* に変更できます。その場合、コード内で [SetLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに *Aspose.Slides.Android.via.Java.lic.xml* で終わるパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードできます。以下の Java コードはストリームからライセンスを適用する方法を示しています。

``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを使用してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **ライセンスの検証**

ライセンスが正しく設定されているか確認するには、検証できます。以下の Java コードはライセンスの検証方法を示しています。

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。このメソッドを複数のスレッドから同時に呼び出す必要がある場合、ロックなどの同期プリミティブを使用して問題を回避することを検討してください。 

{{% /alert %}}

## **FAQ**

### 完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？

はい。ライセンスの検証はライセンスファイルを使用してローカルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになるとどうなりますか？ ライブラリは動作しなくなりますか？

いいえ。ライセンスは永久利用可能です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。