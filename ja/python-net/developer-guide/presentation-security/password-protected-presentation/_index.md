---
title: Python を使用したパスワード保護付きプレゼンテーションのセキュリティ
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
description: "Aspose.Slides for Python (via .NET) を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびロック解除する方法を学びましょう。生産性を高め、ステップバイステップのガイドでプレゼンテーションを安全に保護できます。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して次のようにパスワードを設定して制限を課すことができます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーション内の変更、編集、コピーを防止します。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツやハイパーリンク、アニメーション、エフェクトなどを見ることができますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの開封を許可したい場合、開封制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの内容を閲覧さえできなくします。

  技術的には、開封制限はプレゼンテーションの変更も防止します。プレゼンテーションを開くことができなければ、変更や編集も行えません。

  **Note** パスワード保護により開封を防止した場合、プレゼンテーションファイルは暗号化されます。

## オンラインでプレゼンテーションにパスワード保護を設定する方法

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページへ移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード**をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用に希望のパスワードを入力します；閲覧保護用に希望のパスワードを入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを表示させたい場合は、**Mark as final**チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**
### **サポートされている形式**
Aspose.Slides は以下の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

### **サポートされている操作**
Aspose.Slides は以下の方法でプレゼンテーションへの変更を防止するためにパスワード保護を利用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

### **その他の操作**
Aspose.Slides は以下の方法でパスワード保護や暗号化に関わるその他のタスクを実行できます。

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションの開封
- 暗号化の削除; パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除する
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているか確認する
- プレゼンテーションがパスワードで保護されているか確認する。

## **プレゼンテーションの暗号化**
パスワードを設定することでプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) の encrypt メソッドを使用してプレゼンテーションにパスワードを設定します。パスワードを encrypt メソッドに渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **プレゼンテーションへの書き込み保護の設定**
「変更しないでください」というマークをプレゼンテーションに追加できます。これにより、ユーザーに対してプレゼンテーションの変更を希望しないことを伝えることができます。

**Note** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更したい場合はプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、setWriteProtection メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **プレゼンテーションの復号化; 暗号化されたプレゼンテーションの開封**
Aspose.Slides はパスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしで [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込む必要があります。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```


## **暗号化の削除; パスワード保護の無効化**
プレゼンテーションの暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を削除するには、[remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を削除する方法を示しています:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **プレゼンテーションから書き込み保護を削除する**
Aspose.Slides を使用してプレゼンテーションファイルに設定された書き込み保護を削除できます。これにより、ユーザーは好きなように変更でき、タスク実行時に警告が表示されなくなります。

書き込み保護を削除するには、[remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を削除する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **暗号化されたプレゼンテーションのプロパティ取得**
通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しながら、ユーザーがそのプロパティにアクセスできる仕組みを提供します。

**Note** Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後もプロパティへのアクセスを可能にしたい場合、Aspose.Slides はその機能を提供します。

暗号化したプレゼンテーションのプロパティへのアクセスを保持したい場合は、[EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) プロパティを `True` に設定します。このサンプルコードは、プロパティへのアクセスを可能にしながらプレゼンテーションを暗号化する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```


## **読み込む前にプレゼンテーションがパスワードで保護されているか確認する**
プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込む際に発生するエラーや類似の問題を回避できます。

この Python コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```


## **プレゼンテーションが暗号化されているか確認する**
Aspose.Slides はプレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、暗号化されていれば `True`、されていなければ `False` を返す [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) プロパティを使用します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```


## **プレゼンテーションが書き込み保護されているか確認する**
Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、書き込み保護されていれば `True`、されていなければ `False` を返す [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) プロパティを使用します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```


## **特定のパスワードがプレゼンテーションの保護に使用されたか検証または確認する**
特定のパスワードがプレゼンテーションの保護に使用されたかどうかを確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # "pass" が一致するか確認
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```


指定されたパスワードでプレゼンテーションが暗号化されていれば `True` を返します。そうでなければ `False` を返します。

{{% alert color="primary" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**
**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際にパフォーマンスへの影響はありますか？**

暗号化および復号化のプロセスにより、開く時や保存時に若干のオーバーヘッドが発生する場合がありますが、ほとんどのケースでその影響は最小限であり、全体的な処理時間に大きな影響はありません。