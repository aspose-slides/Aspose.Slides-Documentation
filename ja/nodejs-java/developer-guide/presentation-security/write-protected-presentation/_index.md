---
title: JavaScript でプレゼンテーションを書き込み保護する
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/nodejs-java/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーション編集の制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js (Java) を使用して、PowerPoint の PPT および PPTX プレゼンテーションに対し、書き込み保護パスワードの設定、検出、検証、削除を行います。"
---
## **イントロダクション**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、内容を暗号化はしません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションを読み込み、表示できます。アプリケーションによっては、内容を編集して別名で保存できる場合もあるため、書き込み保護を機密保持手段として扱うべきではありません。

開放パスワードは別の目的で使用されます。プレゼンテーションを暗号化し、内容を読み込む際に必要です。プレゼンテーションを暗号化するか、開放パスワードを検証するには、[Password-Protect Presentations](/slides/ja/nodejs-java/password-protected-presentation/) を参照してください。

この記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例は PPTX ファイルを使用しています。PPT に保存する場合は `.ppt` 拡張子と対応する PPT の保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションの変更用パスワードを割り当てるには、[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) を使用します。プレゼンテーションを保存すると、保護設定が保持されます。

以下の例は PPTX プレゼンテーションに書き込み保護を設定します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションの内容を暗号化しないため、プレゼンテーションの読み込みにパスワードは不要です。パスワードは、保護されたプレゼンテーションの変更権限を検証する場合にのみ使用されます。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に書き込み保護パスワードを渡さないでください。そのメソッドは暗号化されたコンテンツ用の開放パスワードを受け取ります。プレゼンテーションが両方の保護タイプを持つ場合、開放パスワードを使用して読み込み、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションからの書き込み保護の削除**

変更制限を解除するには、[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) を使用し、続いてプレゼンテーションを保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているかの確認**

完全な [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査するには、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) を呼び出し、[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) を確認します。このメソッドは [NullableBool](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合 `NullableBool.True` を返します。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

ストリームベースの [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) メソッドは、Node.js の読み取り可能ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

完全なプレゼンテーションを読み込まずに変更パスワードを検証するには、[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) を使用します。まず [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) を確認し、書き込み保護がある場合にのみアプリケーションがパスワードを要求または検証するようにしてください。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) は書き込み保護パスワードのみを検証します。開放パスワードの検証や暗号化されたコンテンツが読み込めるかどうかは判断しません。逆に、[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#checkPassword) は開放パスワードのみを検証します。完全なプレゼンテーションが既に読み込まれている場合、[ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに出力したり診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="参考" %}}
- [パスワード保護プレゼンテーション](/slides/ja/nodejs-java/password-protected-presentation/)
- [読み取り専用プレゼンテーション](/slides/ja/nodejs-java/read-only-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更は制限しますが、プレゼンテーションの内容は読み込みや表示のために利用可能なままです。

**プレゼンテーションを開く際に書き込み保護パスワードは必要ですか？**

いいえ。暗号化されたプレゼンテーションの内容を読み込むには、開放パスワードのみが必要です。

**プレゼンテーションは開放パスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションで開放パスワードを指定し、変更権限が必要なときに書き込み保護パスワードを別途検証してください。