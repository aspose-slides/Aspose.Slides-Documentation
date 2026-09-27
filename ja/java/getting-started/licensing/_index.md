---
title: ライセンス
type: docs
weight: 90
url: /ja/java/licensing/
keywords:
- ライセンス
- 一時ライセンス
- ライセンスの設定
- ライセンスの使用
- ライセンスの検証
- ライセンスファイル
- 評価版
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java におけるライセンスの適用、管理、トラブルシューティングを行います。ステップバイステップのライセンスガイドで、フル機能への継続的なアクセスを確保してください。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版は製品版と同じ機能を提供しますが、保存する各プレゼンテーションの各スライドに評価用の透かしが追加され、API 経由でコードが読み取るテキストは切り詰められます。

この記事では Aspose.Slides のライセンス方法と、ライブラリを使用する前にライセンスを適用する手順を説明します。ライセンスは `License` クラスを使用してファイル、ストリーム、または埋め込みリソースから読み込むことができます。さらに、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" title="Note" %}}
**Aspose.Slides for Java** の評価版は[ダウンロードページ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入版と同一です。評価版はライセンスを適用するために数行のコードを追加すれば、ライセンス版となります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/pricing/slides/ja/java/)できます。さまざまなサブスクリプションタイプをご確認ください。ご不明な点があれば、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品（評価版でも可）を使用しているユーザーは、無料で無制限のテクニカルサポートを受けられます。
{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない評価版は製品の全機能を提供しますが、保存する各プレゼンテーションの各スライドに評価用の透かしテキストボックスが追加されます。
* API 経由でコードが読み取るテキスト（設定した直後のテキストを含む）は最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは完全に保存されます。

{{% alert color="info" title="Note" %}}
制限なしで Aspose.Slides をテストするには、**30 日間の一時ライセンス**を取得できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご参照ください。
{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードでライセンスを適用すればライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。余分な改行を加えるだけでも無効になります。
* Aspose.Slides for Java は通常、次の場所でライセンスを探します:
  * 明示的なパス
  * Aspose.Slides.jar があるフォルダー
* 評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば済みます。

{{% alert color="info" title="Note" %}}
[Metered Licensing](/slides/ja/java/metered-licensing/) をご覧になることをおすすめします。
{{% /alert %}} 

## **ライセンスの適用**

ライセンスは**ファイル**または**ストリーム**から読み込むことができます。

{{% alert color="info" title="Note" %}}
Aspose.Slides はライセンス操作用に[License](https://reference.aspose.com/slides/ja/java/com.aspose.slides/license/)クラスを提供しています。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

### **ファイル**

ライセンスを設定する最も簡単な方法は、ライセンスファイルを Aspose.Slides.jar またはアプリケーションの JAR があるフォルダーに配置することです。

この Java コードはライセンス ファイルの設定方法を示しています:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンス ファイルのパスを設定します
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
別のディレクトリにライセンス ファイルを配置した場合、[setLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドを呼び出す際、指定したパスの末尾にあるライセンス ファイル名は実際のファイル名と同じでなければなりません。

例として、ライセンス ファイル名を *Aspose.Slides.Java.lic.xml* に変更したとします。その場合、コード内で [setLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに*Aspose.Slides.Java.lic.xml* で終わるパスを渡す必要があります。
{{% /alert %}}

### **ストリーム**

ストリームからライセンスを読み込むことができます。この Java コードはストリームからライセンスを適用する方法を示しています:
``` java
// License クラスをインスタンス化します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを通してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java ブリッジ**

Java 経由で Aspose.Slides for PHP を使用している場合、PHP/Java ブリッジを通じてライセンスを設定できます。このブリッジにより、PHP の構文で Java クラスを使用できます。詳しくは[License in PHP](/slides/ja/php-java/licensing/)をご覧ください。

## **ライセンスの検証**

ライセンスが正しく設定されているか確認するには、検証を行います。この Java コードはライセンスの検証方法を示しています:
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

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/ja/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。このメソッドを多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。
{{% /alert %}}

## **FAQ**

### 完全にオフライン環境（インターネットに接続せず）でライセンスを適用できますか？

はい。ライセンスの検証はライセンス ファイルを使用してローカルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになるとどうなりますか？ ライブラリは動作しなくなりますか？

いいえ。ライセンスは永久ライセンスです。サブスクリプション終了日までにリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。