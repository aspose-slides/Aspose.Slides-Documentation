---
title: Python でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、.NET 経由で Python 用 Aspose.Slides を使用してデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、署名されたコンテンツが変更されたかを判断できるようにします。ここでは、次の 3 つの関連するセキュリティ概念が重要です。

- **デジタル証明書** は、身元と公開鍵を結び付ける電子クレデンシャルです。信頼できる認証局 (CA) が証明書を発行することも、組織が内部ワークフロー用に自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。その後、証明書の公開鍵を使って署名を検証できます。署名は発信元と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別物で、[Password-Protected Presentations](/slides/ja/python-net/password-protected-presentation/) に記載されています。

PowerPoint は **File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の「保護されたプレゼンテーション」メニューで「Add a Digital Signature」が強調表示されている画像](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知でプレゼンテーションに有効な署名が含まれていることが示されている画像](digital-signature-status-in-powerpoint.png)

Aspose.Slides は署名を [Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) という [DigitalSignatureCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/) で公開し、各項目は [DigitalSignature](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/) オブジェクトです。1 つのプレゼンテーションに複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12`）は、X.509 証明書、秘密鍵、および証明書チェーンを格納できます。秘密鍵は所有者が署名を作成するために必要です。アクセス可能な秘密鍵がない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージと秘密鍵を保護します。これはプレゼンテーションを開くまたは編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアまたはその他の保護された構成ソースから取得してください。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションにデジタル署名を追加する**

実際のプレゼンテーションワークフローで署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して PPTX ファイルとして保存します。

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

結果を新しい名前で保存すると、署名されていない元ファイルが保護されます。 [DigitalSignature.comments](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/comments/) の値は署名の目的を記述しますが、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込んだら、[Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) 内のすべての項目を検査します。 [DigitalSignature.is_valid](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/is_valid/) プロパティは、埋め込まれた署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

無効な結果は、署名後にプレゼンテーションコンテンツまたは署名データが変更された、またはファイルが破損したことを意味することが一般的です。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

[DigitalSignature.certificate](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/certificate/) プロパティは証明書データをバイト配列として提供します。例では SHA-256 フィンガープリントを計算し、アプリケーションが期待する署名者証明書のフィンガープリントと比較できるようにしています。

この有効性の結果だけで証明書の信頼性を完全に判断すべきではありません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効ステータスの確認、期待されるサブジェクトまたはサムプリントの確認、キー使用目的の検証、信頼できるタイムスタンプの評価も行う必要があります。 [DigitalSignature.sign_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/sign_time/) の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変化します。以下の例では署名された PPTX ファイルを読み込み、[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーとして保存します。

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

1 つだけ署名を削除したい場合は、ゼロベースのインデックスを指定して [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/remove_at/) を呼び出します。署名された元ファイルを上書きすることが明示的なワークフローの一部でない限り、必ず新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名対象のコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前にすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正版を保存して再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として扱います。秘密鍵とそのパスワードを取得した者は、当該証明書所有者になりすました署名を作成できる可能性があります。
- 文書保存ポリシーで求められる場合は、未署名の元ファイルまたは別の管理コピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は発信元と完全性の証拠を提供しますが、プレゼンテーションの内容は別途暗号化しない限り読み取り可能なままです。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/slides/ja/python-net/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージに格納された秘密鍵を解除するためのもので、PPTX ファイルを開くまたは編集できるかは制御しません。

**自己署名証明書は使用できますか？**

技術的には、アクセス可能な秘密鍵が含まれている限り自己署名証明書を使用できます。ただし、受信者が自動的に信頼するわけではなく、明示的に信頼された環境に追加されている必要があります。公開または組織横断的なワークフローでは、通常、信頼された CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーションのコンテンツや署名データを変更すると署名は無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名を含むファイルとは異なります。

**有効な署名は署名者を信用すべきことを意味しますか？**

それだけではありません。署名の完全性と署名者の信頼は別々の判断です。本番環境の検証ポリシーでは、証明書チェーン、期限、失効ステータス、期待される身元、キー使用目的、必要に応じた信頼できるタイムスタンプなども確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の期限切れはプレゼンテーションのバイト列を変更しませんが、証明書の信頼性評価に影響します。署名が有効かどうかはポリシーと、信頼できるタイムスタンプが署名時点で証明書が有効であったことを示すかに依存します。表示される署名時刻だけを信頼できるタイムスタンプとして扱わないでください。

**署名されたプレゼンテーションは編集可能ですか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると既存の署名は通常無効になるため、最終版を作成してから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に各署名を [Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) に追加します。検証時はすべての署名を確認し、必要な署名者がすべて存在することを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明したデジタル署名操作をサポートしているのは PPTX 形式のみです。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**署名を削除してもスライドに影響はありませんか？**

はい。1 つの署名を削除するかコレクション全体をクリアしてからプレゼンテーションを保存すれば、スライドコンテンツはそのままで、保存されたファイルに署名の証拠は残りません。