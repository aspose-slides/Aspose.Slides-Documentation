---
title: C++ でプレゼンテーションに書き込み保護
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/cpp/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーション編集の制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint の PPT および PPTX プレゼンテーションに対する書き込み保護パスワードの設定、検出、検証、解除を行います。"
---
## **概要**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、コンテンツを暗号化しません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションを読み込み、表示できます。アプリケーションによっては、コンテンツを編集して別名で保存できる場合もあるため、書き込み保護は機密性の手段として扱うべきではありません。

オープニングパスワードは別の目的を持ちます。プレゼンテーションを暗号化し、そのコンテンツを読み込む際に必要です。プレゼンテーションを暗号化したり、オープニングパスワードを検証したりするには、[Password-Protect Presentations](/slides/ja/cpp/password-protected-presentation/) を参照してください。

この記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では PPTX ファイルを使用しています。PPT で保存する場合は、`.ppt` 拡張子と対応する PPT 保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションの変更用パスワードを設定するには、[IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) を使用します。プレゼンテーションを保存すると、保護設定が保持されます。

以下の例は PPTX プレゼンテーションに書き込み保護を設定します：

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションのコンテンツを暗号化しないため、プレゼンテーションを読み込む際にパスワードは不要です。パスワードが必要になるのは、保護されたプレゼンテーションの変更権限を検証する場合のみです。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

書き込み保護パスワードを [LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) に渡さないでください。このプロパティは暗号化されたコンテンツ用のオープニングパスワードを受け付けます。プレゼンテーションに両方の保護タイプがある場合、オープニングパスワードで読み込み、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションから書き込み保護を解除する**

変更制限を解除するには [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) を使用し、その後プレゼンテーションを保存します。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションが書き込み保護されているか確認する**

完全な [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成せずにファイルを調べるには、[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を呼び出し、[IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) を確認します。このプロパティは [NullableBool](https://reference.aspose.com/slides/ja/cpp/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合 `NullableBool::True` を返します。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) のストリームオーバーロードも、ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

完全なプレゼンテーションを読み込まずに変更パスワードを検証するには、[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) を使用します。まず [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) を確認し、書き込み保護がある場合にのみアプリケーションがパスワードを要求または検証するようにします。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) は書き込み保護パスワードのみを検証します。オープニングパスワードの検証や暗号化コンテンツの読み込み可否は判断しません。逆に、[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/checkpassword/) はオープニングパスワードのみを検証します。完全なプレゼンテーションがすでに読み込まれている場合、[IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/ja/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/ja/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションのコンテンツは読み込みと表示が可能なままです。

**書き込み保護パスワードはプレゼンテーションを開くために必要ですか？**

いいえ。暗号化されたプレゼンテーションのコンテンツを読み込むには、オープニングパスワードのみが必要です。

**プレゼンテーションはオープニングパスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションでオープニングパスワードを指定し、変更権限が必要なときに書き込み保護パスワードを別途検証してください。