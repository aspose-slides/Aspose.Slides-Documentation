---
title: ".NET でプレゼンテーションを書き込み保護"
linktitle: "書き込み保護"
type: docs
weight: 25
url: /ja/net/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーションの編集制限
- 書き込み保護の削除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint の PPT および PPTX プレゼンテーションに対し、書き込み保護パスワードの設定、検出、検証、削除を行う。"
---
## **はじめに**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、内容を暗号化しません。ユーザーは書き込み保護されたプレゼンテーションをパスワードなしで読み込み、表示できます。アプリケーションによっては、内容を編集して別名で保存できる場合もあるため、書き込み保護は機密性の手段として扱うべきではありません。

開くためのパスワードは別の目的を持ちます。プレゼンテーションを暗号化し、内容の読み込みに必要です。プレゼンテーションを暗号化する方法や開くためのパスワードの検証については、[Password-Protect Presentations](/slides/ja/net/password-protected-presentation/)をご参照ください。

本記事のワークフローは PPT と PPTX の両方に適用されます。例は PPTX ファイルを使用しています。PPT で保存する場合は拡張子を `.ppt` にし、対応する PPT 保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

[IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/setwriteprotection/) を使用して、プレゼンテーションの変更用パスワードを設定します。プレゼンテーションを保存すると、保護設定が保持されます。

次の例は PPTX プレゼンテーションに書き込み保護を設定します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションの内容を暗号化しないため、読み込みにパスワードは不要です。パスワードは保護されたプレゼンテーションの変更権限を検証する際にのみ使用されます。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

[LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に書き込み保護パスワードを渡さないでください。このプロパティは暗号化された内容用の開くためのパスワードを受け取ります。プレゼンテーションに両方の保護タイプがある場合は、開くためのパスワードを指定して読み込み、書き込み保護パスワードは別途扱います。

## **プレゼンテーションから書き込み保護を削除する**

[IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/removewriteprotection/) を使用して変更制限を解除し、プレゼンテーションを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **プレゼンテーションが書き込み保護されているかどうかの確認**

完全な [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成せずにファイルを調べるには、[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) を呼び出し、[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/iswriteprotected/) を確認します。このプロパティは [NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合は `NullableBool.True` を返します。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) のストリームオーバーロードは、ストリームとして提供されたプレゼンテーションに対しても同じ情報を提供します。

## **書き込み保護パスワードの検証**

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkwriteprotection/) を使用して、プレゼンテーション全体を読み込まずに変更パスワードを検証します。まず [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/iswriteprotected/) を確認し、書き込み保護がある場合にのみパスワードの要求または検証を行うようにしてください。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkwriteprotection/) は書き込み保護パスワードのみを検証し、開くためのパスワードや暗号化された内容のロード可否は判断しません。逆に、[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkpassword/) は開くためのパスワードのみを検証します。すでにプレゼンテーション全体がロードされている場合は、[IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/checkwriteprotection/) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証は避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="参照" %}}
- [Password-Protect Presentations](/slides/ja/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/ja/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションの内容は読み込みおよび表示可能なままです。

**書き込み保護パスワードはプレゼンテーションを開くために必要ですか？**

いいえ。暗号化されたプレゼンテーションの内容を読み込むには開くためのパスワードだけが必要です。

**プレゼンテーションに開くためのパスワードと書き込み保護パスワードの両方を設定できますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションで開くためのパスワードを指定し、変更権限が必要なときに書き込み保護パスワードを別途検証してください。