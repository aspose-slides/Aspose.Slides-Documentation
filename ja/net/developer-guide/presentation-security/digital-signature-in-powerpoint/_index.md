---
title: .NET でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/net/digital-signature-in-powerpoint/
keywords:
- デジタル署名
- デジタル証明書
- 認証局
- PFX 証明書
- PKCS#12
- 署名を検証する
- PowerPoint
- PPTX
- プレゼンテーションのセキュリティ
- .NET
- C#
- Aspose.Slides
description: "PFX 証明書で既存の PPTX プレゼンテーションに署名し、.NET 向け Aspose.Slides を使用してデジタル署名の検証や削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに署名した人物と、署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です:

- **デジタル証明書**は、身元と公開鍵を結びつける電子クレデンシャルです。信頼された証明機関(CA)が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名**は、プレゼンテーションのコンテンツと証明書所有者のプライベートキーから作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は、出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護**は、ユーザーがプレゼンテーションを開くまたは編集できるかどうかを制御します。これはデジタル署名とは別で、[Password-Protected Presentations](/net/password-protected-presentation/)で説明されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![PowerPoint の保護プレゼンテーション メニュー（Add a Digital Signature がハイライトされている）](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![PowerPoint の通知（プレゼンテーションに有効な署名が含まれていることを示す）](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、署名を [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/)（[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/) の項目が [IDigitalSignature](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/) を実装）として公開します。プレゼンテーションは複数の署名を含むことができます。

## **PFX 証明書とパスワードの理解**

PFX ファイル（PKCS#12 ファイルとも呼ばれ、通常は `.pfx` または `.p12` 拡張子が付けられます）は、X.509 証明書、そのプライベートキー、および証明書チェーンを含むことができます。プライベートキーは、所有者が署名を作成できるようにするものです。アクセス可能なプライベートキーがない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージとプライベートキーを保護します。これはプレゼンテーションを開いたり編集したりするためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアまたは他の保護された設定ソースから取得します。以下の例では、コードにパスワードを埋め込まないよう環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーションワークフローに署名するには、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/net/aspose.slides/digitalsignature/) を作成し、その署名をプレゼンテーションのコレクションに追加して、PPTX ファイルとして保存します。

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

結果を新しい名前で保存すると、未署名の元ファイルが保護されます。[DigitalSignature.Comments](https://reference.aspose.com/slides/ja/net/aspose.slides/digitalsignature/comments/) の値は署名の目的を記述しますが、これはセキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込むときは、[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/) のすべての項目を検査します。[IDigitalSignature.IsValid](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/isvalid/) プロパティは、埋め込まれた署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

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

無効な結果は、通常、署名後にプレゼンテーションのコンテンツまたは署名データが変更された、あるいはファイルが破損していることを意味します。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけを確認するだけでは不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

この有効性の結果だけで、証明書の信頼性に関する完全な判断を行うべきではありません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効ステータスの確認、期待されるサブジェクトやサムプリントの確認、鍵使用目的の検証、信頼できるタイムスタンプの評価も必要になる場合があります。[IDigitalSignature.SignTime](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignature/signtime/) の値だけでは、信頼されたタイムスタンプ機関からの証拠とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変化します。以下の例では、署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーとして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

1 つだけ署名を削除するには、ゼロベースのインデックスを指定して [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ja/net/aspose.slides/idigitalsignaturecollection/removeat/) を呼び出します。ワークフローで署名済みの元ファイルを上書きすることが明示的に必要でない限り、新しいファイルに保存してください。

## **編集とフォーマットに関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションはファイルを引き続き編集できますが、署名されたコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前に、すべての意図した編集を完了してください。プレゼンテーションを変更する必要がある場合は、修正版を保存し、再度署名してください。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として転送されません。
- 証明書のプライベートキーは機密情報として扱ってください。プライベートキーとそのパスワードを取得した者は、その証明書所有者からのものと見なされる署名を作成できる可能性があります。
- ドキュメント保存ポリシーで要求される場合は、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **よくある質問**

**デジタル署名はプレゼンテーションを暗号化しますか？**  
いいえ。デジタル署名は出所と完全性に関する証拠を提供しますが、別途暗号化を施さない限りプレゼンテーションの内容は読めたままです。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/net/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**  
いいえ。PFX パスワードは証明書パッケージに格納されたプライベートキーのロックを解除するものです。PPTX ファイルを開いたり編集したりできる人物を制御するものではありません。

**自己署名証明書は使用できますか？**  
技術的には、アクセス可能なプライベートキーを含む自己署名証明書は使用できます。ただし、受信者がその証明書を信頼できる環境に明示的に追加しない限り、自動的に信頼されることはありません。一般に、公開または組織横断のワークフローでは、信頼された CA が発行した証明書が使用されます。

**何が署名を無効にしますか？**  
署名後にプレゼンテーションのコンテンツや署名データを変更すると、署名が無効になります。ファイルの破損も検証失敗の原因となります。すべての署名が削除された場合、プレゼンテーションは未署名となり、無効な署名が含まれるファイルではありません。

**有効な署名は署名者を信頼すべきことを意味しますか？**  
それだけではありません。署名の完全性と署名者の信頼は別々の判断です。本番環境の検証ポリシーでは、証明書チェーン、有効期間、失効状態、期待される身元、鍵使用目的、信頼できるタイムスタンプ要件なども確認すべきです。

**証明書が期限切れになるとどうなりますか？**  
証明書の有効期限切れはプレゼンテーションのバイト列を変更しませんが、証明書の信頼性評価に影響します。署名が許容されるかどうかは、ポリシーと、有効な信頼タイムスタンプが署名時に証明書が有効であったことを示すかどうかに依存します。表示される署名時刻だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションはまだ編集できますか？**  
はい。署名はファイルをロックしません。署名されたコンテンツを編集すると、通常、既存の署名は無効になるため、先にプレゼンテーションを完成させ、最終版に署名してください。

**プレゼンテーションに複数の署名を含めることはできますか？**  
はい。保存前に各署名を [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/digitalsignatures/) に追加します。検証時にはすべての署名を検査し、必要な署名者が全員揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**  
Aspose.Slides は、ここで説明したデジタル署名操作を PPTX のみでサポートします。PPT および OpenDocument プレゼンテーション形式はこの API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**  
はい。1 つの署名を削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容は保持されますが、保存されたファイルには削除された署名の証拠は残りません。