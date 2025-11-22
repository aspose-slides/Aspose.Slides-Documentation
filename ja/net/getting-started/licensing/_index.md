---
title: ライセンス
type: docs
weight: 80
url: /ja/net/licensing/
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

**Aspose.Slides for NET** の評価版は、[its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入したパッケージと同一です。評価版は、数行のコードを追加してライセンスを適用すれば、ライセンス版になります。

**Aspose.Slides** の評価に満足したら、[purchase a license](https://purchase.aspose.com/buy)できます。さまざまなサブスクリプションタイプをご確認ください。質問がある場合は、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが 1 年間付帯します。ライセンス製品または評価版を使用しているユーザーは、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**Evaluation version limitations**

* Aspose.Slides の評価版（ライセンスが指定されていない）はフル機能を提供しますが、開くおよび保存する際に文書上部に評価用透かしが挿入されます。 
* プレゼンテーション スライドからテキストを抽出する場合、1 スライドに限定されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストするには、**30-Day Temporary License**を取得できます。詳細は[How to get a Temporary License](https://purchase.aspose.com/temporary-license)のページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版は、ライセンスを購入し、数行のコードでライセンスを適用すると、ライセンス版になります。 
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの情報が含まれます。 
* ライセンスファイルはデジタル署名されているため、変更してはいけません。余分な改行を加えるだけでも無効になります。 
* Aspose.Slides for .NET は通常、以下の場所でライセンスを検索します:
  * 明示的なパス
  * コンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれる）
  * コンポーネントの DLL を呼び出したアセンブリが格納されているフォルダー（Aspose.Slides に含まれる）
  * エントリ アセンブリ（.exe）が格納されているフォルダー
  * コンポーネントの DLL を呼び出したアセンブリに埋め込まれたリソース（Aspose.Slides に含まれる）
* 評価版の制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに一度だけ設定すれば完了です。

{{% alert color="primary" %}} 

[Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/)をご覧ください。

{{% /alert %}} 


## **ライセンスの適用**
ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。 

{{% alert color="primary" %}}

Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/net/aspose.slides/license) クラスを提供します。

{{% /alert %}} 

{{% alert color="warning" %}} 

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**
最も簡単なライセンス設定方法は、ライセンスファイルをコンポーネントの DLL があるフォルダー（Aspose.Slides に含まれる）に置き、パスなしでファイル名だけを指定することです。

この C# コードは、ライセンス ファイルの設定方法を示しています:
``` csharp
// License クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイルのパスを設定します
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

ライセンス ファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドを呼び出す際に、指定した明示的パスの最後にあるファイル名が実際のライセンス ファイル名と一致している必要があります。

例として、ライセンス ファイル名を *Aspose.Slides.lic.xml* に変更できます。その場合、コード内で [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドに *Aspose.Slides.lic.xml* で終わるパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**
ストリームからライセンスをロードできます。この C# コードは、ストリームからライセンスを適用する方法を示しています:
``` csharp
// ライセンス クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ストリームを介してライセンスを設定します
license.SetLicense(myStream);
```


### **埋め込みリソース**
ライセンスをアプリケーションに同梱（失くさないように）するには、コンポーネントの DLL を呼び出すアセンブリのいずれかに埋め込みリソースとしてライセンスを追加します（Aspose.Slides に含まれる）。

このようにライセンス ファイルを埋め込みリソースとして追加します:

1. Visual Studio で、ライセンス（.lic）ファイルをプロジェクトに追加します。**File** > **Add Existing Item** > **Add** の順に操作してください。 
2. **Solution Explorer** でファイルを選択します。 
3. **Properties** ウィンドウで **Build Action** を **Embedded Resource** に設定します。 
4. アセンブリに埋め込まれたライセンスにアクセスするには、プロジェクトにライセンス ファイルを埋め込みリソースとして追加し、`SetLicense` メソッドにライセンス ファイル名を渡します。 

`License` クラスは埋め込みリソース内のライセンス ファイルを自動的に検索します。Microsoft .NET Framework の `System.Reflection.Assembly` クラスの `GetExecutingAssembly` や `GetManifestResourceStream` メソッドを呼び出す必要はありません。

この C# コードは、埋め込みリソースとしてライセンスを設定する方法を示しています:
``` csharp
// ライセンス クラスをインスタンス化します
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンス ファイル名を渡します
license.SetLicense("Aspose.Slides.lic");
```


## **ライセンスの検証**

ライセンスが正しく設定されているか確認するには、検証できます。この C# コードは、ライセンスを検証する方法を示しています:
```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```


## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) メソッドはスレッド セーフではありません。このメソッドを多数のスレッドから同時に呼び出す必要がある場合、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

**完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？**

はい。ライセンスの検証はローカルでライセンス ファイルを使用して行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになるとどうなりますか？ ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できなくなります。