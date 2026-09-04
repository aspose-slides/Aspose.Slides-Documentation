---
title: Java でプレゼンテーション プロパティを管理
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
## **イントロダクション**

Aspose.Slides は、ドキュメント プロパティの 2 種類、**Built-in** と **Custom** をサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単に取得および管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDocumentProperties--) で返されます。以下の例では、これらのプロパティを読み取り、変更し、管理する方法を示します。

{{% alert color="info" title="Note" %}}
**Application** と **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for Java」とそのライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションを書き出す際に破棄されます。
{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下に示すように、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。

|**Advanced Properties メニュー項目の選択**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下の図のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **Properties Dialog** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブがあることがわかります。これらのタブは、PowerPoint ファイルに関するさまざまな情報を構成するために使用できます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

### Aspose.Slides for Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Java は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを **Presentation.DocumentProperties** プロパティを通じて表すクラス [IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties) を提供します。

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、以下に示すようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くためのパスワードは、通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に `false` を渡してプレゼンテーションを暗号化すると、ドキュメント プロパティは公開されたままになります。その後、アプリケーションは [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) に `true` を渡すことで、開くためのパスワードを提供せずに公開メタデータを読み取れます。

document-properties-only オプションは Aspose.Slides がロードする対象を制御しますが、暗号化の解除は行いません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

次の例では、[IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) でロード モードを確認し、続いて [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDocumentProperties--) で Built-in プロパティを読み取ります：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

このモードではスライド コンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは使用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を行う前に、常に [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) を確認してください。

{{% alert color="warning" title="Warning" %}}
公開メタデータにより、作者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密性の高いプロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでのアクセスを特に要求する場合のみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、document-properties-only モードでロードされたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides は、このメタデータのみオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと一貫性を保つ必要があるため、更新には正しい開くためのパスワードと完全なロードが必要です。

次の例では、[LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) でプレゼンテーションを開き、公開されている Built-in プロパティを更新して結果を保存します。その後、[IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **Built-in プロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties) オブジェクトが提供するプロパティは、**Creator** (Author)、**Description**、**Keywords**、**Created** (作成日)、**Modified** (更新日)、**Printed** (最終印刷日)、**LastModifiedBy**、**Keywords**、**SharedDoc** (異なる作成者間で共有されているか)、**PresentationFormat**、**Subject**、**Title** が含まれます。

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

プレゼンテーション ファイルの Built-in プロパティを変更するのは、取得するのと同様に簡単です。目的のプロパティに文字列値を割り当てるだけでプロパティの値が変更されます。以下の例では、Aspose.Slides for Java を使用してプレゼンテーション ファイルの Built-in ドキュメント プロパティを変更する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成します
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 組み込みプロパティを設定します
    dp.setAuthor("Aspose.Slides for Java");
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

この例では、プレゼンテーションの Built-in プロパティを変更し、以下のように表示されます。

|**変更後の Built-in ドキュメント プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for Java は、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では、3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索してそのプロパティを削除します。その結果、保存されたプレゼンテーションには 2 つのプロパティが残ります。カスタム プロパティは、追加順ではなくアルファベット順にインデックス付けされます。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ドキュメント プロパティの取得
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // カスタム プロパティの追加
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 特定のインデックスのプロパティ名を取得
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 選択されたプロパティの削除
    dProps.removeCustomProperty(getPropertyName);
    
    // プレゼンテーションの保存
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**追加されたカスタム ドキュメント プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for Java は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例では、プレゼンテーションに対してこれらすべてのカスタム プロパティにアクセスし、変更する方法を示します。

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

この例では、[PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のプレゼンテーション カスタム プロパティを示しています。

|**変更前のカスタム プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}
新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、[WriteBindedPresentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

[ReadDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) の 2 つの新しいメソッドが [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPPresentationInfo) インターフェイスに追加されました。これらはドキュメント プロパティへの高速アクセスを提供し、プレゼンテーション全体をロードせずにプロパティを変更および更新できます。

典型的なシナリオとして、プロパティをロードし、値を変更してドキュメントを更新する手順は以下のように実装できます：

```java
import com.aspose.slides.*;

// プレゼンテーション情報を読み取ります
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

特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法があります：

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

新しいテンプレートをゼロから作成し、複数のプレゼンテーションの更新に使用できます：

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

Aspose.Slides は LanguageId プロパティ（PortionFormat クラスで公開）を提供し、PowerPoint ドキュメントの校正言語を設定できるようにします。校正言語とは、PowerPoint のスペルと文法がチェックされる言語です。

以下の Java コードは、PowerPoint の校正言語を設定する方法を示しています：

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

    portionFormat.setLanguageId("zh-CN"); // 校正言語の ID を設定します

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **既定言語の設定**

以下の Java コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // テキスト付きの新しい矩形シェイプを追加します
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 最初の部分の言語を確認します
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください：

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから Built-in プロパティを削除するにはどうすればよいですか？**

Built-in プロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、対象のプロパティが許可する場合は、値を変更したり空文字列に設定することは可能です。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。Aspose.Slides が自動的にプロパティの値を更新するため、事前に削除したり確認したりする必要はありません。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、続いて [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを、開くためのパスワードなしで読み取れますか？**

はい。ドキュメント プロパティの暗号化がプレゼンテーションの暗号化前に無効化されており、プレゼンテーションが document-properties-only モードでロードされている必要があります。

**document-properties-only モードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開くためのパスワードでプレゼンテーション全体をロードする必要があります。