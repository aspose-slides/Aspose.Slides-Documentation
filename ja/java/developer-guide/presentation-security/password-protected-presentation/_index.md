---
title: Java でパスワード付きプレゼンテーションを保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/java/password-protected-presentation/
keywords:
- PowerPoint をロック
- プレゼンテーションをロック
- PowerPoint のロックを解除
- プレゼンテーションのロックを解除
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
- 保護を解除
- 暗号化を解除
- パスワードを無効化
- 保護を無効化
- 書き込み保護を解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、パスワードで保護された PowerPoint および OpenDocument プレゼンテーションを簡単にロックおよびアンロックする方法を学びましょう。プレゼンテーションを安全に保護できます。"
---
## **はじめに**

プレゼンテーションにパスワード保護を設定すると、プレゼンテーションに対して特定の制限を課すパスワードを設定したことになります。これらの制限を解除するには、パスワードを入力する必要があります。パスワードで保護されたプレゼンテーションは、ロックされたプレゼンテーションと見なされます。

通常、プレゼンテーションに対してこれらの制限を適用するためにパスワードを設定できます：

- **変更**

  特定のユーザーだけにプレゼンテーションの変更を許可したい場合は、変更の制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーション内の要素を変更、編集、コピーできなくなります。

  ただし、パスワードがなくてもユーザーはドキュメントを開くことができます。この読み取り専用モードでは、ユーザーはコンテンツ（ハイパーリンク、アニメーション、エフェクト、その他の要素を含む）を閲覧できますが、項目をコピーしたりプレゼンテーションを保存したりすることはできません。

- **開く**

  特定のユーザーだけにプレゼンテーションの閲覧を許可したい場合は、開く制限を設定できます。この制限により、パスワードを入力しない限り、プレゼンテーションの内容を表示さえできなくなります。

  技術的には、開く制限はプレゼンテーションの変更も防止します。プレゼンテーションを開けなければ、変更や編集もできないからです。

**Note:** 開くことを防止するためにプレゼンテーションにパスワード保護を設定すると、プレゼンテーションファイルは暗号化されます。

## **Aspose.Slides のパスワード保護**
**サポート形式**

Aspose.Slides は、次の形式のプレゼンテーションに対してパスワード保護、暗号化、同様の操作をサポートします。

- PPTX と PPT - Microsoft PowerPoint プレゼンテーション
- ODP - OpenDocument プレゼンテーション
- OTP - OpenDocument プレゼンテーション テンプレート

**サポートされている操作**

Aspose.Slides では、次の方法でプレゼンテーションの変更を防止するためにパスワード保護を使用できます。

- プレゼンテーションの暗号化
- プレゼンテーションへの書き込み保護の設定

**その他の操作**

Aspose.Slides は、次の方法でパスワード保護と暗号化に関連するその他のタスクを実行できます。

- プレゼンテーションの復号化；暗号化されたプレゼンテーションのオープン
- 暗号化の解除；パスワード保護の無効化
- プレゼンテーションから書き込み保護を削除
- 暗号化されたプレゼンテーションのプロパティ取得
- プレゼンテーションが暗号化されているかの確認
- プレゼンテーションがパスワード保護されているかの確認

## **パスワードでプレゼンテーションを保護する**

プレゼンテーションにパスワードを設定して暗号化できます。その後、ロックされたプレゼンテーションを変更するには、ユーザーはパスワードを提供する必要があります。

プレゼンテーションを暗号化またはパスワード保護するには、[IProtectionManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager) の `encrypt` メソッドを使用してプレゼンテーションにパスワードを設定します。パスワードを `encrypt` メソッドに渡し、`save` メソッドで暗号化されたプレゼンテーションを保存します。

このサンプルコードは、プレゼンテーションを暗号化する方法を示しています。

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

## **プレゼンテーションに書き込み保護を設定する**

プレゼンテーションに「変更しないでください」というマークを追加できます。これにより、ユーザーに対してプレゼンテーションを変更しないよう指示できます。

**Note** 書き込み保護のプロセスはプレゼンテーションを暗号化しません。したがって、ユーザーは実際に変更したい場合はプレゼンテーションを変更できますが、変更を保存するには別名で保存する必要があります。

書き込み保護を設定するには、[setWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) メソッドを使用します。このサンプルコードは、プレゼンテーションに書き込み保護を設定する方法を示しています。

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

## **暗号化されたプレゼンテーションのロード**

Aspose.Slides は、正しいパスワードを [LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) を介して渡すことで暗号化されたプレゼンテーションをロードできます。

このサンプルコードは、暗号化されたプレゼンテーションをロードする方法を示しています。

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

プレゼンテーションの暗号化またはパスワード保護を解除できます。これにより、ユーザーは制限なしでプレゼンテーションにアクセスまたは変更できるようになります。

