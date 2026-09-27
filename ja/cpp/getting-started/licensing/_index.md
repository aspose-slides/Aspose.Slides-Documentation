---
title: ライセンス
type: docs
weight: 120
url: /ja/cpp/licensing/
keywords:
- ライセンス
- 一時ライセンス
- ライセンスの設定
- ライセンスの使用
- ライセンスの検証
- ライセンス ファイル
- 評価版
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のライセンスを適用、管理、トラブルシューティングします。ステップバイステップのライセンス ガイドで、機能へのアクセスを中断なく確保できます。"
---
## **概要**

Aspose.Slides は評価モードまたは有効なライセンスで使用できます。評価版はライセンス版と同じ機能を提供しますが、保存する各プレゼンテーションのすべてのスライドに評価用の透かしが追加され、プレゼンテーションからコードが読み取るテキストが切り捨てられます。

本記事では Aspose.Slides のライセンス方式と、ライブラリを使用する前にライセンスを適用する方法を説明します。`License` クラスを使用してファイルまたはストリームからライセンスをロードできます。また、ライセンスが正しく適用されたかどうかを検証する方法も示します。

## **Aspose.Slides の評価**

{{% alert color="info" title="Note" %}}

**Aspose.Slides for C++** の評価版は、[NuGet ダウンロードページ](https://www.nuget.org/packages/Aspose.Slides.Cpp/)から、または ZIP パッケージとして[ダウンロードページ](https://releases.aspose.com/slides/ja/cpp/)から取得できます。評価版はライセンス製品と同等の機能を提供します。実際、評価パッケージは購入版と同一で、ライセンスを適用する数行のコードを追加するとライセンス版になります。

**Aspose.Slides** の評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/pricing/slides/ja/cpp/)できます。利用可能なサブスクリプションタイプをご確認ください。ご質問がある場合は、Aspose の営業チームまでお問い合わせください。

すべての Aspose ライセンスには、1 年間の無料アップグレード（期間中にリリースされる新バージョンとバグ修正を含む）サブスクリプションが含まれます。ライセンス版でも評価版でも、無料で無制限の技術サポートが受けられます。

{{% /alert %}} 

**評価版の制限**

* ライセンスが指定されていない評価版は、製品のすべての機能を提供しますが、保存する各プレゼンテーションのすべてのスライドに評価用透かしテキストボックスが追加されます。
* プレゼンテーションからコードが読み取るテキストは、最初の数文字に切り詰められ、評価制限に関する通知が付加されます。コードが書き込むテキストは全て保存されます。

{{% alert color="info" title="Note" %}}

