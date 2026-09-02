---
title: PHP でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/php-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書機関
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーション セキュリティ
- PHP
- Aspose.Slides
description: "PFX 証明書で既存の PPTX プレゼンテーションに署名し、Java 経由で PHP 用 Aspose.Slides を使用してデジタル署名の検証や削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です。

- A **digital certificate** は、ID と公開鍵を結びつける電子証明書です。信頼できる証明書機関 (CA) が証明書を発行することも、組織が内部ワークフロー用に自己署名証明書を使用することもできます。
- A **digital signature** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。その後、証明書の公開鍵を使って署名を検証できます。署名は発信元と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **Password protection** は、ユーザーがプレゼンテーションを開くか編集できるかを制御します。これはデジタル署名とは別で、[Password-Protected Presentations](/slides/ja/php-java/password-protected-presentation/) に記載されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の「Protect Presentation」メニュー（「Add a Digital Signature」ハイライト）](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[Presentation::getDigitalSignatures] を通じて署名を公開します。このメソッドは [DigitalSignatureCollection] を返し、その項目は [DigitalSignature] オブジェクトで表されます。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイルは PKCS#12 ファイルとも呼ばれ、一般的に `.pfx` または `.p12` 拡張子が付けられます。このファイルは X.509 証明書、その秘密鍵、および証明書チェーンを含むことができます。秘密鍵は所有者が署名を作成できるようにするものです。アクセス可能な秘密鍵がない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージと秘密鍵を保護します。これはプレゼンテーションを開くまたは編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース コントロールにコミットしないでください。実運用では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された構成ソースから取得してください。以下の例では、コードにパスワードを埋め込むのを避けるために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローに署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature] を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルとして保存します。

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果を新しい名前で保存すると、署名されていない元ファイルが保持されます。[DigitalSignature::setComments] で設定する値は署名の目的を記述するもので、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む際は、[Presentation::getDigitalSignatures] が返すすべての項目を検査します。[DigitalSignature::isValid] メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

無効な結果は、署名されたプレゼンテーションのコンテンツや署名データが署名後に変更された、またはファイルが破損していることを意味することが一般的です。すべての署名を削除すると署名なしのプレゼンテーションが生成されるため、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の ID が存在することも確認する必要があります。

この有効性の結果だけを証明書の信頼性の最終判断として扱うべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期間と失効ステータスの確認、期待されるサブジェクトまたはサムプリントの検証、キー使用目的の確認、信頼できるタイムスタンプの評価も行う必要があります。[DigitalSignature::getSignTime] の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変わります。以下の例は、署名された PPTX ファイルを読み込み、[DigitalSignatureCollection::clear] ですべての署名を削除し、署名なしのコピーを保存します。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

1 つだけ署名を削除する場合は、[DigitalSignatureCollection::removeAt] にゼロベースのインデックスを渡して呼び出します。ワークフローで署名済みのオリジナルを上書きすることが明示的に要求されていない限り、別名で保存してください。

## **編集と形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にするものではありません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前に、すべての意図した編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正版を保存し、再度その版に署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名が変換後のファイルの有効な署名として引き継がれることはありません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とそのパスワードを入手した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- ドキュメント保持ポリシーで要求される場合は、署名なしの元ファイルまたは別の管理されたコピーを保持してください。

## **よくある質問**

**Does a digital signature encrypt the presentation?**  
いいえ。デジタル署名は発信元と完全性の証拠を提供しますが、プレゼンテーションの内容は別途暗号化しない限り読み取り可能なままです。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/slides/ja/php-java/password-protected-presentation/) を使用してください。

**Is the PFX password the same as a presentation password?**  
いいえ。PFX パスワードは証明書パッケージ内の秘密鍵を解除するためのもので、PPTX ファイルを開いたり編集したりする権限を制御するものではありません。

**Can I use a self-signed certificate?**  
技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的にそれを信頼しないため、信頼できる環境に明示的に追加しない限り、一般的なパブリックや組織間のワークフローでは信頼された CA が発行した証明書が使用されます。

**What makes a signature invalid?**  
署名後にプレゼンテーションのコンテンツや署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは「署名なし」の状態となり、無効な署名が含まれるわけではありません。

**Does a valid signature mean that I should trust the signer?**  
署名の有効性だけでは署名者を信頼すべきかは判断できません。署名の完全性と署名者の信頼は別個の判断です。運用上の検証ポリシーでは、証明書チェーン、期限、失効ステータス、期待される識別情報、キー使用目的、必要に応じて信頼できるタイムスタンプの有無も確認すべきです。

**What happens when the certificate expires?**  
証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書信頼性の評価に影響します。署名が有効かどうかはポリシーと、署名時点が証明書の有効期間内であったことを示す信頼できるタイムスタンプが存在するかに依存します。表示されている署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**Can a signed presentation still be edited?**  
はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常、既存の署名は無効になるため、最終版を完成させてから署名してください。

**Can a presentation contain more than one signature?**  
はい。[Presentation::getDigitalSignatures] が返すコレクションに各署名を追加して保存できます。検証時にはすべての署名を調べ、必要な署名者がすべて揃っていることを確認してください。

**Which presentation formats support these operations?**  
Aspose.Slides がここで説明したデジタル署名操作をサポートしているのは PPTX のみです。PPT および OpenDocument のプレゼンテーション形式はこの API ワークフローではサポートされていません。

**Can I remove a signature without affecting the slides?**  
はい。1 つの署名を削除するかコレクション全体をクリアしてからプレゼンテーションを保存すれば、スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。