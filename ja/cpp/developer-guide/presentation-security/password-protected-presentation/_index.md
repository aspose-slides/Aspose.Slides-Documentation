---
title: パスワード保護されたプレゼンテーション
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords: "PowerPointプレゼンテーションをロックする"
description: "Aspose.Slidesを使用してパスワード保護されたPowerPointプレゼンテーション。"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワードを設定すると、特定の制限を強制するパスワードを設定することを意味します。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対してこれらの制限を強制するためにパスワードを設定できます：

- **変更**

  特定のユーザーのみがプレゼンテーションを変更できるようにする場合、変更制限を設定できます。ここでの制限は、パスワードを提供しない限り、人々がプレゼンテーション内のものを変更したり、変更したり、コピーしたりすることを防ぎます。

  ただし、この場合、パスワードなしでもユーザーはドキュメントにアクセスして開くことができます。この読み取り専用モードでは、ユーザーはプレゼンテーション内のコンテンツやハイパーリンク、アニメーション、効果などを見ることができますが、アイテムをコピーしたり、プレゼンテーションを保存したりすることはできません。

- **オープン**

  特定のユーザーのみがプレゼンテーションを開けるようにする場合、オープン制限を設定できます。ここでの制限は、パスワードを提供しない限り、人々がプレゼンテーションのコンテンツを見たりすることを防ぎます。

  技術的には、オープン制限はユーザーがプレゼンテーションを変更するのを防ぎます：人々がプレゼンテーションを開けないと、変更を加えたり修正することはできません。

  **注**：プレゼンテーションを開けないようにするためにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションをパスワード保護する方法**

1. [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) ページに移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード** をクリックします。

3. パスワード保護したいファイルをコンピュータから選択します。

4. 編集保護用に希望のパスワードを入力し、表示保護用に希望のパスワードを入力します。

5. ユーザーに最終コピーとしてプレゼンテーションを見せたい場合は、**最終版としてマーク** チェックボックスをオンにします。

6. **今すぐ保護** をクリックします。

7. **今すぐダウンロード** をクリックします。

## **Aspose.Slides のプレゼンテーションのパスワード保護**
**対応フォーマット**

Aspose.Slidesは、以下のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、および類似の操作をサポートしています：

- PPTXおよびPPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポートする操作**

Aspose.Slidesは、以下の方法でプレゼンテーションの変更を防ぐためにパスワード保護を使用することを許可します：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slidesは、以下の方法でパスワード保護および暗号化に関する他のタスクを実行することを許可します：

- プレゼンテーションの暗号解除；暗号化されたプレゼンテーションのオープン
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションからの書き込み保護の解除
- 暗号化されたプレゼンテーションのプロパティの取得
- プレゼンテーションが暗号化されているかどうかの確認
- プレゼンテーションがパスワード保護されているかどうかの確認。

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、プレゼンテーションのパスワードを設定するために encrypt メソッド（[ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)から）を使用する必要があります。パスワードを encrypt メソッドに渡し、save メソッドを使用して今や暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションへの書き込み保護の設定**

「変更しないでください」というマークをプレゼンテーションに追加できます。これにより、ユーザーにプレゼンテーションを変更してほしくないことを伝えることができます。

**注**：書き込み保護プロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に望む場合、プレゼンテーションを変更できますが、変更を保存するには異なる名前のプレゼンテーションを作成する必要があります。

書き込み保護を設定するには、setWriteProtection メソッドを使用する必要があります。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションの暗号解除；暗号化されたプレゼンテーションを開く**

Aspose.Slidesは、パスワードを渡すことによって暗号化されたファイルをロードすることを許可します。プレゼンテーションを暗号解除するには、[RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドをパラメータなしで呼び出す必要があります。その後、プレゼンテーションをロードするために正しいパスワードを入力する必要があります。

このサンプルコードは、プレゼンテーションを暗号解除する方法を示しています：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 暗号解除されたプレゼンテーションで作業する
```

## **暗号化の削除；パスワード保護の無効化**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なしにプレゼンテーションにアクセスしたり、変更したりできるようになります。

暗号化またはパスワード保護を解除するには、[RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) メソッドを呼び出す必要があります。このサンプルコードは、プレゼンテーションから暗号化を削除する方法を示しています：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");

auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **プレゼンテーションからの書き込み保護の削除**

Aspose.Slidesを使用してプレゼンテーションファイルに使用されている書き込み保護を削除できます。これにより、ユーザーは自由に変更でき、作業を行う際に警告を受けなくなります。

[RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) メソッドを使用してプレゼンテーションから書き込み保護を削除できます。このサンプルコードは、プレゼンテーションから書き込み保護を削除する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **暗号化されたプレゼンテーションのプロパティの取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。しかし、Aspose.Slidesは、プレゼンテーションのパスワード保護を行いつつ、ユーザーにそのプレゼンテーションのプロパティにアクセスする手段を提供するメカニズムを提供します。

**注**：Aspose.Slidesがプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。しかし、暗号化された後でもプレゼンテーションのプロパティをアクセス可能にする必要がある場合、Aspose.Slidesは正確にそれを許可します。

ユーザーに暗号化されたプレゼンテーションのプロパティにアクセスできるようにするには、[set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) メソッドに `true` を渡すことができます。このサンプルコードは、ユーザーにドキュメントプロパティにアクセスする手段を提供しつつプレゼンテーションを暗号化する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **プレゼンテーションをロードする前にパスワード保護されているかどうかを確認する**

プレゼンテーションをロードする前に、そのプレゼンテーションがパスワードで保護されていないことを確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしでロードしたときに発生するエラーや類似の問題を回避できます。

このC++コードは、プレゼンテーションがパスワード保護されているかどうかを確認する方法を示しています（プレゼンテーション自体をロードすることなく）：

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"プレゼンテーションはパスワード保護されています: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **プレゼンテーションが暗号化されているかどうかを確認する**

Aspose.Slidesは、プレゼンテーションが暗号化されているかどうかを確認することを許可します。このタスクを実行するには、プレゼンテーションが暗号化されていれば `true` を、そうでなければ `false` を返す [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) メソッドを使用できます。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **プレゼンテーションが書き込み保護されているかどうかを確認する**

Aspose.Slidesは、プレゼンテーションが書き込み保護されているかどうかを確認することを許可します。このタスクを実行するには、プレゼンテーションが書き込み保護されていれば `true` を、そうでなければ `false` を返す [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) メソッドを使用できます。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **特定のパスワードがプレゼンテーションを保護するために使用されていることを確認する**

特定のパスワードがプレゼンテーションドキュメントを保護するために使用されているかを確認したい場合があります。Aspose.Slidesは、パスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" が一致しているかを確認
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

指定されたパスワードでプレゼンテーションが暗号化されている場合、`true` を返します。それ以外の場合は `false` を返します。

{{% alert color="primary" title="関連情報" %}} 
- [PowerPointにおけるデジタル署名](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}