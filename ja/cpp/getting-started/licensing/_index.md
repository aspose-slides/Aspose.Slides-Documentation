---
title: ライセンス
type: docs
weight: 120
url: /ja/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のライセンスを適用、管理、トラブルシューティングします。段階的なライセンスガイドに従って、機能への継続的なアクセスを確保しましょう。"
---

## **Aspose.Slides の評価**

{{% alert color="primary" %}} 

**Aspose.Slides for C++** の評価版は、[NuGet ダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.CPP/)からダウンロードできます。評価版はライセンス版と同じ機能を提供します。実際、評価パッケージは購入版と同一で、ライセンスを適用する数行のコードを追加するとライセンス版になります。

評価版で **Aspose.Slides** に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。利用可能なサブスクリプションの種類を確認することをお勧めします。ご質問がある場合は、Aspose の営業チームまでお気軽にお問い合わせください。

すべての Aspose ライセンスには、1 年間の無料アップグレード（その期間中にリリースされた新バージョンやバグ修正を含む）サブスクリプションが含まれます。ライセンス版でも評価版でも、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* ライセンスが適用されていない Aspose.Slides の評価版は、製品機能はフルに利用できますが、開閉や保存時にドキュメント上部に評価用透かしが挿入されます。
* テキスト抽出は評価版では 1 スライドに制限されます。

{{% alert color="primary" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**を申請できます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス認証**

* 評価版は、ライセンスを購入してコードに数行追加することでライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。改行を加えるだけでもファイルは無効になります。
* Aspose.Slides for C++ は通常、以下の場所でライセンスファイルを検索します：
  * コードで明示的に指定したパス
  * コンポーネントの DLL があるフォルダー（Aspose.Slides に含まれる）
  * コンポーネントの DLL を呼び出すアセンブリがあるフォルダー
* 評価版の制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度設定すれば十分です。

## **ライセンスの適用方法**

ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。

{{% alert color="primary" %}}

Aspose.Slides はライセンス操作用に[License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) クラスを提供します。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。古いバージョンは別のライセンス方式を使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンスファイルをコンポーネントの DLL と同じフォルダー（Aspose.Slides に含まれる）に置き、パスなしでファイル名だけを指定することです。

以下の C++ コードはライセンスファイルの設定方法を示しています：
```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```


{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) メソッドを呼び出す際に、指定した明示的パスの最後にあるファイル名がライセンスファイル名と完全に一致している必要があります。

例えば、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更した場合、コード内で [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) メソッドに *Aspose.Slides.lic.xml* で終了するフルパスを渡さなければなりません。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードすることもできます。以下の C++ コードはストリームからライセンスを適用する方法を示しています：
```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```


## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証できます。以下の C++ コードはライセンスの検証方法を示しています：
```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```


## **スレッド安全性**

{{% alert title="注意" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) メソッドは **スレッドセーフではありません**。複数スレッドから同時にこのメソッドを呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を防止することを推奨します。

{{% /alert %}}

## **FAQ**

**完全にオフラインの環境（インターネットアクセスなし）でライセンスを適用できますか？**

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

**1 年間のサブスクリプションが切れた後はどうなりますか？ライブラリは動作しなくなりますか？**

いいえ。ライセンスは永久利用が可能です。サブスクリプション終了日時点までにリリースされたバージョンは引き続き使用できますが、更新しない限り新しいリリースは利用できません。