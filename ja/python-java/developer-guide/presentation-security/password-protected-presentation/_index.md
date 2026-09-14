---
title: Python でプレゼンテーションにパスワード保護をかける
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/python-java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPoint の暗号化
- PowerPoint の復号
- プレゼンテーションパスワードの検証
- プレゼンテーションパスワードのチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化の削除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号します。"
---
## **概要**

オープニングパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションのコンテンツをロードおよび表示できるため、この保護は機密性を提供します。

オープニングパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションのロードを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/python-java/write-protected-presentation/)をご覧ください。

以下のワークフローは PPT および PPTX のプレゼンテーションの両方に適用されます。例では、ファイルベースとストリームベースの動作が重要な場合に両方の形式を使用しています。

## **オープニングパスワードでプレゼンテーションを暗号化する**

[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#encrypt) を使用してオープニングパスワードを割り当てます。次に [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を使用して暗号化されたプレゼンテーションを保存します。

次の例は PPTX プレゼンテーションを暗号化します：
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ドキュメントプロパティを公開したままにする**

既定では、Aspose.Slides はプレゼンテーションの暗号化にドキュメントプロパティも含めます。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) メソッドは、スライドコンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムがオープニングパスワードなしでメタデータを読み取る必要がある場合は、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#encrypt) を呼び出す前に `False` を渡してください。

次の例は、組み込みのドキュメントプロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します：
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`False` を [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に渡しても、スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーションコンテンツが公開されるわけではありません。影響を受けるのはドキュメントプロパティのみです。暗号化されたコンテンツをロードせずにそれらのプロパティを読み取るには、[Manage Presentation Properties](/slides/ja/python-java/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションをロードする**

[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) にオープニングパスワードを設定し、ファイルをロードする際にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) に渡します。オープニングパスワードが必要なのに提供されたパスワードが不足しているか誤っている場合、ロードは失敗します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # 復号されたプレゼンテーションで作業する。
    pass
finally:
    presentation.dispose()
```

## **プレゼンテーションから暗号化を削除する**

オープニングパスワードでプレゼンテーションをロードし、[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#removeEncryption) を呼び出して結果を保存します。保存されたプレゼンテーションはその後、パスワードなしでロードできます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ロード前にオープニングパスワードを検証する**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、完全なプレゼンテーションインスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) を取得します。パスワードの要求または検証を行う前に [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#isPasswordProtected) を確認してください。保護が存在する場合、[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#checkPassword) で提供された値を検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルのオープニングパスワードを検証し、検証された値を [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) に渡してから、完全なプレゼンテーションをロードします：
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **ストリーム ワークフロー**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) のストリームオーバーロードも同様のワークフローを提供します。そのストリームから完全なプレゼンテーションをロードする前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用しています：
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword の戻り値**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#checkPassword) は、プレゼンテーションがオープニングパスワードを持ち、提供されたパスワードが正しい場合にのみ `True` を返します。次のいずれかのケースでは `False` を返します：

- パスワードが正しくありません。
- プレゼンテーションにオープニングパスワードが設定されていません。
- 提供されたパスワードが `None` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **ロードされたプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションをロードした後、[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isEncrypted) を確認して、元のプレゼンテーションが暗号化されていたことを確認します。ロード前にオープニングパスワード保護を検出するには、上記のように [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#isPasswordProtected) を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
オープニングパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返しの検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションを直ちにロードする際には成功した検証結果を再利用してください。

プレゼンテーションのコンテンツが暗号化されていても、公開されたドキュメントプロパティは著者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値などを明らかにする可能性があります。機密メタデータはプレゼンテーションと一緒に暗号化してください。プロパティを公開したままにすることは、システムがオープニングパスワードなしでファイルをインデックス、分類、検索、または管理しなければならない場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護をかける**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択するかアップロードします。
1. 表示保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニングパスワードと書き込み保護パスワードの違いは何ですか？**

オープニングパスワードはプレゼンテーションを暗号化し、コンテンツのロードに必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドをロードせずにオープニングパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニングパスワード保護が存在するか確認し、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証してください。

**オープニングパスワードなしでアプリケーションがメタデータを読み取れますか？**

はい、ただしプレゼンテーションがドキュメントプロパティの暗号化を無効にして暗号化された場合に限ります。その場合、アプリケーションは [Manage Presentation Properties](/slides/ja/python-java/presentation-properties/) に記載されたドキュメントプロパティのみのロードモードを使用する必要があります。

**パスワード検証ワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。