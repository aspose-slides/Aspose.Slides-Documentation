---
title: PHPでプレゼンテーションにデジタル署名を追加
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/php-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証局
- PFX証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションセキュリティ
- PHP
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、Java 経由で PHP 用 Aspose.Slides を使ってデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、および署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、3つの関連するセキュリティ概念が重要です：

- **デジタル証明書** は、身元と公開鍵を結び付ける電子的な証明書です。信頼できる認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は、出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別であり、[パスワードで保護されたプレゼンテーション](/php-java/password-protected-presentation/)で説明されています。

PowerPoint は、**ファイル > 情報 > プレゼンテーションの保護** の下にある **デジタル署名の追加** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「デジタル署名の追加」がハイライトされている様子](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDigitalSignatures) を介して署名を公開し、[DigitalSignatureCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignaturecollection/) を返します。このコレクションの項目は [DigitalSignature](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignature/) オブジェクトで表されます。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

A PFX ファイルは、PKCS#12 ファイルとも呼ばれ、通常は `.pfx` または `.p12` 拡張子が付けられ、X.509 証明書、その秘密鍵、証明書チェーンを含むことができます。秘密鍵は、所有者が署名を作成することを可能にします。秘密鍵にアクセスできない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは、証明書パッケージと秘密鍵を保護します。これは、プレゼンテーションを開いたり編集したりするためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。実稼働環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された構成ソースから取得してください。以下の例では、パスワードをコードに埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローで署名するには、既存の PPTX ファイルをロードし、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルに保存します。

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

結果を新しい名前で保存すると、署名されていない元のファイルが保持されます。[DigitalSignature::setComments](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignature/setcomments/) で設定する値は署名の目的を記述するものであり、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルをロードしたら、[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDigitalSignatures) が返す各項目を検査します。[DigitalSignature::isValid](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignature/isvalid/) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

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

無効な結果は、一般的に署名後にプレゼンテーションのコンテンツや署名データが変更された、またはファイルが破損したことを意味します。すべての署名を削除すると署名なしのプレゼンテーションが生成されるため、項目の有効性だけをチェックするだけでは不十分です。セキュリティが重要なワークフローでは、期待される署名数と期待される署名者の身元が存在することも確認する必要があります。

この有効性の結果だけで、証明書の信頼性に関する最終判断を下すべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効ステータスの確認、期待されるサブジェクトまたはサムプリントの確認、キー使用法の検証、そして信頼できるタイムスタンプの評価も行う必要があります。[DigitalSignature::getSignTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignature/getsigntime/) の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変わります。次の例は、署名された PPTX ファイルをロードし、[DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignaturecollection/clear/) で全署名を削除し、署名なしのコピーを保存します。

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

1 つだけ署名を削除するには、ゼロベースのインデックスを使用して [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/digitalsignaturecollection/removeat/) を呼び出します。署名された元ファイルを上書きすることが明示的にワークフローの一部でない限り、必ず新しいファイルに保存してください。

## **編集および形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にするわけではありません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前に、意図したすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正後のプレゼンテーションを保存し、再度署名してください。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とそのパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、署名されていない元ファイルまたは別の管理されたコピーを保持してください。

## **よくある質問**

**デジタル署名はプレゼンテーションを暗号化しますか？**

No. デジタル署名は出所と完全性に関する証拠を提供しますが、別途暗号化を適用しない限りプレゼンテーションの内容は読めたままです。コンテンツへのアクセスを制限する必要がある場合は、[パスワード保護](/php-java/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

No. PFX パスワードは証明書パッケージ内の秘密鍵をアンロックするためのものです。PPTX ファイルを開くまたは編集できるユーザーを制御するものでは **ありません**。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能な秘密鍵を含む自己署名証明書は使用可能です。ただし、受信者はその証明書が明示的に信頼された環境に追加されていない限り、自動的に信頼しません。公共または組織間のワークフローでは、通常、信頼できる CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名されたプレゼンテーションのコンテンツや署名データを署名後に変更すると、署名が無効になります。また、ファイルの破損も検証失敗の原因となります。すべての署名が削除された場合、プレゼンテーションは署名なしとなり、無効な署名が含まれているわけではありません。

**有効な署名は、署名者を信頼すべきことを意味しますか？**

それだけではありません。署名の完全性と署名者の信頼は別個の判断です。実運用の検証ポリシーでは、証明書チェーン、 有効期間、失効状態、期待される身元、キー使用法、そして必要に応じて信頼できるタイムスタンプの確認も行うべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書の信頼性評価に影響します。署名が受け入れ可能かどうかは、ポリシーと、署名が証明書有効期間内に行われたことを示す有効な信頼タイムスタンプがあるかに依存します。表示されている署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルのロックを行いません。署名されたコンテンツを編集すると通常、既存の署名は無効になるため、まずプレゼンテーションを完成させ、最終リビジョンに署名してください。

**プレゼンテーションに複数の署名を含めることはできますか？**

はい。保存する前に、[Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDigitalSignatures) が返すコレクションに各署名を追加してください。検証時にはすべての署名を検査し、必要な署名者が全員揃っていることを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides はここで説明したデジタル署名操作を PPTX のみでサポートします。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。