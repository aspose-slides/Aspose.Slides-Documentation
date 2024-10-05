---
title: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /php-java/password-protected-presentation/
keywords: "PowerPointプレゼンテーションのロック"
description: "PowerPointプレゼンテーションをロックします。パスワード保護されたPowerPoint"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションをパスワードで保護すると、それによってプレゼンテーションに特定の制限を課すパスワードを設定していることになります。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対して以下のような制限を強制するためにパスワードを設定できます：

- **変更**

  特定のユーザーだけがプレゼンテーションを変更できるようにしたい場合は、変更制限を設定できます。この制限により、ユーザーはプレゼンテーション内の項目を変更、変更、またはコピーすることができません（パスワードを提供する場合を除く）。

  ただし、この場合、パスワードがなくても、ユーザーはドキュメントにアクセスし、開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツやハイパーリンク、アニメーション、効果などを見ることができますが、項目をコピーしたり、プレゼンテーションを保存したりすることはできません。

- **開くこと**

  特定のユーザーだけがプレゼンテーションを開くことができるようにしたい場合は、開く制限を設定できます。この制限により、ユーザーはプレゼンテーションの内容を表示することすらできなくなります（パスワードを提供する場合を除く）。

  技術的には、開く制限はユーザーがプレゼンテーションを変更することも防ぎます：ユーザーがプレゼンテーションを開けない場合、変更を加えることはできません。

  **注**：プレゼンテーションをパスワードで保護して開くのを防ぐと、プレゼンテーションファイルが暗号化されます。

## **オンラインでプレゼンテーションをパスワード保護する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページにアクセスします。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード**をクリックします。

3. コンピュータでパスワード保護したいファイルを選択します。

4. 編集保護のために希望のパスワードを入力し、表示保護のために希望のパスワードを入力します。

5. ユーザーに最終版のプレゼンテーションとして表示させたい場合は、**最終版としてマーク**にチェックを入れます。

6. **今すぐ保護**をクリックします。

7. **今すぐダウンロード**をクリックします。

## **Aspose.Slidesによるプレゼンテーションのパスワード保護**
**対応フォーマット**

Aspose.Slidesは、以下のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、および類似の操作をサポートしています：

- PPTXおよびPPT - Microsoft PowerPointプレゼンテーション
- ODP - OpenDocumentプレゼンテーション
- OTP - OpenDocumentプレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slidesでは、以下の方法でプレゼンテーションの変更を防ぐためにパスワード保護を利用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slidesでは、以下の方法でパスワード保護や暗号化に関する他の作業を行うことができます：

- プレゼンテーションの暗号解除; 暗号化されたプレゼンテーションを開く
- 暗号の解除; パスワード保護の無効化
- プレゼンテーションからの書き込み保護の解除
- 暗号化されたプレゼンテーションのプロパティの取得
- プレゼンテーションが暗号化されているかどうかの確認
- プレゼンテーションがパスワードで保護されているかどうかの確認。

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提示する必要があります。

プレゼンテーションを暗号化またはパスワードで保護するには、[IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)から暗号化メソッドを使用してプレゼンテーションのパスワードを設定する必要があります。パスワードを暗号化メソッドに渡し、保存メソッドを使用して暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **プレゼンテーションへの書き込み保護の設定**

「変更しないでください」というマークをプレゼンテーションに追加できます。この方法で、ユーザーにプレゼンテーションの変更を望まないことを伝えることができます。

**注**：書き込み保護プロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは本当に変更したい場合、プレゼンテーションを変更できますが、変更を保存するには異なる名前でプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)メソッドを使用する必要があります。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **暗号化されたプレゼンテーションの暗号解除; 暗号化されたプレゼンテーションを開く**

Aspose.Slidesでは、パスワードを渡すことで暗号化されたファイルをロードすることができます。プレゼンテーションを暗号解除するには、パラメータなしで[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--)メソッドを呼び出す必要があります。プレゼンテーションをロードするには正しいパスワードを入力する必要があります。

このサンプルコードは、プレゼンテーションを暗号解除する方法を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 暗号解除されたプレゼンテーションで作業する
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **暗号の解除; パスワード保護の無効化**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスしたり、変更を加えたりできるようになります。

暗号またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--)メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号を解除する方法を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **プレゼンテーションからの書き込み保護の解除**

Aspose.Slidesを使用してプレゼンテーションファイルで使用された書き込み保護を解除できます。これにより、ユーザーは好きなように変更でき、こうした作業を行う際に警告が表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--)メソッドを使用できます。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **暗号化されたプレゼンテーションのプロパティの取得**

通常、ユーザーは暗号化されたまたはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションをパスワードで保護しつつ、ユーザーがそのプロパティにアクセスできる手段を提供します。

**注**：Aspose.Slidesがプレゼンテーションを暗号化する際には、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。ただし、プレゼンテーションが暗号化された後でもプロパティにアクセスできるようにする必要がある場合、Aspose.Slidesでは正確にその操作を行うことができます。

ユーザーが暗号化されたプレゼンテーションのプロパティにアクセスする能力を保持させたい場合は、[encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--)プロパティを`true`に設定できます。このサンプルコードは、プレゼンテーションを暗号化し、そのドキュメントプロパティにユーザーがアクセスできる手段を提供する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **プレゼンテーションをロードする前にパスワード保護されているか確認する**

プレゼンテーションをロードする前に、プレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションがそのパスワードなしでロードされた際に発生するエラーや問題を回避できます。

このPHPコードは、プレゼンテーションがパスワードで保護されているかどうかを確認する方法を示しています（プレゼンテーション自体をロードせずに）：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("プレゼンテーションはパスワードで保護されています: " . $presentationInfo->isPasswordProtected());

```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slidesでは、プレゼンテーションが暗号化されているかどうかを確認できます。この作業を行うには、[isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--)プロパティを使用できます。これは、プレゼンテーションが暗号化されている場合は`true`を返し、暗号化されていない場合は`false`を返します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slidesでは、プレゼンテーションが書き込み保護されているかどうかを確認できます。この作業を行うには、[isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--)プロパティを使用できます。これは、プレゼンテーションが暗号化されている場合は`true`を返し、暗号化されていない場合は`false`を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **特定のパスワードがプレゼンテーションを保護するために使用されたことを検証または確認する**

特定のパスワードがプレゼンテーションドキュメントを保護するために使用されたかどうかを確認したい場合があります。Aspose.Slidesは、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # "pass"が一致するか確認する
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

指定されたパスワードでプレゼンテーションが暗号化されていた場合、`true`を返します。そうでない場合は`false`を返します。

{{% alert color="primary" title="さらに学ぶ" %}} 
- [PowerPointのデジタル署名](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}