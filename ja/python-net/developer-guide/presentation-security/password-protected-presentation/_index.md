---
title: Python を使用したパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/python-net/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロックを解除
- プレゼンテーションのロックを解除
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
description: "Aspose.Slides for Python via .NET を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。ステップバイステップのガイドで生産性を向上させ、プレゼンテーションを安全に保護できます。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対して次のような制限を設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの変更、編集、コピーを防ぎます。

  ただし、この場合でも、ユーザーはパスワードがなくてもドキュメントを開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの内容を閲覧させません。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けないユーザーは、変更や編集ができません。

  **注意**　開く制限を設定してパスワード保護すると、プレゼンテーションファイルは暗号化されます。

## パスワードでプレゼンテーションをオンラインで保護する方法

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページにアクセスします。  

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上で保護したいファイルを選択します。

4. 編集保護用の好きなパスワード、閲覧保護用の好きなパスワードを入力します。

5. プレゼンテーションを最終版として提示したい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**
**対応フォーマット**

Aspose.Slides は次のフォーマットのプレゼンテーションに対して、パスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT – Microsoft PowerPoint プレゼンテーション  
- ODP – OpenDocument プレゼンテーション  
- OTP – OpenDocument プレゼンテーションテンプレート  

**サポートされる操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するパスワード保護を使用できます。

- プレゼンテーションの暗号化  
- プレゼンテーションへの書き込み保護の設定  

**その他の操作**

Aspose.Slides では、パスワード保護と暗号化に関するその他のタスクを次のように実行できます。

- プレゼンテーションの復号化／暗号化されたプレゼンテーションの開く  
- 暗号化の解除／パスワード保護の無効化  
- プレゼンテーションから書き込み保護を削除  
- 暗号化されたプレゼンテーションのプロパティ取得  
- プレゼンテーションが暗号化されているかのチェック  
- プレゼンテーションがパスワードで保護されているかのチェック  

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

暗号化またはパスワード保護を行うには、[ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) の `encrypt` メソッドを使用してプレゼンテーションにパスワードを設定します。`encrypt` メソッドにパスワードを渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

以下のサンプルコードはプレゼンテーションを暗号化する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションへの書き込み保護の設定** 

「変更しないでください」というマークをプレゼンテーションに追加できます。これにより、ユーザーに対してプレゼンテーションの変更を許可しない旨を伝えられます。

**注意**　書き込み保護プロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更したい場合はプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、`set_write_protection` メソッドを使用します。以下のサンプルコードは書き込み保護を設定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションの復号化／暗号化されたプレゼンテーションの開く**

Aspose.Slides はパスワードを渡すことで暗号化ファイルを読み込めます。プレゼンテーションを復号化するには、パラメータなしの `remove_encryption` メソッドを呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションをロードします。

以下のサンプルコードはプレゼンテーションを復号化する方法を示しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **暗号化の解除／パスワード保護の無効化**

プレゼンテーションの暗号化やパスワード保護を解除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスしたり変更したりできます。

暗号化やパスワード保護を解除するには、`remove_encryption` メソッドを呼び出します。以下のサンプルコードは暗号化を解除する方法を示しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションから書き込み保護を削除する**

Aspose.Slides を使用して、プレゼンテーションファイルに設定された書き込み保護を削除できます。これにより、ユーザーは好きなように変更でき、警告も表示されません。

`remove_write_protection` メソッドを使用して書き込み保護を削除します。以下のサンプルコードは書き込み保護を削除する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しながら、ユーザーがそのプロパティにアクセスできる仕組みを提供します。

**注意**　Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後でもプロパティへのアクセスを可能にしたい場合、Aspose.Slides はそれを実現できます。

暗号化されたプレゼンテーションのプロパティにアクセスできるようにしたい場合は、`EncryptDocumentProperties` プロパティを `True` に設定します。以下のサンプルコードは、プロパティへのアクセスを許可しながらプレゼンテーションを暗号化する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **プレゼンテーションをロードする前にパスワード保護かどうか確認する**

プレゼンテーションをロードする前に、パスワードで保護されていないか確認したいことがあります。これにより、パスワード保護されたプレゼンテーションをパスワードなしでロードしようとして発生するエラーや問題を回避できます。

以下の Python コードは、プレゼンテーションを実際にロードせずにパスワード保護かどうか調べる方法を示しています。

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides はプレゼンテーションが暗号化されているかをチェックできます。このタスクを実行するには、`is_encrypted` プロパティを使用します。暗号化されていれば `True`、されていなければ `False` が返ります。

以下のサンプルコードはプレゼンテーションが暗号化されているか確認する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides はプレゼンテーションが書き込み保護されているかをチェックできます。このタスクを実行するには、`is_write_protected` プロパティを使用します。書き込み保護されていれば `True`、されていなければ `False` が返ります。

以下のサンプルコードはプレゼンテーションが書き込み保護されているか確認する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **特定のパスワードがプレゼンテーション保護に使用されているか検証する**

特定のパスワードがプレゼンテーションに使用されているか確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

以下のサンプルコードはパスワードを検証する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 「pass」が一致するかチェック
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

`True` が返された場合、プレゼンテーションは指定したパスワードで暗号化されています。そうでない場合は `False` が返ります。

{{% alert color="primary" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートしている暗号化方式は何ですか？**  
Aspose.Slides は AES ベースのアルゴリズムなど、最新の暗号化方式をサポートしており、プレゼンテーションのデータを高度に保護します。

**プレゼンテーションを開く際に間違ったパスワードを入力した場合はどうなりますか？**  
間違ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**  
暗号化および復号化プロセスにより、開く・保存する際に若干のオーバーヘッドが発生することがあります。多くの場合、この影響は最小限であり、プレゼンテーション全体の処理時間に大きな影響はありません。