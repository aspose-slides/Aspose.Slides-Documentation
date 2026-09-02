---
title: Java でプレゼンテーションを書き込み保護する
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/java/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更パスワード
- プレゼンテーションの編集制限
- 書き込み保護の解除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint の PPT および PPTX プレゼンテーションに対する書き込み保護パスワードの設定、検出、検証、解除を行います。"
---
## **はじめに**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、コンテンツを暗号化しません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションを読み込み、表示できます。アプリケーションによっては、コンテンツを編集して別名で保存できる場合もあるため、書き込み保護は機密保持の手段とみなすべきではありません。

開くパスワードは別の目的で使用されます：プレゼンテーションを暗号化し、コンテンツの読み込みに必要です。プレゼンテーションを暗号化したり、開くパスワードを検証したりするには、[パスワードで保護されたプレゼンテーション](/slides/ja/java/password-protected-presentation/)をご参照ください。

この記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では PPTX ファイルを使用しています。PPT に保存する場合は、`.ppt` 拡張子と対応する PPT 保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) を使用して、プレゼンテーションの変更用パスワードを割り当てます。プレゼンテーションを保存すると、保護設定が保持されます。

次の例は PPTX プレゼンテーションに書き込み保護を設定します。

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

書き込み保護はプレゼンテーションのコンテンツを暗号化しないため、プレゼンテーションの読み込みにパスワードは不要です。パスワードは、保護されたプレゼンテーションの変更権限を検証する場合にのみ関係します。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に書き込み保護パスワードを渡さないでください。このメソッドは暗号化されたコンテンツ用の開くパスワードを受け取ります。プレゼンテーションに両方の保護タイプがある場合は、開くパスワードを使用して読み込み、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションから書き込み保護を解除する**

[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) を使用して変更制限を解除し、プレゼンテーションを保存します。

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

## **プレゼンテーションが書き込み保護されているかの確認**

[Presentation] インスタンスを作成せずにファイルを検査するには、[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を呼び出し、[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) を確認します。このメソッドは [NullableBool](https://reference.aspose.com/slides/ja/java/com.aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合は `NullableBool.True` を返します。

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) のストリームオーバーロードは、ストリームで提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) を使用して、プレゼンテーション全体を読み込まずに変更パスワードを検証します。まず [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) を確認し、書き込み保護がある場合にのみアプリケーションがパスワードを要求または検証するようにしてください。

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) は書き込み保護パスワードのみを検証します。開くパスワードの検証や、暗号化されたコンテンツが読み込めるかは判断しません。逆に、[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) は開くパスワードのみを検証します。完全なプレゼンテーションがすでに読み込まれている場合は、[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番環境のアプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返し検証を避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="関連項目" %}}
- [パスワードで保護されたプレゼンテーション](/slides/ja/java/password-protected-presentation/)
- [読み取り専用プレゼンテーション](/slides/ja/java/read-only-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションのコンテンツは読み込みおよび表示が可能なままです。

**書き込み保護パスワードはプレゼンテーションを開くために必要ですか？**

いいえ。暗号化されたプレゼンテーションのコンテンツを読み込むには、開くパスワードだけが必要です。

**プレゼンテーションは開くパスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションで開くパスワードを提供し、変更権限が必要な場合は書き込み保護パスワードを別途検証してください。