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
## **イントロダクション**

Aspose.Slides は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートします。これらのプロパティは、Aspose.Slides API を使用して簡単に取得および管理できます。

Aspose.Slides は、[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) クラスを介してプレゼンテーション ドキュメント プロパティを操作できます。このクラスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDocumentProperties) メソッドによって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}

**Application** および **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにそれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Node.js via Java」とライブラリのバージョンを報告します。`setNameOfApplication` に渡された任意の値は、プレゼンテーションの書き込み時に破棄されます。

{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint では、プレゼンテーション ファイルにいくつかのプロパティを追加する機能が提供されています。これらのドキュメント プロパティにより、ドキュメント (プレゼンテーション ファイル) と共に有用な情報を保存できます。ドキュメント プロパティは次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティには、ドキュメント タイトル、作者名、統計情報などの一般的な情報が含まれます。**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するものです。Aspose.Slides for Node.js via Java を使用すると、開発者は組み込みプロパティとカスタム プロパティの値にアクセスし、変更できます。

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。操作は、Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（以下の図参照）。

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます（以下の図参照）。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **プロパティ ダイアログ** には、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブページがあり、PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

### Aspose.Slides for Node.js via Java を使用したドキュメント プロパティの操作

前述の通り、Aspose.Slides for Node.js via Java は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は Aspose.Slides for Node.js via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Node.js via Java は、**Presentation.DocumentProperties** プロパティを介してプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表す [DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties) クラスを提供します。

開発者は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くためのパスワードは通常、プレゼンテーション内容とドキュメント プロパティの両方を保護します。`false` を [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に渡して暗号化した場合、ドキュメント プロパティは公開されたままになります。その後、`true` を [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) に渡すことで、開くパスワードを提供せずに公開メタデータを読み取れます。

「ドキュメント プロパティのみ」オプションは Aspose.Slides が読み込む対象を制御しますが、暗号化は行いません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

次の例は、[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) でロードモードを確認し、続いて [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDocumentProperties) で組み込みプロパティを読み取ります。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

このモードではスライド コンテンツはロードされません。スライド、マスタ、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、プレゼンテーション全体のオブジェクト モデルが必要な操作を行う前に、必ず [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) をチェックすべきです。

{{% alert color="warning" title="Warning" %}}
公開メタデータには、作者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密性の高いプロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでのアクセスを特に要求する場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、ドキュメント プロパティのみモードでロードされたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides は、このメタデータのみオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内のデータと整合性を保つ必要があるため、正しい開くパスワードと完全なロードが必要です。

次の例は、[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) でプレゼンテーションを開き、公開の組み込みプロパティを更新し、結果を保存します。その後、[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties) オブジェクトが公開するプロパティは次のとおりです: **Creator** (Author)、**Description**、**Keywords**、**Created** (作成日)、**Modified** (更新日)、**Printed** (最終印刷日)、**LastModifiedBy**、**SharedDoc** (複数の作成者で共有されているか)、**PresentationFormat**、**Subject**、**Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーションを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成する
    var dp = pres.getDocumentProperties();
    // 組み込みプロパティを表示する
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、取得と同様に簡単です。目的のプロパティに文字列値を代入するだけで、プロパティの値が変更されます。以下の例は、Aspose.Slides for Node.js via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成する
    var dp = pres.getDocumentProperties();
    // 組み込みプロパティを設定する
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // プレゼンテーションをファイルに保存する
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

この例は、変更後の組み込みドキュメント プロパティを以下のように示します。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Node.js via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加する機能も提供します。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // ドキュメント プロパティを取得
    var dProps = pres.getDocumentProperties();
    // カスタム プロパティを追加
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 特定のインデックスのプロパティ名を取得
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 選択したプロパティを削除
    dProps.removeCustomProperty(getPropertyName);
    // プレゼンテーションを保存
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**追加されたカスタム ドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for Node.js via Java は、カスタム プロパティの値にアクセスする機能も提供します。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成する
    var dp = pres.getDocumentProperties();
    // カスタム プロパティにアクセスして変更する
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタム プロパティの名前と値を表示する
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // カスタム プロパティの値を変更する
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // プレゼンテーションをファイルに保存する
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

この例は、[PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) が [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo) に追加され、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

2 つの新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) が [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo) クラスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更と更新を可能にします。

典型的なシナリオは、プロパティをロードし、いくつかの値を変更してドキュメントを更新することで、以下のように実装できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーションの情報を取得する
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 現在のプロパティを取得する
var props = info.readDocumentProperties();
// Author と Title フィールドの新しい値を設定する
props.setAuthor("New Author");
props.setTitle("New Title");
// 新しい値でプレゼンテーションを更新する
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することができます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新するために使用することも可能です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **校正言語の設定**

Aspose.Slides は、PortionFormat クラスで公開されている LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語とは、PowerPoint のスペルと文法チェックが行われる言語のことです。

以下の JavaScript コードは、PowerPoint の校正言語を設定する方法を示しています: xxx JavaScript PortionFormat クラスに LanguageId がないのはなぜですか？

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// 校正言語の ID を設定する
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **デフォルト言語の設定**

以下の JavaScript コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 新しい長方形シェイプにテキストを追加する
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 最初のポーションの言語を確認する
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当プロパティが許可する場合は空に設定したりできます。

**すでに存在するカスタム プロパティを追加した場合、どうなりますか？**

既存のカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、次に [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/nodejs-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを、開くパスワードなしで読み取れますか？**

はい。ドキュメント プロパティの暗号化がプレゼンテーションの暗号化前に無効化され、プレゼンテーションが「ドキュメント プロパティのみ」モードでロードされている必要があります。

**暗号化された PPTX ファイルを「ドキュメント プロパティのみ」モードで更新できますか？**

できません。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開くパスワードでプレゼンテーション全体をロードする必要があります。