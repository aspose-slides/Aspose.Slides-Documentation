---
title: Javaでパスワードを使用したプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
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
- PowerPoint の復号化
- プレゼンテーションの復号化
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、パスワードで保護された PowerPoint および OpenDocument のプレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、次のような制限をプレゼンテーションに設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを入力しない限り、プレゼンテーションの変更、編集、コピーを防止します。

  ただし、この場合でもパスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限は、パスワードを入力しない限り、プレゼンテーションの内容自体を見ることさえできなくします。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けないユーザーは、変更や編集ができません。

  **注意** パスワード保護で開くこと自体を防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用のパスワードと表示保護用のパスワードを入力します。

5. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**
**サポート形式**

Aspose.Slides は次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似操作をサポートします。

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides では、次の方法でパスワード保護や暗号化に関連するその他のタスクを実行できます。

- プレゼンテーションの復号化；暗号化されたプレゼンテーションの開封
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションからの書き込み保護の削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **プレゼンテーションを暗号化する**

パスワードを設定してプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager) の encrypt メソッドを使用してプレゼンテーションにパスワードを設定します。パスワードを encrypt メソッドに渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションの暗号化方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションに書き込み保護を設定する**

プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーに変更を望まない旨を伝えることができます。

**注意** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更することは可能ですが、変更を保存するには別名でプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードはプレゼンテーションへの書き込み保護の設定方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **暗号化されたプレゼンテーションを読み込む**

Aspose.Slides はパスワードを渡すことで暗号化ファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしの [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションを読み込むことになります。

このサンプルコードはプレゼンテーションの復号化方法を示しています:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業
} finally {
    if (presentation != null) presentation.dispose();
}
}
```


## **プレゼンテーションから暗号化を解除する**

プレゼンテーションの暗号化やパスワード保護を解除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスしたり、変更したりできるようになります。

暗号化やパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を解除する方法を示しています:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用してプレゼンテーションファイルに設定された書き込み保護を解除できます。これにより、ユーザーは自由に変更でき、警告も表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。このサンプルコードは書き込み保護の解除方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **暗号化されたプレゼンテーションのプロパティ取得**

通常、暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのは困難です。Aspose.Slides は、プレゼンテーションをパスワード保護しつつ、ユーザーがそのプロパティにアクセスできる仕組みを提供します。

**注意** Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。ただし、暗号化後でもプロパティにアクセスできるようにしたい場合、Aspose.Slides はそれを可能にします。

暗号化されたプレゼンテーションのプロパティへユーザーがアクセスできるようにするには、[encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) プロパティを `true` に設定します。このサンプルコードはプロパティへのアクセスを可能にしつつプレゼンテーションを暗号化する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワード保護されていないか確認したい場合があります。これにより、パスワードがない状態で保護されたプレゼンテーションを読み込んでエラーが発生するのを防げます。

この Java コードはプレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides はプレゼンテーションが暗号化されているかを確認できます。このタスクには、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--) プロパティを使用します。

このサンプルコードはプレゼンテーションが暗号化されているかを確認する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides はプレゼンテーションが書き込み保護されているかを確認できます。このタスクには、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--) プロパティを使用します。

このサンプルコードはプレゼンテーションが書き込み保護されているかを確認する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **特定のパスワードが使用されたか検証または確認する**

プレゼンテーションドキュメントが特定のパスワードで保護されているかを確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

このサンプルコードはパスワードを検証する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 「pass」と一致するか確認
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```


パスワードが一致すれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化のプロセスにより、開く時や保存時に若干のオーバーヘッドが発生することがあります。多くの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響を与えることはありません。