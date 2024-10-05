---
title: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /androidjava/password-protected-presentation/
keywords: "JavaでのPowerPointプレゼンテーションのロック"
description: "PowerPointプレゼンテーションをロックします。Javaでのパスワード保護されたPowerPoint"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションをパスワードで保護すると、プレゼンテーションに対する特定の制限を強制するパスワードを設定することを意味します。制限を解除するには、パスワードを入力する必要があります。パスワード保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、次の制限をプレゼンテーションに強制するためにパスワードを設定できます：

- **修正**

  特定のユーザーのみがプレゼンテーションを修正できるようにしたい場合は、修正制限を設定できます。この制限により、パスワードを提供しない限り、人々がプレゼンテーションの内容を修正、変更、またはコピーすることを防ぎます。

  ただし、この場合、パスワードなしでもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のリンク、アニメーション、効果などの内容を見ることができますが、アイテムをコピーしたり、プレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーのみがプレゼンテーションを開けるようにしたい場合は、開く制限を設定できます。この制限により、パスワードを提供しない限り、人々がプレゼンテーションの内容を見ることすらできなくなります。

  技術的には、開く制限は、ユーザーがプレゼンテーションを修正できないようにします：プレゼンテーションを開けない人々は、それを修正または変更することはできません。

  **注意**：プレゼンテーションを開くのを防ぐためにパスワード保護をすると、プレゼンテーションファイルが暗号化されます。

## **オンラインでプレゼンテーションをパスワード保護する方法**

1. 私たちの[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード**をクリックします。

3. コンピュータ上でパスワードを保護したいファイルを選択します。

4. 編集保護用の好みのパスワードを入力します；閲覧保護用の好みのパスワードを入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを表示させたい場合は、**最終としてマーク**チェックボックスをチェックします。

6. **今すぐ保護します。**

7. **今すぐダウンロードします。**

## **Aspose.Slidesでのプレゼンテーションのパスワード保護**
**サポートされている形式**

Aspose.Slidesは、以下の形式のプレゼンテーションに対して、パスワード保護、暗号化、および同様の操作をサポートしています：

- PPTXおよびPPT - Microsoft PowerPointプレゼンテーション
- ODP - OpenDocumentプレゼンテーション
- OTP - OpenDocumentプレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slidesでは、次の方法でプレゼンテーションのパスワード保護を使用して、修正を防ぐことができます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slidesでは、次の方法でパスワード保護と暗号化に関連する他のタスクを実行できます：

- プレゼンテーションの復号化；暗号化されたプレゼンテーションを開く
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションからの書き込み保護の解除
- 暗号化されたプレゼンテーションのプロパティの取得
- プレゼンテーションが暗号化されているかどうかの確認
- プレゼンテーションがパスワード保護されているかどうかの確認。

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。そして、ロックされたプレゼンテーションを修正するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)のencryptメソッドを使用してプレゼンテーションのパスワードを設定する必要があります。パスワードをencryptメソッドに渡し、saveメソッドを使用して、現在暗号化されたプレゼンテーションを保存します。

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

## **プレゼンテーションへの書き込み保護の設定**

「修正しないでください」というマークをプレゼンテーションに追加できます。この方法で、ユーザーにプレゼンテーションの変更を望まないことを伝えることができます。

**注意**：書き込み保護プロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に望む場合、プレゼンテーションを修正できますが、変更を保存するには異なる名前のプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)メソッドを使用する必要があります。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションの復号化；暗号化されたプレゼンテーションを開く**

Aspose.Slidesは、パスワードを渡すことで暗号化されたファイルを読み込むことを許可します。プレゼンテーションを復号化するには、[removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)メソッドを引数なしで呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションを読み込む必要があります。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています：

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

## **暗号化の解除；パスワード保護の無効化**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスまたは修正できるようになります。

暗号化またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています：

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

## **プレゼンテーションからの書き込み保護の解除**

Aspose.Slidesを使用して、プレゼンテーションファイルに使用されている書き込み保護を解除できます。これにより、ユーザーは好きなように修正でき、その際に警告を受けることはありません。

プレゼンテーションから書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--)メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号化されたプレゼンテーションのプロパティを取得する**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションにパスワード保護をかけながら、ユーザーがそのプロパティにアクセスできる手段を提供します。

**注意**：Aspose.Slidesがプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。しかし、プレゼンテーションのプロパティをアクセス可能にしたい場合（プレゼンテーションが暗号化された後も）、Aspose.Slidesはそれを正確に行うことを許可します。

ユーザーが暗号化されたプレゼンテーションのプロパティにアクセスする能力を保持させたい場合は、[encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--)プロパティを`true`に設定できます。このサンプルコードは、ユーザーがプレゼンテーションのドキュメントプロパティにアクセスできる手段を提供しながらプレゼンテーションを暗号化する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションを読み込む前にパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、そのプレゼンテーションがパスワードで保護されていないことを確認したい場合があります。これにより、パスワード保護されたプレゼンテーションがパスワードなしで読み込まれた場合に発生するエラーや類似の問題を回避できます。

このJavaコードは、プレゼンテーションがパスワード保護されているかどうかを確認する方法を示しています（プレゼンテーション自体を読み込まずに）：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("プレゼンテーションはパスワード保護されています: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているかどうかの確認**

Aspose.Slidesは、プレゼンテーションが暗号化されているかどうかを確認することを許可します。このタスクを実行するには、[isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--)プロパティを使用できます。このプロパティは、プレゼンテーションが暗号化されている場合は`true`を、暗号化されていない場合は`false`を返します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているかどうかの確認**

Aspose.Slidesは、プレゼンテーションが書き込み保護されているかどうかを確認することを許可します。このタスクを実行するには、[isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--)プロパティを使用できます。このプロパティは、プレゼンテーションが暗号化されている場合は`true`を、そうでない場合は`false`を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードがプレゼンテーションを保護するために使用されたことを確認する**

特定のパスワードがプレゼンテーションドキュメントを保護するために使用されたことを確認したい場合があります。Aspose.Slidesは、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass"が一致しているか確認
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

指定されたパスワードでプレゼンテーションが暗号化されている場合は`true`を返します。それ以外の場合は`false`を返します。

{{% alert color="primary" title="関連情報" %}} 
- [PowerPointのデジタル署名](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}