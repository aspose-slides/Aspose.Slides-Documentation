---
title: Python でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、Java 経由で Python 用 Aspose.Slides を利用してデジタル署名を検証または削除する方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、および署名されたコンテンツが変更されたかどうかを判断できるようにします。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **デジタル証明書** は、識別子と公開鍵を結び付ける電子クレデンシャルです。信頼できる証明書機関 (CA) が証明書を発行することも、組織が内部ワークフロー用に自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。証明書の公開鍵を使用して署名を検証できます。署名は発信元と完全性の証拠を提供しますが、プレゼンテーションを暗号化はしません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別であり、[パスワード保護されたプレゼンテーション](/slides/ja/python-java/password-protected-presentation/)で説明しています。

PowerPoint は **ファイル > 情報 > プレゼンテーションの保護** メニューの **デジタル署名の追加** コマンドを提供します。

![PowerPoint Protect Presentation メニューでデジタル署名の追加がハイライトされた状態](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知: プレゼンテーションに有効な署名が含まれています](digital-signature-status-in-powerpoint.png)

Aspose.Slides は [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDigitalSignatures) を介して署名を公開し、これにより [DigitalSignatureCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignaturecollection/) が返されます。そのコレクションの各項目は [DigitalSignature](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignature/) のインスタンスです。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12`）は、X.509 証明書、秘密鍵、および証明書チェーンを含めることができます。秘密鍵が署名作成を可能にします。アクセス可能な秘密鍵が無い証明書は、プレゼンテーションに署名できません。

PFX パスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開いたり編集したりするためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。実稼働環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレット ストアやその他の保護された設定ソースから取得してください。以下のサンプルは、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションにデジタル署名を追加する**

実際の署名ワークフローでは、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignature/) を作成し、プレゼンテーションのコレクションに署名を追加してから PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

結果を新しい名前で保存すると、未署名の元ファイルが残ります。[DigitalSignature.setComments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignature/#setComments) で設定する値は署名の目的を記述するものであり、セキュリティ コントロールではありません。

## **デジタル署名の検証**

署名された PPTX ファイルをロードしたら、[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDigitalSignatures) が返すすべての項目を調べます。[DigitalSignature.isValid](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignature/#isValid) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

無効な結果は、署名後にプレゼンテーション コンテンツまたは署名データが変更された、あるいはファイルが破損したことを意味することが一般的です。すべての署名を削除すると未署名のプレゼンテーションになりますので、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待する署名数と署名者の ID が存在することも検証する必要があります。

この有効性の結果だけで証明書の信頼性を完全に判断すべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効状態のチェック、期待するサブジェクトまたはサムプリントの確認、キー使用目的の確認、信頼できるタイムスタンプの評価も行う必要があります。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignature/#getSignTime) のみでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除するとプレゼンテーションのセキュリティ状態が変わります。以下の例では、署名された PPTX ファイルを読み込み、[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignaturecollection/#clear) で全署名を削除し、未署名のコピーとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

1 つだけ署名を削除したい場合は、ゼロベースのインデックスを指定して [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/digitalsignaturecollection/#removeAt) を呼び出します。ワークフローで明示的に元の署名付きファイルを上書きする必要がない限り、新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常は既存の署名が無効になります。
- 署名前にすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正後のプレゼンテーションを保存し、改訂版に再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱います。秘密鍵とそのパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで求められる場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は発信元と完全性の証拠を提供しますが、コンテンツは別途暗号化しない限り読み取り可能です。コンテンツへのアクセスを制限する必要がある場合は、[パスワード保護されたプレゼンテーション](/slides/ja/python-java/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージ内の秘密鍵を解除するためのものであり、PPTX ファイルを開いたり編集したりする権限を制御しません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれていれば自己署名証明書を使用できます。ただし、受信者は自動的に信頼しません。信頼できる環境に明示的に追加しない限り、一般的な公開または組織横断ワークフローでは信頼できる CA が発行した証明書が使用されます。

**署名が無効になる条件は何ですか？**

署名後にプレゼンテーション コンテンツまたは署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれるわけではありません。

**有効な署名は署名者を信頼すべきことを意味しますか？**

それだけでは判断できません。署名の完全性と署名者の信頼は別々の判断です。運用上の検証ポリシーでは、証明書チェーン、期間、失効状態、期待する ID、キー使用目的、信頼できるタイムスタンプ要件も確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限切れはプレゼンテーションのバイト列を変更しませんが、証明書の信頼評価に影響します。署名が有効かどうかはポリシーと、署名時に証明書が有効であったことを示す信頼できるタイムスタンプがあるかに依存します。表示される署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常は既存の署名が無効になるため、最終版を完成させてから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDigitalSignatures) が返すコレクションにそれぞれの署名を追加します。検証時にはすべての署名を調べ、必須の署名者が全員揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートするのは PPTX のみです。PPT や OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドの内容に影響を与えずに署名を削除できますか？**

はい。1 つの署名を削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。