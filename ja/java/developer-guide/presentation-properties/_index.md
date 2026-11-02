---
title: Javaでプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/java/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides for Java は **組み込み** と **カスタム** のドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーション メタデータを読み取り、更新できます。

Aspose.Slides を使用すると、[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) から取得されます。以下の例では、これらのプロパティの読み取り、変更、および管理方法を示します。

{{% alert color="info" title="注意" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションおよび製作者のメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを特定します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツとともに記述情報を保持します。これらは 2 つのカテゴリに分かれます：

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを保存します。

Aspose.Slides for Java は両方のカテゴリへのアクセスを提供します。PowerPoint では **File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認します。ダイアログは情報を **Summary**、**Statistics**、**Contents**、**Custom** などのタブに分けます。**Custom** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開閉パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) を `false` で呼び出した後に暗号化された場合、ドキュメント プロパティは公開されたままです。アプリケーションはその後、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) を `true` で設定し、開閉パスワードを提供せずに公開メタデータを読み取れます。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) は Aspose.Slides のロード対象を制御しますが、暗号化は行いません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例は、ドキュメント プロパティが公開された暗号化プレゼンテーションを必要とします。[IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) でロードモードを確認し、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) を介して組み込みプロパティを読み取ります。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、プレゼンテーション全体のオブジェクト モデルが必要な操作を行う前に必ず [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) を確認してください。

{{% alert color="warning" title="警告" %}}
公開メタデータには作成者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでアクセスする特定の要件がある場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルで、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) を `true` に設定してロードしたプレゼンテーションは、公開メタデータの読み取り専用として扱われます。このメタデータのみのオブジェクトから変更されたプロパティを保存することはできません。公開プロパティは暗号化されたプレゼンテーション内部のデータと一貫性を保つ必要があるため、正しい開閉パスワードで完全にロードする必要があります。

この例は、公開ドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知の開閉パスワードを前提とします。[LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) でプレゼンテーション全体を開き、公開の組み込みプロパティを更新して結果を保存します。その後、[IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) で暗号化が維持されていることを確認し、パスワードなしで公開メタデータを再度開き、新しい値を検証します。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

アプリケーションがプレゼンテーション コンテンツを復号またはロードできない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティにアクセスする**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) インターフェイスは、[getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--)、[getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) などの取得メソッドを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、コンソールに保存されたメタデータを出力します。値は入力プレゼンテーションに依存し、フィールドが空の場合もあります。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **組み込みプロパティを変更する**

組み込みメタデータを更新するには、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) が返すオブジェクトのセッター メソッドを使用します。この例は既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-) 、[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-) 、[setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-) 、[setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) 、[setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) を呼び出し、更新されたプレゼンテーションを [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) で保存します。保存された PPTX には新しいメタデータが含まれます。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハイパーリンクベースを管理する**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) は相対ハイパーリンク用のドキュメント レベルのベースを返します。[IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) を使用して変更またはクリアできます。これは、プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。個々のハイパーリンクの [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) とは別で、ベースを変更しても保存されたリンク アドレスや絶対的な宛先は書き換えられません。

この例は、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションを前提とします。既存のベースを読み取り、新しいベース アドレスを設定し、プレゼンテーションを保存して再度開き、値を確認します。その後、空文字列でベースをクリアし、別ファイルで空の値を検証します。例のベース アドレスはリンクされたファイルの場所に置き換えてください。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

2 つの検証メッセージは共に `true` と出力されます。ベースをクリアしても個別のハイパーリンク アドレスはそのまま残ります。

ベースが `old` フォルダーを指しているとき、相対リンク `target.pptx` は `old/target.pptx` を開きます。ベースを `new` フォルダーに変更し、保存・再オープンすると同じリンクは `new/target.pptx` を開きます。絶対リンクは従来どおり同じファイルを開きます。プレゼンテーションを移動またはベースを変更する前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティを追加する**

カスタムプロパティは、組み込みフィールドに対応しないメタデータを格納します。[IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) メソッドを使用して、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値を追加し、[Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) で保存します。既存の名前に値を割り当てると、そのプロパティの値は上書きされます。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カスタム プロパティにアクセスし、変更する**

この例はカスタムプロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) を使用してそれらを反復処理します。[getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) はゼロベースのインデックスを受け取り、[IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) で使用される名前を返します。例は各元の名前と値を出力し、元の型にかかわらず番号付き文字列に置き換えて変更を保存します。カスタムプロパティが存在しない場合、ループは何も変更しません。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ライブ例**

[**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティで許可されている場合は、値を変更するか空文字列に設定できます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除や確認を行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、続いて [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット別の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/java/examine-presentation/) を参照してください。

**開閉パスワードなしで暗号化されたプレゼンテーションの公開プロパティを読み取れますか？**

はい。プレゼンテーションは [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) を `false` で呼び出した後に暗号化され、かつ [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) を `true` でロードされている必要があります。

**ドキュメント プロパティのみのモードで暗号化された PPTX ファイルを更新できますか？**

できません。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開閉パスワードでプレゼンテーション全体をロードする必要があります。