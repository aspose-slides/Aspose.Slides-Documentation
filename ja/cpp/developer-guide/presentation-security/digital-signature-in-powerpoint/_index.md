---
title: C++ でプレゼンテーションにデジタル署名を追加する
linktitle: デジタル署名
type: docs
weight: 10
url: /ja/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、C++ 用 Aspose.Slides でデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに署名した人物と、署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、関連する3つのセキュリティ概念が重要です。

- **デジタル証明書** は、身元と公開鍵を結びつける電子資格情報です。信頼された認証局 (CA) が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書保持者の秘密鍵から作成されます。その後、証明書の公開鍵を使用して署名を検証できます。署名は出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するわけではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別であり、[Password-Protected Presentations](/slides/ja/cpp/password-protected-presentation/) で説明されています。

PowerPoint は、**File > Info > Protect Presentation** の下にある **Add a Digital Signature** コマンドを提供します。

![Add a Digital Signature がハイライトされた PowerPoint の Protect Presentation メニュー](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションが開かれると、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) を介して署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの項目は [IDigitalSignature](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションは複数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイルは PKCS#12 ファイルとしても知られ、一般に `.pfx` または `.p12` 拡張子が付与されます。X.509 証明書、秘密鍵、証明書チェーンを格納できます。秘密鍵は保持者が署名を作成できるようにします。アクセス可能な秘密鍵を持たない証明書は、プレゼンテーションに署名するために使用できません。

PFX パスワードは証明書パッケージと秘密鍵を保護しますが、プレゼンテーションを開くまたは編集するためのパスワードでは **ありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレット ストアや他の保護された構成ソースから取得してください。以下の例では、パスワードをコードに埋め込まないために環境変数のみを使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション ワークフローに署名するには、既存の PPTX ファイルをロードし、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/cpp/aspose.slides/digitalsignature/) を作成し、署名をプレゼンテーションのコレクションに追加して、PPTX ファイルとして保存します。

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

新しい名前で結果を保存すると、署名されていない元ファイルが保持されます。[IDigitalSignature::set_Comments](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/set_comments/) の値は署名の目的を示すもので、セキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルをロードしたときは、[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) が返すすべての項目を検査します。[IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/get_isvalid/) メソッドは、埋め込まれた署名が現在のプレゼンテーション コンテンツに対して有効かどうかを示します。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

無効な結果は、署名後にプレゼンテーション コンテンツまたは署名データが変更された、あるいはファイルが破損していることを意味することが一般的です。すべての署名を削除すると署名のないプレゼンテーションが生成されるため、項目の有効性だけをチェックするだけでは不十分です。セキュリティが重要なワークフローでは、期待される署名数と署名者の身元が揃っていることも確認する必要があります。

この有効性の結果だけを証明書の信頼判定の全体と見なすべきではありません。セキュリティ ポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限や失効ステータスの確認、期待されるサブジェクトまたはサムプリントの照合、キー使用目的の検証、信頼できるタイムスタンプの評価も行う必要があります。[IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/get_signtime/) の値だけでは、信頼できるタイムスタンプ機関からの証拠とはなりません。

## **デジタル署名の削除**

署名を削除するとプレゼンテーションのセキュリティ状態が変化します。以下の例は署名された PPTX ファイルをロードし、[IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/clear/) で全署名を削除し、署名のないコピーを保存します。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

1 つだけ署名を削除する場合は、ゼロベースのインデックスを指定して [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/removeat/) を呼び出します。署名された元ファイルを上書きすることが明示的なワークフローの一部でない限り、新しいファイルに保存してください。

## **編集と形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常既存の署名が無効になります。
- 署名する前にすべての意図した編集を完了してください。プレゼンテーションを変更する必要がある場合は、改訂版を保存し、再度署名します。
- 最終出力は PPTX 形式のまま保持してください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルに有効な署名として引き継がれません。
- 証明書の秘密鍵は機密情報として扱ってください。秘密鍵とそのパスワードを取得した者は、その証明書保持者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで求められる場合は、署名されていない元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**

いいえ。デジタル署名は起源と完全性に関する証拠を提供しますが、別途暗号化が施されていない限りプレゼンテーションの内容は読み取り可能です。コンテンツへのアクセスを制限する必要がある場合は、[password protection](/slides/ja/cpp/password-protected-presentation/) を使用してください。

**PFX パスワードはプレゼンテーションのパスワードと同じですか？**

いいえ。PFX パスワードは証明書パッケージ内の秘密鍵をロック解除するためのもので、PPTX ファイルを開いたり編集したりする権限を制御するものではありません。

**自己署名証明書を使用できますか？**

技術的には、アクセス可能な秘密鍵を含む自己署名証明書は使用できます。ただし、受信者は自動的に信頼しないため、信頼された環境に明示的に追加しない限り、一般的な公開または組織間ワークフローでは信頼された CA が発行した証明書が使用されます。

**署名が無効になる理由は何ですか？**

署名後にプレゼンテーション コンテンツまたは署名データを変更すると署名が無効になります。ファイルの破損も検証失敗の原因です。すべての署名が削除された場合、そのプレゼンテーションは「署名なし」の状態となり、無効な署名が残っているわけではありません。

**有効な署名は、署名者を信頼すべきことを意味しますか？**

署名の有効性だけでは署名者の信頼性は判断できません。運用上の検証ポリシーでは、証明書チェーン、期限、失効状態、期待される署名者の身元、キー使用目的、必要に応じた信頼できるタイムスタンプの確認も行うべきです。

**証明書が期限切れになるとどうなりますか？**

証明書の有効期限はプレゼンテーションのバイト列を変更しませんが、証明書の信頼評価に影響します。署名が有効とみなされるかはポリシーと、署名時に証明書が有効であったことを示す信頼できるタイムスタンプがあるかに依存します。表示される署名時刻だけを信頼できるタイムスタンプとして利用しないでください。

**署名されたプレゼンテーションはまだ編集できますか？**

はい。署名はファイルをロックしません。署名されたコンテンツを編集すると通常既存の署名が無効になるため、最終版を完成させてから署名してください。

**プレゼンテーションに複数の署名を含められますか？**

はい。保存前に [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) が返すコレクションに各署名を追加します。検証時にはすべての署名を調べ、必要な署名者が全員揃っていることを確認してください。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**

Aspose.Slides がここで説明するデジタル署名操作をサポートするのは PPTX 形式のみです。PPT および OpenDocument のプレゼンテーション形式はこの API ワークフローではサポートされません。

**署名を削除してもスライドは影響を受けませんか？**

はい。1 つの署名だけを削除するか、コレクション全体をクリアしてから保存すれば、スライドの内容はそのまま残りますが、保存されたファイルには削除された署名の証拠は残りません。