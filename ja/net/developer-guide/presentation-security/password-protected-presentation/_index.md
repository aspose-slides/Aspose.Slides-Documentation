---
title: .NET でパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
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
- PowerPoint を復号
- プレゼンテーションを復号
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
description: "Aspose.Slides for .NET を使用して、パスワードで保護された PowerPoint および OpenDocument のプレゼンテーションを簡単にロックおよびアンロックする方法を学び、プレゼンテーションを安全に保護しましょう。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。これらの制限を解除するには、パスワードの入力が必要です。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対してこれらの制限を適用するためにパスワードを設定できます。

- **Modification**
  
  特定のユーザーだけにプレゼンテーションの変更を許可したい場合は、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーション内の要素の変更、編集、コピーができなくなります。  
  ただし、パスワードがなくてもユーザーはドキュメントにアクセスして開くことは可能です。この読み取り専用モードでは、プレゼンテーション内のコンテンツ（ハイパーリンク、アニメーション、エフェクト、その他の要素）を閲覧できますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **Opening**
  
  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合は、開封制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容を閲覧すらできなくなります。  
  技術的には、開封制限はユーザーがプレゼンテーションを変更できなくする効果もあります。プレゼンテーションを開けなければ、変更や編集はできません。

**注:** 開封を防ぐためにプレゼンテーションにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**

**サポートされている形式**

Aspose.Slides は以下の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX と PPT – Microsoft PowerPoint プレゼンテーション
- ODP – OpenDocument プレゼンテーション
- OTP – OpenDocument プレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slides は次の方法でプレゼンテーションの変更を防止するパスワード保護を利用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は次の方法でパスワード保護や暗号化に関わる追加タスクを実行できます。

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションのオープン
- 暗号化の解除; パスワード保護の無効化
- プレゼンテーションから書き込み保護を解除
- 暗号化されたプレゼンテーションのプロパティ取得
- ロード前にプレゼンテーションがパスワード保護されているか確認
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認

## **パスワードでプレゼンテーションを保護する**

パスワードを設定することでプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを編集するには、ユーザーはパスワードを入力する必要があります。

プレゼンテーションを暗号化（またはパスワード保護）するには、[ProtectionManager](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager) の `Encrypt` メソッドを使用してパスワードを設定します。`Encrypt` メソッドにパスワードを渡し、その後 `Save` メソッドで暗号化されたプレゼンテーションを保存します。

以下のサンプルコードは、プレゼンテーションを暗号化する方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションに書き込み保護を設定する** 

プレゼンテーションに「変更禁止」のマークを追加できます。これにより、ユーザーに対してプレゼンテーションを変更しないよう通知します。

**注:** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは（選択すれば）プレゼンテーションを変更できますが、変更を保存する場合は別名で保存する必要があります。

書き込み保護を設定するには、`SetWriteProtection` メソッドを使用します。以下のサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **暗号化されたプレゼンテーションのロード**

Aspose.Slides では、正しいパスワードを渡すことで暗号化されたプレゼンテーションをロードできます。以下のサンプルコードは、暗号化されたプレゼンテーションをロードする方法を示します。

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションで作業します。
}
```

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションから暗号化やパスワード保護を解除でき、ユーザーは制限なくアクセスまたは編集できるようになります。

暗号化またはパスワード保護を解除するには、[RemoveEncryption](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/methods/removeencryption) メソッドを呼び出します。以下のサンプルコードは、プレゼンテーションから暗号化を解除する方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用して、プレゼンテーションファイルから書き込み保護を解除できます。これにより、ユーザーは自由に編集でき、編集時に警告が表示されなくなります。

書き込み保護は、[RemoveWriteProtection](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/methods/removewriteprotection) メソッドで解除できます。以下のサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのが困難です。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しつつ、ユーザーがプロパティにアクセスできる仕組みを提供します。

**注:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、ドキュメントプロパティもパスワード保護されます。暗号化後もプロパティにアクセスできるようにしたい場合、Aspose.Slides はその機能を提供します。

暗号化されたプレゼンテーションのプロパティにユーザーがアクセスできるようにするには、[IProtectionManager](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/) の `EncryptDocumentProperties` プロパティを `false` に設定します。以下のサンプルコードは、暗号化しつつドキュメントプロパティへのアクセスを許可する方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみをロードする**

スライドや他のコンテンツをロードせずに暗号化されたプレゼンテーションのメタデータを確認するには、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) オブジェクトを作成し、[OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) を `true` に設定します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティのみをロードします。

以下のコード例は、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/documentproperties/) を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります。

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// 組み込みドキュメントプロパティを読み取ります。
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// カスタムドキュメントプロパティを読み取ります。
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

このワークフローは、プレゼンテーションが暗号化された際にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。プロパティが暗号化されている場合、`OnlyLoadDocumentProperties` を `true` に設定すると例外が発生します（このモードではパスワードが無視されるため）。暗号化されたプロパティにアクセスするか、スライドやその他のコンテンツを含むプレゼンテーション全体をロードするには、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) の `Password` に正しい値を指定してください。

## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションをロードする前に、パスワードで保護されていないか確認したい場合があります。これにより、正しいパスワードなしでパスワード保護されたプレゼンテーションをロードした際に発生するエラーや問題を回避できます。

以下の C# コードは、実際にロードせずにプレゼンテーションがパスワード保護されているかどうかを調べる方法を示します。

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides を使用すると、プレゼンテーションが暗号化されているかどうかを確認できます。この操作には、暗号化されていれば `true`、そうでなければ `false` を返す [IsEncrypted](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/properties/isencrypted) プロパティを利用します。

以下のサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示します。

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides では、プレゼンテーションが書き込み保護されているかどうかを確認できます。この操作には、書き込み保護されていれば `true`、そうでなければ `false` を返す [IsWriteProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/properties/iswriteprotected) プロパティを使用します。

以下のサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示します。

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **プレゼンテーションのパスワード使用を検証する**

特定のパスワードがプレゼンテーションドキュメントの保護に使用されたか確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

以下のサンプルコードは、パスワードを検証する方法を示します。

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // パスワードが一致するか確認します。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

指定したパスワードでプレゼンテーションが暗号化されていれば `true`、それ以外の場合は `false` を返します。

{{% alert color="info" title="関連項目" %}} 
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **オンラインでプレゼンテーションをパスワード保護する**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/ja/lock)ページに移動します。 
2. **Drop or upload your files** をクリックします。 
3. パスワードで保護したいファイルをコンピューターから選択します。 
4. 編集保護用および閲覧保護用に希望のパスワードを入力します。 
5. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスにチェックを入れます。 
6. **PROTECT NOW.** をクリックします。 
7. **DOWNLOAD NOW.** をクリックします。

![PowerPoint プレゼンテーションのパスワード保護](slides-lock.png)

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開こうとした際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号の処理により、開く時や保存時に若干のオーバーヘッドが生じる可能性があります。多くの場合、このパフォーマンスへの影響は最小限で、プレゼンテーション処理全体の時間に大きな影響はありません。