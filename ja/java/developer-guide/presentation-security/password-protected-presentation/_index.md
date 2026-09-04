---
title: Javaでプレゼンテーションにパスワード保護を設定する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPointを暗号化する
- PowerPointを復号化する
- プレゼンテーションのパスワードを検証する
- プレゼンテーションのパスワードを確認する
- 暗号化されたプレゼンテーションを開く
- 暗号化を解除する
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

開くためのパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要で、プレゼンテーションの内容を読み込み・表示できるようになるため、この保護は機密性を提供します。

開くためのパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/java/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用できます。例では、ファイルベースとストリームベースの振る舞いが重要になる場合に両方の形式を使用しています。

## **開くためのパスワードでプレゼンテーションを暗号化する**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を使用して開くためのパスワードを設定します。その後、[IPresentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を使用して暗号化されたプレゼンテーションを保存します。

以下の例は PPTX プレゼンテーションを暗号化します：

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

## **ドキュメント プロパティを公開したままにする**

デフォルトでは、Aspose.Slides はドキュメント プロパティをプレゼンテーションの暗号化に含めます。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) メソッドは、スライド コンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムが開くためのパスワードなしでメタデータを読み取る必要がある場合は、[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を呼び出す前に `false` を渡してください。

以下の例は、組み込みのドキュメント プロパティを公開したまま、暗号化された PPTX プレゼンテーションを作成します：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡しても、スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション コンテンツが公開されるわけではありません。対象となるのはドキュメント プロパティのみです。暗号化されたコンテンツを読み込まずにこれらのプロパティを取得する方法については、[Manage Presentation Properties](/slides/ja/java/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションを読み込む**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に開くためのパスワードを設定し、読み込み時にオプションを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) に渡します。開くためのパスワードが必要なのに提供されたパスワードが未指定または誤っている場合、読み込みは失敗します。

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

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションを開くためのパスワードで読み込み、[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) を呼び出して暗号化を解除し、結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込むことができます。

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

## **読み込む前に開くためのパスワードを検証する**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を使用して、完全なプレゼンテーション インスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/) を取得します。[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) を確認してから、パスワードの要求または検証を行います。保護が存在する場合は、[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) で提供された値を検証します。

### **ファイル パス ワークフロー**

以下の例は PPTX ファイルの開くためのパスワードを検証し、検証済みの値を [ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に渡して、完全なプレゼンテーションを読み込みます：

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) のストリーム オーバーロードでも同じワークフローが提供されます。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

以下の例は PPT ファイルを使用します：

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) は、プレゼンテーションに開くためのパスワードが設定されており、提供されたパスワードが正しい場合にのみ `true` を返します。次のいずれかの場合は `false` を返します。

- パスワードが正しくない。
- プレゼンテーションに開くためのパスワードが設定されていない。
- 提供されたパスワードが `null` または空文字列である。

動作は PPT と PPTX のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) を確認して、元のプレゼンテーションが暗号化されていたかどうかを確認します。読み込み前に開くためのパスワード保護を検出したい場合は、上記と同様に `IPresentationInfo.isPasswordProtected` を使用します。

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

{{% alert color="warning" title="Security" %}}
開くためのパスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返しの検証を避け、パスワードは必要な期間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。

公開されたドキュメント プロパティには、作者名、タイトル、件名、キーワード、会社情報、コメント、カスタム値などが含まれる可能性があり、プレゼンテーションの内容が暗号化されていても情報が漏れます。機密性の高いメタデータもプレゼンテーションと一緒に暗号化してください。プロパティを公開したままにするのは、システムが開くためのパスワードなしでファイルをインデックス作成、分類、検索、または管理する必要がある場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護をかける**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択するかアップロードします。
1. ビュー保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **よくある質問**

**開くためのパスワードと書き込み保護パスワードの違いは何ですか？**

開くためのパスワードはプレゼンテーションを暗号化し、内容を読み込むために必要です。書き込み保護パスワードは内容を暗号化せずに変更を制限します。

**すべてのスライドを読み込まずに開くためのパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、開くためのパスワード保護があるか確認した上で、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証できます。

**アプリケーションは開くためのパスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションがドキュメント プロパティの暗号化を無効にした状態で暗号化されている場合に限ります。その場合は、[Manage Presentation Properties](/slides/ja/java/presentation-properties/) で説明されているドキュメント プロパティのみの読み込みモードを使用してください。

**パスワード検証のワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。