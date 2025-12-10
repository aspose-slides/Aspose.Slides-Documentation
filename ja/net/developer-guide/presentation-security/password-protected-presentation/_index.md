---
title: .NET でパスワードで保護されたプレゼンテーションを安全にする
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/net/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロックを解除
- プレゼンテーションのロックを解除
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
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、パスワードで保護された PowerPoint および OpenDocument のプレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---

## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を強制するパスワードを設定したことになります。これらの制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションにパスワードを設定してこれらの制限を強制できます：
- **変更**
  
  特定のユーザーだけにプレゼンテーションの変更を許可したい場合は、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーション内の要素を変更したり、コピーしたりできなくなります。

  しかし、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツ（ハイパーリンク、アニメーション、エフェクト、その他の要素を含む）を見ることはできますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。
- **開く**
  
  特定のユーザーだけにプレゼンテーションを開かせたい場合は、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容さえ閲覧できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けなければ、変更や編集もできません。

**Note:** プレゼンテーションの開封を防止するためにパスワード保護を行うと、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**

**サポートされている形式**

Aspose.Slides は、以下の形式のプレゼンテーションに対してパスワード保護、暗号化、および類似の操作をサポートします。

- PPTX と PPT – Microsoft PowerPoint プレゼンテーション
- ODP – OpenDocument プレゼンテーション
- OTP – OpenDocument プレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slides は、プレゼンテーションにパスワード保護を使用して変更を防止できる方法を以下に示します。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、パスワード保護と暗号化に関する追加タスクを以下の方法で実行できます。

- プレゼンテーションの復号化；暗号化されたプレゼンテーションの開封
- 暗号化の削除；パスワード保護の無効化
- プレゼンテーションから書き込み保護を除去
- 暗号化されたプレゼンテーションのプロパティ取得
- 読み込み前にプレゼンテーションがパスワード保護されているか確認
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認

## **プレゼンテーションをパスワードで保護する**

パスワードを設定してプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化（またはパスワード保護）するには、[ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) の `Encrypt` メソッドを使用してパスワードを設定します。パスワードを `Encrypt` メソッドに渡し、その後 `Save` メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **プレゼンテーションに書き込み保護を設定する**

プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーにプレゼンテーションを変更しないよう伝えることができます。

**Note:** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは（望む場合）プレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、`SetWriteProtection` メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、正しいパスワードを渡すことで暗号化されたプレゼンテーションを読み込むことができます。このサンプルコードは、暗号化されたプレゼンテーションを読み込む方法を示しています:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションを操作します。
}
```


## **プレゼンテーションから暗号化を削除する**

プレゼンテーションから暗号化またはパスワード保護を削除でき、ユーザーは制限なくアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を削除する方法を示しています:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **プレゼンテーションから書き込み保護を削除する**

Aspose.Slides を使用してプレゼンテーションファイルから書き込み保護を削除できます。これにより、ユーザーは好きなように変更でき、変更時に警告が表示されません。

書き込み保護は、[RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) メソッドで削除できます。このサンプルコードは、プレゼンテーションから書き込み保護を削除する方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。ただし、Aspose.Slides は、プレゼンテーションをパスワード保護しながらも、ユーザーがそのプロパティにアクセスできる仕組みを提供します。

**Note:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もドキュメントプロパティにアクセスできるようにしたい場合は、Aspose.Slides はそれを実現できます。

暗号化されたプレゼンテーションのプロパティにアクセスできるようにしたい場合は、[EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) プロパティを `true` に設定できます。このサンプルコードは、プレゼンテーションを暗号化しつつ、ユーザーがドキュメントプロパティにアクセスできるようにする方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションを正しいパスワードなしで読み込む際のエラーや問題を回避できます。

この C# コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているか調べる方法を示しています:
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides を使用して、プレゼンテーションが暗号化されているか確認できます。このタスクを実行するには、[IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) プロパティを使用します。このプロパティは、プレゼンテーションが暗号化されている場合は `true`、そうでない場合は `false` を返します。

このサンプルコードは、プレゼンテーションが暗号化されているか確認する方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides を使用して、プレゼンテーションが書き込み保護されているか確認できます。このタスクを実行するには、[IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) プロパティを使用します。このプロパティは、プレゼンテーションが書き込み保護されている場合は `true`、そうでない場合は `false` を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているか確認する方法を示しています:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **プレゼンテーションのパスワード使用を検証する**

特定のパスワードがプレゼンテーションドキュメントの保護に使用されたか確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています:
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // パスワードが一致するかチェックします。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


指定されたパスワードでプレゼンテーションが暗号化されている場合は `true` を返し、そうでない場合は `false` を返します。

{{% alert color="primary" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **オンラインでプレゼンテーションをパスワード保護する**

1. 当社の [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) ページに移動します。 
2. **Drop or upload your files** をクリックします。 
3. パスワードで保護したいファイルをコンピューターから選択します。 
4. 編集保護用と閲覧保護用の好みのパスワードを入力します。 
5. ユーザーに最終版としてプレゼンテーションを表示させたい場合は、**Mark as final** チェックボックスにチェックを入れます。 
6. **PROTECT NOW.** をクリックします。 
7. **DOWNLOAD NOW.** をクリックします。

![PowerPoint プレゼンテーションのパスワード保護](slides-lock.png)

## **よくある質問**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は、AES ベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開封や保存時にわずかなオーバーヘッドが発生する可能性がありますが、ほとんどの場合、その影響は最小限であり、プレゼンテーションの処理時間全体に大きな影響はありません。