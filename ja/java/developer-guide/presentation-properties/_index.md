---
title: プレゼンテーションプロパティ
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供します。これらのドキュメントプロパティにより、ドキュメント（プレゼンテーションファイル）と共に便利な情報を保存できます。ドキュメントプロパティには以下の2種類があります。

- システム定義（ビルトイン）プロパティ
- ユーザー定義（カスタム）プロパティ

**ビルトイン**プロパティには、ドキュメントのタイトル、著者名、ドキュメント統計など、ドキュメントに関する一般的な情報が含まれています。**カスタム**プロパティは、ユーザーが**名前/値**ペアとして定義するプロパティであり、名前と値の両方がユーザーによって定義されます。Aspose.Slides for Javaを使用すると、開発者はビルトインプロパティとカスタムプロパティの値にアクセスし、変更できます。

{{% /alert %}} 

## **PowerPointのドキュメントプロパティ**
Microsoft PowerPoint 2007では、プレゼンテーションファイルのドキュメントプロパティを管理できます。必要なのは、以下に示すようにOfficeアイコンをクリックし、さらに**準備 | プロパティ | 詳細プロパティ**メニュー項目を選択することです。

{{% alert color="primary" %}} 

**Application**と**Producer**フィールドに対して値を設定することはできません。なぜなら、これらのフィールドにはAspose Ltd.とAspose.Slides for Java x.x.xが表示されるためです。

{{% /alert %}} 

|**詳細プロパティメニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**詳細プロパティ**メニュー項目を選択すると、以下の図のようにPowerPointファイルのドキュメントプロパティを管理するためのダイアログが表示されます。

|**プロパティダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記の**プロパティダイアログ**には、**一般**、**要約**、**統計**、**内容**、**カスタム**など、多くのタブページが表示されます。これらのタブページは、PowerPointファイルに関連するさまざまな種類の情報を構成することを可能にします。**カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。

Aspose.Slides for Javaを使用したドキュメントプロパティの操作

前述のように、Aspose.Slides for Javaは**ビルトイン**プロパティと**カスタム**プロパティの2種類のドキュメントプロパティをサポートしています。したがって、開発者はAspose.Slides for Java APIを使用して、両方の種類のプロパティにアクセスできます。Aspose.Slides for Javaは、**Presentation.DocumentProperties**プロパティを通じてプレゼンテーションファイルに関連するドキュメントプロパティを表すクラス[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties)を提供します。

開発者は、以下に説明するように、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)オブジェクトによって公開された**IDocumentProperties**プロパティを使用してプレゼンテーションファイルのドキュメントプロパティにアクセスできます。

## **ビルトインプロパティにアクセスする**
[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties)オブジェクトによって公開されるこれらのプロパティには、**Creator**（著者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（最終変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**、および**Title**が含まれます。

