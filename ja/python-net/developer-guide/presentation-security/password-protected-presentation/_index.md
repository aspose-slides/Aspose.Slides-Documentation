---
title: Python を使用したパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/python-net/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロック解除
- プレゼンテーションのロック解除
- PowerPoint を保護
- プレゼンテーションを保護
- パスワードを設定
- パスワードを追加
- PowerPoint を暗号化
- プレゼンテーションを暗号化
- PowerPoint を復号化
- プレゼンテーションを復号化
- 書き込み保護
- PowerPoint のセキュリティ
- プレゼンテーションのセキュリティ
- パスワードを削除
- 保護を削除
- 暗号化を削除
- パスワードを無効化
- 保護を無効化
- 書き込み保護を削除
- PowerPoint プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。生産性を向上させ、ステップバイステップのガイドでプレゼンテーションを安全に保護できます。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して次のような制限を設定できます。

- **変更**

  特定のユーザーにのみプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの変更、編集、コピーができなくなります。

  ただし、この場合でもパスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどのコンテンツを見ることはできますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーにのみプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容さえ表示できなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開くことができなければ、変更や編集もできません。

  **注意** パスワードでプレゼンテーションを保護して開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## プレゼンテーションをオンラインでパスワード保護する方法

1. 当社の[**Aspose.Slides ロック**](https://products.aspose.app/slides/ja/lock)ページへ移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用の希望パスワードと閲覧保護用の希望パスワードを入力します。

5. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**最終版としてマーク** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides のプレゼンテーション向けパスワード保護**
### **サポート形式**

Aspose.Slides は以下の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

### **サポート操作**

Aspose.Slides は次の方法でプレゼンテーションの変更を防止するためのパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

### **その他の操作**

Aspose.Slides はパスワード保護と暗号化に関連する他のタスクも次のように実行できます。

- プレゼンテーションの復号化；暗号化されたプレゼンテーションの開く
- 暗号化の除去；パスワード保護の無効化
- プレゼンテーションから書き込み保護を除去
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかのチェック
- プレゼンテーションがパスワード保護されているかのチェック

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/protectionmanager/) の `encrypt` メソッドを使用してパスワードを設定します。`encrypt` メソッドにパスワードを渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションの暗号化方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションに「変更しないでください」というマークを付けることができます。これにより、ユーザーに変更を望まない旨を通知できます。

**注意** 書き込み保護はプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには `setWriteProtection` メソッドを使用します。このサンプルコードはプレゼンテーションへの書き込み保護の設定方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションの復号化；暗号化されたプレゼンテーションの開く**

Aspose.Slides はパスワードを渡すことで暗号化されたファイルをロードできます。プレゼンテーションを復号化するには、パラメータなしの `remove_encryption` メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションをロードします。

このサンプルコードはプレゼンテーションの復号化方法を示しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **暗号化の除去；パスワード保護の無効化**

プレゼンテーションから暗号化またはパスワード保護を除去できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を除去するには `remove_encryption` メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を除去する方法を示しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションから書き込み保護を除去**

Aspose.Slides を使用してプレゼンテーションファイルに付加された書き込み保護を除去できます。これにより、ユーザーは自由に変更でき、警告も表示されません。

書き込み保護を除去するには `remove_write_protection` メソッドを使用します。このサンプルコードは書き込み保護の除去方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。しかし、Aspose.Slides は暗号化されたままでもプロパティにアクセスできる機構を提供します。

**注意:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、ドキュメントプロパティもパスワード保護されます。暗号化後もプロパティを利用可能にしたい場合、`ProtectionManager` の `encrypt_document_properties` プロパティを `False` に設定します。このサンプルコードは暗号化しつつプロパティにアクセスできる方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみをロード**

スライドやその他のコンテンツをロードせずに暗号化されたプレゼンテーションのメタデータを確認するには、`LoadOptions` オブジェクトを作成し、`only_load_document_properties` を `True` に設定します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティだけをロードします。

以下のコード例は組み込みドキュメントプロパティとカスタムドキュメントプロパティを `Presentation.document_properties` で読み取り、列挙します。

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # 組み込みドキュメントプロパティを読み取ります。
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # カスタムドキュメントプロパティを一覧表示します。
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

このワークフローは、暗号化時にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。プロパティが暗号化されている場合、`only_load_document_properties` を `True` に設定すると例外がスローされます。暗号化されたプロパティにアクセスするか、スライドやその他のコンテンツも含めて完全にロードしたい場合は、`LoadOptions` の `password` に正しいパスワードを指定してください。

## **ロード前にプレゼンテーションがパスワード保護されているか確認する方法**

プレゼンテーションをロードする前に、パスワードで保護されていないか確認したいことがあります。これにより、パスワード保護されたプレゼンテーションをパスワードなしでロードしようとして発生するエラーや問題を回避できます。

この Python コードは、プレゼンテーションを実際にロードせずにパスワード保護されているかどうかを調べる方法を示しています。

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **プレゼンテーションが暗号化されているかのチェック**

Aspose.Slides はプレゼンテーションが暗号化されているかどうかをチェックできます。このタスクには `is_encrypted` プロパティを使用します。暗号化されていれば `True`、されていなければ `False` が返ります。

このサンプルコードはプレゼンテーションが暗号化されているかをチェックする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **プレゼンテーションが書き込み保護されているかのチェック**

Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかをチェックできます。このタスクには `is_write_protected` プロパティを使用します。書き込み保護されていれば `True`、されていなければ `False` が返ります。

このサンプルコードはプレゼンテーションが書き込み保護されているかをチェックする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **特定のパスワードがプレゼンテーション保護に使用されたかの検証**

特定のパスワードがプレゼンテーションに使用されたか確認したい場合、Aspose.Slides はパスワードの検証手段を提供します。

このサンプルコードはパスワードを検証する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # "pass" が一致するか確認
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

正しいパスワードで暗号化されていれば `True`、それ以外は `False` が返ります。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES などの最新暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化・復号化の処理により、開く・保存する際に若干のオーバーヘッドが発生することがあります。多くの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響はありません。