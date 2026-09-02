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
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを合理化します。"
---
## **はじめに**

Aspose.Slides は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/) インターフェイスを通じてプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getDocumentProperties--) メソッドによって返されます。以下の例は、これらのプロパティの読み取り、変更、管理方法を示しています。

{{% alert color="info" title="Note" %}}
※ **Application** と **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存するたびにこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Java」とそれを生成したライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションが書き込まれる際に破棄されます。
{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下の図のように、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。

|**Advanced プロパティ メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下の図に示すように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **プロパティ ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** など多数のタブ ページがあることがわかります。これらのタブは、PowerPoint ファイルに関連するさまざまな情報を設定するために使用されます。**Custom** タブは PowerPoint ファイルのカスタム プロパティを管理するために利用されます。

### Aspose.Slides for Java を使用したドキュメント プロパティの操作

先に説明したとおり、Aspose.Slides for Java は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Java は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties) を提供し、**Presentation.DocumentProperties** プロパティを通じて利用できます。

開発者は、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

これらのプロパティは [IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties) オブジェクトで公開されており、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数の作成者で共有されますか？）、**PresentationFormat**、**Subject**、**Title** などが含まれます。

```java
import com.aspose.slides.*;

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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけでプロパティの値が変更されます。以下の例では、Aspose.Slides for Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

```java
import com.aspose.slides.*;

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

この例は、プレゼンテーションの組み込みプロパティを変更し、以下のように表示されます。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Java は、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では、3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索してそのプロパティを削除します。その結果、保存されたプレゼンテーションには 2 つのカスタム プロパティが残ります。カスタム プロパティは追加順ではなく、アルファベット順でインデックス付けされます。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ドキュメント プロパティを取得する
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタム プロパティを追加する
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスのプロパティ名を取得する
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択したプロパティを削除する
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションを保存する
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**追加されたカスタム ドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for Java は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例では、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示します。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタムプロパティにアクセスして変更する
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタムプロパティの名前と値を表示する
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // カスタムプロパティの値を変更する
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // プレゼンテーションをファイルに保存する
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例は、[PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のプレゼンテーションのカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}
新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

2 つの新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) および [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo) インターフェイスに追加されました。これらは、プレゼンテーション全体をロードせずにドキュメント プロパティに迅速にアクセスし、変更・更新できるようにします。

典型的なシナリオとして、プロパティをロードし、値を変更してドキュメントを更新する手順は以下のように実装できます：

```java
import com.aspose.slides.*;

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

別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することができます：

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

新しいテンプレートを最初から作成し、複数のプレゼンテーションを更新するために利用できます：

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **校正言語の設定**

Aspose.Slides は、PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルと文法チェックを行う対象言語です。

以下の Java コードは、PowerPoint の校正言語を設定する方法を示しています。

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // 校正言語の ID を設定する

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **既定言語の設定**

以下の Java コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 新しい矩形シェイプをテキスト付きで追加する
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 最初のポーションの言語を確認する
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライブ例**

オンライン アプリの [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) を試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な要素であり、完全に削除することはできません。ただし、特定のプロパティが許可している場合は、値を変更するか空文字列に設定することが可能です。

**すでに存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、その後 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例やフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/java/examine-presentation/) を参照してください。