---
title: ライセンス
type: docs
weight: 80
url: /ja/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンスガイドで、機能を中断なくフルに利用できるようにします。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版はライセンス版と同じ機能を提供しますが、プレゼンテーションを開くまたは保存する際に評価用の透かしが追加され、テキスト抽出は1枚のスライドに制限されます。

本稿では Aspose.Slides のライセンスの仕組みと、ライブラリを使用する前にライセンスを適用する方法について説明します。ライセンスは `License` クラスを使用してファイル、ストリーム、または埋め込みリソースから読み込むことができます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" %}} 

**Aspose.Slides for .NET** の評価版は [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/) からダウンロードできます。評価版は製品のライセンス版と同等の機能を提供します。評価パッケージは購入パッケージと同一です。評価版はコードに数行追加してライセンスを適用すれば、ライセンス版となります。

**Aspose.Slides** の評価に満足したら、[purchase a license](https://purchase.aspose.com/buy) してください。さまざまなサブスクリプションタイプをご確認いただくことをおすすめします。質問がある場合は Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中の新バージョンや修正への無料アップグレードが1年間付属します。ライセンス製品でも評価版でも、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slides の評価版（ライセンス未指定）は製品の全機能を提供しますが、開くまたは保存するたびにドキュメント上部に評価用透かしが挿入されます。  
* プレゼンテーションスライドからテキストを抽出できるのは 1 枚のスライドに限られます。

{{% alert color="info" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス** を取得できます。詳細は [How to get a Temporary License](https://purchase.aspose.com/temporary-license) ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス設定**
* 評価版はライセンスを購入し、数行のコードでライセンスを適用するとライセンス版になります。  
* ライセンスはプレーンテキストの XML ファイルで、製品名、対象開発者数、サブスクリプション有効期限などが記載されています。  
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。余計な改行を加えるだけでも無効になります。  
* Aspose.Slides for .NET は通常、次の場所でライセンスを検索します：  
  * 明示的に指定したパス  
  * コンポーネントの DLL があるフォルダー（Aspose.Slides に含まれる）  
  * コンポーネントの DLL を呼び出したアセンブリがあるフォルダー（Aspose.Slides に含まれる）  
  * エントリ アセンブリ（実行ファイル）所在のフォルダー  
  * コンポーネントの DLL を呼び出したアセンブリに埋め込まれたリソース（Aspose.Slides に含まれる）  
* 評価版に伴う制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度設定すれば済みます。

{{% alert color="info" %}} 

[Metered Licensing](https://docs.aspose.com/slides/ja/net/metered-licensing/) もご参照ください。

{{% /alert %}} 

## **ライセンスの適用**
ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。

{{% alert color="info" %}}

Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/ja/net/aspose.slides/license) クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" %}} 

新しいライセンスはバージョン 21.4 以降でのみ Aspose.Slides を有効化できます。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスを認識しません。

{{% /alert %}}

### **ファイル**
最も簡単なライセンス設定方法は、ライセンスファイルをコンポーネントの DLL があるフォルダー（Aspose.Slides に含まれる）に置き、パスを指定せずファイル名だけを指定することです。

この C# コードはライセンスファイルの設定方法を示しています：

``` csharp
// License クラスをインスタンス化します
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイル パスを設定します
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/ja/net/aspose.slides/license/setlicense/#setlicense_1) メソッドを呼び出す際に、明示的に指定したパスの末尾にあるライセンスファイル名が実際のファイル名と一致している必要があります。

たとえば、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更した場合、コード内で [SetLicense](https://reference.aspose.com/slides/ja/net/aspose.slides/license/setlicense/#setlicense_1) メソッドに渡すパスは *Aspose.Slides.lic.xml* で終わる必要があります。

{{% /alert %}}

### **ストリーム**
ストリームからライセンスをロードすることもできます。この C# コードはストリームからライセンスを適用する方法を示しています：

``` csharp
// License クラスをインスタンス化します
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイルをストリームとして開きます
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// ストリームを使用してライセンスを設定します
license.SetLicense(licenseStream);
```

### **埋め込みリソース**
ライセンスをアプリケーションに同梱して紛失を防ぐには、コンポーネントの DLL を呼び出すアセンブリのいずれかに埋め込みリソースとしてライセンスを追加します。

埋め込みリソースとしてライセンスファイルを追加する手順は次のとおりです：

1. Visual Studio で **File** > **Add Existing Item** > **Add** の順に選択し、ライセンス（.lic）ファイルをプロジェクトに追加します。  
2. **Solution Explorer** でファイルを選択します。  
3. **Properties** ウィンドウで **Build Action** を **Embedded Resource** に設定します。  
4. アセンブリに埋め込まれたライセンスにアクセスするには、ライセンスファイル名を `SetLicense` メソッドに渡すだけで済みます。  

`License` クラスは埋め込みリソース内のライセンスファイルを自動的に検出します。Microsoft .NET Framework の `System.Reflection.Assembly` クラスの `GetExecutingAssembly` および `GetManifestResourceStream` メソッドを呼び出す必要はありません。

この C# コードは埋め込みリソースとしてライセンスを設定する方法を示しています：

``` csharp
// License クラスをインスタンス化します
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンス ファイル名を渡します
license.SetLicense("Aspose.Slides.lic");
```

## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。この C# コードはライセンスの検証方法を示しています：

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

`license.SetLicense` メソッドはスレッドセーフではありません。多数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 

{{% /alert %}}

## **FAQ**

### 完全にオフライン環境（インターネット非接続）でもライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ ライブラリは動作を停止しますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新せずに新しいリリースを使用することはできません。更新するにはサブスクリプションを更新する必要があります。