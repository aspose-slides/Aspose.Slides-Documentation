---
title: .NET でプレゼンテーションにパスワード保護を付ける
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/net/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- 開封パスワード
- PowerPoint の暗号化
- PowerPoint の復号化
- プレゼンテーション パスワードの検証
- プレゼンテーション パスワードのチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化の除去
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、C# でパスワードで保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

開封パスワードはプレゼンテーションを暗号化します。正しいパスワードがないとプレゼンテーションの内容を読み込んだり表示したりできないため、この保護は機密性を提供します。

開封パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、内容を暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[プレゼンテーションの書き込み保護](/slides/ja/net/write-protected-presentation/)をご覧ください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要になる場合の両形式を使用しています。

## **開封パスワードでプレゼンテーションを暗号化**

[IProtectionManager.Encrypt](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/encrypt/) を使用して開封パスワードを割り当てます。その後、[IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) を使用して暗号化されたプレゼンテーションを永続化します。

次の例は PPTX プレゼンテーションを暗号化します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **暗号化されたプレゼンテーションの読み込み**

[LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に開封パスワードを設定し、ファイルの読み込み時にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) に渡します。開封パスワードが必要なのに提供されたパスワードが不足または不正確な場合、読み込みは失敗します。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 復号化されたプレゼンテーションで作業します。
```

## **プレゼンテーションから暗号化を解除**

プレゼンテーションを開封パスワードで読み込み、[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/removeencryption/) を呼び出し、結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込むことができます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **読み込み前に開封パスワードを検証**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用して、完全なプレゼンテーションインスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/) を取得します。パスワードの要求または検証を行う前に、[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/ispasswordprotected/) を確認します。保護が存在する場合は、[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkpassword/) で提供された値を検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルの開封パスワードを検証し、検証済みの値を [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に渡して、完全なプレゼンテーションを読み込みます：

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **ストリーム ワークフロー**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) のストリームオーバーロードも同じワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用しています：

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword の戻り値**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkpassword/) は、プレゼンテーションに開封パスワードが設定されており、提供されたパスワードが正しい場合にのみ `true` を返します。以下のいずれかの場合は `false` を返します：

- パスワードが正しくありません。
- プレゼンテーションに開封パスワードが設定されていません。
- 指定されたパスワードが `null` または空です。

PPT と PPTX のプレゼンテーションで動作は同じです。

## **読み込まれたプレゼンテーションが暗号化されているか確認**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/isencrypted/) をチェックして、元のプレゼンテーションが暗号化されていたことを確認します。読み込み前に開封パスワード保護を検出するには、上記と同様に `IPresentationInfo.IsPasswordProtected` を使用します。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **セキュリティの推奨事項**

{{% alert color="warning" title="Security" %}}
開封パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返し検証を避け、パスワードは必要な間だけメモリに保持し、直ちにプレゼンテーションを読み込む場合は検証結果を再利用してください。
{{% /alert %}}

## **オンラインでプレゼンテーションをパスワード保護**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択またはアップロードします。
1. 閲覧保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/net/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**開封パスワードと書き込み保護パスワードの違いは何ですか？**

開封パスワードはプレゼンテーションを暗号化し、内容を読み込むために必要です。書き込み保護パスワードは暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開封パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開封パスワード保護が存在するか確認したうえで、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証できます。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同じように動作します。