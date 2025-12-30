---
title: PHPでパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/php-java/password-protected-presentation/
keywords:
- PowerPointをロック
- プレゼンテーションをロック
- PowerPointのロックを解除
- プレゼンテーションのロックを解除
- PowerPointを保護
- プレゼンテーションを保護
- パスワードを設定
- パスワードを追加
- PowerPointを暗号化
- プレゼンテーションを暗号化
- PowerPointを復号化
- プレゼンテーションを復号化
- 書き込み保護
- PowerPointのセキュリティ
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを保護します。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、次のような制限をプレゼンテーションに設定できます:

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの変更、編集、コピーができなくなります。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツやハイパーリンク、アニメーション、エフェクトなどを見ることはできますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容を閲覧できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開くことができなければ、変更や編集を行うことはできません。

  **注意** パスワードでプレゼンテーションの開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**

1. 当社の[**Aspose.Slides ロック**](https://products.aspose.app/slides/lock)ページに移動します。  

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用の希望パスワードと表示保護用の希望パスワードを入力します。

5. プレゼンテーションを最終版としてユーザーに見せたい場合は、**最終版としてマーク** チェックボックスにチェックを入れます。

6. **今すぐ保護** をクリックします。

7. **今すぐダウンロード** をクリックします。

## **Aspose.Slides のプレゼンテーション用パスワード保護**
**サポート形式**

Aspose.Slides は次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似操作をサポートします:

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます:

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides では、次の方法でパスワード保護と暗号化に関するその他のタスクを実行できます:

- プレゼンテーションの復号化・暗号化されたプレゼンテーションの開く
- 暗号化の解除・パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager) の `encrypt` メソッドを使用してプレゼンテーションにパスワードを設定します。パスワードを `encrypt` メソッドに渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションの暗号化方法を示しています:
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


## **プレゼンテーションに書き込み保護を設定する**

プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーに変更を許可しない旨を伝えることができます。

**注意** 書き込み保護プロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードはプレゼンテーションへの書き込み保護の設定方法を示しています:
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


## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides はパスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしの [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込む必要があります。

このサンプルコードはプレゼンテーションの復号化方法を示しています:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 復号化されたプレゼンテーションで作業
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **プレゼンテーションから暗号化を削除する**

プレゼンテーションの暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を削除する方法を示しています:
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


## **プレゼンテーションから書き込み保護を削除する**

Aspose.Slides を使用してプレゼンテーションファイルの書き込み保護を削除できます。これにより、ユーザーは好きなように変更でき、警告も表示されません。

[removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用して書き込み保護を削除できます。このサンプルコードはプレゼンテーションから書き込み保護を削除する方法を示しています:
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


## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しながら、ユーザーがそのプロパティにアクセスできるメカニズムを提供します。

**注意** Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後でもプロパティへのアクセスを可能にしたい場合、[encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) プロパティを `true` に設定できます。このサンプルコードは、プロパティへのアクセスを可能にしつつプレゼンテーションを暗号化する方法を示しています:
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


## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワード保護されていないことを確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだ際に発生するエラーや問題を回避できます。

この PHP コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides はプレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--) プロパティを使用します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--) プロパティを使用します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています:
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


## **特定のパスワードが使用されたか検証または確認する**

プレゼンテーション文書が特定のパスワードで保護されているかどうかを確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードはパスワードを検証する方法を示しています:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    # "pass" が一致するか確認
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


指定されたパスワードでプレゼンテーションが暗号化されていれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="こちらも参照" %}} 
- [Digital Signature in PowerPoint](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムなどの最新暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開こうとした際にパスワードが間違っているとどうなりますか？**

間違ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを操作する際のパフォーマンスへの影響はありますか？**

暗号化および復号化プロセスにより、開くと保存する際に若干のオーバーヘッドが発生する場合があります。ほとんどの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響を与えることはありません。