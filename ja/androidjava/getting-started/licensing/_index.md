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
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版はライセンス版と同じ機能を提供しますが、保存する各プレゼンテーションのすべてのスライドに評価用の透かしを追加し、プレゼンテーションからコードが読み取るテキストを切り詰めます。

本記事では Aspose.Slides のライセンスの仕組みと、ライブラリを使用する前にライセンスを適用する方法について説明します。ライセンスは [License](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/) クラスを使用してファイル、ストリーム、または埋め込みリソースからロードできます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java の評価版は、[ダウンロードページ](https://releases.aspose.com/slides/ja/androidjava/)から取得できます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入パッケージと同一です。評価版はライセンスを適用する数行のコードを追加するだけでライセンス版になります（ライセンスの適用）。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入する](https://purchase.aspose.com/pricing/slides/ja/android-java/)ことができます。さまざまなサブスクリプションタイプをご確認ください。質問がある場合は Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされた新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品（評価版を含む）を使用するユーザーは、無料かつ無制限のテクニカルサポートを受けられます。
{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない評価版は、製品のすべての機能を提供しますが、保存する各プレゼンテーションのすべてのスライドに評価用透かしテキストボックスを追加します。
* コードがプレゼンテーションから読み取るテキストは最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは全文保存されます。

{{% alert color="info" title="Note" %}}
制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を申請できます。詳細は [一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license) ページをご覧ください。
{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードでライセンスを適用するとライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの詳細が含まれます。 
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。余分な改行を加えるだけでも無効になります。
* Aspose.Slides for Android via Java は通常、次の場所でライセンスを検索します。
  * 明示的なパス
  * Aspose.Slides.jar を含むフォルダー
* 評価版に伴う制限を回避するには、**Aspose.Slides** を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスあたり 1 回だけ設定すれば十分です。

## **ライセンスの適用**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="info" title="Note" %}}
Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/) クラスを提供しています。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンス体系を使用しており、これらのライセンスを認識しません。
{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンスファイルを Aspose.Slides.jar またはアプリケーションの JAR があるフォルダーに置くことです。

{{% alert color="info" title="Note" %}}
Android ではライブラリとアプリが APK にパッケージ化されるため、ライブラリの JAR ファイルがあるフォルダーは存在せず、*Aspose.Slides.Android.via.Java.lic* のような相対パスはアプリ内のファイルを指しません。ライセンスファイルをアプリの assets に追加し、[アセットからのストリーム](#stream-from-app-assets) に示すようにストリームからロードしてください。
{{% /alert %}}

この Java コードはライセンスファイルの設定方法を示しています:

``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ライセンスファイルのパスを設定します
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
ライセンスファイルを別のディレクトリに配置した場合、[setLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドを呼び出す際、指定パスの末尾にあるファイル名はライセンスファイル名と同一である必要があります。

たとえば、ライセンスファイル名を *Aspose.Slides.Android.via.Java.lic.xml* に変更した場合、コードではファイルへのパス（*Aspose.Slides.Android.via.Java.lic.xml* で終わる）を [setLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) メソッドに渡す必要があります。
{{% /alert %}}

### **ストリーム**

ライセンスはストリームからロードできます。この Java コードはストリームからライセンスを適用する方法を示しています:

``` java
// License クラスのインスタンスを作成します
com.aspose.slides.License license = new com.aspose.slides.License();

// ストリームを使用してライセンスを設定します
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **アプリのアセットからのストリーム**

Android アプリでは、ライセンスファイルをアプリモジュールの *assets* フォルダー（*app/src/main/assets*）に置き、APK にパッケージ化します。[getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) メソッドでファイルを開き、ストリームを [setLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドに渡します。コードは `Activity` 内で実行され、たとえば `onCreate` メソッドで Aspose.Slides を使用する前に実行されます:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

[open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) メソッドに渡すファイル名は *assets* フォルダーに対して相対パスです。ファイルが存在しない場合、コードはエラーをログに出し、Aspose.Slides は評価モードのままです。ライセンスが適用されたか確認するには、[ライセンスの検証](#validating-a-license) を参照してください。

## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。この Java コードはライセンスの検証方法を示しています:

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

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) メソッドはスレッドセーフではありません。同時に多数のスレッドから呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。
{{% /alert %}}

## **よくある質問**

### ライセンスを完全にオフライン環境（インターネットアクセスなし）で適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れとなった後はどうなりますか？ライブラリは動作を停止しますか？

いいえ。ライセンスは永続的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できなくなります。