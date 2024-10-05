---
title: ライセンス
type: docs
weight: 120
url: /cpp/licensing/
---

## **Aspose.Slidesの評価**

{{% alert color="primary" %}} 

**Aspose.Slides for C++**の評価版は、[NuGetのダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.CPP/)からダウンロードできます。評価版は製品のライセンス版と同じ機能を提供します。評価用パッケージは購入したパッケージと同じです。評価版は、ライセンスを適用するためにいくつかの行のコードを追加することで単にライセンス版になります。

**Aspose.Slides**の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。さまざまなサブスクリプションタイプを確認することをお勧めします。質問がある場合は、Asposeの営業チームにお問い合わせください。

すべてのAsposeライセンスには、新しいバージョンや修正がリリースされた際の無料アップグレードのための1年間のサブスクリプションが付属します。ライセンスされた製品を持つユーザーや評価版を使用しているユーザーは、無料で無制限の技術サポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slidesの評価版（ライセンスが指定されていない）は完全な製品機能を提供しますが、ドキュメントを開くときや保存するときに評価用の透かしを挿入します。
* プレゼンテーションスライドからテキストを抽出する際には、1枚のスライドに制限されます。

{{% alert color="primary" %}} 

制限なしでAspose.Slidesを試すには、**30日間の一時ライセンス**を請求できます。詳しくは[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)のページをご覧ください。

{{% /alert %}}

## **Aspose.Slidesのライセンス**

* 評価版はライセンスを購入し、いくつかの行のコードを追加することでライセンスが適用されます。
* ライセンスは、製品名、ライセンスが付与されている開発者の数、サブスクリプションの有効期限などの詳細を含むプレーンテキストのXMLファイルです。 
* ライセンスファイルはデジタル署名されているため、ファイルを変更してはいけません。ファイルの内容に余分な改行を誤って追加すると、ライセンスが無効になります。
* Aspose.Slides for C++は通常、以下の場所でライセンスを探そうとします。
  * 明示的なパス
  * コンポーネントのDLLを含むフォルダー（Aspose.Slidesに含まれます）
  * コンポーネントのDLLを呼び出すアセンブリを含むフォルダー（Aspose.Slidesに含まれます）
* 評価版に関連する制限を回避するには、Aspose.Slidesを使用する前にライセンスを設定する必要があります。アプリケーションまたはプロセスごとに1回だけライセンスを設定すれば十分です。

## **ライセンスの適用**

ライセンスは**ファイル**、**ストリーム**、または**埋め込みリソース**からロードできます。 

{{% alert color="primary" %}}

Aspose.Slidesはライセンス操作のための[License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/)クラスを提供します。

{{% /alert %}} 

### **ファイル**

ライセンスを設定する最も簡単な方法は、ライセンスファイルをコンポーネントのDLLを含む同じフォルダーに置き、パスを省略したファイル名を指定することです。

以下のC++コードは、ライセンスファイルを設定する方法を示しています:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

ライセンスファイルを異なるディレクトリに置いた場合、[License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67)メソッドを呼び出すときは、指定された明示的なパスの最後にライセンスファイル名がライセンスファイルと一致している必要があります。

例えば、ライセンスファイル名を*Aspose.Slides.lic.xml*に変更できます。コード内で、[License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67)メソッドに対してファイルのパス（*Aspose.Slides.lic.xml*で終わる）を渡す必要があります。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードできます。このC++コードは、ストリームからライセンスを適用する方法を示しています:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **ライセンスの検証**

ライセンスが正しく設定されているかを確認するために、検証できます。このC++コードは、ライセンスを検証する方法を示しています:

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"ライセンスは有効です！");
    System::Console::Read();
}
```

## **スレッドの安全性**

{{% alert title="注意" color="warning" %}} 

[License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67)メソッドはスレッドセーフではありません。このメソッドが多くのスレッドから同時に呼び出される必要がある場合は、問題を避けるために同期原始（ロックなど）を使用してください。 

{{% /alert %}}