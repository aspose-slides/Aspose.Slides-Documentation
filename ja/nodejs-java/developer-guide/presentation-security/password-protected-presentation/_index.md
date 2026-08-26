---
title: JavaScript でプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/nodejs-java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- 開くためのパスワード
- PowerPoint の暗号化
- PowerPoint の復号化
- プレゼンテーション パスワードの検証
- プレゼンテーション パスワードの確認
- 暗号化されたプレゼンテーションを開く
- 暗号化の削除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides を使用して、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

開くためのパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションのコンテンツを読み込み表示できるため、この保護は機密性を提供します。

開くためのパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したり、プレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/nodejs-java/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースおよびストリームベースの動作が重要な場合に両方の形式を使用しています。

## **開くためのパスワードでプレゼンテーションを暗号化する**

開くためのパスワードを割り当てるには、[ProtectionManager.encrypt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#encrypt) を使用します。次に、暗号化されたプレゼンテーションを保存するには、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) を使用します。

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

## **暗号化されたプレゼンテーションを読み込む**

[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に開くためのパスワードを設定し、ファイルを読み込む際にオプションを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) に渡します。開くためのパスワードが必要なのに提供されたパスワードが欠落または正しくない場合、読み込みは失敗します。

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

## **プレゼンテーションから暗号化を削除する**

プレゼンテーションを開くためのパスワードで読み込み、[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) を呼び出して結果を保存します。その後、保存されたプレゼンテーションはパスワードなしで読み込むことができます。

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

## **読み込む前に開くためのパスワードを検証する**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、完全なプレゼンテーションインスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) を取得します。パスワードの要求または検証を行う前に、[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) を確認します。保護が存在する場合、提供された値を [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkPassword) で検証します。

### **ファイル パス ワークフロー**

以下の例は PPTX ファイルの開くためのパスワードを検証し、検証された値を [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に渡して、完全なプレゼンテーションを読み込みます:

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

[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) を使用して Node.js の読み取り可能ストリームを検査します。検査用ストリームが消費された後、[Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) を使用して完全なプレゼンテーションを読み込む前に新しいストリームを作成します。

以下の例は PPT ファイルを使用しています:

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkPassword) は、プレゼンテーションに開くためのパスワードが設定され、提供されたパスワードが正しい場合にのみ `true` を返します。次のいずれかの場合は `false` を返します:

- パスワードが正しくありません。
- プレゼンテーションに開くためのパスワードが設定されていません。
- 提供されたパスワードが `null` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) を確認して、元のプレゼンテーションが暗号化されていることを確認します。読み込む前に開くためのパスワード保護を検出するには、上記のように [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) を使用します。

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

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
開くためのパスワードをログに記録したり、診断メッセージに含めたりしないでください。不要な繰り返しの検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐに読み込む際には成功した検証結果を再利用してください。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を設定する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択するかアップロードします。
1. 表示保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/nodejs-java/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**開くためのパスワードと書き込み保護パスワードの違いは何ですか？**

開くためのパスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開くためのパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開くためのパスワード保護が存在するか確認し、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証します。

**パスワード検証のワークフローは PPT と PPTX の両方をサポートしていますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。