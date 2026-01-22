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
description: "Aspose.Slides for Android via Java のライセンスを適用、管理、トラブルシューティングします。ライセンス ガイドでフル機能への継続的なアクセスを確保してください。"
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

Android via Java 用 **Aspose.Slides** の評価版を、[ダウンロードページ](https://releases.aspose.com/slides/androidjava/) からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入したパッケージと同一です。評価版は、ライセンスを適用するために数行のコードを追加すると、ライセンス版になります。

Aspose.Slides の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy) してください。さまざまなサブスクリプションタイプをご確認いただくことをお勧めします。質問がある場合は、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが1 年間付属します。ライセンス製品（評価版でも可）をご利用のユーザーは、無料で無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slides の評価版（ライセンスが指定されていない場合）はフル機能を提供しますが、開くまたは保存する際にドキュメント上部に評価用の透かしが挿入されます。 
* プレゼンテーションスライドからテキストを抽出する場合、1 スライドに制限されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストするには、**30 日間の一時ライセンス** を取得できます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) のページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードを追加してライセンスを適用すると、ライセンス版になります。 
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。 
* ライセンスファイルはデジタル署名されているため、変更してはいけません。余分な改行を加えるだけでも無効になります。 
* Android via Java 用 Aspose.Slides は通常、以下の場所でライセンスを検索します:
  * 明示的なパス
  * Aspose.Slides.jar を含むフォルダー
* 評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに一度だけ設定すれば済みます。

## **ライセンスの適用**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="primary" %}}

Aspose.Slides はライセンス操作用の [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) クラスを提供します。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンスファイルを Aspose.Slides.jar があるフォルダーまたはアプリケーションの JAR 内に配置することです。

以下の Java コードはライセンスファイルの設定方法を示しています:
``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンスファイルのパスを設定します
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドを呼び出す際、指定した明示的パスの最後のファイル名は実際のライセンスファイル名と一致している必要があります。

例えば、ライセンスファイル名を *Aspose.Slides.Android.via.Java.lic.xml* に変更できます。その場合、コードでは [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに ( *Aspose.Slides.Android.via.Java.lic.xml* で終わる) パスを渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードできます。以下の Java コードはストリームからライセンスを適用する方法を示しています:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを介してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。以下の Java コードはライセンスの検証方法を示しています:
```java
License license = new License();
license.setLicense("Aspense.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。このメソッドを多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

**完全にオフラインの環境（インターネットアクセスなし）でライセンスを適用できますか？**

はい。ライセンスの検証はローカルでライセンスファイルを使用して行われるため、インターネット接続は必要ありません。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久的で、サブスクリプション終了日前にリリースされたバージョンは引き続き使用できます。ただし、更新しない限り新しいリリースは利用できません。