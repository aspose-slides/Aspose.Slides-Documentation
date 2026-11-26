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
- カスタム プロパティ
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

Aspose.Slides for Node.js via Java は **組み込み** および **カスタム** ドキュメント プロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーション メタデータを読み取りおよび更新できます。

Aspose.Slides を使用すると、[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) クラスを介してプレゼンテーション ドキュメント プロパティを操作できます。このクラスのインスタンスは [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) によって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションおよびプロデューサ メタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツと共に記述情報を保存します。これらは 2 つのカテゴリに分類されます。

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを保存します。

Aspose.Slides for Node.js via Java は両方のカテゴリへのアクセスを提供します。PowerPoint で、**File → Info → Properties → Advanced Properties** を選択してドキュメント メタデータを確認できます。ダイアログは情報を **Summary**、**Statistics**、**Contents**、**Custom** といったタブに分類します。**Custom** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションからパブリック プロパティを読み取る**

オープニング パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) を `false` で呼び出した後にプレゼンテーションが暗号化されると、ドキュメント プロパティはパブリックのまま残ります。その後、アプリケーションは [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出すことで、オープニング パスワードを提供せずにパブリック メタデータを読み取ることができます。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) は Aspose.Slides が読み込む内容を制御します；暗号化は行われません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

この例は、ドキュメント プロパティがパブリックのまま残された暗号化されたプレゼンテーションを前提としています。[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) で読み込みモードを確認し、次に [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) で組み込みプロパティを読み取ります：

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

このモードではスライド コンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルを必要とする操作を行う前に、必ず [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) を確認してください。

{{% alert color="warning" title="Warning" %}}
パブリック メタデータは、作成者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値などを露出させる可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでのアクセスを特別に要求する場合のみ、パブリックのままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出した後にロードされたプレゼンテーションはパブリック メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみのオブジェクトから変更されたプロパティを保存できません。パブリック プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新には正しいオープニング パスワードと完全なロードが必要です。

この例は、パブリック ドキュメント プロパティと既知のオープニング パスワードを持つ暗号化された PPTX プレゼンテーションを前提としています。[LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) でプレゼンテーション全体を開き、パブリック 組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) を使用して暗号化が維持されていることを確認し、パスワードなしでパブリック メタデータを再度開いて新しい値を確認します：

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

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化された PPTX ファイルのパブリック プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティにアクセスする**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) クラスは、[getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)、[getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle)、[getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) などのゲッターメソッドを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、いくつかのフィールドは空の場合があります。

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

### **リビジョン番号と編集時間のレポート**

`presentations` フォルダー内の各 PPTX ファイルのリビジョン番号と総編集時間をレポートするには、[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) を使用します。これにより、スライドを編集用にロードせずにファイルの [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) が返されます。例では、記録された期間をミリ秒から時間、分、秒に変換します。24 時間以上の期間の場合、時間の前に全日数を付加します。

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

記録された編集時間が 1 日 2 時間 5 分のプレゼンテーションの場合、レポートは以下の出力を示します。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) は、アプリケーションが [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) で変更できる値を読み取ります。リビジョン番号だけでは、プレゼンテーションが保存された回数やバージョン履歴を再構築することはできません。

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) はファイルに記録された編集期間を読み取ります。`00:0:0` の値は、誰かがプレゼンテーションを編集した場合でも、保存された期間がゼロであることを意味します。

## **組み込みプロパティを変更する**

組み込みメタデータを更新するには、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) が返すオブジェクトのセッターメソッドを使用します。この例は既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)、[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)、[setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)、[setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments)、[setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) を呼び出し、[Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

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

## **ハイパーリンクベースを管理する**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) は相対ハイパーリンク用のドキュメントレベルのベースを返します。[DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) を使用して変更またはクリアできます。これは、プレゼンテーションとリンクされたファイルを別の場所に移動するときに便利です。個々のハイパーリンクの [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) とは別物で、ベースを変更しても保存されたリンクアドレスは書き換えられず、絶対的な宛先も変わりません。

この例は、相対リンク（例: `target.html`）と絶対リンク（例: `https://example.org/absolute.html`）の両方を含むプレゼンテーションを前提としています。既存のベースを読み取り、新しいベース アドレスを割り当て、プレゼンテーションを保存して再度開き、値を確認します。その後、空文字列でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスは、リンクされたファイルの場所に置き換えてください。

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

2 つの検証メッセージは `true` を出力するはずです。ベースをクリアしても、個々のハイパーリンク アドレスはそのまま残ります。

`target.pptx` への相対リンクは、ベースが `old` フォルダーを指しているとき `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティを追加する**

カスタム プロパティは、対応する組み込みフィールドがないメタデータを保存します。[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) メソッドを使用すると、プロパティ名で値を設定できます。この例はプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値を追加し、[Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) でプレゼンテーションを保存します。既存の名前に値を割り当てると、そのプロパティの値は置き換えられます。

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

## **カスタム プロパティにアクセスして変更する**

この例はカスタム プロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) を使用してそれらを反復処理します。[getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) はゼロベースのインデックスを受け取り、[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) で使用される名前を返します。例では各元の名前と値を出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタム プロパティがない場合、ループは何も変更しません。

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

Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認するには、オンライン アプリの [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) を試してください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合は、値を変更するか空に設定することができます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) を使用し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) を使用すると、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[軽量プレゼンテーションインベントリの作成](/slides/ja/nodejs-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションのオープニング パスワードなしでパブリック プロパティを読み取れますか？**

はい。プレゼンテーションは [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) を `false` で呼び出した後に暗号化され、[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) を `true` で呼び出した後にロードされている必要があります。

**ドキュメント プロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。パブリック プロパティと暗号化されたプロパティ データは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しいオープニング パスワードでプレゼンテーション全体をロードする必要があります。