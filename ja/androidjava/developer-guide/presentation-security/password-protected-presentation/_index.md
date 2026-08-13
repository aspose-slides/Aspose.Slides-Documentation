---
title: Android でパスワードでプレゼンテーションを保護
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/androidjava/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロック解除
- プレゼンテーションのロック解除
- PowerPoint を保護
- プレゼンテーションを保護
- パスワードを設定
- パスワードを追加
- PowerPoint を暗号化
- プレゼンテーションを暗号化
- PowerPoint を復号化
- プレゼンテーションを復号化
- 書き込み保護
- PowerPoint のセキュリティ
- プレゼンテーションのセキュリティ
- パスワードを削除
- 保護を削除
- 暗号化を削除
- パスワードを無効化
- 保護を無効化
- 書き込み保護を削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、PowerPoint および OpenDocument のプレゼンテーションを簡単にパスワードでロック・アンロックできます。プレゼンテーションを安全に保護しましょう。"
---
## **概要**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードが設定されます。制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、次のような制限をプレゼンテーションに設定できます。

- **変更制限**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合、変更制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの内容を変更、編集、コピーできなくなります。

  ただし、パスワードがなくてもユーザーはドキュメントを開いて閲覧できます。この読み取り専用モードでは、ハイパーリンクやアニメーション、エフェクトなどのコンテンツは表示できますが、項目のコピーやプレゼンテーションの保存はできません。

- **開くことの制限**

  特定のユーザーだけにプレゼンテーションを開くことを許可したい場合、開くことの制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの内容自体を閲覧できなくなります。

  技術的には、開くことの制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けなければ、変更や編集もできません。

  **注意** パスワードで開くことを防止するためにプレゼンテーションを保護すると、ファイルは暗号化されます。

## **Aspose.Slides のプレゼンテーション向けパスワード保護**
**サポート形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、類似の操作をサポートします。

- PPTX および PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーションテンプレート

**サポート操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、パスワード保護と暗号化に関する以下の操作も提供します。

- プレゼンテーションの復号化／暗号化されたプレゼンテーションの開封
- 暗号化の解除／パスワード保護の無効化
- プレゼンテーションから書き込み保護を解除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **プレゼンテーションの暗号化**

パスワードを設定してプレゼンテーションを暗号化できます。ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを入力する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager) の `encrypt` メソッドを使用してパスワードを設定し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

以下のサンプルコードは、プレゼンテーションを暗号化する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションへの書き込み保護の設定**

プレゼンテーションに「変更しないでください」というマークを付けることができます。これにより、ユーザーに対してプレゼンテーションの変更を求めない旨を通知できます。

**注意** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。そのため、ユーザーが実際に変更したい場合はプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。以下のサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号化されたプレゼンテーションの読み込み**

Aspose.Slides は、正しいパスワードを [LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) に渡すことで暗号化されたプレゼンテーションを読み込むことができます。

以下のサンプルコードは、暗号化されたプレゼンテーションを開く方法を示しています。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで作業する
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションから暗号化を解除する**

プレゼンテーションの暗号化やパスワード保護を解除できます。これにより、ユーザーは制限なくプレゼンテーションにアクセスしたり変更したりできるようになります。

暗号化またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。以下のサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションから書き込み保護を解除する**

Aspose.Slides を使用して、プレゼンテーションファイルに設定された書き込み保護を解除できます。これにより、ユーザーは自由に変更でき、警告も表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。以下のサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号化されたプレゼンテーションのプロパティ取得**

暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティを取得するのは難しいと感じるユーザーが多いですが、Aspose.Slides は、プレゼンテーションをパスワード保護しながらもプロパティへのアクセスを可能にする機構を提供します。

**注** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、ドキュメントプロパティもパスワード保護されます。暗号化後もプロパティにアクセスできるようにしたい場合は、[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡すことで実現できます。以下のサンプルコードは、暗号化しつつドキュメントプロパティへのアクセスを許可する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **暗号化されたプレゼンテーションからドキュメントプロパティのみをロードする**

スライドやその他のコンテンツを読み込まずに、暗号化されたプレゼンテーションのメタデータだけを確認したい場合は、[LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) オブジェクトを作成し、`setOnlyLoadDocumentProperties` に `true` を渡します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティのみをロードします。

以下のコード例は、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) を使用して組み込みおよびカスタムドキュメントプロパティを読み取る方法を示しています。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 組み込みドキュメントプロパティを読み取る。
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // カスタムドキュメントプロパティを読み取る。
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

このワークフローは、暗号化時にドキュメントプロパティが暗号化されていない（公開状態）場合にのみ機能します。プロパティが暗号化されている場合、`loadOptions.setOnlyLoadDocumentProperties` に `true` を渡すと例外がスローされます。暗号化されたプロパティにアクセスしたり、スライドやその他のコンテンツを含むプレゼンテーション全体をロードしたりするには、[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) に正しいパスワードを渡してください。

## **プレゼンテーションがパスワード保護されているかの確認**

プレゼンテーションをロードする前に、パスワード保護されていないか確認したいことがあります。これにより、パスワードがない状態で保護されたプレゼンテーションをロードしようとして発生するエラーや問題を回避できます。

この Java コードは、プレゼンテーション自体をロードせずにパスワード保護されているかどうかを調べる方法を示しています。

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているかの確認**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認する機能を提供します。この操作には、暗号化されていれば `true`、されていなければ `false` を返す [isEncrypted](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) プロパティを使用します。

以下のサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているかの確認**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認する機能を提供します。この操作には、書き込み保護されていれば `true`、されていなければ `false` を返す [isWriteProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) プロパティを使用します。

以下のサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードが使用されたかの検証または確認**

プレゼンテーションが特定のパスワードで保護されているかどうかを確認したい場合があります。Aspose.Slides はパスワードの検証手段を提供します。

以下のサンプルコードは、パスワードを検証する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // 「pass」が一致するか確認する
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

指定されたパスワードで書き込み保護が行われている場合は `true`、それ以外の場合は `false` が返されます。

{{% alert color="info" title="See also" %}} 
- [PowerPoint のデジタル署名](/slides/ja/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートしており、プレゼンテーションのデータセキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化・復号化の処理により、開く時や保存時に若干のオーバーヘッドが発生することがあります。多くの場合、この影響は最小限であり、プレゼンテーション処理全体の時間に大きな影響を与えることはありません。