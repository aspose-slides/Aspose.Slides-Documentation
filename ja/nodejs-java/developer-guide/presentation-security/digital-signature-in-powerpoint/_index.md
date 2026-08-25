---
title: JavaScript でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/nodejs-java/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書認証局
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Node.js
- JavaScript
- Aspose.Slides
description: "既存の PPTX プレゼンテーションに PFX 証明書で署名し、Node.js 用 Aspose.Slides を Java 経由で使用してデジタル署名の検証や削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、署名されたコンテンツが変更されていないかを判断するのに役立ちます。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **デジタル証明書** は、公開鍵と個人を関連付ける電子的な資格情報です。信頼できる認証局 (CA) が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は発信元と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開いたり変更したりできるかを制御します。デジタル署名とは別物で、[パスワードで保護されたプレゼンテーション](/slides/ja/nodejs-java/password-protected-presentation/)で説明されています。

PowerPoint は **ファイル > 情報 > プレゼンテーションの保護** の下に **デジタル署名の追加** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「デジタル署名の追加」がハイライトされている画像](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知で、プレゼンテーションに有効な署名が含まれていることが示されています](digital-signature-status-in-powerpoint.png)

Aspose.Slides は [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) を介して署名を公開し、[DigitalSignatureCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/) に [DigitalSignature](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) オブジェクトが格納されます。1 つのプレゼンテーションに複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12`）には、X.509 証明書、秘密鍵、および証明書チェーンが含まれます。秘密鍵が署名作成を可能にします。アクセス可能な秘密鍵がない証明書は、プレゼンテーションに署名するために使用できません。

PFX のパスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開いたり編集したりするためのパスワードでは **ありません**。PFX ファイルやパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際の署名ワークフローでは、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して PPTX ファイルとして保存します。

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

結果を新しい名前で保存すると、署名されていない元ファイルが保持されます。[DigitalSignature.setComments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) で設定する値は署名の目的を記述するものであり、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込んだら、[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) が返す各アイテムを検査します。[DigitalSignature.isValid](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) メソッドは、埋め込まれた署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

以下の例では、Node.js の `X509Certificate` クラスを使用して、埋め込まれた各証明書からサブジェクト名を取得しています。

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

無効な結果は、署名後にプレゼンテーションコンテンツまたは署名データが変更されたか、ファイルが破損していることを意味することが多いです。すべての署名を削除すると署名なしのプレゼンテーションが残りますので、アイテムの有効性だけをチェックするのでは不十分です。セキュリティが重要なワークフローでは、期待する署名数と署名者 ID が存在することも検証する必要があります。

この有効性結果は、証明書の信頼性判断の全体とはみなさないでください。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期間・失効状態のチェック、期待するサブジェクトまたはフィンガープリントの確認、鍵使用目的の検証、信頼できるタイムスタンプの評価を行う必要があります。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignature/) の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除するとプレゼンテーションのセキュリティ状態が変化します。以下の例は署名された PPTX ファイルを読み込み、[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) で全署名を削除し、署名なしのコピーとして保存します。

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

1 つだけ署名を削除したい場合は、ゼロベースインデックスを指定して [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) を呼び出します。署名された元ファイルを上書きすることが明示的にワークフローの一部でない限り、結果は新しいファイルに保存してください。

## **編集と形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名済みコンテンツの変更は通常、既存の署名を無効にします。
- 署名前にすべての編集を完了してください。変更が必要な場合は、修正したプレゼンテーションを保存し、そのリビジョンに再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを他の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで求められる場合は、署名なしの元ファイルまたは別の管理コピーを保存しておいてください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は発信元と完全性の証拠を提供しますが、コンテンツは別途暗号化しない限り読み取り可能です。コンテンツへのアクセスを制限したい場合は、[パスワード保護](/slides/ja/nodejs-java/password-protected-presentation/) を使用してください。

**PFX のパスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX のパスワードは証明書パッケージ内の秘密鍵を解除するためのもので、PPTX ファイルを開いたり編集したりする権限を制御するものではありません。

**自己署名証明書は使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的に信頼しないため、明示的に信頼された環境に追加する必要があります。公的または組織横断的なワークフローでは、通常、信頼できる CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーションコンテンツや署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、ファイルは「無効な署名がある」状態ではなく「署名なし」の状態になります。

**有効な署名は署名者を信用すべきことを意味しますか？**

署名の有効性だけでは信用は判断できません。署名の完全性と署名者の信頼は別個の判断です。本番環境の検証ポリシーでは、証明書チェーン、期限、失効状態、期待する ID、鍵使用目的、信頼できるタイムスタンプの要件などもチェックすべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限切れはプレゼンテーションのバイト列を変更しませんが、証明書の信頼性評価に影響します。署名が受け入れ可能かどうかはポリシーと、署名時点が証明書の有効期間内であることを示す信頼できるタイムスタンプがあるかどうかに依存します。表示される署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションはまだ編集可能ですか？**

はい。署名はファイルをロックしません。署名済みコンテンツを編集すると既存の署名は通常無効になるため、最終版を先に完成させてから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) が返すコレクションに各署名を追加してください。検証時はすべての署名を調べ、必要な署名者が全員揃っていることを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートしているのは PPTX のみです。PPT および OpenDocument 形式のプレゼンテーションはこの API ワークフローではサポートされていません。

**署名を削除してもスライドに影響はありませんか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてからプレゼンテーションを保存すれば、スライド内容はそのままで、削除された署名の証拠だけが失われます。