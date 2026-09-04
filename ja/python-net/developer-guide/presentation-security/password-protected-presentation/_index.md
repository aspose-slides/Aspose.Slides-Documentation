---
title: Python でプレゼンテーションをパスワード保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/python-net/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPoint の暗号化
- PowerPoint の復号
- プレゼンテーションパスワードの検証
- プレゼンテーションパスワードのチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化の解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python でパスワード保護された PowerPoint の PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号します。"
---
## **概要**

オープンパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションの内容をロードして表示できるため、この保護は機密性を提供します。

オープンパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションのロードを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/python-net/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要な場合に両方の形式を使用しています。

## **オープンパスワードでプレゼンテーションを暗号化する**

オープンパスワードを設定するには、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/encrypt/) を使用します。その後、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を使用して暗号化されたプレゼンテーションを保存します。

次の例は PPTX プレゼンテーションを暗号化します。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **ドキュメントプロパティを公開する**

デフォルトでは、Aspose.Slides はプレゼンテーションの暗号化に文書プロパティを含めます。スライドコンテンツの暗号化とは独立してこの動作を制御するのが[ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) プロパティです。インデックス作成、分類、検索、または文書管理システムがオープンパスワードなしでメタデータを読み取る必要がある場合は、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/encrypt/) を呼び出す前にこれを `False` に設定します。

次の例は、組み込みの文書プロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

`encrypt_document_properties` を `False` に設定しても、スライド、マスター、レイアウト、シェイプ、メディア、またはその他のプレゼンテーションコンテンツが公開されるわけではありません。影響を受けるのは文書プロパティのみです。暗号化されたコンテンツをロードせずにこれらのプロパティを読み取るには、[Manage Presentation Properties](/slides/ja/python-net/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションをロードする**

オープンパスワードを [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に設定し、ファイルをロードする際にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) に渡します。オープンパスワードが必要なのに提供されたパスワードが欠如しているか間違っている場合、ロードは失敗します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 復号されたプレゼンテーションで作業します。
    pass
```

## **プレゼンテーションから暗号化を解除する**

オープンパスワードでプレゼンテーションをロードし、[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/remove_encryption/) を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしでロードできるようになります。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ロード前にオープンパスワードを検証する**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用して、完全なプレゼンテーションインスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/) を取得します。パスワードの要求または検証の前に、[PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/is_password_protected/) を確認します。保護が存在する場合、提供された値を [PresentationInfo.check_password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_password/) で検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルのオープンパスワードを検証し、検証された値を [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に渡してから、完全なプレゼンテーションをロードします。

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **ストリーム ワークフロー**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) のストリームオーバーロードは同じワークフローを提供します。そのストリームから完全なプレゼンテーションをロードする前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します。

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword の戻り値**

[PresentationInfo.check_password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_password/) は、プレゼンテーションにオープンパスワードが設定され、提供されたパスワードが正しい場合にのみ `True` を返します。次のいずれかの場合は `False` を返します。

- パスワードが正しくない。
- プレゼンテーションにオープンパスワードが設定されていない。
- 提供されたパスワードが `None` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **ロードしたプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションをロードした後、[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/is_encrypted/) を確認して、元のプレゼンテーションが暗号化されていることを確認します。ロード前にオープンパスワード保護を検出するには、上記のように `PresentationInfo.is_password_protected` を使用します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
オープンパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返しの検証試行は避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐにロードする際は成功した検証結果を再利用してください。

プレゼンテーションのコンテンツが暗号化されていても、公開された文書プロパティは作者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値などを漏洩させる可能性があります。機密メタデータはプレゼンテーションとともに暗号化してください。プロパティを公開したままにするのは、システムがオープンパスワードなしでファイルをインデックス付け、分類、検索、または管理しなければならない場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を設定する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択またはアップロードします。
1. 閲覧保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/python-net/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**オープンパスワードと書き込み保護パスワードの違いは何ですか？**

オープンパスワードはプレゼンテーションを暗号化し、コンテンツをロードするために必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドをロードせずにオープンパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープンパスワード保護が存在するか確認し、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証してください。

**アプリケーションはオープンパスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションが `encrypt_document_properties` を `False` に設定して暗号化された場合に限ります。その場合、アプリケーションは [Manage Presentation Properties](/slides/ja/python-net/presentation-properties/) で説明されている文書プロパティのみのロードモードを使用する必要があります。

**パスワード検証ワークフローは PPT と PPTX の両方をサポートしていますか？**

はい。ファイルパスとストリームベースのパスワード検出および検証は、PPT と PPTX のプレゼンテーションで同じように動作します。