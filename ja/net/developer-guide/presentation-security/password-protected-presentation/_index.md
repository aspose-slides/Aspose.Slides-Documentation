---
title: .NET でプレゼンテーションにパスワード保護を設定する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/net/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- 開くためのパスワード
- PowerPoint の暗号化
- PowerPoint の復号
- プレゼンテーション パスワードの検証
- プレゼンテーション パスワードの確認
- 暗号化されたプレゼンテーションの開封
- 暗号化の解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、C# でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号します。"
---
## **概要**

開くためのパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションの内容を読み込んで表示できるため、この保護は機密性を提供します。

開くためのパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、内容を暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/net/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要となる両形式を使用しています。

## **開くためのパスワードでプレゼンテーションを暗号化する**

開くためのパスワードを割り当てるには [IProtectionManager.Encrypt](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/encrypt/) を使用します。その後、暗号化されたプレゼンテーションを永続化するには [IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) を使用します。

以下の例は PPTX プレゼンテーションを暗号化します:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **ドキュメントプロパティを公開したままにする**

デフォルトでは、Aspose.Slides はプレゼンテーションの暗号化にドキュメントプロパティを含めます。[IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) プロパティは、スライドコンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムが開くためのパスワードなしでメタデータを読み取る必要がある場合は、[IProtectionManager.Encrypt](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/encrypt/) を呼び出す前にこれを `false` に設定します。

以下の例は暗号化された PPTX プレゼンテーションを作成し、組み込みのドキュメントプロパティは公開されたままにします:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

`EncryptDocumentProperties` を `false` に設定しても、スライド、マスタ、レイアウト、シェイプ、メディア、またはその他のプレゼンテーションコンテンツが公開されるわけではありません。ドキュメントプロパティのみに影響します。暗号化されたコンテンツを読み込まずにこれらのプロパティを取得する方法については、[Manage Presentation Properties](/slides/ja/net/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションを読み込む**

開くためのパスワードを設定するには [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) にパスワードを設定し、ファイルを読み込む際にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) に渡します。開くためのパスワードが必要なのに、提供されたパスワードが未指定または誤っている場合、読み込みは失敗します。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 復号されたプレゼンテーションで作業します。
```

## **プレゼンテーションから暗号化を削除する**

プレゼンテーションをその開くためのパスワードで読み込み、[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/removeencryption/) を呼び出してから結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込めるようになります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **読み込む前に開くためのパスワードを検証する**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用して、完全なプレゼンテーション インスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/) を取得します。パスワードを要求または検証する前に、[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/ispasswordprotected/) を確認します。保護が存在する場合は、[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkpassword/) で提供された値を検証します。

### **ファイルパス ワークフロー**

以下の例は PPTX ファイルの開くためのパスワードを検証し、検証済みの値を [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に渡してから、完全なプレゼンテーションを読み込みます:

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

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationfactory/getpresentationinfo/) のストリームオーバーロードは同じワークフローを提供します。完全なプレゼンテーションをそのストリームから読み込む前に、シーク可能なストリームの位置をリセットしてください。

以下の例は PPT ファイルを使用しています:

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/checkpassword/) は、プレゼンテーションに開くためのパスワードが設定され、かつ提供されたパスワードが正しい場合にのみ `true` を返します。次の場合は `false` を返します:

- パスワードが正しくない。
- プレゼンテーションに開くためのパスワードが設定されていない。
- 提供されたパスワードが `null` または空文字列です。

PPT と PPTX のプレゼンテーションでも動作は同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/isencrypted/) を確認して、元のプレゼンテーションが暗号化されていたかどうかを確認します。読み込む前に開くパスワード保護を検出するには、上記と同様に `IPresentationInfo.IsPasswordProtected` を使用します。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
開くためのパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な再検証を避け、パスワードは必要な期間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。

公開されたドキュメントプロパティは、プレゼンテーションの内容が暗号化されていても、著者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値などを漏洩させる可能性があります。機密性の高いメタデータはプレゼンテーションと共に暗号化してください。プロパティを公開したままにすることは、システムが開くためのパスワードなしでファイルをインデックス作成、分類、検索、または管理する必要がある場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護をかける**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択またはアップロードします。
1. 表示保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/net/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**開くためのパスワードと書き込み保護パスワードの違いは何ですか？**

開くためのパスワードはプレゼンテーションを暗号化し、その内容を読み込むために必要です。書き込み保護パスワードは内容を暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開くためのパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開くためのパスワード保護があるか確認し、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証します。

**アプリケーションは開くためのパスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションが `EncryptDocumentProperties` を `false` に設定して暗号化された場合に限ります。その場合、[Manage Presentation Properties](/slides/ja/net/presentation-properties/) で説明されているドキュメントプロパティのみの読み込みモードを使用する必要があります。

**パスワード検証のワークフローは PPT と PPTX の両方をサポートしていますか？**

はい。ファイルパスとストリームベースのパスワード検出および検証は、PPT と PPTX のプレゼンテーションで同様に動作します。