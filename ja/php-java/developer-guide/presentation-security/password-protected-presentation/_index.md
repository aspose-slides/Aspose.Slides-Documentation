---
title: PHPでパスワードで保護されたプレゼンテーションを安全にする
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/php-java/password-protected-presentation/
keywords:
- PowerPointをロック
- プレゼンテーションをロック
- PowerPointのロック解除
- プレゼンテーションのロック解除
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
description: "Aspose.Slides for PHP を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対してこれらの制限を課すためにパスワードを設定できます：

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを提示しない限り、プレゼンテーションの変更、編集、コピーができなくなります。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどのコンテンツを見ることはできますが、アイテムのコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提示しない限り、プレゼンテーションの内容さえ表示できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開くことができなければ、変更や編集を行うこともできません。

  **注意** パスワード保護により開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **プレゼンテーションをオンラインでパスワード保護する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/ja/lock)ページへ移動します。 

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。 

4. 編集保護用の希望パスワードと表示保護用の希望パスワードを入力します。 

5. ユーザーに最終版としてプレゼンテーションを閲覧させたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。 

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**
**サポートされている形式**

Aspose.Slides は、以下の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします：

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション 
- ODP - OpenDocument プレゼンテーション 
- OTP - OpenDocument プレゼンテーションテンプレート 

**サポートされている操作**

Aspose.Slides は、次の方法でプレゼンテーションに対して変更を防止するためのパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、次の方法でパスワード保護や暗号化に関わるその他のタスクを実行できます：

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションの開封
- 暗号化の解除; パスワード保護の無効化
- プレゼンテーションから書き込み保護を解除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認。

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するにはユーザーがパスワードを提供しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/) の `encrypt` メソッドを使用してパスワードを設定します。`encrypt` メソッドにパスワードを渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

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

プレゼンテーションに「変更しないでください」というマークを付けることができます。これにより、ユーザーに対してプレゼンテーションの変更を望んでいないことを伝えられます。

**注意** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更することは可能ですが、変更を保存するには別名でファイルを作成しなければなりません。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setWriteProtection) メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

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

Aspose.Slides は、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしで [removeEncryption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeEncryption) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています：

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

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションの暗号化やパスワード保護を解除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスまたは変更できるようになります。

暗号化やパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeEncryption) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています：

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

## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用してプレゼンテーションファイルの書き込み保護を解除できます。これにより、ユーザーは自由に変更でき、警告メッセージも表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeWriteProtection) メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています：

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

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しつつ、ユーザーがプロパティにアクセスできるメカニズムを提供します。

**注意:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もプロパティにアクセスできるようにしたい場合は、[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に `false` を渡します。このサンプルコードは、プロパティへのアクセスを許可しながらプレゼンテーションを暗号化する方法を示しています：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみを読み込む**

スライドやその他のコンテンツを読み込まずに暗号化されたプレゼンテーションのメタデータだけを調査したい場合は、[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) オブジェクトを作成し、`true` を [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) に渡します。このモードでは、Aspose.Slides はパスワードを無視し、パブリックにアクセス可能なドキュメントプロパティのみを読み込みます。

次のコード例は、[Presentation::getDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDocumentProperties) を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります：

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # ビルトインドキュメントプロパティを読み取る。
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # カスタムドキュメントプロパティを読み取る。
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

このワークフローは、プレゼンテーションが暗号化されたときにドキュメントプロパティが暗号化されていない（パブリック）場合にのみ機能します。プロパティが暗号化されている場合、[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) に `true` を渡すと例外がスローされます。暗号化されたプロパティにアクセスするか、スライドやその他のコンテンツを含むプレゼンテーション全体を読み込むには、[LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) を使用して正しいパスワードを指定してください。

## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、そのプレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワードがない状態で保護されたプレゼンテーションを読み込もうとしたときに発生するエラーや類似の問題を回避できます。

この PHP コードは、プレゼンテーション自体を読み込まずにパスワード保護されているかどうかを調べる方法を示しています：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認できます。この処理には、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#isEncrypted) メソッドを使用します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかをチェックする方法を示しています：

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

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。この処理には、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#isWriteProtected) メソッドを使用します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかをチェックする方法を示しています：

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

プレゼンテーション文書が特定のパスワードで保護されているかどうかを確認したい場合があります。Aspose.Slides は、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

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

パスワードで暗号化されたプレゼンテーションであれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートしている暗号化方式は何ですか？**

Aspose.Slides は AES 系列を含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開こうとした際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際にパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開閉時に若干のオーバーヘッドが発生する可能性があります。しかし多くの場合、この影響は最小限であり、プレゼンテーションの全体的な処理時間に大きな支障はありません。