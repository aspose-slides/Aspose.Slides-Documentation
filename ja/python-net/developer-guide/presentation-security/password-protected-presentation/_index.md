---
title: Pythonでプレゼンテーションをパスワード保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/python-net/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニング パスワード
- PowerPoint を暗号化
- PowerPoint を復号化
- プレゼンテーション パスワードを検証
- プレゼンテーション パスワードをチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化を解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

オープニング パスワードはプレゼンテーションを暗号化します。正しいパスワードが必要で、プレゼンテーションのコンテンツを読み込み表示できるため、この保護は機密性を提供します。

オープニング パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/python-net/write-protected-presentation/) を参照してください。

以下のワークフローは PPT および PPTX のプレゼンテーションの両方に適用されます。例では、ファイルベースとストリームベースの動作が重要な場合に両方の形式を使用しています。

## **オープニング パスワードでプレゼンテーションを暗号化**

オープニング パスワードを割り当てるには [ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/encrypt/) を使用します。その後、暗号化されたプレゼンテーションを保存するには [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を使用します。

次の例は PPTX プレゼンテーションを暗号化します:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **暗号化されたプレゼンテーションの読み込み**

[LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) にオープニング パスワードを設定し、ファイルを読み込む際にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) に渡します。オープニング パスワードが必要なのにパスワードが未提供または正しくない場合、読み込みは失敗します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで作業します。
    pass
```

## **プレゼンテーションから暗号化を解除**

プレゼンテーションをオープニング パスワードで読み込み、[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/remove_encryption/) を呼び出して結果を保存します。保存されたプレゼンテーションはその後、パスワードなしで読み込むことができます。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **読み込み前にオープニング パスワードを検証**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用して、完全なプレゼンテーション インスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/) を取得します。パスワードの要求または検証を行う前に [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/is_password_protected/) を確認してください。保護が存在する場合、提供された値を [PresentationInfo.check_password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_password/) で検証します。

### **ファイル パス ワークフロー**

次の例は PPTX ファイルのオープニング パスワードを検証し、検証済みの値を [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に渡して、完全なプレゼンテーションを読み込みます:

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

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) のストリームオーバーロードは同じワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します:

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_password/) は、プレゼンテーションにオープニング パスワードが設定されており、提供されたパスワードが正しい場合にのみ `True` を返します。次の場合は `False` を返します:

- パスワードが正しくありません。
- プレゼンテーションにオープニング パスワードが設定されていません。
- 提供されたパスワードが `None` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **読み込まれたプレゼンテーションが暗号化されているか確認**

正しいパスワードでプレゼンテーションを読み込んだ後、[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/is_encrypted/) を確認して、元のプレゼンテーションが暗号化されていることを確認します。読み込み前にオープニング パスワード保護を検出するには、上記のように `PresentationInfo.is_password_protected` を使用します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="セキュリティ" %}}
オープニング パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返し検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択するかアップロードします。
3. 表示保護用のパスワードを入力します。
4. 必要に応じて、編集保護用の別のパスワードを入力します。
5. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="関連項目" %}}
- [Write-Protect Presentations](/slides/ja/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**オープニング パスワードと書き込み保護パスワードの違いは何ですか？**

オープニング パスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずにオープニング パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニング パスワード保護があるか確認し、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証します。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイル パスとストリームベースのパスワード検出および検証は、PPT と PPTX のプレゼンテーションで同様に動作します。