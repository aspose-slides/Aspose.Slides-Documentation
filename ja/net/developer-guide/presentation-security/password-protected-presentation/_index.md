---
title: パスワード保護プレゼンテーション
type: docs
weight: 20
url: /net/password-protected-presentation/
keywords: "PowerPointのロック, PowerPointの解除, PowerPointの保護, パスワード設定, パスワード追加, PowerPointの暗号化, PowerPointの復号, 書き込み保護, PowerPointのセキュリティ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointのパスワード保護、暗号化、セキュリティ"

---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を施すとは、プレゼンテーションに特定の制限を適用するパスワードを設定することを意味します。制限を解除するには、パスワードを入力する必要があります。パスワード保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、次の制限をプレゼンテーションに適用するためにパスワードを設定できます：

- **変更**

  特定のユーザーのみがプレゼンテーションを変更できるようにしたい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、他の人はプレゼンテーション内の内容を変更、変更、またはコピーすることができません。

  ただし、この場合、パスワードなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内の内容やハイパーリンク、アニメーション、効果などを表示できますが、アイテムをコピーしたり、プレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーのみがプレゼンテーションを開けるようにしたい場合、開く制限を設定できます。この制限により、他の人はパスワードを提供しない限り、プレゼンテーションの内容を表示することすらできません。

  技術的には、開く制限はユーザーがプレゼンテーションを変更できないようにもします：人々がプレゼンテーションを開くことができないとき、彼らはそれを変更したり修正したりすることができません。

  **注意** プレゼンテーションを開けないようにするためにパスワード保護を施すと、プレゼンテーションファイルは暗号化されます。

## オンラインでプレゼンテーションにパスワード保護を施す方法

1. [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。 

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード**をクリックします。

3. パスワード保護したいファイルをコンピューターで選択します。 

4. 編集保護用に希望するパスワードを入力し、表示保護用に希望するパスワードを入力します。 

5. 最終版としてプレゼンテーションを表示させたい場合は、**最終版としてマーク**のチェックボックスをオンにします。

6. **保護する**をクリックします。 

7. **今すぐダウンロード**をクリックします。

### **Aspose.Slidesにおけるプレゼンテーションのパスワード保護**
**サポートされているフォーマット**

Aspose.Slidesは、以下のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、同様の操作をサポートしています： 

- PPTXおよびPPT - Microsoft PowerPointプレゼンテーション 
- ODP - OpenDocumentプレゼンテーション 
- OTP - OpenDocumentプレゼンテーションテンプレート 

**サポートされている操作**

Aspose.Slidesでは、以下の方法で変更を防止するためにプレゼンテーションにパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションに書き込み保護を設定

**その他の操作**

Aspose.Slidesでは、パスワード保護と暗号化に関する他のタスクを以下の方法で実行できます：

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションを開く
- 暗号化の削除; パスワード保護の無効化
- プレゼンテーションから書き込み保護の削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションを読み込む前にパスワード保護されているか確認
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認。

## プレゼンテーションの暗号化

プレゼンテーションにパスワードを設定することで暗号化できます。その後、ロックされたプレゼンテーションを変更するためにはユーザーがパスワードを提供する必要があります。 

プレゼンテーションを暗号化するには、`encrypt`メソッドを使用してプレゼンテーションにパスワードを設定する必要があります（[ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager)から）。パスワードを`encrypt`メソッドに渡し、`save`メソッドを使用して今や暗号化されたプレゼンテーションを保存します。

以下は、プレゼンテーションを暗号化する方法を示すサンプルコードです：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## プレゼンテーションへの書き込み保護の設定 

「変更しないでください」と記載されたマークをプレゼンテーションに追加できます。この方法で、ユーザーにプレゼンテーションに変更を加えたくないことを伝えることができます。

**注意** 書き込み保護プロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に望む場合にプレゼンテーションを変更できますが、変更を保存するには異なる名前のプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、`setWriteProtection`メソッドを使用する必要があります。以下は、プレゼンテーションに書き込み保護を設定する方法を示すサンプルコードです：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## プレゼンテーションの復号化; 暗号化されたプレゼンテーションのオープン

Aspose.Slidesでは、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、[RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption)メソッドをパラメータなしで呼び出す必要があります。次に、プレゼンテーションを読み込むには正しいパスワードを入力する必要があります。 

このサンプルコードは、プレゼンテーションを復号化する方法を示します： 

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
  // 復号化されたプレゼンテーションで作業
}
```

## 暗号化の削除; パスワード保護の無効化

プレゼンテーションの暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption)メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号化を削除する方法を示します：

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## プレゼンテーションからの書き込み保護の削除

Aspose.Slidesを使用すると、プレゼンテーションファイルに使用されている書き込み保護を削除できます。これにより、ユーザーは自由に変更でき、警告なしでその作業を実行できます。

[RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection)メソッドを使用してプレゼンテーションから書き込み保護を削除できます。このサンプルコードは、プレゼンテーションから書き込み保護を削除する方法を示します：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## 暗号化されたプレゼンテーションのプロパティ取得

通常、ユーザーは暗号化されたまたはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションのプロパティにアクセスする手段を保持しつつ、プレゼンテーションにパスワード保護を施すメカニズムを提供します。

**注意** Aspose.Slidesがプレゼンテーションを暗号化する際、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。しかし、プレゼンテーションのプロパティをアクセス可能にしたい場合（たとえプレゼンテーションが暗号化されても）、Aspose.Slidesはそれを正確に実行できるようにします。

ユーザーが暗号化されたプレゼンテーションのプロパティにアクセスできる能力を保持させたい場合、[EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties)プロパティを`true`に設定できます。このサンプルコードは、ユーザーがドキュメントプロパティにアクセスできるようにしながらプレゼンテーションを暗号化する方法を示します：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **プレゼンテーションを読み込む前にパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、そのプレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションがパスワードなしで読み込まれた場合に発生するエラーや問題を避けることができます。

このC#コードは、プレゼンテーションがパスワード保護されているかどうかを調べる方法を示しています（プレゼンテーション自体を読み込むことなしに）：

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("プレゼンテーションはパスワードで保護されていますか: " + presentationInfo.IsPasswordProtected);
```

## プレゼンテーションが暗号化されているか確認する

Aspose.Slidesでは、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、[IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted)プロパティを使用できます。このプロパティは、プレゼンテーションが暗号化されている場合は`true`を返し、暗号化されていない場合は`false`を返します。

以下のサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示します：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## プレゼンテーションが書き込み保護されているか確認する

Aspose.Slidesは、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、[IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected)プロパティを使用できます。このプロパティは、プレゼンテーションが書き込み保護されている場合は`true`を返し、書き込み保護されていない場合は`false`を返します。

以下のサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示します：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **特定のパスワードがプレゼンテーションを保護するために使用されたことを検証または確認する**

プレゼンテーションドキュメントを保護するために特定のパスワードが使用されたかどうかを確認したい場合があります。Aspose.Slidesは、パスワードを検証する手段を提供しています。

このサンプルコードは、パスワードを検証する方法を示します：

```c#
using (IPresentation pres = new Presentation("pres.pptx"))
{
    // "pass"が一致するかどうか確認
    bool isWriteProtected = pres.ProtectionManager.CheckWriteProtection("my_password");
}
```

指定されたパスワードでプレゼンテーションが暗号化されている場合は`true`を返し、そうでない場合は`false`を返します。 

{{% alert color="primary" title="関連情報" %}} 
- [PowerPointのデジタル署名](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}