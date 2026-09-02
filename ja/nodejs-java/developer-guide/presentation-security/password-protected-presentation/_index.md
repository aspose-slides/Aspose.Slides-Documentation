---
title: JavaScript でパスワードでプレゼンテーションを保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロック解除
- プレゼンテーションのロック解除
- PowerPoint の保護
- プレゼンテーションの保護
- パスワード設定
- パスワード追加
- PowerPoint の暗号化
- プレゼンテーションの暗号化
- PowerPoint の復号化
- プレゼンテーションの復号化
- 書き込み保護
- PowerPoint のセキュリティ
- プレゼンテーションのセキュリティ
- パスワード削除
- 保護解除
- 暗号化解除
- パスワード無効化
- 保護無効化
- 書き込み保護解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を Java で使用し、パスワードで保護された PowerPoint および OpenDocument のプレゼンテーションを簡単にロックおよびアンロックできます。プレゼンテーションを安全に保護しましょう。"
---
## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。制限を解除するにはパスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対してこれらの制限を課すためにパスワードを設定できます：

- **変更**

  特定のユーザーだけにプレゼンテーションの編集を許可したい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの変更やコピーができなくなります。

  ただし、この場合、パスワードなしでもユーザーはドキュメントにアクセスして開くことができます。この閲覧専用モードでは、ユーザーはプレゼンテーション内のコンテンツやハイパーリンク、アニメーション、エフェクトなどを閲覧できますが、項目のコピーやプレゼンテーションの保存はできません。

- **開く**

  特定のユーザーだけにプレゼンテーションを開かせたい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容すら閲覧できなくなります。

  技術的には、開く制限はユーザーの編集も防止します。プレゼンテーションを開くことができなければ、変更や修正を行うこともできません。

**注意** 開かないようにパスワード保護を設定した場合、プレゼンテーション ファイルは暗号化されます。

## **オンラインでプレゼンテーションをパスワード保護する方法**

1. 当社の[**Aspose.Slides Lock**](https://products.aspose.app/slides/ja/lock)ページへ移動します。 

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。 

4. 編集保護用に希望のパスワードを入力します；閲覧保護用に希望のパスワードを入力します。 

5. ユーザーに最終版としてプレゼンテーションを見せたい場合、**Mark as final**チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。 

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides におけるプレゼンテーションのパスワード保護**

**対応フォーマット**

Aspose.Slidesは、これらのフォーマットのプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX と PPT – Microsoft PowerPoint プレゼンテーション 
- ODP – OpenDocument プレゼンテーション 
- OTP – OpenDocument プレゼンテーションテンプレート 

**対応操作**

Aspose.Slidesでは、プレゼンテーションにパスワード保護を使用して次の方法で変更を防止できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slidesでは、パスワード保護と暗号化に関するその他のタスクを次のように実行できます：

- プレゼンテーションの復号化；暗号化されたプレゼンテーションの開封
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワードで保護されているかの確認。

## **プレゼンテーションの暗号化**

パスワードを設定することでプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを入力する必要があります。  

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager) の encrypt メソッドを使用してパスワードを設定します。encrypt メソッドにパスワードを渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションの暗号化方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションに「編集しないでください」というマークを追加できます。これにより、ユーザーに変更を加えないよう通知できます。  

**注意** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更したい場合はプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。  

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードは、プレゼンテーションへの書き込み保護の設定方法を示しています：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **プレゼンテーションの復号化；暗号化されたプレゼンテーションの開封**

Aspose.Slidesでは、パスワードを渡すことで暗号化されたファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしで [removeEncryption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) メソッドを呼び出す必要があります。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードは、プレゼンテーションの復号化方法を示しています。

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業する
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **暗号化の解除；パスワード保護の無効化**

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスまたは変更できるようになります。  

暗号化またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています。

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **プレゼンテーションから書き込み保護を削除**

Aspose.Slidesを使用して、プレゼンテーションファイルに設定された書き込み保護を削除できます。これにより、ユーザーは自由に変更でき、変更時に警告が表示されません。  

[removeWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) メソッドを使用して、プレゼンテーションから書き込み保護を削除できます。このサンプルコードは、プレゼンテーションから書き込み保護を削除する方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **暗号化されたプレゼンテーションのプロパティ取得**

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティ取得に苦労します。しかし、Aspose.Slidesは、プレゼンテーションをパスワード保護しつつ、ユーザーがプロパティにアクセスできる機能を提供します。

**注意:** デフォルトでは、Aspose.Slidesがプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もドキュメントプロパティにアクセスできるようにするには、Aspose.Slidesでそれを実現できます。

暗号化されたプレゼンテーションのプロパティへのアクセスをユーザーに保持させたい場合は、[ProtectionManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/) の `setEncryptDocumentProperties` に `false` を渡します。このサンプルコードは、プレゼンテーションを暗号化しながら、ドキュメントプロパティへのアクセスをユーザーに提供する方法を示しています：

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみを読み込む**

スライドやその他のコンテンツを読み込まずに暗号化されたプレゼンテーションのメタデータを検査するには、[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) オブジェクトを作成し、`setOnlyLoadDocumentProperties` に `true` を渡します。このモードでは、Aspose.Slidesはパスワードを無視し、公開されているドキュメントプロパティのみを読み込みます。

以下のコード例は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) の `getDocumentProperties` を使用して組み込みおよびカスタムドキュメントプロパティを読み取ります。

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // 組み込みドキュメントプロパティを読み取る。
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // カスタムドキュメントプロパティを読み取る。
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

このワークフローは、プレゼンテーションが暗号化された際にドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。ドキュメントプロパティが暗号化されている場合、`LoadOptions.setOnlyLoadDocumentProperties` に `true` を渡すと例外が発生します。暗号化されたドキュメントプロパティにアクセスしたり、スライドやその他のコンテンツを含むプレゼンテーション全体を読み込むには、[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) の `setPassword` で正しいパスワードを提供してください。

## **読み込む前にプレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションを読み込む前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込んだ際に発生するエラーや類似の問題を回避できます。

この JavaScript コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています。

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているかの確認**

Aspose.Slidesでは、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、[isEncrypted](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) プロパティを使用します。プレゼンテーションが暗号化されていれば `true`、されていなければ `false` を返します。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **プレゼンテーションが書き込み保護されているかの確認**

Aspose.Slidesでは、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、[isWriteProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) プロパティを使用します。書き込み保護されていれば `true`、されていなければ `false` を返します。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **特定のパスワードがプレゼンテーションの保護に使用されたかの検証または確認**

特定のパスワードがプレゼンテーション文書の保護に使用されたかどうかを確認したい場合があります。Aspose.Slidesはパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています。

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // パスワードが一致するかチェック
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

指定されたパスワードでプレゼンテーションが暗号化されていれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slidesは、AESベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードが入力された場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスを防止し、コンテンツを保護します。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開く・保存時に若干のオーバーヘッドが発生することがあります。多くの場合、このパフォーマンスへの影響は最小限で、プレゼンテーション作業全体の処理時間に大きな影響はありません。