---
title: Android でプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/androidjava/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察と賢いコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、コンテンツを読み込んで処理するかどうかを決定する前にプロパティを確認したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/) と [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) を使用した軽量検査、および [IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/) を使用した対象更新について示します。

## **プレゼンテーション形式の確認**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用して、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずにファイルを検査できます。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) メソッドは、PPTX、PPT、ODP など検出された形式を報告します。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **軽量プレゼンテーション インベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム向けのコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用して [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) オブジェクトを取得し、続いて [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出してドキュメント メタデータを読み取ります。このアプローチは [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せず、完全なプレゼンテーション オブジェクト モデルを走査する必要もありません。

[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/) が公開する拡張プロパティは、次のインベントリ値を提供します。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | スライド総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 非表示スライド数。 |
| [getNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | ノートが含まれるスライド数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | 利用可能な場合の段落総数。 |
| [getWords](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | 単語総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | オーディオおよびビデオクリップ総数。 |

以下のサンプルは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリとして出力します。また、[getHeadingPairs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) と [getTitlesOfParts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

各 [IHeadingPair](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iheadingpair/) はグループ名とそのグループ内の項目数を提供します。[IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) は平坦で順序付けられた配列を返すため、各ヘディング ペアで指定された連続したタイトル数だけを消費してください。

### **保存されたメタデータと形式の制限**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) が返すインベントリ プロパティは、ソース ドキュメントに存在するメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルを読み込んで走査せず、値を再計算しません。欠落しているプロパティは既定値で表され、最後に保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなる可能性があります。

- **PPTX:** この形式はスライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、およびヘディング ペアとパーツ タイトルの拡張ドキュメント プロパティを提供します。利用可能性はドキュメント 作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存された値または既定値を返します。
- **ODP:** OpenDocument メタデータはページ、段落、単語の総数など一般的な統計情報を提供しますが、これらの値は PowerPoint 固有の拡張プロパティすべてにマッピングされません。非表示スライド、ノートスライド、マルチメディア、ヘディング ペア、パーツ タイトルのメタデータは利用できないことがあり、インベントリ プロパティは既定値を返す可能性があります。ゼロ値や空配列を、該当コンテンツが存在しない決定的な証拠として扱わないでください。

軽量メタデータ アプローチはインベントリや事前チェックに適しています。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証したい場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを調べてください。

## **プレゼンテーション プロパティの更新**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずに変更できます。変更は [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) で適用し、その後 [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) を使用してバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下のサンプルはタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

以下の画像は更新後のドキュメント プロパティを示しています。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

セキュリティチェックや保護設定に関する記事は次をご覧ください。

- [Password-Protect Presentations](/slides/ja/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ja/androidjava/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getFontsManager--) を使用します。[IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) で埋め込みフォントを取得し、[IFontsManager.getFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) でプレゼンテーションで使用されているフォントを取得します。両方の結果を比較して、レンダリングに必要だが埋め込まれていないフォントを特定してください。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認するには？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) と [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を通じて [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) を読み取ります。これは軽量インベントリに適しています。メモリ上でプレゼンテーションが変更されている可能性がある場合や、ライブ値を検証する必要がある場合は、[Presentation.getSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlides--) を反復し、各スライドの [ISlide.getHidden](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getHidden--) メソッドで確認してください。

**カスタム スライド サイズと方向が使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlideSize--) を呼び出します。[ISlideSize.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidesize/#getType--)、[ISlideSize.getSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidesize/#getSize--)、[ISlideSize.getOrientation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidesize/#getOrientation--) を使用して現在の設定を期待されるプリセットや寸法と比較してください。

**チャートが外部データ ソースを参照しているかすぐに確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/) を見つけ、[IChartData.getDataSourceType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) を呼び出します。外部ブックの場合は、[IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) を呼び出してください。データ ソースの種類とパスは外部参照を示しますが、対象が利用可能かどうかは別途リソース確認が必要です。

**レンダリングや PDF エクスポートを遅くする「重い」スライドを評価する方法はありますか？**

単一の複雑度プロパティは存在しません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlides--) と各スライドの [IBaseSlide.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/#getShapes--) コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無を指標として使用し、代表的なレンダリングまたはエクスポートを計測してから、スライドを確実なパフォーマンス ボトルネックとして扱ってください。