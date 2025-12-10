---
title: Java でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/java/presentation-properties/
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
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint はプレゼンテーション ファイルにプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）に有用な情報を保存できます。プロパティは次の 2 種類があります。

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** プロパティは、ドキュメントのタイトル、作者名、統計情報など、ドキュメント全般に関する情報を含みます。**Custom** プロパティは、ユーザーが **Name/Value** のペアとして定義するものです。Aspose.Slides for Java を使用すると、組み込みプロパティとカスタムプロパティの値にアクセスしたり変更したりできます。

{{% /alert %}} 

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 は、プレゼンテーション ファイルのドキュメント プロパティの管理を可能にします。Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択すれば完了です（下図参照）。

{{% alert color="primary" %}} 

※ **Application** および **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for Java x.x.x が表示されます。

{{% /alert %}} 

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** を選択すると、以下のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記 **Properties Dialog** では **General**、**Summary**、**Statistics**、**Contents**、**Custom** などのタブがあり、各タブで PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブはカスタム プロパティの管理に使用します。

Working with Document Properties Using Aspose.Slides for Java

前述のとおり、Aspose.Slides for Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。開発者は Aspose.Slides for Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Java では、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) があり、**Presentation.DocumentProperties** プロパティから取得できます。

開発者は [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) オブジェクトが提供する **IDocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **Access Built-in Properties**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) オブジェクトが提供するプロパティには、**Creator**（作者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（複数のプロデューサーで共有されているか）、**PresentationFormat**、**Subject**、**Title** などがあります。
```java
// プレゼンテーションを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを表示する
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modify Built-in Properties**

組み込みプロパティの変更は、取得と同様に簡単です。目的のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを設定する
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // プレゼンテーションをファイルに保存する
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この例は、変更後の組み込みプロパティを以下のように表示します。

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    // ドキュメント プロパティを取得
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタム プロパティを追加
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスのプロパティ名を取得
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択したプロパティを削除
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションを保存
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Java は、カスタム プロパティの取得と変更もサポートします。以下の例は、プレゼンテーションのカスタム プロパティにアクセスし、すべてを変更する方法を示しています。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタム プロパティにアクセスして変更する
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタム プロパティの名前と値を表示する
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // カスタム プロパティの値を変更する
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // プレゼンテーションをファイルに保存する
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この例は [PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は変更前後のカスタム プロパティを示しています。

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="primary" %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) が [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) インターフェイスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティを変更・更新できます。

典型的なシナリオは、プロパティをロードし、値を変更してドキュメントを更新するというものです。以下のコードがその実装例です。
```java
// プレゼンテーションの情報を読み取る
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 現在のプロパティを取得する
IDocumentProperties props = info.readDocumentProperties();

// Author と Title フィールドの新しい値を設定する
props.setAuthor("New Author");
props.setTitle("New Title");

// 新しい値でプレゼンテーションを更新する
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


特定のプレゼンテーションのプロパティをテンプレートとして他のプレゼンテーションのプロパティを更新する別の方法があります。
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新する際に使用できます。
```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Set Proofing Language**

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを使用して、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックおよび文法チェックが行われる言語です。

以下の Java コードは PowerPoint の校正言語を設定する方法を示しています: xxx Why is LanguageId missing from Java PortionFormat class?
```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // 校正言語の ID を設定
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Set Default Language**

以下の Java コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // テキスト付きの新しい長方形シェイプを追加します
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 最初のポーションの言語を確認します
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Live Example**

Aspose.Slides API を使用してドキュメント プロパティを操作する方法を確認するには、オンライン アプリ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) をお試しください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes, you can access presentation properties without fully loading the presentation by using the `getPresentationInfo` method from the [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/) class. Then, utilize the `readDocumentProperties` method provided by the [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/) interface to read the properties efficiently, saving memory and improving performance.