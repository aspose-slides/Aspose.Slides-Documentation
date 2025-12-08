---
title: C# を使用してパスワードで PowerPoint プレゼンテーションを保護
linktitle: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /ja/net/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロック解除
- プレゼンテーションのロック解除
- PowerPoint を保護
- プレゼンテーションを保護
- パスワードを設定
- パスワードを追加
- PowerPoint を暗号化
- プレゼンテーションを暗号化
- PowerPoint を復号化
- プレゼンテーションを復号化
- 書き込み保護
- PowerPoint のセキュリティ
- プレゼンテーションのセキュリティ
- パスワードを削除
- 保護を削除
- 暗号化を削除
- パスワードを無効化
- 保護を無効化
- 書き込み保護を削除
- PowerPoint プレゼンテーション
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。生産性を向上させ、ステップバイステップガイドでプレゼンテーションを安全に保護できます。"
---

## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。これらの制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して次のような制限を課すためにパスワードを設定できます。

- **変更**

特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーション内の要素を変更、編集、コピーすることができなくなります。

ただし、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはハイパーリンク、アニメーション、エフェクト、その他の要素を含む内容を閲覧できますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容を閲覧すらできなくなります。

技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けなければ、変更や編集もできないからです。

**注:** 開くことを防止するためにパスワードでプレゼンテーションを保護すると、ファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**

**サポート形式**

Aspose.Slides は、以下の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT – Microsoft PowerPoint プレゼンテーション
- ODP – OpenDocument プレゼンテーション
- OTP – OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、パスワード保護と暗号化に関する追加タスクを次の方法で実行できます。

- プレゼンテーションの復号化、暗号化されたプレゼンテーションの開封
- 暗号化の解除、パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- 読み込み前にプレゼンテーションがパスワード保護されているかの確認
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **パスワードでプレゼンテーションを保護する**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーがパスワードを提供する必要があります。

プレゼンテーションを暗号化（またはパスワード保護）するには、[ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) の `Encrypt` メソッドを使用してパスワードを設定します。`Encrypt` メソッドにパスワードを渡し、`Save` メソッドで暗号化されたプレゼンテーションを保存します。

以下のサンプルコードは、プレゼンテーションを暗号化する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **プレゼンテーションに書き込み保護を設定する**

プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーに対してプレゼンテーションの変更を望まない旨を伝えます。

**注:** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには、`SetWriteProtection` メソッドを使用します。以下のサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **暗号化されたプレゼンテーションを読み込む**

Aspose.Slides は、正しいパスワードを渡すことで暗号化されたプレゼンテーションを読み込むことができます。以下のサンプルコードは、暗号化されたプレゼンテーションを読み込む方法を示しています：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションで作業します。
}
```


## **プレゼンテーションから暗号化を解除する**

暗号化またはパスワード保護を解除すれば、ユーザーは制限なくアクセスまたは変更できるようになります。

暗号化またはパスワード保護を解除するには、[RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) メソッドを呼び出します。以下のサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用してプレゼンテーションファイルから書き込み保護を解除できます。これにより、ユーザーは自由に変更でき、警告メッセージも表示されません。

書き込み保護は、[RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) メソッドで解除できます。以下のサンプルコードは、書き込み保護を解除する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **暗号化されたプレゼンテーションのプロパティ取得**

暗号化またはパスワードで保護されたプレゼンテーションのドキュメントプロパティ取得に苦労することがありますが、Aspose.Slides はパスワード保護されたままプロパティにアクセスできる仕組みを提供します。

**注:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、ドキュメントプロパティもパスワード保護されます。暗号化後もプロパティにアクセスできるようにしたい場合は、Aspose.Slides がそれを可能にします。

暗号化されたプレゼンテーションでもプロパティへのアクセスを許可したい場合は、[EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) プロパティを `true` に設定します。以下のサンプルコードは、プレゼンテーションを暗号化しつつドキュメントプロパティへのアクセスを提供する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションを正しいパスワードなしで読み込んだ際のエラーや問題を回避できます。

この C# コードは、実際に読み込まずにプレゼンテーションがパスワード保護されているかどうかを調べる方法を示しています：
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides では、プレゼンテーションが暗号化されているかを確認できます。このタスクは、[IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) プロパティを使用して実行でき、暗号化されていれば `true`、そうでなければ `false` が返ります。

以下のサンプルコードは、プレゼンテーションが暗号化されているかを確認する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides では、プレゼンテーションが書き込み保護されているかを確認できます。このタスクは、[IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) プロパティを使用して実行でき、書き込み保護されていれば `true`、そうでなければ `false` が返ります。

以下のサンプルコードは、プレゼンテーションが書き込み保護されているかを確認する方法を示しています：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **プレゼンテーションのパスワード使用状況を検証する**

特定のパスワードがプレゼンテーションの保護に使用されたかどうかを確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

以下のサンプルコードは、パスワードを検証する方法を示しています：
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // パスワードが一致するか確認します。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


指定したパスワードで暗号化されていれば `true`、それ以外の場合は `false` が返ります。

{{% alert color="primary" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **オンラインでプレゼンテーションをパスワード保護する**

1. 当社の **[Aspose.Slides ロック]**(https://products.aspose.app/slides/lock) ページに移動します。  
2. **Drop or upload your files** をクリックします。  
3. コンピューター上でパスワード保護したいファイルを選択します。  
4. 編集保護用と閲覧保護用のそれぞれの好みのパスワードを入力します。  
5. プレゼンテーションを最終版として表示させたい場合は **Mark as final** チェックボックスにチェックを入れます。  
6. **PROTECT NOW.** をクリックします。  
7. **DOWNLOAD NOW.** をクリックします。

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムを含む最新の暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高いレベルで保護します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用された場合は例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツを保護します。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化プロセスにより、開く時や保存時にわずかなオーバーヘッドが発生することがあります。ほとんどの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響はありません。