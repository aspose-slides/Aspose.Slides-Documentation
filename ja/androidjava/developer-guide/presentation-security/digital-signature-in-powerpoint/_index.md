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
- プレゼンテーションのセキュリティ
- Android
- Java
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、Java 経由で Android 用 Aspose.Slides を利用してデジタル署名の検証や削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションの署名者と署名されたコンテンツが変更されたかどうかを判断できるようにします。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **デジタル証明書** は、身元と公開鍵を結び付ける電子的資格情報です。信頼できる認証局 (CA) が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** はプレゼンテーションのコンテンツと証明書保持者の秘密鍵から作成されます。証明書の公開鍵を使用して署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーション自体を暗号化しません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別個であり、[Password-Protected Presentations](/androidjava/password-protected-presentation/)で説明されています。

PowerPoint は **ファイル > 情報 > プレゼンテーションの保護** の下に **デジタル署名の追加** コマンドを提供します。

![PowerPoint Protect Presentation メニューで デジタル署名の追加 がハイライトされた](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知: プレゼンテーションに有効な署名が含まれています](digital-signature-status-in-powerpoint.png)

Aspose.Slides は [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) を介して署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの各項目は [IDigitalSignature](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションには複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12`）には X.509 証明書、その秘密鍵、および証明書チェーンが格納されます。秘密鍵は保持者が署名を作成できるようにするものです。秘密鍵にアクセスできない証明書はプレゼンテーションの署名に使用できません。

PFX のパスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開いたり編集したりするためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。実運用では証明書ファイルへのアクセスを制限し、パスワードはシークレットストアまたは他の保護された設定ソースから取得します。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローで署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して PPTX ファイルとして保存します。

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

結果を新しい名前で保存すると、署名されていない元ファイルが保持されます。[IDigitalSignature.setComments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) で設定する値は署名の目的を記述するものであり、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む際は、[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すすべての項目を検査します。各項目の [IDigitalSignature.isValid](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#isValid--) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

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

無効な結果は、署名後にプレゼンテーション コンテンツまたは署名データが変更された、またはファイルが破損したことを意味することが多いです。すべての署名を削除すると署名なしのプレゼンテーションになりますので、項目の有効性だけを確認するのは不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

この有効性の結果だけで証明書の信頼性を判断すべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効状態の確認、期待されるサブジェクトまたはサムプリントの照合、キー使用目的の検証、信頼できるタイムスタンプの評価を行う必要があります。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) の値だけでは、信頼できるタイムスタンプ機関からの証拠とはなりません。

## **デジタル署名の除去**

署名を除去するとプレゼンテーションのセキュリティ状態が変わります。次の例は署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) で全署名を削除し、署名なしのコピーとして保存します。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つだけ署名を除去したい場合は、ゼロベースのインデックスを使用して [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) を呼び出します。署名された元ファイルを上書きすることが明示的なワークフローの一部でない限り、必ず新しいファイルに保存してください。

## **編集と形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常は既存の署名が無効になります。
- 署名前にすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正後のプレゼンテーションを保存し、再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名付きプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とそのパスワードを取得した者は、その証明書保持者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、署名なしの元ファイルまたは別の管理されたコピーを保管してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は出所と完全性の証拠を提供しますが、別途暗号化しない限りプレゼンテーションの内容は読み取り可能です。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/androidjava/password-protected-presentation/) を使用してください。

**PFX のパスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX のパスワードは証明書パッケージ内の秘密鍵をロック解除するためのものです。PPTX ファイルを開くまたは編集できるかは制御しません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的に信頼しません。信頼された環境に明示的に追加しない限り、一般的な組織間ワークフローでは信頼された CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーション コンテンツや署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名を削除した場合、プレゼンテーションは「署名なし」となります。

**有効な署名は署名者を信頼すべきことを意味しますか？**

それだけでは信頼できません。署名の完全性と署名者の信頼は別々の判断です。運用上の検証ポリシーでは、証明書チェーン、 有効期間、失効状態、期待される身元、キー使用目的、信頼できるタイムスタンプ要件なども確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書の信頼評価に影響します。署名が有効かどうかはポリシーと、署名時に証明書が有効であったことを示す信頼できるタイムスタンプの有無に依存します。表示される署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると既存の署名は通常無効になるため、最終版を完成させてから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) が返すコレクションに各署名を追加します。検証時はすべての署名を確認し、必要な署名者がすべて存在することを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートしているのは PPTX のみです。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライド内容に影響を与えずに署名を削除できますか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。