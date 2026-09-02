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
## **概要**

Aspose.Slides は、**Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティタイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides を使用すると、[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) クラスを介してプレゼンテーション ドキュメント プロパティを操作できます。このクラスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDocumentProperties) メソッドによって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}
※ **Application** および **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Node.js via Java」およびそれを生成したライブラリのバージョンを報告します。`setNameOfApplication` に渡された任意の値は、プレゼンテーションを書き込む際に破棄されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint には、プレゼンテーション ファイルにプロパティを追加する機能があります。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と共に有用な情報を保存できます。ドキュメント プロパティは以下の 2 種類があります。

- システム定義 (Built-in) プロパティ
- ユーザー定義 (Custom) プロパティ

**Built-in** プロパティは、ドキュメントのタイトル、著者名、統計情報など、一般的な情報を含みます。**Custom** プロパティは、ユーザーが **Name/Value** ペアとして定義するもので、名前と値の両方をユーザーが設定します。Aspose.Slides for Node.js via Java を使用すると、開発者は組み込みプロパティとカスタム プロパティの値にアクセスして変更できます。

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下に示すように、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。

|**高度なプロパティ メニュー項目の選択**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||

**Advanced Properties** メニュー項目を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが以下の図のように表示されます。

|**プロパティ ダイアログ**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||

上記の **Properties Dialog** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** など多数のタブ ページがあることが確認できます。これらのタブは、PowerPoint ファイルに関するさまざまな情報を構成するために使用されます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **Aspose.Slides for Node.js via Java を使用したドキュメント プロパティの操作**

前述のとおり、Aspose.Slides for Node.js via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for Node.js via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Node.js via Java は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを **Presentation.DocumentProperties** プロパティを通じて表す [DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties) クラスを提供します。

開発者は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

これらのプロパティは、[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties) オブジェクトで公開され、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数の作成者間で共有されているか）、**PresentationFormat**、**Subject**、**Title** が含まれます。

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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for Node.js via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

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

この例では、プレゼンテーションの組み込みプロパティが以下のように変更されます。

|**変更後の組み込みドキュメント プロパティ**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Node.js via Java は、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // ドキュメント プロパティを取得する
    var dProps = pres.getDocumentProperties();
    // カスタム プロパティを追加する
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 特定のインデックスのプロパティ名を取得する
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 選択したプロパティを削除する
    dProps.removeCustomProperty(getPropertyName);
    // プレゼンテーションを保存する
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**追加されたカスタム ドキュメント プロパティ**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for Node.js via Java は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

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

この例では、[PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前と変更後のプレゼンテーション カスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**変更後のカスタム プロパティ**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}
新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) が [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo) に追加されました。また、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

2 つの新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) が [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo) クラスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更と更新が可能です。

典型的なシナリオは、プロパティをロードし、値を変更し、ドキュメントを更新することで、以下のように実装できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーションの情報を読み取る
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

特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法があります。

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

新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新するために使用できます。

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

Aspose.Slides は、PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できるようにします。校正言語とは、PowerPoint のスペルと文法がチェックされる言語です。

この JavaScript コードは、PowerPoint の校正言語を設定する方法を示しています: xxx なぜ JavaScript の PortionFormat クラスに LanguageId がないのでしょうか？

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

この JavaScript コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // テキスト付きの新しい長方形シェイプを追加する
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

オンライン アプリの [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) を試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティで許可されている場合は、値を変更するか空に設定することができます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したりチェックしたりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体を読み込まずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、次に [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/nodejs-java/examine-presentation/) を参照してください。