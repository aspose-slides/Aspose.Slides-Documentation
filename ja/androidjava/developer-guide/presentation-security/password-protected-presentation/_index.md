---
title: Androidでのパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/androidjava/password-protected-presentation/
keywords:
- PowerPointをロック
- プレゼンテーションをロック
- PowerPointのロック解除
- プレゼンテーションのロック解除
- PowerPointを保護
- プレゼンテーションを保護
- パスワード設定
- パスワード追加
- PowerPointを暗号化
- プレゼンテーションを暗号化
- PowerPointを復号化
- プレゼンテーションを復号化
- 書き込み保護
- PowerPointセキュリティ
- プレゼンテーションセキュリティ
- パスワード削除
- 保護解除
- 暗号化解除
- パスワード無効化
- 保護無効化
- 書き込み保護解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android（Java）を使用して、パスワードで保護されたPowerPointおよびOpenDocumentプレゼンテーションを簡単にロック・解除できます。プレゼンテーションを安全に保護しましょう。"
---
## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対してこれらの制限を課すためにパスワードを設定できます：

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合は、変更制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの変更、編集、コピーができなくなります。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合は、開く制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの内容さえ表示できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けないユーザーは、変更や編集を行うことができません。

  **注** パスワードでプレゼンテーションを保護して開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のプレゼンテーション パスワード保護**
**サポート形式**

Aspose.Slides は以下の形式のプレゼンテーションに対して、パスワード保護、暗号化、同様の操作をサポートします：

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーション テンプレート

**サポート操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides では、以下の方法でパスワード保護と暗号化に関するその他のタスクを実行できます：

- プレゼンテーションの復号化；暗号化されたプレゼンテーションのオープン
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager) の `encrypt` メソッドを使用してパスワードを設定し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションの暗号化方法を示しています：

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

プレゼンテーションに「変更しないでください」というマークを追加できます。この方法で、ユーザーに対してプレゼンテーションの変更を希望しない旨を伝えることができます。

**注** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に変更を加えることは可能ですが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードは書き込み保護の設定方法を示しています：

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

Aspose.Slides はパスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしの [removeEncryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出し、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードはプレゼンテーションの復号化方法を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションからの暗号化解除**

プレゼンテーションから暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[removeEncryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を削除する方法を示しています：

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

## **プレゼンテーションからの書き込み保護の削除**

Aspose.Slides を使用してプレゼンテーションファイルに設定された書き込み保護を削除できます。これにより、ユーザーは自由に変更でき、警告メッセージも表示されません。

書き込み保護を削除するには、[removeWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。このサンプルコードは書き込み保護の削除方法を示しています：

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

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティの取得に苦労します。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しながらも、ユーザーがプロパティにアクセスできるメカニズムを提供します。

**注** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もプロパティにアクセスできるようにしたい場合は、[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡します。このサンプルコードは、プロパティへのアクセスを可能にしながらプレゼンテーションを暗号化する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみを読み込む**

スライドやその他のコンテンツを読み込まずに暗号化されたプレゼンテーションのメタデータを調査するには、[LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) オブジェクトを作成し、`true` を [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) に渡します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティのみを読み込みます。

次のコード例は、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 組み込みのドキュメントプロパティを読み取ります。
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // カスタムドキュメントプロパティを読み取ります。
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

このワークフローは、暗号化時にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。プロパティが暗号化されている場合、`loadOptions.setOnlyLoadDocumentProperties` に `true` を渡すと例外がスローされます。暗号化されたプロパティにアクセスするか、スライドやその他のコンテンツを含むプレゼンテーション全体を読み込むには、[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) で正しいパスワードを提供してください。

## **プレゼンテーションがパスワード保護されているかの確認**

プレゼンテーションを読み込む前に、パスワードで保護されていないかを確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだときに発生するエラーや問題を回避できます。

この Java コードは、プレゼンテーション自体を読み込まずにパスワード保護されているかどうかを調べる方法を示しています：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているかの確認**

Aspose.Slides はプレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、`isEncrypted` プロパティを使用します。暗号化されていれば `true`、されていなければ `false` が返ります。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているかの確認**

Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、`isWriteProtected` プロパティを使用します。書き込み保護されていれば `true`、されていなければ `false` が返ります。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードが使用されたかの検証または確認**

プレゼンテーションが特定のパスワードで保護されているかどうかをチェックしたい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" が一致するかチェック
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

パスワードが一致すれば `true`、一致しなければ `false` が返されます。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高レベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツを保護します。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化・復号化のプロセスにより、開閉時に若干のオーバーヘッドが発生する可能性があります。ほとんどの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな差は生じません。