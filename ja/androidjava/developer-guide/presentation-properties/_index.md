---
title: プレゼンテーションのプロパティ
type: docs
weight: 70
url: /ja/androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供します。これらの文書プロパティは、文書（プレゼンテーションファイル）と共に有用な情報を保存することを可能にします。文書プロパティには以下の2種類があります。

- システム定義（ビルトイン）プロパティ
- ユーザー定義（カスタム）プロパティ

**ビルトイン**プロパティには、文書のタイトル、著者名、文書統計など、文書に関する一般的な情報が含まれています。**カスタム**プロパティは、ユーザーが**名前/値**ペアとして定義するプロパティであり、名前と値の両方がユーザーによって定義されます。Java経由でAspose.Slides for Androidを使用することで、開発者はビルトインプロパティとカスタムプロパティの両方にアクセスして、値を変更することができます。

{{% /alert %}} 

## **PowerPointの文書プロパティ**
Microsoft PowerPoint 2007では、プレゼンテーションファイルの文書プロパティを管理できます。すべてやるべきことは、以下に示すように、Officeアイコンをクリックし、その後**準備 | プロパティ | 詳細プロパティ**メニュー項目を選択することです。

{{% alert color="primary" %}} 

**アプリケーション**および**プロデューサ**フィールドに対して値を設定できないことに注意してください。これらのフィールドには、Aspose Ltd.およびAspose.Slides for Android via Java x.x.xが表示されます。

{{% /alert %}} 

|**詳細プロパティメニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**詳細プロパティ**メニュー項目を選択すると、以下の図に示すように、PowerPointファイルの文書プロパティを管理するためのダイアログが表示されます。

|**プロパティダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記の**プロパティダイアログ**には、**一般**、**要約**、**統計**、**内容**、**カスタム**といった多くのタブページがあることがわかります。これらすべてのタブページは、PowerPointファイルに関連するさまざまな種類の情報を構成するために使用されます。**カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。



Aspose.Slides for Android via Javaを使用した文書プロパティの操作

以前に説明したように、Aspose.Slides for Android via Javaは**ビルトイン**および**カスタム**プロパティという2種類の文書プロパティをサポートしています。したがって、開発者はAspose.Slides for Android via Java APIを使用して両方の種類のプロパティにアクセスできます。Aspose.Slides for Android via Javaは、**Presentation.DocumentProperties**プロパティを介してプレゼンテーションファイルに関連付けられた文書プロパティを表すクラス[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties)を提供します。

開発者は、以下に説明するように、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)オブジェクトによって公開された**IDocumentProperties**プロパティを使用して、プレゼンテーションファイルの文書プロパティにアクセスできます。

## **ビルトインプロパティへのアクセス**
[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties)オブジェクトによって公開されるこれらのプロパティには、**Creator**（著者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（最終更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサ間で共有されていますか？）、**PresentationFormat**、**Subject**、**Title**が含まれます。

```java
// プレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連するIDocumentPropertiesオブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ビルトインプロパティを表示します
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

## **ビルトインプロパティの変更**
プレゼンテーションファイルのビルトインプロパティを変更するのは、それらにアクセスするのと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、そのプロパティの値が変更されます。以下の例では、Aspose.Slides for Android via Javaを使用して、プレゼンテーションファイルのビルトイン文書プロパティを変更する方法を示しています。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連するIDocumentPropertiesオブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ビルトインプロパティを設定します
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("プレゼンテーションプロパティの変更");
    dp.setSubject("Asposeのテーマ");
    dp.setComments("Asposeの説明");
    dp.setManager("Asposeマネージャ");
    
    // プレゼンテーションをファイルに保存します
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例は、以下に示すように、変更後に表示されるプレゼンテーションのビルトインプロパティを変更します。

|**変更後のビルトイン文書プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム文書プロパティの追加**
Aspose.Slides for Android via Javaは、開発者がプレゼンテーションの文書プロパティに対してカスタム値を追加することも許可します。以下に示す例は、プレゼンテーションのカスタムプロパティを設定する方法を示しています。

```java
Presentation pres = new Presentation();
try {
    // 文書プロパティを取得する
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタムプロパティを追加
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスにあるプロパティ名を取得
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択されたプロパティを削除
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションを保存
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**追加されたカスタム文書プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタムプロパティにアクセスして変更する**
Aspose.Slides for Android via Javaは、開発者がカスタムプロパティの値にアクセスすることも許可します。以下に示す例は、プレゼンテーションのこれらすべてのカスタムプロパティにアクセスして変更する方法を示しています。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに関連するDocumentPropertiesオブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタムプロパティにアクセスして変更する
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタムプロパティの名前と値を表示
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // カスタムプロパティの値を変更
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // プレゼンテーションをファイルに保存します
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例は、[PPTX ](https://docs.fileformat.com/presentation/pptx/)プレゼンテーションのカスタムプロパティを変更します。以下の図は、変更前と変更後のプレゼンテーションのカスタムプロパティを示しています。

|**変更前のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**変更後のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度な文書プロパティ**
{{% alert color="primary" %}} 

新しいメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および[WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)が[IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo)に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)プロパティセッターのロジックが変更されました。

{{% /alert %}} 

新しいメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)および[UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)が[IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo)インターフェースに追加されました。これらは文書プロパティへの迅速なアクセスを提供し、プレゼンテーション全体を読み込まずにプロパティを変更および更新することを可能にします。

典型的なシナリオでは、プロパティを読み込み、一部の値を変更し、文書を更新します。次のように実装できます。

```java
// プレゼンテーションの情報を読み取る
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 現在のプロパティを取得
IDocumentProperties props = info.readDocumentProperties();

// 著者とタイトルフィールドの新しい値を設定
props.setAuthor("New Author");
props.setTitle("New Title");

// 新しい値でプレゼンテーションを更新
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

特定のプレゼンテーションのプロパティをテンプレートとして使用して他のプレゼンテーションのプロパティを更新するもう1つの方法があります。

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

新しいテンプレートをゼロから作成し、その後、複数のプレゼンテーションを更新するために使用することも可能です。

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

## **プレゼンテーションが変更されたかどうかの確認**
Aspose.Slides for Android via Javaは、プレゼンテーションが変更されたか作成されたかを確認する機能を提供します。以下に示す例は、プレゼンテーションが作成されたか変更されたかを確認する方法を示しています。

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Application Name: " + app);
System.out.println("Application Version: " + ver);
```

## **校正言語の設定**
Aspose.Slidesは、PowerPoint文書の校正言語を設定できるLanguageIdプロパティ（PortionFormatクラスによって公開）を提供します。校正言語は、PowerPointで綴りや文法がチェックされる言語です。

このJavaコードは、PowerPointの校正言語を設定する方法を示しています：xxx なぜLanguageIdがJavaのPortionFormatクラスに欠けているのか？

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

    portionFormat.setLanguageId("zh-CN"); // 校正言語のIdを設定します

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **デフォルト言語の設定**
このJavaコードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // テキストを持つ新しい長方形形状を追加します
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("新しいテキスト");

    // 最初の部分の言語を確認します
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```