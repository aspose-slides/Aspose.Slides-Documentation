---
title: プレゼンテーション プロパティ
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
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "JavaScript で PowerPoint プレゼンテーションのプロパティを管理する"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint は、プレゼンテーション ファイルにいくつかのプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と一緒に有用な情報を保存できます。ドキュメント プロパティには次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、ドキュメントのタイトル、作者名、ドキュメント統計情報など、一般的な情報を含みます。**カスタム** プロパティは、ユーザーが **Name/Value** のペアとして定義するもので、名前と値の両方をユーザーが決めます。Aspose.Slides for Node.js via Java を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。

{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下のように、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。

{{% alert color="primary" %}} 

**Application** および **Producer** フィールドには値を設定できないことに注意してください。これらのフィールドには Aspose Ltd. と Aspose.Slides for Node.js via Java x.x.x が表示されます。

{{% /alert %}} 

|**高度なプロパティ メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下の図のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **Properties Dialog** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブ ページがあることがわかります。これらのタブは、PowerPoint ファイルに関連するさまざまな情報を設定できます。**Custom** タブは PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

Aspose.Slides for Node.js via Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for Node.js via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for Node.js via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Node.js via Java は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) を提供し、**Presentation.DocumentProperties** プロパティを通じて利用できます。

開発者は [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

これらのプロパティは [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) オブジェクトが公開しており、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサ間で共有されているか）、**PresentationFormat**、**Subject**、**Title** が含まれます。

```javascript
// プレゼンテーションを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成
    var dp = pres.getDocumentProperties();
    // 組み込みプロパティを表示
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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を割り当てるだけでプロパティの値が変更されます。以下の例では、Aspose.Slides for Node.js via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成
    var dp = pres.getDocumentProperties();
    // 組み込みプロパティを設定
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // プレゼンテーションをファイルに保存
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この例では、以下に示すようにプレゼンテーションの組み込みプロパティが変更されます。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Node.js via Java は、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションのカスタム プロパティを設定する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // ドキュメント プロパティの取得
    var dProps = pres.getDocumentProperties();
    // カスタム プロパティの追加
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 特定インデックスのプロパティ名を取得
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 選択されたプロパティの削除
    dProps.removeCustomProperty(getPropertyName);
    // プレゼンテーションの保存
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

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for Node.js via Java は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    var dp = pres.getDocumentProperties();
    // カスタム プロパティにアクセスして変更
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタム プロパティの名前と値を表示
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // カスタム プロパティの値を変更
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // プレゼンテーションをファイルに保存
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この例では、[PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のプレゼンテーション カスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="primary" %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) が [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) に追加され、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

2 つの新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) が [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) クラスに追加されました。これにより、プレゼンテーション全体を読み込むことなく、ドキュメント プロパティにすばやくアクセスし、変更および更新できます。

典型的なシナリオとして、プロパティを読み込んで値を変更し、ドキュメントを更新する手順は次のように実装できます。

```javascript
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


別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することができます。

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新するために使用できます。

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **校正言語の設定**

Aspose.Slides は LanguageId プロパティ（PortionFormat クラスが公開）を提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルと文法がチェックされる言語です。

この JavaScript コードは、PowerPoint の校正言語を設定する方法を示しています：xxx なぜ JavaScript の PortionFormat クラスに LanguageId がないのでしょうか？

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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


## **既定言語の設定**

この JavaScriptコードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // テキスト付きの新しい四角形シェイプを追加
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 最初のポーションの言語を確認します
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ライブ例**

オンライン アプリ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) を試して、Aspose.Slides API でドキュメント プロパティを操作する方法をご確認ください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティで許可されている場合は、値を変更したり空文字列に設定したりできます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) クラスの `getPresentationInfo` メソッドを使用すれば、プレゼンテーション全体をロードせずにプロパティにアクセスできます。その後、[PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) クラスが提供する `readDocumentProperties` メソッドを利用してプロパティを効率的に読み取り、メモリを節約しパフォーマンスを向上させます。