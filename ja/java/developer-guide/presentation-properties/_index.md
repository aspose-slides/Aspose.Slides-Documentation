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
## **はじめに**

Aspose.Slides は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides.idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメント プロパティを操作できるようにします。このインターフェイスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getDocumentProperties--) メソッドによって返されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" %}} 

**Application** および **AppVersion** フィールドは変更できません。Aspose.Slides は保存時にこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Java」とそのライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションを書き込む際に破棄されます。

{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（下図参照）。

|**詳細プロパティ メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **プロパティ ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブページが表示されます。これらのタブページは、PowerPoint ファイルに関連するさまざまな情報の設定を可能にします。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **Aspose.Slides for Java を使用したドキュメント プロパティの操作**

前述のとおり、Aspose.Slides for Java は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は Aspose.Slides for Java API を使用して両方の種類のプロパティにアクセスできます。Aspose.Slides for Java は、**Presentation.DocumentProperties** プロパティを介してプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表す [IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides.idocumentproperties) クラスを提供します。

開発者は、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、下記のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides.idocumentproperties) オブジェクトが公開するこれらのプロパティには、**Creator**（作者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（最終更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（複数の制作者で共有されているか）、**PresentationFormat**、**Subject**、**Title** が含まれます。

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

組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティ値が変更されます。以下の例では、Aspose.Slides for Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。

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

この例は、以下のように変更後の組み込みプロパティを示します。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では 3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索してそのプロパティを削除します。その結果、保存されたプレゼンテーションには 2 つのカスタム プロパティが残ります。カスタム プロパティはアルファベット順にインデックス付けされ、追加順ではありません。

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

## **カスタムプロパティへのアクセスと変更**

Aspose.Slides for Java は、カスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成する
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタム プロパティにアクセスし、変更する
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

この例は [PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

新しく追加された 2 つのメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) は、[IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo) インターフェイスに実装されています。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更と更新が可能です。

典型的なシナリオは、プロパティを読み込み、値を変更し、ドキュメントを更新することで、以下のように実装できます。

```java
import com.aspose.slides.*;

// プレゼンテーションの情報を読み取る
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法もあります。

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

新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新することも可能です。

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

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、スペルと文法チェックが行われる言語です。

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

Aspose.Slides Metadata のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## ***FAQ**

### 組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、値を変更するか、プロパティが許可する場合は空文字列に設定できます。

### 既に存在するカスタムプロパティを追加した場合はどうなりますか？

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

### プレゼンテーション全体をロードせずにプロパティにアクセスできますか？

はい、[PresentationFactory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/) クラスの `getPresentationInfo` メソッドを使用し、[IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/) インターフェイスの `readDocumentProperties` メソッドでプロパティを効率的に読み取ることで、メモリ使用量を抑え、パフォーマンスを向上させながらプロパティにアクセスできます。