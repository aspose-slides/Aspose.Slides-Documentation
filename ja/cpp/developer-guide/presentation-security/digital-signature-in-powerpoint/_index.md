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
description: "PFX 証明書を使用して既存の PPTX プレゼンテーションに署名し、C++ 用 Aspose.Slides を使ってデジタル署名の検証または削除を行う方法を学びます。"
---
## **概要**

デジタル署名は、受信者がプレゼンテーションに署名した人物と、署名されたコンテンツが変更されたかどうかを判断するのに役立ちます。ここでは、次の3つの関連するセキュリティ概念が重要です：

- **デジタル証明書** は、識別子と公開鍵を結び付ける電子クレデンシャルです。信頼された認証局（CA）が証明書を発行することも、組織が内部ワークフロー向けに自己署名証明書を使用することもできます。
- **デジタル署名** は、プレゼンテーションのコンテンツと証明書所有者の秘密鍵から作成されます。証明書の公開鍵を使用して署名を検証できます。署名は、出所と完全性の証拠を提供しますが、プレゼンテーションを暗号化するものではありません。
- **パスワード保護** は、ユーザーがプレゼンテーションを開くか変更できるかを制御します。これはデジタル署名とは別で、[パスワード保護されたプレゼンテーション](/cpp/password-protected-presentation/)で説明されています。

PowerPoint は、**ファイル > 情報 > プレゼンテーションの保護** の下にある **デジタル署名の追加** コマンドを提供します。

![PowerPoint の「プレゼンテーションの保護」メニューで「デジタル署名の追加」がハイライトされている様子](add-digital-signature-in-powerpoint.png)

署名されたプレゼンテーションを開くと、PowerPoint は署名ステータスの通知を表示できます。

![プレゼンテーションに有効な署名が含まれていることを示す PowerPoint の通知](digital-signature-status-in-powerpoint.png)

Aspose.Slides は、[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) を通じて署名を公開し、[IDigitalSignatureCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/) を返します。このコレクションの項目は [IDigitalSignature](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/) を実装しています。プレゼンテーションは�数の署名を含めることができます。

## **PFX 証明書とパスワードの理解**

PFX ファイルは PKCS#12 ファイルとも呼ばれ、通常は `.pfx` または `.p12` 拡張子が付けられます。このファイルには X.509 証明書、秘密鍵、証明書チェーンが含まれる場合があります。秘密鍵は所有者が署名を作成できるようにするものです。アクセス可能な秘密鍵がない証明書は、プレゼンテーションに署名するために使用できません。

PFX のパスワードは証明書パッケージと秘密鍵を保護します。これはプレゼンテーションを開くまたは編集するためのパスワード **ではありません**。PFX ファイルやそのパスワードをソース管理にコミットしないでください。本番環境では、証明書ファイルへのアクセスを制限し、パスワードはシークレットストアや他の保護された構成ソースから取得してください。以下の例では、コードにパスワードを埋め込まないように環境変数を使用しています。

## **プレゼンテーションへのデジタル署名の追加**

