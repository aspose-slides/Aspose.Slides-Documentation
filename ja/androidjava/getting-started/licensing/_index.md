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
- 評価バージョン
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java におけるライセンスの適用、管理、トラブルシューティングを行います。ライセンスガイドでフル機能への継続的なアクセスを保証します。"
---

## **Aspose.Slides を評価する**

{{% alert color="primary" %}} 

**Aspose.Slides for Android via Java** の評価版は、[ダウンロードページ](https://releases.aspose.com/slides/androidjava/)から取得できます。評価版は製品の正規版と同じ機能を提供します。評価パッケージは購入版と同一です。コードを数行追加してライセンスを適用すれば、評価版は正規版になります。

評価が完了したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。さまざまなサブスクリプションタイプをご確認ください。質問がある場合は、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中の新しいバージョンや修正への無料アップグレードが 1 年間付与されます。正規版または評価版を使用しているユーザーは、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slides の評価版（ライセンス未指定）はフル機能を提供しますが、開く・保存時に文書上部に評価用透かしが挿入されます。  
* プレゼンテーション スライドからテキストを抽出できるのは 1 スライドに制限されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides を試したい場合は、**30 日間の一時ライセンス**を取得できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)をご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードを追加して適用すると正規版になります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの情報が含まれます。  
* ライセンス ファイルはデジタル署名されているため、ファイルの内容を変更してはいけません。余分な改行を加えるだけでも無効になります。  
* Aspose.Slides for Android via Java は通常、次の場所でライセンスを検索します。  
  * 明示的に指定したパス  
  * Aspose.Slides.jar が格納されているフォルダー  
* 評価版の制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば済みます。

{{% alert color="primary" %}} 

[従量課金ライセンス](/slides/ja/androidjava/metered-licensing/)をご参照ください。

{{% /alert %}} 

## **ライセンスの適用**

ライセンスは **ファイル** または **ストリーム** から読み込むことができます。

{{% alert color="primary" %}}

Aspose.Slides では、ライセンス操作用に [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) クラスが提供されています。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降でのみ有効です。以前のバージョンは別のライセンス システムを使用しており、これらのライセンスを認識しません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンス ファイルを Aspose.Slides.jar があるフォルダーまたはアプリケーションの jar に配置することです。

この Java コードはライセンス ファイルの設定方法を示しています:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンス ファイルのパスを設定します
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

ライセンス ファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに指定する明示的パスの末尾のファイル名は、実際のライセンス ファイル名と同一である必要があります。

たとえば、ライセンス ファイル名を *Aspose.Slides.Android.via.Java.lic.xml* に変更した場合、コード内で [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに *Aspose.Slides.Android.via.Java.lic.xml* で終わるパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスを読み込むことも可能です。この Java コードはストリームからライセンスを適用する方法を示しています:
``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを介してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。この Java コードはライセンスの検証方法を示しています:
```java
License license = new License();
license.setLicense("Aspise.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

**オフライン環境（インターネット未接続）でもライセンスを適用できますか？**

はい。ライセンスの検証はローカルのライセンス ファイルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになるとどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久ライセンスです。サブスクリプション終了日までにリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。