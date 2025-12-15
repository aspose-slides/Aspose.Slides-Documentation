---
title: Android でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint はプレゼンテーション ファイルにプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ドキュメント (プレゼンテーション ファイル) と一緒に有用な情報を保存できます。プロパティは次の 2 種類があります。

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** プロパティは、ドキュメント タイトル、作者名、ドキュメント統計情報など、ドキュメントに関する一般的な情報を格納します。**Custom** プロパティは、ユーザーが **Name/Value** のペアとして定義するもので、名前も値もユーザーが決めます。Aspose.Slides for Android via Java を使用すると、開発者は組み込みプロパティとカスタム プロパティの両方の値にアクセスしたり、変更したりできます。

{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。必要なのは Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（以下の図参照）。

{{% alert color="primary" %}} 

Application および Producer フィールドには値を設定できません。これらのフィールドには Aspose Ltd. および Aspose.Slides for Android via Java x.x.x が表示されます。

{{% /alert %}} 

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Advanced Properties メニュー項目を選択すると、以下の図のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記 **プロパティ ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブページが確認できます。これらのタブは PowerPoint ファイルに関するさまざまな情報の設定を可能にします。**Custom** タブは PowerPoint ファイルのカスタム プロパティを管理するために使用します。

Aspose.Slides for Android via Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for Android via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は Aspose.Slides for Android via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Android via Java は、**Presentation.DocumentProperties** プロパティを通じてプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) を提供します。

開発者は [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、以下に示すようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

これらのプロパティは IDocumentProperties オブジェクトで提供され、Creator (Author)、Description、Keywords、Created (作成日)、Modified (最終更新日)、Printed (最終印刷日)、LastModifiedBy、SharedDoc (異なるプロデューサー間で共有されていますか?)、PresentationFormat、Subject、Title が含まれます。
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


## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティを変更するのは、アクセスするのと同様に簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for Android via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを設定する
    dp.setAuthor("Aspose.Slides for Android via Java");
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


この例は、変更後の組み込みドキュメント プロパティを以下のように表示します。

|**組み込みドキュメント プロパティ (変更後)**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Android via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。
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


|**追加されたカスタム ドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for Android via Java は、カスタム プロパティの値へのアクセスも可能にします。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。
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


この例は [PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は変更前後のカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="primary" %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

2 つの新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) が [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) インターフェイスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更と更新を可能にします。

典型的なシナリオは、プロパティを読み込み、値を変更し、ドキュメントを更新することで、以下のように実装できます:
```java
// プレゼンテーションの情報を読み取る
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// Author と Title フィールドの新しい値を設定する
props.setAuthor("New Author");
props.setTitle("New Title");

// 新しい値でプレゼンテーションを更新する
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法もあります:
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


新しいテンプレートを最初から作成し、複数のプレゼンテーションを更新するために使用することもできます:
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


## **校正言語の設定**

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語とは、PowerPoint のスペルと文法がチェックされる対象言語です。

この Java コードは、PowerPoint の校正言語を設定する方法を示しています: xxx なぜ Java の PortionFormat クラスに LanguageId がないのでしょうか？
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


## **デフォルト言語の設定**

この Java コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 新しい矩形シェイプをテキスト付きで追加
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 最初のポーションの言語を確認
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **ライブ例**

[Aspose.Slides Metadata](https://products.aspose.app/slides/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください:

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、特定のプロパティで許可されている場合は空文字列に設定したりすることは可能です。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除や確認を行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/) クラスの `getPresentationInfo` メソッドを使用してプレゼンテーションを完全にロードせずにプロパティにアクセスできます。その後、[IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/) インターフェイスが提供する `readDocumentProperties` メソッドを利用してプロパティを効率的に読み取り、メモリ使用量を削減しパフォーマンスを向上させます。