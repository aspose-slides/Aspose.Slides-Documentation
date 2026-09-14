---
title: Python でプレゼンテーションの書き込み保護
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/python-java/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーション編集の制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint の PPT および PPTX プレゼンテーションに書き込み保護パスワードを設定、検出、検証、解除します。"
---
## **はじめに**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、コンテンツを暗号化しません。ユーザーは書き込み保護されたプレゼンテーションをパスワードなしで読み込み、表示できます。アプリケーションによっては、コンテンツを編集して別名で保存できる場合もあるため、書き込み保護は機密性の手段として扱うべきではありません。

開くためのパスワードは別の目的を持ちます。プレゼンテーションを暗号化し、コンテンツの読み込みに必要です。プレゼンテーションを暗号化するか、開くためのパスワードを検証する方法は、[Password-Protect Presentations](/slides/ja/python-java/password-protected-presentation/)をご参照ください。

この記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例は PPTX ファイルを使用しています。PPT 形式で保存する場合は、拡張子 `.ppt` と対応する PPT 保存形式を使用してください。

## **プレゼンテーションに書き込み保護を設定する**

[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#setWriteProtection) を使用して、プレゼンテーションの変更用パスワードを割り当てます。プレゼンテーションを保存すると、保護設定が永続化されます。

次の例は PPTX プレゼンテーションに書き込み保護を設定します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **書き込み保護されたプレゼンテーションを読み込む**

書き込み保護はプレゼンテーションのコンテンツを暗号化しないため、読み込み時にパスワードは必要ありません。パスワードは、保護されたプレゼンテーションの変更権限を検証する際にのみ関連します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) に書き込み保護パスワードを渡さないでください。このメソッドは暗号化されたコンテンツ用の開くためのパスワードを受け取ります。プレゼンテーションに両方の保護タイプがある場合は、開くためのパスワードを指定して読み込み、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションから書き込み保護を削除する**

[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#removeWriteProtection) を使用して変更制限を解除し、プレゼンテーションを保存します。

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **プレゼンテーションが書き込み保護されているか確認する**

完全な [Presentation](/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを調べるには、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を呼び出し、[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#isWriteProtected) を確認します。このメソッドは [NullableBool](/slides/ja/python-java/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合は `NullableBool.True_` を返します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) のストリームオーバーロードは、ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードを検証する**

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#checkWriteProtection) を使用して、プレゼンテーション全体を読み込まずに変更パスワードを検証できます。まず [PresentationInfo.isWriteProtected](/slides/ja/python-java/aspose.slides/presentationinfo/#isWriteProtected) を確認し、書き込み保護が存在する場合にのみパスワードの要求または検証を行ってください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](/slides/ja/python-java/aspose.slides/presentationinfo/#checkWriteProtection) は書き込み保護パスワードのみを検証し、開くためのパスワードや暗号化コンテンツの読み込み可否は確認しません。対照的に、[PresentationInfo.checkPassword](/slides/ja/python-java/aspose.slides/presentationinfo/#checkPassword) は開くためのパスワードのみを検証します。すでにプレゼンテーション全体が読み込まれている場合は、[ProtectionManager.checkWriteProtection](/slides/ja/python-java/aspose.slides/protectionmanager/#checkWriteProtection) が同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な検証の繰り返しを避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/ja/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/ja/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションのコンテンツは読み込みや表示のために利用可能なままです。

**書き込み保護パスワードはプレゼンテーションを開くために必要ですか？**

いいえ。暗号化されたプレゼンテーションのコンテンツを読み込むには、開くためのパスワードのみが必要です。

**プレゼンテーションは開くためのパスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開く際はロードオプションで開くためのパスワードを指定し、変更権限が必要なときに書き込み保護パスワードを別途検証してください。