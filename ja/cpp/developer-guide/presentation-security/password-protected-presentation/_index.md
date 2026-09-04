---
title: C++ でのプレゼンテーションのパスワード保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/cpp/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPoint を暗号化
- PowerPoint を復号化
- プレゼンテーション パスワードを検証
- プレゼンテーション パスワードを確認
- 暗号化されたプレゼンテーションを開く
- 暗号化を除去
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

開くためのパスワードはプレゼンテーションを暗号化します。正しいパスワードがなければプレゼンテーションのコンテンツを読み込んだり表示したりできないため、この保護は機密性を提供します。

開くためのパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/cpp/write-protected-presentation/)をご参照ください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの振る舞いが重要になる場合の両形式を使用しています。

## **開くためのパスワードでプレゼンテーションを暗号化する**

[IProtectionManager::Encrypt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/encrypt/) を使用して開くためのパスワードを設定します。その後、[IPresentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/save/) を使用して暗号化されたプレゼンテーションを保存します。

次の例は PPTX プレゼンテーションを暗号化します。

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

## **ドキュメントプロパティを公開したままにする**

既定では Aspose.Slides はプレゼンテーション暗号化にドキュメントプロパティを含めます。[IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) はスライドコンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、ドキュメント管理システムが開くためのパスワードなしでメタデータを読み取る必要がある場合は、[IProtectionManager::Encrypt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/encrypt/) を呼び出す前にこのメソッドに `false` を渡してください。

次の例は、組み込みドキュメントプロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`set_EncryptDocumentProperties` に `false` を渡しても、スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーションコンテンツが公開されるわけではありません。これはドキュメントプロパティのみに影響します。暗号化されたコンテンツを読み込まずにこれらのプロパティを取得する方法については、[Manage Presentation Properties](/slides/ja/cpp/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションを読み込む**

[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) に開くためのパスワードを設定し、ファイルの読み込み時にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) に渡します。開くためのパスワードが必要なのに、パスワードが提供されていないか間違っている場合、読み込みは失敗します。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 復号化されたプレゼンテーションで作業します。
```

## **プレゼンテーションから暗号化を除去する**

開くためのパスワードでプレゼンテーションを読み込み、[IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/removeencryption/) を呼び出してから保存します。保存されたプレゼンテーションはパスワードなしで読み込めるようになります。

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

## **読み込む前に開くためのパスワードを検証する**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用して、完全なプレゼンテーションインスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/) を取得します。パスワードを要求または検証する前に、[IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) を確認してください。保護が存在する場合は、[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/checkpassword/) で提供された値を検証します。

### **ファイルパスワークフロー**

次の例は PPTX ファイルに対して開くためのパスワードを検証し、検証済みの値を [LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) に渡してから、完全なプレゼンテーションを読み込みます。

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

### **ストリームワークフロー**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) のストリームオーバーロードも同様のワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します。

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/checkpassword/) は、プレゼンテーションに開くためのパスワードが設定されていて、かつ提供されたパスワードが正しい場合にのみ `true` を返します。次のいずれかの場合は `false` を返します。

- パスワードが間違っている。
- プレゼンテーションに開くためのパスワードが設定されていない。
- 提供されたパスワードが null または空文字列である。

この挙動は PPT と PPTX の両方のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) を調べて、元のプレゼンテーションが暗号化されていたかどうかを確認します。読み込み前に開くためのパスワード保護を検出するには、上記と同様に `IPresentationInfo::get_IsPasswordProtected` を使用してください。

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
開くためのパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証は避け、パスワードは必要な時間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。
{{% /alert %}}

公開ドキュメントプロパティには、著者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値が含まれることがあり、プレゼンテーションの内容が暗号化されていても情報が漏洩する可能性があります。機密性の高いメタデータはプレゼンテーションと一緒に暗号化してください。プロパティを公開したままにするのは、システムが開くためのパスワードなしでファイルをインデックス作成、分類、検索、または管理する必要がある場合に限り、明示的な判断として行ってください。
{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を適用する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択またはアップロードします。
3. 表示保護用のパスワードを入力します。
4. 必要に応じて編集保護用の別のパスワードを入力します。
5. 保護を適用して、結果のファイルをダウンロードします。

## **FAQ**

**開くためのパスワードと書き込み保護パスワードの違いは何ですか？**

開くためのパスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードは暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開くためのパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開くためのパスワード保護が存在するかを確認した上で、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証できます。

**アプリケーションは開くためのパスワードなしでメタデータを読み取れますか？**

はい。ただし、プレゼンテーションが `set_EncryptDocumentProperties(false)` で暗号化された場合に限ります。その場合は、[Manage Presentation Properties](/slides/ja/cpp/presentation-properties/) で説明されているドキュメントプロパティのみのロードモードを使用してください。

**パスワード検証ワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同じように動作します。