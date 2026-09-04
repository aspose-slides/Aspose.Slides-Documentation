---
title: JavaScript でプレゼンテーションをパスワード保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/nodejs-java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPoint の暗号化
- PowerPoint の復号化
- プレゼンテーション パスワードの検証
- プレゼンテーション パスワードの確認
- 暗号化されたプレゼンテーションを開く
- 暗号化の解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して、JavaScript でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

オープニングパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションのコンテンツをロードして表示できるため、この保護は機密性を提供します。

オープニングパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションのロードを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[プレゼンテーションの書き込み保護](/slides/ja/nodejs-java/write-protected-presentation/)をご覧ください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要になる両形式を使用しています。

## **オープニングパスワードでプレゼンテーションを暗号化**

オープニングパスワードを割り当てるには、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#encrypt) を使用します。その後、暗号化されたプレゼンテーションを保存するには [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) を使用します。

以下の例は PPTX プレゼンテーションを暗号化します:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ドキュメント プロパティを公開したままにする**

既定では、Aspose.Slides はプレゼンテーションの暗号化にドキュメント プロパティを含めます。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) メソッドは、スライド コンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムがオープニングパスワードなしでメタデータを読み取る必要がある場合は、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#encrypt) を呼び出す前に `false` を渡してください。

以下の例は、組み込みのドキュメント プロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` を [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に渡しても、スライド、マスター、レイアウト、シェイプ、メディア、またはその他のプレゼンテーション コンテンツが公開されるわけではありません。影響を受けるのはドキュメント プロパティのみです。暗号化されたコンテンツをロードせずにこれらのプロパティを読み取るには、[プレゼンテーション プロパティの管理](/slides/ja/nodejs-java/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションのロード**

ファイルをロードする際に、オープニングパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に設定し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) に渡します。オープニングパスワードが必要なのにパスワードが未提供または誤っている場合、ロードは失敗します。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業します。
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションから暗号化を解除**

オープニングパスワードでプレゼンテーションをロードし、[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしでロードできるようになります。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ロード前にオープニングパスワードを検証**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、完全なプレゼンテーション インスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) を取得します。パスワードの要求または検証の前に [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) を確認してください。保護が存在する場合は、[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkPassword) で提供された値を検証します。

### **ファイルパス ワークフロー**

以下の例は PPTX ファイルのオープニングパスワードを検証し、検証済みの値を [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に渡してから、完全なプレゼンテーションをロードします:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **ストリーム ワークフロー**

[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) を使用して Node.js の読み取り可能ストリームを検査します。検査用ストリームが消費された後、[Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) を使用して完全なプレゼンテーションをロードする前に新しいストリームを作成します。

以下の例は PPT ファイルを使用します:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword の戻り値**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkPassword) は、プレゼンテーションにオープニングパスワードが設定されており、提供されたパスワードが正しい場合にのみ `true` を返します。以下のいずれかの場合は `false` を返します:

- パスワードが正しくありません。
- プレゼンテーションにオープニングパスワードが設定されていません。
- 提供されたパスワードが `null` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **ロードされたプレゼンテーションが暗号化されているか確認**

正しいパスワードでプレゼンテーションをロードした後、[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) を確認して、元のプレゼンテーションが暗号化されていたことを確認します。ロード前にオープニングパスワード保護を検出するには、上記のように [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) を使用します。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **セキュリティの推奨事項**

{{% alert color="warning" title="Security" %}}
オープニングパスワードをログに記録したり、診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐにロードする際には成功した検証結果を再利用してください。

プレゼンテーションのコンテンツが暗号化されていても、公開されたドキュメント プロパティにより、著者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密性の高いメタデータはプレゼンテーションと共に暗号化してください。プロパティを公開することは、システムがオープニングパスワードなしでファイルをインデックス、分類、検索、または管理しなければならない場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択するかアップロードします。
3. 閲覧保護用のパスワードを入力します。
4. 必要に応じて、編集保護用の別のパスワードを入力します。
5. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/nodejs-java/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニングパスワードと書き込み保護パスワードの違いは何ですか？**

オープニングパスワードはプレゼンテーションを暗号化し、コンテンツをロードするために必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドをロードせずにオープニングパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニングパスワード保護が存在するか確認し、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証します。

**アプリケーションはオープニングパスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションがドキュメント プロパティの暗号化を無効にして暗号化された場合に限ります。その場合、アプリケーションは [プレゼンテーション プロパティの管理](/slides/ja/nodejs-java/presentation-properties/) で説明されているドキュメント プロパティのみのロード モードを使用する必要があります。

**パスワード検証のワークフローは PPT と PPTX の両方をサポートしていますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。