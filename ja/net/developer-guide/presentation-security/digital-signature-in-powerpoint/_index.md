---
title: .NET でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証機関
- PFX 証明書
- PKCS#12
- 署名の検証
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- .NET
- C#
- Aspose.Slides
description: "既存の PPTX プレゼンテーションに PFX 証明書で署名し、.NET 用 Aspose.Slides を使用してデジタル署名を検証または削除する方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに誰が署名したか、および署名されたコンテンツが変更されているかを判断できるようにします。ここでは、次の3つの関連するセキュリティ概念が重要です。

- **digital certificate** は、身元と公開鍵を結び付ける電子的な資格情報です。信頼された認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **digital signature** は、プレゼンテーションのコンテンツと証明書所有者のプライベートキーから作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は、出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するわけではありません。
- **Password protection** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別で、[Password-Protected Presentations](/slides/ja/net/password-protected-presentation/)で説明されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の「Protect Presentation」メニューで「Add a Digital Signature」がハイライトされた画像](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションが開かれると、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/) (それは [IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/) で、アイテムは [IDigitalSignature](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/) を実装しています) を通じて署名を公開します。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、一般的に `.pfx` または `.p12` 拡張子が付く）は、X.509 証明書、そのプライベートキー、および証明書チェーンを含むことができます。プライベートキーは所有者が署名を作成できるようにするものです。アクセス可能なプライベートキーがない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージとプライベートキーを保護します。これはプレゼンテーションを開いたり編集したりするためのパスワード **not** ではありません。PFX ファイルやそのパスワードをソース管理にコミットしないでください。運用環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアやその他の保護された設定ソースから取得してください。以下の例では、コードにパスワードを埋め込まないように環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーションのワークフローに署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/net/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルとして保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

結果を新しい名前で保存すると、署名されていない元ファイルが保持されます。[DigitalSignature.Comments](https://reference.aspose.com/slides/ja/net/aspose.slides/digitalsignature/comments/) の値は署名の目的を記述しますが、これはセキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む際は、[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/) のすべての項目を検査します。[IDigitalSignature.IsValid](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/isvalid/) プロパティは、埋め込まれた署名が現在のプレゼンテーション内容に対して有効かどうかを示します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

無効な結果は、通常、署名されたプレゼンテーションのコンテンツまたは署名データが署名後に変更されたか、ファイルが破損していることを意味します。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけをチェックするだけでは不十分です。セキュリティが重要なワークフローでは、期待される署名数と期待される署名者の身元が存在することも検証する必要があります。

この有効性の結果だけを、証明書の信頼性に関する最終判断として扱ってはいけません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効状態の確認、期待されるサブジェクトまたはサムプリントの確認、キー使用法の検証、信頼できるタイムスタンプの評価も必要になる場合があります。[IDigitalSignature.SignTime](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/signtime/) の値だけでは、信頼できるタイムスタンプ機関からの証拠とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変わります。以下の例は、署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

1 つだけ署名を削除するには、ゼロベースのインデックスを指定して [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/removeat/) を呼び出します。ワークフローで署名済みのオリジナルを上書きすることが明示的に必要でない限り、新しいファイルに保存してください。

## **編集およびフォーマット上の考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常、既存の署名が無効になります。
- 署名する前にすべての意図した編集を完了してください。プレゼンテーションを変更する必要がある場合は、改訂版を保存し、その改訂版に再度署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として転送されません。
- 証明書のプライベートキーは機密情報として扱ってください。プライベートキーとそのパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで求められる場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は出所と完全性に関する証拠を提供しますが、別途暗号化を適用しない限りプレゼンテーションの内容は読み取り可能なままです。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/slides/ja/net/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージに保存されたプライベートキーのロックを解除します。PPTX ファイルを開く・編集できるユーザーを制御するものではありません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能なプライベートキーが含まれている限り、自己署名証明書を使用できます。ただし、受信者はその証明書を明示的に信頼できる環境に追加しない限り自動的に信頼しません。公共または組織間のワークフローでは、通常、信頼された CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**

署名後に署名されたプレゼンテーションのコンテンツまたは署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因となります。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれているわけではありません。

**有効な署名は署名者を信用すべきという意味ですか？**

それだけではありません。署名の完全性と署名者の信頼は別々の判断です。本番環境の検証ポリシーでは、証明書チェーン、期限、失効状態、期待される身元、キー使用法、信頼できるタイムスタンプ要件も確認すべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の期限切れはプレゼンテーションのバイト列を変更しませんが、証明書の信頼性評価に影響します。署名が許容されるかはポリシーと、署名時に証明書が有効であったことを示す有効な信頼タイムスタンプがあるかどうかによります。表示される署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションはまだ編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常、既存の署名が無効になるため、まずプレゼンテーションを完成させ、最終リビジョンに署名してください。

**プレゼンテーションは複数の署名を含められますか？**

はい。保存前に各署名を [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/) に追加します。検証時にはすべての署名を確認し、必要な署名者がすべて揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides はここで説明するデジタル署名操作を PPTX のみでサポートします。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされません。

**署名を削除してもスライドに影響はありませんか？**

はい。1 つの署名を削除するかコレクション全体をクリアしてからプレゼンテーションを保存できます。スライドのコンテンツはそのまま残りますが、保存されたファイルには削除された署名の証拠は含まれません。