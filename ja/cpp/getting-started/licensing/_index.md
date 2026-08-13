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
description: "Aspose.Slides for C++ のライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンスガイドで、機能への中断なしのフルアクセスを保証します。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版は製品版と同じ機能を提供しますが、プレゼンテーションを開くまたは保存する際に評価用透かしが追加され、テキスト抽出は 1 スライドに制限されます。

本稿では Aspose.Slides のライセンス仕組みと、ライブラリ使用前にライセンスを適用する方法を説明します。ライセンスは `License` クラスを使用してファイル、ストリーム、または埋め込みリソースからロードできます。また、ライセンスが正しく適用されたかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" %}} 

**Aspose.Slides for C++** の評価版は[その NuGet ダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.CPP/)からダウンロードできます。評価版は製品版と同等の機能を提供します。実際、評価パッケージは購入版と同一で、ライセンス適用コードを数行追加するだけでライセンス版になります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)してください。利用可能なサブスクリプションタイプを確認することを推奨します。ご質問がある場合は、Aspose の営業チームまでお気軽にお問い合わせください。

すべての Aspose ライセンスには、1 年間の無料アップグレードサブスクリプションが含まれます。この期間中にリリースされた新バージョンやバグ修正も対象です。ライセンス版でも評価版でも、無料かつ無制限のテクニカルサポートを受けられます。

{{% /alert %}} 

**評価版の制限**

* Aspose.Slides の評価版（ライセンス未適用）は製品の全機能を提供しますが、開く・保存時に文書上部に評価用透かしが挿入されます。
* テキスト抽出は評価版では 1 スライドに限定されます。

{{% alert color="info" %}} 

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版はライセンスを購入し、数行のコードで適用するとライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などが記載されています。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。改行を加えるだけでも無効になります。
* Aspose.Slides for C++ は通常、以下の場所でライセンスファイルを検索します。
  * コードで明示的に指定したパス
  * コンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれる）
  * コンポーネント DLL を呼び出すアセンブリが所在するフォルダー
* 評価版の制限を回避するには、Aspose.Slides 使用前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度だけ設定すれば十分です。

## **ライセンスの適用**

ライセンスは **ファイル**、**ストリーム**、または **埋め込みリソース** からロードできます。

{{% alert color="info" %}}

Aspose.Slides はライセンス操作用に[License](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.license/) クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" %}}

新しいライセンスはバージョン 21.4 以降の Aspose.Slides のみで有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単なライセンス設定方法は、ライセンスファイルをコンポーネントの DLL が格納されているフォルダー（Aspose.Slides に含まれる）に置き、パスを指定せずファイル名だけを渡すことです。

以下の C++ コードはライセンスファイルを設定する例です。

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

ライセンスファイルを別のディレクトリに置く場合、[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) メソッドに渡すパスの最後のファイル名は、実際のライセンスファイル名と完全に一致させる必要があります。

例えば、ライセンスファイル名を *Aspose.Slides.lic.xml* に変更した場合、コード内で [License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) メソッドに *Aspose.Slides.lic.xml* で終わるフルパスを渡さなければなりません。

{{% /alert %}}

### **ストリーム**

ストリームからライセンスをロードすることも可能です。以下の C++ コードはストリームからライセンスを適用する例です。

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、検証を行います。以下の C++ コードはライセンスを検証する例です。

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **スレッド安全性**

{{% alert title="Note" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) メソッドは **スレッド セーフではありません**。複数スレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避することを推奨します。

{{% /alert %}}

## **FAQ**

### 完全にオフライン環境（インターネット接続なし）でライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンスファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作しなくなりますか？

いいえ。ライセンスは永久ライセンスです。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用可能ですが、更新しない限り新しいリリースは利用できません。