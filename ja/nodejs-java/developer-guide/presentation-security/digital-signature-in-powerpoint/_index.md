---
title: JavaScript でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/nodejs-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書機関
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Node.js
- JavaScript
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、Node.js 用 Aspose.Slides を Java 経由で利用してデジタル署名の検証や削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、そして署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **digital certificate** は、身元と公開鍵を関連付ける電子クレデンシャルです。信頼された証明書機関 (CA) が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **digital signature** は、プレゼンテーションのコンテンツと証明書所有者のプライベートキーから作成されます。証明書の公開鍵を使用して署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **Password protection** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別で、[パスワード保護されたプレゼンテーション](/nodejs-java/password-protected-presentation/) に記載されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![デジタル署名の追加がハイライトされた PowerPoint の「プレゼンテーションの保護」メニュー](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名状態の通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) を介して署名を公開し、[DigitalSignatureCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/) を返します。このコレクションは [DigitalSignature](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) オブジェクトを含みます。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイルは PKCS#12 ファイルとも呼ばれ、通常は `.pfx` または `.p12` 拡張子が付けられます。このファイルには X.509 証明書、そのプライベートキー、および証明書チェーンが含まれる場合があります。プライベートキーは所有者が署名を作成することを可能にします。プライベートキーにアクセスできない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージとプライベートキーを保護します。これはプレゼンテーションを開くまたは編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないように環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーションワークフローに署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) を作成し、プレゼンテーションのコレクションに署名を追加して、PPTX ファイルに保存します。

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果を新しい名前で保存すると、未署名の元ファイルが保持されます。[DigitalSignature.setComments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) に設定した値は署名の目的を記述しますが、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む際は、[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) が返す各項目を検査します。[DigitalSignature.isValid](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) メソッドは、埋め込み署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

以下の例では、Node.js の `X509Certificate` クラスを使用して、埋め込み証明書ごとのサブジェクト名を読み取ります。

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

無効な結果は、署名後にプレゼンテーションのコンテンツや署名データが変更された、あるいはファイルが破損していることを意味することが多いです。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

この有効性の結果だけを証明書の信頼判定全体の決定として扱ってはいけません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期間と失効ステータスの確認、期待されるサブジェクトまたはフィンガープリントの確認、キー使用の検証、信頼できるタイムスタンプの評価も必要になる場合があります。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) の値単体は、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変化します。以下の例は署名された PPTX ファイルを読み込み、[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーを保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つだけ署名を削除するには、[DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) をゼロベースのインデックスで呼び出します。ワークフローで署名済みの元ファイルを上書きすることが明示的に指定されていない限り、新しいファイルに保存してください。

## **編集と形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションはファイルを編集できますが、署名されたコンテンツを変更すると通常既存の署名は無効になります。
- 署名する前に意図したすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、改訂版を保存し、再度署名してください。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として転送されません。
- 証明書のプライベートキーは機密情報として扱ってください。プライベートキーとそのパスワードを取得した者は、その証明書所有者からの署名のように見える署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **よくある質問**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は出所と完全性の証拠を提供しますが、別途暗号化を適用しない限りプレゼンテーションの内容は読み取れたままです。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/nodejs-java/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージ内のプライベートキーを解除するためのものです。PPTX ファイルを開くまたは編集できるかは制御しません。

**自己署名証明書は使用できますか？**

技術的には、アクセス可能なプライベートキーを含む自己署名証明書を使用できます。ただし、受信者は自動的に信頼しません。信頼された環境に明示的に追加されない限りです。公開または組織間のワークフローでは、通常信頼された CA が発行した証明書が使用されます。

**署名が無効になる理由は何ですか？**

署名後にプレゼンテーションのコンテンツや署名データを変更すると署名が無効になります。また、ファイルが破損しても検証に失敗します。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれているわけではありません。

**有効な署名は署名者を信頼すべきことを意味しますか？**

それだけではありません。署名の完全性と署名者の信頼は別々の判断です。 本番環境の検証ポリシーでは、証明書チェーンや有効期間、失効状態、期待される身元、キー使用、信頼できるタイムスタンプ要件なども確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーションのバイト列は変わりませんが、証明書の信頼評価に影響します。署名が受け入れ可能かはポリシーと、署名が有効な証明書で行われたことを示す信頼できるタイムスタンプがあるかに依存します。表示されている署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常既存の署名は無効になるため、まずプレゼンテーションを完成させてから最終リビジョンに署名してください。

**プレゼンテーションは複数の署名を含められますか？**

はい。[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) が返すコレクションに各署名を追加してから保存してください。検証時にはすべての署名を検査し、必要な署名者が全員揃っていることを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides はここで説明したデジタル署名操作を PPTX のみでサポートします。PPT と OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**

はい。1 つの署名を削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容は残りますが、保存されたファイルには削除された署名の証拠が残りません。