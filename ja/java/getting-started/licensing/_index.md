---
title: ライセンス
type: docs
weight: 90
url: /ja/java/licensing/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンスガイドで、フル機能への継続的なアクセスを確保してください。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版は製品版と同じ機能を提供しますが、プレゼンテーションを開くまたは保存する際に評価用透かしが追加され、テキスト抽出は 1 スライドに制限されます。

このドキュメントでは Aspose.Slides のライセンスの仕組みと、ライブラリを使用する前にライセンスを適用する方法を解説します。ライセンスは `License` クラスを使用してファイル、ストリーム、または埋め込みリソースからロードできます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" %}} 

**Aspose.Slides for Java** の評価版は、[download page](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) からダウンロードできます。評価版は製品版と同じ機能を提供し、購入版と同一のパッケージです。数行のコードを追加してライセンスを適用すれば、評価版はライセンス版に切り替わります。

**Aspose.Slides** の評価に満足したら、[purchase a license](https://purchase.aspose.com/buy) してください。さまざまなサブスクリプションタイプをご確認ください。質問がある場合は Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中の新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品（評価版を含む）を使用しているユーザーは、無制限の無料テクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限事項**

* ライセンスが指定されていない Aspose.Slides の評価版はフル機能を提供しますが、開く・保存時にドキュメント上部に評価用透かしが挿入されます。  
* プレゼンテーションからテキストを抽出できるスライドは 1 枚に制限されます。

{{% alert color="info" %}} 

制限なしで Aspose.Slides を試したい場合は、**30 日間の一時ライセンス**を取得できます。詳細は [How to get a Temporary License](https://purchase.aspose.com/temporary-license) ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス管理**

* 評価版はライセンスを購入し、数行のコードでライセンスを適用すると正式版になります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、許可された開発者数、サブスクリプションの有効期限などが記載されています。  
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。余分な改行を加えるだけでも無効になります。  
* Aspose.Slides for Java は通常、次の場所でライセンスを検索します。  
  * 明示的に指定したパス  
  * Aspose.Slides.jar が格納されているフォルダー  
* 評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに 1 回設定すれば完了です。

{{% alert color="info" %}} 

[Metered Licensing](/slides/ja/java/metered-licensing/) をご確認ください。

{{% /alert %}} 


## **ライセンスの適用方法**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="info" %}}

Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/ja/java/com.aspose.slides/License) クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降でのみ有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

ライセンスを設定する最も簡単な方法は、ライセンスファイルを Aspose.Slides.jar があるフォルダーまたはアプリケーションの JAR と同じフォルダーに配置することです。

この Java コードはライセンスファイルの設定方法を示しています。

``` java
// License クラスのインスタンスを生成
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンスファイルのパスを設定
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/License#setLicense-java.lang.String-) メソッドを呼び出す際に、指定した明示的パスの末尾にあるファイル名が実際のライセンスファイル名と一致している必要があります。

たとえば、ライセンスファイル名を *Aspose.Slides.Java.lic.xml* に変更した場合、コード内で [SetLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/License#setLicense-java.lang.String-) メソッドに *Aspose.Slides.Java.lic.xml* で終わるパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードすることも可能です。この Java コードはストリームからライセンスを適用する方法を示しています。

``` java
// License クラスのインスタンスを生成
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを介してライセンスを設定
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java ブリッジ**

PHP から Java 経由で Aspose.Slides を使用する場合、PHP/Java ブリッジを介してライセンスを設定できます。このブリッジにより、PHP の構文で Java クラスを利用できます。詳細は [License in PHP](/slides/ja/php-java/licensing/) を参照してください。

## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。この Java コードはライセンスの検証方法を示しています。

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/License#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。

{{% /alert %}}

## **FAQ**

### ライセンスを完全にオフライン環境（インターネット非接続）で適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日までにリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。