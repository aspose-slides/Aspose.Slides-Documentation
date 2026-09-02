---
title: Android でプレゼンテーションを書き込み保護する
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/androidjava/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーションの編集を制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android (Java) を使用して、PowerPoint の PPT および PPTX プレゼンテーションにおける書き込み保護パスワードの設定、検出、検証、削除を行います。"
---
## **はじめに**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、内容を暗号化はしません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションを読み込み、表示することができます。アプリケーションによっては、内容を編集して別名で保存できる場合もあるため、書き込み保護は機密性の手段として扱うべきではありません。

オープニングパスワードは異なる目的で使用されます。プレゼンテーションを暗号化し、内容を読み込む際に必要です。プレゼンテーションを暗号化するか、オープニングパスワードを検証するには、[パスワードで保護されたプレゼンテーション](/slides/ja/androidjava/password-protected-presentation/) を参照してください。

本記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用できます。例では PPTX ファイルを使用しています。PPT で保存する場合は、`.ppt` 拡張子と対応する PPT 保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションの変更用パスワードを設定するには、[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) を使用します。プレゼンテーションを保存すると、保護設定が保持されます。

以下の例は PPTX プレゼンテーションに書き込み保護を設定します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションの内容を暗号化しないため、プレゼンテーションの読み込みにパスワードは不要です。パスワードは、保護されたプレゼンテーションの変更権限を検証する場合にのみ関係します。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

書き込み保護パスワードを [ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に渡さないでください。このメソッドは暗号化された内容用のオープニングパスワードを受け取ります。プレゼンテーションが両方の保護タイプを持つ場合、読み込むためにオープニングパスワードを提供し、書き込み保護パスワードは別に処理してください。

## **プレゼンテーションから書き込み保護を削除する**

変更制限を解除するには、[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) を使用し、その後プレゼンテーションを保存してください。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているかどうかの確認**

完全な [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずにファイルを調査するには、[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を呼び出し、[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) を確認します。このメソッドは [NullableBool](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合 `NullableBool.True` を返します。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) のストリーム オーバーロードは、ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

完全なプレゼンテーションを読み込まずに変更用パスワードを検証するには、[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) を使用します。アプリケーションがパスワードを要求または検証するのは、書き込み保護が存在する場合のみになるよう、まず [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) を確認してください。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) は書き込み保護パスワードのみを検証します。オープニングパスワードの検証や、暗号化されたコンテンツが読み込めるかどうかは行いません。逆に、[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) はオープニングパスワードのみを検証します。すでに完全なプレゼンテーションが読み込まれている場合、[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) は保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="See also" %}}
- [パスワードで保護されたプレゼンテーション](/slides/ja/androidjava/password-protected-presentation/)
- [読み取り専用プレゼンテーション](/slides/ja/androidjava/read-only-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションの内容は読み込みや表示が可能なままです。

**プレゼンテーションを開く際に書き込み保護パスワードは必要ですか？**

いいえ。暗号化されたプレゼンテーションの内容を読み込むにはオープニングパスワードのみが必要です。

**プレゼンテーションはオープニングパスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションでオープニングパスワードを提供し、変更権限が必要な場合は書き込み保護パスワードを別途検証してください。