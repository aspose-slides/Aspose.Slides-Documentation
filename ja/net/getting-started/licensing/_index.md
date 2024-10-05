---  
title: ライセンス  
type: docs  
weight: 80  
url: /net/licensing/  
---  

## **Aspose.Slidesの評価**

{{% alert color="primary" %}} 

**Aspose.Slides for NET**の評価版を[NuGetのダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.NET/)からダウンロードできます。評価版は、製品のライセンス版と同じ機能を提供します。評価パッケージは購入されたパッケージと同じです。評価版は、いくつかのコード行を追加することで（ライセンスを適用するために）ライセンス版に変わります。

**Aspose.Slides**の評価が満足できるものであれば、[ライセンスを購入](https://purchase.aspose.com/buy)できます。異なるサブスクリプションタイプを確認することをお勧めします。質問がある場合は、Asposeの販売チームにお問い合わせください。

すべてのAsposeライセンスには、新しいバージョンやサブスクリプション期間内にリリースされた修正への無料アップグレードが1年間含まれています。ライセンス製品をお持ちのユーザーや評価版ユーザーは、無料で無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slidesの評価版（ライセンス未指定）は、完全な製品機能を提供しますが、文書のオープンおよび保存操作時に評価用のウォーターマークを挿入します。
* プレゼンテーションスライドからテキストを抽出する際は、1スライドに制限されています。

{{% alert color="primary" %}} 

制限なしでAspose.Slidesをテストするには、**30日間の一時ライセンス**をリクエストできます。詳細については、[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slidesにおけるライセンス**

* 評価版は、ライセンスを購入し、いくつかのコード行を追加するとライセンス版になります（ライセンスを適用するために）。
* ライセンスは、製品名、ライセンスされている開発者の数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。
* ライセンスファイルはデジタル署名されているため、ファイルを変更しないでください。ファイルの内容に意図せず追加した改行すらも無効にします。
* Aspose.Slides for .NET は通常、以下の場所でライセンスを探します：
  * 明示的なパス
  * コンポーネントのDLLが含まれるフォルダー（Aspose.Slidesに含まれています）
  * コンポーネントのDLLを呼び出したアセンブリが含まれるフォルダー（Aspose.Slidesに含まれています）
  * エントリーアセンブリ（あなたの.exe）が含まれるフォルダー
  * コンポーネントのDLLを呼び出したアセンブリ内の埋め込みリソース（Aspose.Slidesに含まれています）。
* 評価版に関連する制限を回避するには、Aspose.Slidesを使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとにライセンスを1回設定すれば大丈夫です。

{{% alert color="primary" %}} 

[メーターライセンス](https://docs.aspose.com/slides/net/metered-licensing/)を確認することをお勧めします。

{{% /alert %}} 

## **ライセンスの適用**
ライセンスは**ファイル**、**ストリーム**、または**埋め込みリソース**から読み込むことができます。

{{% alert color="primary" %}}

Aspose.Slidesはライセンス操作のための[License](https://reference.aspose.com/slides/net/aspose.slides/license)クラスを提供しています。

{{% /alert %}} 

### **ファイル**
ライセンスを設定する最も簡単な方法は、ライセンスファイルをコンポーネントのDLLが含まれる同じフォルダーに置き、パスを指定せずにファイル名のみを指定することです。

このC#コードは、ライセンスファイルを設定する方法を示しています：

```csharp
// Licenseクラスをインスタンス化
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンスファイルのパスを設定
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを異なるディレクトリに置くと、[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)メソッドを呼び出す際、指定された明示的なパスの最後のライセンスファイル名は、ライセンスファイル名と同じでなければなりません。

たとえば、ライセンスファイル名を*Aspose.Slides.lic.xml*に変更することができます。この場合、コード内で、ファイルのパス（*Aspose.Slides.lic.xml*で終わる）を[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)メソッドに渡す必要があります。

{{% /alert %}}

### **ストリーム**
ストリームからライセンスを読み込むことができます。このC#コードは、ストリームからライセンスを適用する方法を示しています：

```csharp
// Licenseクラスをインスタンス化
Aspose.Slides.License license = new Aspose.Slides.License();

// ストリームを介してライセンスを設定
license.SetLicense(myStream);
```

### **埋め込みリソース**
アプリケーションにライセンスをパッケージ化して（紛失を避けるために）、コンポーネントのDLLを呼び出すアセンブリの1つにライセンスを埋め込みリソースとして追加します。

これが、ライセンスファイルを埋め込みリソースとして追加する方法です：

1. Visual Studioで、以下の手順でライセンス（.lic）ファイルをプロジェクトに追加します：**ファイル** > **既存アイテムの追加** > **追加**。
2. **ソリューションエクスプローラー**でファイルを選択します。
3. **プロパティ**ウィンドウで、**ビルドアクション**を**埋め込まれたリソース**に設定します。
4. アセンブリに埋め込まれたライセンスにアクセスするには、ライセンスファイルを埋め込みリソースとしてプロジェクトに追加し、ライセンスファイル名を`SetLicense`メソッドに渡します。

`License`クラスは自動的に埋め込まれたリソース内のライセンスファイルを見つけます。Microsoft .NET Frameworkの`System.Reflection.Assembly`クラスの`GetExecutingAssembly`および`GetManifestResourceStream`メソッドを呼び出す必要はありません。

このC#コードは、埋め込まれたリソースとしてライセンスを設定する方法を示しています：

```csharp
// Licenseクラスをインスタンス化
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンスファイル名を渡す
license.SetLicense("Aspose.Slides.lic");
```

## **ライセンスの検証**

ライセンスが正しく設定されているか確認するために、検証できます。このC#コードは、ライセンスを検証する方法を示しています：

```csharp
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("ライセンスは有効です！");
    Console.Read();
}
```

## **スレッドセーフ**

{{% alert title="注意" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/)メソッドはスレッドセーフではありません。このメソッドを多くのスレッドから同時に呼び出す必要がある場合は、問題を避けるために同期プリミティブ（ロックなど）を使用することを検討してください。

{{% /alert %}}