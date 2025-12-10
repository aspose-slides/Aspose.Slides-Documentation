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
description: "Aspose.Slides for Java のライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンス ガイドで、フル機能への継続的なアクセスを確保してください。"
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

**Aspose.Slides for Java** の評価版は、[download page](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入パッケージと同一です。評価版は、ライセンスを適用するために数行のコードを追加すればすぐにライセンス版になります。

**Aspose.Slides** の評価に満足したら、[purchase a license](https://purchase.aspose.com/buy) からライセンスを購入できます。さまざまなサブスクリプションタイプをご確認ください。ご質問がある場合は Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中の新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品（評価版を含む）を使用しているユーザーは、無制限の無料テクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない Aspose.Slides の評価版は完全な機能を提供しますが、開く・保存する際にドキュメント上部に評価用透かしが挿入されます。  
* プレゼンテーションのスライドからテキストを抽出する場合、1 枚のスライドに限定されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス** を取得できます。詳細は [How to get a Temporary License](https://purchase.aspose.com/temporary-license) ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス管理**

* 評価版は、ライセンスを購入し、数行のコードでライセンスを適用すればライセンス版になります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション期限などが記載されています。  
* ライセンス ファイルはデジタル署名されているため、ファイルを変更してはなりません。余計な改行を加えるだけでも無効になります。  
* Aspose.Slides for Java は通常、次の場所でライセンスを検索します。  
  * 明示的に指定したパス  
  * Aspose.Slides.jar があるフォルダー  
* 評価版の制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば完了です。

{{% alert color="primary" %}} 

[Metered Licensing](/slides/ja/java/metered-licensing/) をご覧ください。

{{% /alert %}} 


## **ライセンスの適用方法**

ライセンスは **ファイル** または **ストリーム** から読み込めます。

{{% alert color="primary" %}}

Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンス方式を使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンス ファイルを Aspose.Slides.jar があるフォルダーまたはアプリケーションの JAR と同じフォルダーに配置することです。

次の Java コードはライセンス ファイルを設定する例です:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンス ファイルのパスを設定します
license.setLicense("Aspose.Slides.Java.lic");
```


{{% alert color="warning" %}} 

ライセンス ファイルを別のディレクトリーに置く場合、[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) メソッドを呼び出す際に、指定した明示パスの末尾にあるライセンス ファイル名が実際のファイル名と一致している必要があります。

たとえば、ライセンス ファイル名を *Aspose.Slides.Java.lic.xml* に変更した場合、コード内で [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) メソッドに *Aspose.Slides.Java.lic.xml* で終了するパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスを読み込むこともできます。次の Java コードはストリームからライセンスを適用する例です:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを使用してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```


### **PHP/Java ブリッジ**

Java 経由で Aspose.Slides for PHP を使用する場合、PHP/Java ブリッジを通じてライセンスを設定できます。このブリッジを使用すると PHP 構文で Java クラスを利用できます。詳細は [License in PHP](/slides/ja/php-java/licensing/) を参照してください。

## **ライセンスの検証**

ライセンスが正しく設定されたかどうかは、検証することで確認できます。次の Java コードはライセンスを検証する例です:
```java
License license = new License();
license.setLicense("Asplice.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。複数スレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

**完全にオフラインの環境（インターネット接続なし）でライセンスを適用できますか？**

はい。ライセンスの検証はローカルのライセンス ファイルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久的に有効です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。