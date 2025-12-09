---
title: ライセンス
type: docs
weight: 80
url: /ja/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンス ガイドでフル機能への継続的なアクセスを確保してください。"
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

**Aspose.Slides for NET** の評価版は[その NuGet ダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.NET/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入版と同一です。評価版は数行のコードを追加してライセンスを適用すれば、ライセンス版として機能します。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。さまざまなサブスクリプションタイプをご確認ください。ご質問がある場合は Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが1年間付属します。ライセンス製品を使用しているユーザーや評価版ユーザーも、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない Aspose.Slides の評価版はフル機能を提供しますが、開く時と保存時に文書の上部に評価用透かしを挿入します。  
* プレゼンテーションスライドからテキストを抽出する場合、1枚のスライドに制限されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を取得できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードでライセンスを適用すると、ライセンス版に変わります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプションの有効期限などの情報が含まれます。  
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。余分な改行を加えるだけでも無効になります。  
* Aspose.Slides for .NET は通常、以下の場所でライセンスを検索します。  
  * 明示的なパス  
  * コンポーネントの DLL が含まれるフォルダー（Aspose.Slides に含まれる）  
  * コンポーネントの DLL を呼び出したアセンブリがあるフォルダー（Aspose.Slides に含まれる）  
  * エントリ アセンブリ（your .exe）があるフォルダー  
  * コンポーネントの DLL を呼び出したアセンブリに埋め込まれたリソース（Aspose.Slides に含まれる）  
* 評価版に伴う制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば済みます。

{{% alert color="primary" %}} 
[メーター制ライセンス](https://docs.aspose.com/slides/net/metered-licensing/)をご覧になることをおすすめします。
{{% /alert %}} 

## **ライセンスの適用**
ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。

{{% alert color="primary" %}}
Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/net/aspose.slides/license) クラスを提供します。
{{% /alert %}} 

{{% alert color="warning" %}} 
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンス方式を使用しており、これらのライセンスは認識されません。
{{% /alert %}}

### **ファイル**
ライセンスを設定する最も簡単な方法は、ライセンス ファイルをコンポーネントの DLL があるフォルダー（Aspose.Slides に含まれる）に配置し、パスを付けずにファイル名だけを指定することです。

C# のコード例はライセンス ファイルの設定方法を示しています。
``` csharp
// License クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイルのパスを設定します
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 
ライセンス ファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドを呼び出す際、指定した明示的なパスの最後にあるライセンス ファイル名は実際のライセンス ファイル名と一致している必要があります。  
例として、ライセンス ファイル名を *Aspose.Slides.lic.xml* に変更できます。その場合、コード内で [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドに *Aspose.Slides.lic.xml* で終わるファイル パスを渡す必要があります。
{{% /alert %}}

### **ストリーム**
ストリームからライセンスをロードすることができます。以下の C# コードはストリームからライセンスを適用する方法を示しています。
``` csharp
// ライセンス クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ストリームを介してライセンスを設定します
license.SetLicense(myStream);
```


### **埋め込みリソース**
ライセンスをアプリケーションに組み込むことで（紛失を防ぐため）コンポーネントの DLL を呼び出すアセンブリのいずれかに埋め込みリソースとして追加できます（Aspose.Slides に含まれる）。

ライセンス ファイルを埋め込みリソースとして追加する手順は以下のとおりです。

1. Visual Studio で、ライセンス（.lic）ファイルをプロジェクトに追加します。**File** > **Add Existing Item** > **Add** の順に操作してください。  
2. **Solution Explorer** でファイルを選択します。  
3. **Properties** ウィンドウで **Build Action** を **Embedded Resource** に設定します。  
4. アセンブリに埋め込まれたライセンスにアクセスするには、プロジェクトにライセンス ファイルを埋め込みリソースとして追加し、`SetLicense` メソッドにライセンス ファイル名を渡します。  

`License` クラスは埋め込みリソース内のライセンス ファイルを自動的に検出します。Microsoft .NET Framework で `System.Reflection.Assembly` クラスの `GetExecutingAssembly` および `GetManifestResourceStream` メソッドを呼び出す必要はありません。

``` csharp
// License クラスをインスタンス化します
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンス ファイル名を渡します
license.SetLicense("Aspose.Slides.lic");
```


## **ライセンスの検証**
ライセンスが正しく設定されているか確認するには、検証を行います。以下の C# コードはライセンスの検証方法を示しています。
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
[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) メソッドはスレッド セーフではありません。このメソッドを多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 
{{% /alert %}}

## **FAQ**
**完全にオフライン（インターネット接続なし）の環境でライセンスを適用できますか？**  
はい。ライセンスの検証はライセンス ファイルを使用してローカルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？**  
いいえ。ライセンスは永久的なもので、サブスクリプション終了日までにリリースされたバージョンは引き続き使用できます。ただし、更新しない限り新しいリリースは利用できなくなります。