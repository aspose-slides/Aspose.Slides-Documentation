---
title: Android でプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/androidjava/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニングパスワード
- PowerPoint の暗号化
- PowerPoint の復号化
- プレゼンテーションパスワードの検証
- プレゼンテーションパスワードの確認
- 暗号化されたプレゼンテーションを開く
- 暗号化の削除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、パスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

オープニングパスワードはプレゼンテーションを暗号化します。正しいパスワードが必要となり、プレゼンテーションの内容を読み込み表示できるため、この保護は機密性を提供します。

オープニングパスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/androidjava/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要な場合の両方の形式を使用しています。

## **オープニングパスワードでプレゼンテーションを暗号化する**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を使用してオープニングパスワードを割り当てます。次に、[IPresentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) を使用して暗号化されたプレゼンテーションを保存します。

次の例は PPTX プレゼンテーションを暗号化します：

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

## **ドキュメントプロパティを公開したまま保持する**

既定では、Aspose.Slides はプレゼンテーションの暗号化にドキュメントプロパティも含めます。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) メソッドは、スライドコンテンツの暗号化とは別にこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムがオープニングパスワードなしでメタデータを読む必要がある場合は、[IProtectionManager.encrypt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) を呼び出す前に `false` を渡します。

次の例は、組み込みのドキュメントプロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します：

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

`false` を [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に渡しても、スライド、マスター、レイアウト、シェイプ、メディア、またはその他のプレゼンテーションコンテンツが公開されるわけではありません。影響を受けるのはドキュメントプロパティのみです。暗号化されたコンテンツを読み込まずにこれらのプロパティを読むには、[Manage Presentation Properties](/slides/ja/androidjava/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションを読み込む**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) にオープニングパスワードを設定し、ファイルを読み込む際にオプションを [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) に渡します。オープニングパスワードが必要なのにパスワードが未提供または不正な場合、読み込みは失敗します。

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

## **プレゼンテーションから暗号化を削除する**

オープニングパスワードでプレゼンテーションを読み込み、[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込むことができます。

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) を使用して、完全なプレゼンテーションインスタンスを作成せずに [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) を取得します。パスワードの要求または検証の前に、[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) を確認します。保護が存在する場合は、[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) で提供された値を検証します。

### **ファイルパスワークフロー**

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

### **ストリームワークフロー**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) のストリームオーバーロードは同じワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) は、プレゼンテーションにオープニングパスワードが設定されていて、かつ提供されたパスワードが正しい場合にのみ `true` を返します。次のいずれかの場合は `false` を返します：

- パスワードが正しくありません。
- プレゼンテーションにオープニングパスワードが設定されていません。
- 提供されたパスワードが `null` または空です。

この動作は PPT と PPTX の両方で同じです。

## **読み込まれたプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) を確認して、元のプレゼンテーションが暗号化されていたかを確認します。読み込む前にオープニングパスワード保護を検出するには、上記と同様に `IPresentationInfo.isPasswordProtected` を使用します。

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
オープニングパスワードをログに記録したり診断メッセージに含めたりしないでください。不要な再検証は避け、パスワードは必要な期間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。

プレゼンテーションの内容が暗号化されていても、公開されたドキュメントプロパティは作者名、タイトル、サブジェクト、キーワード、会社情報、コメント、およびカスタム値を露出させる可能性があります。機密メタデータはプレゼンテーションとともに暗号化してください。プロパティを公開することは、システムがオープニングパスワードなしでファイルをインデックス、分類、検索、または管理しなければならない場合にのみ、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護をかける**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択するかアップロードします。
3. 表示保護用のパスワードを入力します。
4. 必要に応じて編集保護用の別のパスワードを入力します。
5. 保護を適用し、生成されたファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニングパスワードと書き込み保護パスワードの違いは何ですか？**

オープニングパスワードはプレゼンテーションを暗号化し、内容を読み込むために必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずにオープニングパスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニングパスワード保護があるか確認した上で、完全なプレゼンテーションインスタンスを作成せずにパスワードを検証できます。

**アプリケーションはオープニングパスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションがドキュメントプロパティの暗号化を無効にして暗号化された場合に限ります。その場合は、[Manage Presentation Properties](/slides/ja/androidjava/presentation-properties/) で説明されているドキュメントプロパティのみの読み込みモードを使用してください。

**パスワード検証ワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスとストリームベースのパスワード検出および検証は、PPT と PPTX のプレゼンテーションで同じように動作します。