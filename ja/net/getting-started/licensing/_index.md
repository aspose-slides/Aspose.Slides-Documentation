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
description: "Aspose.Slides for .NET のライセンスを適用、管理、トラブルシュートします。ステップバイステップのライセンス ガイドに従い、機能を中断なくフルに利用できるようにします。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価バージョンは有償バージョンと同じ機能を提供しますが、保存する各プレゼンテーションの各スライドに評価用透かしが追加され、プレゼンテーションからコードが読み取るテキストは切り詰められます。

本記事では Aspose.Slides のライセンスの仕組みと、ライブラリを使用する前にライセンスを適用する方法について説明します。ライセンスは `License` クラスを使用して、ファイル、ストリーム、または埋め込みリソースからロードできます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**
{{% alert color="info" title="Note" %}}
**Aspose.Slides for .NET** の評価版は、[NuGet のダウンロード ページ](https://www.nuget.org/packages/Aspose.Slides.NET/)からダウンロードできます。評価版は製品の有償版と同じ機能を提供します。評価パッケージは購入パッケージと同一です。評価版は、数行のコード（ライセンスを適用するコード）を追加するだけでライセンス版になります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/pricing/slides/ja/net/)できます。さまざまなサブスクリプションタイプをご確認いただくことをお勧めします。ご質問がある場合は、Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、サブスクリプション期間中にリリースされる新バージョンや修正への無料アップグレードが1年間付帯します。ライセンス製品を使用しているユーザーだけでなく、評価版ユーザーも無料で無制限のテクニカルサポートを受けられます。
{{% /alert %}} 

**評価版の制限**
* ライセンスが指定されていない評価版は製品の全機能を提供しますが、保存する各プレゼンテーションの各スライドに評価用透かしテキストボックスが追加されます。
* プレゼンテーションからコードが読み取るテキストは最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストはそのまま全体が保存されます。

{{% alert color="info" title="Note" %}}
制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を取得できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)のページをご覧ください。
{{% /alert %}}

## **Aspose.Slides のライセンス**
* 評価版はライセンスを購入し、数行のコード（ライセンスを適用するコード）を追加するとライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象の開発者数、サブスクリプションの有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。ファイル内容に余計な改行が入るだけでも無効になります。
* Aspose.Slides for .NET は通常、次の場所でライセンスを検索します。
  * 明示的なパス
  * コンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれます）
  * コンポーネントの DLL を呼び出したアセンブリが格納されているフォルダー（Aspose.Slides に含まれます）
  * エントリ アセンブリ（あなたの .exe）が格納されているフォルダー
  * コンポーネントの DLL を呼び出したアセンブリに埋め込まれたリソース（Aspose.Slides に含まれます）。
* 評価版に伴う制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度設定すれば十分です。

{{% alert color="info" title="Note" %}}
[従量制ライセンス](/slides/ja/net/metered-licensing/)をご覧ください。
{{% /alert %}} 

## **ライセンスの適用**
ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。

{{% alert color="info" title="Note" %}}
Aspose.Slides はライセンス操作用に [License](https://reference.aspose.com/slides/ja/net/aspose.slides/license) クラスを提供しています。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンス システムを使用しており、これらのライセンスは認識されません。
{{% /alert %}}

### **ファイル**
ライセンスを設定する最も簡単な方法は、ライセンス ファイルをコンポーネントの DLL（Aspose.Slides に含まれます）があるフォルダーと同じ場所に配置し、パスを付けずにファイル名だけを指定することです。

以下の C# コードはライセンス ファイルの設定方法を示しています。

``` csharp
// License クラスのインスタンスを作成します 
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイル パスを設定します
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
ライセンス ファイルを別のディレクトリに置く場合、[SetLicense](https://reference.aspose.com/slides/ja/net/aspose.slides/license/setlicense/#setlicense_1) メソッドを呼び出す際、指定したパスの最後にあるライセンス ファイル名は実際のファイル名と同一でなければなりません。

例として、ライセンス ファイル名を *Aspose.Slides.lic.xml* に変更できます。その場合、コード内で [SetLicense](https://reference.aspose.com/slides/ja/net/aspose.slides/license/setlicense/#setlicense_1) メソッドに *Aspose.Slides.lic.xml* で終わるパスを渡す必要があります。
{{% /alert %}}

### **ストリーム**
ストリームからライセンスをロードすることができます。以下の C# コードはストリームからライセンスを適用する方法を示しています。

``` csharp
// License クラスのインスタンスを作成します
Aspose.Slides.License license = new Aspose.Slides.License();

// ライセンス ファイルをストリームとして開きます
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// ストリームでライセンスを設定します
license.SetLicense(licenseStream);
```

### **埋め込みリソース**
ライセンスをアプリケーションにパッケージ化して紛失を防ぐには、コンポーネントの DLL（Aspose.Slides に含まれます）を呼び出すアセンブリのいずれかに埋め込みリソースとしてライセンスを追加します。

ライセンス ファイルを埋め込みリソースとして追加する手順は以下の通りです。
1. Visual Studio で、ライセンス（.lic）ファイルをプロジェクトに追加します。**File** > **Add Existing Item** > **Add** の順に操作してください。
2. **Solution Explorer** でファイルを選択します。
3. **Properties** ウィンドウで **Build Action** を **Embedded Resource** に設定します。
4. アセンブリに埋め込まれたライセンスにアクセスするには、プロジェクトにライセンス ファイルを埋め込みリソースとして追加し、`SetLicense` メソッドにライセンス ファイル名を渡します。

`License` クラスは埋め込みリソース内のライセンス ファイルを自動的に検出します。Microsoft .NET Framework の `System.Reflection.Assembly` クラスの `GetExecutingAssembly` および `GetManifestResourceStream` メソッドを呼び出す必要はありません。

以下の C# コードは埋め込みリソースとしてライセンスを設定する方法を示しています。

``` csharp
// License クラスのインスタンスを作成します
Aspose.Slides.License license = new Aspose.Slides.License();

// アセンブリに埋め込まれたライセンス ファイル名を渡します
license.SetLicense("Aspose.Slides.lic");
```

## **ライセンスの検証**
ライセンスが正しく設定されたか確認するには、検証を行います。以下の C# コードはライセンスの検証方法を示しています。

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
{{% alert color="warning" title="Warning" %}}
[license.SetLicense](https://reference.aspose.com/slides/ja/net/aspose.slides/license/setlicense/) メソッドはスレッドセーフではありません。このメソッドを複数のスレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避してください。 
{{% /alert %}}

## **FAQ**

### オフライン環境（インターネット接続なし）でもライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンス ファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？

いいえ。ライセンスは永久的なもので、サブスクリプション終了日までにリリースされたバージョンは引き続き使用可能です。ただし、更新しない限り新しいリリースは使用できません。