---
title: Androidでプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/androidjava/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPointの暗号化
- PowerPointの復号化
- プレゼンテーションパスワードの検証
- プレゼンテーションパスワードのチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化の解除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションの暗号化、検出、検証、開く、復号化を行います。"
---
## **概要**

オープニングパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションの内容を読み込んで表示できるため、この保護は機密性を提供します。

オープニングパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化せず、プレゼンテーションの読み込みも防ぎません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/androidjava/write-protected-presentation/)をご覧ください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要な場合に両方の形式を使用しています。

## **オープニングパスワードでプレゼンテーションを暗号化する**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を使用してオープニングパスワードを割り当てます。その後、[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を使用して暗号化されたプレゼンテーションを保存します。

次の例は PPTX プレゼンテーションを暗号化します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **暗号化されたプレゼンテーションの読み込み**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) にオープニングパスワードを設定し、ファイルを読み込む際にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) に渡します。オープニングパスワードが必要なのに提供されたパスワードが欠如または不正確な場合、読み込みは失敗します。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションを操作します。
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションをオープニングパスワードで読み込み、[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込むことができます。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **読み込む前にオープニングパスワードを検証する**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を使用して、完全なプレゼンテーションインスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) を取得します。パスワードの要求または検証の前に、[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) を確認します。保護が存在する場合、提供された値を [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) で検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルのオープニングパスワードを検証し、検証された値を [ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に渡してから、完全なプレゼンテーションを読み込みます：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **ストリーム ワークフロー**

[IPresentationFactory.getPresentationInfo] のストリームオーバーロードは同じワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword の戻り値**

[IPresentationInfo.checkPassword] は、プレゼンテーションがオープニングパスワードを持ち、提供されたパスワードが正しい場合にのみ `true` を返します。以下の場合はすべて `false` を返します：

- パスワードが正しくありません。
- プレゼンテーションにオープニングパスワードが設定されていません。
- 提供されたパスワードが `null` または空です。

この動作は PPT および PPTX のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) を調べて、元のプレゼンテーションが暗号化されていたことを確認します。読み込み前にオープニングパスワード保護を検出するには、上記のように `IPresentationInfo.isPasswordProtected` を使用します。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **セキュリティ推奨事項**

{{% alert color="warning" title="Security" %}}
オープニングパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を適用する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択するかアップロードします。
3. 表示保護用のパスワードを入力します。
4. 必要に応じて、編集保護用の別のパスワードを入力します。
5. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニングパスワードと書き込み保護パスワードの違いは何ですか？**

オープニングパスワードはプレゼンテーションを暗号化し、コンテンツを読み込むために必要です。書き込み保護パスワードは暗号化せずに変更を制限します。

**すべてのスライドを読み込まずにオープニングパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニングパスワード保護があるか確認し、完全なプレゼンテーションインスタンスを作成する前にパスワードを検証します。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は PPT と PPTX のプレゼンテーションで同じように動作します。