実際のプレゼンテーション署名フローでは、既存の PPTX ファイルを読み込み、PFX 証明書とそのパスワードから [DigitalSignature](https://reference.aspose.com/slides/ja/cpp/aspose.slides/digitalsignature/) を作成し、プレゼンテーションのコレクションに署名を追加して、PPTX ファイルとして保存します。

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

結果を別名で保存すると、未署名の元ファイルが保持されます。[IDigitalSignature::set_Comments](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/set_comments/) の値は署名の目的を記述しますが、これはセキュリティ制御ではありません。

## **デジタル署名の検証**

署名された PPTX ファイルを読み込む際は、[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) が返す各項目を検査します。[IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/get_isvalid/) メソッドは、埋め込まれた署名が現在のプレゼンテーションコンテンツに対して有効かどうかを示します。

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

無効な結果は、署名後にプレゼンテーションのコンテンツや署名データが変更された、またはファイルが破損していることを示すことが一般的です。すべての署名を削除すると未署名のプレゼンテーションが生成されるため、項目の有効性だけを確認するだけでは不十分です。セキュリティ上重要なワークフローでは、期待される署名数と署名者の身元が存在することも検証する必要があります。

この有効性結果だけを証明書信頼の最終判断として扱ってはいけません。セキュリティポリシーに応じて、アプリケーションは X.509 証明書チェーンの構築と検証、証明書の有効期限と失効状態のチェック、期待されるサブジェクトやサムプリントの確認、キー使用法の検証、そして信頼できるタイムスタンプの評価も必要になる場合があります。[IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignature/get_signtime/) の値だけでは、信頼できるタイムスタンプ機関からの証明とはなりません。

## **デジタル署名の削除**

署名を削除すると、プレゼンテーションのセキュリティ状態が変化します。次の例では、署名された PPTX ファイルを読み込み、[IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/clear/) で全署名を削除し、未署名のコピーを保存します。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

1 つだけ署名を削除するには、[IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idigitalsignaturecollection/removeat/) にゼロベースのインデックスを指定して呼び出します。ワークフローで署名された元ファイルを上書きすることが明示的に必要でない限り、新しいファイルに保存してください。

## **編集および形式に関する考慮事項**

- 署名はプレゼンテーションを読み取り専用にしません。ユーザーやアプリケーションは引き続きファイルを編集できますが、署名されたコンテンツを変更すると通常、既存の署名は無効になります。
- 署名する前にすべての意図した編集を完了してください。プレゼンテーションを変更する必要がある場合は、改訂版を保存し、再度その改訂版に署名します。
- 最終出力は PPTX 形式のままにしてください。署名されたプレゼンテーションを別の形式に変換しても、元の PPTX 署名は変換後のファイルの有効な署名として転送されません。
- 証明書の秘密鍵は機密情報として取り扱ってください。秘密鍵とそのパスワードを取得した者は、その証明書所有者になりすました署名を作成できる可能性があります。
- 文書保持ポリシーで要求される場合、未署名の元ファイルまたは別の管理されたコピーを保持してください。

## **FAQ**

**デジタル署名はプレゼンテーションを暗号化しますか？**  
いいえ。デジタル署名は出所と完全性に関する証拠を提供しますが、別途暗号化が適用されない限りプレゼンテーションの内容は読み取れたままです。コンテンツへのアクセスを制限する必要がある場合は、[パスワード保護](/cpp/password-protected-presentation/) を使用してください。

**PFX のパスワードはプレゼンテーションのパスワードと同じですか？**  
いいえ。PFX のパスワードは証明書パッケージに保存された秘密鍵のロックを解除します。これは PPTX ファイルを開くまたは編集できるユーザーを制御するものではありません。

**自己署名証明書を使用できますか？**  
技術的には、アクセス可能な秘密鍵を含む自己署名証明書は使用可能です。ただし、受信者の信頼された環境に明示的に追加されていない限り、自動的に信頼されることはありません。公共または組織間のワークフローでは、通常、信頼された CA が発行した証明書が使用されます。

**署名が無効になる原因は何ですか？**  
署名後にプレゼンテーションのコンテンツや署名データを変更すると、署名は無効になります。ファイルの破損も検証失敗の原因となります。すべての署名が削除された場合、プレゼンテーションは無効な署名を含むファイルではなく、未署名の状態になります。

**有効な署名は、署名者を信頼すべきことを意味しますか？**  
それだけではありません。署名の完全性と署名者の信頼は別々の判断です。本番環境の検証ポリシーでは、証明書チェーン、有効期間、失効状態、期待される身元、キー使用法、そして信頼できるタイムスタンプの要件も確認すべきです。

**証明書が期限切れになるとどうなりますか？**  
証明書の期限切れはプレゼンテーションのバイト列を変更しませんが、証明書信頼の評価に影響します。署名が受け入れ可能かどうかは、ポリシーと、署名が証明書有効期間中に行われたことを示す有効な信頼タイムスタンプがあるかどうかに依存します。表示される署名時間だけを信頼できるタイムスタンプとして使用しないでください。

**署名されたプレゼンテーションは編集できますか？**  
はい。署名はファイルをロックしません。署名されたコンテンツを編集すると、通常、既存の署名は無効になるため、まずプレゼンテーションを完成させ、最終版に署名してください。

**プレゼンテーションに複数の署名を含めることはできますか？**  
はい。保存する前に、[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_digitalsignatures/) が返すコレクションに各署名を追加してください。検証時にはすべての署名を検査し、必要な署名者がすべて揃っていることを確認します。

**どのプレゼンテーション形式がこれらの操作をサポートしていますか？**  
Aspose.Slides は、ここで説明するデジタル署名操作を PPTX のみでサポートします。PPT および OpenDocument プレゼンテーション形式は、この API ワークフローではサポートされていません。

**スライドに影響を与えずに署名を削除できますか？**  
はい。1 つの署名を削除するか、コレクション全体をクリアしてからプレゼンテーションを保存できます。スライドの内容は残りますが、保存されたファイルには削除された署名の証拠は残りません。