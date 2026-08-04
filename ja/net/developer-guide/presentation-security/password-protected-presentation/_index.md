---
title: ".NET でパスワードを使用したプレゼンテーションの保護"
linktitle: "パスワード保護"
type: docs
weight: 20
url: /ja/net/password-protected-presentation/
keywords:
- "PowerPoint をロック"
- "プレゼンテーションをロック"
- "PowerPoint のロック解除"
- "プレゼンテーションのロック解除"
- "PowerPoint を保護"
- "プレゼンテーションを保護"
- "パスワードを設定"
- "パスワードを追加"
- "PowerPoint を暗号化"
- "プレゼンテーションを暗号化"
- "PowerPoint を復号化"
- "プレゼンテーションを復号化"
- "書き込み保護"
- "PowerPoint のセキュリティ"
- "プレゼンテーションのセキュリティ"
- "パスワードを削除"
- "保護を削除"
- "暗号化を削除"
- "パスワードを無効化"
- "保護を無効化"
- "書き込み保護を削除"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET 用 Aspose.Slides で、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロック・アンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。これらの制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対して次のような制限を課すためにパスワードを設定できます。

- **編集**

特定のユーザーだけにプレゼンテーションの編集を許可したい場合、編集制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの要素を変更、編集、コピーすることができなくなります。

ただし、パスワードがなくてもユーザーはドキュメントにアクセスして開くことは可能です。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツ（ハイパーリンク、アニメーション、エフェクト、その他の要素）を閲覧できますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容を表示さえできなくなります。

技術的には、開く制限はプレゼンテーションの編集も防止します。プレゼンテーションを開くことができなければ、編集や変更も行えません。

**注:** 開くことを防止するためにプレゼンテーションにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**

**サポート形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT – Microsoft PowerPoint プレゼンテーション
- ODP – OpenDocument プレゼンテーション
- OTP – OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides では、以下の方法でプレゼンテーションの編集を防止するためにパスワード保護を利用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides では、パスワード保護や暗号化に関する追加タスクを次のように実行できます。

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションの開封
- 暗号化の解除; パスワード保護の無効化
- プレゼンテーションからの書き込み保護の解除
- 暗号化されたプレゼンテーションのプロパティ取得
- 読み込み前にプレゼンテーションがパスワード保護されているか確認
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認

## **プレゼンテーションをパスワードで保護する**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化（またはパスワード保護）するには、[ProtectionManager](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager) の `Encrypt` メソッドを使用してパスワードを設定します。`Encrypt` メソッドにパスワードを渡し、`Save` メソッドで暗号化されたプレゼンテーションを保存します。

以下のサンプルコードは、プレゼンテーションを暗号化する方法を示しています。

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションに書き込み保護を設定する** 

プレゼンテーションに「編集しないでください」というマークを追加できます。これにより、ユーザーに対して変更を加えないよう伝えることができます。

**注:** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーはプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、`SetWriteProtection` メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています。

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、正しいパスワードを渡すことで暗号化されたプレゼンテーションを読み込むことができます。このサンプルコードは、暗号化されたプレゼンテーションを読み込む方法を示しています。

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションで作業します。
}
```

## **プレゼンテーションから暗号化を解除する**

暗号化またはパスワード保護を解除すると、ユーザーは制限なくプレゼンテーションにアクセスまたは編集できるようになります。

暗号化またはパスワード保護を解除するには、[RemoveEncryption](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/methods/removeencryption) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています。

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用して、プレゼンテーションファイルから書き込み保護を解除できます。これにより、ユーザーは自由に編集でき、警告メッセージも表示されません。

書き込み保護は、[RemoveWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/methods/removewriteprotection) メソッドで解除できます。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています。

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しつつも、ユーザーがプロパティにアクセスできる仕組みを提供します。

**注:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もドキュメントプロパティへのアクセスを可能にしたい場合、Aspose.Slides でそれを実現できます。

暗号化されたプレゼンテーションでもプロパティにアクセスできるようにするには、[IProtectionManager](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/) の `EncryptDocumentProperties` プロパティを `false` に設定します。このサンプルコードは、プレゼンテーションを暗号化しつつドキュメントプロパティへのアクセスを提供する方法を示しています。

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみを読み込む**

スライドやその他のコンテンツを読み込まずに暗号化されたプレゼンテーションのメタデータを検査したい場合は、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) オブジェクトを作成し、`OnlyLoadDocumentProperties` を `true` に設定します。このモードでは、Aspose.Slides はパスワードを無視して、公開されているドキュメントプロパティのみを読み込みます。

以下のコード例は、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/documentproperties/) を通じて組み込みおよびカスタムドキュメントプロパティを読み取ります。

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

このワークフローは、プレゼンテーション暗号化時にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。プロパティが暗号化されている場合、`OnlyLoadDocumentProperties` を `true` に設定すると例外がスローされます。暗号化されたドキュメントプロパティにアクセスするか、スライドやその他のコンテンツも含めてプレゼンテーション全体を読み込むには、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) の `Password` に正しい値を指定してください。

## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、正しいパスワードなしでパスワード保護されたプレゼンテーションを読み込む際に発生するエラーや類似の問題を回避できます。

以下の C# コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています。

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、`IsEncrypted` プロパティを使用します。暗号化されていれば `true`、そうでなければ `false` が返ります。

以下のサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています。

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、`IsWriteProtected` プロパティを使用します。書き込み保護されていれば `true`、そうでなければ `false` が返ります。

以下のサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています。

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **プレゼンテーションのパスワード使用を検証する**

特定のパスワードがプレゼンテーションドキュメントの保護に使用されたかどうかを確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

以下のサンプルコードは、パスワードを検証する方法を示しています。

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // パスワードが一致するか確認します。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

プレゼンテーションが指定されたパスワードで暗号化されていれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="関連記事" %}} 
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **オンラインでプレゼンテーションをパスワード保護する**

1. 当社の **Aspose.Slides Lock** ページ (https://products.aspose.app/slides/ja/lock) に移動します。  
1. **Drop or upload your files** をクリックします。  
1. コンピューター上でパスワードで保護したいファイルを選択します。  
1. 編集保護用パスワードと閲覧保護用パスワードを入力します。  
1. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスをオンにします。  
1. **PROTECT NOW.** をクリックします。  
1. **DOWNLOAD NOW.** をクリックします。

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高水準で確保します。

**プレゼンテーションを開こうとしたときに間違ったパスワードを入力した場合はどうなりますか？**

間違ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化のプロセスにより、開く時や保存時に若干のオーバーヘッドが発生する可能性があります。多くの場合、このパフォーマンスへの影響は最小限で、全体的な処理時間に大きな影響はありません。