制限なしで Aspose.Slides をテストしたい場合は、**30 日間の一時ライセンス**をリクエストできます。詳細は[一時ライセンスの取得方法](https://purchase.aspose.com/temporary-license)ページをご覧ください。

{{% /alert %}}

## **Aspose.Slides のライセンス**

* 評価版は、ライセンスを購入して数行のコードで適用すると、ライセンス版になります。
* ライセンスはプレーンテキストの XML ファイルで、製品名、ライセンス対象開発者数、サブスクリプション有効期限などの情報が含まれます。
* ライセンスファイルはデジタル署名されているため、変更してはいけません。改行を追加するといった偶発的な変更でもファイルは無効になります。
* フォルダーなしでファイル名だけを渡すと、Aspose.Slides for C++ はカレント ワーキング ディレクトリでライセンスファイルを検索します。実行ファイルや Aspose.Slides ライブラリのフォルダーは検索対象にならないため、別の場所にある場合はフルパスを指定してください。
* 評価版の制限を回避するには、Aspose.Slides を使用する前にライセンスを設定する必要があります。ライセンスはアプリケーションまたはプロセスごとに一度設定すれば十分です。

## **ライセンスの適用**

ライセンスは **ファイル** または **ストリーム** からロードできます。

{{% alert color="info" title="Note" %}}

Aspose.Slides は、ライセンス操作用に[License](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/)クラスを提供しています。

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

新しいライセンスはバージョン 21.4 以降でのみ有効です。以前のバージョンは別のライセンスシステムを使用しており、これらのライセンスは認識されません。

{{% /alert %}}

### **ファイル**

最も簡単な方法は、ライセンス ファイルをプログラムの作業ディレクトリに配置し、パスなしでファイル名だけを指定することです。別の場所にある場合はフルパスを指定します。

以下の C++ コードは、プログラムの作業ディレクトリにある *Aspose.Slides.lic* を適用します。

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

ライセンスが有効な場合、[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) は例外をスローせずに戻り、プログラムは何も出力せずに終了します。その後、Aspose.Slides は評価制限なしで動作します。ファイルが作業ディレクトリにない場合、メソッドは[FileNotFoundException](https://reference.aspose.com/slides/ja/cpp/system.io/filenotfoundexception/) をスローし、メッセージは *License "Aspose.Slides.lic" doesn't exist or access is restricted* となります。この例では例外を捕捉していないため、プログラムは停止します。

{{% alert color="warning" title="Warning" %}}

ライセンス ファイルを別のディレクトリに置く場合、[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) メソッドに渡す完全パスの最後のファイル名は、ライセンス ファイルの名前と完全に一致している必要があります。

たとえば、ライセンス ファイル名を *Aspose.Slides.lic.xml* に変更した場合、コード内で [License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) に渡すパスは *Aspose.Slides.lic.xml* で終わるフルパスでなければなりません。

{{% /alert %}}

### **ストリーム**

ライセンスをファイルとして保持せず、たとえばデータベースから読み込む場合は、ストリームからロードします。[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) はライセンスを含む任意の [Stream](https://reference.aspose.com/slides/ja/cpp/system.io/stream/) を受け付けます。例を簡潔にするため、以下の C++ コードは作業ディレクトリの *Aspose.Slides.lic* を [File::OpenRead](https://reference.aspose.com/slides/ja/cpp/system.io/file/openread/) で開き、そのストリームからライセンスを適用します。

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

有効なライセンスはファイル例と同じ結果になります。ファイルが存在しない場合、[File::OpenRead](https://reference.aspose.com/slides/ja/cpp/system.io/file/openread/) が [FileNotFoundException](https://reference.aspose.com/slides/ja/cpp/system.io/filenotfoundexception/) をスローし、ライセンスは適用されずにプログラムは停止します。

## **ライセンスの検証**

ライセンスが正しく設定されたか確認するには、[License::IsLicensed](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/islicensed/) を呼び出します。有効なライセンスが適用された後にのみ `true` を返し、それ以前は `false` を返します。以下の C++ コードは作業ディレクトリのライセンス ファイルを適用し、続いて検証します。

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

有効なライセンスがある場合、プログラムは *License is good!* と出力します。ファイルが不存在またはライセンス ファイルでない場合、[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) が例外をスローし、チェック前にプログラムは何も出力せずに停止します。署名が一致しないライセンス（例：編集された場合）では、SetLicense はエラーなしで戻りますが `IsLicensed` は `false` を返すため、何も出力されず Aspose.Slides は評価モードのままです。

## **スレッド安全性**

{{% alert color="warning" title="Warning" %}}

[License::SetLicense](https://reference.aspose.com/slides/ja/cpp/aspose.slides/license/setlicense/) メソッドは **スレッドセーフではありません**。複数スレッドから同時に呼び出す必要がある場合は、ロックなどの同期プリミティブを使用して問題を回避することを推奨します。

{{% /alert %}}

## **よくある質問**

### 完全にオフラインの環境（インターネット接続なし）でライセンスを適用できますか？

はい。ライセンスの検証はローカルのライセンス ファイルで行われるため、インターネット接続は不要です。

### 1 年間のサブスクリプションが期限切れになった後はどうなりますか？ライブラリは動作を停止しますか？

いいえ。ライセンスは永久的です。サブスクリプション終了日以前にリリースされたバージョンは引き続き使用できますが、更新せずに新しいリリースを使用することはできません。