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
description: "Aspose.Slides for .NET でライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンスガイドで、機能への継続的なアクセスを確保しましょう。"
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

評価版 **Aspose.Slides for NET** は[その NuGet ダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.NET/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価パッケージは購入パッケージと同一です。評価版は、ライセンスを適用するために数行のコードを追加するとライセンス版になります。

評価版 **Aspose.Slides** に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。さまざまなサブスクリプションタイプをご確認ください。ご質問がある場合は、Aspose の営業チームにお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされた新バージョンや修正への無料アップグレードが 1 年間付属します。ライセンス製品または評価版のユーザーは、無料で無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slides の評価版（ライセンス未指定）はフル機能を提供しますが、開くときと保存するときにドキュメント上部に評価用透かしが挿入されます。  
* プレゼンテーションスライドからテキストを抽出する際は、1 スライドに限定されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を申請できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版は、ライセンスを購入し数行のコードを追加するとライセンス版になります（ライセンスを適用するため）。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、対象開発者数、サブスクリプション有効期限などの情報が含まれます。  
* ライセンスファイルはデジタル署名されているため、変更してはいけません。余分な改行を加えるだけでも無効になります。  
* Aspose.Slides for .NET は通常、以下の場所でライセンスを検索します：
  * 明示的なパス  
  * コンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれる）  
  * コンポーネントの DLL を呼び出したアセンブリが格納されているフォルダー（Aspose.Slides に含まれる）  
  * エントリ アセンブリ（your .exe）が格納されているフォルダー  
  * コンポーネントの DLL を呼び出したアセンブリに埋め込まれたリソース（Aspose.Slides に含まれる）  
* 評価版に伴う制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに一度だけ設定すれば完了です。

{{% alert color="primary" %}} 

[従量課金ライセンス](https://docs.aspose.com/slides/net/metered-licensing/)をご覧ください。

{{% /alert %}} 


## **ライセンスの適用**
ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。 

{{% alert color="primary" %}}

Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/net/aspose.slides/license) クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" %}} 

新しいライセンスはバージョン 21.4 以降でのみ Aspose.Slides を有効化できます。以前のバージョンは別のライセンス方式を使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**
最も簡単なライセンス設定方法は、ライセンスファイルをコンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれる）に置き、パスなしでファイル名だけを指定することです。

この C# コードはライセンスファイルの設定方法を示しています:
``` csharp
// License クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンスファイルのパスを設定します
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドを呼び出す際に、指定した明示的パスの最後にあるライセンスファイル名が実際のファイル名と一致している必要があります。

たとえば、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更できます。その場合、コード内で [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) メソッドに *Aspose.Slides.lic.xml* で終わるパスを渡す必要があります。

{{% /alert %}}

### **ストリーム**
ストリームからライセンスを読み込むことができます。この C# コードはストリームからライセンスを適用する方法を示しています:
``` csharp
// License クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ストリームを使用してライセンスを設定します
license.SetLicense(myStream);
```


### **埋め込みリソース**
ライセンスをアプリケーションにパッケージ化して紛失を防ぐには、コンポーネントの DLL を呼び出すアセンブリのいずれかにライセンスを **埋め込みリソース** として追加します。

ライセンス ファイルを埋め込みリソースとして追加する手順は次のとおりです：

1. Visual Studio で、**File** > **Add Existing Item** > **Add** の順に操作し、プロジェクトにライセンス（.lic）ファイルを追加します。  
2. **Solution Explorer** でファイルを選択します。  
3. **Properties** ウィンドウで **Build Action** を **Embedded Resource** に設定します。  
4. アセンブリに埋め込まれたライセンスにアクセスするには、プロジェクトにライセンス ファイルを埋め込みリソースとして追加し、`SetLicense` メソッドにライセンス ファイル名を渡します。  

`License` クラスは埋め込みリソース内のライセンス ファイルを自動的に検索します。Microsoft .NET Framework の `System.Reflection.Assembly` クラスの `GetExecutingAssembly` および `GetManifestResourceStream` メソッドを呼び出す必要はありません。

この C# コードは埋め込みリソースとしてライセンスを設定する方法を示しています:
``` csharp
// License クラスのインスタンスを作成します
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンスファイル名を渡します
license.SetLicense("Aspose.Slides.lic");
```


## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証できます。この C# コードはライセンスの検証方法を示しています:
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

[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) メソッドはスレッドセーフではありません。このメソッドを多数のスレッドから同時に呼び出す必要がある場合、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

**完全にオフライン環境（インターネット未接続）でもライセンスを適用できますか？**

はい。ライセンス検証はローカルのライセンス ファイルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが期限切れになった後はどうなりますか？ ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久的です。サブスクリプション終了日前にリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できなくなります。