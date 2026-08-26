---
title: Pythonでプレゼンテーションを書き込み保護
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/python-net/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPointの書き込み保護
- 変更用パスワード
- プレゼンテーションの編集制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint の PPT および PPTX プレゼンテーションに対する書き込み保護パスワードの設定、検出、検証、解除を行います。"
---
## **概要**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、内容を暗号化しません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションをロードして表示できます。アプリケーションによっては、内容を編集して別名で保存できる場合もあるため、書き込み保護は機密保持の手段として扱うべきではありません。

開封パスワードは別の目的を持ちます。プレゼンテーションを暗号化し、内容を読み込むために必要です。プレゼンテーションを暗号化したり開封パスワードを検証したりするには、[プレゼンテーションのパスワード保護](/slides/ja/python-net/password-protected-presentation/)をご覧ください。

この記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用できます。例では PPTX ファイルを使用しています。PPT に保存する場合は `.ppt` 拡張子と対応する PPT 保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションの変更用パスワードを割り当てるには、[ProtectionManager.set_write_protection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/set_write_protection/) を使用します。プレゼンテーションを保存すると、保護設定が永続化されます。

以下の例は PPTX プレゼンテーションに書き込み保護を設定します。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションの内容を暗号化しないため、プレゼンテーションを読み込む際にパスワードは不要です。パスワードが必要になるのは、保護されたプレゼンテーションの変更権限を検証する場合だけです。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

書き込み保護パスワードを [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に渡さないでください。このプロパティは暗号化されたコンテンツ用の開封パスワードを受け取ります。プレゼンテーションが両方の保護タイプを持つ場合、開封パスワードを使用してロードし、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションから書き込み保護を解除**

変更制限を解除するには、[ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/remove_write_protection/) を使用し、その後プレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションが書き込み保護されているかの確認**

完全な [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成せずにファイルを調べるには、[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を呼び出し、[PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/is_write_protected/) を確認します。このプロパティは [NullableBool](https://reference.aspose.com/slides/ja/python-net/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合は `NullableBool.TRUE` を返します。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) のストリームオーバーロードは、ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

完全なプレゼンテーションをロードせずに変更パスワードを検証するには、[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_write_protection/) を使用します。まず [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/is_write_protected/) を確認し、書き込み保護がある場合にのみアプリケーションがパスワードを要求または検証するようにします。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_write_protection/) は書き込み保護パスワードのみを検証します。開封パスワードの検証や暗号化されたコンテンツがロード可能かどうかは判断しません。逆に [PresentationInfo.check_password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/check_password/) は開封パスワードのみを検証します。すでに完全なプレゼンテーションがロードされている場合、[ProtectionManager.check_write_protection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/check_write_protection/) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返しの検証は避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="参照" %}}
- [プレゼンテーションのパスワード保護](/slides/ja/python-net/password-protected-presentation/)
- [読み取り専用プレゼンテーション](/slides/ja/python-net/read-only-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションの内容はロードおよび表示可能なままです。

**プレゼンテーションを開く際に書き込み保護パスワードは必要ですか？**

いいえ。暗号化されたプレゼンテーションの内容をロードするには開封パスワードのみが必要です。

**プレゼンテーションは開封パスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。開封パスワードはロードオプションを通じて提供し、書き込み保護パスワードは変更権限が必要なときに別途検証します。