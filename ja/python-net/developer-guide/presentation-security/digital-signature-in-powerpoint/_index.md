---
title: Pythonでプレゼンテーションにデジタル署名を追加
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/python-net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 証明書発行機関
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- Python
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、.NET を介した Python 用 Aspose.Slides でデジタル署名の検証や削除を行う方法を学びます。"
---
## **Overview**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、署名されたコンテンツが変更されていないかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です：

- **デジタル証明書** は、識別子と公開鍵を関連付ける電子クレデンシャルです。信頼できる認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者のプライベートキーから作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか編集できるかを制御します。これはデジタル署名とは別で、[Password-Protected Presentations](/python-net/password-protected-presentation/)で説明されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「Add a Digital Signature」がハイライトされている](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知で、プレゼンテーションに有効な署名が含まれていることを示す](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、署名を [Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) で公開し、項目が [DigitalSignature](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/) オブジェクトである [DigitalSignatureCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/) を提供します。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、拡張子は `.pfx` または `.p12` が一般的です）は、X.509 証明書、そのプライベートキー、および証明書チェーンを含むことができます。プライベートキーは署名者が署名を作成できるようにするものです。アクセス可能なプライベートキーを持たない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージとプライベートキーを保護します。これはプレゼンテーションを開くまたは編集するためのパスワード**ではありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアや別の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないために環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローで署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して PPTX ファイルとして保存します。

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

新しい名前で保存すると、未署名の元ファイルが保持されます。[DigitalSignature.comments](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/comments/) の値は署名の目的を記述するもので、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込むときは、[Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) 内のすべての項目を検査します。[DigitalSignature.is_valid](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/is_valid/) プロパティは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

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

無効な結果は、署名後にプレゼンテーションのコンテンツまたは署名データが変更された、あるいはファイルが破損していることを示すことが一般的です。すべての署名を削除すると未署名のプレゼンテーションになりますので、項目の有効性だけを確認しても不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

[DigitalSignature.certificate](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/certificate/) プロパティは証明書データをバイト配列として提供します。例ではその SHA-256 フィンガープリントを計算し、アプリケーションが期待する署名者証明書のフィンガープリントと比較できるようにしています。

この有効性の結果だけで、証明書の信頼性を完全に判断すべきではありません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効状態の確認、期待されるサブジェクトまたはサムプリントの確認、キー使用目的の検証、信頼できるタイムスタンプの評価も行う必要があります。[DigitalSignature.sign_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignature/sign_time/) の値単体は、信頼できるタイムスタンプ機関からの証明にはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変化します。以下の例は署名された PPTX ファイルを読み込み、[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーを保存します。

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

1 つだけ署名を削除したい場合は、[DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/ja/python-net/aspose.slides/digitalsignaturecollection/remove_at/) にゼロベースのインデックスを渡して呼び出します。署名されたオリジナルを上書きすることが明示的に必要な場合を除き、新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名済みコンテンツを変更すると通常は既存の署名が無効になります。
- 署名する前にすべての編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正後に保存し、改訂版に再度署名します。
- 最終出力は PPTX 形式のまま保持してください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として引き継がれません。
- 証明書のプライベートキーは機密情報として取り扱ってください。プライベートキーとパスワードを取得した者は、その証明書所有者になりすます署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合は、未署名の元ファイルまたは別の管理コピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は出所と完全性の証拠を提供しますが、プレゼンテーションの内容は暗号化されません。コンテンツへのアクセスを制限する必要がある場合は、[パスワード保護](/python-net/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージ内のプライベートキーを解除するためのもので、PPTX ファイルの開封や編集を制御するものではありません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能なプライベートキーを含む自己署名証明書を使用できます。ただし、受信者は自動的に信頼しないため、信頼できる環境に明示的に追加しなければなりません。組織間や公開のワークフローでは、信頼された CA が発行した証明書を使用するのが一般的です。

**署名が無効になる原因は何ですか？**

署名後にプレゼンテーションのコンテンツや署名データが変更された場合、またはファイルが破損した場合に署名が無効になります。すべての署名が削除されている場合は、無効な署名が残っているのではなく、単に未署名の状態です。

**有効な署名があるからといって、署名者を信頼すべきですか？**

署名の有効性だけで署名者を信頼すべきかは判断できません。信頼性の判断には、証明書チェーン、期限、失効状態、期待される身元、キー使用目的、信頼できるタイムスタンプなどの追加チェックが必要です。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限が切れてもプレゼンテーション自体のバイト列は変わりませんが、証明書の信頼性評価に影響します。署名が有効期限内に行われたことを示す信頼できるタイムスタンプがあるかどうかで、ポリシーに応じた取り扱いを決定してください。

**署名されたプレゼンテーションは編集できますか？**

可能です。署名はファイルをロックしませんが、署名済みコンテンツを編集すると既存の署名は通常無効になります。したがって、最終版を作成してから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に各署名を [Presentation.digital_signatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/digital_signatures/) に追加します。検証時にはすべての署名をチェックし、必要な署名者が全員揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートしているのは PPTX 形式のみです。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライド内容に影響を与えずに署名を削除できますか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてから保存すれば、スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。