暗号化またはパスワード保護を解除するには、[removeEncryption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#removeEncryption--) メソッドを呼び出します。このサンプルコードは、プレゼンテーションから暗号化を解除する方法を示しています。

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

Aspose.Slides を使用してプレゼンテーション ファイルに適用された書き込み保護を解除できます。これにより、ユーザーは好きなように変更でき、警告も表示されません。

書き込み保護を解除するには、[removeWriteProtection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) メソッドを使用します。このサンプルコードは、プレゼンテーションから書き込み保護を解除する方法を示しています。

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

通常、ユーザーは暗号化またはパスワード保護されたプレゼンテーションのドキュメントプロパティの取得に苦労します。しかし、Aspose.Slides は、プレゼンテーションをパスワード保護しながらも、ユーザーがプロパティにアクセスできるメカニズムを提供します。

**Note:** デフォルトでは、Aspose.Slides がプレゼンテーションを暗号化すると、プレゼンテーションのドキュメントプロパティもパスワード保護されます。暗号化後もドキュメントプロパティにアクセスできるようにする必要がある場合、Aspose.Slides はそれを可能にします。

暗号化されたプレゼンテーションのプロパティへのアクセスを許可したい場合は、[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡します。このサンプルコードは、プレゼンテーションを暗号化しつつ、ドキュメントプロパティへのアクセスを提供する方法を示しています。

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

スライドやその他のコンテンツをロードせずに暗号化されたプレゼンテーションのメタデータを調査するには、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) オブジェクトを作成し、`setOnlyLoadDocumentProperties` に `true` を渡します。このモードでは、Aspose.Slides はパスワードを無視し、公開されているドキュメントプロパティのみをロードします。

以下のコード例は、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDocumentProperties--) を使用して組み込みおよびカスタム ドキュメントプロパティを読み取ります。

```java
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

このワークフローは、プレゼンテーションが暗号化されたときにドキュメントプロパティが暗号化されていない（公開）場合にのみ機能します。ドキュメントプロパティが暗号化されている場合、`loadOptions.setOnlyLoadDocumentProperties` に `true` を渡すと例外がスローされます。暗号化されたドキュメントプロパティにアクセスするか、スライドやその他のコンテンツを含むプレゼンテーション全体をロードするには、[ILoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) を使用して正しいパスワードを提供してください。

## **プレゼンテーションがパスワード保護されているか確認する**

プレゼンテーションをロードする前に、パスワードで保護されていないか確認したい場合があります。これにより、パスワード保護されたプレゼンテーションをパスワードなしでロードしたときに発生するエラーや類似の問題を回避できます。

この Java コードは、プレゼンテーション自体をロードせずにパスワード保護されているかどうかを調べる方法を示しています。

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **プレゼンテーションが暗号化されているか確認する**

Aspose.Slides は、プレゼンテーションが暗号化されているかどうかを確認できます。このタスクを実行するには、`isEncrypted` プロパティを使用します。プレゼンテーションが暗号化されていれば `true`、暗号化されていなければ `false` が返されます。

このサンプルコードは、プレゼンテーションが暗号化されているかどうかを確認する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **プレゼンテーションが書き込み保護されているか確認する**

Aspose.Slides は、プレゼンテーションが書き込み保護されているかどうかを確認できます。このタスクを実行するには、`isWriteProtected` プロパティを使用します。プレゼンテーションが書き込み保護されていれば `true`、そうでなければ `false` が返されます。

このサンプルコードは、プレゼンテーションが書き込み保護されているかどうかを確認する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **特定のパスワードが使用されたか検証または確認する**

プレゼンテーションが特定のパスワードで保護されているかどうかを確認したい場合があります。Aspose.Slides はパスワードを検証する手段を提供します。

このサンプルコードは、パスワードを検証する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" が一致するか確認
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

パスワードで書き込み保護されたプレゼンテーションであれば `true` を返し、そうでなければ `false` を返します。

{{% alert color="info" title="参照" %}} 
- [PowerPoint のデジタル署名](/slides/ja/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides がサポートする暗号化方式は何ですか？**

Aspose.Slides は AES ベースのアルゴリズムを含む最新の暗号化方式をサポートし、プレゼンテーションのデータ セキュリティを高いレベルで確保します。

**プレゼンテーションを開く際に誤ったパスワードを入力した場合はどうなりますか？**

誤ったパスワードが使用されると例外がスローされ、プレゼンテーションへのアクセスが拒否されたことが通知されます。これにより不正アクセスが防止され、コンテンツが保護されます。

**パスワード保護されたプレゼンテーションを扱う際のパフォーマンスへの影響はありますか？**

暗号化および復号化のプロセスにより、開く時や保存時に若干のオーバーヘッドが発生する可能性があります。ほとんどの場合、このパフォーマンスへの影響は最小限で、プレゼンテーション処理全体の時間に大きな差は生じません。