```java
// プレゼンテーションを表すPresentationクラスをインスタンス化する
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連付けられたIDocumentPropertiesオブジェクトの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ビルトインプロパティを表示する
    System.out.println("カテゴリ : " + dp.getCategory());
    System.out.println("現在のステータス : " + dp.getContentStatus());
    System.out.println("作成日 : " + dp.getCreatedTime());
    System.out.println("著者 : " + dp.getAuthor());
    System.out.println("説明 : " + dp.getComments());
    System.out.println("キーワード : " + dp.getKeywords());
    System.out.println("最終変更者 : " + dp.getLastSavedBy());
    System.out.println("マネージャー : " + dp.getManager());
    System.out.println("最終変更日 : " + dp.getLastSavedTime());
    System.out.println("プレゼンテーション形式 : " + dp.getPresentationFormat());
    System.out.println("最終印刷日 : " + dp.getLastPrinted());
    System.out.println("プロデューサー間で共有されているか : " + dp.getSharedDoc());
    System.out.println("件名 : " + dp.getSubject());
    System.out.println("タイトル : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ビルトインプロパティを変更する**
プレゼンテーションファイルのビルトインプロパティを変更するのは、アクセスするのと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for Javaを使用してプレゼンテーションファイルのビルトインドキュメントプロパティを変更する方法を示しています。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連付けられたIDocumentPropertiesオブジェクトの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ビルトインプロパティを設定する
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("プレゼンテーションプロパティの変更");
    dp.setSubject("Aspose件名");
    dp.setComments("Asposeの説明");
    dp.setManager("Asposeマネージャー");
    
    // プレゼンテーションをファイルに保存する
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例では、以下のように表示できるプレゼンテーションのビルトインプロパティを変更します。

|**変更後のビルトインドキュメントプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタムドキュメントプロパティを追加する**
Aspose.Slides for Javaは、開発者がプレゼンテーションドキュメントプロパティにカスタム値を追加することも可能にします。以下に示す例は、プレゼンテーションのカスタムプロパティを設定する方法を示しています。

```java
Presentation pres = new Presentation();
try {
    // ドキュメントプロパティを取得する
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタムプロパティを追加する
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスにあるプロパティ名を取得する
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択したプロパティを削除する
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションを保存する
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**追加されたカスタムドキュメントプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタムプロパティにアクセスして変更する**
Aspose.Slides for Javaでは、開発者がカスタムプロパティの値にアクセスすることもできます。以下の例では、プレゼンテーションのこれらのカスタムプロパティにアクセスして変更する方法を示しています。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連付けられたDocumentPropertiesオブジェクトの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタムプロパティにアクセスして変更する
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタムプロパティの名前と値を表示する
        System.out.println("カスタムプロパティ名 : " + dp.getCustomPropertyName(i));
        System.out.println("カスタムプロパティ値 : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // カスタムプロパティの値を変更する
        dp.set_Item(dp.getCustomPropertyName(i), "新しい値 " + (i + 1));
    }
    
    // プレゼンテーションをファイルに保存する
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例では、[PPTX](https://docs.fileformat.com/presentation/pptx/)プレゼンテーションのカスタムプロパティを変更します。以下の図は、変更前と変更後のプレゼンテーションのカスタムプロパティを示しています。

|**変更前のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**変更後のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメントプロパティ**
{{% alert color="primary" %}} 

新しいメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および[WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)が[IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)プロパティセッターのロジックが変更されました。

{{% /alert %}} 

新しいメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)と[UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)が[IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)インターフェースに追加されました。これらはドキュメントプロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティを変更および更新することを可能にします。

プロパティをロードし、一部の値を変更し、ドキュメントを更新する一般的なシナリオは、以下のように実装できます。

```java
// プレゼンテーションの情報を読み取る
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 現在のプロパティを取得する
IDocumentProperties props = info.readDocumentProperties();

// AuthorおよびTitleフィールドの新しい値を設定する
props.setAuthor("新しい著者");
props.setTitle("新しいタイトル");

// 新しい値でプレゼンテーションを更新する
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

特定のプレゼンテーションのプロパティをテンプレートとして使用して、他のプレゼンテーションのプロパティを更新する別の方法があります。

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("テンプレート著者");
template.setTitle("テンプレートタイトル");
template.setCategory("テンプレートカテゴリ");
template.setKeywords("キーワード1, キーワード2, キーワード3");
template.setCompany("私たちの会社");
template.setComments("テンプレートから作成されました");
template.setContentType("テンプレートコンテンツ");
template.setSubject("テンプレート件名");

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

新しいテンプレートをゼロから作成し、その後複数のプレゼンテーションを更新するために使用することもできます。

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("テンプレート著者");
template.setTitle("テンプレートタイトル");
template.setCategory("テンプレートカテゴリ");
template.setKeywords("キーワード1, キーワード2, キーワード3");
template.setCompany("私たちの会社");
template.setComments("テンプレートから作成されました");
template.setContentType("テンプレートコンテンツ");
template.setSubject("テンプレート件名");

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

## **プレゼンテーションが変更されたか作成されたかを確認する**
Aspose.Slides for Javaは、プレゼンテーションが変更されたか作成されたかを確認する機能を提供します。以下に示す例は、プレゼンテーションが作成されたか変更されたかを確認する方法を示しています。

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("アプリケーション名: " + app);
System.out.println("アプリケーションバージョン: " + ver);
```

## **校正言語を設定する**

Aspose.Slidesは、PowerPointドキュメントの校正言語を設定できるLanguageIdプロパティ（PortionFormatクラスによって公開）を提供します。校正言語は、PowerPoint内でのスペルおよび文法チェックのための言語です。

このJavaコードは、PowerPointの校正言語を設定する方法を示しています：xxx なぜLanguageIdがJavaのPortionFormatクラスに表示されないのか？

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

    portionFormat.setLanguageId("zh-CN"); // 校正言語のIDを設定する

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **デフォルト言語を設定する**

このJavaコードは、全プレゼンテーションのデフォルト言語を設定する方法を示しています。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // テキスト付きの新しい四角形を追加する
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("新しいテキスト");

    // 最初のポーションの言語をチェックする
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```