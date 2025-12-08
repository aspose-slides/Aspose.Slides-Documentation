---
title: パスワードで保護されたプレゼンテーション
type: docs
weight: 20
url: /ja/nodejs-java/password-protected-presentation/
keywords: "JavaScriptでPowerPointプレゼンテーションをロック"
description: "PowerPointプレゼンテーションをロックします。JavaScriptでパスワード保護されたPowerPoint"
---

## **パスワード保護について**
### **プレゼンテーションのパスワード保護はどのように機能しますか？**
プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションはロックされたプレゼンテーションとみなされます。

通常、プレゼンテーションに対してこれらの制限を適用するためにパスワードを設定できます：

- **変更**

  特定のユーザーだけにプレゼンテーションの編集を許可したい場合、変更制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーション内の項目を変更、変更、コピーすることができません。

  ただし、この場合、パスワードがなくてもユーザーはドキュメントにアクセスして開くことができます。読み取り専用モードでは、ユーザーはプレゼンテーション内のハイパーリンク、アニメーション、エフェクトなどの内容を見ることはできますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合、開く制限を設定できます。この制限により、パスワードを提供しない限り、プレゼンテーションの内容さえ表示できなくなります。

  技術的には、開く制限はプレゼンテーションの編集も防止します。プレゼンテーションを開くことができなければ、変更や修正を行うこともできません。

  **Note** パスワード保護により開くことを防止すると、プレゼンテーションファイルは暗号化されます。

## **オンラインでプレゼンテーションにパスワード保護を設定する方法**
1. 当社の[**Aspose.Slides ロック**](https://products.aspose.app/slides/lock)ページへ移動します。

   ![todo:image_alt_text](slides-lock.png)

2. **ファイルをドロップまたはアップロード** をクリックします。

3. コンピューター上でパスワード保護したいファイルを選択します。

4. 編集保護用のパスワードと閲覧保護用のパスワードを入力します。

5. ユーザーに最終版としてプレゼンテーションを見せたい場合は、**Mark as final** チェックボックスにチェックを入れます。

6. **PROTECT NOW.** をクリックします。

7. **DOWNLOAD NOW.** をクリックします。

## **Aspose.Slides のプレゼンテーションに対するパスワード保護**
**対応フォーマット**

Aspose.Slides は次のフォーマットのプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします：

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**対応操作**

Aspose.Slides はプレゼンテーションに対して次の方法で変更を防止するパスワード保護を使用できます：

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides はパスワード保護と暗号化に関連する次の操作を実行できます：

- プレゼンテーションの復号化；暗号化されたプレゼンテーションを開く
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションから書き込み保護を解除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているか確認
- プレゼンテーションがパスワード保護されているか確認

## **プレゼンテーションの暗号化**
パスワードを設定してプレゼンテーションを暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供しなければなりません。

プレゼンテーションを暗号化またはパスワード保護するには、[ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager) の encrypt メソッドを使用してプレゼンテーションにパスワードを設定します。パスワードを encrypt メソッドに渡し、save メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードはプレゼンテーションを暗号化する方法を示しています:
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
プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーに対してプレゼンテーションを変更しないよう通知できます。

**Note** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーは実際に変更できても、変更を保存する際には別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードはプレゼンテーションに書き込み保護を設定する方法を示しています:
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


## **プレゼンテーションの復号化；暗号化されたプレゼンテーションの開く方法**
Aspose.Slides はパスワードを渡すことで暗号化ファイルを読み込むことができます。プレゼンテーションを復号化するには、パラメータなしで removeEncryption メソッドを呼び出します。その後、正しいパスワードを入力してプレゼンテーションを読み込みます。

このサンプルコードはプレゼンテーションを復号化する方法を示しています:
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
プレゼンテーションの暗号化やパスワード保護を解除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスまたは変更できるようになります。

暗号化やパスワード保護を解除するには、removeEncryption メソッドを呼び出します。このサンプルコードはプレゼンテーションから暗号化を解除する方法を示しています:
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


## **プレゼンテーションから書き込み保護を解除する**
Aspose.Slides を使用してプレゼンテーションファイルに適用された書き込み保護を解除できます。これにより、ユーザーは好きなように変更でき、警告も表示されません。

書き込み保護を解除するには、removeWriteProtection メソッドを使用します。このサンプルコードはプレゼンテーションから書き込み保護を解除する方法を示しています:
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
通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのに苦労します。Aspose.Slides は、プレゼンテーションをパスワード保護しつつ、ユーザーがそのプロパティにアクセスできる手段を提供します。

**Note** Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもデフォルトでパスワード保護されます。ただし、暗号化後でもプロパティにアクセスできるようにしたい場合は、encryptDocumentProperties プロパティを `true` に設定できます。このサンプルコードは、プロパティへのアクセス手段を提供しながらプレゼンテーションを暗号化する方法を示しています:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **ロードする前にプレゼンテーションがパスワード保護されているか確認する**
プレゼンテーションを読み込む前に、パスワード保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしで読み込もうとしたときに発生するエラーや問題を回避できます。

この JavaScript コードは、プレゼンテーションを実際に読み込まずにパスワード保護されているかどうかを調べる方法を示しています:
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **プレゼンテーションが暗号化されているか確認する**
Aspose.Slides はプレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、isEncrypted プロパティを使用します。プレゼンテーションが暗号化されていれば `true`、されていなければ `false` が返されます。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています:
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


## **プレゼンテーションが書き込み保護されているか確認する**
Aspose.Slides はプレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、isWriteProtected プロパティを使用します。プレゼンテーションが暗号化されていれば `true`、されていなければ `false` が返されます。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています:
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


## **特定のパスワードがプレゼンテーションの保護に使用されたか検証または確認する**
特定のパスワードがプレゼンテーションの保護に使用されたかを確認したいことがあります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // "pass" が一致するか確認
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


指定されたパスワードでプレゼンテーションが暗号化されていれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="primary" title="関連記事" %}} 
- [Digital Signature in PowerPoint](/slides/ja/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に間違ったパスワードが入力された場合、どうなりますか？**

誤ったパスワードが使用された場合は例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化の処理により、開く時や保存時に若干のオーバーヘッドが発生することがあります。ほとんどの場合、この影響は最小限であり、プレゼンテーション操作全体の処理時間に大きな影響を与えることはありません。