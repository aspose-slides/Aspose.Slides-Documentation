---
title: ライセンス
type: docs
weight: 90
url: /ja/java/licensing/
---

## **Aspose.Slidesの評価**

{{% alert color="primary" %}} 

**Aspose.Slides for Java**の評価版は[ダウンロードページ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入したパッケージと同じです。評価版は、いくつかのコード行を追加することでライセンスされます（ライセンスを適用するために）。

**Aspose.Slides**の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。異なるサブスクリプションタイプを確認することをお勧めします。質問がある場合は、Asposeの営業チームにお問い合わせください。

すべてのAsposeライセンスには、サブスクリプション期間内にリリースされた新しいバージョンまたは修正への無料アップグレードの1年のサブスクリプションが付いてきます。ライセンスされた製品（または評価版）を持っているユーザーは、無料で無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slidesの評価版（ライセンスが指定されていない）は、完全な製品機能を提供しますが、ドキュメントを開くときや保存するときに評価用の透かしを挿入します。
* プレゼンテーションスライドからテキストを抽出する際には、スライド1枚に制限されています。

{{% alert color="primary" %}} 

制限のないAspose.Slidesを試すには、**30日間の一時ライセンス**をリクエストできます。詳細については、[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページを参照してください。

{{% /alert %}}

## **Aspose.Slidesのライセンス管理**

* 評価版はライセンスを購入し、それに数行のコードを追加することでライセンスされます（ライセンスを適用するために）。
* ライセンスは、製品名、ライセンスされた開発者の数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。 
* ライセンスファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に余分な改行を加えるだけでも無効になります。
* Aspose.Slides for Javaは通常、次の場所でライセンスを探します。
  * 明示的なパス
  * Aspose.Slides.jarを含むフォルダ
* 評価版に関連する制限を回避するには、**Aspose.Slides**を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとにライセンスを1回設定するだけで済みます。

{{% alert color="primary" %}} 

[Metered Licensing](/slides/ja/java/metered-licensing/)を参照することをお勧めします。

{{% /alert %}} 


## **ライセンスの適用**

ライセンスは**ファイル**または**ストリーム**から読み込むことができます。

{{% alert color="primary" %}}

Aspose.Slidesはライセンス操作のための[License](https://reference.aspose.com/slides/java/com.aspose.slides/License)クラスを提供しています。

{{% /alert %}} 

### **ファイル**

ライセンスを設定する最も簡単な方法は、ライセンスファイルをAspose.Slides.jarまたはアプリケーションのjarを含むフォルダーに配置することです。

このJavaコードは、ライセンスファイルの設定方法を示しています:

``` java
// Licenseクラスをインスタンス化
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンスファイルのパスを設定
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに配置した場合、[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-)メソッドを呼び出すとき、指定された明示的な末尾のライセンスファイル名は、ライセンスファイル名と同じでなければなりません。

例えば、ライセンスファイル名を*Aspose.Slides.Java.lic.xml*に変更することができます。すると、コード内で、（*Aspose.Slides.Java.lic.xml*で終了する）ファイルへのパスを[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-)メソッドに渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスを読み込むことができます。このJavaコードは、ストリームからライセンスを適用する方法を示しています:

``` java
// Licenseクラスをインスタンス化
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを通じてライセンスを設定
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

PHP経由でJavaを使用してAspose.Slidesを使用する場合、PHP/Javaブリッジを通じてライセンスを設定できます。このブリッジにより、PHP構文内でJavaクラスを使用することができます。詳細については、[PHPのライセンス](/slides/ja/php-java/licensing/)を参照してください。

## **ライセンスの検証**

ライセンスが正しく設定されているかどうかを確認するために、ライセンスを検証できます。このJavaコードは、ライセンスを検証する方法を示しています:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("ライセンスが正常です！");
}
```

## **スレッドの安全性**

{{% alert title="注意" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-)メソッドはスレッドセーフではありません。このメソッドが多くのスレッドから同時に呼び出される場合、問題を避けるために同期プリミティブ（ロックなど）を使用することを検討してください。 

{{% /alert %}}