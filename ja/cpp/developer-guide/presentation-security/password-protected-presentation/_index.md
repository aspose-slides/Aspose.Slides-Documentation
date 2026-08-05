---
title: C++ でパスワード付きプレゼンテーションを保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/cpp/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のパスワード保護されたプレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを安全に保護します。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対して以下の制限を設定できます。

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限は、パスワードを入力しない限り、プレゼンテーションの変更、編集、コピーを防止します。

  ただし、この場合でもパスワードがなくてもユーザーはドキュメントを開くことができます。閲覧専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限は、パスワードを入力しない限り、プレゼンテーションの内容を閲覧さえできなくします。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けないユーザーは、変更や修正を行うことができません。

  **注**：開くことを防止するためにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/ja/lock)ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用の好きなパスワード、表示保護用の好きなパスワードを入力します。

5. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides のプレゼンテーション用パスワード保護**
**サポート形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides は、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、次の方法でパスワード保護および暗号化に関連するその他のタスクを実行できます。

- プレゼンテーションの復号化、暗号化されたプレゼンテーションの開封
- 暗号化の解除、パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを入力する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager) の encrypt メソッドを使用してパスワードを設定します。encrypt メソッドにパスワードを渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションに「変更しないでください」というマークを付けることができます。これにより、ユーザーに変更を加えてほしくない旨を伝えることができます。

**注**：書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更することは可能ですが、変更を保存するには別名でプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、setWriteProtection メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしの [RemoveEncryption](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードは、プレゼンテーションを復号化する方法を示しています。

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 復号化されたプレゼンテーションで作業する
```

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を解除するには、[RemoveEncryption](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています。

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用して、プレゼンテーションファイルに設定された書き込み保護を解除できます。これにより、ユーザーは自由に変更でき、警告も表示されません。

[RemoveWriteProtection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) メソッドを使用して書き込み保護を解除します。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティの取得に苦労します。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しながらもドキュメントプロパティへのアクセスを可能にするメカニズムを提供します。

**注**：デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワードで保護されます。暗号化後もプロパティにアクセスできるようにしたい場合は、[IProtectionManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/) の `set_EncryptDocumentProperties` メソッドに `false` を渡します。このサンプルコードは、暗号化しつつドキュメントプロパティへのアクセスを提供する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **暗号化されたプレゼンテーションからプロパティのみを読み込む**

スライドやその他のコンテンツを読み込まずに暗号化されたプレゼンテーションのメタデータだけを確認したい場合は、[LoadOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/) オブジェクトを作成し、`set_OnlyLoadDocumentProperties` を `true` に設定します。このモードでは、Aspose.Slides はパスワードを無視して公開されているドキュメントプロパティのみを読み込みます。

以下のコード例は、[IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_documentproperties/) を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります。

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

このワークフローは、プレゼンテーションが暗号化された際にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。プロパティが暗号化されている場合、`LoadOptions::set_OnlyLoadDocumentProperties` を `true` に設定すると例外が発生します。暗号化されたプロパティにアクセスしたり、スライドや他のコンテンツを含むプレゼンテーション全体を読み込むには、正しいパスワードを `LoadOptions::set_Password` に設定して使用してください。

## **プレゼンテーションがパスワード保護されているかの確認**

プレゼンテーションを読み込む前に、そのプレゼンテーションがパスワードで保護されていないか確認したい場合があります。これにより、パスワードなしで保護されたプレゼンテーションを読み込んだ際に発生するエラーや類似の問題を回避できます。

この C++ コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています。

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **プレゼンテーションが暗号化されているかの確認**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、暗号化されていれば `true`、されていなければ `false` を返す [get_IsEncrypted()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) メソッドを使用します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **プレゼンテーションが書き込み保護されているかの確認**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、書き込み保護されていれば `true`、されていなければ `false` を返す [get_IsWriteProtected()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) メソッドを使用します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **プレゼンテーションのパスワード使用状況の検証**

特定のパスワードがプレゼンテーションに使用されているか確認したい場合があります。Aspose.Slides は、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" が一致するか確認
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

指定したパスワードでプレゼンテーションが暗号化されていれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="See also" %}} 
- [PowerPoint のデジタル署名](/slides/ja/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES 系アルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高レベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開閉や保存時に若干のオーバーヘッドが発生する可能性があります。ほとんどの場合、このパフォーマンスへの影響は最小限であり、プレゼンテーション作業全体の処理時間に大きな影響はありません。