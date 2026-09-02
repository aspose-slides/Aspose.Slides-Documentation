---
title: Javaでプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- 開封パスワード
- PowerPointの暗号化
- PowerPointの復号化
- プレゼンテーションパスワードの検証
- プレゼンテーションパスワードのチェック
- 暗号化されたプレゼンテーションを開く
- 暗号化の削除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開封、復号化します。"
---
## **概要**

開封パスワードはプレゼンテーションを暗号化します。正しいパスワードが必要になるため、プレゼンテーションの内容を読み込み・表示できず、この保護は機密性を提供します。

開封パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/java/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要になる場合の両形式を使用しています。

## **開封パスワードでプレゼンテーションを暗号化する**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を使用して開封パスワードを設定します。その後、[IPresentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を使用して暗号化されたプレゼンテーションを保存します。

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

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に開封パスワードを設定し、ファイルの読み込み時にオプションを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) に渡します。開封パスワードが必要なのに提供されたパスワードが欠如または不正確な場合、読み込みは失敗します。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業します。
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションから暗号化を削除する**

プレゼンテーションを開封パスワードで読み込み、[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) を呼び出してから保存します。保存されたプレゼンテーションはパスワードなしで読み込めるようになります。

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

## **読み込む前に開封パスワードを検証する**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を使用して、完全なプレゼンテーションインスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/) を取得します。パスワードを要求または検証する前に、[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) を確認してください。保護が存在する場合、提供された値を [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) で検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルの開封パスワードを検証し、検証済みの値を [ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に渡してから、完全なプレゼンテーションを読み込みます。

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) のストリームオーバーロードも同様のワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します。

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) は、プレゼンテーションに開封パスワードが設定されており、提供されたパスワードが正しい場合にのみ `true` を返します。次の場合は `false` を返します。

- パスワードが正しくない。
- プレゼンテーションに開封パスワードが設定されていない。
- 提供されたパスワードが `null` または空文字列である。

この動作は PPT と PPTX の両方で同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) を確認して、元のプレゼンテーションが暗号化されていたかどうかを検証します。読み込み前に開封パスワード保護を検出するには、上記のように `IPresentationInfo.isPasswordProtected` を使用してください。

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

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="セキュリティ" %}}
開封パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返し検証は避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。
{{% /alert %}}

## **プレゼンテーションをオンラインでパスワード保護する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択するかアップロードします。
3. ビュー保護用のパスワードを入力します。
4. 必要に応じて編集保護用の別のパスワードを入力します。
5. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="参考" %}}
- [Write-Protect Presentations](/slides/ja/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**開封パスワードと書き込み保護パスワードの違いは何ですか？**

開封パスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開封パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開封パスワード保護の有無を確認した上で、完全なプレゼンテーションインスタンスを作成せずにパスワードを検証できます。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。