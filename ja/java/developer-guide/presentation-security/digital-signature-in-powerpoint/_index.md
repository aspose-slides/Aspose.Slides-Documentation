---
title: Javaでプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Java
- Aspose.Slides
description: "PFX証明書を使用して既存のPPTXプレゼンテーションに署名し、Aspose.Slides for Javaでデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、そして署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です。

- **digital certificate** は、ID と公開鍵を結び付ける電子証明書です。信頼された認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **digital signature** は、プレゼンテーションのコンテンツと証明書所有者のプライベートキーから作成されます。その後、証明書の公開鍵を使って署名を検証できます。署名は発信元と完全性の証拠を提供しますが、プレゼンテーションを暗号化するわけではありません。
- **Password protection** は、ユーザーがプレゼンテーションを開いたり変更したりできるかどうかを制御します。これはデジタル署名とは別で、[Password-Protected Presentations](/slides/ja/java/password-protected-presentation/) に記載されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の「Protect Presentation」メニュー（「Add a Digital Signature」ハイライト）](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) を通じて署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの項目は [IDigitalSignature](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワード**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、一般的に `.pfx` または `.p12` 拡張子が付けられます）は、X.509 証明書、そのプライベートキー、および証明書チェーンを含むことができます。プライベートキーが署名作成を可能にします。アクセス可能なプライベートキーがない証明書は、プレゼンテーションの署名に使用できません。

PFX パスワードは証明書パッケージとプライベートキーを保護します。これはプレゼンテーションを開いたり編集したりするためのパスワード **ではありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローに署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/java/com.aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルとして保存します。

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

結果を新しい名前で保存すると、署名されていない元ファイルが保持されます。[IDigitalSignature.setComments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) で設定する値は署名の目的を記述しますが、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む時は、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返す各項目を検査します。[IDigitalSignature.isValid](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#isValid--) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

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

無効な結果は、署名後にプレゼンテーションのコンテンツまたは署名データが変更された、あるいはファイルが破損していることを意味することが一般的です。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の ID が存在することも検証する必要があります。

この有効性の結果だけで証明書の信頼性を完全に判断すべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限や失効状態の確認、期待されるサブジェクトまたはサムプリントの確認、キー使用法の検証、信頼できるタイムスタンプの評価が必要になる場合があります。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignature/#getSignTime--) の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変わります。以下の例は、署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/#clear--) ですべての署名を削除し、未署名のコピーを保存します。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つだけ署名を削除するには、[IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) にゼロベースのインデックスを指定して呼び出します。ワークフローで署名済みの元ファイルを上書きすることが明示的に必要でない限り、新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前に、すべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正版を保存し、その修正版に再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として引き継がれません。
- 証明書のプライベートキーは機密情報として扱ってください。プライベートキーとそのパスワードを取得した者は、その証明書所有者になりすます署名を作成できる可能性があります。
- 文書保持ポリシーで求められる場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は発信元と完全性の証拠を提供しますが、別途暗号化が施されていない限り、プレゼンテーションの内容は読むことができます。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/slides/ja/java/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージに保存されたプライベートキーのロックを解除します。これは PPTX ファイルを開いたり編集したりできるユーザーを制御するものではありません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能なプライベートキーを含む自己署名証明書は使用可能です。ただし、受信者はその証明書を明示的に信頼できる環境に追加しない限り、自動的に信頼しません。一般的に、公開または組織横断のワークフローでは、信頼された CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーションのコンテンツや署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれるファイルではなくなります。

**有効な署名は、署名者を信頼すべきことを意味しますか？**

それだけではありません。署名の完全性と署名者の信頼は別々の判断です。本番環境の検証ポリシーでは、証明書チェーン、有効期間、失効状態、期待される ID、キー使用法、信頼できるタイムスタンプ要件なども確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書の信頼性評価に影響します。署名が許容されるかどうかはポリシーと、署名が証明書有効期間中に行われたことを示す有効な信頼タイムスタンプがあるかに依存します。表示された署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常、既存の署名が無効になるため、まずプレゼンテーションを完成させ、最終リビジョンに署名してください。

**プレゼンテーションに複数の署名を含めることはできますか？**

はい。保存する前に、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すコレクションに各署名を追加してください。検証時にはすべての署名を確認し、必要な署名者がすべて存在することを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides は、ここで説明したデジタル署名操作を PPTX のみでサポートします。PPT や OpenDocument のプレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**

はい。1 つの署名を削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容は残りますが、保存されたファイルには削除された署名の証拠は残りません。