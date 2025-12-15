---
title: Android でパスワードを使用したプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/androidjava/password-protected-presentation/
keywords:
- PowerPoint のロック
- プレゼンテーションのロック
- PowerPoint のロック解除
- プレゼンテーションのロック解除
- PowerPoint の保護
- プレゼンテーションの保護
- パスワードの設定
- パスワードの追加
- PowerPoint の暗号化
- プレゼンテーションの暗号化
- PowerPoint の復号化
- プレゼンテーションの復号化
- 書き込み保護
- PowerPoint のセキュリティ
- プレゼンテーションのセキュリティ
- パスワードの削除
- 保護の解除
- 暗号化の解除
- パスワードの無効化
- 保護の無効化
- 書き込み保護の解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java 経由で Android 用 Aspose.Slides を使用し、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックできます。プレゼンテーションを保護しましょう。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに特定の制限を課すパスワードが設定されます。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して次のような制限を設定するためにパスワードを設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの変更、編集、コピーができなくなります。

  ただし、この場合でもパスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、アイテムのコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの内容すら閲覧できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。ユーザーがプレゼンテーションを開けなければ、変更や編集もできません。

  **注** パスワードで保護して開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用の希望パスワードと閲覧保護用の希望パスワードを入力します。

5. ユーザーに最終版としてプレゼンテーションを表示させたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides のプレゼンテーション パスワード保護**
**サポートされている形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX と PPT – Microsoft PowerPoint プレゼンテーション
- ODP – OpenDocument プレゼンテーション
- OTP – OpenDocument プレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides では、次の方法でパスワード保護や暗号化に関するその他のタスクを実行できます。

- プレゼンテーションの復号化、暗号化されたプレゼンテーションの開封
- 暗号化の解除、パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかのチェック
- プレゼンテーションがパスワード保護されているかのチェック

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを入力しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager) の encrypt メソッドを使用してパスワードを設定します。encrypt メソッドにパスワードを渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションへの書き込み保護の設定**

「変更しないでください」というマークをプレゼンテーションに追加できます。これにより、ユーザーに対してプレゼンテーションを変更しないよう通知できます。

**注** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしの [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業する
} finally {
    if (presentation != null) presentation.dispose();
}
}
```


## **プレゼンテーションから暗号化を解除する**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています:
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

Aspose.Slides を使用して、プレゼンテーションファイルに設定された書き込み保護を解除できます。これにより、ユーザーは好きなように変更でき、警告も表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています:
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

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのが難しいと感じますが、Aspose.Slides はパスワード保護されたプレゼンテーションでもプロパティにアクセスできる仕組みを提供します。

**注** Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後でもプロパティにアクセスできるようにしたい場合、Aspose.Slides でそれが可能です。

暗号化したプレゼンテーションのプロパティへのアクセスを許可したい場合は、[encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) プロパティを `true` に設定します。このサンプルコードは、プレゼンテーションを暗号化しつつ、ユーザーがドキュメントプロパティにアクセスできるようにする方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションがパスワード保護されているかの確認**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだ際に発生するエラーや問題を回避できます。

この Java コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **プレゼンテーションが暗号化されているかの確認**

Aspose.Slides では、プレゼンテーションが暗号化されているかどうかを確認できます。この操作には、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) プロパティを使用します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **プレゼンテーションが書き込み保護されているかの確認**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。この操作には、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) プロパティを使用します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **特定のパスワードが使用されたかの検証または確認**

プレゼンテーションを保護するために特定のパスワードが使用されたかどうかを確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています:
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" が一致するかチェック
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```


パスワードが正しければ `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムなど、最新の暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に間違ったパスワードを入力するとどうなりますか？**

間違ったパスワードが使用された場合、例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化のプロセスにより、開く・保存する際にわずかなオーバーヘッドが発生することがあります。ほとんどの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響はありません。