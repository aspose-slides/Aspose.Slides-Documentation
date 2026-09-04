---
title: Android でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/androidjava/presentation-properties/
keywords:
- PowerPoint のプロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
- 詳細プロパティ
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
## **はじめに**

Aspose.Slides はドキュメント プロパティの二種類、**Built-in** と **Custom** をサポートしています。これらのプロパティは、Aspose.Slides API を使用して簡単に取得および管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) で取得できます。以下の例は、プロパティの読み取り、変更、管理方法を示しています。

{{% alert color="info" title="Note" %}}
**Application** と **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにこれらを書き換えるため、保存されたプレゼンテーションは常に Aspose.Slides の製品名と生成したライブラリのバージョンを報告します。`setNameOfApplication` に渡された任意の値は、プレゼンテーションが書き込まれる際に破棄されます。
{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下のように Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** のメニュー項目を選択するだけです。

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下の図のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**Properties ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **Properties ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブページが表示されます。これらのタブは、PowerPoint ファイルに関連するさまざまな情報の設定を可能にします。**Custom** タブは PowerPoint ファイルのカスタム プロパティを管理するために使用されます。



### Aspose.Slides for Android via Java でドキュメント プロパティを操作する

前述のとおり、Aspose.Slides for Android via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。開発者は Aspose.Slides for Android via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for Android via Java は、**Presentation.DocumentProperties** プロパティを通じてプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties) を提供します。

開発者は [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開封パスワードは通常、プレゼンテーションのコンテンツとドキュメント プロパティの両方を保護します。`false` を [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) に渡して暗号化した場合、ドキュメント プロパティは公開されたままです。その後、`true` を [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) に渡すことで、開封パスワードを提供せずに公開メタデータを読み取れます。

ドキュメント プロパティのみのオプションは Aspose.Slides が読み込む対象を制御しますが、暗号化されたものは復号しません。暗号化にプロパティが含まれている場合、パスワードなしでの読み込みは失敗します。暗号化されていないプレゼンテーションの場合はオプションは無視され、プレゼンテーション全体が読み込まれます。

以下の例は [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) でロードモードを確認し、続いて [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) で組み込みプロパティを読み取ります。

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

このモードではスライド コンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、およびその他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、完全なプレゼンテーション オブジェクト モデルを必要とする操作を行う前に必ず [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) をチェックすべきです。

{{% alert color="warning" title="Warning" %}}
公開メタデータには作者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密性の高いプロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでのアクセスを特別に要求する場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、ドキュメント プロパティのみモードで読み込まれたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内部のデータと一貫性を保つ必要があるためです。したがって、プロパティの更新には正しい開封パスワードと完全なロードが必要です。

以下の例は [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) でプレゼンテーションを開き、公開の組み込みプロパティを更新して保存します。その後、[IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) で暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

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

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティにアクセスする**

[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties) オブジェクトが提供するプロパティは次のとおりです：**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日時）、**Modified**（最終更新日時）、**Printed**（最終印刷日時）、**LastModifiedBy**、**SharedDoc**（複数の作成者で共有されているか）、**PresentationFormat**、**Subject**、**Title**

```java
import com.aspose.slides.*;

// プレゼンテーションを表す Presentation クラスをインスタンス化する
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

## **組み込みプロパティを変更する**

プレゼンテーション ファイルの組み込みプロパティの変更は、取得と同様に簡単です。任意のプロパティに文字列値を代入すれば、プロパティの値が更新されます。以下の例では、Aspose.Slides for Android via Java を使用してプレゼンテーションの組み込みドキュメント プロパティを変更する方法を示しています。

```java
import com.aspose.slides.*;

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

この例は、以下のように変更後の組み込みドキュメント プロパティを表示します。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティを追加する**

Aspose.Slides for Android via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では 3 つのカスタム プロパティを追加し、インデックス 2 に格納された名前を検索して削除します。その結果、保存されたプレゼンテーションには 2 つのカスタム プロパティが残ります。カスタム プロパティは追加順ではなく、アルファベット順にインデックス付けされます。

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
    
    //選択したプロパティを削除する
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

## **カスタム プロパティにアクセスして変更する**

Aspose.Slides for Android via Java は、カスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

```java
import com.aspose.slides.*;

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

{{% alert color="info" title="Note" %}}
新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

新しく追加された 2 つのメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) は [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentationInfo) インターフェイスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更・更新が可能です。

典型的なシナリオは、プロパティをロードし、いくつかの値を変更してドキュメントを更新することで、以下のように実装できます。

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

別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することができます。

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

## **校正言語を設定する**

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックや文法チェックが行われる言語です。

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

    portionFormat.setLanguageId("zh-CN"); // 校正言語の ID を設定する

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **デフォルト言語を設定する**

以下の Java コードは PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。

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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当プロパティが許可している場合は空に設定したりすることは可能です。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除またはチェックする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、次に [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例と形式別の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/androidjava/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを開封パスワードなしで読み取れますか？**

はい。ドキュメント プロパティの暗号化がプレゼンテーションの暗号化前に無効化されており、プレゼンテーションがドキュメント プロパティのみモードでロードされている場合に限ります。

**暗号化された PPTX ファイルをドキュメント プロパティのみモードで更新できますか？**

できません。公開プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには正しい開封パスワードでプレゼンテーション全体をロードする必要があります。