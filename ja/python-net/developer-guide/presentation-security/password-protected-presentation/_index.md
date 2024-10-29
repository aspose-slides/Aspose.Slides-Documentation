---
title: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /ja/python-net/password-protected-presentation/
keywords: "PowerPointのロック、PowerPointの解除、PowerPointの保護、パスワードの設定、パスワードの追加、PowerPointの暗号化、PowerPointの復号化、書き込み保護、PowerPointのセキュリティ、PowerPointプレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointのパスワード保護、暗号化、およびセキュリティ"

---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションをパスワード保護すると、特定の制限を強制するパスワードを設定することを意味します。制限を解除するには、パスワードを入力する必要があります。パスワード保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対してこれらの制限を強制するためにパスワードを設定できます：

- **変更**

  特定のユーザーのみがプレゼンテーションを変更できるようにしたい場合、変更制限を設定できます。ここでの制限は、ユーザーがプレゼンテーションの内容を変更、変更、またはコピーすることを防ぎます（パスワードを提供しない限り）。

  ただし、この場合、パスワードなしでも、ユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内の内容や物—ハイパーリンク、アニメーション、効果など—を表示できますが、アイテムをコピーしたり、プレゼンテーションを保存したりすることはできません。

- **オープニング**

  特定のユーザーのみがプレゼンテーションを開けるようにしたい場合、オープニング制限を設定できます。ここでの制限は、ユーザーがプレゼンテーションの内容を表示することすら防ぎます（パスワードを提供しない限り）。

  技術的には、オープニング制限はユーザーがプレゼンテーションを変更することも防ぎます：人々がプレゼンテーションを開けない場合、変更や修正を行うことはできません。

  **注意**: プレゼンテーションのオープンを防ぐためにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## オンラインでプレゼンテーションをパスワード保護する方法

1. [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドラッグまたはアップロード**をクリックします。

3. コンピュータ上でパスワード保護したいファイルを選択します。

4. 編集保護のために希望のパスワードを入力し、表示保護のために希望のパスワードを入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを表示させたい場合は、**最終としてマーク**のチェックボックスにチェックを入れます。

6. **今すぐ保護**をクリックします。

7. **今すぐダウンロード**をクリックします。

## **Aspose.Slidesにおけるプレゼンテーションのパスワード保護**
**サポートされているフォーマット**

Aspose.Slidesは、次のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、および同様の操作をサポートしています：

- PPTXおよびPPT - Microsoft PowerPointプレゼンテーション
- ODP - OpenDocumentプレゼンテーション
- OTP - OpenDocumentプレゼンテーションテンプレート

**サポートされている操作**

Aspose.Slidesは、次の方法でプレゼンテーションの変更を防ぐためにパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slidesは、次の方法でパスワード保護と暗号化を含む他のタスクを実行できます：

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションを開く
- 暗号化を解除; パスワード保護を無効にする
- プレゼンテーションから書き込み保護を解除
- 暗号化されたプレゼンテーションのプロパティを取得
- プレゼンテーションが暗号化されているかどうかを確認
- プレゼンテーションがパスワード保護されているかどうかを確認

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。次に、ロックされたプレゼンテーションを変更するには、ユーザーがパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、encryptメソッド（[ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)から）を使用して、プレゼンテーションのパスワードを設定する必要があります。パスワードをencryptメソッドに渡し、saveメソッドを使用して今や暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションに「変更しないでください」というマークを追加できます。こうすることで、ユーザーに対してプレゼンテーションを変更しないでほしいことを伝えることができます。

**注意**: 書き込み保護のプロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは—実際にそうしたい場合—プレゼンテーションを変更できますが、変更を保存するには異なる名前のプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、setWriteProtectionメソッドを使用する必要があります。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションの復号化; 暗号化されたプレゼンテーションを開く**

Aspose.Slidesは、パスワードを渡すことで暗号化されたファイルをロードすることを許可します。プレゼンテーションを復号化するには、[remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)メソッドをパラメータなしで呼び出す必要があります。その後、プレゼンテーションをロードするために正しいパスワードを入力する必要があります。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **暗号化の解除; パスワード保護の無効化**

プレゼンテーションの暗号化またはパスワード保護を解除することができます。こうすることで、ユーザーは制限なしにプレゼンテーションにアクセスしたり、変更したりできるようになります。

暗号化やパスワード保護を解除するには、[remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションからの書き込み保護の解除**

Aspose.Slidesを使用してプレゼンテーションファイルにかけられた書き込み保護を解除できます。こうすることで、ユーザーは好きなように変更でき、そうしたタスクを実行する際に警告を受けることはありません。

[remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)メソッドを使用してプレゼンテーションから書き込み保護を解除できます。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **暗号化されたプレゼンテーションのプロパティを取得する**

通常、ユーザーは暗号化されたまたはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションをパスワード保護しながら、そのプロパティにアクセスする手段をユーザーに提供するメカニズムを提供します。

**注意**: Aspose.Slidesがプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。しかし、プレゼンテーションのプロパティにアクセスできるようにしたい場合（プレゼンテーションが暗号化された後でも）、Aspose.Slidesはそれを正確に行うことを許可します。

暗号化されたプレゼンテーションのプロパティへのアクセスを保持したい場合、[EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)プロパティを`True`に設定できます。このサンプルコードは、プロパティへのアクセス手段を提供しながらプレゼンテーションを暗号化する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **プレゼンテーションをロードする前にパスワード保護されているか確認する**

プレゼンテーションをロードする前に、そのプレゼンテーションがパスワードで保護されていないことを確認することを希望するかもしれません。こうすることで、パスワード保護されたプレゼンテーションがパスワードなしでロードされた際に発生するエラーや同様の問題を回避できます。

このPythonコードは、プレゼンテーションがパスワード保護されているかどうかを確認する方法を示しています（プレゼンテーション自体をロードせずに）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("プレゼンテーションはパスワード保護されています: " + str(presentationInfo.is_password_protected))
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slidesは、プレゼンテーションが暗号化されているかどうかを確認することを許可します。このタスクを実行するには、[is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)プロパティを使用できます。これは、プレゼンテーションが暗号化されている場合は`True`を、暗号化されていない場合は`False`を返します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slidesは、プレゼンテーションが書き込み保護されているかどうかを確認することを許可します。このタスクを実行するには、[is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)プロパティを使用できます。これは、プレゼンテーションが暗号化されている場合は`True`を、暗号化されていない場合は`False`を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **特定のパスワードがプレゼンテーションを保護するために使用されたかを検証または確認する**

特定のパスワードがプレゼンテーションドキュメントを保護するために使用されたかを確認したいかもしれません。Aspose.Slidesは、パスワードの検証手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # "pass"が一致するか確認する
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

指定したパスワードでプレゼンテーションが暗号化されている場合は`True`を返します。それ以外の場合は`False`を返します。

{{% alert color="primary" title="関連情報" %}} 
- [PowerPointにおけるデジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}