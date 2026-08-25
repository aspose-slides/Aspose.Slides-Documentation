---
title: Android でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/androidjava/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証局
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションセキュリティ
- Android
- Java
- Aspose.Slides
description: "既存の PPTX プレゼンテーションに PFX 証明書で署名し、Java 経由で Android 用 Aspose.Slides を使用してデジタル署名を検証または削除する方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、署名されたコンテンツが変更されているかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です：

- **デジタル証明書** は、識別子と公開鍵を結び付ける電子クレデンシャルです。信頼できる認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くまたは変更できるかを制御します。デジタル署名とは別物であり、[パスワードで保護されたプレゼンテーション](/slides/ja/androidjava/password-protected-presentation/)で説明されています。

PowerPoint は、**ファイル > 情報 > プレゼンテーションの保護** の下にある **デジタル署名の追加** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「デジタル署名の追加」がハイライトされている様子](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知で、プレゼンテーションに有効な署名が含まれていることが示されています](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) を通じて署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの項目は [IDigitalSignature](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、一般に `.pfx` または `.p12` 拡張子が付く）は、X.509 証明書、その秘密鍵、および証明書チェーンを含むことができます。秘密鍵は所有者が署名を作成できるようにするものです。アクセス可能な秘密鍵を持たない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開くまたは編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された構成ソースから取得してください。以下の例では、コードにパスワードを埋め込まないよう環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローで署名するには、既存の PPTX ファイルをロードし、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルに保存します。

```java
import com.aspose.slides.*;

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

結果を新しい名前で保存すると、署名されていない元のファイルが保持されます。[IDigitalSignature.setComments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) で設定する値は署名の目的を記述するものであり、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルをロードしたら、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すすべての項目をチェックします。[IDigitalSignature.isValid](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#isValid--) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

```java
import com.aspose.slides.*;

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

無効な結果は、署名されたプレゼンテーション コンテンツまたは署名データが署名後に変更されたか、ファイルが破損していることを意味することが多いです。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけをチェックするだけでは不十分です。セキュリティ上重要なワークフローでは、期待される署名数と署名者の身元が存在することも確認する必要があります。

この有効性の結果だけを証明書の信頼判断の全体と見なしてはいけません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期間と失効状態の確認、期待されるサブジェクトまたはサムプリントの確認、鍵使用法の検証、信頼できるタイムスタンプの評価も行う必要があります。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) の値だけでは、信頼できるタイムスタンプ機関からの証拠とはみなされません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変わります。次の例は、署名された PPTX ファイルをロードし、[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) ですべての署名を削除し、未署名のコピーとして保存します。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つの署名だけを削除する場合は、ゼロベースのインデックスを指定して [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) を呼び出します。署名された元ファイルを上書きすることが明示的なワークフローの一部でない限り、新しいファイルに保存してください。

## **編集および形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツの変更は通常、既存の署名を無効にします。
- 署名する前に意図したすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正後のプレゼンテーションを保存し、再度署名してください。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とそのパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、未署名の元ファイルまたは別の管理コピーを保持してください。

## **よくある質問**

**プレゼンテーションはデジタル署名で暗号化されますか？**

いいえ。デジタル署名は出所と完全性に関する証拠を提供しますが、別途暗号化しない限りプレゼンテーションの内容は読み取り可能です。コンテンツへのアクセスを制限する必要がある場合は、[パスワード保護](/slides/ja/androidjava/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージに保存された秘密鍵を解除するためのものであり、PPTX ファイルを開くまたは編集できるかどうかは制御しません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的にそれを信頼しません。明示的に信頼された環境に証明書を追加しない限り、一般的な組織間ワークフローでは信頼できる CA が発行した証明書が使用されます。

**署名が無効になる理由は何ですか？**

署名後にプレゼンテーション コンテンツや署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは未署名となりますが、無効な署名が残っているわけではありません。

**有効な署名は、署名者を信頼すべきことを意味しますか？**

署名の完全性だけでは署名者の信頼は判断できません。運用上の検証ポリシーでは、証明書チェーン、証明書の有効期間、失効状態、期待される身元、鍵の使用目的、信頼できるタイムスタンプ要件なども確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書の信頼評価に影響します。署名が受け入れ可能かどうかは、ポリシーと、署名時に証明書が有効であったことを示す信頼できるタイムスタンプがあるかどうかに依存します。表示される署名時間だけを信頼できるタイムスタンプとみなさないでください。

**署名されたプレゼンテーションはまだ編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると既存の署名は通常無効になるため、最終版を署名することが推奨されます。

**プレゼンテーションに複数の署名を含めることはできますか？**

はい。[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すコレクションに各署名を追加してから保存してください。検証時にはすべての署名をチェックし、必要な署名者がすべて揃っていることを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明したデジタル署名操作をサポートしているのは PPTX 形式のみです。PPT および OpenDocument のプレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**

はい。1 つの署名を削除するかコレクション全体をクリアしてからプレゼンテーションを保存すれば、スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。