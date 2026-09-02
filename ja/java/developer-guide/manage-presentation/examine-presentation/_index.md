---
title: Java でプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Java を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察と高度なコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を特定し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容を読み込んで処理するかどうかを判断する前にプロパティを検査したりする際に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/) と [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/) を使用した軽量な検査、および [IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/) を使用した対象を絞った更新方法を示します。

## **プレゼンテーション形式の確認**

ファイルを検査する際に、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成せずに検査できます。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) メソッドは、PPTX、PPT、ODP など、検出された形式を報告します。

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

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム向けのコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用して [IPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/) オブジェクトを取得し、次に [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出してドキュメント メタデータを読み取ります。このアプローチでは [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成せず、完全なプレゼンテーション オブジェクト モデルを走査する必要もありません。

[IDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/) によって提供される拡張プロパティは、次のインベントリ 値を提供します：

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getSlides--) | スライドの総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 非表示スライドの数。 |
| [getNotes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getNotes--) | ノートを含むスライドの数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | 利用可能な場合の段落の総数。 |
| [getWords](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getWords--) | 単語の総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 音声およびビデオクリップの総数。 |

次の例はこれらの値を [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) オブジェクトを作成せずに読み取り、コンパクトなインベントリを出力します。また、[getHeadingPairs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) と [getTitlesOfParts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

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

各 [IHeadingPair](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iheadingpair/) はグループ名とそのグループ内の項目数を提供します。[IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) はフラットな順序付き配列を返すため、各ヘッディング ペアで指定された連続したタイトル数だけを消費します。

### **保存されたメタデータと形式の制限**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) が返すインベントリ プロパティは、ソース ドキュメントで利用可能なメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していなければ、保存された値は古くなる可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウントやヘッディング ペア、パート タイトルなどの拡張ドキュメント プロパティを提供します。利用可能性はドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを保存できます。プロパティが存在しない、またはドキュメント作成者によって更新されていない場合、Aspose.Slides はスライドから計算せず、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータは、ページ、段落、単語数などの一般的なドキュメント統計情報を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、ヘッディング ペア、パート タイトルのメタデータが利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値や空配列を、対応するコンテンツが存在しないことの決定的な証拠とみなさないでください。

インベントリや事前チェックには軽量メタデータアプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーション プロパティの更新**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成せずに変更することもできます。[IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) で変更を適用し、次に [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

次の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します：

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

以下の画像は更新されたドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの変更されたドキュメント プロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、以下の記事をご参照ください：

- [パスワードで保護されたプレゼンテーション](/slides/ja/java/password-protected-presentation/)
- [書き込み保護されたプレゼンテーション](/slides/ja/java/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getFontsManager--) を使用します。[IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) で埋め込みフォントを取得し、[IFontsManager.getFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getFonts--) でプレゼンテーションで使用されているフォントを取得します。両者を比較して、レンダリングに必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認するにはどうすればよいですか？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) と [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を通じて [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) を読み取ります。これは軽量インベントリに適しています。メモリ内でプレゼンテーションが変更されている場合や、リアルタイムの値を確認する必要がある場合は、[Presentation.getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) を列挙し、各スライドの [ISlide.getHidden](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getHidden--) を調べます。

**カスタム スライド サイズと向きが使用されているか、既定値と異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlideSize--) を呼び出します。[ISlideSize.getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidesize/#getType--)、[ISlideSize.getSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidesize/#getSize--)、および [ISlideSize.getOrientation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidesize/#getOrientation--) を使用して、現在の設定を期待されるプリセットや寸法と比較します。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/) を検索し、[IChartData.getDataSourceType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdata/#getDataSourceType--) を呼び出します。外部ブックの場合は、[IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) を使用します。データ ソースの種類とパスから外部参照があるか判別できますが、対象が利用可能かどうかは別途リソースチェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

単一の「複雑さ」プロパティはありません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) と各スライドの [IBaseSlide.getShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getShapes--) コレクションを走査します。形状数や大きな画像、エフェクト、アニメーション、マルチメディアの有無を指標として使用し、代表的なレンダリングやエクスポートを計測して、スライドが実際にパフォーマンスのボトルネックであるかを判断します。