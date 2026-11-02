---
title: JavaScript でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides for Node.js via Java は **組み込み** および **カスタム** ドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義値などのプレゼンテーション メタデータを読み取り、更新できます。

Aspose.Slides では、プレゼンテーションのドキュメント プロパティを [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) クラスを使用して操作できます。このクラスのインスタンスは [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) で取得されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示します。

{{% alert color="info" title="Note" %}}

Aspose.Slides はプレゼンテーションを保存する際にアプリケーションおよびプロデューサーのメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。

{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツと一緒に記述情報を格納します。これらは 2 つのカテゴリに分かれます。

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを格納します。

Aspose.Slides for Node.js via Java は両方のカテゴリへのアクセスを提供します。PowerPoint では、**File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認します。このダイアログは情報を **Summary**、**Statistics**、**Contents**、**Custom** などのタブに分類します。**Custom** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開封パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) を `false` で呼び出した後にプレゼンテーションが暗号化されると、ドキュメント プロパティは公開されたままになります。アプリケーションはその後、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出すことで、開封パスワードを提供せずに公開メタデータを読み取れます。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) は Aspose.Slides がロードする対象を制御しますが、復号は行いません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例では、ドキュメント プロパティが公開されたままの暗号化プレゼンテーションが必要です。[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) でロード モードを確認し、続いて [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) を使用して組み込みプロパティを読み取ります。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

このモードでは、スライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を実行する前に、必ず [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) を確認してください。

{{% alert color="warning" title="Warning" %}}
公開メタデータにより、作成者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ、公開したままにします。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出してロードしたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides は、メタデータのみのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新には正しい開封パスワードと完全なロードが必要です。

この例では、公開ドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知の開封パスワードが必要です。[LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) でプレゼンテーション全体を開き、公開組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティを読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) クラスは、[getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)、[getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle)、[getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) などの getter メソッドを通じて組み込みメタデータを公開します。この例では既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、フィールドによっては空の場合があります。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) が返すオブジェクトの setter メソッドを使用します。この例では既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)、[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)、[setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)、[setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments)、[setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) を呼び出し、[Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハイパーリンク ベースの管理**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) は相対ハイパーリンク用のドキュメント レベルのベースを返します。[DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) を使用して変更またはクリアできます。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) とは別物で、ベースを変更しても保存されたリンク アドレスは書き換えられず、絶対パスの宛先も変わりません。

この例では、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、新しいベース アドレスを設定し、プレゼンテーションを保存して再度開き値を確認します。その後、空文字列でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスは、リンクされたファイルの場所に置き換えてください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

2 つの検証メッセージは `true` と出力されるはずです。ベースをクリアしても個々のハイパーリンク アドレスはそのまま残ります。

ベースが `old` フォルダーを指しているとき、相対リンク `target.pptx` は `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタムプロパティは、組み込みフィールドに対応しないメタデータを格納します。[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) メソッドを使用すると、プロパティ名で値を割り当てられます。この例ではプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値を追加し、[Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) で保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換わります。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カスタム プロパティへのアクセスと変更**

この例ではカスタムプロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) を使用してそれらを列挙します。[getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) は 0 ベースのインデックスを受け取り、[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) で使用される名前を返します。例では各元の名前と値を出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタムプロパティがない場合、ループは何も変更しません。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ライブ例**

Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認するには、オンライン アプリ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) を試してください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可分な要素であり、完全に削除することはできません。ただし、プロパティの値を変更するか、該当プロパティが許可する場合は空に設定することはできます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) を使用し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/nodejs-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを開封パスワードなしで読み取れますか？**

はい。プレゼンテーションは [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) を `false` で呼び出した後に暗号化され、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出してロードされている必要があります。

**文書プロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開封パスワードでプレゼンテーション全体をロードする必要があります。