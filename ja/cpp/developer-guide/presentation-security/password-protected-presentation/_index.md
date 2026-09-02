---
title: C++ でプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/cpp/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- 開封パスワード
- PowerPoint の暗号化
- PowerPoint の復号化
- プレゼンテーション パスワードの検証
- プレゼンテーション パスワードの確認
- 暗号化されたプレゼンテーションの開く
- 暗号化の解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

開封パスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションの内容を読み込み表示できるため、この保護は機密性を提供します。

開封パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したり、プレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/cpp/write-protected-presentation/) を参照してください。

以下のワークフローは PPT および PPTX プレゼンテーションの両方に適用されます。例では、ファイルベースとストリームベースの動作が重要になる場合の両形式を使用しています。

## **開封パスワードでプレゼンテーションを暗号化する**

`IProtectionManager::Encrypt` を使用して開封パスワードを設定します。その後、`IPresentation::Save` を使用して暗号化されたプレゼンテーションを保存します。

以下の例は PPTX プレゼンテーションを暗号化します。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **暗号化されたプレゼンテーションの読み込み**

`LoadOptions::set_Password` に開封パスワードを設定し、ファイルの読み込み時にそのオプションを `Presentation` に渡します。開封パスワードが必要なのにパスワードが未指定または誤っている場合、読み込みは失敗します。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 復号化されたプレゼンテーションを操作します。
```

## **プレゼンテーションから暗号化を解除する**

開封パスワードを使用してプレゼンテーションを読み込み、`IProtectionManager::RemoveEncryption` を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込めるようになります。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **読み込む前に開封パスワードを検証する**

`IPresentationFactory::GetPresentationInfo` を使用して、完全なプレゼンテーション インスタンスを作成せずに `IPresentationInfo` を取得します。パスワードの要求または検証の前に `IPresentationInfo::get_IsPasswordProtected` を確認します。保護が存在する場合は、`IPresentationInfo::CheckPassword` で提供された値を検証します。

### **ファイルパス ワークフロー**

以下の例は PPTX ファイルの開封パスワードを検証し、検証された値を `LoadOptions::set_Password` に渡してから完全なプレゼンテーションを読み込みます。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **ストリーム ワークフロー**

`IPresentationFactory::GetPresentationInfo` のストリーム オーバーロードでも同様のワークフローが提供されます。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

以下の例は PPT ファイルを使用します。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword の戻り値**

`IPresentationInfo::CheckPassword` は、プレゼンテーションに開封パスワードが設定され、かつ提供されたパスワードが正しい場合にのみ `true` を返します。以下の場合はすべて `false` を返します：

- パスワードが正しくありません。
- プレゼンテーションに開封パスワードが設定されていません。
- 提供されたパスワードが null または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、`IProtectionManager::get_IsEncrypted` を調べて元のプレゼンテーションが暗号化されていることを確認します。読み込み前に開封パスワード保護を検出するには、上記のように `IPresentationInfo::get_IsPasswordProtected` を使用します。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
開封パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な期間だけメモリに保持し、プレゼンテーションをすぐに読み込む際は成功した検証結果を再利用してください。
{{% /alert %}}

## **プレゼンテーションをオンラインでパスワード保護する**

1. Aspose.Slides Lock アプリケーションを開きます。
1. プレゼンテーションを選択するかアップロードします。
1. 閲覧保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/cpp/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**開封パスワードと書き込み保護パスワードの違いは何ですか？**

開封パスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードは暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開封パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開封パスワード保護があるか確認した上で、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証できます。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスとストリームベースのパスワード検出および検証は、PPT と PPTX のプレゼンテーションで同じように動作します。