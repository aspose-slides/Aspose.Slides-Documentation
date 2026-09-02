---
title: Android でのプレゼンテーション プロパティの管理
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
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は、ドキュメント プロパティの 2 種類、**Built-in** と **Custom** をサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーション ドキュメント プロパティを操作できるようにします。このインターフェイスのインスタンスは、[Presentation.getDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) メソッドによって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="注意" %}}
**Application** および **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにそれらを上書きするため、保存されたプレゼンテーションは常に Aspose.Slides の製品名とライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションが書き込まれる際に破棄されます。
{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（下図参照）。

|**Advanced Properties メニュー項目の選択**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます（下図）。

|**プロパティ ダイアログ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記 **プロパティ ダイアログ** には、**全般**、**概要**、**統計**、**内容**、**カスタム** といった多数のタブがあり、PowerPoint ファイルに関するさまざまな情報を設定できます。**カスタム** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **Android 用 Aspose.Slides (Java) でドキュメント プロパティを操作する**

前述のとおり、Aspose.Slides for Android via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。開発者は Aspose.Slides for Android via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Android via Java は、**Presentation.DocumentProperties** プロパティを通じてプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties) を提供します。

開発者は [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、以下に示すようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **Built-in プロパティにアクセスする**

[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties) オブジェクトが公開するこれらのプロパティには、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（他の作成者と共有されているか）、**PresentationFormat**、**Subject**、**Title** が含まれます。

```java
import com.aspose.slides.*;

// プレゼンテーションを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを表示します
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

## **Built-in プロパティの変更**

Built-in プロパティの変更は、アクセスと同じくらい簡単です。目的のプロパティに文字列値を代入すれば、プロパティ値が更新されます。以下の例では、Aspose.Slides for Android via Java を使用してプレゼンテーション ファイルの Built-in ドキュメント プロパティを変更する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを設定します
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // プレゼンテーションをファイルに保存します
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例は、変更後の Built-in プロパティを以下のように表示します。

|**変更後の Built-in ドキュメント プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Android via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では 3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索して削除します。保存されたプレゼンテーションには残りの 2 つだけが保持されます。カスタム プロパティはアルファベット順にインデックス付けされ、追加順ではありません。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ドキュメント プロパティを取得しています
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタム プロパティを追加しています
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスのプロパティ名を取得しています
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択したプロパティを削除しています
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションを保存しています
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**追加されたカスタム ドキュメント プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for Android via Java は、カスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // カスタム プロパティにアクセスして変更します
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // カスタム プロパティの名前と値を表示します
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // カスタム プロパティの値を変更します
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // プレゼンテーションをファイルに保存します
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

この例は [PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は変更前後のカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" title="注意" %}}
新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

新しく追加された 2 つのメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) は、[IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo) インターフェイスに実装されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体を読み込むことなくプロパティの変更と更新が可能です。

典型的なシナリオは、プロパティを読み込んで値を変更し、ドキュメントを更新することであり、以下のように実装できます。

```java
import com.aspose.slides.*;

// プレゼンテーションの情報を読み取ります
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 現在のプロパティを取得します
IDocumentProperties props = info.readDocumentProperties();

// Author と Title フィールドに新しい値を設定します
props.setAuthor("New Author");
props.setTitle("New Title");

// 新しい値でプレゼンテーションを更新します
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **校正言語の設定**

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint 文書の校正言語を設定できます。校正言語は、スペルや文法チェックが行われる言語です。

以下の Java コードは PowerPoint の校正言語を設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // 校正言語の ID を設定します

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **既定言語の設定**

以下の Java コードは PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // テキスト付きの新しい矩形シェイプを追加します
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 最初のポーションの言語を確認します
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライブ例**

Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認するには、オンライン アプリ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) をお試しください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから Built-in プロパティを削除するにはどうすればよいですか？**

Built-in プロパティはプレゼンテーションの構成要素であり、完全に削除することはできません。ただし、値を変更したり、プロパティが許可する場合は空文字列に設定したりできます。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、次に [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例と形式固有の制限については、[軽量プレゼンテーション インベントリの構築](/slides/ja/androidjava/examine-presentation/) を参照してください。