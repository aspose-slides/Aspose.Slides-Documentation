---
title: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
keywords: "JavaでPowerPointプレゼンテーションをロックする"
description: "PowerPointプレゼンテーションをロックします。Javaでのパスワード保護されたPowerPoint"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションをパスワード保護するとは、特定の制限をプレゼンテーションに適用するためのパスワードを設定することを意味します。制限を解除するには、パスワードを入力する必要があります。パスワード保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、以下の制限をプレゼンテーションに適用するためのパスワードを設定できます：

- **変更の制限**

  特定のユーザーにのみプレゼンテーションを変更させたい場合、変更の制限を設定できます。ここでの制限は、人々がプレゼンテーションの内容を変更、変更、またはコピーすることを防ぎます（パスワードを提供する場合を除く）。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内の内容やハイパーリンク、アニメーション、効果などを見ることができますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開くための制限**

  特定のユーザーにのみプレゼンテーションを開かせたい場合、開くための制限を設定できます。ここでの制限は、人々がプレゼンテーションの内容を表示することさえ防ぎます（パスワードを提供する場合を除く）。

  技術的には、開くための制限はユーザーがプレゼンテーションを変更することを防ぎます：人々がプレゼンテーションを開けない場合、それを変更したり、変更したりすることはできません。

  **注意**：プレゼンテーションを開くのを防ぐためにパスワード保護を行うと、プレゼンテーションファイルが暗号化されます。

## **オンラインでプレゼンテーションをパスワード保護する方法**

1. [**Aspose.Slidesロック**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード**をクリックします。

3. パスワード保護したいファイルをコンピュータから選択します。

4. 編集保護のための希望のパスワードを入力します。表示保護のための希望のパスワードも入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを表示させたい場合は、**最終版としてマーク**のチェックボックスをオンにします。

6. **今すぐ保護する**をクリックします。

7. **今すぐダウンロード**をクリックします。

## **Aspose.Slidesでのプレゼンテーションのパスワード保護**
**サポートされているフォーマット**

Aspose.Slidesは、以下のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、その他の類似の操作をサポートしています：

- PPTXおよびPPT - Microsoft PowerPointプレゼンテーション
- ODP - OpenDocumentプレゼンテーション
- OTP - OpenDocumentプレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slidesでは、プレゼンテーションの変更を防ぐためにパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションに書き込み保護を設定する

**その他の操作**

Aspose.Slidesでは、以下の方法でパスワード保護や暗号化に関する他のタスクを実行できます：

- プレゼンテーションの暗号を解除する；暗号化されたプレゼンテーションを開く
- 暗号を削除する；パスワード保護を無効にする
- プレゼンテーションから書き込み保護を解除する
- 暗号化されたプレゼンテーションのプロパティを取得する
- プレゼンテーションが暗号化されているかどうかを確認する
- プレゼンテーションがパスワード保護されているかどうかを確認する。

## **プレゼンテーションを暗号化する**

パスワードを設定することで、プレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーがパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)からencryptメソッドを使用して、プレゼンテーションのパスワードを設定する必要があります。パスワードをencryptメソッドに渡し、saveメソッドを使用して暗号化されたプレゼンテーションを保存します。

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

「変更しないでください」と記載したマークをプレゼンテーションに追加できます。この方法で、ユーザーに対してプレゼンテーションに変更を加えたくないことを伝えることができます。

**注意**：書き込み保護プロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に変更したい場合、プレゼンテーションを変更できますが、変更を保存するためには異なる名前のプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)メソッドを使用する必要があります。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションの暗号を解除する；暗号化されたプレゼンテーションを開く**

Aspose.Slidesは、パスワードを渡すことで暗号化されたファイルをロードすることを許可します。プレゼンテーションの暗号を解除するには、[removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--)メソッドを引数なしで呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションをロードする必要があります。

このサンプルコードは、プレゼンテーションの暗号を解除する方法を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 暗号解除したプレゼンテーションで作業
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号を削除する；パスワード保護を無効にする**

プレゼンテーションの暗号化またはパスワード保護を削除することができます。この方法で、ユーザーは制限なしにプレゼンテーションにアクセスまたは変更できるようになります。

暗号またはパスワード保護を削除するには、[removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--)メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号を削除する方法を示しています：

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

Aspose.Slidesを使用して、プレゼンテーションファイルに適用された書き込み保護を解除することができます。このようにして、ユーザーは自由に変更でき、警告も表示されません。

[removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--)メソッドを使用してプレゼンテーションから書き込み保護を削除できます。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています：

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

通常、ユーザーは暗号化されたりパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションをパスワード保護しながら、そのプロパティにアクセスする手段を提供するメカニズムを提供します。

**注意**：Aspose.Slidesがプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。しかし、プレゼンテーションのプロパティをアクセス可能にしたい場合（プレゼンテーションが暗号化された後でも）、Aspose.Slidesはそのための方法を提供します。

ユーザーが暗号化したプレゼンテーションのプロパティにアクセスする能力を保持したい場合は、[encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--)プロパティを`true`に設定できます。このサンプルコードは、ユーザーがドキュメントプロパティにアクセスできる方法でプレゼンテーションを暗号化する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションをロードする前にパスワード保護されているか確認する**

プレゼンテーションをロードする前に、そのプレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをそのパスワードなしでロードしたときに発生するエラーや類似の問題を回避できます。

このJavaコードは、プレゼンテーションがパスワード保護されているかどうかを確認する方法を示しています（プレゼンテーション自体をロードせずに）：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("プレゼンテーションはパスワードで保護されていますか：" + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slidesを使用すると、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、[isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--)プロパティを使用できます。このプロパティは、プレゼンテーションが暗号化されている場合に`true`を返し、暗号化されていない場合は`false`を返します。

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

Aspose.Slidesを使用すると、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、[isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--)プロパティを使用できます。このプロパティは、プレゼンテーションが暗号化されている場合に`true`を返し、暗号化されていない場合は`false`を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードがプレゼンテーションを保護するために使用されたか検証する**

プレゼンテーションドキュメントが特定のパスワードで保護されているか確認したい場合があります。Aspose.Slidesは、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass"が一致するか確認します
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

指定されたパスワードでプレゼンテーションが暗号化されている場合は`true`を返し、それ以外は`false`を返します。

{{% alert color="primary" title="参照" %}} 
- [PowerPointのデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}