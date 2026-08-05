---
title: Javaでパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
keywords:
- PowerPointのロック
- プレゼンテーションのロック
- PowerPointのロック解除
- プレゼンテーションのロック解除
- PowerPointの保護
- プレゼンテーションの保護
- パスワードの設定
- パスワードの追加
- PowerPointの暗号化
- プレゼンテーションの暗号化
- PowerPointの復号化
- プレゼンテーションの復号化
- 書き込み保護
- PowerPointのセキュリティ
- プレゼンテーションのセキュリティ
- パスワードの削除
- 保護の削除
- 暗号化の削除
- パスワードの無効化
- 保護の無効化
- 書き込み保護の削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロック・アンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---
## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して一定の制限を課すパスワードを設定したことになります。これらの制限を解除するには、パスワードを入力する必要があります。パスワード保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対してこれらの制限を課すためにパスワードを設定できます：

- **編集**

特定のユーザーだけにプレゼンテーションの編集を許可したい場合、編集制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーション内の要素を編集、変更、またはコピーすることができません。  

ただし、パスワードがなくてもユーザーはドキュメントにアクセスして開くことは可能です。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツ（ハイパーリンク、アニメーション、エフェクト、その他の要素を含む）を閲覧できますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開封制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容さえ閲覧できなくなります。  

技術的には、開封制限はユーザーがプレゼンテーションを編集できないようにもします。プレゼンテーションを開けなければ、編集や変更を行うことはできません。

**注:** 開封を防止するためにプレゼンテーションにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**
**サポートされている形式**

Aspose.Slides は、これらの形式のプレゼンテーションに対してパスワード保護、暗号化、および類似の操作をサポートします: 

- PPTX and PPT - Microsoft PowerPoint プレゼンテーション 
- ODP - OpenDocument プレゼンテーション 
- OTP - OpenDocument プレゼンテーションテンプレート 

**サポートされている操作**

Aspose.Slides は、以下の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、パスワード保護と暗号化に関するその他のタスクを以下の方法で実行できます：

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションの開封
- 暗号化の除去; パスワード保護の無効化
- プレゼンテーションから書き込み保護を除去
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認。

## **パスワードでプレゼンテーションを保護する**

パスワードを設定することでプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを編集するには、ユーザーがパスワードを提供する必要があります。 

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager) の encrypt メソッドを使用してプレゼンテーションにパスワードを設定します。encrypt メソッドにパスワードを渡し、save メソッドで暗号化されたプレゼンテーションを保存します。 

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています：

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

プレゼンテーションに「編集しないでください」というマークを追加できます。これにより、ユーザーにプレゼンテーションを変更しないよう伝えることができます。  

**注:** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは（本当に望む場合）プレゼンテーションを編集できますが、変更を保存するには別名でプレゼンテーションを作成する必要があります。 

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

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

Aspose.Slides は、パスワードを渡すことで暗号化されたファイルの読み込みを可能にします。プレゼンテーションを復号化するには、パラメーターなしで [removeEncryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションを読み込むことになります。 

このサンプルコードは、プレゼンテーションを復号化する方法を示しています： 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業する
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションから暗号化を除去する**

プレゼンテーションの暗号化またはパスワード保護を除去できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスしたり編集したりできるようになります。 

暗号化またはパスワード保護を除去するには、[removeEncryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号化を除去する方法を示しています。

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

## **プレゼンテーションから書き込み保護を除去する**

Aspose.Slides を使用して、プレゼンテーションファイルに設定された書き込み保護を除去できます。これにより、ユーザーは好きなように編集でき、編集時に警告が表示されなくなります。

プレゼンテーションから書き込み保護を除去するには、[removeWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を除去する方法を示しています：

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

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティの取得に苦労します。ただし、Aspose.Slides は、プレゼンテーションにパスワード保護を設定しつつ、ユーザーがプロパティにアクセスできる仕組みを提供します。  

**注:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もドキュメントプロパティにアクセスできるようにしたい場合、Aspose.Slides はそれを可能にします。  

暗号化されたプレゼンテーションのプロパティにユーザーがアクセスできるようにしたい場合は、[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡します。このサンプルコードは、プレゼンテーションを暗号化しつつ、ユーザーがドキュメントプロパティにアクセスできる方法を示しています：

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

暗号化されたプレゼンテーションのスライドやその他のコンテンツを読み込まずにメタデータを確認するには、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) オブジェクトを作成し、[setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) に `true` を渡します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティのみを読み込みます。  

以下のコード例は、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDocumentProperties--) を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 組み込みドキュメントプロパティを読み取る。
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // カスタムドキュメントプロパティを読み取る。
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

このワークフローは、プレゼンテーションが暗号化された際にドキュメントプロパティが暗号化されていない（公開）場合にのみ動作します。ドキュメントプロパティが暗号化されている場合、`loadOptions.setOnlyLoadDocumentProperties` に `true` を渡すと、パスワードが無視されるため例外が発生します。暗号化されたドキュメントプロパティにアクセスするか、スライドやその他のコンテンツを含む完全なプレゼンテーションを読み込むには、[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) を使用して正しいパスワードを提供してください。

## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだ際に発生するエラーや類似の問題を回避できます。  

この Java コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認できます。この作業には、プレゼンテーションが暗号化されている場合は `true`、されていない場合は `false` を返す [isEncrypted](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#isEncrypted--) プロパティを使用します。  

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。この作業には、プレゼンテーションが書き込み保護されている場合は `true`、されていない場合は `false` を返す [isWriteProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#isWriteProtected--) プロパティを使用します。  

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードが使用されたか検証または確認する**

特定のパスワードがプレゼンテーションドキュメントの保護に使用されたかを確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。  

このサンプルコードは、パスワードを検証する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" が一致するか確認する
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

指定したパスワードでプレゼンテーションが暗号化されている場合は `true` を返し、そうでない場合は `false` を返します。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は、AES ベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより、未許可のアクセスを防止し、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際にパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開く際や保存する際に若干のオーバーヘッドが生じる可能性があります。ほとんどの場合、このパフォーマンスへの影響は最小限で、プレゼンテーションの処理全体の時間に大きな影響はありません。