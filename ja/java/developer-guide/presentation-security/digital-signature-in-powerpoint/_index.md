---
title: Java でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明機関
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Java
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、Aspose.Slides for Java を使ってデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに署名した人物と、署名されたコンテンツが変更されていないかを判定するのに役立ちます。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **デジタル証明書** は、アイデンティティと公開鍵を紐付ける電子クレデンシャルです。信頼できる認証局 (CA) が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書保持者の秘密鍵から作成されます。その後、証明書の公開鍵で署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーション自体を暗号化するわけではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか編集できるかを制御します。これはデジタル署名とは別物で、[Password-Protected Presentations](/java/password-protected-presentation/) に記載されています。

PowerPoint は **ファイル > 情報 > プレゼンテーションの保護** の下に **デジタル署名の追加** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「デジタル署名の追加」がハイライトされている画像](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知画像](digital-signature-status-in-powerpoint.png)

Aspose.Slides は [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) を介して署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの項目はすべて [IDigitalSignature](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイルは PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12` です。X.509 証明書、その秘密鍵、証明書チェーンを含めることができます。秘密鍵は署名を作成するために必要です。秘密鍵にアクセスできない証明書は、プレゼンテーションの署名に使用できません。

PFX パスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開く・編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーションに署名する手順は、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/java/com.aspose.slides/digitalsignature/) を作成し、プレゼンテーションのコレクションに署名を追加して、PPTX ファイルとして保存します。

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果を新しい名前で保存すると、未署名の元ファイルが残ります。[IDigitalSignature.setComments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) で設定する値は署名の目的を記述するものであり、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込んだら、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返す各項目を検査します。[IDigitalSignature.isValid](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#isValid--) メソッドは、埋め込まれた署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

無効な結果は、署名後にコンテンツまたは署名データが変更された、あるいはファイルが破損したことを意味することが多いです。すべての署名を削除すると未署名のプレゼンテーションになるため、項目の有効性だけを確認するだけでは不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者のアイデンティティが存在することも検証してください。

この有効性結果だけで証明書の信頼性を完全に判断すべきではありません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書有効期限と失効状態の確認、期待されるサブジェクトやサムプリントの確認、キー使用法の検証、信頼できるタイムスタンプの評価も必要になる場合があります。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#getSignTime--) の値だけでは、信頼できるタイムスタンプ機関からの証明とはみなせません。

## **デジタル署名の削除**

署名を削除するとプレゼンテーションのセキュリティ状態が変わります。次の例では署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/#clear--) で全署名を削除し、未署名のコピーとして保存します。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

単一の署名だけを削除したい場合は、ゼロベースインデックスで [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) を呼び出します。署名された元ファイルを上書きすることがワークフローの明示的な一部でない限り、必ず新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常は既存の署名が無効になります。
- 署名前にすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、改訂版を保存し、再度署名してください。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として引き継がれません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とパスワードを取得した者は、その証明書保持者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は出所と完全性の証拠を提供しますが、コンテンツは暗号化されずに読み取れます。コンテンツへのアクセス制限が必要な場合は、[password protection](/java/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージ内の秘密鍵を解除するためのもので、PPTX ファイルの開閉や編集を制御するものではありません。

**自己署名証明書は使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的に信頼しないため、明示的に信頼環境に追加する必要があります。組織間や公開のワークフローでは、通常、信頼できる CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーションの内容や署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれるわけではありません。

**有効な署名は署名者を信頼すべきことを意味しますか？**

署名の完全性と署名者の信頼は別々の判断です。運用上の検証ポリシーでは、証明書チェーン、期限、失効状態、期待するアイデンティティ、キー使用法、必要に応じた信頼できるタイムスタンプも確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の期限切れはプレゼンテーションのバイト列を変更しませんが、証明書信頼の評価に影響します。署名が有効かどうかはポリシーと、期限切れ前に署名されたことを示す有効な信頼タイムスタンプがあるかに依存します。表示される署名時刻だけに頼らないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルをロックしません。ただし、署名されたコンテンツを編集すると既存の署名は通常無効になるため、最終版を作成してから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すコレクションに各署名を追加してから保存します。検証時はすべての署名をチェックし、必要な署名者が揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートしているのは PPTX のみです。PPT および OpenDocument のプレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてからプレゼンテーションを保存すれば、スライド内容はそのままで、保存されたファイルに署名証拠は残りません。