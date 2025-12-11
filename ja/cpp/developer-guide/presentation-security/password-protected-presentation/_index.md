---
title: C++ でパスワードによるプレゼンテーションの保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/cpp/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロックを解除
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
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよび解除する方法をご紹介します。プレゼンテーションを保護しましょう。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を実施するパスワードが設定されます。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して次のような制限を実施するパスワードを設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーション内の項目を変更、変更、コピーすることを防ぎます。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーだけにプレゼンテーションのオープンを許可したい場合、開く制限を設定できます。この制限は、パスワードを提供しない限り、プレゼンテーションの内容を閲覧することすら防ぎます。

  技術的には、開く制限はプレゼンテーションの変更も防ぎます。プレゼンテーションを開くことができなければ、変更や編集を行うことはできません。  

  **Note** パスワードでプレゼンテーションを保護して開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワードを設定する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)ページへ移動します。 

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。 

4. 編集保護用に希望のパスワードを入力します; 表示保護用に希望のパスワードを入力します。 

5. ユーザーにプレゼンテーションを最終版として表示させたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。 

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**
**サポートされる形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX と PPT - Microsoft PowerPoint プレゼンテーション 
- ODP - OpenDocument プレゼンテーション 
- OTP - OpenDocument プレゼンテーションテンプレート 

**サポートされる操作**

Aspose.Slides は、次の方法でプレゼンテーションへの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、次の方法でパスワード保護や暗号化に関わるその他のタスクを実行できます。

- プレゼンテーションの復号化; 暗号化されたプレゼンテーションのオープン
- 暗号化の削除; パスワード保護の無効化
- プレゼンテーションからの書き込み保護の削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認。

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager) の encrypt メソッドを使用してプレゼンテーションにパスワードを設定します。encrypt メソッドにパスワードを渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションの暗号化方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```


## **プレゼンテーションに書き込み保護を設定する** 

「変更しないでください」というマークをプレゼンテーションに追加できます。この方法で、ユーザーに対してプレゼンテーションを変更しないよう指示できます。  

**Note** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に変更することは可能ですが、変更を保存するには別名でプレゼンテーションを作成する必要があります。 

書き込み保護を設定するには、setWriteProtection メソッドを使用します。このサンプルコードはプレゼンテーションへの書き込み保護の設定方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```


## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメーターなしの [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。 

このサンプルコードはプレゼンテーションの復号化方法を示しています: 
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 復号化されたプレゼンテーションで作業する
```


## **プレゼンテーションから暗号化を削除する**

プレゼンテーションの暗号化またはパスワード保護を削除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスまたは変更できるようになります。 

暗号化またはパスワード保護を削除するには、[RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を削除する方法を示しています:
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```


## **プレゼンテーションから書き込み保護を削除する**

Aspose.Slides を使用してプレゼンテーションファイルの書き込み保護を削除できます。これにより、ユーザーは好きなように変更でき、タスクを実行しても警告が表示されなくなります。

[RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) メソッドを使用して書き込み保護を削除できます。このサンプルコードはプレゼンテーションから書き込み保護を削除する方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```


## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しつつ、ユーザーがそのプロパティにアクセスできるメカニズムを提供します。

**Note** Aspose.Slides がプレゼンテーションを暗号化すると、デフォルトでプレゼンテーションのドキュメントプロパティもパスワード保護されます。ただし、暗号化後でもプレゼンテーションのプロパティにアクセスできるようにしたい場合、Aspose.Slides は正確にそれを可能にします。 

暗号化されたプレゼンテーションのプロパティにユーザーがアクセスできるようにしたい場合は、[set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) メソッドに `true` を渡します。このサンプルコードは、プロパティへのアクセス手段を提供しつつプレゼンテーションを暗号化する方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```


## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、プレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだ際に発生するエラーや類似の問題を回避できます。

この C++ コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```


## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides はプレゼンテーションが暗号化されているかを確認できます。このタスクを実行するには、[get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) メソッドを使用します。このメソッドはプレゼンテーションが暗号化されていれば `true`、暗号化されていなければ `false` を返します。 

このサンプルコードはプレゼンテーションが暗号化されているかどうかを確認する方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```


## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides はプレゼンテーションが書き込み保護されているかを確認できます。このタスクを実行するには、[get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) メソッドを使用します。このメソッドはプレゼンテーションが暗号化されていれば `true`、暗号化されていなければ `false` を返します。 

このサンプルコードはプレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```


## **プレゼンテーションのパスワード使用を検証する**

特定のパスワードがプレゼンテーションドキュメントの保護に使用されたかどうかを確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。 

このサンプルコードはパスワードを検証する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" が一致しているか確認
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```


指定されたパスワードでプレゼンテーションが暗号化されていれば `true` を返します。そうでない場合は `false` を返します。 

{{% alert color="primary" title="関連項目" %}} 
- [PowerPoint のデジタル署名](/slides/ja/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用された場合、例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化プロセスにより、オープンや保存時に若干のオーバーヘッドが発生する可能性があります。ほとんどの場合、このパフォーマンスへの影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響はありません。