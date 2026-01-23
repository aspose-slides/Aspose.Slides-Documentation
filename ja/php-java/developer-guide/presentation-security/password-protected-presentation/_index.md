---
title: PHPでパスワード保護されたプレゼンテーションのセキュリティ
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびロック解除する方法を学びましょう。プレゼンテーションを安全に保護します。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するにはパスワードを入力する必要があります。パスワード保護されたプレゼンテーションはロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対して次のような制限を課すためにパスワードを設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの変更、編集、コピーを防ぎます。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を閲覧できますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの内容の閲覧すら防ぎます。

  技術的には、開く制限はユーザーの変更も防止します。プレゼンテーションを開けない場合、変更や編集もできません。

  **注意** パスワード保護で開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**
1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用の希望パスワードと表示保護用の希望パスワードを入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides のプレゼンテーション向けパスワード保護**
**サポート形式**

Aspose.Slides は次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX と PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides は次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は次の方法でパスワード保護や暗号化に関するその他のタスクを実行できます。

- プレゼンテーションの復号化、暗号化されたプレゼンテーションの開く
- 暗号化の解除、パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **プレゼンテーションを暗号化する**
パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

暗号化またはパスワード保護を行うには、[ProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/) の `encrypt` メソッドを使用してプレゼンテーションにパスワードを設定します。`encrypt` メソッドにパスワードを渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

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
「変更しないでください」というマークをプレゼンテーションに追加できます。これにより、ユーザーに対してプレゼンテーションの変更を望んでいないことを伝えられます。

**注意** 書き込み保護プロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setWriteProtection) メソッドを使用します。このサンプルコードはプレゼンテーションへの書き込み保護設定方法を示しています:
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


## **暗号化されたプレゼンテーションを読み込む**
Aspose.Slides はパスワードを渡すことで暗号化ファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしで [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption) メソッドを呼び出し、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードはプレゼンテーションの復号化方法を示しています:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 復号化されたプレゼンテーションで作業する
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **プレゼンテーションから暗号化を削除する**
プレゼンテーションの暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption) メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を削除する方法を示しています:
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

書き込み保護を削除するには、[removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeWriteProtection) メソッドを使用します。このサンプルコードは書き込み保護の削除方法を示しています:
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


## **暗号化されたプレゼンテーションのプロパティを取得する**
通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しながら、ユーザーがそのプロパティにアクセスできるメカニズムを提供します。

**注意** Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後でもプロパティを利用可能にしたい場合は、`encryptDocumentProperties` メソッドに `true` を渡すことで実現できます。このサンプルコードはプロパティへのアクセスを可能にしつつプレゼンテーションを暗号化する方法を示しています:
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
プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワードがない状態で保護されたプレゼンテーションを読み込んで起こるエラーや問題を回避できます。

この PHP コードはプレゼンテーションを実際に読み込まずにパスワード保護されているか調べる方法を示しています:
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **プレゼンテーションが暗号化されているか確認する**
Aspose.Slides はプレゼンテーションが暗号化されているかどうかを確認できます。このタスクには、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isEncrypted) メソッドを使用します。

このサンプルコードはプレゼンテーションが暗号化されているか確認する方法を示しています:
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
Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクには、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isWriteProtected) メソッドを使用します。

このサンプルコードはプレゼンテーションが書き込み保護されているか確認する方法を示しています:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **特定のパスワードが使用されたことを検証または確認する**
プレゼンテーションドキュメントが特定のパスワードで保護されているか確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

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


指定されたパスワードでプレゼンテーションが暗号化されていれば `true` が返り、そうでなければ `false` が返ります。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**
**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートし、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力するとどうなりますか？**

誤ったパスワードが使用された場合、例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化プロセスにより、開く際や保存時に若干のオーバーヘッドが発生する可能性があります。ほとんどの場合、このパフォーマンスへの影響は最小限で、プレゼンテーション全体の処理時間に大きな影響はありません。